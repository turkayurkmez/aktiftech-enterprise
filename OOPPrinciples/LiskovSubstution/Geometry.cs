namespace LiskovSubstution
{
    public class Geometry
    {
        public IGetArea GetRectangle(int unit1, int unit2 = 1)
        {
            //....
            return unit2 > 1 ? new Rectangle { Width = unit1, Height = unit2 } :
                               new Square { Edge = unit1 };
        }
    }

    public interface IGetArea
    {
        int GetArea();
    }
    public class Rectangle : IGetArea
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea() => Width * Height;
    }

    public class Square : IGetArea //: Rectangle
    {
        //public override int Width { get => base.Width; set { base.Width = value; base.Height = value; } }
        //public override int Height { get => base.Width; set { base.Width = value; base.Height = value; } }

        public int Edge { get; set; }
        public int GetArea()
        {
            return Edge * Edge;
        }
    }
}
