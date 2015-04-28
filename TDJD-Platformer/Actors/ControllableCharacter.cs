using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TDJD_Platformer.Interfaces;
using IDrawable = TDJD_Platformer.Interfaces.IDrawable;

namespace TDJD_Platformer.Actors
{
    public class ControllableCharacter : Actor, ICollidable, IDrawable
    {
        public Texture2D Texture { get; protected set; }
        public Collider Collider { get; protected set; }
        public float WalkSpeed { get; set; }

        public ControllableCharacter(float x, float y) : base(x, y) { }

        public void Load(ContentManager contentManager, string filePath)
        {
            WalkSpeed = 100f;
            Texture = contentManager.Load<Texture2D>(filePath);
            Collider = new Collider(Collisions.CreateRectangle(Position.X, Position.Y, Texture));
        }
        
        public override void Update()
        {
            // TO DO: Adicionem aqui um sitema de movimentos para Platformer.
            // as colisões já funcionam, por isso agora falta mesmo sistema 
            // de movimento. Também podem aproveitar para adicionar a gravidade
            // Eu já defini uma variável global em Platformer.cs que dá um valor
            // à gravidade. Podem mexer com o valor até parecer mais ou menos correcto,
            // é uma questão de somar a gravidade ao Y, constantemente.

            // Outra coisa que seria interessante era também deixar as keys personalizáveis,
            // para poder mudar as keybindings. Mas não é super importante.

            if (Keyboard.GetState().IsKeyDown(Keys.S)) {
                Position = new Vector2(Position.X, Position.Y + WalkSpeed * World.DeltaTime);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W)) {
                Position = new Vector2(Position.X, Position.Y - WalkSpeed * World.DeltaTime);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                Position = new Vector2(Position.X - WalkSpeed * World.DeltaTime, Position.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)) {
                Position = new Vector2(Position.X + WalkSpeed * World.DeltaTime, Position.Y);
            }

            // Um exemplo de detecção de colisões.
            // Verifica-se se há colisões com a nova posição,
            // se houver, reverte-se para a posição antiga.
            Collider.Update(this);
            if (Collider.GetCollisions()) {
                Console.WriteLine(this + " collided with something!");
                Collider.RevertPosition(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
