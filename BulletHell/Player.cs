using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class Player : IEntity
    {
        public Player(Texture2D image, Point location)
        {
            myBox = new Rectangle(location, new Point(100, 100));
            CollisionBehavior = new PlayerCollisionBehavior(this);
            this.image = image;
            prev = location;
        }

        private Point prev;

        public Texture2D image { get; set; }

        private Rectangle myBox;


        public Rectangle HitBox { get { return myBox; } set { myBox = value; } }

        public ICollisionBehavior CollisionBehavior { get; set; }

        public bool isExpired { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(image, HitBox, Color.White);
            //spriteBatch.Draw(image, null, HitBox, null, null, 0f, null, Color.White, SpriteEffects.None, 0f);
            spriteBatch.Draw(image, HitBox, null, Color.White,0f, new Vector2(0,0), SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            int speed = 1;
            Point toAdd = new Point(0, 0);
            KeyboardState state = Keyboard.GetState();

            GamePadState padState = GamePad.GetState(PlayerIndex.One);


            Vector2 vec = padState.ThumbSticks.Left;
            
            if(vec.Length() > 0.25f)
            {
                float len = vec.Length();
                vec.Normalize();
                vec = Vector2.Multiply(vec, new Vector2(1, -1));
                toAdd = toAdd + (vec * 15*len).ToPoint();
            }
            //toAdd = toAdd + (vec*5).ToPoint();


            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up))
            {
                toAdd = toAdd + new Point(0, -speed);
            }
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down))
            {
                toAdd = toAdd + new Point(0, speed);
            }
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left))
            {
                toAdd = toAdd + new Point(-speed, 0);
            }
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
                toAdd = toAdd + new Point(speed, 0);
            }

            myBox.Location = myBox.Location + toAdd;

        }
    }
}
