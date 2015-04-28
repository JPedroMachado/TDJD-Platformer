using Microsoft.Xna.Framework;

namespace TDJD_Platformer
{
    public abstract class Actor : IFocusable
    {
        public Vector2 Position { get; set; }
        public bool Alive { get; set; }

        protected Actor(float x, float y)
        {
            Position = new Vector2(x, y);
            World.Actors.Add(this);
        }

        public abstract void Update();
    }
}
