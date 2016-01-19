using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Artemis;
using Artemis.System;
using Artemis.Attributes;
using Extensions.Artemis;
using Artemis.Manager;

namespace MapRenderer
{
    [Artemis.Attributes.ArtemisEntitySystem(ExecutionType = ExecutionType.Synchronous,
                                            GameLoopType = GameLoopType.Update,
                                            Layer = 0)]
    public class TextureManager : EntityProcessingSystem
    {
        public Dictionary<string, Texture2D> Textures { get; }

        public TextureManager()
            : base(Aspect.All(typeof(Textured)))
        {
            Textures = new Dictionary<string, Texture2D>();
            BlackBoard.SetEntry(Constants.TextureManager, this);
        }

        public Texture2D LoadTexturesIfNeeded(string path)
        {
            var contentManager = EntitySystem.BlackBoard.GetEntry<ContentManager, Constants>(Constants.ContentManager);
            Texture2D texture;
            if (!Textures.ContainsKey(path))
            {
                texture = contentManager.Load<Texture2D>(path);
                Textures[path] = texture;
            }
            else
            {
                texture = Textures[path];
            }
            return texture;
        }

        public override void Process(Entity entity)
        {
            Textured textured = entity.GetComponent<Textured>();
            LoadTexturesIfNeeded(textured.Path);
        }
    }
}
