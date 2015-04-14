using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer {
    public class Actor
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }

        public virtual void Update(float deltaTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
