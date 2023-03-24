using ToDoAPI.Models;

namespace ToDoAPI.Tests;

public class ToDoModelTests
{
    [Fact]
    public void CanChangeName()
    {
        // Arrange
        var testTodo = new TodoItem
        {
            Name = "completed unit test"
        };

        // Act
        testTodo.Name = "debugging";

        // Assert
        Assert.Equal("debugging", testTodo.Name);
    }
}