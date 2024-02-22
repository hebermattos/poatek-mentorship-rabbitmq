using System.Reflection.Metadata.Ecma335;

namespace rabbitmq_example;

public class TodoReport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TaskCount { get; set; }
    public int Taskfinished { get; set; }
    public int TaskUnfinished { get; set; }


    public TodoReport(string name)
    {
        Name = name;
        TaskCount = 1;
        TaskUnfinished = 1;
    }
}
