using Input;
using Terminal;


namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser rawCommands = new Parser("../input.txt");
            //List<Datastream.Buffer> buffer = new List<Datastream.Buffer>();

            List<Terminal.Output> outputs = new List<Terminal.Output>();
            foreach(string l in rawCommands.getLines()) {
                outputs.Add(new Output(l));
            }

            // initialize filetree object and start parsing the command line output
            Filesystem.Tree fsTree = new Filesystem.Tree();

            fsTree.addNode(new Filesystem.Dir("/", "dirA"));
            fsTree.addNode(new Filesystem.Dir("/", "dirB"));



            //Dir currentDir = fsTree.ge

            string currentDir = "/";
            foreach(Output o in outputs) {
                // if o is a command and starts with dir we need to do somethin,
                // for ls we dont need to act
                if ((o.isCli()) && (o.getOutput().StartsWith("cd "))) {
                    string targetDir = o.getOutput().Substring(2);
                    if (targetDir == "..") {
                        currentDir = fsTree.getParentNameOfNode(currentDir);
                    } else {
                        currentDir = targetDir;
                    }
                    continue;
                }

                if (o.isDir()) {
                    fsTree.addNode(new Filesystem.Dir(currentDir, o.getOutput()));
                    continue;
                }

                if (o.isFile()) {
                    fsTree.addNode(new Filesystem.File(currentDir, o.getOutput(), o.getSize()));
                    continue;
                }
            }
            
            Console.WriteLine(fsTree.renderTree());

            //Console.WriteLine(buffer[0].getMessageMarkerPosition());

        }
    }
}
