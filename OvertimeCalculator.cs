namespace PayrollConsoleApp
{
    public static class OvertimeCalculator
    {
        // MULTIPLICADORES
        private const decimal DayOvertimeMultiplier             = 1.25m;
        private const decimal NightOvertimeMultiplier           = 1.75m;
        private const decimal HolidayDayOvertimeMultiplier      = 2.15m;
        private const decimal HolidayNightOvertimeMultiplier    = 2.65m;
        private const decimal HolidayWorkMultiplier             = 1.90m;




        #region HORA EXTRA DIURNA 25%

        // CALCULAR VALOR HORA EXTRA DIURNA
        public static decimal CalculateDayOvertimeRate(decimal hourlyRate)
        {
            decimal dayOvertimeRate = hourlyRate * DayOvertimeMultiplier;

            return dayOvertimeRate;
        }


        // MOSTRAR VALOR HORA EXTRA DIURNA
        public static void ShowDayOvertimeRate(decimal dayOvertimeRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor hora extra diurna (25%)", dayOvertimeRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS
        public static decimal CalculateDayOvertimePay(decimal dayOvertimeHours, decimal dayOvertimeRate)
        {
            decimal dayOvertimePay = dayOvertimeHours * dayOvertimeRate;

            return dayOvertimePay;
        }


        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS
        public static void ShowDayOvertimePay(decimal dayOvertimeHours, decimal dayOvertimePay, bool showSeparator, bool showSpace)
        {
            string message = dayOvertimeHours == 1
                                                ? "Hora extra diurna"
                                                : "Horas extras diurnas";


            Print.ShowMoneyWithQuantity(message, dayOvertimeHours, dayOvertimePay, showSeparator, showSpace);
        }

        #endregion




        #region HORA EXTRA NOCTURNA 75%

        // CALCULAR VALOR HORA EXTRA NOCTURNA
        public static decimal CalculateNightOvertimeRate(decimal hourlyRate)
        {
            decimal nightOvertimeRate = hourlyRate * NightOvertimeMultiplier;

            return nightOvertimeRate;
        }


        // MOSTRAR VALOR HORA EXTRA NOCTURNA
        public static void ShowNightOvertimeRate(decimal nightOvertimeRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor hora extra nocturna (75%)", nightOvertimeRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS
        public static decimal CalculateNightOvertimePay(decimal nightOvertimeHours, decimal nightOvertimeRate)
        {
            decimal nightOvertimePay = nightOvertimeHours * nightOvertimeRate;

            return nightOvertimePay;
        }


        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS
        public static void ShowNightOvertimePay(decimal nightOvertimeHours, decimal nightOvertimePay, bool showSeparator, bool showSpace)
        {
            string message = nightOvertimeHours == 1
                                                ? "Hora extra nocturna"
                                                : "Horas extras nocturnas";


            Print.ShowMoneyWithQuantity(message, nightOvertimeHours, nightOvertimePay, showSeparator, showSpace);
        }

        #endregion




        #region HORA EXTRA DIURNA EN DOMINGO/FESTIVO 115%

        // CALCULAR VALOR HORA EXTRA DIURNA EN DOMINGO/FESTIVO
        public static decimal CalculateHolidayDayOvertimeRate(decimal hourlyRate)
        {
            decimal holidayDayOvertimeRate = hourlyRate * HolidayDayOvertimeMultiplier;

            return holidayDayOvertimeRate;
        }


        // MOSTRAR VALOR HORA EXTRA DIURNA EN DOMINGO/FESTIVO
        public static void ShowHolidayDayOvertimeRate(decimal holidayDayOvertimeRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor hora extra diurna en domingo/festivo (115%)", holidayDayOvertimeRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS EN DOMINGO/FESTIVO
        public static decimal CalculateHolidayDayOvertimePay(decimal holidayDayOvertimeHours, decimal holidayDayOvertimeRate)
        {
            decimal holidayDayOvertimePay = holidayDayOvertimeHours * holidayDayOvertimeRate;

            return holidayDayOvertimePay;
        }


        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS DIURNAS EN DOMINGO/FESTIVO
        public static void ShowHolidayDayOvertimePay(decimal holidayDayOvertimeHours, decimal holidayDayOvertimePay, bool showSeparator, bool showSpace)
        {
            string message = holidayDayOvertimeHours == 1 
                                                    ? "Hora extra diurna en domingo/festivo"
                                                    : "Horas extras diurnas en domingos/festivos";


            Print.ShowMoneyWithQuantity(message, holidayDayOvertimeHours, holidayDayOvertimePay, showSeparator, showSpace);
        }

        #endregion




        #region HORA EXTRA NOCTURNA EN DOMINGO/FESTIVO 165%

        // CALCULAR VALOR HORA EXTRA NOCTURNA EN DOMINGO/FESTIVO
        public static decimal CalculateHolidayNightOvertimeRate(decimal hourlyRate)
        {
            decimal holidayNightOvertimeRate = hourlyRate * HolidayNightOvertimeMultiplier;

            return holidayNightOvertimeRate;
        }


        // MOSTRAR VALOR HORA EXTRA NOCTURNA EN DOMINGO/FESTIVO
        public static void ShowHolidayNightOvertimeRate(decimal holidayNightOvertimeRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor hora extra nocturna en domingo/festivo (165%)", holidayNightOvertimeRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS EN DOMINGO/FESTIVO
        public static decimal CalculateHolidayNightOvertimePay(decimal holidayNightOvertimeHours, decimal holidayNightOvertimeRate)
        {
            decimal holidayNightOvertimePay = holidayNightOvertimeHours * holidayNightOvertimeRate;

            return holidayNightOvertimePay;
        }


        // MOSTRAR VALOR A PAGAR DE LAS HORAS EXTRAS NOCTURNAS EN DOMINGO/FESTIVO
        public static void ShowHolidayNightOvertimePay(decimal holidayNightOvertimeHours, decimal holidayNightOvertimePay, bool showSeparator, bool showSpace)
        {
            string message = holidayNightOvertimeHours == 1
                                                        ? "Hora extra nocturna en domingo/festivo"
                                                        : "Horas extras nocturnas en domingos/festivos";


            Print.ShowMoneyWithQuantity(message, holidayNightOvertimeHours, holidayNightOvertimePay, showSeparator, showSpace);
        }

        #endregion




        #region DIA TRABAJADO EN DOMINGO/FESTIVO 90%

        // CALCULAR VALOR DIA TRABAJADO EN DOMINGO/FESTIVO
        public static decimal CalculateHolidayWorkRate(decimal hourlyRate)
        {
            decimal holidayWorkRate = hourlyRate * HolidayWorkMultiplier;

            return holidayWorkRate;
        }


        // MOSTRAR VALOR DIA TRABAJADO EN DOMINGO/FESTIVO
        public static void ShowHolidayWorkRate(decimal holidayWorkRate, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Valor día trabajado en domingo/festivo (90%)", holidayWorkRate, showSeparator, showSpace);
        }



        // CALCULAR VALOR A PAGAR DE DIA TRABAJADO EN DOMINGO/FESTIVO
        public static decimal CalculateHolidayWorkPay(decimal holidayDaysWorked, decimal holidayWorkRate)
        {
            decimal holidayWorkPay = holidayDaysWorked * holidayWorkRate;

            return holidayWorkPay;
        }


        // MOSTRAR VALOR A PAGAR DE DIA TRABAJADO EN DOMINGO/FESTIVO
        public static void ShowHolidayWorkPay(decimal holidayDaysWorked, decimal holidayWorkPay, bool showSeparator, bool showSpace)
        {
            string message = holidayDaysWorked == 1 
                                                ? "Día trabajado en domingo/festivo" 
                                                : "Días trabajados en domingos/festivos";


            Print.ShowMoneyWithQuantity(message, holidayDaysWorked, holidayWorkPay, showSeparator, showSpace);
        }

        #endregion




        #region TOTAL PAGOS ADICIONALES

        // CALCULAR VALOR TOTAL PAGOS ADICIONALES
        public static decimal CalculateTotalAdditionalPay(decimal dayOvertimePay, 
                                                        decimal nightOvertimePay, 
                                                        decimal holidayDayOvertimePay, 
                                                        decimal holidayNightOvertimePay, 
                                                        decimal holidayWorkPay)
        {
            decimal totalAdditionalPay = dayOvertimePay + nightOvertimePay + holidayDayOvertimePay + holidayNightOvertimePay + holidayWorkPay;

            return totalAdditionalPay;
        }


        // MOSTRAR VALOR TOTAL PAGOS ADICIONALES
        public static void ShowTotalAdditionalPay(decimal totalAdditionalPay, bool showSeparator, bool showSpace)
        {
            Print.ShowMoney("Total pagos adicionales", totalAdditionalPay, showSeparator, showSpace);
        }

        #endregion
    }
}