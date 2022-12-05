using Input;
using Rucksack;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser parser = new Parser("../input.txt");

            List<RucksackContent> rucksacks = new List<RucksackContent>();
            foreach((string c1, string c2) content in parser.getRucksackContents()) {
                rucksacks.Add(new RucksackContent(content.c1, content.c2));
            }

            int prioritySum = rucksacks.Sum(r => r.getItemPriority(r.getWrongItem()));
            Console.WriteLine(prioritySum);

        }
    }
}
