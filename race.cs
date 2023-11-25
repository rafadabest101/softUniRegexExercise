using System.Text;
using System.Text.RegularExpressions;

namespace softUni_RegexesExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            List<Participant> participants = new List<Participant>();

            string str = Console.ReadLine();
            while(str != "end of race")
            {
                StringBuilder sb = new StringBuilder();
                int distance = 0;
                foreach(char ch in str)
                {
                    if(char.IsLetter(ch)) sb.Append(ch);
                    else if(char.IsDigit(ch)) distance += int.Parse(ch.ToString());
                }

                bool partAlreadyAdded = false;
                foreach(Participant pc in participants)
                {
                    if(pc.Name == sb.ToString())
                    {
                        partAlreadyAdded = true;
                        pc.UpdateDistance(distance);
                        break;
                    }
                }
                if(!partAlreadyAdded && names.Contains(sb.ToString()))
                {
                    participants.Add(new Participant(sb.ToString(), distance));
                }

                str = Console.ReadLine();
            }
            participants = participants.OrderByDescending(p => p.Distance).ToList();
            Console.WriteLine($"1st place: {participants[0].Name}");
            Console.WriteLine($"2nd place: {participants[1].Name}");
            Console.WriteLine($"3rd place: {participants[2].Name}");
        }
    }

    class Participant
    {
        public string Name { get; set; }
        public int Distance { get; set; }

        public Participant(string name, int distance)
        {
            Name = name;
            Distance = distance;
        }

        public void UpdateDistance(int bonusDistance)
        {
            Distance += bonusDistance;
        }
    }
}