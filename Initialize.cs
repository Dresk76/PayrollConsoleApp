namespace PayrollConsoleApp
{
    public static class Initialize
    {
        public static void Greeting()
        {
            string  title       = "BIENVENIDO A LA APP";
            string  subTitle    = "CONSOLA DE NÓMINA";
            char    doubleLine  = '='; 


            Print.PrintLine(doubleLine);
            Print.PrintText(title);
            Print.PrintText(subTitle);
            Print.PrintLine(doubleLine, showSeparator: true);
        }
    }
}