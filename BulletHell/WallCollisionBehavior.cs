using System;

namespace BulletHell
{
    internal class WallCollisionBehavior : ICollisionBehavior
    {
        public IEntity self { get; set; }

        public void DoCollision(IEntity collidee)
        {
            return;
        }
    }
}