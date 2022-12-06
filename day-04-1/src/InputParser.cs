using System;


namespace Input {
    class Parser {
        private string file;
        private List<(List<int>, List<int>)> areas;

        public Parser(string f) {
            file = f;
            
            areas = new List<(List<int>, List<int>)>();

            foreach (string l in System.IO.File.ReadAllLines(@file)) {
                // split string and convert the areas to integers to be used as start and end 
                // to create lists with all area ids.
                String[] a = l.Split(',');

                int[] a1 = a[0].Split('-').Select(Int32.Parse).ToArray();
                int[] a2 = a[1].Split('-').Select(Int32.Parse).ToArray();

                List<int> ap1 = new List<int>();
                List<int> ap2 = new List<int>();
                for ( int i = a1[0]; i <= a1[1]; i++ ) {
                    ap1.Add(i);
                }
                for ( int i = a2[0]; i <= a2[1]; i++ ) {
                    ap2.Add(i);
                }

                areas.Add((ap1, ap2));
            }
        }

        public List<(List<int>, List<int>)> getAreas() {
            return areas;
        }

    }
}
