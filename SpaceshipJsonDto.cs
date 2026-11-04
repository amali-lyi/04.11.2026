namespace DotNetLessons;

public class SpaceshipJsonDto
{
    public string Name { get; set; } = "";
    public int Health { get; set; }
    public float Fuel { get; set; }
    public Vector3D Position { get; set; } = new Vector3D();
    public List<CargoItem> Cargo { get; set; } = new List<CargoItem>();

    public SpaceshipJsonDto() { }

    public SpaceshipJsonDto(Spaceship spaceship)
    {
        Name = spaceship.Name;
        Health = spaceship.Health;
        Fuel = spaceship.Fuel;

        Position = new Vector3D(
            spaceship.Position.X,
            spaceship.Position.Y,
            spaceship.Position.Z
        );

        for (int i = 0; i < spaceship.Cargo.Count; i++)
        {
            Cargo.Add(new CargoItem(
                spaceship.Cargo[i].Name,
                spaceship.Cargo[i].Quantity,
                spaceship.Cargo[i].Weight
            ));
        }
    }

    public Spaceship Load()
    {
        Spaceship spaceship = new Spaceship()
        {
            Name = Name,
            Health = Health,
            Fuel = Fuel,
            Position = new Vector3D(
                Position.X,
                Position.Y,
                Position.Z
            )
        };

        for (int i = 0; i < Cargo.Count; i++)
        {
            spaceship.Cargo.Add(new CargoItem(
                Cargo[i].Name,
                Cargo[i].Quantity,
                Cargo[i].Weight
            ));
        }

        return spaceship;
    }
}