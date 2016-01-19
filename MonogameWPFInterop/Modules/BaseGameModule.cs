using System;
using System.Windows.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Interop.Arguments;
using MonoGame.Interop.Controls;
using MonoGame.Interop.Services;
using System.ComponentModel.Design;

namespace MonoGame.Interop.Modules
{
    public abstract class BaseGameModule : IGameModule, IInternalGameModule
    {
        private readonly string contentDirectory;
        private GameUpdater updater;
        private DrawingSurface drawingSurface;

        protected BaseGameModule(string contentDirectory)
        {
            this.contentDirectory = contentDirectory;
        }

        protected GraphicsDevice GraphicsDevice { get; private set; }
        protected SpriteBatch SpriteBatch { get; private set; }
        protected ContentManager Content { get; private set; }
        public double Width
        {
            get { return drawingSurface.ActualWidth; }
            set { drawingSurface.Width = value; }
        }
        public double Height
        {
            get { return drawingSurface.ActualHeight; }
            set { drawingSurface.Height = value; }
        }
        bool IInternalGameModule.IsRunning => updater.IsRunning;

        void IInternalGameModule.Prepare(DrawingSurface drawingSurface, IServiceProvider provider)
        {

            this.drawingSurface = drawingSurface;
            GraphicsDevice = drawingSurface.GraphicsDevice;
            SpriteBatch = new SpriteBatch((GraphicsDevice)provider.GetService(typeof(GraphicsDevice)));
            Content = new ContentManager(provider, contentDirectory);
            updater = new GameUpdater(Update, drawingSurface.Invalidate);
        }
        void IInternalGameModule.Run()
        {
            updater.Start();
        }
        void IInternalGameModule.Draw(DrawEventArgs e)
        {
            Draw();
            updater.Drawing = false;
        }
        void IInternalGameModule.Stop()
        {
            updater.Stop();
        }

        public virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw() { }

        // events
        public virtual void OnMouseMove(GameMouseEventArgs e) { }
        public virtual void OnMouseDown(GameMouseButtonEventArgs e) { }
        public virtual void OnKeyDown(KeyEventArgs e) { }
    }
}
