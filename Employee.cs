namespace PayrollConsoleApp
{
    // DATOS DE UN EMPLEADO
    public class Employee(int id, 
                        string name, 
                        string lastName, 
                        string identification,
                        string jobTitle, 
                        decimal baseSalary, 
                        int workedDays, 
                        Overtime overtime, 
                        decimal holidayDaysWorked)
    {
        public int Id { get; set; }                     = id;
        public string Name { get; set; }                = name;
        public string LastName { get; set; }            = lastName;
        public string Identification { get; set; }      = identification;
        public string JobTitle { get; set; }            = jobTitle;
        public decimal BaseSalary { get; set; }         = baseSalary;
        public int WorkedDays { get; set; }             = workedDays;
        public Overtime Overtime { get; set; }          = overtime;
        public decimal HolidayDaysWorked { get; set; }  = holidayDaysWorked;
    }



    // HORAS EXTRAS
    public struct Overtime(decimal dayHours, 
                        decimal nightHours, 
                        decimal holidayDayHours, 
                        decimal holidayNightHours)
    {
        public decimal DayHours { get; set; }           = dayHours;
        public decimal NightHours { get; set; }         = nightHours;
        public decimal HolidayDayHours { get; set; }    = holidayDayHours;
        public decimal HolidayNightHours { get; set; }  = holidayNightHours;
    }
}