namespace GuineasECS;

public class EntityStore
{
    private readonly Dictionary<Type, SparseSet<object>> Components;

    public EntityStore()
    {
        Components = [];
    }

    public EntityStore ReserveComponent<T>()
    {
        Components.Add(
            typeof(T), 
            new SparseSet<object>()
        );
        return this;
    }

    protected SparseSet<object> GetComponentsList<T>()
        => Components[typeof(T)];

    public void AddComponent<T>(int entityID, T component)
    {
        if (component is null) throw new NullReferenceException();
        GetComponentsList<T>().Set(entityID, component);
    }

    public void RemoveComponent<T>(int entityID)
        => GetComponentsList<T>().Delete(entityID);
    
    public T GetComponent<T>(int entityID)
    {
        var component = (T)GetComponentsList<T>().Get(entityID) ?? throw new NullReferenceException();
        return component;
    }

    public bool HasComponent<T>(int entityID)
        => GetComponentsList<T>().Contains(entityID);
}