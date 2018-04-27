using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace graphproject
{
    internal class Vert : Transformable, Drawable
    {
        private readonly CircleShape circleShape;
        private readonly Text text;
        private readonly int number;

        public Vert(CircleShape circle, Text text, Vector2f position, int number)
        {
            circleShape = circle;
            Position = position;
            this.number = number;
            this.text = text;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            circleShape.Position = Position;
            text.DisplayedString = number.ToString();
            text.Origin = new Vector2f(text.GetLocalBounds().Width/2.0f, text.GetLocalBounds().Height / 2.0f);
            text.Position = Position;

            target.Draw(circleShape, states);
            target.Draw(text, states);
        }
    }
}
