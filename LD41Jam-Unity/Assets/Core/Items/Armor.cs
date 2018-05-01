public interface Armor : Equipment { }

public class WoodenShield : Armor
{
    public Slot Slot => Slot.SHIELD;
}

public class WoodenHelmet : Armor
{
    public Slot Slot => Slot.HEAD;
}

public class WoodenChestpiece : Armor
{
    public Slot Slot => Slot.CHEST;
}

public class WoodenGloves : Armor
{
    public Slot Slot => Slot.HANDS;
}

public class WoodenLeggings : Armor
{
    public Slot Slot => Slot.LEGS;
}

public class WoodenBoots : Armor
{
    public Slot Slot => Slot.FEET;
}