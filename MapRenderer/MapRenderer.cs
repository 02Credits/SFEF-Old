using Artemis;
using Artemis.System;
using Extensions.Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Interop.Modules;

namespace MapRenderer
{
    public class MapRenderer : BaseGameModule
    {
        EntityWorld world;
        public MapRenderer()
          : base("Content") {}

        public override void Initialize()
        {
            world = new EntityWorld();

            EntitySystem.BlackBoard.SetEntry(Constants.ContentManager, this.Content);
            EntitySystem.BlackBoard.SetEntry(Constants.GraphicsDevice, this.GraphicsDevice);
            EntitySystem.BlackBoard.SetEntry(Constants.SpriteBatch, new SpriteBatch(GraphicsDevice));

            world.InitializeAll(System.Reflection.Assembly.GetExecutingAssembly());

            var testEntity = world.CreateEntity();
            testEntity.AddComponentFromPool<Textured, Position, Dimensions>((textured, position, dimensions) =>
            {
                textured.Path = "GrassTile1";
                position.X = 0;
                position.Y = 0;
                dimensions.Width = 500;
                dimensions.Height = 500;
            });
        }

        public override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var spriteBatch = EntitySystem.BlackBoard.GetEntry<SpriteBatch, Constants>(Constants.SpriteBatch);

            spriteBatch.Begin();
            world.Draw();
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            world.Update();
        }
    }
}
