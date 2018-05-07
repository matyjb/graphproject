using System;
using SFML.Graphics;
using SFML.System;

namespace graphproject
{
    class VertsConnectionLine : Transformable, Drawable
    {
        private int valueToP1;
        private int valueToP2;
        private Font font;
        private Vector2f p1;
        private Vector2f p2;
        private float thickness;
        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; }
        public Color TextColor { get; set; }

        public VertsConnectionLine(int valueToP1, int valueToP2, float thickness, Vector2f p1, Vector2f p2, Font font)
        {
            FillColor = Color.White;
            OutlineColor = Color.White;
            TextColor = Color.Red;
            this.font = font;
            this.p1 = p1;
            this.p2 = p2;
            this.thickness = thickness;
            this.valueToP1 = valueToP1;
            this.valueToP2 = valueToP2;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (valueToP1 != valueToP2)
            {
                if (valueToP1 == 0)
                {
                    LineWithArrow l1 = new LineWithArrow(thickness, p1, p2, 2, valueToP2, font){OutlineColor = OutlineColor, FillColor = FillColor, TextColor = TextColor};
                    target.Draw(l1, states);
                    l1.Dispose();
                }
                else if (valueToP2 == 0)
                {
                    LineWithArrow l2 = new LineWithArrow(thickness, p1, p2, 1, valueToP1, font) { OutlineColor = OutlineColor, FillColor = FillColor, TextColor = TextColor };
                    target.Draw(l2, states);
                    l2.Dispose();
                }
                else
                {
                    Vector2f v = p1 - p2;
                    float my = (float)(thickness*3 / Math.Sqrt(1 + v.Y * v.Y / v.X / v.X));
                    Vector2f m = new Vector2f(-(v.Y/v.X)*my,my);
                    LineWithArrow l1 = new LineWithArrow(thickness, p1 + m, p2 + m, 1, valueToP1, font) { OutlineColor = OutlineColor, FillColor = FillColor, TextColor = TextColor };
                    target.Draw(l1, states);
                    l1.Dispose();
                    LineWithArrow l2 = new LineWithArrow(thickness, p1 - m, p2 - m, 2, valueToP2, font) { OutlineColor = OutlineColor, FillColor = FillColor, TextColor = TextColor };
                    target.Draw(l2, states);
                    l2.Dispose();
                }
            }
            else
            {
                if (valueToP1 != 0)
                {
                    LineWithArrow l1 = new LineWithArrow(thickness, p1, p2, 0, valueToP1, font) { OutlineColor = OutlineColor, FillColor = FillColor, TextColor = TextColor };
                    target.Draw(l1, states);
                    l1.Dispose();
                }
            }
        }
    }
}
