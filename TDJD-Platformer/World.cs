using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TDJD_Platformer.Interfaces;

namespace TDJD_Platformer
{
    public static class World
    {   
        public static float DeltaTime;
        public const float Gravity = 0.98f;
        public static List<Actor> Actors { get; private set; }

        static World()
        {
            Actors = new List<Actor>();
        }

        public static void Update()
        {
            for (int i = Actors.Count - 1; i >= 0; i--) {
                if (!Actors[i].Alive) {
                    ICollidable collidable = Actors[i] as ICollidable;
                    if (collidable != null) Collisions.Colliders.Remove(collidable.Collider);
                    Actors.RemoveAt(i);
                    return;
                }

                Actors[i].HandleGravity();
                Actors[i].Update();
            }
        }

        public static void HandleGravity(this Actor actor)
        {
            IDynamic dynamicObj = actor as IDynamic;
            if (dynamicObj == null) return;

            dynamicObj.GravityAcceleration += Gravity * DeltaTime;
            dynamicObj.GravityAcceleration = MathHelper.Clamp(dynamicObj.GravityAcceleration, 0, dynamicObj.MaxGravityAcceleration);
        }
    }
}
