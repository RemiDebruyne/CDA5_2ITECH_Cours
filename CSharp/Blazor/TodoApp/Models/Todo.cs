namespace TodoApp.Models;

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Task { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;

}
