using Input;
using Cargo; 

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            ParserMoves parsedMoves = new ParserMoves("../input_moves.txt");
            ParserStack parsedStack = new ParserStack("../input_stack.txt");

            Area stackArea = new Area();
            foreach(List<char> c in parsedStack.getStacks()) {
                Stack s = new Stack(c);
                stackArea.addStack(s);
            }
            
            Console.WriteLine(stackArea.returnAllCrates());

            foreach((int count, int source, int dest) m in parsedMoves.getMoves()) {
                Console.WriteLine($"move {m.count} crate(s) from stack {m.source} to stack {m.dest}");
                stackArea.moveCrates(m.count, m.source, m.dest);
                Console.WriteLine(stackArea.returnAllCrates());
            }

            Console.WriteLine(stackArea.returnAllCrates());
            Console.WriteLine(stackArea.returnAllTopCrates());
        }
    }
}
