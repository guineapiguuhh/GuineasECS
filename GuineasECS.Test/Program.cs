using System.Diagnostics;
using GuineasECS;

public struct Position
{
    public float X { get; set; }
    public float Y { get; set; }

    public Position()
    {
        (X, Y) = (0f, 0f);
    }
    
    public Position(float x)
    {
        (X, Y) = (x, x);
    }

    public Position(float x, float y)
    {
        (X, Y) = (x, y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

public class Program
{
    private static void Main()
    {
        var ecs = new EntityStore()
            .ReserveComponent<string>()
            .ReserveComponent<Position>();
        
        var testEntity = new Entity(ecs);
        testEntity.AddComponent("testComponent!");
        testEntity.AddComponent(new Position(500.0f, 250.0f));

        Console.WriteLine(testEntity.HasComponent<string>());
        Console.WriteLine(testEntity.GetComponent<string>());
        Console.WriteLine(testEntity.GetComponent<Position>());

        Console.WriteLine();

        testEntity.RemoveComponent<string>();

        Console.WriteLine(testEntity.HasComponent<string>());
        Console.WriteLine(testEntity.GetComponent<string>());
        Console.WriteLine(testEntity.GetComponent<Position>());
    }
}