namespace Rucksack {
    class RucksackContent {
        protected char[] compartmentOne { get; set; }
        protected char[] compartmentTwo { get; set; }

        protected char wrongItem { get; set; }

        public RucksackContent(string c1, string c2) {
            compartmentOne = fillCompartment(c1);
            compartmentTwo = fillCompartment(c2);

            wrongItem = findWrongItem();
        }

        private char[] fillCompartment(string contents) {
            
            int index = 0;
            char[] comp = new char[contents.Length];
            foreach (char s in contents.OrderBy(c => c)) {
                comp[index] = s;
                index += 1;
            }

            return comp;
        }

        private char findWrongItem() {
            for (int i = 0; i < compartmentOne.Length; i++) {
                for (int j = 0; j < compartmentTwo.Length; j++ ) {
                    if (compartmentOne[i] == compartmentTwo[j]) {
                        return compartmentTwo[j];
                    }
                }
            }
            return new char();
        }

        public char getWrongItem() {
            return wrongItem;
        }

        public char[] getAllItems() {
            char[] all = new char[compartmentOne.Length + compartmentTwo.Length];
            Array.Copy(compartmentOne, all, compartmentOne.Length);
            Array.Copy(compartmentTwo, 0, all, compartmentOne.Length, compartmentTwo.Length);
            return all;
        }

    }
}
