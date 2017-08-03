namespace BulletHell
{
    public interface ICollisionBehavior
    {

        IEntity self { get; set; }

        void DoCollision(ICollidable collidee);


    }
}