using Filesystem;
using Input;
using Microsoft.VisualBasic.FileIO;
using Terminal;


namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser rawCommands = new Parser("../input.txt");
            
            List<Terminal.Output> outputs = new List<Terminal.Output>();
            foreach(string l in rawCommands.getLines()) {
                outputs.Add(new Output(l));
            }

            // initialize filetree object and start parsing the command line output
            Filesystem.Tree fsTree = new Filesystem.Tree();

            Filesystem.Dir rootDir = fsTree.getRootDir();
            string currentDirPath = "";
            Filesystem.Dir currentDir = rootDir;
            foreach(Output o in outputs) {
                // if o is a command and starts with dir we need to do something,
                // for ls we dont need to act
                if ((o.isCli()) && (o.getOutput().StartsWith("cd ")))
                {
                    string targetDir = o.getOutput().Substring(2).Trim();
                    if (targetDir == "..")
                    {
                        currentDirPath = currentDirPath.Substring(0, currentDirPath.LastIndexOf("/"));
                    } else
                    {
                        currentDirPath = $"{currentDirPath}/{targetDir}";
                    }
                    currentDir = fsTree.findDirectory(currentDirPath);
                    continue;
                }
            
                if (o.isDir()) {
                    currentDir.addDirectory(o.getOutput());
                    continue;
                }
            
                if (o.isFile()) {
                    currentDir.addFile(o.getOutput(), o.getSize());
                }
            }
            
            // after parsing the command lines we should have a nested list of directories and files
            // get all directories (order will be from top level to bottom level
            List<Filesystem.Dir> allDirectories = new List<Filesystem.Dir>();
            allDirectories = fsTree.getAllDirectories();
            // reverse order to allow calculating last directory sizes first
            allDirectories.Reverse();
            foreach (Filesystem.Dir d in allDirectories)
            {
                d.calculateDirSize();
            }
            // and for good measures calculate root dir size too
            rootDir.calculateDirSize();

            // calculate the available disk space
            int diskSize = 70000000;
            int availableSpace = diskSize - rootDir.getSize();
            int requiredSpaceForUpgrade = 30000000;
            int requiredSpaceToFreeUp = requiredSpaceForUpgrade - availableSpace;
  
            // loop trough the directories startting with the "smallest" one
            // if deleting the dir would free enough space return its 
            Console.WriteLine($"disk space to free up: {requiredSpaceToFreeUp}");
            foreach(Filesystem.Dir d in allDirectories.OrderBy(c => c.getSize())) {
                if (d.getSize() >= requiredSpaceToFreeUp) {
                    Console.WriteLine($"{d.getName()}: {d.getSize()}");
                    break;
                }
            }
        }
    }
}
