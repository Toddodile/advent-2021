using System;

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

        public Point(string position) {
            string[] coordinates = position.Split(",");
            x = Convert.ToInt32(coordinates[0]);
            y = Convert.ToInt32(coordinates[1]);
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

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }
}