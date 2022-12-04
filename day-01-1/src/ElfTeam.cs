
namespace Elf {
    class Team {
        private List<Member> elfes;

        public Team() {
            elfes = new List<Member>();
        }

        public void addMember(Member e) {
            elfes.Add(e);
        }

        public (int, int) getMemberWithHighestCaloriesCount() {
            int lastHighestCaloriesCount = 0;
            int indexOfElfeWithHighestCaloriesCount = -1;
            for (int i = 0; i < elfes.Count(); i++) {
                if (elfes[i].getTotalCalories() > lastHighestCaloriesCount) {
                    lastHighestCaloriesCount = elfes[i].getTotalCalories();
                    indexOfElfeWithHighestCaloriesCount = i;
                }
            }
            return (indexOfElfeWithHighestCaloriesCount, lastHighestCaloriesCount);
        }
    }
}