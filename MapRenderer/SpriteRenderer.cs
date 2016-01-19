using Artemis;
using Artemis.Manager;
using Artemis.System;
using Extensions.Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapRenderer
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.Synchronous,
                                            GameLoopType = GameLoopType.Draw,
                                            Layer = 1)]
    public class SpriteRenderer : EntityProcessingSystem
    {
        public SpriteRenderer()
            : base(Aspect.All(typeof(Position), typeof(Dimensions), typeof(Textured)))
        { }

        public override void Process(Entity entity)
        {
            var spriteBatch = BlackBoard.GetEntry<SpriteBatch, Constants>(Constants.SpriteBatch);
            var textureManager = BlackBoard.GetEntry<TextureManager, Constants>(Constants.TextureManager);

            var dimensions = entity.GetComponent<Dimensions>();
            var position = entity.GetComponent<Position>();
            var textured = entity.GetComponent<Textured>();

            var width = dimensions.Width;
            var height = dimensions.Height;
            var texture = textureManager.LoadTexturesIfNeeded(textured.Path);

            spriteBatch.Draw(texture, new Rectangle(position.X, position.Y, width, height), Color.White);
        }
    }
}
