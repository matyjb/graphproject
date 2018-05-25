using SFML.Graphics;
using SFML.System;

namespace graphproject
{
    internal class Vert : Transformable, Drawable
    {
        private readonly int number;
        private readonly Font font;
        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; }
        public Color TextColor { get; set; }
        public bool Selected { get; set; }
        public bool IsSink { get; set; }
        public bool IsSource { get; set; }

        public Vert(Font font, Vector2f position, int number)
        {
            Position = position;
            this.number = number;
            this.font = font;
            FillColor = Color.Black;
            OutlineColor = Color.White;
            TextColor = Color.White;
            Selected = false;
            IsSink = false;
            IsSource = false;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Text text = new Text("0", font);
            CircleShape circle = new CircleShape(20)
            {
                Origin = new Vector2f(20, 20),
                OutlineThickness = 4,
                FillColor = FillColor,
                OutlineColor = IsSink ? Color.Red : IsSource ? Color.Green : Selected ? Color.Yellow : OutlineColor //XD
            };
            circle.Position = Position;
            text.DisplayedString = number.ToString();
            text.Origin = new Vector2f(text.GetLocalBounds().Width/1.6f, text.GetLocalBounds().Height / 1.15f);
            text.Position = Position;
            text.Color = circle.OutlineColor;

            target.Draw(circle, states);
            target.Draw(text, states);

            circle.Dispose();
            text.Dispose();
        }
    }
}
