using MyToDoList.Data;

namespace MyToDoList.Commands
{
    internal class MarkAsCompleted : ICommand
    {
        private readonly IToDoList _toDoList;

        public string Description => "Пометить задачу завершённой";

        public MarkAsCompleted(IToDoList toDoList)
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
                        _toDoList.MarkAsCompleted(task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка");
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;
                }
            }
            while (true);
        }
    }
}
