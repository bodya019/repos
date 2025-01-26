using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Utilities.Encoders;
using System.Data;


class Program
{
    static void Main()
    {
        string identicalCubes4 = "1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6";
        string cubes3 = "2,2,4,4,9,9 1,1,6,6,8,8 3,3,5,5,7,7";

        (byte[] key, string hmacResult) = GenerateAndComputeHMAC();

        int numberOfCubes = GetNumberOfCubesFromUser();
        int[,] cubeNumbers = HandleCubesInput(numberOfCubes, cubes3, identicalCubes4);

        Print2DArray(cubeNumbers);

        Console.WriteLine("Let's determine who makes the first move.\r\n" +
            "I selected a random value in the range 0..1.\r\n" +
            $"HMAC (SHA3-256): {hmacResult}");

        Console.WriteLine("Enter the command:\r\n" +
                "0 - 0\r\n" +
                "1 - 1\r\n" +
                "X - exit\r\n" +
                "? - help");

        int step1User = Convert.ToInt32(HandleUserInput(numberOfCubes));
        Console.WriteLine($"Your selection:{step1User}");
        RandomGeneratorBase step1PC = new FirstStep();
        int PcSelection = step1PC.Generate();
        Console.WriteLine($"My selection:{PcSelection} (KEY = {BitConverter.ToString(key).Replace("-", "").ToLower()})");

        int[] removedRowPC = new int[6];
        int[] removedRowUser = new int[6];        

        (int pc1, int user1) =  GameForDifferentCubes(cubeNumbers, PcSelection, step1User, ref removedRowPC, ref removedRowUser);
        (int pc2, int user2) = GameForDifferentCubes(cubeNumbers, PcSelection, step1User, ref removedRowPC, ref removedRowUser);
        int computerResult = pc1 + pc2;
        int userResult = user1 + user2;

        Console.WriteLine($"The end result:\r\n" +
            $"For user = {userResult}.\r\n" +
            $"For computer = {computerResult}.");

        WhoWin(computerResult, userResult);
    }
    static (int a, int b) GameForDifferentCubes(int[,] cubeNumbers, int PcSelection, int step1User, ref int[] removedRowPC, ref int[] removedRowUser)
    {
        if (PcSelection != step1User)
        {
            removedRowPC = RemoveRandomRow(ref cubeNumbers);

            Console.Write("I make the first move and choose the [");
            Console.Write(string.Join(",", removedRowPC));
            Console.WriteLine("] dice.");

            Console.WriteLine("Choose your dice:");
            for (int i = 0; i < cubeNumbers.GetLength(0); i++)
            {
                Console.Write($"{i} - ");
                Console.WriteLine($"[{string.Join(",", Enumerable.Range(0, cubeNumbers.GetLength(1)).Select(j => cubeNumbers[i, j]))}]");
            }
            Console.WriteLine("X - exit");
            Console.WriteLine("? - help");

            int userSelection = Convert.ToInt32(HandleUserInput(cubeNumbers.GetLength(0)));

            removedRowUser = RemoveRowByIndex(ref cubeNumbers, userSelection);
            Console.WriteLine($"Your selection: {userSelection}");
            Console.Write("You choose the [");
            Console.Write(string.Join(",", removedRowUser));
            Console.WriteLine("] dice.");
            Console.WriteLine("It's time for my throw.");
            int computerResult = removedRowPC[Throw()];
            Console.WriteLine($"My throw is {computerResult}.");
            Console.WriteLine("It's time for your throw.");
            int userResult = removedRowUser[Throw()];
            Console.WriteLine($"Your throw is {userResult}.");
            return (computerResult, userResult);
        }
        else
        {
            Console.WriteLine("You make the first move.");
            Console.WriteLine("Choose your dice:");
            for (int i = 0; i < cubeNumbers.GetLength(0); i++)
            {
                Console.Write($"{i} - ");
                Console.WriteLine($"[{string.Join(",", Enumerable.Range(0, cubeNumbers.GetLength(1)).Select(j => cubeNumbers[i, j]))}]");
            }
            Console.WriteLine("X - exit");
            Console.WriteLine("? - help");

            int userSelection = Convert.ToInt32(HandleUserInput(cubeNumbers.GetLength(0)));

            removedRowUser = RemoveRowByIndex(ref cubeNumbers, userSelection);
            Console.WriteLine($"Your selection: {userSelection}");
            Console.Write("You choose the [");
            Console.Write(string.Join(",", removedRowUser));
            Console.WriteLine("] dice.");

            int[] randomRowFromRemaining = RemoveRandomRow(ref cubeNumbers);
            Console.Write("I make the next move and choose the [");
            Console.Write(string.Join(",", randomRowFromRemaining));
            Console.WriteLine("] dice.");
            Console.WriteLine("It's time for your throw.");
            int userResult = removedRowUser[Throw()];
            Console.WriteLine($"Your throw is {userResult}.");

            int computerResult = randomRowFromRemaining[Throw()];
            Console.WriteLine($"My throw is {computerResult}.");
            return (computerResult, userResult);
        }
    }

    static void WhoWin(int pc, int user)
    {
        if (pc > user)
        {
            Console.WriteLine($"I win ({pc} > {user})!");
        }
        else if (pc < user)
        {
            Console.WriteLine($"You win ({user} > {pc})!");
        }
        else
        {
            Console.WriteLine($"Draw ({user} = {pc})!");
        }
    }
    static int Throw()
    {
        RandomGeneratorBase randomFOrThrow = new ComputerNumber();

        int randomValue = randomFOrThrow.Generate();
        (byte[] key, string hmacResult) = GenerateAndComputeHMAC();
        Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={hmacResult}).");

        Console.WriteLine("Add your number modulo 6.");
        Console.WriteLine("0 - 0\n1 - 1\n2 - 2\n3 - 3\n4 - 4\n5 - 5");
        Console.WriteLine("X - exit");
        Console.WriteLine("? - help");

        int userSelection = Convert.ToInt32(HandleUserInput(6));
        Console.WriteLine($"My number is {randomValue} (KEY={BitConverter.ToString(key).Replace("-", "").ToLower()}).");

        int result = (randomValue + userSelection) % 6;
        Console.WriteLine($"The result is {randomValue} + {userSelection} = {result} (mod 6).");
        return result;
    }

    static int[] RemoveRandomRow(ref int[,] cubeNumbers)
    {
        Random rand = new Random();
        int numberOfRows = cubeNumbers.GetLength(0);
        int randomRow = rand.Next(numberOfRows);

        int[] removedRow = new int[6];
        for (int i = 0; i < 6; i++)
        {
            removedRow[i] = cubeNumbers[randomRow, i];
        }

        int[,] newCubeNumbers = new int[numberOfRows - 1, 6];
        int newRow = 0;
        for (int i = 0; i < numberOfRows; i++)
        {
            if (i == randomRow) continue;

            for (int j = 0; j < 6; j++)
            {
                newCubeNumbers[newRow, j] = cubeNumbers[i, j];
            }
            newRow++;
        }

        cubeNumbers = newCubeNumbers;

        return removedRow;
    }
    static int[] RemoveRowByIndex(ref int[,] cubeNumbers, int index)
    {
        int[] removedRow = new int[6];
        for (int i = 0; i < 6; i++)
        {
            removedRow[i] = cubeNumbers[index, i];
        }

        int[,] newCubeNumbers = new int[cubeNumbers.GetLength(0) - 1, 6];
        int newRow = 0;
        for (int i = 0; i < cubeNumbers.GetLength(0); i++)
        {
            if (i == index) continue;

            for (int j = 0; j < 6; j++)
            {
                newCubeNumbers[newRow, j] = cubeNumbers[i, j];
            }
            newRow++;
        }

        cubeNumbers = newCubeNumbers;

        return removedRow;
    }

    static string HandleUserInput(int numberOfCubes)
    {
        while (true)
        {
            string input = ReadHideInput();
            if (int.TryParse(input, out int cubeIndex))
            {

                if (cubeIndex >= 0 && cubeIndex < numberOfCubes)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Unknown program command. Enter '?' for help.");
                    continue;
                }
            }

            switch (input.ToUpper())
            {
                case "X":
                    Console.WriteLine("Exit the program.");
                    Environment.Exit(0);
                    break;

                case "?":
                    string identicalCubes4 = "1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6 1,2,3,4,5,6";
                    string cubes3 = "2,2,4,4,9,9 1,1,6,6,8,8 3,3,5,5,7,7";
                    int[,] dice = HandleCubesInput(numberOfCubes, cubes3, identicalCubes4);
                    double[,] probabilities = CalculateProbabilities(dice);
                    Console.WriteLine("The first step in the game is to determine who will make the first move, while choosing 0 or 1." +
                        " Guessing the number of the computer, if the user guessed, then he goes first, if not, then the computer goes first." +
                        " Next, choose which dice we want to select. After that, we select any number that will be the number of the user's choice in the future." +
                        " The computer's choice and the user's choice are summed up and we get the result of the roll.");                    
                    PrintProbabilityTable(dice, probabilities);
                    

                    break;

                default:
                    Console.WriteLine("Unknown program command. Enter '?' for help.");
                    break;
            }
        }
    }

    static int GetNumberOfCubesFromUser()
    {
        int numberOfCubes;
        while (true)
        {
            Console.WriteLine("How many dice do you want to choose 3 or 4?");
            string input = ReadHideInput();


            if (int.TryParse(input, out numberOfCubes) && (numberOfCubes == 3 || numberOfCubes == 4))
            {
                Console.WriteLine($"Your choose:{numberOfCubes}");
                return numberOfCubes;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter either 3 or 4.");
            }
        }
    }
    static int[,] HandleCubesInput(int numberOfCubes, string cubes3, string identicalCubes4)
    {
        if (numberOfCubes == 3)
        {
            return ProcessStringTo2DArray(cubes3);
        }
        else if (numberOfCubes == 4)
        {
            return ProcessStringTo2DArray(identicalCubes4);
        }
        else
        {
            Console.WriteLine("ERROR: Enter 3 cubes or 4 cubes");
            Console.WriteLine("Please try again.");
            numberOfCubes = Convert.ToInt32(Console.ReadLine());
            return HandleCubesInput(numberOfCubes, cubes3, identicalCubes4);
        }
    }



    static int[,] ProcessStringTo2DArray(string input)
    {
        string[] parts = input.Split(' ');
        int[,] result = new int[parts.Length, 6];

        for (int i = 0; i < parts.Length; i++)
        {
            string[] numbers = parts[i].Split(',');
            for (int j = 0; j < numbers.Length; j++)
            {
                result[i, j] = int.Parse(numbers[j]);
            }
        }

        return result;
    }

    static void Print2DArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            Console.Write($"{i} - ");
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    static void Print1DArray(int[] array)
    {
        foreach (int value in array)
        {
            Console.Write(value + " ");
        }
    }


    static (byte[] key, string hmacResult) GenerateAndComputeHMAC()
    {
        byte[] key = HMACCalculator.GenerateRandomBytes(32);
        byte[] message = HMACCalculator.GenerateRandomBytes(16);
        string hmacResult = HMACCalculator.ComputeHMACSHA3_256(key, message);

        return (key, hmacResult);
    }


    public static class HMACCalculator
    {

        public static byte[] GenerateRandomBytes(int length)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            return data;
        }


        public static string ComputeHMACSHA3_256(byte[] key, byte[] message)
        {
            var hmac = new HMac(new Sha3Digest(256));
            hmac.Init(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));

            byte[] result = new byte[hmac.GetMacSize()];
            hmac.BlockUpdate(message, 0, message.Length);
            hmac.DoFinal(result, 0);

            return Hex.ToHexString(result);
        }
    }

    public abstract class RandomGeneratorBase
    {
        protected static Random random = new Random();
        protected abstract int MinValue { get; }
        protected abstract int MaxValue { get; }

        public int Generate()
        {
            return random.Next(MinValue, MaxValue);
        }
    }

    public class FirstStep : RandomGeneratorBase
    {
        protected override int MinValue => 0;
        protected override int MaxValue => 2;
    }

    public class ComputerNumber : RandomGeneratorBase
    {
        protected override int MinValue => 0;
        protected override int MaxValue => 6;
    }

    static string ReadHideInput()
    {
        string input = Console.ReadLine();
        int currentLine = Console.CursorTop;
        Console.SetCursorPosition(0, currentLine - 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLine - 1);
        return input.ToUpper();
    }

    static double[,] CalculateProbabilities(int[,] dice)
    {
        int numDice = dice.GetLength(0);
        double[,] probabilities = new double[numDice, numDice];

        for (int i = 0; i < numDice; i++)
        {
            for (int j = 0; j < numDice; j++)
            {
                if (i == j)
                {
                    probabilities[i, j] = -1; 
                }
                else
                {
                    probabilities[i, j] = CalculateWinProbability(dice, i, j);
                }
            }
        }

        return probabilities;
    }

    static double CalculateWinProbability(int[,] dice, int userIndex, int pcIndex)
    {
        int[] userDice = GetRow(dice, userIndex);
        int[] pcDice = GetRow(dice, pcIndex);

        int userWins = 0;
        int totalRolls = userDice.Length * pcDice.Length;

        foreach (int userRoll in userDice)
        {
            foreach (int pcRoll in pcDice)
            {
                if (userRoll > pcRoll)
                {
                    userWins++;
                }
            }
        }

        return (double)userWins / totalRolls;
    }

    static int[] GetRow(int[,] array, int rowIndex)
    {
        int cols = array.GetLength(1);
        int[] row = new int[cols];
        for (int col = 0; col < cols; col++)
        {
            row[col] = array[rowIndex, col];
        }
        return row;
    }

    static void PrintProbabilityTable(int[,] dice, double[,] probabilities)
    {
        Console.WriteLine("Probability of the win for the user:");
        Console.WriteLine("+-------------+-------------+-------------+-------------+");
        Console.Write("| User dice v ");
        for (int i = 0; i < dice.GetLength(0); i++)
        {
            Console.Write($"| {string.Join(",", GetRow(dice, i))} ");
        }
        Console.WriteLine("|");
        Console.WriteLine("+-------------+-------------+-------------+-------------+");

        for (int i = 0; i < dice.GetLength(0); i++)
        {
            Console.Write($"| {string.Join(",", GetRow(dice, i))} ");
            for (int j = 0; j < dice.GetLength(0); j++)
            {
                if (probabilities[i, j] == -1)
                {
                    Console.Write("| - (0.3333)  "); // Same dice, probability of tie
                }
                else
                {
                    Console.Write($"| {probabilities[i, j]:F4}      ");
                }
            }
            Console.WriteLine("|");
            Console.WriteLine("+-------------+-------------+-------------+-------------+");
        }
    }
}