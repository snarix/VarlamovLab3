using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.XPath;

namespace LibMatrix
{
    public class Matrix<T>
    {
        private T[,] _matrix;
        private int _row;
        private int _column;

        private readonly int _defaultRowCount = 3;
        private readonly int _defaultColumnCount = 4;

        public Matrix(int rowCount, int columnCount, string extension = ".matrix")
        {
            _matrix = new T[rowCount, columnCount];
            _row = rowCount;
            _column = columnCount;
        }

        public T this[int rowIndex, int columnIndex]
        {
            get { return _matrix[rowIndex, columnIndex]; }
            set { _matrix[rowIndex, columnIndex] = value; }
        }

        public int CountRow
        {
            get => _row;
            private set
            {
                if (value == _row)
                {
                    return;
                }

                _row = value;
            }
        }

        public int CountColumn
        {
            get => _column;
            private set
            {
                if (value == _column)
                {
                    return;
                }

                _column = value;
            }
        }

        public void DefaultInit()
        {      
            for (int i = 0; i < CountColumn; i++)
            {
                for (int j = 1; j < CountRow; j++)
                {
                    _matrix[i, j] = default;
                }
            }
        }

        private static readonly BinaryFormatter _formatter = new();
        public readonly string Extension = ".matrix";

        public void Save(string path)
        {
            string fullPath = string.Concat(path, Extension);

            using (FileStream stream = new(fullPath, FileMode.Create))
            {
                _formatter.Serialize(stream, _matrix);
            }
        }

        public void Load(string path)
        {
            string fullPath = string.Concat(path, Extension);

            using (FileStream stream = new(fullPath, FileMode.Open))
            {
                _matrix = _formatter.Deserialize(stream) as T[,];
            }

        }

        public void Clear()
        {          
            CountRow = 0;
            CountColumn = 0;
            _matrix = new T[_row, _column];
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _matrix.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    row[j] = _matrix[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
