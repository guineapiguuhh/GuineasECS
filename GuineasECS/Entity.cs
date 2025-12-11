namespace GuineasECS;

public class Entity
{
    private static int _AvailableID = 0;
    public readonly int ID = 0;

    private readonly EntityStore Store;

    public Entity(EntityStore store)
    {
        ID = _AvailableID++;
        Store = store;
    }

    public void AddComponent<T>(T component) 
        => Store.AddComponent(ID, component);

    public void RemoveComponent<T>()
        => Store.RemoveComponent<T>(ID);

    public bool HasComponent<T>()
        => Store.HasComponent<T>(ID);

    public T? GetComponent<T>()
        => Store.GetComponent<T>(ID);
}