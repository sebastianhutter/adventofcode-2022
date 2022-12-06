using System;

namespace Input {
    class Parser {
        private string file;
        private List<string> messages;

        public Parser(string f) {
            file = f;
            
            messages = new List<string>();

            foreach (string l in System.IO.File.ReadAllLines(@file)) {
                messages.Add(l);
            }
        }

        public List<string> getMessages() {
            return messages;
        }
    }
}
