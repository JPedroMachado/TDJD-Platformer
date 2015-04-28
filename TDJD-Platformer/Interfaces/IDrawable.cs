using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDJD_Platformer.Interfaces
{
    interface IDrawable
    {
        Vector2 Position { get; }
        Texture2D Texture { get; }
        void Draw(SpriteBatch spriteBatch);
    }
}
