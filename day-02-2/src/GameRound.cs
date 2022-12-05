namespace Game {
    class Round {
        protected Move moveOpponent { get; set; }
        protected Move moveSelf  { get; set; }
        protected bool roundIsWon { get; set; }
        protected bool roundIsDraw { get; set; }
        protected int roundPoints { get; set; }

        public Round(string mo, string state) {
            moveOpponent = describeOpponentMove(mo);
            moveSelf = describeMyMove(state);

            (bool won, bool draw) r = setRoundWonOrDraw();
            roundIsWon = r.won;
            roundIsDraw = r.draw;

            roundPoints = calculateRoundPoints();
        }

        private Move describeOpponentMove(string move) {
            Move m;
            switch(move) {
                case "A":
                    m = new Rock();
                    break;
                case "B":
                    m = new Paper();
                    break;
                case "C":
                    m = new Scissors();
                    break;
                default:
                    throw new ArgumentException($"Invalid argument {move}");
                    break;
            }
            return m;
        }

        private Move describeMyMove(string state) {
            // depending on the state and the opponents move we need
            // to figure out what our move is

            Move m;

            if (state == "X") {
                return getMoveForLoose(moveOpponent.getName());
            }
            if (state == "Y") {
                return getMoveForDraw(moveOpponent.getName());
            }
            if (state == "Z") {
                return getMoveForWin(moveOpponent.getName());
            }

            throw new ArgumentException($"Invalid state {state}");

        }

        private Move getMoveForLoose(string move) {
            Move m;
            switch(move) {
                case "Rock":
                    m = new Scissors();
                    break;
                case "Paper":
                    m = new Rock();
                    break;
                case "Scissors":
                    m = new Paper();
                    break;
                default:
                    throw new ArgumentException($"Invalid argument {move}");
                    break;
            }
            return m;
        }

        private Move getMoveForDraw(string move) {
            Move m;
            switch(move) {
                case "Rock":
                    m = new Rock();
                    break;
                case "Paper":
                    m = new Paper();
                    break;
                case "Scissors":
                    m = new Scissors();
                    break;
                default:
                    throw new ArgumentException($"Invalid argument {move}");
                    break;
            }
            return m;
        }

        private Move getMoveForWin(string move) {
            Move m;
            switch(move) {
                case "Rock":
                    m = new Paper();
                    break;
                case "Paper":
                    m = new Scissors();
                    break;
                case "Scissors":
                    m = new Rock();
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
