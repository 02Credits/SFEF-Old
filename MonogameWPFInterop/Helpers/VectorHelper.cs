using Microsoft.Xna.Framework;

namespace MonoGame.Interop.Helpers
{
    internal static class VectorHelper
    {
        public static Vector2 ToVector(this System.Windows.Point point) => new Vector2((float)point.X, (float)point.Y);
    }
}