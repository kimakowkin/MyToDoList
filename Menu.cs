using MyToDoList.Commands;
using MyToDoList.Data;

namespace MyToDoList;
internal class Menu
{
    public Menu()
    {
    }



    public void Start()
    {
        var todoList = new ToDoList();
        var doneItems = todoList.DoneItems;
        List<ICommand> commands = new()
        {
            new ExitCommand(),
            new AddCommand(todoList),
            new DeleteCommand(todoList),
            new MarkAsCompleted(todoList)
        };

        do
        {
            Console.WriteLine("Задачи:");
            PrintList(todoList.ToDoItems());
            Console.WriteLine("Достижения:");
            PrintList(todoList.DoneItems());

            for (int i = 0; i < commands.Count; i++)
            {
                Console.Write(i + ") ");
                Console.WriteLine(commands[i].Description);
            }
            Console.Write("=> ");

            if (int.TryParse(Console.ReadLine(), out int commandId) && commandId >= 0 && commandId < commands.Count)
            {
                commands[commandId].Execute();
            }
            else
            {
                Console.WriteLine("Недопустимое значение");
            }
        } while (true);
    }

    public static void PrintList(string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(i + "->");
            Console.WriteLine(list[i]);
        }
    }
}
