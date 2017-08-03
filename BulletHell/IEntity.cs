using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public interface IEntity: ICollidable
    {
        EntityType Type { get; set; }

        void Draw(GameTime time);
        void Update(GameTime time);
    }
}
