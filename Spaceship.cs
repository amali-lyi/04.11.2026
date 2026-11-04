namespace DotNetLessons;

public class Spaceship
{
    public string Name { get; set; } = "";
    public int Health { get; set; }
    public float Fuel { get; set; }
    public Vector3D Position { get; set; } = new Vector3D();
    public List<CargoItem> Cargo { get; set; } = new List<CargoItem>();
    public bool IsEngineRunning { get; set; }
    public float DistanceTraveled { get; set; }
    public string LastCommand { get; set; } = "";

    public void StartEngine()
    {
        if (Fuel > 0)
        {
            IsEngineRunning = true;
            LastCommand = "Start Engine";
            Console.WriteLine("Engine started.");
        }
        else
        {
            Console.WriteLine("Not enough fuel.");
        }
    }

    public void StopEngine()
    {
        IsEngineRunning = false;
        LastCommand = "Stop Engine";
        Console.WriteLine("Engine stopped.");
    }

    public void Move(float x, float y, float z)
    {
        if (!IsEngineRunning)
        {
            Console.WriteLine("Engine is not running.");
            return;
        }

        float distance = MathF.Sqrt(x * x + y * y + z * z);
        float fuelCost = distance * 0.1f;

        if (Fuel < fuelCost)
        {
            Console.WriteLine("Not enough fuel.");
            return;
        }

        Position.X += x;
        Position.Y += y;
        Position.Z += z;

        Fuel -= fuelCost;
        DistanceTraveled += distance;

        LastCommand = "Move";

        Console.WriteLine("Spaceship moved.");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
        }

        LastCommand = "Take Damage";
    }

    public void AddCargo(CargoItem item)
    {
        Cargo.Add(item);
        LastCommand = "Add Cargo";
    }

    public float GetTotalCargoWeight()
    {
        float totalWeight = 0;

        for (int i = 0; i < Cargo.Count; i++)
        {
            totalWeight += Cargo[i].Quantity * Cargo[i].Weight;
        }

        return totalWeight;
    }

    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"Health: {Health}\n" +
               $"Fuel: {Fuel}\n" +
               $"Position: {Position}\n" +
               $"Cargo items: {Cargo.Count}\n" +
               $"Total cargo weight: {GetTotalCargoWeight()}\n" +
               $"Engine running: {IsEngineRunning}\n" +
               $"Distance traveled: {DistanceTraveled}\n" +
               $"Last command: {LastCommand}";
    }
}