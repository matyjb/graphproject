using SFML.Graphics;
using SFML.System;

namespace graphproject
{
    class LineWithArrow : Line
    {
        private readonly int direction;
        private Text text;
        //0-bez kierunku, 1 do p1, 2 do p2
        public LineWithArrow(float thickness, Vector2f p1, Vector2f p2, int direction, int value, Font font) : base(thickness, p1, p2)
        {
            if (direction >= 0 && direction <= 2)
            {
                this.direction = direction;
            }
            else
            {
                this.direction = 0;
            }
            text = new Text(value.ToString(), font);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            float triangleSizeM = 4.5f;
            if (text.DisplayedString != "0")
            {
                base.Draw(target, states);
                if (direction != 0)
                {
                    CircleShape triangle = new CircleShape(Size.Y * triangleSizeM, 3)
                    {
                        Origin = new Vector2f(Size.Y * triangleSizeM, Size.Y * triangleSizeM),
                        Position = Position - (Position - p2) / 5 * (direction == 1 ? 2 : 3),
                        Rotation = direction == 1 ? -90 + Rotation : 90 + Rotation,
                        OutlineColor = Color.White,
                        OutlineThickness = Size.Y / 2,
                        FillColor = Color.Black,
                    };

                    target.Draw(triangle, states);
                    triangle.Dispose();
                    text.Position = Position - (Position - p2) / 5 * (direction == 1 ? 2 : 3);
                }
                else
                {
                    text.Position = Position - (Position - p2) / 2;

                }
            text.Origin = new Vector2f(text.GetLocalBounds().Width / 2f, text.GetLocalBounds().Height / 2f);
            text.CharacterSize = (uint)Size.Y * 5;
            text.Color = Color.Red;
            target.Draw(text, states);
            text.Dispose();
            }
        }
    }
}
