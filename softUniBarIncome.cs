using System.Text;
using System.Text.RegularExpressions;

namespace softUni_RegexesExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|\D*(?<price>\d+\.\d+|\d+)\$";
            var str = Console.ReadLine();

            double income = 0;
            while(str != "end of shift")
            {
                MatchCollection mc = Regex.Matches(str, regex);
                foreach(Match m in mc)
                {
                    string name = m.Groups["name"].Value;
                    string product = m.Groups["product"].Value;
                    int quantity = int.Parse(m.Groups["quantity"].Value);
                    double price = double.Parse(m.Groups["price"].Value);

                    income += quantity * price;
                    Console.WriteLine($"{name}: {product} - {quantity * price:f2}");
                }

                str = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}