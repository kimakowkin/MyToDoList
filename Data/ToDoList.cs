namespace MyToDoList.Data;

public class ToDoList : IToDoList
{
    private readonly List<string> _todoTasks = new List<string>();
    private readonly List<string> _doneTasks = new List<string>();

    private const string TodoTasksFile = "todoTasks.txt";
    private const string DoneTasksFile = "doneTasks.txt";

    public ToDoList()
    {
        _todoTasks = File.Exists(TodoTasksFile) ? File.ReadAllLines(TodoTasksFile).ToList() : new List<string>();
        _doneTasks = File.Exists(DoneTasksFile) ? File.ReadAllLines(DoneTasksFile).ToList() : new List<string>();
    }
    public void Add(string task)
    {
        _todoTasks.Add(task);
        File.WriteAllLines(TodoTasksFile, _todoTasks);
    }

    public void Delete(int id)
    {
        _todoTasks.RemoveAt(id);
        File.WriteAllLines(TodoTasksFile, _todoTasks);
    }

    public void MarkAsCompleted(int id)
    {
        var task = _todoTasks[id];
        _todoTasks.RemoveAt(id);
        _doneTasks.Add(task + " -> " +  DateTime.Now.ToString(@"HH:mm:ss"));
        File.WriteAllLines(TodoTasksFile, _todoTasks);
        File.WriteAllLines(DoneTasksFile, _doneTasks);
    }

    public string[] ToDoItems()
    {
        return _todoTasks.ToArray();
    }

    public string[] DoneItems()
    {
       return _doneTasks.ToArray();
    }
}
