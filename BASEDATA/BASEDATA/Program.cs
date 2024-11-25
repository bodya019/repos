using Org.BouncyCastle.Bcpg.OpenPgp;
using System;

namespace BASEDATA
{
    class Program
    {
        public async static Task Main()
        {
            DB date = new DB();
            string? title = Console.ReadLine();
            string? text = Console.ReadLine();
            string? data = Console.ReadLine();
            string? avtor = Console.ReadLine();
            await date.UpdateData(title, text, data, avtor);
        }
    }
}