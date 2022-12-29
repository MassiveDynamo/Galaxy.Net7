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
    public readonly float X;
    public readonly float Y;
    public readonly float Z;

    public EDSystem(int Id, long? Id64, string Name, float X, float Y, float Z, DateTime Date)
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

