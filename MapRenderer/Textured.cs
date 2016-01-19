using Artemis;
using System;

namespace MapRenderer
{
    [Artemis.Attributes.ArtemisComponentPool(
        InitialSize = 5,
        IsResizable = true,
        ResizeSize = 20,
        IsSupportMultiThread = false)]
    public class Textured : ComponentPoolable
    {
        public string Path { get; set; }

        public Textured() { }
        public Textured(string path)
        {
            Path = path;
        }

        public void Cleanup()
        {
            Path = String.Empty;
        }
    }
}
