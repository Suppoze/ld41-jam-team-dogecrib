public enum Slot
{
    HEAD,
    CHEST,
    HANDS,
    LEGS,
    FEET,
    WEAPON,
    SHIELD
}

public interface Equipment
{
    Slot Slot
    {
        get;
    }
}