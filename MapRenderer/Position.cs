using Artemis;

namespace MapRenderer
{
    [Artemis.Attributes.ArtemisComponentPool(
        InitialSize = 5,
        IsResizable = true,
        ResizeSize = 20,
        IsSupportMultiThread = false)]
    public class Position : ComponentPoolable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position() { }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Cleanup()
        {
            X = 0;
            Y = 0;
        }
    }
}
