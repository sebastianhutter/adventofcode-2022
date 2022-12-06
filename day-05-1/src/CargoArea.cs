namespace Cargo {
    public class Area {
        protected List<Stack> stacks {get; set;}

        public Area() {
            stacks = new List<Stack>();
        }

        public void addStack(Stack s) {
            stacks.Add(s);
        }

        public void moveCrate(int sourceStackId, int destStackId) {
            char crate = stacks[sourceStackId-1].getTopCrate();
            stacks[sourceStackId-1].removeTopCrate();
            stacks[destStackId-1].stackCrate(crate);
        }

        public string returnAllTopCrates() {
            string tc = "";
            foreach(Stack s in stacks) {
                tc = tc + s.getTopCrate();
            }

            return tc;
        }

    }
}
