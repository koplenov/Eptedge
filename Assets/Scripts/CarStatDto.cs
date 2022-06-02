public class CarStatDto
{
    public int Level { get; }
        
    public int Durability { get; set; }
    public int Cargo { get; set; }
    public int JewishModifier { get; set; }
        
    public int maxDurability;
    public int maxCargo;
    public int maxJewishModifier;

    public CarStatDto(int level)
    {
        Level = level;
        maxDurability = (Level + 1) * 2;
        maxCargo = (Level + 1) * 5;
        maxJewishModifier = (Level + 1) * 2;
    }
}