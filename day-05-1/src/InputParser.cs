using System;
using System.Text.RegularExpressions;

namespace Input {
    class ParserMoves {
        private string file;
        // first int = count of items to move
        // second int = source stack to move from
        // third int = destination stack to move to
        private List<(int, int, int)> moves;

        public ParserMoves(string f) {
            file = f;
            
            moves = new List<(int, int, int)>();
            //Regex regex = new Regex(@"^move\s(\d+)\sfrom\s(\d+)\sto(\d+)$");
            Regex regex = new Regex(@"^move\s(\d+)\sfrom\s(\d+)\sto\s(\d+)$");

            foreach (string l in System.IO.File.ReadAllLines(@file)) {
                Match m = regex.Match(l);
                int count = Int32.Parse(m.Groups[1].Value);
                int source = Int32.Parse(m.Groups[2].Value);
                int dest = Int32.Parse(m.Groups[3].Value);
                moves.Add((count, source, dest));
            }
        }

        public List<(int, int, int)> getMoves() {
            return moves;
        }

    }

    class ParserStack {
        private string file;
        private List<List<char>> stacks;

        public ParserStack(string f) {
            file = f;
            
            stacks = new List<List<char>>();

            // iterate over the stack file but skeep the last line
            // the id of the stack is calculated in the loop
            Regex regItem = new Regex(@"\[(\w)\]");
            foreach (string l in System.IO.File.ReadAllLines(@file).SkipLast(1)) {
                int stackCount = 1;
                // iterate over the lines, in 4 char steps 
                // basically the item in brackets + whitespace -> [X]\s
                for(int i = 0; i<=l.Length; i = i + 4) {
                    if (stacks.Count < stackCount) {
                        // Console.WriteLine($"id: {stackCount} not in list yet");
                        stacks.Add(new List<char>());
                    }
                    // Console.WriteLine($"id: {stackCount}, string length: {l.Length}, curser: {i}");
                    // Console.WriteLine(l.Skip(i).Take(4).ToArray());
                    string itemSlice = new string(l.Skip(i).Take(4).ToArray());
                    foreach(Match m in regItem.Matches(itemSlice)) {
                        char c = char.Parse(m.Groups[1].Value);
                        stacks[stackCount-1].Add(c);
                    }
                    stackCount += 1;
                }
            }
            // reverse all lists so the "last" create is on top
            foreach(List<char> s in stacks) {
                s.Reverse();
            }
        }

        public List<List<char>> getStacks() {
            return stacks;
        }

    }
}
