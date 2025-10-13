namespace TPAhorcado
{
    public class Program
    {
        private string palabraSecreta = "ejemplo";
        public string palabraEnJuego = "";
       public int intentosLetraEnJuego = 0;
        public int intentosPalabraEnJuego = 0;
        private int cantidadVidasPalabra = 3;
        private int cantidadVidasLetras = 6;
        static void Main(string[] args)
        {
           
        }

        public bool TirarLetraYAcertar(string letra)
        {
           if (palabraSecreta.Contains(letra))
           {
              return true;
           }
           else return false;
        }

        public bool TirarPalabraYAcertar(string palabra)
        {
            if (palabraSecreta == palabra)
            {
                return true;
            }
            else return false;
        }

        public bool ValidarLetraRepetida(string letra)
        {
           if (palabraEnJuego.Contains(letra))
            {
                return true;
            }
            else return false;
        }

        public bool Inicializar()
        {
           
            if (intentosLetraEnJuego == 0 && palabraEnJuego == "")
            {
                return true;
            }
            else return false;

        }

        public bool GameOver()
        {
            return intentosLetraEnJuego == cantidadVidasLetras || intentosPalabraEnJuego == cantidadVidasPalabra;
        }

       
    }

}