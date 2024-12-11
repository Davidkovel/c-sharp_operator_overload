using System;
namespace InheritanceApp;

public interface IMatrix
{
    double this[int row, int col] { get; set; }
    int Rows { get; }
    int Columns { get; }
    void Fill(double value);
    void Print();
}

class Matrix : IMatrix
{
    private double[,] elements;

    public int Rows { get; set; }
    public int Columns { get; set; }

    public double this[int row, int col]
    {
        get { return elements[row, col]; }
        set { elements[row, col] = value; }
    }

    public Matrix(int rows, int columns)
    {
        this.Rows = rows;
        this.Columns = columns;
        elements = new double[rows, columns];
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new Exception("Matrices must have the same dimensions for addition operation");

        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new Exception("Matrices must have the same dimensions for subtraction operation");

        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] - b[i, j];

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new Exception("Number of columns in the first matrix must equal the number of rows in the second matrix");

        Matrix result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Columns; j++)
                for (int k = 0; k < a.Columns; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return result;
    }

    public static Matrix operator *(Matrix a, double scalar)
    {
        Matrix result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] * scalar;

        return result;
    }

    public static bool operator ==(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            return false;

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                if (a[i, j] != b[i, j])
                    return false;

        return true;
    }

    public static bool operator !=(Matrix a, Matrix b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Matrix other)
            return this == other;

        return false;
    }

    public void Fill(double value)
    {
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                elements[i, j] = value;
    }

    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
                Console.Write(elements[i, j] + " ");

            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        var m1 = new Matrix(2, 2);
        var m2 = new Matrix(2, 2);

        m1.Fill(3);
        m2.Fill(4);

        Console.WriteLine("Matrix 1:");
        m1.Print();

        Console.WriteLine("Matrix 2:");
        m2.Print();

        Matrix sum = m1 + m2;
        Console.WriteLine("Sum:");
        sum.Print();

        Matrix product = m1 * m2;
        Console.WriteLine("Multiplication:");
        product.Print();

        Matrix scaled = m1 * 3;
        Console.WriteLine("Matrix 1 by 3:");
        scaled.Print();

        Console.WriteLine("Matrix 1 == Matrix 2? " + (m1 == m2));
        Console.WriteLine("Matrix 1 != Matrix 2? " + (m1 != m2));
    }
}



/*
Matrix 1:
3 3
3 3
Matrix 2:
4 4
4 4
Sum:
7 7
7 7
Multiplication:
24 24
24 24
Matrix 1 by 3:
9 9
9 9
Matrix 1 == Matrix 2? False
Matrix 1 != Matrix 2? True

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 20852) exited with code 0 (0x0).
Press any key to close this window . . .

*/