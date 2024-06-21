using System;
using System.Collections.Generic;
using System.IO;

namespace classMatrix
{
    public class Matrix
    {
        double[,] values;
        public static Matrix Empty;

        public int lines { get { return values.GetLength(0); } }
        public int collumns { get { return values.GetLength(1); } }

        public Matrix() { }

        public Matrix(int lin, int col)
        {
            values = new double[lin, col];
        }

        public Matrix(double[,] values)
        {
            this.values = values;
        }

        public Matrix(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            List<string> data = new List<string>();
            string buffer;
            while ((buffer = load.ReadLine()) != null)
                data.Add(buffer);
            load.Close();
            values = new double[data.Count, data[0].Split(' ').Length];
            for (int i = 0; i < values.GetLength(0); i++)
            {
                string[] tmp = data[i].Split(' ');
                for (int j = 0; j < values.GetLength(1); j++)
                    values[i, j] = double.Parse(tmp[j]);
            }
        }

        public Matrix(Matrix toCopy)
        {
            this.values = new double[toCopy.values.GetLength(0), toCopy.values.GetLength(1)];
            for (int i = 0; i < values.GetLength(0); i++)
                for (int j = 0; j < values.GetLength(1); j++)
                    this.values[i, j] = toCopy.values[i, j];
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.lines != b.lines && a.collumns != b.collumns)
                return Matrix.Empty;
            else
            {
                Matrix toReturn = new Matrix(a.lines, a.collumns);
                for (int i = 0; i < a.lines; i++)
                    for (int j = 0; j < a.collumns; j++)
                        toReturn.values[i, j] = a.values[i, j] + b.values[i, j];
                return toReturn;
            }
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.collumns != B.lines)
            {
                Console.WriteLine("Cannot multiply");
                return Matrix.Empty;
            }
            else
            {
                Matrix C = new Matrix(A.lines, B.collumns);
                for (int i = 0; i < A.lines; i++)
                    for (int j = 0; j < B.collumns; j++)
                    {
                        C.values[i, j] = 0;
                        for (int k = 0; k < A.collumns; k++)
                            C.values[i, j] += A.values[i, k] * B.values[k, j];
                    }
                return C;
            }
        }

        public List<string> View()
        {
            List<string> toReturn = new List<string>();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                string buffer = "";
                for (int j = 0; j < values.GetLength(1); j++)
                    buffer += values[i, j].ToString() + "\t";
                toReturn.Add(buffer);
            }
            return toReturn;
        }

        //determinant recursiv, inversa, stelat
    }
}
