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
        public void TestValidarLetraRepetidaTrue()
        {
            var juego = new TPAhorcado.Program();
            juego.palabraEnJuego = "eje";
            string letra = "e";

            bool resultado = juego.ValidarLetraRepetida(letra);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestValidarLetraRepetidaFalse()
        {
            var juego = new TPAhorcado.Program();
            juego.palabraEnJuego = "eje";
            string letra = "o";

            bool resultado = juego.ValidarLetraRepetida(letra);

            Assert.IsFalse(resultado);
        }


        [TestMethod]
        public void TestSumaCantidadIntentosTrue()
        {
            var juego = new TPAhorcado.Program();
            juego.palabraEnJuego = "eje";
            string letra = "o";

            bool resultado = juego.SumaIntento(letra);

            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestSumaCantidadIntentosFalse()
        {
            var juego = new TPAhorcado.Program();
            juego.palabraEnJuego = "eje";
            string letra = "e";

            bool resultado = juego.SumaIntento(letra);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestInicializarTrue()
        {
            var juego = new TPAhorcado.Program();
            juego.intentosEnJuego = 0;
            juego.palabraEnJuego = "";


            bool resultado = juego.Inicializar();


            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestInicializarFalse()
        {
            var juego = new TPAhorcado.Program();
            juego.intentosEnJuego = 1;
            juego.palabraEnJuego = "e";


            bool resultado = juego.Inicializar();

            Assert.IsFalse(resultado);
        }

    }
}
