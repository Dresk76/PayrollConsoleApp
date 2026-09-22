namespace PayrollConsoleApp
{
    public static class AllowanceCalculator
    {
        #region AUXILIO DE TRANSPORTE

        // VALIDAR SI APLICA PARA AUXILIO DE TRANSPORTE
        public static bool IsEligibleForTransportationAllowance(decimal baseSalary)
        {
            decimal minimumWageThreshold = PayrollSettings.MinimumWage * 2m;

            bool eligibleForTransportationAllowance = baseSalary <= minimumWageThreshold;

            return eligibleForTransportationAllowance;
        }



        // CALCULAR VALOR AUXILIO DE TRANSPORTE
        public static decimal CalculateTransportationAllowance(bool eligibleForTransportationAllowance)
        {
            decimal transportationAllowance = eligibleForTransportationAllowance 
                                                ? PayrollSettings.TransportationAllowanceAmount 
                                                : 0m;

            return transportationAllowance;
        }


        // MOSTRAR VALOR AUXILIO DE TRANSPORTE
        public static void ShowTransportationAllowance(bool eligibleForTransportationAllowance, decimal transportationAllowance, bool showSeparator, bool showSpace)
        {
            if (!eligibleForTransportationAllowance) return;


            Print.ShowMoney("Valor auxilio de transporte", transportationAllowance, showSeparator, showSpace);
        }



        // CALCULAR VALOR DIARIO DEL AUXILIO DE TRANSPORTE
        public static decimal CalculateDailyTransportationAllowance(bool eligibleForTransportationAllowance)
        {
            decimal dailyTransportationAllowance = eligibleForTransportationAllowance
                                                    ? PayrollSettings.TransportationAllowanceAmount / PayrollSettings.DaysPerMonth
                                                    : 0m;

            return dailyTransportationAllowance;
        }


        // MOSTRAR VALOR DIARIO DEL AUXILIO DE TRANSPORTE
        public static void ShowDailyTransportationAllowance(bool eligibleForTransportationAllowance, decimal dailyTransportationAllowance, bool showSeparator, bool showSpace)
        {
            if (!eligibleForTransportationAllowance) return;


            Print.ShowMoney("Valor diario del auxilio de transporte", dailyTransportationAllowance, showSeparator, showSpace);
        }



        // CALCULAR AUXILIO DE TRANSPORTE A PAGAR
        public static decimal CalculateTransportationAllowancePay(decimal dailyTransportationAllowance, decimal workedDays)
        {
            decimal transportationAllowancePay = dailyTransportationAllowance * workedDays;

            return transportationAllowancePay;
        }


        // MOSTRAR AUXILIO DE TRANSPORTE A PAGAR
        public static void ShowTransportationAllowancePay(bool eligibleForTransportationAllowance, decimal transportationAllowancePay, bool showSeparator, bool showSpace)
        {
            if (!eligibleForTransportationAllowance) return;

            Print.ShowMoney("Auxilio de transporte", transportationAllowancePay, showSeparator, showSpace);
        }

        #endregion
    }
}