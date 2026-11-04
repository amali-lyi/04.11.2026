namespace DotNetLessons;

public class CargoItem
{
    public string Name { get; set; } = "";
    public int Quantity { get; set; }
    public float Weight { get; set; }

    public CargoItem() { }

    public CargoItem(string name, int quantity, float weight)
    {
        Name = name;
        Quantity = quantity;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{Name}: Quantity - {Quantity}; Weight - {Weight}";
    }
}