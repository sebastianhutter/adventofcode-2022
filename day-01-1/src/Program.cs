using Elf;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser parser = new Parser("../input.txt");
            Team team = new Team();

            foreach (List<int> pc in parser.getCalories()) {
                team.addMember(new Member(pc));
            }

            // first int in tuple = index of elve, second int = total calories of elf
            (int i, int c) elf = team.getMemberWithHighestCaloriesCount();
            Console.WriteLine($"Elf with highest Count is {elf.i+1} carrying {elf.c} calories");
        }
    }
}
