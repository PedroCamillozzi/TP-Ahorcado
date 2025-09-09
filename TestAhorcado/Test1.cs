using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Ahorcado
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestTirarLetraEYAcertarTrue()
        {
            var juego = new TPAhorcado.Program();
            string letra = "e";

            bool resultado = juego.TirarLetraYAcertar(letra);

            Assert.IsTrue(resultado);
        }

        
        
    }
}
