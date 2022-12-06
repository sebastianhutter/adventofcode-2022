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

        public void moveCrates(int count, int sourceStackId, int destStackId) {
            List<char> crates = stacks[sourceStackId-1].getCratesFromTop(count);
            stacks[sourceStackId-1].removeCratesFromTop(count);
            foreach(char c in crates) {
                stacks[destStackId-1].stackCrate(c);
            }
        }

        public string returnAllCrates() {
            string tc = "";
            int stackId = 1;
            foreach(Stack s in stacks) {
                tc = tc + $"{stackId}: ";
                foreach (char c in s.getCrates()) {
                    tc = tc + $" {c}";
                }
                //tc = tc + s.getTopCrate();
                tc = tc + "\n";
                stackId += 1;
            }

            return tc;
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
