using Guide;
using Game;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser parser = new Parser("../input.txt");

            List<Round> rounds = new List<Round>();
            foreach ((string op, string state) mo in parser.getMoves()) {
                rounds.Add(new Round(mo.op, mo.state));
            }

            int totalPoints = rounds.Sum(r => r.getRoundPoints());

            Console.WriteLine(totalPoints);
        }
    }
}
