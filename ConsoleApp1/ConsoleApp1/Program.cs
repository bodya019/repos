using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1;
public class Program
{
    static void Main()
    {
        int sum = 0;
        int[] arr = new int[5];
        foreach (int i in arr)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
            sum += arr[i];
        }
        Console.WriteLine(sum);
    }
}