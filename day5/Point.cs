namespace day5
{
    class Point
    {
        private int x;
        private int y;

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int GetX() {
            return x;
        }

        public int GetY() {
            return y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }
            return Equals(obj as Point);
        }

        public bool Equals(Point obj) {
            return obj.GetX() == this.GetX() && obj.GetY() == this.GetY();
        }
    }
}