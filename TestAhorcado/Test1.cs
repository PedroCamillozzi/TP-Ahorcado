using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Ahorcado
{
    [TestClass]
    public sealed class Test1
    {
        
        [TestMethod]
        public void GameOverTrue()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            juego.intentosLetraEnJuego = 6;
            juego.intentosPalabraEnJuego = 3;

            bool resultado = juego.GameOver();

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void GameOverFalse()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            juego.intentosLetraEnJuego = 2;
            juego.intentosPalabraEnJuego = 2;

            bool resultado = juego.GameOver();

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestTirarLetraEYAcertarTrue()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            string letra = "e";

            bool resultado = juego.TirarLetraYAcertar(letra);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestTirarLetraEYAcertarFalse()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            string letra = "b";

            bool resultado = juego.TirarLetraYAcertar(letra);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void IngresaPalabraYAciertaTrue()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            string palabra = "ejemplo";

            bool resultado = juego.TirarPalabraYAcertar(palabra);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void IngresaPalabraYAciertaFalse()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            string palabra = "otra";

            bool resultado = juego.TirarPalabraYAcertar(palabra);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestValidarLetraRepetidaTrue()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            juego.palabraEnJuego = "eje";
            string letra = "e";

            bool resultado = juego.ValidarLetraRepetida(letra);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestValidarLetraRepetidaFalse()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            juego.palabraEnJuego = "eje";
            string letra = "o";

            bool resultado = juego.ValidarLetraRepetida(letra);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestInicializarTrue()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            juego.intentosLetraEnJuego = 0;
            juego.palabraEnJuego = "";


            bool resultado = juego.Inicializar();


            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestInicializarFalse()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            juego.intentosLetraEnJuego = 1;
            juego.palabraEnJuego = "e";


            bool resultado = juego.Inicializar();

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void TestEsLetraOPalabraTrue()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            string palabraOLetra = "a";


            bool resultado = juego.EsLetraOPalabra(palabraOLetra);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestEsLetraOPalabraFalse()
        {
            var juego = new TPAhorcado.JuegoAhorcado();
            string palabraOLetra = "pepe";

            bool resultado = juego.EsLetraOPalabra(palabraOLetra);

            Assert.IsFalse(resultado);
        }
    }
}
