using MyToDoList.Data;

namespace MyToDoList.Commands
{
    internal class DeleteCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public string Description => "Удалить задачу";

        public DeleteCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            do
            {
                Console.WriteLine("Введи номер задачи");
                var task = Convert.ToInt32(Console.ReadLine());

                if (task != null)
                {
                    try
                    {
                        _toDoList.Delete(task);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Ошибка");
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;
                }
            } while (true);
        }
    }
}
