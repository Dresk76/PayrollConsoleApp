using Newtonsoft.Json;
using PayrollConsoleApp;


// MOSTRAR SALUDO
Initialize.Greeting();


// CONFIGURACIÓN DE VISUALIZACIÓN
bool showEmployeeListInformation    = true; // MOSTRAR LA LISTA COMPLETA DE EMPLEADOS
bool showEmployeeInformation        = true; // MOSTRAR LA INFORMACIÓN DEL EMPLEADO
bool showPayrollDetails             = true; // MOSTRAR EL DETALLE DE NÓMINA
bool showPaySummary                 = true; // MOSTRAR EL RESUMEN DE PAGO
bool showRateBreakdown              = true; // MOSTRAR DESGLOSE DE TARIFAS


// RUTA DEL ARCHIVO
string fileName                     = "employees.json";
string path                         = Path.Combine(Directory.GetCurrentDirectory(), fileName);




/*
! PRUEBA DEL CÁLCULO DE NÓMINA DE UN EMPLEADO

* Salario mínimo 2026:        1_750_905m
* Dos salarios mínimos 2026:  3_501_810m
*/

    // Employee mariaLopez = new(
    //     id: 3,
    //     name: "María",
    //     lastName: "López",
    //     identification: "1023456789",
    //     jobTitle: "Desarrolladora Junior",
    //     baseSalary: 1_750_905m,
    //     workedDays: 30,
    //     overtime: new Overtime(5m, 0m, 1m, 0m),
    //     holidayDaysWorked: 1m
    // );

    // EmployeeCalculation(employee: mariaLopez,
    //                     showEmployeeInformation,
    //                     showPayrollDetails,
    //                     showPaySummary,
    //                     showRateBreakdown);

/*
*/



// MOSTRAR EL CÁLCULO DE LA LISTA DE EMPLEADOS
EmployeeListCalculation(path, 
                        showEmployeeListInformation, 
                        showEmployeeInformation, 
                        showPayrollDetails,
                        showPaySummary,
                        showRateBreakdown);







#region CÁLCULO DE UN EMPLEADO

static void EmployeeCalculation(Employee employee, 
                                bool showEmployeeInformation, 
                                bool showPayrollDetails, 
                                bool showPaySummary,
                                bool showRateBreakdown)
{
    // INFORMACIÓN DE UN EMPLEADO
    if (showEmployeeInformation)
        EmployeeInformation(employee);

    // RESUMEN DE NÓMINA
    EmployeePayrollSummary(employee, showPayrollDetails, showPaySummary, showRateBreakdown);
}

#endregion




#region CÁLCULO DE UNA LISTA DE EMPLEADOS

static void EmployeeListCalculation(string path, 
                                    bool showEmployeeListInformation, 
                                    bool showEmployeeInformation, 
                                    bool showPayrollDetails, 
                                    bool showPaySummary,
                                    bool showRateBreakdown)
{
    // VALIDAR EXISTENCIA DEL ARCHIVO JSON DE EMPLEADOS
    bool fileFound = EmployeeService.FileExists(path);
    if (!fileFound) return;


    // GUARDAR LISTA DE EMPLEADOS
    List<Employee> employeeList = EmployeeService.ReadFile(path);


    // INFORMACIÓN LISTA DE EMPLEADOS
    if (showEmployeeListInformation)
        EmployeeListInformation(employeeList);


    foreach (var employee in employeeList)
    {
        // CÁLCULO DE UN EMPLEADO
        EmployeeCalculation(employee, 
                            showEmployeeInformation, 
                            showPayrollDetails, 
                            showPaySummary,
                            showRateBreakdown);
    }
}


// INFORMACIÓN LISTA DE EMPLEADOS
static void EmployeeListInformation(List<Employee> employeeList)
{
    Print.PrintLine('=');
    Print.PrintText($"INFORMACIÓN LISTA DE EMPLEADOS");
    Print.PrintLine('=');

    // MOSTRAR DATOS DE LOS EMPLEADOS
    EmployeeService.PrintListEmployees(employeeList);
    Console.WriteLine();
}

#endregion




#region INFORMACIÓN DE UN EMPLEADO

static void EmployeeInformation(Employee employee)
{
    Print.PrintLine('=');
    Print.PrintText($"INFORMACIÓN DEL EMPLEADO: {employee.Name} {employee.LastName}");
    Print.PrintLine('=');


    // MOSTRAR DATOS DEL EMPLEADO
    EmployeeService.PrintEmployee(employee, false, true);
}

#endregion




#region RESUMEN DE NÓMINA DE UN EMPLEADO

static void EmployeePayrollSummary(Employee employee, 
                                    bool showPayrollDetails, 
                                    bool showPaySummary, 
                                    bool showRateBreakdown)
{
    #region VALORES DEL EMPLEADO

    decimal baseSalary = employee.BaseSalary;
    decimal workedDays = employee.WorkedDays;
    decimal dayOvertimeHours = employee.Overtime.DayHours;
    decimal nightOvertimeHours = employee.Overtime.NightHours;
    decimal holidayDayOvertimeHours = employee.Overtime.HolidayDayHours;
    decimal holidayNightOvertimeHours = employee.Overtime.HolidayNightHours;
    decimal holidayDaysWorked = employee.HolidayDaysWorked;

    #endregion




    #region VALORES DE TARIFAS

    // HORAS MENSUALES POR LEY
    decimal monthlyWorkedHours = BaseRateCalculator.CalculateMonthlyLegalHours();

    // VALOR DEL DIA
    decimal dailyRate = BaseRateCalculator.CalculateDailyRate(baseSalary);

    // VALOR HORA REGULAR
    decimal hourlyRate = BaseRateCalculator.CalculateHourlyRate(monthlyWorkedHours, baseSalary);

    // VALOR HORA EXTRA DIURNA
    decimal dayOvertimeRate = OvertimeCalculator.CalculateDayOvertimeRate(hourlyRate);

    // VALOR HORA EXTRA NOCTURNA
    decimal nightOvertimeRate = OvertimeCalculator.CalculateNightOvertimeRate(hourlyRate);

    // VALOR HORA EXTRA DIURNA EN DOMINGO/FESTIVO
    decimal holidayDayOvertimeRate = OvertimeCalculator.CalculateHolidayDayOvertimeRate(hourlyRate);

    // VALOR HORA EXTRA NOCTURNA EN DOMINGO/FESTIVO
    decimal holidayNightOvertimeRate = OvertimeCalculator.CalculateHolidayNightOvertimeRate(hourlyRate);

    // VALOR DIA TRABAJADO EN DOMINGO/FESTIVO
    decimal holidayWorkRate = OvertimeCalculator.CalculateHolidayWorkRate(hourlyRate);

    // VALIDAR SI APLICA PARA AUXILIO DE TRANSPORTE
    bool eligibleForTransportationAllowance = AllowanceCalculator.IsEligibleForTransportationAllowance(baseSalary);

    // VALOR AUXILIO DE TRANSPORTE
    decimal transportationAllowance = AllowanceCalculator.CalculateTransportationAllowance(eligibleForTransportationAllowance);

    // VALOR DIARIO DEL AUXILIO DE TRANSPORTE
    decimal dailyTransportationAllowance = AllowanceCalculator.CalculateDailyTransportationAllowance(eligibleForTransportationAllowance);

    #endregion




    #region CONCEPTOS TRABAJADOS

    // HORAS TRABAJADAS
    decimal workedHours = BaseRateCalculator.CalculateWorkedHours(workedDays);

    // SALARIO BASE A PAGAR
    decimal baseSalaryPay = BaseRateCalculator.CalculateBaseSalaryPay(hourlyRate, workedHours);

    // HORAS EXTRAS DIURNAS
    decimal dayOvertimePay = OvertimeCalculator.CalculateDayOvertimePay(dayOvertimeHours, dayOvertimeRate);

    // HORAS EXTRAS NOCTURNAS
    decimal nightOvertimePay = OvertimeCalculator.CalculateNightOvertimePay(nightOvertimeHours, nightOvertimeRate);

    // HORAS EXTRAS DIURNAS EN DOMINGO/FESTIVO
    decimal holidayDayOvertimePay = OvertimeCalculator.CalculateHolidayDayOvertimePay(holidayDayOvertimeHours, holidayDayOvertimeRate);

    // HORAS EXTRAS NOCTURNAS EN DOMINGO/FESTIVO
    decimal holidayNightOvertimePay = OvertimeCalculator.CalculateHolidayNightOvertimePay(holidayNightOvertimeHours, holidayNightOvertimeRate);

    // DIA TRABAJADO EN DOMINGO/FESTIVO
    decimal holidayWorkPay = OvertimeCalculator.CalculateHolidayWorkPay(holidayDaysWorked, holidayWorkRate);

    // TOTAL PAGOS ADICIONALES
    decimal totalAdditionalPay = OvertimeCalculator.CalculateTotalAdditionalPay(dayOvertimePay,
                                                                                nightOvertimePay,
                                                                                holidayDayOvertimePay,
                                                                                holidayNightOvertimePay,
                                                                                holidayWorkPay);

    #endregion




    #region RESUMEN DE NÓMINA

    // SALARIO DEVENGADO
    decimal accruedSalary = BaseRateCalculator.CalculateAccruedSalary(baseSalaryPay, totalAdditionalPay, holidayWorkPay);

    // AUXILIO DE TRANSPORTE
    decimal transportationAllowancePay = AllowanceCalculator.CalculateTransportationAllowancePay(dailyTransportationAllowance, workedDays);

    // TOTAL DEVENGADO
    decimal totalAccruedSalary = BaseRateCalculator.CalculateTotalAccruedSalary(accruedSalary, transportationAllowancePay);

    // DESCUENTO DE SALUD
    decimal healthDeduction = DeductionCalculator.CalculateHealthDeductionAmount(accruedSalary);

    // DESCUENTO DE PENSIÓN
    decimal pensionDeduction = DeductionCalculator.CalculatePensionDeductionAmount(accruedSalary);

    // TOTAL DEDUCCIONES
    decimal totalDeductions = DeductionCalculator.CalculateTotalDeductions(healthDeduction, pensionDeduction);

    // NETO A PAGAR
    decimal netPay = BaseRateCalculator.CalculateNetPay(totalAccruedSalary, totalDeductions);

    #endregion




    #region MOSTRAR DESGLOSE DE TARIFAS

    if (showRateBreakdown)
    {
        Print.PrintLine('=');
        Print.PrintText($"DESGLOSE DE TARIFAS");
        Print.PrintLine('=');

        // HORAS HORAS MENSUALES POR LEY
        BaseRateCalculator.ShowMonthlyLegalHours(monthlyWorkedHours, false, false);

        // VALOR DEL DIA
        BaseRateCalculator.ShowDailyRate(dailyRate, false, false);

        // VALOR DE LA HORA REGULAR
        BaseRateCalculator.ShowHourlyRate(hourlyRate, false, false);

        // VALOR HORA EXTRA DIURNA
        OvertimeCalculator.ShowDayOvertimeRate(dayOvertimeRate, false, false);

        // VALOR HORA EXTRA NOCTURNA
        OvertimeCalculator.ShowNightOvertimeRate(nightOvertimeRate, false, false);

        // VALOR HORA EXTRA DIURNA DOMINICAL O FESTIVA
        OvertimeCalculator.ShowHolidayDayOvertimeRate(holidayDayOvertimeRate, false, false);

        // VALOR HORA EXTRA NOCTURNA DOMINICAL O FESTIVA
        OvertimeCalculator.ShowHolidayNightOvertimeRate(holidayNightOvertimeRate, false, false);

        // VALOR DIAS DOMINICALES O FESTIVOS TRABAJADOS
        OvertimeCalculator.ShowHolidayWorkRate(holidayWorkRate, false, false);

        // VALOR AUXILIO DE TRANSPORTE
        AllowanceCalculator.ShowTransportationAllowance(eligibleForTransportationAllowance, transportationAllowance, false, false);

        // VALOR DIARIO DEL AUXILIO DE TRANSPORTE
        AllowanceCalculator.ShowDailyTransportationAllowance(eligibleForTransportationAllowance, dailyTransportationAllowance, false, false);

        // VALOR DESCUENTO DE SALUD
        DeductionCalculator.ShowHealthDeductionPercentage(false, false);

        // VALOR DESCUENTO DE PENSIÓN
        DeductionCalculator.ShowPensionDeductionPercentage(false, true);
    }

    #endregion




    #region MOSTRAR DETALLE DE NÓMINA

    if (showPayrollDetails)
    {
        Print.PrintLine('=');
        Print.PrintText($"DETALLE DE NÓMINA");
        Print.PrintLine('=');

        // DIAS TRABAJADAS
        BaseRateCalculator.ShowWorkedDays(workedDays, false, false);

        // HORAS TRABAJADAS
        BaseRateCalculator.ShowWorkedHours(workedHours, false, false);

        // SALARIO BASE
        BaseRateCalculator.ShowBaseSalaryPay(baseSalaryPay, false, false);

        // HORAS EXTRAS DIURNAS
        OvertimeCalculator.ShowDayOvertimePay(dayOvertimeHours, dayOvertimePay, false, false);

        // HORAS EXTRAS NOCTURNAS
        OvertimeCalculator.ShowNightOvertimePay(nightOvertimeHours, nightOvertimePay, false, false);

        // HORAS EXTRAS DIURNAS EN DOMINGO/FESTIVO
        OvertimeCalculator.ShowHolidayDayOvertimePay(holidayDayOvertimeHours, holidayDayOvertimePay, false, false);

        // HORAS EXTRAS NOCTURNAS EN DOMINGO/FESTIVO
        OvertimeCalculator.ShowHolidayNightOvertimePay(holidayNightOvertimeHours, holidayNightOvertimePay, false, false);

        // DIA TRABAJADO EN DOMINGO/FESTIVO
        OvertimeCalculator.ShowHolidayWorkPay(holidayDaysWorked, holidayWorkPay, false, true);
    }

    #endregion




    #region MOSTRAR RESUMEN DE PAGO

    if (showPaySummary)
    {
        Print.PrintLine('=');
        Print.PrintText($"RESUMEN DE PAGO");
        Print.PrintLine('=');

        // SALARIO DEVENGADO
        BaseRateCalculator.ShowAccruedSalary(accruedSalary, true, false);

        // AUXILIO DE TRANSPORTE
        AllowanceCalculator.ShowTransportationAllowancePay(eligibleForTransportationAllowance, transportationAllowancePay, true, false);
        
        // TOTAL DEVENGADO
        BaseRateCalculator.ShowTotalAccruedSalary(eligibleForTransportationAllowance, totalAccruedSalary, true, false);

        // DESCUENTO SALUD
        DeductionCalculator.ShowHealthDeductionAmount(healthDeduction, true, false);

        // DESCUENTO PENSIÓN
        DeductionCalculator.ShowPensionDeductionAmount(pensionDeduction, true, false);

        // NETO A PAGAR
        BaseRateCalculator.ShowNetPay(netPay, true, true);
    }

    #endregion
}

#endregion