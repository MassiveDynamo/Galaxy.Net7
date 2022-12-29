﻿using ImportEdsmSystems;
using System.Data;
using System.Text.Json;

namespace DataReaderExample
{
    public class JsonDataReader : IDataReader
    {
        public EDSystemJson CurrentElement;
        private int _index;
        private readonly StreamReader _sr;
        private bool _isClosed;

        public JsonDataReader(string filePath)
        {
            _index = -1;
            _sr = new StreamReader(filePath);
            CurrentElement = new EDSystemJson();
        }

        public object GetValue(int ordinal)
        {
            switch (ordinal)
            {
                case 0:
                    return CurrentElement.Id;
                case 1:
                    return CurrentElement.Id64;
                case 2:
                    return CurrentElement.Name;
                case 3:
                    return CurrentElement.Coords.X;
                case 4:
                    return CurrentElement.Coords.Y;
                case 5:
                    return CurrentElement.Coords.Z;
                case 6:
                    return CurrentElement.Date;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool Read()
        {
            string? line = GetJsonLine();
            if (line == null) return false;
            CurrentElement = JsonSerializer.Deserialize<EDSystemJson>(line);
            return true;
        }

        private string? GetJsonLine()
        {
            string? line = _sr.ReadLine();
            if (line == null) return null;

            _index++;
            line = line.Trim();
            if (line == null || line.Length == 0) return null;
            while (line!.Length < 10)
            {
                line = GetJsonLine();
            }

            if (line.EndsWith(",")) line = line[..^1];
            return line;
        }

        public int FieldCount
        {
            get
            {
                return 7;
            }
        }

        int IDataReader.Depth => 1;

        bool IDataReader.IsClosed => _isClosed;

        int IDataReader.RecordsAffected => throw new NotImplementedException();

        object IDataRecord.this[string name] => throw new NotImplementedException();

        object IDataRecord.this[int i] => throw new NotImplementedException();

        public string GetName(int ordinal)
        {
            return EDSystemJson.GetPropertyNames().ToArray()[ordinal];
        }

        public int GetOrdinal(string name)
        {
            int index = 0;
            foreach (string key in EDSystemJson.GetPropertyNames())
            {
                if (key == name)
                {
                    return index;
                }
                index++;
            }
            throw new ArgumentOutOfRangeException("Specified name not found in json file.");
        }

        public void Close()
        {
            _index = -1;
            if (!_isClosed)
            {
                _sr.Close();
                _isClosed = true;
            }
        }

        public void Dispose() => Close();

        DataTable? IDataReader.GetSchemaTable()
        {
            DataTable? table = new();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Id64", typeof(long));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));
            table.Columns.Add("Z", typeof(double));
            table.Columns.Add("Date", typeof(DateTime));
            return table;
        }

        bool IDataReader.NextResult()
        {
            return Read();
        }

        bool IDataRecord.GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        byte IDataRecord.GetByte(int i)
        {
            throw new NotImplementedException();
        }

        long IDataRecord.GetBytes(int i, long fieldOffset, byte[]? buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        char IDataRecord.GetChar(int i)
        {
            throw new NotImplementedException();
        }

        long IDataRecord.GetChars(int i, long fieldoffset, char[]? buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        IDataReader IDataRecord.GetData(int i)
        {
            throw new NotImplementedException();
        }

        string IDataRecord.GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        DateTime IDataRecord.GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        decimal IDataRecord.GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        double IDataRecord.GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        Type IDataRecord.GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        float IDataRecord.GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        Guid IDataRecord.GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        short IDataRecord.GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        int IDataRecord.GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        long IDataRecord.GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        string IDataRecord.GetString(int i)
        {
            throw new NotImplementedException();
        }

        int IDataRecord.GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        bool IDataRecord.IsDBNull(int i)
        {
            throw new NotImplementedException();
        }
    }
}