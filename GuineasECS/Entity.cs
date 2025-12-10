namespace GuineasECS;

public class Entity
{
    private static uint _AvailableID = 0;
    public readonly uint ID = 0;

    public Entity()
    {
        ID = _AvailableID++;
    }
}