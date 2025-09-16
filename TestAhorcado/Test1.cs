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

        [TestMethod]
        public void TestTirarLetraEYAcertarFalse()
        {
            var juego = new TPAhorcado.Program();
            string letra = "b";

            bool resultado = juego.TirarLetraYAcertar(letra);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void IngresaPalabraYAciertaTrue()
        {
            var juego = new TPAhorcado.Program();
            string palabra = "otra";

            bool resultado = juego.TirarLetraYAcertar(palabra);

            Assert.IsTrue(resultado);
        }




    }
}
