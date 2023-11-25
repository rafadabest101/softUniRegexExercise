using System.Text;
using System.Text.RegularExpressions;

namespace softUni_RegexesExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            
            List<char> starLetters = new List<char>() { 's', 'S', 't', 'T', 'a', 'A', 'r', 'R' };
            var regex = @"[^@\-!:>]*@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<soldiers>\d+)[^@\-!:>]*";

            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                var str = Console.ReadLine();
                int starLettersCount = 0;
                foreach(char ch in str)
                {
                    if(starLetters.Contains(ch)) starLettersCount++;
                }

                StringBuilder sb = new StringBuilder();
                foreach(char ch in str)
                {
                    sb.Append((char)(ch - starLettersCount));
                }
                string decryptedMsg = sb.ToString();

                Match m = Regex.Match(decryptedMsg, regex);
                string planetName = m.Groups["planet"].Value;
                string attackType = m.Groups["attackType"].Value;

                if(attackType == "A") attackedPlanets.Add(planetName);
                else if(attackType == "D") destroyedPlanets.Add(planetName);
            }

            attackedPlanets.Sort();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach(string name in attackedPlanets)
            {
                Console.WriteLine($"-> {name}");
            }

            destroyedPlanets.Sort();
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach(string name in destroyedPlanets)
            {
                Console.WriteLine($"-> {name}");
            }
        }
    }
}