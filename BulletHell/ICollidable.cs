using Microsoft.Xna.Framework;

namespace BulletHell
{
    public interface ICollidable
    {
        BoundingBox HitBox { get; set; }

        ICollisionBehavior CollisionBehavior { get; set; }

        
    }
}