using Artemis;

namespace MapRenderer
{
    [Artemis.Attributes.ArtemisComponentPool(
        InitialSize = 5,
        IsResizable = true,
        ResizeSize = 20,
        IsSupportMultiThread = false)]
    class Dimensions : ComponentPoolable
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Dimensions() { }
        public Dimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Cleanup()
        {
            Width = 0;
            Height = 0;
        }
    }
}
