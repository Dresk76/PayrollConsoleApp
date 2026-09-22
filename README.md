# PayrollConsoleApp

Aplicación de consola en C#/.NET que calcula la nómina quincenal de un grupo de
empleados en Colombia: valor de la hora ordinaria, recargos por horas extra
(diurna, nocturna, dominical y festiva), auxilio de transporte, deducciones de
salud y pensión, y neto a pagar.

Los datos se leen desde un archivo JSON y el resultado se imprime en consola
con el desglose completo de cada cálculo.

## Salida de ejemplo

```
=====================================================================================
--                      INFORMACIÓN DEL EMPLEADO: Juan Pérez                      --
=====================================================================================
- Id                                                   : 1
- Nombre                                               : Juan
- Apellido                                             : Pérez
- Cédula                                               : 1012345678
- Cargo                                                : Auxiliar Administrativo
- Salario base                                         : $ 1.750.905,00
- Días trabajados                                      : 30
- Horas extras diurnas                                 : 4
- Horas extras nocturnas                               : 2
- Días trabajados en domingos/festivos                 : 1

=====================================================================================
--                               DESGLOSE DE TARIFAS                               --
=====================================================================================
- Horas mes por ley                                    : 210
- Valor día                                            : $ 58.363,50
- Valor hora regular                                   : $ 8.337,64
- Valor hora extra diurna (25%)                        : $ 10.422,05
- Valor hora extra nocturna (75%)                      : $ 14.590,88
- Valor hora extra diurna en domingo/festivo (115%)    : $ 17.925,93
- Valor hora extra nocturna en domingo/festivo (165%)  : $ 22.094,75
- Valor día trabajado en domingo/festivo (90%)         : $ 15.841,52
- Valor auxilio de transporte                          : $ 249.095,00
- Valor diario del auxilio de transporte               : $ 8.303,17
- Porcentaje descuento salud                           : 4,0 %
- Porcentaje descuento pensión                         : 4,0 %

=====================================================================================
--                                DETALLE DE NÓMINA                                --
=====================================================================================
- Días trabajados                                      : 30
- Horas trabajadas                                     : 210
- Salario base a pagar                                 : $ 1.750.905,00
- [4] Horas extras diurnas                             : $ 41.688,21
- [2] Horas extras nocturnas                           : $ 29.181,75
- [1] Día trabajado en domingo/festivo                 : $ 15.841,52

=====================================================================================
--                                 RESUMEN DE PAGO                                 --
=====================================================================================
- Salario devengado                                    : $ 1.853.458,01
-------------------------------------------------------------------------------------
- Auxilio de transporte                                : $ 249.095,00
-------------------------------------------------------------------------------------
- Total devengado                                      : $ 2.102.553,01
-------------------------------------------------------------------------------------
- Descuento salud (4%)                                 : $ 74.138,32
-------------------------------------------------------------------------------------
- Descuento pensión (4%)                               : $ 74.138,32
-------------------------------------------------------------------------------------
- Neto a pagar                                         : $ 1.954.276,00
-------------------------------------------------------------------------------------
```

## Requisitos

- [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/download)

## Cómo ejecutarlo

```bash
git clone https://github.com/Dresk76/PayrollConsoleApp.git
cd PayrollConsoleApp/PayrollConsoleApp
dotnet run
```

La aplicación busca un archivo `employees.json` en la carpeta desde la que se
ejecuta. El repositorio incluye uno de ejemplo con cuatro empleados.

## Formato del archivo de entrada

```json
{
  "employees": [
    {
      "id": 1,
      "name": "Juan",
      "lastName": "Pérez",
      "identification": "1012345678",
      "jobTitle": "Auxiliar Administrativo",
      "baseSalary": 1750905,
      "workedDays": 30,
      "overtime": {
        "dayHours": 4,
        "nightHours": 2,
        "holidayDayHours": 0,
        "holidayNightHours": 0
      },
      "holidayDaysWorked": 1
    }
  ]
}
```

| Campo | Tipo | Descripción |
|---|---|---|
| `id` | número | Identificador del empleado |
| `name`, `lastName` | texto | Nombre y apellido |
| `identification` | texto | Número de documento. Se maneja como texto porque nunca se opera aritméticamente y puede tener ceros a la izquierda |
| `jobTitle` | texto | Cargo |
| `baseSalary` | número | Salario mensual |
| `workedDays` | número | Días trabajados en el período liquidado |
| `overtime.dayHours` | número | Horas extra diurnas |
| `overtime.nightHours` | número | Horas extra nocturnas |
| `overtime.holidayDayHours` | número | Horas extra diurnas en domingo o festivo |
| `overtime.holidayNightHours` | número | Horas extra nocturnas en domingo o festivo |
| `holidayDaysWorked` | número | Días completos trabajados en domingo o festivo |

Los campos de horas y días admiten valores fraccionarios (por ejemplo, `4.5`).

## Qué calcula

**Valor de la hora ordinaria.** Se calcula sobre el salario mensual completo,
sin importar el período liquidado: `(salario mensual) / (horas mensuales)`,
donde las horas mensuales salen de `(jornada semanal / días laborales por
semana) × 30`.

**Recargos por hora extra**, aplicados sobre el valor de la hora ordinaria:

| Concepto | Recargo |
|---|---|
| Hora extra diurna | 25 % |
| Hora extra nocturna | 75 % |
| Hora extra diurna en domingo/festivo | 115 % |
| Hora extra nocturna en domingo/festivo | 165 % |
| Día trabajado en domingo/festivo | 90 % |

**Auxilio de transporte.** Aplica a quien devenga hasta dos salarios mínimos
mensuales legales vigentes. Se calcula como valor diario y se paga
proporcional a los días trabajados en el período.

**Deducciones.** Salud y pensión, 4 % cada una, calculadas sobre el salario
devengado (sin incluir el auxilio de transporte, que no hace parte de la base
de estos dos aportes).

**Neto a pagar.** Total devengado más auxilio de transporte, menos las
deducciones. Es el único valor que se redondea al peso; todos los demás
conservan sus decimales y solo se redondean al mostrarse.

> Los valores de salario mínimo, auxilio de transporte y porcentajes de ley
> corresponden a 2026 y están centralizados en `PayrollSettings.cs`.

## Estructura del proyecto

```
PayrollConsoleApp/
├── Program.cs                  Orquesta la lectura, el cálculo y la impresión
├── Employee.cs                 Modelo de un empleado y su registro de horas extra
├── EmployeeService.cs          Lee el JSON y construye la lista de empleados
├── PayrollSettings.cs          Parámetros legales y de jornada (salario mínimo,
│                                auxilio de transporte, horas semanales)
├── BaseRateCalculator.cs       Valor del día, valor de la hora, salario base
│                                a pagar, salario devengado, neto a pagar
├── OvertimeCalculator.cs       Tarifas y pagos de cada tipo de hora extra
├── DeductionCalculator.cs      Deducciones de salud y pensión
├── AllowanceCalculator.cs      Elegibilidad y cálculo del auxilio de transporte
├── CurrencyFormat.cs           Formato de moneda colombiana
├── Print.cs                    Impresión en consola (texto, dinero, números,
│                                porcentajes)
└── employees.json              Datos de entrada de ejemplo
```

Cada calculador agrupa los cálculos que cambiarían juntos si cambiara la ley:
los parámetros de horas extra en una clase, los de deducciones en otra.

## Decisiones técnicas

**`decimal` en todos los valores monetarios y de horas.** `double` y `float`
no representan de forma exacta números como 0.1 en base binaria; sobre miles
de operaciones ese error se acumula y el total deja de cuadrar. `decimal`
trabaja en base 10 y evita ese problema, al costo de ser más lento — un costo
irrelevante para esta escala.

**Redondeo solo en dos puntos del código.** Todos los cálculos intermedios se
propagan sin redondear; el formato de moneda (`"C2"`) ya se encarga de
mostrar dos decimales. La única excepción es el neto a pagar, que se redondea
al peso con `MidpointRounding.AwayFromZero` porque es el valor que
efectivamente se transfiere, no solo se muestra. Redondear en cada paso
intermedio introducía diferencias de hasta varios pesos entre el salario
base calculado y el salario real del empleado.

**El documento de identidad se guarda como texto.** Nunca se opera
aritméticamente y un número puede perder ceros a la izquierda o quedarse
corto para documentos largos.

**Separación entre calcular y mostrar.** Cada clase de cálculo tiene un
método `Calculate...` que devuelve un valor y un método `Show...` que lo
imprime. Un método que calculara e imprimiera a la vez quedaría atado a la
consola: no podría reutilizarse si estos cálculos alimentaran una API más
adelante, y sería más difícil de probar con tests.

**Parámetros legales centralizados en `PayrollSettings`.** El salario mínimo,
el auxilio de transporte y la jornada semanal cambian por decreto cada año.
Tenerlos en un solo archivo reduce la actualización anual a cambiar unos
pocos números, en vez de buscarlos por todo el proyecto.

## Limitaciones conocidas

- Los parámetros legales están escritos en el código como constantes. En una
  aplicación real irían en un archivo de configuración externo, para
  actualizarlos sin recompilar.
- No hay validación de los datos del archivo JSON más allá de comprobar que
  no venga vacío. Un valor negativo o un tipo de dato incorrecto no se
  rechaza explícitamente.
- El proyecto no tiene tests automatizados.

## Contexto

Este proyecto es el primer mini proyecto de un roadmap autodirigido de 12
semanas hacia backend con .NET, que en este punto cubre C# moderno, LINQ,
programación asíncrona y manejo de archivos y directorios.
