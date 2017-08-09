using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public class CollisionManager
    {
        public static void HandleCollisions(List<IEntity> staticObjects, List<IEntity> dynamicObjects)
        {
            for (int i = 0; i < dynamicObjects.Count; i++)
            {
                IEntity obj1 = dynamicObjects[i];
                for (int j = i + 1; j < dynamicObjects.Count; j++)
                {
                    IEntity obj2 = dynamicObjects[j];
                    HandleSingleCollision(obj1, obj2);
                }
                for (int j = 0; j < staticObjects.Count; j++)
                {
                    IEntity obj2 = staticObjects[j];
                    HandleSingleCollision(obj1, obj2);
                }
            }
        }


        public static void HandleSingleCollision(IEntity obj1, IEntity obj2)
        {
            if (DetectCollisions(obj1, obj2))
            {
                obj1.CollisionBehavior.DoCollision(obj2);
                obj2.CollisionBehavior.DoCollision(obj1);
            }
        }


        public static bool DetectCollisions(IEntity obj1, IEntity obj2)
        {
            return obj1.HitBox.Intersects(obj2.HitBox);
        }

    }
}
