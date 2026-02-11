using ConsoleApp1.Session2;
using System.Diagnostics.Metrics;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Session3.Assessment3 x = new Session3.Assessment3();

            string word = "this is a word";
            string reversed = string.Empty;

            for (int i = word.Length-1; i > 0; i--)
                reversed = reversed + word[i];

            Console.WriteLine(reversed);

            StringBuilder sb = new();
            sb[0] = 'g';
        }
    }
}
