using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TDJD_Platformer
{
    public class Collider
    {
        public Rectangle Rectangle { get; protected set; }
        public List<Collider> ActiveCollisions { get; protected set; }
        public bool IsColliding { get; protected set; }
        public Vector2 LastPosition { get; protected set; }
        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set
            {
                LastPosition = new Vector2(position.X, position.Y);
                position = value;
                Rectangle = new Rectangle((int)Math.Round(value.X), (int)Math.Round(value.Y), Rectangle.Width, Rectangle.Height);
            }
        }

        public Collider(Rectangle rectangle)
        {
            position = new Vector2(rectangle.X, rectangle.Y);
            LastPosition = position;
            Rectangle = rectangle;
            Collisions.Colliders.Add(this);
            ActiveCollisions = new List<Collider>();
        }

        /// <summary>
        /// Update Collider in relation to parent Actor.
        /// </summary>
        /// <param name="actor">Parent Actor</param>
        public void Update(Actor actor)
        {
            Position = actor.Position;
        }

        public void RevertPosition(Actor actor)
        {
            Position = LastPosition;
            actor.Position = Position;
        }

        /// <summary>
        /// Iterates through all collisions and adds them to a list.
        /// </summary>
        /// <returns>Returns whether there's any collision.</returns>
        public bool GetCollisions()
        {
            int count = 0;
            ActiveCollisions.Clear();

            foreach (var collider in Collisions.Colliders) {
                if (this.IsColliding(collider) && collider != this) {
                    ActiveCollisions.Add(collider);
                    count++;
                }
            }

            IsColliding = count > 0;
            return IsColliding;
        }
    }
}
