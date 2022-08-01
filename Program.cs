/*
 * Testing async operations through the Task Main()
 */

using System;
using System.Collections.Generic;
using TestNS;

#region Test:
namespace TestNS
{ 
    interface iTest
    {
        public int[] ints { get; set; } 
    }

    public class Test: iTest
    {
        public int[] ints { get; set; }
        public int a, b, c;

        public Test(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            ints = new int[] { a, b, c };
        }
    }

    public class NewTest : Test
    {
        public int d;
        public NewTest(int x, int y, int z, int d) : base(x, y, z)
        {
            this.d = d;

            ints = new int[] { x, y, z, d };
        }
}
}
#endregion test />

public class Program
{
    private static void Main(string[] args)
    {
        var t = new NewTest(1, 2, 3, 4).Sum();
        var t2 = new Test(1, 2, 3).Sum();

        Console.WriteLine($"{t} + {t2} = {t + t2}");
    }
}

public static class TestSum
{
    public static int Sum(this Test t)
    {
        int s = 0;
        for (int i = 0; i < t.ints.Length; i++)
            s += t.ints[i];
        return s;
    }
}


