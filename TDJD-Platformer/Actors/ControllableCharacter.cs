using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TDJD_Platformer.Actors
{
    public class ControllableCharacter : Character
    {
        public ControllableCharacter(float x, float y) : base(x, y) { }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                Position = new Vector2(Position.X - Velocity.X * World.DeltaTime, Position.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                Position = new Vector2(Position.X + Velocity.X * World.DeltaTime, Position.Y);
            }

            base.Update();
        }
    }
}
