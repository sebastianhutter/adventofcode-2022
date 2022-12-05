namespace Game {
    public class Move {
        //protected List<string> Code { get; set; }
        protected string Name { get; set; } = null!;
        protected int Points { get; set; }

        public string getName() {
            return Name;
        }

        public int getPoints() {
            return Points;
        }
    }

    public class Rock : Move {
        public Rock() {
            // Code = new List<string>();
            // Code.Add("A");
            // Code.Add("X");
            Name = "Rock";
            Points = 1;
        }
    }

    public class Paper : Move {
        public Paper() {
            // Code = new List<string>();
            // Code.Add("B");
            // Code.Add("Y");
            Name = "Paper";
            Points = 2;
        }
    }

    public class Scissors : Move {
        public Scissors() {
            // Code = new List<string>();
            // Code.Add("C");
            // Code.Add("Z");
            Name = "Scissors";
            Points = 3;
        }
    }

}
