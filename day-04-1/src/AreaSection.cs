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
    }
}
