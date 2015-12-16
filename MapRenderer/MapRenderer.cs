using Microsoft.Xna.Framework;
using MonoGame.Interop.Modules;

namespace MapRenderer
{
    public class MapRenderer : BaseGameModule
    {

        public MapRenderer()
          : base("Content")
        { }

        public override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
