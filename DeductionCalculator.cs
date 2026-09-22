namespace PayrollConsoleApp
{
    public static class DeductionCalculator
    {
        // TASAS DE DESCUENTO
        private const decimal HealthDeductionRate   = 0.04m;
        private const decimal PensionDeductionRate  = 0.04m;




        #region DESCUENTO DE SALUD 4%

        // MOSTRAR PORCENTAJE DE DESCUENTO DE SALUD
        public static void ShowHealthDeductionPercentage(bool showSeparator, bool showSpace)
        {
            Print.ShowPercentage("Porcentaje descuento salud", HealthDeductionRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A DESCONTAR DE SALUD
        public static decimal CalculateHealthDeductionAmount(decimal accruedSalary)
        {
            decimal healthDeduction = accruedSalary * HealthDeductionRate;

            return healthDeduction;
        }


        // MOSTRAR VALOR A DESCONTAR DE SALUD
        public static void ShowHealthDeductionAmount(decimal healthDeduction, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Descuento salud (4%)", healthDeduction, showSeparator, showSpace);
        }

        #endregion




        #region DESCUENTO DE PENSIÓN 4%

        // MOSTRAR PORCENTAJE DE DESCUENTO DE PENSIÓN
        public static void ShowPensionDeductionPercentage(bool showSeparator, bool showSpace)
        {
            Print.ShowPercentage("Porcentaje descuento pensión", PensionDeductionRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A DESCONTAR DE PENSIÓN
        public static decimal CalculatePensionDeductionAmount(decimal accruedSalary)
        {
            decimal pensionDeduction = accruedSalary * PensionDeductionRate;

            return pensionDeduction;
        }


        // MOSTRAR VALOR A DESCONTAR DE PENSIÓN
        public static void ShowPensionDeductionAmount(decimal pensionDeduction, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Descuento pensión (4%)", pensionDeduction, showSeparator, showSpace);
        }

        #endregion




        #region TOTAL DEDUCCIONES

        // CALCULAR TOTAL DEDUCCIONES
        public static decimal CalculateTotalDeductions(decimal healthDeduction, decimal pensionDeduction)
        {
            decimal totalDeductions = healthDeduction + pensionDeduction;

            return totalDeductions;
        }


        // MOSTRAR TOTAL DEDUCCIONES
        public static void ShowTotalDeductions(decimal totalDeductions, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Total deducciones", totalDeductions, showSeparator, showSpace);
        }

        #endregion
    }
}