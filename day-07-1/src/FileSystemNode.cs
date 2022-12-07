namespace Filesystem {
    public class Node {
        protected string parentNode { get; set; }
        protected bool isADir { get; set; }
        protected string name { get; set; }

        public string getParentNodeName() {
            return parentNode;
        }

        public string getNodeName() {
            return name;
        }

    }

    public class Dir : Node {

        List<Node> contents;
        public Dir(string n) {
            contents = new List<Node>();
            parentNode = null;
            isADir = true;
            name = n;
        }

        public Dir(string pn, string n) {
            contents = new List<Node>();
            parentNode = pn;
            isADir = true;
            name = n;
        }
    }

    public class File : Node {
        protected int size { get; set; }
        public File(string pn, string n, int s) {
            parentNode = pn;
            isADir = false;
            name = n;
            size = s;
        }
    }
}
