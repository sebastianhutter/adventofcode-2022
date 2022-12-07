using System.Reflection.Metadata.Ecma335;

namespace Filesystem {
    public class Tree {
        private List<Node> nodes;

        public Tree() {
            nodes = new List<Node>();
            nodes.Add(new Dir("/"));
        }

        public void addNode(Node n) {
            nodes.Add(n);
        }

        public Dir getRootDir()
        {
            return nodes[0] as Dir;
        }

        public Dir findDirectory(string path)
        {
            // find directory by path "abc/def" looks for the directory def in the directory abc
            // directory abc will be looked for in the rootdir

            path = path.Trim();
            if (path.EndsWith("/"))
            {
                path = path.Substring(0, path.Length - 2);
            }
            if (path.StartsWith("/"))
            {
                path = path.Substring(1);
            }

            Dir currentDir = nodes[0] as Dir;
            foreach (string p in path.Split('/'))
            {
                currentDir = currentDir.getDirectory(p);
            }

            return currentDir;
        }

        public List<Dir> getAllDirectories()
        {
            // define currentDirs - our check if to check if any directories are left to traverse
            List<Dir> currentDirectories = new List<Dir>();
            // all directories will contain all found directories in the end
            List<Dir> allDirectories = new List<Dir>();

            // get the fs root node
            Dir rootNode = nodes[0] as Dir;
            // get all directories from the root naode and store them in currentDirectories
            currentDirectories = rootNode.getAllDirectories();
            
            // loop as long as currentdirectories isnt 0
            while (currentDirectories.Count > 0)
            {
                // add the current directories to the alldirectories variable for return value
                allDirectories.AddRange(currentDirectories);
                // yet another list to store all directories found in the current directory level
                List<Dir> loopDirectories = new List<Dir>();
                // get all directories from the directories currently found
                foreach(Dir c in currentDirectories)
                {
                    loopDirectories.AddRange(c.getAllDirectories());
                }
                // overwrite currentdirectories with the directories found in the subdirectories
                currentDirectories = loopDirectories;
            }
            return allDirectories;
        }
    }
}
