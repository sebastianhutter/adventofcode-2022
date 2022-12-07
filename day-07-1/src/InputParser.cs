using System;

namespace Input {
    class Parser {
        private string file;
        private List<string> lines;

        public Parser(string f) {
            file = f;
            
            lines = new List<string>();

            // parse input, skip the first line as it's always 'cd /'
            foreach (string l in System.IO.File.ReadAllLines(@file).Skip(1)) {
                lines.Add(l);
            }
        }

        public List<string> getLines() {
            return lines;
        }
    }
}
