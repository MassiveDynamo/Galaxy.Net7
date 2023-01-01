using System.Diagnostics;

int chunkLinesToRead = 20 * 1000 * 1000;
long totalLinesRead = 0;
string fileName = @"D:\data\EDSM-Dumps\systemsWithCoordinates.json";
string currentFileName = GetChunkFileName(fileName, totalLinesRead, chunkLinesToRead);
long currentlinesRead = 0;

using StreamReader sr = new (fileName);
StreamWriter currentFile = new(currentFileName, false);
Stopwatch w = Stopwatch.StartNew();


while(true)
{
    string? line = sr.ReadLine();
    if( line == null)
    {
        break;
    }

    currentlinesRead++;
    totalLinesRead++;

    line.Trim();
    if (line.Length < 10) continue;
    if (line.EndsWith(",")) line = line[..^1];

    if ( currentlinesRead > chunkLinesToRead)
    {
        currentlinesRead = 0;
        currentFile.Close();
        currentFileName = GetChunkFileName(fileName, totalLinesRead, chunkLinesToRead);
        currentFile = new(currentFileName);
    }
    
    currentFile.WriteLine(line);
}

currentFile.Close();
Console.WriteLine($"Lines read:{totalLinesRead}");
Console.WriteLine($"Elapsed: {w.Elapsed}");


string  GetChunkFileName(string fileName, long line, long chunkSize)
{
    return $"{new FileInfo(fileName).FullName}.chunk{(int)(line % chunkSize) + 1}.json";
}