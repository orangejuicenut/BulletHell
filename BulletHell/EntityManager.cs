using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell
{
    public class EntityManager
    {

        public List<IEntity> staticEntities { get; set; }
        public List<IEntity> dynamicEntities { get; set; }

        public EntityManager()
        {
            staticEntities = new List<IEntity>();
            dynamicEntities = new List<IEntity>();

        }
        public void Initialize()
        {

        }

        public void Update(GameTime time)
        {
            foreach (IEntity entity in dynamicEntities)
            {
                entity.Update(time);
            }
            CollisionManager.HandleCollisions(staticEntities, dynamicEntities);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
            foreach (IEntity entity in staticEntities)
            {
                entity.Draw(spriteBatch);
            }
            foreach (IEntity entity in dynamicEntities)
            {
                entity.Draw(spriteBatch);
            }
            
        }

    }
}
