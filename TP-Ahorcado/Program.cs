namespace TPAhorcado
{
    public class JuegoAhorcado
    {
        public string palabraSecreta = "ejemplo";
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
            bool acierto = false;
            var nuevaPalabra = "";

            // Recorremos cada letra de la palabra secreta
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                // Si la letra coincide, la mostramos
                if (palabraSecreta[i].ToString().ToLower() == letra.ToLower())
                {
                    nuevaPalabra += palabraSecreta[i]; // reemplaza el _
                    acierto = true;
                }
                else
                {
                    // Mantiene lo que ya se había adivinado
                    if (palabraEnJuego.Length > i)
                        nuevaPalabra += palabraEnJuego[i];
                    else
                        nuevaPalabra += "_";
                }
            }

            // Actualizamos la palabra en juego
            palabraEnJuego = nuevaPalabra;

            // Si no acertó, sumamos un intento
            if (!acierto)
                intentosLetraEnJuego++;

            return acierto;
        }


        public bool TirarPalabraYAcertar(string palabra)
        {
            if (palabraSecreta == palabra)
            {
                return true;
            }
            else
            {
                intentosPalabraEnJuego++;
                GameOver();
                return false;
            }
        }

        public bool ValidarLetraRepetida(string letra)
        {
            if (palabraEnJuego.Contains(letra))
            {
                return true;
            }
            else {
                TirarLetraYAcertar(letra);
                return false; 
            }
        }

        public bool Inicializar()
        {
           
            if (intentosLetraEnJuego == 0 && intentosPalabraEnJuego == 0 && palabraEnJuego == "")
            {
                return true;
            }
            else return false;

        }

        public bool GameOver()
        {
            return intentosLetraEnJuego == cantidadVidasLetras || intentosPalabraEnJuego == cantidadVidasPalabra;
        }

        public bool EsLetraOPalabra(string palabraOLetra)
        {
            if (palabraOLetra.Length == 1)
            {
                ValidarLetraRepetida(palabraOLetra);
                return true;
            }
            else {
                TirarPalabraYAcertar(palabraOLetra);
                return false ;
            }
        }

        public void Reiniciar()
        {
            palabraEnJuego = "";
            intentosLetraEnJuego = 0;
            intentosPalabraEnJuego = 0;
        }

        public string MostrarPalabra()
        {
            // Si ya adivinó la palabra completa, devolvemos la palabra separada por espacios
            if (string.Equals(palabraEnJuego, palabraSecreta, StringComparison.OrdinalIgnoreCase))
            {
                return string.Join(" ", palabraSecreta.ToCharArray());
            }

            // Aseguramos comparar sin distinción de mayúsculas
            var palabraEnJuegoLower = (palabraEnJuego ?? "").ToLowerInvariant();
            var palabraSecretaLower = (palabraSecreta ?? "").ToLowerInvariant();

            return string.Concat(palabraSecretaLower.Select((c, i) =>
                palabraEnJuegoLower.Length > i && palabraEnJuegoLower[i] == c
                    ? $"{palabraSecreta[i]} "   // mostramos el carácter con la capitalización original
                    : "_ "));
        }
    }
    
}