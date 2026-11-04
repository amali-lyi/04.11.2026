using System.Text.Json;

namespace DotNetLessons;

class Program
{
    static void Main()
    {
        Spaceship spaceship = new Spaceship()
        {
            Name = "Explorer",
            Health = 100,
            Fuel = 500,
            Position = new Vector3D(0, 0, 0)
        };

        spaceship.AddCargo(new CargoItem("Food", 10, 2.5f));
        spaceship.AddCargo(new CargoItem("Metal", 20, 5.0f));
        spaceship.AddCargo(new CargoItem("Fuel Cells", 5, 3.0f));

        spaceship.StartEngine();
        spaceship.Move(10, 20, 5);
        spaceship.TakeDamage(15);

        Console.WriteLine("\nORIGINAL SPACESHIP");
        Console.WriteLine(spaceship);

        //Save 

        SpaceshipJsonDto saveData = new SpaceshipJsonDto(spaceship);

        string json = JsonSerializer.Serialize(
            saveData,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText("spaceship.json", json);

        Console.WriteLine("\nJSON saved");

        //Change 

        spaceship.Name = "Changed Ship";
        spaceship.Health = 20;
        spaceship.Fuel = 10;
        spaceship.Position.X = 999;
        spaceship.Cargo.Clear();

        spaceship.StopEngine();

        //Load 

        string loadedJson = File.ReadAllText("spaceship.json");

        SpaceshipJsonDto loadedData =
            JsonSerializer.Deserialize<SpaceshipJsonDto>(loadedJson)
            ?? throw new Exception("Loading failed");

        Spaceship loadedSpaceship = loadedData.Load();

        //Res

        Console.WriteLine("\nCHANGED ORIGINAL");
        Console.WriteLine(spaceship);

        Console.WriteLine("\nLOADED SPACESHIP");
        Console.WriteLine(loadedSpaceship);
    }
}
