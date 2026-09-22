using Newtonsoft.Json;

namespace PayrollConsoleApp
{
    public static class EmployeeService
    {
        // MOSTRAR LOS DATOS DE UN EMPLEADO
        public static void PrintEmployee(Employee employee, bool showSeparator, bool showSpace)
        {
            int id                              = employee.Id;
            string name                         = employee.Name;
            string lastName                     = employee.LastName;
            string identification               = employee.Identification;
            string jobTitle                     = employee.JobTitle;
            decimal baseSalary                  = employee.BaseSalary;
            int workedDays                      = employee.WorkedDays;
            decimal dayOvertimeHours            = employee.Overtime.DayHours;
            decimal nightOvertimeHours          = employee.Overtime.NightHours;
            decimal holidayDayOvertimeHours     = employee.Overtime.HolidayDayHours;
            decimal holidayNightOvertimeHours   = employee.Overtime.HolidayNightHours;
            decimal holidayDaysWorked           = employee.HolidayDaysWorked;


            Print.ShowText("Id", id, false, false);
            Print.ShowText("Nombre", name, false, false);
            Print.ShowText("Apellido", lastName, false, false);
            Print.ShowText("Cédula", identification, false, false);
            Print.ShowText("Cargo", jobTitle, false, false);
            Print.ShowMoney("Salario base", baseSalary, false, false);
            Print.ShowNumber("Días trabajados", workedDays, false, false);
            Print.ShowNumberIfAny("Horas extras diurnas", dayOvertimeHours, false, false);
            Print.ShowNumberIfAny("Horas extras nocturnas", nightOvertimeHours, false, false);
            Print.ShowNumberIfAny("Horas extras diurnas en domingos/festivos", holidayDayOvertimeHours, false, false);
            Print.ShowNumberIfAny("Horas extras nocturnas en domingos/festivos", holidayNightOvertimeHours, false, false);
            Print.ShowNumberIfAny("Días trabajados en domingos/festivos", holidayDaysWorked, false, false);


            if (showSeparator) Print.PrintLine('-');

            if (showSpace) Console.WriteLine();
        }



        // VALIDAR SI EL ARCHIVO JSON EXISTE
        public static bool FileExists(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"El archivo '{Path.GetFileName(path)}' que desea consultar no existe en la ruta '{Path.GetDirectoryName(path)}'.\n");
                return false;
            }
            else
            {
                Console.WriteLine($"Se encontró el archivo '{Path.GetFileName(path)}'.\n");
                return true;
            }
        }



        // DEVUELEVE UNA LISTA DE EMPLEADOS FORMATEADA PARA TRABAJAR CON SUS VALORES
        public static List<Employee> ReadFile(string path)
        {
            var fileContent = File.ReadAllText(path);

            EmployeeFile? employeeFile = JsonConvert.DeserializeObject<EmployeeFile?>(fileContent);

            if (employeeFile?.Employees == null)
            {
                Console.WriteLine($"El archivo '{Path.GetFileName(path)}' esta vacío.");
                return [];
            }

            return employeeFile.Employees;
        }



        // MUESTRA LA INFORMACIÓN DE UNA LISTA DE EMPLEADOS
        public static void PrintListEmployees(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                PrintEmployee(employee, true, false);
            }
        }
    }



    // ESTRUCTURA DE COMO LLEGA LA LISTA DE EMPLEADOS DEL JSON
    public record EmployeeFile
    {
        public List<Employee>? Employees { get; set; }
    }

}