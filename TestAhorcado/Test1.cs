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
            string palabra = "ejemplo";

            bool resultado = juego.TirarPalabraYAcertar(palabra);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void IngresaPalabraYAciertaFalse()
        {
            var juego = new TPAhorcado.Program();
            string palabra = "otra";

            bool resultado = juego.TirarPalabraYAcertar(palabra);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestValidarLetraTrue()
        {
            var juego = new TPAhorcado.Program();
            juego.palabraEnJuego = "eje";
            string letra = "o";

            bool resultado = juego.ValidarLetra(letra);

            Assert.IsTrue(resultado);
        }




    }
}
