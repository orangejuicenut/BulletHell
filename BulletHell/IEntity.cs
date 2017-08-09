using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public interface IEntity
    {
        bool isExpired { get; }

        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime time);

        Texture2D image { get; set; }

        Rectangle HitBox { get; }

        ICollisionBehavior CollisionBehavior { get; set; }
    }
}
