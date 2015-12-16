using Microsoft.Xna.Framework;
using MonoGame.Interop.Modules;

namespace CharacterRenderer
{
    public class CharacterRenderer : BaseGameModule
    {
        public CharacterRenderer()
            : base("Content")
        { }

        public override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
