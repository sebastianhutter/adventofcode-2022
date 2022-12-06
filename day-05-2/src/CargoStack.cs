namespace Cargo {
    public class Stack {
        List<char> crates;

        public Stack(List<char> c) {
            crates = c;
        }

        public List<char> getCrates() {
            return crates;
        }

        public char getTopCrate() {
            return crates.Last();
        }

        public List<char> getCratesFromTop(int count) {
            return crates.TakeLast(count).ToList();
        }

        public void removeCratesFromTop(int count) {
            for(int i=0; i<count; i++) {
                removeTopCrate();
            }
        }

        public void removeTopCrate() {
            crates.RemoveAt(crates.Count - 1);
        }

        public void stackCrate(char c) {
            crates.Add(c);
        }
    }
}
