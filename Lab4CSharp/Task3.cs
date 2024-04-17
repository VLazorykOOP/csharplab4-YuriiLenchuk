public class MatrixLong
{
    protected VectorLong[] LongArray;
    protected uint n, m;
    protected int codeError;
    protected static int num_m;

    public MatrixLong()
    {
        n = m = 1;
        LongArray = new VectorLong[1];
        LongArray[0] = new VectorLong();
        codeError = 0;
        num_m++;
    }

    public MatrixLong(long[,] array)
    {
        n = (uint)(array.Length <= 0 ? 1 : array.GetLength(0));
        m = (uint)(array.GetLength(0) <= 0 ? 1 : array.GetLength(1));
        LongArray = new VectorLong[n];
        for (int i = 0; i < n; i++)
        {
            LongArray[i] = new VectorLong(m);
            for (int j = 0; j < m; j++)
                LongArray[i][j] = array[i, j];
        }
        codeError = 0;
        num_m++;    
    }

    public MatrixLong(uint rows, uint columns)
    {
        n = rows;
        m = columns;
        LongArray = new VectorLong[n];
        for (int i = 0; i < n; i++)
        {
            LongArray[i] = new VectorLong(columns);
        }
        codeError = 0;
        num_m++;
    }

    public MatrixLong(uint rows, uint columns, long initValue)
    {
        n = rows;
        m = columns;
        LongArray = new VectorLong[n];
        for (int i = 0; i < n; i++)
        {
            LongArray[i] = new VectorLong(columns, initValue);
        }
        codeError = 0;
        num_m++;
    }

    ~MatrixLong()
    {
        Console.WriteLine("Matrix destroyed");
    }

    public void Input()
    {
        foreach (VectorLong vector in LongArray)
        {
            vector.Input();
        }
    }

    public void Display()
    {
        foreach (VectorLong vector in LongArray)
        {
            vector.Display();
        }
    }

    public void Assign(long value)
    {
        foreach (VectorLong vector in LongArray)
        {
            vector.Assign(value);
        }
    }

    public static int GetNumMatrices()
    {
        return num_m;
    }

    public uint Rows
    {
        get { return n; }
    }

    public uint Columns
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public VectorLong this[int i]
    {
        get
        {
            if (i < 0 || i >= n)
            {
                codeError = 1;
                return new VectorLong();
            }
            else
            {
                codeError = 0;
                return LongArray[i];
            }
        }
        set
        {
            if (i >= 0 && i < n)
            {
                LongArray[i] = value;
                codeError = 0;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    public long this[int i, int j]
    {
        get
        {
            if (i < 0 || i >= n || j < 0 || j >= m)
            {
                codeError = 1;
                return 0;
            }
            else
            {
                codeError = 0;
                return LongArray[i][j];
            }
        }
        set
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
            {
                LongArray[i][j] = value;
                codeError = 0;
            }
            else
            {
                codeError = 1;
            }
        }
    }

    public static MatrixLong operator ++(MatrixLong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            ++matrix.LongArray[i];
        }
        return matrix;
    }

    public static MatrixLong operator --(MatrixLong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            --matrix.LongArray[i];
        }
        return matrix;
    }

    public static bool operator true(MatrixLong matrix)
    {
        foreach (VectorLong vector in matrix.LongArray)
        {
            if (!vector)
                return false;
        }
        return true;
    }

    public static bool operator false(MatrixLong matrix)
    {
        foreach (VectorLong vector in matrix.LongArray)
        {
            if (vector)
                return false;
        }
        return true;
    }

    public static bool operator !(MatrixLong matrix)
    {
        return matrix.n != 0 && matrix.m != 0;
    }

    public static MatrixLong operator ~(MatrixLong matrix)
    {
        for (int i = 0; i < matrix.n; i++)
        {
            matrix.LongArray[i] = ~matrix.LongArray[i];
        }
        return matrix;
    }

    public static MatrixLong operator +(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrix dimensions must be the same for addition");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            result[i] = matrix1[i] + matrix2[i];
        }
        return result;
    }

    public static MatrixLong operator +(MatrixLong matrix, long scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            result[i] = matrix[i] + scalar;
        }
        return result;
    }

    public static MatrixLong operator -(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrix dimensions must be the same for subtraction");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            result[i] = matrix1[i] - matrix2[i];
        }
        return result;
    }

    public static MatrixLong operator -(MatrixLong matrix, long scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            result[i] = matrix[i] - scalar;
        }
        return result;
    }

    public static MatrixLong operator *(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.m != matrix2.n)
        {
            throw new ArgumentException("Number of columns of the first matrix must be equal to the number of rows of the second matrix for matrix multiplication");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix2.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix2.m; j++)
            {
                for (int k = 0; k < matrix1.m; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    public static VectorLong operator *(MatrixLong matrix, VectorLong vector)
    {
        if (matrix.m != vector.Size)
        {
            throw new ArgumentException("Number of columns of the matrix must be equal to the size of the vector for matrix-vector multiplication");
        }

        VectorLong result = new VectorLong(matrix.n);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i] += matrix[i, j] * vector[j];
            }
        }
        return result;
    }

    public static MatrixLong operator *(MatrixLong matrix, long scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    public static MatrixLong operator *(long scalar, MatrixLong matrix)
    {
        return matrix * scalar;
    }

    public static MatrixLong operator /(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (!!matrix2)
        {
            throw new DivideByZeroException("Cannot divide by zero matrix");
        }

        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions for division");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] / matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixLong operator /(MatrixLong matrix, long scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Cannot divide matrix by zero scalar");
        }

        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] / scalar;
            }
        }
        return result;
    }

    public static MatrixLong operator %(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions.");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] % matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixLong operator %(MatrixLong matrix, long scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Division by zero.");
        }

        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] % scalar;
            }
        }
        return result;
    }

    public static MatrixLong operator ^(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions for bitwise XOR operation.");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] ^ matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixLong operator ^(MatrixLong matrix, long scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] ^ scalar;
            }
        }
        return result;
    }

    public static MatrixLong operator |(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions for bitwise AND operation.");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] & matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixLong operator |(MatrixLong matrix, long scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] & scalar;
            }
        }
        return result;
    }

    public static MatrixLong operator >>(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions for bitwise right shift operation.");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] >> (int)matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixLong operator >>(MatrixLong matrix, uint scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] >> (int)scalar;
            }
        }
        return result;
    }

    public static MatrixLong operator <<(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions for bitwise left shift operation.");
        }

        MatrixLong result = new MatrixLong(matrix1.n, matrix1.m);
        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                result[i, j] = matrix1[i, j] << (int)matrix2[i, j];
            }
        }
        return result;
    }

    public static MatrixLong operator <<(MatrixLong matrix, uint scalar)
    {
        MatrixLong result = new MatrixLong(matrix.n, matrix.m);
        for (int i = 0; i < matrix.n; i++)
        {
            for (int j = 0; j < matrix.m; j++)
            {
                result[i, j] = matrix[i, j] << (int)scalar;
            }
        }
        return result;
    }

    public static bool operator ==(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (ReferenceEquals(matrix1, matrix2))
        {
            return true;
        }

        if (matrix1 is null || matrix2 is null)
        {
            return false;
        }

        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            return false;
        }

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(MatrixLong matrix1, MatrixLong matrix2)
    {
        return !(matrix1 == matrix2);
    }

    public static bool operator >(MatrixLong matrix1, MatrixLong matrix2)
    {
        if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
        {
            throw new ArgumentException("Matrices must have the same dimensions for comparison.");
        }

        for (int i = 0; i < matrix1.n; i++)
        {
            for (int j = 0; j < matrix1.m; j++)
            {
                if (matrix1[i, j] <= matrix2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator >=(MatrixLong matrix1, MatrixLong matrix2)
    {
        return matrix1 == matrix2 || matrix1 > matrix2;
    }

    public static bool operator <(MatrixLong matrix1, MatrixLong matrix2)
    {
        return !(matrix1 >= matrix2);
    }

    public static bool operator <=(MatrixLong matrix1, MatrixLong matrix2)
    {
        return !(matrix1 > matrix2);
    }
}

class Task3
{
    public static void task3()
    {
        MatrixLong matrix1 = new();
        Console.WriteLine("Matrix1 (constructor without parameters):");
        matrix1.Display();

        MatrixLong matrix2 = new(3, 3);
        Console.WriteLine("Matrix2 (constructor with parameters):");
        matrix2.Display();

        long[,] values = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        MatrixLong matrix3 = new(values);
        Console.WriteLine("Matrix3 (constructor with parameters):");
        matrix3.Display();

        matrix2[0, 0] = 10;
        matrix2[1, 1] = 20;
        matrix2[2, 2] = 30;
        Console.WriteLine("Matrix2 after setting values:");
        matrix2.Display();

        Console.WriteLine("Matrix1 == Matrix2: " + (matrix1 == matrix2));
        Console.WriteLine("Matrix2 == Matrix3: " + (matrix2 == matrix3));
        Console.WriteLine("Matrix2 != Matrix3: " + (matrix2 != matrix3));
        Console.WriteLine("Matrix2 > Matrix3: " + (matrix2 > matrix3));
        Console.WriteLine("Matrix2 >= Matrix3: " + (matrix2 >= matrix3));
        Console.WriteLine("Matrix2 < Matrix3: " + (matrix2 < matrix3));
        Console.WriteLine("Matrix2 <= Matrix3: " + (matrix2 <= matrix3));
    }
}