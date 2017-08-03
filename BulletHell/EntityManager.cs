using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BulletHell
{
    public class EntityManager
    {

        List<IEntity> staticEntities;
        List<IEntity> dynamicEntities;

        public EntityManager()
        {
            
        }
        public void Initialize()
        {

        }

        public void Update(GameTime time)
        {
            foreach(IEntity entity in dynamicEntities)
            {
                entity.Update(time);
            }
            CollisionManager.HandleCollisions(staticEntities, dynamicEntities);
            
        }

        public void Draw(GameTime time)
        {
            foreach(IEntity entity in staticEntities)
            {
                entity.Draw(time);
            }
            foreach(IEntity entity in dynamicEntities)
            {
                entity.Draw(time);
            }
        }

    }
}
