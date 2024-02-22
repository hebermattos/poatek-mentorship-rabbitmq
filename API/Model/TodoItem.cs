namespace rabbitmq_example;

public class TodoItem
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Task { get; set; }
    public bool Completed { get; set; }
    public DateTime CreationDate { get; set; }

    public TodoItem(int id)
    {
        Id = id;
    }

    public TodoItem(string name, string task)
    {
        Name = name;
        Task = task;
        Completed = false;
        CreationDate = DateTime.Now;
    }

}
