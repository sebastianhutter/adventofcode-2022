namespace Elf {
    class Member{
        private List<int> packedCalories;
        private int totalCalories;

        public Member(List<int> pc) {
            packedCalories = pc;
            totalCalories = packedCalories.Sum();
        }

        public int getTotalCalories() {
            return totalCalories;
        }
    }
}