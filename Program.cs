using tareas;
using EspacioCalculadora;

// Inicializamos las listas y el gestor de tareas
GestorDeTareas gestorTareas = new GestorDeTareas();
List<Tarea> listaTareasPendientes = new List<Tarea>();
List<Tarea> listaTareasRealizadas = new List<Tarea>();

int opcion;
do
{
    Console.WriteLine("\n------MENU DE OPERACIONES-----");
    Console.WriteLine("1). Agregar una nueva tarea a Pendientes");
    Console.WriteLine("2). Mostrar lista de tareas pendientes");
    Console.WriteLine("3). Mostrar lista de tareas realizadas");
    Console.WriteLine("4). Transferir tareas de la lista Pendientes a Realizadas por ID");
    Console.WriteLine("5). Buscar Tarea Por palabra clave");
    Console.WriteLine("6). Finalizar");
    Console.WriteLine("Seleccione una opción: ");

    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine("\nIngrese la cantidad de tareas que desea agregar:");
                if (int.TryParse(Console.ReadLine(), out int cantidad))
                {
                    listaTareasPendientes.AddRange(gestorTareas.crearNTareas(cantidad));
                }
                else
                {
                    Console.WriteLine("Cantidad inválida.");
                }
                break;

            case 2:
                Console.WriteLine("\n---Tareas pendientes---");
                if (listaTareasPendientes.Count > 0)
                {
                    int j = 1;
                    foreach (Tarea tarea in listaTareasPendientes)
                    {
                        Console.WriteLine($"\nTarea {j}:");
                        Console.WriteLine($"ID: {tarea.Id}");
                        Console.WriteLine($"Descripción: {tarea.Descripcion}");
                        Console.WriteLine($"Duración: {tarea.Duracion}");
                        j++;
                    }
                }
                else
                {
                    Console.WriteLine("No hay tareas pendientes.");
                }
                break;

            case 3:
                Console.WriteLine("\n---Tareas realizadas---");
                if (listaTareasRealizadas.Count > 0)
                {
                    int m = 1;
                    foreach (Tarea tarea in listaTareasRealizadas)
                    {
                        Console.WriteLine($"\nTarea {m}:");
                        Console.WriteLine($"ID: {tarea.Id}");
                        Console.WriteLine($"Descripción: {tarea.Descripcion}");
                        Console.WriteLine($"Duración: {tarea.Duracion}");
                        m++;
                    }
                }
                else
                {
                    Console.WriteLine("No hay tareas realizadas.");
                }
                break;

            case 4:
                Console.WriteLine("\nIngrese el ID de la tarea que desea transferir a 'Tareas Realizadas':");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    gestorTareas.moverTareasARealizadasId(listaTareasPendientes, listaTareasRealizadas, id);
                }
                else
                {
                    Console.WriteLine("ID inválido.");
                }
                break;

            case 5:
                Console.WriteLine("\nIngrese la descripción de la tarea a buscar:");
                string descripcion = Console.ReadLine();
                Tarea tareaBuscada = gestorTareas.BuscarTareaPorDescripcion(listaTareasPendientes, descripcion);
                if (tareaBuscada != null)
                {
                    Console.WriteLine($"\nTarea encontrada:");
                    Console.WriteLine($"ID: {tareaBuscada.Id}");
                    Console.WriteLine($"Descripción: {tareaBuscada.Descripcion}");
                    Console.WriteLine($"Duración: {tareaBuscada.Duracion}");
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna tarea con esa descripción.");
                }
                break;
        }
    }
    else
    {
        Console.WriteLine("Opción inválida. Intente nuevamente.");
    }

} while (opcion != 6);

Console.WriteLine("-------EJERCICIO 2: CALCULADORA-------");

// Inicializamos la calculadora
Calculadora calculadora = new Calculadora();

int control;
do
{
    Console.WriteLine("\n--CALCULADORA--");
    Console.WriteLine("1) Suma");
    Console.WriteLine("2) Resta");
    Console.WriteLine("3) Multiplicación");
    Console.WriteLine("4) División");
    Console.WriteLine("5) Limpiar");
    Console.WriteLine("6) Historial");
    Console.WriteLine("Seleccione una operación:");

    if (int.TryParse(Console.ReadLine(), out int operacion))
    {
        double num = 0;
        if (operacion >= 1 && operacion <= 4)
        {
            Console.WriteLine("Ingrese el número:");
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Número inválido. Intente nuevamente:");
            }
        }

        switch (operacion)
        {
            case 1:
                calculadora.Sumar(num);
                Console.WriteLine($"Resultado: {calculadora.Resultado}");
                break;

            case 2:
                calculadora.Restar(num);
                Console.WriteLine($"Resultado: {calculadora.Resultado}");
                break;

            case 3:
                calculadora.Multiplicar(num);
                Console.WriteLine($"Resultado: {calculadora.Resultado}");
                break;

            case 4:
                calculadora.Dividir(num);
                Console.WriteLine($"Resultado: {calculadora.Resultado}");
                break;

            case 5:
                calculadora.Limpiar();
                Console.WriteLine("La calculadora ha sido limpiada.");
                break;

            case 6:
                Console.WriteLine("\n---Historial de operaciones---");
                if (calculadora.Historial.Count > 0)
                {
                    int m = 1;
                    foreach (var operacionRealizada in calculadora.Historial)
                    {
                        Console.WriteLine($"\nOperación {m}:");
                        Console.WriteLine($"Dato anterior: {operacionRealizada.ResultadoAnterior}");
                        Console.WriteLine($"Operación realizada: {operacionRealizada.OperacionRealizar}");
                        Console.WriteLine($"Resultado: {operacionRealizada.NuevoValor}");
                        m++;
                    }
                }
                else
                {
                    Console.WriteLine("El historial está vacío.");
                }
                break;

            default:
                Console.WriteLine("Operación inválida. Intente nuevamente.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Opción inválida. Intente nuevamente.");
    }

    Console.WriteLine("¿Desea continuar operando? 1)Sí / 0)No");
    if (!int.TryParse(Console.ReadLine(), out control))
    {
        control = 1;
    }

} while (control != 0);
