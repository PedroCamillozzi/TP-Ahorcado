namespace TPAhorcado
{
    public class Program
    {
        private string palabraSecreta = "ejemplo";
        public string palabraEnJuego = "";
       public int intentosEnJuego = 0;
        private int intentosTotales = 6;
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

        public bool SumaIntento(string letra)
        {
            if (!palabraEnJuego.Contains(letra))
            {
                intentosEnJuego++;
                return true;
            }
            else return false;
        }

    }

}