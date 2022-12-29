namespace EDGalaxy;

public class EDSystemDistance : EDSystem
{
    public readonly double Distance;

    public EDSystemDistance(EDSystem item, double distance) : base(item.Id, item.Id64, item.Name, item.X, item.Y, item.Z, item.Date)
    {
        Distance = distance;
    }

    public EDSystemDistance(int id, long id64, string name, float x, float y, float z, DateTime dateTime, double distance) : base(id, id64, name, x, y, z, dateTime)
    {
        Distance = distance;
    }
}