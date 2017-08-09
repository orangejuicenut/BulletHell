using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell
{
    public class Wall : IEntity
    {
        public Wall(Rectangle wallLoc, Texture2D image)
        {
            CollisionBehavior = new WallCollisionBehavior();
            HitBox = wallLoc;
            this.image = image;
        }

        public Texture2D image { get; set; }

        public bool isExpired => false;

        public Rectangle HitBox { get; set; }

        public ICollisionBehavior CollisionBehavior { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, HitBox, Color.White);
        }

        public void Update(GameTime time)
        {
            return;
        }
    }
}