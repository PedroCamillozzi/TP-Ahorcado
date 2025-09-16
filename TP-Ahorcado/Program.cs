namespace TPAhorcado
{
    public class Program
    {
        private string palabraSecreta = "ejemplo";
        public string palabraEnJuego = "";
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

        public bool ValidarLetra(string letra)
        {
            return false;
        }

    }

}