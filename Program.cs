//Comentado por usar la mejora Implicit Usings
/*using System;
using System.Collections.Generic;*/

namespace ToDo;

internal class Program
{
    //Inicializando el TaskList directamente desde la propiedad
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
        //Inicializando el TaskList dentro del Main
        //TaskList = new List<string>();
        int menuSelected = 0;
        do
        {
            menuSelected = ShowMainMenu();
            if ((Menu)menuSelected == Menu.Add)
                ShowMenuAdd();
            else if ((Menu)menuSelected == Menu.Remove)
                ShowMenuRemove();
            else if ((Menu)menuSelected == Menu.List)
                ShowMenuTaskList();
            else
                continue;
        } while ((Menu)menuSelected != Menu.Exit);
    }

    /// <summary>
    /// Show the options for , 1. Nueva tarea, 2. Remover tarea, 3. Tareas pendientes, 4. Salir
    /// </summary>
    /// <returns>Returns option selected by user</returns>
    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        string menuSelectedItem = Console.ReadLine();
        return Convert.ToInt32(string.IsNullOrEmpty(menuSelectedItem) ? -1 : menuSelectedItem);
    }

    //Función con el cuerpo completo, creada de la forma tradicional/común
    /*public static bool TaskListIsEmpty()
    {
        return (TaskList == null || !TaskList.Any());
    }*/
    //Función en su forma resumida, con operador felcha, Expression Bodied Function
    public static bool TaskListIsEmpty() => (TaskList is null || !TaskList.Any());

    public static void ShowMenuRemove()
    {
        try
        {
            if (TaskListIsEmpty())
            {
                Console.WriteLine("No hay tareas por realizar");
                return;
            }

            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            
            ShowTaskList();

            string taskNumberToDelete = Console.ReadLine();
            // Remove one position
            int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;
            if (indexToRemove > -1 && TaskList.Count > 0 && indexToRemove < TaskList.Count)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                //Sin interpolación de cadenas
                //Console.WriteLine("Tarea " + taskToRemove + " eliminada");
                //Haciendo uso de  interpolación de cadenas
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
            else
                Console.WriteLine("El índice de la tarea a eliminar es incorrecto");
        }
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
        }
    }

    public static void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string taskName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(taskName.Trim()))
            {
                Console.WriteLine("El nombre de la tarea no debe ser vacío");
                return;
            }
            TaskList.Add(taskName);
            Console.WriteLine("Tarea registrada");
        }
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error al registrar la tarea");
        }
    }

    public static void ShowMenuTaskList()
    {
        if (TaskListIsEmpty())
        {
            Console.WriteLine("No hay tareas por realizar");
            return;
        }

        ShowTaskList();
    }

    public static void ShowTaskList()
    {
        Console.WriteLine("----------------------------------------");
        //Ajustado con KISS
        var indexTask = 1;
        //Sin interpolación de cadenas
        //TaskList.ForEach(p => Console.WriteLine((indexTask++) + ". " + p));
        //Haciendo uso de interpolación de cadenas
        TaskList.ForEach(p => Console.WriteLine($"{indexTask++}. {p}"));
        //Antes de hacerlo con KISS
        /*for (int i = 0; i < TaskList.Count; i++)
            Console.WriteLine((i + 1) + ". " + TaskList[i]);*/
    }
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}