namespace PayrollConsoleApp
{
    public static class BaseRateCalculator
    {
        #region HORAS MENSUALES POR LEY

        // CALCULAR HORAS MENSUALES POR LEY
        public static decimal CalculateMonthlyLegalHours()
        {
            decimal monthlyWorkedHours = (PayrollSettings.WeeklyWorkHours / PayrollSettings.WorkDaysPerWeek) * PayrollSettings.DaysPerMonth;

            return monthlyWorkedHours;
        }


        // MOSTRAR HORAS MENSUALES POR LEY
        public static void ShowMonthlyLegalHours(decimal monthlyWorkedHours, bool showSeparator, bool showSpace)
        {
            Print.ShowNumber("Horas mes por ley", monthlyWorkedHours, showSeparator, showSpace);
        }

        #endregion




        #region DIAS TRABAJADAS

        // MOSTRAR LOS DIAS TRABAJADAS
        public static void ShowWorkedDays(decimal workedDays, bool showSeparator, bool showSpace)
        {
            Print.ShowNumber("Días trabajados", workedDays, showSeparator, showSpace);
        }

        # endregion




        #region HORAS TRABAJADAS

        // CALCULAR LAS HORAS TRABAJADAS
        public static decimal CalculateWorkedHours(decimal workedDays)
        {
            decimal workedHours = (PayrollSettings.WeeklyWorkHours / PayrollSettings.WorkDaysPerWeek) * workedDays;

            return workedHours;
        }


        // MOSTRAR LAS HORAS TRABAJADAS
        public static void ShowWorkedHours(decimal workedHours, bool showSeparator, bool showSpace)
        {
            Print.ShowNumber("Horas trabajadas", workedHours, showSeparator, showSpace);
        }

        #endregion




        #region VALOR DEL DIA

        // CALCULAR VALOR DEL DIA
        public static decimal CalculateDailyRate(decimal baseSalary)
        {
            decimal dailyRate = baseSalary / PayrollSettings.DaysPerMonth;

            return dailyRate;
        }


        // MOSTRAR VALOR DEL DIA
        public static void ShowDailyRate(decimal dailyRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor día", dailyRate, showSeparator, showSpace);
        }

        #endregion




        #region VALOR DE LA HORA REGULAR

        // CALCULAR VALOR DE LA HORA REGULAR
        public static decimal CalculateHourlyRate(decimal monthlyWorkedHours, decimal baseSalary)
        {
            decimal hourlyRate = baseSalary / monthlyWorkedHours;

            return hourlyRate;
        }


        // MOSTRAR VALOR DE LA HORA REGULAR
        public static void ShowHourlyRate(decimal hourlyRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor hora regular", hourlyRate, showSeparator, showSpace);
        }

        #endregion




        #region VALOR A PAGAR DEL SALARIO BASE

        // CALCULAR VALOR A PAGAR DEL SALARIO BASE
        public static decimal CalculateBaseSalaryPay(decimal hourlyRate, decimal workedHours)
        {
            decimal baseSalaryPay = hourlyRate * workedHours;

            return baseSalaryPay;
        }


        // MOSTRAR VALOR A PAGAR DEL SALARIO BASE
        public static void ShowBaseSalaryPay(decimal baseSalaryPay, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Salario base a pagar", baseSalaryPay, showSeparator, showSpace);
        }

        #endregion




        #region SALARIO DEVENGADO

        // CALCULAR VALOR A PAGAR DEL SALARIO DEVENGADO
        public static decimal CalculateAccruedSalary(decimal baseSalaryPay, decimal totalOvertimePay, decimal holidayWorkPay)
        {
            decimal accruedSalary = baseSalaryPay + totalOvertimePay + holidayWorkPay;

            return accruedSalary;
        }


        // MOSTRAR VALOR A PAGAR DEL SALARIO DEVENGADO
        public static void ShowAccruedSalary(decimal accruedSalary, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Salario devengado", accruedSalary, showSeparator, showSpace);
        }



        // CALCULAR VALOR A PAGAR DEL TOTAL DEVENGADO
        public static decimal CalculateTotalAccruedSalary(decimal accruedSalary, decimal transportationAllowancePay)
        {
            decimal totalAccruedSalary = accruedSalary + transportationAllowancePay;

            return totalAccruedSalary;
        }


        // MOSTRAR VALOR A PAGAR DEL TOTAL DEVENGADO
        public static void ShowTotalAccruedSalary(bool eligibleForTransportationAllowance, decimal totalAccruedSalary, bool showSeparator, bool showSpace)
        {
            if (!eligibleForTransportationAllowance) return;


            Print.ShowMoney("Total devengado", totalAccruedSalary, showSeparator, showSpace);
        }

        #endregion




        # region NETO A PAGAR

        // CALCULAR VALOR NETO A PAGAR
        public static decimal CalculateNetPay(decimal totalAccruedSalary, decimal totalDeductions)
        {
            decimal netPay = totalAccruedSalary - totalDeductions;

            return Math.Round(netPay, MidpointRounding.AwayFromZero);
        }


        // MOSTRAR VALOR NETO A PAGAR
        public static void ShowNetPay(decimal netPay, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Neto a pagar", netPay, showSeparator, showSpace);
        }

        # endregion
    }
}