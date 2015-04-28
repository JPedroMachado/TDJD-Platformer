using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = TDJD_Platformer.Interfaces.IDrawable;

namespace TDJD_Platformer.Actors
{
    public class Sprite : Actor, IDrawable
    {
        public Sprite(float x, float y) : base(x, y) {}
        public Texture2D Texture { get; set; }

        public virtual void Load(ContentManager contentManager, string filePath)
        {
            Texture = contentManager.Load<Texture2D>(filePath);
        }

        public override void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);            
        }
    }
}
