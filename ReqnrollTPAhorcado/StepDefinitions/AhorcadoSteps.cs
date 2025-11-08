using System;
using System.Threading.Tasks;
using Reqnroll;
using Microsoft.Playwright;

namespace TP_Ahorcado.Features
{
    [Binding]
    public class AhorcadoSteps : IAsyncDisposable
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        // ✅ Inicializa Playwright y abre la app
        [Given("que abro la pagina del juego")]
        public async Task GivenQueAbroLaPaginaDelJuego()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // ⚠️ Cambiá a true si no querés que se abra la ventana
                SlowMo = 250      // Más lento para ver la simulación
            });

            _page = await _browser.NewPageAsync();

            // Cambiá esta URL por la de tu juego (Angular, React, etc.)
            await _page.GotoAsync("https://localhost:7065/counter");
        }

        // ✅ Simula ingresar una letra y presionar "Probar"
        [When("ingreso la letra {string} y presiono Probar")]
        public async Task WhenIngresoLaLetraYPresionoProbar(string letra)
        {
            await _page.FillAsync("#inputLetra", letra);       // campo de texto de la letra
            await _page.ClickAsync("#btnProbarLetra");         // botón de probar letra
        }

        // ✅ Simula ingresar una palabra y presionar "Probar"
        [When("ingreso la palabra {string} y presiono Probar")]
        public async Task WhenIngresoLaPalabraYPresionoProbar(string palabra)
        {
            await _page.FillAsync("#inputLetra", palabra);
            await _page.ClickAsync("#btnProbarLetra");
        }

        // ✅ Verifica estado del juego
        [Then("el juego esta {string}")]
        public async Task ThenElJuegoEsta(string estado)
        {
            var resultText = await _page.InnerTextAsync("#estadoJuego");

            if (estado == "ganado" && !resultText.Contains("Ganaste", StringComparison.OrdinalIgnoreCase))
                throw new Exception($"Se esperaba 'ganado' pero se mostró: {resultText}");

            if (estado == "perdido" && !resultText.Contains("Perdiste", StringComparison.OrdinalIgnoreCase))
                throw new Exception($"Se esperaba 'perdido' pero se mostró: {resultText}");
        }

        // ✅ Verifica el mensaje en pantalla
        [Then("el mensaje contiene {string}")]
        public async Task ThenElMensajeContiene(string mensaje)
        {
            var alert = await _page.InnerTextAsync("#mensajeJuego");
            if (!alert.Contains(mensaje, StringComparison.OrdinalIgnoreCase))
                throw new Exception($"Mensaje esperado '{mensaje}' no encontrado en: {alert}");
        }

        // ✅ Verifica el banner de "Game Over"
        [Then("veo el banner de Game Over")]
        public async Task ThenVeoElBannerDeGameOver()
        {
            var visible = await _page.IsVisibleAsync("#gameOverBanner");
            if (!visible)
                throw new Exception("No se encontró el banner de Game Over en pantalla.");

        }

        // ✅ Verifica los intentos usados
        [Then("los intentos de letra muestran {string}")]
        public async Task ThenLosIntentosDeLetraMuestran(string texto)
        {
            var intentoTexto = await _page.InnerTextAsync("#contadorIntentos");
            if (!intentoTexto.Contains(texto))
                throw new Exception($"Texto esperado '{texto}' no coincide con '{intentoTexto}'");
        }

        // ✅ Cierra el navegador al terminar
        public async ValueTask DisposeAsync()
        {
            if (_browser != null)
                await _browser.CloseAsync();
            _playwright?.Dispose();
        }

    }


}
