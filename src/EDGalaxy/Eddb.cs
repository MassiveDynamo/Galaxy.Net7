using System;
using System.Data;
using System.Data.SqlClient;

namespace EDGalaxy
{
    public class Eddb
    {
        const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eddb1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static EDSystem? GetSystem(string systemName)
        {
            if (systemName is null)
            {
                throw new ArgumentNullException(nameof(systemName));
            }

            DataTable table = new();
            using SqlConnection connection = new(connectionString);
            using SqlCommand cmd = new("dbo.prcGetSystem", connection);
            using SqlDataAdapter da = new(cmd);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SystemName", systemName);
            try
            {
                connection.Open();
                da.Fill(table);
                if( table.Rows.Count == 0 ) 
                {
                    return null;
                }
                
                DataRow dr = table.Rows[0];
                int id = (int)dr[0];
                long id64 = (long)dr[1];
                string name = (string)dr[2];
                double x = (double)dr[3];
                double y = (double)dr[4];
                double z = (double)dr[5];
                DateTime dt = (DateTime)dr[6];
                return new EDSystem(id, id64, name, x, y, z, dt);
            }
            catch (Exception)
            {
                return null; // return new EDSystem((int)table.NewRow[0], )
            }
        }

        public static EDSystemDistance[] GetCubeSystems(string systemName, int size)
        {
            if (systemName is null)
            {
                throw new ArgumentNullException(nameof(systemName));
            }

            List<EDSystem> list = new();
            List<EDSystemDistance> cubeSystems = new();
            using SqlConnection connection = new(connectionString);
            using SqlCommand cmd = new("dbo.prcGetCubeSystems", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SystemName", systemName);
            cmd.Parameters.AddWithValue("@Size", size);
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                double x = (double)reader[3];
                double y = (double)reader[4];
                double z = (double)reader[5];
                list.Add(new EDSystem((int)reader[0], (long)reader[1], (string)reader[2], x, y, z, (DateTime)reader[6]));
            }

            // Close the reader so we can get the return value            
            reader.Close();
            int id = (int)returnParameter.Value;

            var source = list.Where(item => item.Id == id).Single();
            foreach (var item in list)
            {
                double deltax = item.X - source.X;
                double deltay = item.Y - source.Y;
                double deltaz = item.Z - source.Z;

                double distance = Math.Sqrt((deltax * deltax) + (deltay * deltay) + (deltaz * deltaz));
                cubeSystems.Add(new EDSystemDistance(item, distance));
            }

            return cubeSystems.ToArray();
        }

        public static EDSystemDistance[] GetSphereSystems(string systemName, int radius)
        {
            if (systemName is null)
            {
                throw new ArgumentNullException(nameof(systemName));
            }

            IEnumerable<EDSystemDistance> cubeSystems = GetCubeSystems(systemName, 2 * radius);
            var sphere = cubeSystems.Where(item => item.Distance <= radius);
            return sphere.ToArray();
        }
    }
}