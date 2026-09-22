using System.Globalization;

namespace PayrollConsoleApp
{
    // FORMATO DE MONEDA COLOMBIANA
    public static class CurrencyFormat
    {
        // CONFIGURACIÓN DE JORNADA LABORAL
        private static readonly CultureInfo Colombia = new("es-CO");




        // FORMATO DE PESO COLOMBIANO
        public static string ColombianCurrencyFormat(decimal value)
        {
            return value.ToString("C2", Colombia);
        }
    }
}