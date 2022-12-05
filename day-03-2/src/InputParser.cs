using System;


namespace Input {
    class Parser {
        private string file;
        private List<(string, string)> rucksackContents;

        public Parser(string f) {
            file = f;
            rucksackContents = new List<(string, string)>();

            foreach (string l in System.IO.File.ReadAllLines(@file)) {
                string p1 = l.Substring(0,l.Length/2);
                string p2 = l.Substring(l.Length/2);

                rucksackContents.Add((p1, p2));
            }
        }

        public List<(string, string)> getRucksackContents() {
            return rucksackContents;
        }

    }
}
