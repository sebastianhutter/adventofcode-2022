using Input;
using Rucksack;
using Elves;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser parser = new Parser("../input.txt");

            List<RucksackContent> rucksacks = new List<RucksackContent>();
            foreach((string c1, string c2) content in parser.getRucksackContents()) {
                rucksacks.Add(new RucksackContent(content.c1, content.c2));
            }

            List<Group> elveGroups = new List<Group>();
            for (int i = 0; i < rucksacks.Count; i=i+3) {
                elveGroups.Add(new Group(rucksacks.GetRange(i, 3)));
            }

            int badgeSum = elveGroups.Sum(g => PriorityHelper.getItemPriority(g.getGroupBadge()));
            Console.WriteLine(badgeSum);

        }
    }
}
