public interface Weapon : Equipment { }

public class WoodenAxe : Weapon
{
    public Slot Slot => Slot.WEAPON;
}

public class CopperAxe : Weapon
{
    public Slot Slot => Slot.WEAPON;
}