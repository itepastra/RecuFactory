using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuFactory
{
    internal class Player : Entity
    {
        internal Player(Point position) : base(position) { }

        internal Player(Point position, Texture2D texture) : base(position, texture) { }
    }
}
