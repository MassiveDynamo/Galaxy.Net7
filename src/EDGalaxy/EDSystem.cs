using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace EDGalaxy;

[Serializable]
public class EDSystem
{
    public readonly int Id;
    public readonly long? Id64;
    public readonly string Name;
    public readonly DateTime Date;
    public readonly double X;
    public readonly double Y;
    public readonly double Z;

    public EDSystem(int Id, long? Id64, string Name, double X, double Y, double Z, DateTime Date)
    {
        this.Id = Id;
        this.Id64 = Id64;
        this.Name = Name;
        this.Date = Date;
        this.X = X;
        this.Y = Y;
        this.Z = Z;
    }
}

