namespace Game {
    class Round {
        protected Move moveOpponent { get; set; }
        protected Move moveSelf  { get; set; }
        protected bool roundIsWon { get; set; }
        protected bool roundIsDraw { get; set; }
        protected int roundPoints { get; set; }

        public Round(string mo, string ms) {
            moveOpponent = describeMove(mo);
            moveSelf = describeMove(ms);

            (bool won, bool draw) r = setRoundWonOrDraw();
            roundIsWon = r.won;
            roundIsDraw = r.draw;

            roundPoints = calculateRoundPoints();
        }

        private Move describeMove(string move) {
            Move m;
            switch(move) {
            
                case "A":
                case "X":
                    m = new Rock();
                    break;
                case "B":
                case "Y":
                    m = new Paper();
                    break;
                case "C":
                case "Z":
                    m = new Scissors();
                    break;
                default:
                    throw new ArgumentException($"Invalid argument {move}");
                    break;
            }
            return m;
        }

        private (bool, bool) setRoundWonOrDraw() {
            bool w = false;
            bool d = false;

            if (moveOpponent.getName() == moveSelf.getName()) {
                w = false;
                d = true;
            }
            if ((moveOpponent.getName() == "Rock") && (moveSelf.getName() == "Paper") ){
                w = true;
                d = false;
            }
            if ((moveOpponent.getName() == "Rock") && (moveSelf.getName() == "Scissors")) {
                w = false;
                d = false;
            }
            if ((moveOpponent.getName() == "Paper") && (moveSelf.getName() == "Rock")) {
                w = false;
                d = false;
            }
            if ((moveOpponent.getName() == "Paper") && (moveSelf.getName() == "Scissors")) {
                w = true;
                d = false;
            }
            if ((moveOpponent.getName() == "Scissors") && (moveSelf.getName() == "Rock")) {
                w = true;
                d = false;
            }
            if ((moveOpponent.getName() == "Scissors") && (moveSelf.getName() == "Paper")) {
                w = false;
                d = false;
            }

            return (w, d);
        }

        private int calculateRoundPoints() {
            int p = moveSelf.getPoints();
            if (roundIsDraw) {
                p += 3;
            }
            if (roundIsWon) {
                p += 6;
            }
            return p;
        }

        public int getRoundPoints() {
            return roundPoints;
        }
    }
}
