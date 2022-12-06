namespace Area {
    public class Section {
        protected List<int> sectionA { get; set; }
        protected List<int> sectionB { get; set; }

        public Section(List<int> a, List<int> b) {
            sectionA = a;
            sectionB = b;
        } 

        public bool doPairsFullyContainEachOther() {
            // check if the sections are contained in either
            // of them
            return sectionA.All(v => sectionB.Contains(v)) | sectionB.All(v => sectionA.Contains(v));
        }

        public bool doPairsOverlap() {
            // check if the given section pairs partially overlap
            foreach (int s1 in sectionA) {
                foreach(int s2 in sectionB) {
                    if (s1 == s2) {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
