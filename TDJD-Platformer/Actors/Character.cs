using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using TDJD_Platformer.Interfaces;

namespace TDJD_Platformer.Actors
{
    public class Character : Sprite, IDynamic, ICollidable
    {
        public float GravityAcceleration { get; set; }
        public float MaxGravityAcceleration { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public Collider Collider { get; protected set; }

        public Character(float x, float y) : base(x, y) {}

        public override void Update()
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y + GravityAcceleration);
            Position = new Vector2(Position.X, Position.Y + Velocity.Y);

            // Um exemplo de detecção de colisões.
            // Verifica-se se há colisões com a nova posição,
            // se houver, reverte-se para a posição antiga.
            Collider.Update(this);
            if (Collider.GetCollisions()) {
                Console.WriteLine(this + " collided with something!");
                Collider.RevertPosition(this);
            }
        }

        public override void Load(ContentManager contentManager, string filePath)
        {
            base.Load(contentManager, filePath);
            MaxGravityAcceleration = 150f;
            Velocity = new Vector2(100f, 0);
            Collider = new Collider(Collisions.CreateRectangle(Position.X, Position.Y, Texture));
        }
    }
}
