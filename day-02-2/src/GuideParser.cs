using System;


namespace Guide {
    class Parser {
        private string file;
        private List<(string, string)> moves;

        public Parser(string f) {
            file = f;
            moves = new List<(string, string)>();

            foreach (string l in System.IO.File.ReadAllLines(@file)) {
                String[] r = l.Split(' ');
                moves.Add((r[0], r[1]));
            }
        }

        public List<(string, string)> getMoves() {
            return moves;
        }

    }
}
