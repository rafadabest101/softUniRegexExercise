using System.Text.RegularExpressions;

namespace softUni_RegexesExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.\d+|\d+)!(?<quantity>\d+)";
            var str = Console.ReadLine();

            List<string> names = new List<string>();
            double totalCost = 0;
            while(str != "Purchase")
            {
                MatchCollection matches = Regex.Matches(str, regex);
                foreach(Match match in matches)
                {
                    string name = match.Groups["name"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    totalCost += price * quantity;
                    names.Add(name);
                }
                str = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach(string name in names) Console.WriteLine(name);
            Console.WriteLine($"Total money spend: {totalCost:f2}");
        }
    }
}