namespace BulletHell
{
    public interface ICollisionBehavior
    {

        IEntity self { get; }

        void DoCollision(IEntity collidee);


    }
}