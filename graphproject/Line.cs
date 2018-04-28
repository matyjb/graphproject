using SFML.Graphics;
using SFML.System;
using System;

namespace graphproject
{
    class Line : Transformable, Drawable
    {
        public Vector2f Size { get; set; }

        public Line(float thickness, Vector2f p1, Vector2f p2)
        {
            Vector2f v = p1 - p2;
            float length = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            Size = new Vector2f(length, thickness);
            float angle;
            if (v.X != 0)
            {
                angle = (float) (Math.Atan(v.Y / v.X) * (180 / Math.PI));
                if (v.X > 0) angle -= 180;
            }
            else
            {
                if (v.Y > 0) angle = -90;
                else if(v.Y < 0) angle = 90;
                else angle = 0;
            }
            Rotation = angle;
            Position = p1;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            RectangleShape rect = new RectangleShape(Size)
            {
                Origin = new Vector2f(0, Size.Y/2),
                Rotation = Rotation,
                Position = Position
            };
            target.Draw(rect,states);
            rect.Dispose();
        }
    }
}
