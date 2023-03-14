using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuFactory
{
    interface IPositioned
    {
        Point Position { get; protected set; }
    }
}
