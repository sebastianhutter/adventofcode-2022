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

        public string getParentNameOfNode(string name) {
            return nodes.First(n => n.getNodeName() == name).getParentNodeName();
        }


        public string renderTree() {
            string tree = "";

            // foreach(Node n in nodes) {
            //     if 
            // }

            return tree;
        }
    }
}
