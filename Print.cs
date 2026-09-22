namespace PayrollConsoleApp
{
    public static class Print
    {
        // CANTIDAD DE DECORACIÓN INICIAL EN LOS TEXTOS
        private const int AmountDecoration = 2;




        #region CENTER
        
        // CENTRA UN TEXTO EN LA CONSOLA
        private static string CenterText(string text)
        {
            int spaces = (Console.WindowWidth - text.Length) / 2;

            var decoration  = CreateCharacters('-', AmountDecoration);
            var padding     = CreateCharacters(' ', spaces - AmountDecoration);

            if (spaces <= 0)
            {
                return text;
            }

            return decoration + padding + text + padding + decoration;
        }



        // CENTRA UNA LINEA DE CHARACTERS EN LA CONSOLA
        private static string CenterLine(char character)
        {
            int width   = Console.WindowWidth;
            var line    = CreateCharacters(character, width);

            return line;
        }

        #endregion




        # region PRINT
        
        // IMPRIME UNA CANTIDAD DE CHARACTERS EN LA CONSOLA
        private static string CreateCharacters(char character, int value)
        {
            return new string(character, Math.Max(0, value));
        }



        // IMPRIME UN TEXTO CENTRADO EN LA CONSOLA
        public static void PrintText(string text)
        {
            Console.WriteLine(CenterText(text));
        }



        // IMPRIME UNA LINEA DE CHARACTERS CENTRADOS EN LA CONSOLA
        public static void PrintLine(char character, bool showSeparator = false)
        {
            Console.WriteLine(showSeparator ? CenterLine(character) + Environment.NewLine 
                                            : CenterLine(character));
        }

        # endregion




        # region MOSTRAR CALCULOS

        // MOSTRAR LOS CÁLCULOS REALIZADOS
        private static void Show(string message, object value, bool showSeparator, bool showSpace)
        {
            Console.WriteLine($"- {message,-53}: {value}");

            if (showSeparator) PrintLine('-');

            if (showSpace) Console.WriteLine();
        }



        // MOSTRAR FORMATO TEXTO
        public static void ShowText(string message, object value, bool showSeparator, bool showSpace)
        {
            Show(message, value, showSeparator, showSpace);
        }



        // MOSTRAR LOS CÁLCULOS REALIZADOS CON FORMATO MONEDA
        public static void ShowMoney(string message, decimal value, bool showSeparator, bool showSpace)
        {
            string money = CurrencyFormat.ColombianCurrencyFormat(value);

            Show(message, money, showSeparator, showSpace);
        }



        // MOSTRAR LOS CÁLCULOS REALIZADOS CON FORMATO MONEDA Y LAS HORAS O DIAS
        public static void ShowMoneyWithQuantity(string message, decimal times, decimal value, bool showSeparator, bool showSpace)
        {
            if (times <= 0) return;

            string money = CurrencyFormat.ColombianCurrencyFormat(value);
            string label = $"[{times:0.##}] {message}";

            Show(label, money, showSeparator, showSpace);
        }



        // MUESTRA SIEMPRE, AUNQUE SEA CERO. PARA DÍAS Y HORAS TRABAJADAS
        public static void ShowNumber(string message, decimal value, bool showSeparator, bool showSpace)
        {
            string number = $"{value:0.##}";

            Show(message, number, showSeparator, showSpace);
        }



        // MUESTRA SOLO SI HAY VALOR. PARA HORAS EXTRAS Y DIAS FESTIVOS
        public static void ShowNumberIfAny(string message, decimal value, bool showSeparator, bool showSpace)
        {
            if (value <= 0) return;

            ShowNumber(message, value, showSeparator, showSpace);
        }



        // MOSTRAR LOS CÁLCULOS REALIZADOS CON FORMATO PORCENTAJE
        public static void ShowPercentage(string message, decimal value, bool showSeparator, bool showSpace)
        {
            string percentage = $"{value:P1}";

            Show(message, percentage, showSeparator, showSpace);
        }

        #endregion
    }
}