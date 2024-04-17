public class VectorLong
{
    protected long[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vl;

    public VectorLong()
    {
        IntArray = new long[1];
        size = 1;
        num_vl++;
    }

    public VectorLong(uint size)
    {
        IntArray = new long[size];
        this.size = size;
        num_vl++;
    }

    public VectorLong(long[] array)
    {
        size = (uint)array.Length;
        IntArray = new long[size];
        CodeError = 0;
        for (int i = 0; i < size; i++)
            IntArray[i] = array[i];
        num_vl = 0;
    }

    public VectorLong(uint size, long initValue)
    {
        IntArray = new long[size];
        this.size = size;
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        num_vl++;
    }

    ~VectorLong()
    {
        Console.WriteLine("Destructor called for VectorLong");
    }

    public void Input()
    {
        Console.Write("Enter vector: \n");
        string var = Console.ReadLine() ?? throw new IOException();
        long[] array = var.Split(' ').Select(long.Parse).ToArray();
        for (int i = 0; i < size; i++)
            IntArray[i] = array[i];
    }

    public void Display()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(IntArray[i].ToString() + ' ');
        }
        Console.WriteLine();
    }

    public void Assign(long value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint NumVectors()
    {
        return num_vl;
    }

    public long this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                codeError = 0;
                throw new IndexOutOfRangeException();
            }
            else
            {
                return IntArray[index];
            }
        }
        set
        {
            if (index >= 0 && index < size)
            {
                IntArray[index] = value;
            }
            else
            {
                codeError = 1;
                throw new IndexOutOfRangeException();
            }
        }
    }

    public uint Size
    {
        get { return size; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public static VectorLong operator ++(VectorLong vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]++;
        }
        return vec;
    }

    public static VectorLong operator --(VectorLong vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i]--;
        }
        return vec;
    }

    public static bool operator true(VectorLong vec)
    {
        if(vec.size == 0) 
            return false;
        foreach (long element in vec.IntArray)
        {
            if (element == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorLong vec)
    {
        if (vec.size == 0)
            return true;
        foreach (long element in vec.IntArray)
        {
            if (element == 0)
                return true;
        }
        return false;
    }

    public static bool operator !(VectorLong vec)
    {
        return vec.size != 0;
    }

    public static VectorLong operator ~(VectorLong vec)
    {
        for (int i = 0; i < vec.size; i++)
        {
            vec.IntArray[i] = ~vec.IntArray[i];
        }
        return vec;
    }

    public static VectorLong operator +(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] + vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator +(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] + scalar;
        }
        return result;
    }

    public static VectorLong operator -(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] - vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator -(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] - scalar;
        }
        return result;
    }

    public static VectorLong operator *(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] * vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator *(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] * scalar;
        }
        return result;
    }
    
    public static VectorLong operator *(long scalar, VectorLong vec)
    {
        return vec * scalar;
    }

    public static VectorLong operator /(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            if (vec2.IntArray[i] != 0)
                result.IntArray[i] = vec1.IntArray[i] / vec2.IntArray[i];
            else
                result.IntArray[i] = 0;
        }
        return result;
    }

    public static VectorLong operator /(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            if (scalar != 0)
                result.IntArray[i] = vec.IntArray[i] / scalar;
            else
                result.IntArray[i] = 0;
        }
        return result;
    }

    public static VectorLong operator %(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            if (vec2.IntArray[i] != 0)
                result.IntArray[i] = vec1.IntArray[i] % vec2.IntArray[i];
            else
                result.IntArray[i] = 0;
        }
        return result;
    }

    public static VectorLong operator %(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            if (scalar != 0)
                result.IntArray[i] = vec.IntArray[i] % scalar;
            else
                result.IntArray[i] = 0;
        }
        return result;
    }

    public static VectorLong operator |(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] | vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator |(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] | scalar;
        }
        return result;
    }

    public static VectorLong operator ^(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] ^ vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator ^(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] ^ scalar;
        }
        return result;
    }

    public static VectorLong operator &(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] & vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator &(VectorLong vec, int scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] & scalar;
        }
        return result;
    }

    public static VectorLong operator >>(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] >> (int)vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator >>(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] >> (int)scalar;
        }
        return result;
    }

    public static VectorLong operator <<(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            vec1.codeError = -1;
            return vec1;
        }

        VectorLong result = new(vec1.size);
        for (int i = 0; i < vec1.size; i++)
        {
            result.IntArray[i] = vec1.IntArray[i] << (int)vec2.IntArray[i];
        }
        return result;
    }

    public static VectorLong operator <<(VectorLong vec, long scalar)
    {
        VectorLong result = new(vec.size);
        for (int i = 0; i < vec.size; i++)
        {
            result.IntArray[i] = vec.IntArray[i] << (int)scalar;
        }
        return result;
    }

    public static bool operator ==(VectorLong vec1, VectorLong vec2)
    {
        if (ReferenceEquals(vec1, vec2))
        {
            return true;
        }
        if (vec1 is null || vec2 is null)
        {
            return false;
        }
        if (vec1.size != vec2.size)
        {
            return false;
        }

        for (int i = 0; i < vec1.size; i++)
        {
            if (vec1.IntArray[i] != vec2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator !=(VectorLong vec1, VectorLong vec2)
    {
        return !(vec1 == vec2);
    }

    public static bool operator >(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            return false;
        }

        for (int i = 0; i < vec1.size; i++)
        {
            if (vec1.IntArray[i] <= vec2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator >=(VectorLong vec1, VectorLong vec2)
    {
        if (vec1.size != vec2.size)
        {
            return false;
        }

        for (int i = 0; i < vec1.size; i++)
        {
            if (vec1.IntArray[i] < vec2.IntArray[i])
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator <(VectorLong vec1, VectorLong vec2)
    {
        return !(vec1 >= vec2);
    }

    public static bool operator <=(VectorLong vec1, VectorLong vec2)
    {
        return !(vec1 > vec2);
    }
}


class Task2
{
    public static void task2()
    {
        VectorLong vector1 = new(5, 10);

        Console.WriteLine("Vector 1:");
        vector1.Display();

        VectorLong vector2 = new(5, 5);

        Console.WriteLine("Enter elements for Vector 2:");
        vector2.Input();

        Console.WriteLine("Vector 2:");
        vector2.Display();

        Console.WriteLine($"Size of Vector 1: {vector1.Size}");
        Console.WriteLine($"Size of Vector 2: {vector2.Size}");

        Console.WriteLine($"Vector 1 == Vector 2: {vector1 == vector2}");

        Console.WriteLine($"Vector 1 != Vector 2: {vector1 != vector2}");

        Console.WriteLine($"Vector 1 > Vector 2: {vector1 > vector2}");
        Console.WriteLine($"Vector 1 >= Vector 2: {vector1 >= vector2}");
        Console.WriteLine($"Vector 1 < Vector 2: {vector1 < vector2}");
        Console.WriteLine($"Vector 1 <= Vector 2: {vector1 <= vector2}");

        VectorLong bitwiseResult = vector1 | vector2;
        Console.WriteLine("Vector 1 | Vector 2:");
        bitwiseResult.Display();
    }
}
