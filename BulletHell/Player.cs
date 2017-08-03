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
    class Player : IEntity
    {
        public Player()
        {
            HitBox = new BoundingBox(new Vector3(5, 5, 0), new Vector3(10, 10, 0));
            Type = EntityType.Player;
        }

        public EntityType Type { get; set; }



        public BoundingBox HitBox { get; set; }

        public ICollisionBehavior CollisionBehavior { get; set; }


        public void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            HitBox = new BoundingBox(HitBox.Min + Vector3.Up * gameTime.ElapsedGameTime.Minutes,
                HitBox.Max + Vector3.Up * gameTime.ElapsedGameTime.Minutes);

        }
    }
}
