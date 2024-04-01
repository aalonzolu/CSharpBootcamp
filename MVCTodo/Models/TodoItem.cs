namespace MVCTodo.Models;

using System.ComponentModel.DataAnnotations;

public class TodoItem
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Please enter a title.")]
    public required string Title { get; set; }
}
