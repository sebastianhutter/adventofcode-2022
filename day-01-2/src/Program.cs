using Elf;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser parser = new Parser("../input.txt");
            Team team = new Team();

            foreach (List<int> pc in parser.getCalories()) {
                team.addMember(new Member(pc));
            }

            int topElfesToGetCalories = 3;
            List<Member> elfes = team.getElfesWithTheHighestCaloriesCount(topElfesToGetCalories);
            int totalCaloriesOfTopElfes = elfes.Sum(e => e.getTotalCalories());
            Console.WriteLine($"The {topElfesToGetCalories} have combined {totalCaloriesOfTopElfes} calories to spare!");
        }
    }
}
