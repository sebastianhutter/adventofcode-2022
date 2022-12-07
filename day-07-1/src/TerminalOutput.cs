using System.Text.RegularExpressions;

namespace Terminal {    
    public class Output {
        private string output;
        private bool isCommand = false;
        private bool isDirectory = false;
        private bool isAFile = false;
        private int fileSize = 0;

        private Regex cli = new Regex(@"^\$\s(.*)$");
        private Regex dir = new Regex(@"^dir\s(.*)$");
        private Regex file = new Regex(@"^(\d+)\s(.*)$");
    
        public Output(string l) {
            output = l;
            foreach(Match m in cli.Matches(l)) {
                output = m.Groups[1].Value;
                isCommand = true;
                return;
            }
            foreach(Match m in dir.Matches(l)) {
                output = m.Groups[1].Value;
                isDirectory = true;
                return;
            }
            foreach(Match m in file.Matches(l)) {
                output = m.Groups[2].Value;
                isAFile = true;
                fileSize = Int32.Parse(m.Groups[1].Value);
                return;
            }
        }

        public string getOutput() {
            return output;
        }
        public bool isCli() {
            return isCommand;
        }

        public bool isDir() {
            return isDirectory;
        }
        public bool isFile() {
            return isAFile;
        }

        public int getSize() {
            return fileSize;
        }
    }
}
