using Input;
using Area;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {

            Parser parser = new Parser("../input.txt");

            List<Section> sections = new List<Section>();
            foreach((List<int> a, List<int> b) areas in parser.getAreas()) {
                sections.Add(new Section(areas.a, areas.b));
            }
            
            int sectionOverlapSum = sections.Count(s => s.doPairsOverlap());
            Console.WriteLine(sectionOverlapSum);
        }
    }
}
