public class CarStatDto
{
    public int Level { get; }
        
    public int Durability { get; set; }
    public int Cargo { get; set; }
        
    public int maxDurability;
    public int maxCargo;

    public CarStatDto(int level)
    {
        Level = level;
        maxDurability = (Level + 2) * 2;
        maxCargo = (Level + 2) * 5;
    }
}