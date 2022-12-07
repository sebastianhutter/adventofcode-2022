namespace Filesystem {
    public class Node {
        //protected string? parentNode { get; set; }
        protected string? name { get; set; }
        protected int size { get; set; } = 0;
        
        public string getName()
        {
            if (name == null)
            {
                throw new ArgumentNullException("name not set");
            }

            return name;
        }

        public int getSize()
        {
            return size;
        }

    }

    public class Dir : Node
    {
        List<Node> contents;
        public Dir(string n) {
            contents = new List<Node>();
            //parentNode = null;
            name = n;
        }

        public void addDirectory(string n) {
            contents.Add(new Dir(n));
        }

        public void addFile(string n, int s) {
            contents.Add(new File(n, s));
        }

        public Dir getDirectory(string n)
        {
            Node d = contents.Find(c => c.getName() == n && c.GetType() == typeof(Filesystem.Dir));
            return d as Dir;
        }

        public List<Dir> getAllDirectories()
        {
            List<Node> ln = new List<Node>();
            ln = contents.FindAll(c => c.GetType() == typeof(Filesystem.Dir));

            List<Dir> ld = new List<Dir>();
            foreach (Node l in ln)
            {
                ld.Add(l as Dir);
            }

            return ld;
        }
        public void calculateDirSize()
        {
            size = contents.Sum(c => c.getSize());
        }
    }

    public class File : Node {
        public File(string n, int s) {
            //parentNode = pn;
            name = n;
            size = s;
        }
        
    }
}
