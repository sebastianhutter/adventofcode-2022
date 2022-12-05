using Rucksack;

namespace Elves {
    class Group {
        private List<RucksackContent> rucksacks;
        private char groupBadge;

        public Group(List<RucksackContent> r) {
            rucksacks = r;
            groupBadge = findGroupBadge();
        }

        private char findGroupBadge() {
            char[] m1 = rucksacks[0].getAllItems();
            char[] m2 = rucksacks[1].getAllItems();
            char[] m3 = rucksacks[2].getAllItems();    

            for (int i = 0; i < m1.Length; i++) {
                for (int j = 0; j < m2.Length; j++ ) {
                    for (int k = 0; k < m3.Length; k++ ) {
                        if ((m1[i] == m2[j]) && (m1[i] == m3[k]))
                            return m3[k];
                    }
                }
            }
            return new char();
        }

        public char getGroupBadge() {
            return groupBadge;
        }
    }
}
