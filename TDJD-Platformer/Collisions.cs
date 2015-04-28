using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDJD_Platformer
{
    public static class Collisions
    {
        public static List<Collider> Colliders { get; private set; }
        private static Texture2D pointTexture;

        static Collisions()
        {
            Colliders = new List<Collider>();
        }

        public static void Debug(SpriteBatch spriteBatch)
        {
            foreach (var collider in Colliders) {
                collider.Rectangle.DrawRectangle(spriteBatch, collider.IsColliding ? Color.Green : Color.Red);
            }
        }

        /// <summary>
        /// Checks if subject's colliding with target.
        /// </summary>
        /// <param name="collider1">Subject</param>
        /// <param name="collider2">Target</param>
        /// <returns>Returns collision's result.</returns>
        public static bool IsColliding(this Collider collider1, Collider collider2)
        {
            return collider1.Rectangle.Intersects(collider2.Rectangle);
        }

        public static Rectangle CreateRectangle(float x, float y, Texture2D texture)
        {
            return new Rectangle((int)Math.Round(x), (int)Math.Round(y), texture.Width, texture.Height);
        }

        public static Rectangle CreateRectangle(float x, float y, int width, int height)
        {
            return new Rectangle((int)Math.Round(x), (int)Math.Round(y), width, height);
        }

        /// <summary>
        /// Draw a debug rectangle around collider.
        /// </summary>
        /// <param name="rectangle">Target collider's rectangle.</param>
        /// <param name="spriteBatch"></param>
        /// <param name="color"></param>
        /// <param name="lineWidth"></param>
        public static void DrawRectangle(this Rectangle rectangle, SpriteBatch spriteBatch, Color color, int lineWidth = 1)
        {
            if (pointTexture == null) {
                pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                pointTexture.SetData<Color>(new Color[] { Color.White });
            }

            if (lineWidth > 0) {
                spriteBatch.Draw(pointTexture,
                    new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
                spriteBatch.Draw(pointTexture,
                    new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
                spriteBatch.Draw(pointTexture,
                    new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth),
                    color);
                spriteBatch.Draw(pointTexture,
                    new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth),
                    color);
            } else {
                spriteBatch.Draw(pointTexture, rectangle, color);
            }
        }
    }
}
