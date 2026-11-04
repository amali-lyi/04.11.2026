namespace DotNetLessons;

public class Vector3D
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3D() { }

    public Vector3D(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"X: {X}; Y: {Y}; Z: {Z}";
    }
}