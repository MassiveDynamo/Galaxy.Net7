// -SystemsZipfile "D:\data\EDSM-Dumps\systemsWithCoordinates.json.gz" -ExpandSystemName "D:\data\EDSM-Dumps\systemsWithCoordinates.json" -Force
// & "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\SqlPackage.exe" /Sourcefile:D:\prj\Galaxy.Net7\src\eddb\bin\Release\eddb.dacpac /TargetDatabaseName:eddb /TargetServerName:"(localdb)\MSSQLLocalDB" /Action:Publish

using ImportEdsmSystems;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

// https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern

string systemsZipfile = args[1];
string expandSystemsName = args[3];
string initialCatalog = args[5];
string connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog={initialCatalog};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
string destinationTableName = "[dbo].[tblEDSystemsWithCoordinates]";

Console.WriteLine($"systemsZipfile:{systemsZipfile}");
Console.WriteLine($"expandSystemName:{expandSystemsName}");

if (!File.Exists(systemsZipfile))
    throw new FileNotFoundException(systemsZipfile);

if (!File.Exists(expandSystemsName))
    throw new FileNotFoundException(expandSystemsName);

using StreamReader sr = new(expandSystemsName, Encoding.UTF8);
Stopwatch w = Stopwatch.StartNew();

SortedDictionary<int, EDSystemJson> list = new();
using DataReaderExample.JsonDataReader rdr = new(expandSystemsName);

while (rdr.Read())
{
    list.Add(rdr.CurrentElement.Id, rdr.CurrentElement);
}

SqlBulkCopy bcp = new(connectionString, SqlBulkCopyOptions.UseInternalTransaction);
bcp.BatchSize = 10000;
bcp.DestinationTableName = destinationTableName;
bcp.NotifyAfter = 1000 * 1000;
bcp.SqlRowsCopied += (sender, e) =>
{
    Console.WriteLine("Written: " + e.RowsCopied.ToString());
};

bcp.WriteToServer(rdr);

w.Stop();
Console.WriteLine($"Lines read: {list.Count}");
Console.WriteLine($"Time elapsed: {w.Elapsed}");