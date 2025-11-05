using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Reqnroll;
using static PlaywrightHooks;

[Binding]
public class UiSteps
{
    private IBrowserContext _ctx = null!;
    private IPage _page = null!;

    // ---------- Hooks ----------
    [BeforeScenario]
    public async Task BeforeScenario()
    {
        _ctx = await Browser.NewContextAsync(new BrowserNewContextOptions
        {
            ViewportSize = new() { Width = 1280, Height = 900 }
        });
        _page = await _ctx.NewPageAsync();
    }

    [AfterScenario]
    public async Task AfterScenario() => await _ctx.CloseAsync();

    // ---------- Given ----------
    [Given(@"que abro la página del juego")]
    public async Task GivenOpenGamePage()
    {
        await _page.GotoAsync($"{PlaywrightHooks.BaseUrl}/counter");
        // Acepta el H1 exacto o aproximado por si cambia levemente el texto
        var heading = _page.GetByRole(AriaRole.Heading, new() { Name = "Juego del Ahorcado" });
        if (!await heading.IsVisibleAsync())
        {
            // fallback: cualquier h1 que contenga “Ahorcado”
            await _page.Locator("h1:has-text('Ahorcado')").WaitForAsync();
        }
    }

    // ---------- When ----------
    // Acepta tanto letra como palabra (mismo método)
    [When(@"ingreso la letra ""([^""]+)"" y presiono Probar")]
    public async Task WhenEnterLetterAndTry(string letter) => await Play(letter);

    [When(@"ingreso la palabra ""([^""]+)"" y presiono Probar")]
    public async Task WhenEnterWordAndTry(string word) => await Play(word);

    // ---------- Then ----------
    [Then(@"el juego está ""(.*)""")]
    public async Task ThenGameIs(string estado)
    {
        var st = estado.Trim().ToLowerInvariant();
        switch (st)
        {
            case "ganado":
                await ExpectMessageContainsIgnorePunctuation("ganaste");
                break;
            case "perdido":
                await _page.Locator("[data-testid=gameover-banner]").WaitForAsync();
                break;
            default:
                throw new ArgumentException($"Estado desconocido: {estado}");
        }
    }

    [Then(@"el mensaje contiene ""([^""]+)""")]
    public async Task ThenMessageContains(string expected)
    {
        await ExpectMessageContainsIgnorePunctuation(expected);
    }

    [Then(@"los intentos de letra muestran ""([^""]+)""")]
    public async Task ThenLetterAttemptsShow(string expected)
    {
        var raw = await _page.Locator("[data-testid=intentos-letra]").InnerTextAsync();
        if (!raw.Contains(expected, StringComparison.OrdinalIgnoreCase))
            throw new Exception($"Se esperaba '{expected}' en '{raw}'.");
    }

    [Then(@"veo el banner de Game Over")]
    public async Task ThenSeeGameOverBanner() =>
        await _page.Locator("[data-testid=gameover-banner]").WaitForAsync();

    // ---------- Helpers ----------
    private async Task Play(string input)
    {
        var entrada = _page.Locator("[data-testid=entrada]");
        await entrada.FillAsync("");                 // limpiar por si quedó algo
        await entrada.FillAsync(input);
        await _page.Locator("[data-testid=probar-btn]").ClickAsync();
        // breve espera para render de Blazor
        await _page.WaitForTimeoutAsync(80);
    }

    // Hace el contains sin depender de signos/emoji: normaliza y busca substring
    private async Task ExpectMessageContainsIgnorePunctuation(string expectedFragment)
    {
        expectedFragment = Normalize(expectedFragment);
        await _page.WaitForFunctionAsync(
            """(frag) => {
                  const el = document.querySelector("[data-testid='mensaje']");
        if (!el) return false;
        const txt = el.innerText || "";
        const norm = txt
              .normalize("NFD").replace(/\p{ Diacritic}/ gu,"")
                        .replace(/ [^\p{ L}\p{ N}\s]/ gu,"")
                        .toLowerCase().trim();
        return norm.includes(frag);
    }""",
            Normalize(expectedFragment)
        );
    }

private static string Normalize(string s) =>
    Regex.Replace(
        s.Normalize(NormalizationForm.FormD)
         .ToLowerInvariant().Trim(),
        @"[^\p{L}\p{N}\s]", ""
    );
}
