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
            
            foreach((int count, int source, int dest) m in parsedMoves.getMoves()) {
                for(int i=0; i<m.count; i++) {
                    //Console.WriteLine($"move crate from stack {m.source} to stack {m.dest}");
                    stackArea.moveCrate(m.source, m.dest);
                }
            }

            Console.WriteLine(stackArea.returnAllTopCrates());
        }
    }
}
