using Microsoft.Xna.Framework;
using MonoGame.Interop.Modules;
using System;

namespace MapRenderer
{
    public class MapRenderer : BaseGameModule
    {
        Random rand;

        public MapRenderer()
          : base("Content")
        {
            rand = new Random();
        }

        public override void Draw()
        {
            GraphicsDevice.Clear(new Color(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)));
        }
    }
}
