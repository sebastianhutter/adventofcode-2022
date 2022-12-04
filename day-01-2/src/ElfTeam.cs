
namespace Elf {
    class Team {
        private List<Member> elfes;

        public Team() {
            elfes = new List<Member>();
        }

        public void addMember(Member e) {
            elfes.Add(e);
        }

        public List<Member> getElfesWithTheHighestCaloriesCount(int i) {
            return elfes.OrderByDescending(e=>e.getTotalCalories()).Take(i).ToList();
        }
    }
}
