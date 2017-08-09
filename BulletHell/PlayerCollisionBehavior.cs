using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace BulletHell
{
    public class PlayerCollisionBehavior : ICollisionBehavior
    {
        private Player player;

        public PlayerCollisionBehavior(Player player)
        {
            this.player = player;
        }

        public IEntity self
        {
            get
            {
                return player;
            }
        }

        public void DoCollision(IEntity collidee)
        {
            if (collidee is Wall)
            {
                Rectangle temp = collidee.HitBox;
                Rectangle toSet = player.HitBox;
                toSet.Location = DoWallCollision(temp);
                player.HitBox = toSet;





            }
        }

        public Point DoWallCollision(Rectangle collidee)
        {

            int leftColDist = self.HitBox.Left - collidee.Right; // less than 0 means collision;
            int rightColDist = self.HitBox.Right - collidee.Left; // greater than 0 means collision
            int topColDist = self.HitBox.Top - collidee.Bottom; // less than 0 means collision;
            int bottomColDist = self.HitBox.Bottom - collidee.Top; // greater than 0 means collision;



            int[] dists = { leftColDist, rightColDist, topColDist, bottomColDist };
            int max = dists.Select(x => Math.Abs(x)).Min();
            if (Math.Abs(leftColDist) == max)
            {
                return self.HitBox.Location + new Point(-leftColDist, 0);
            }
            if (Math.Abs(rightColDist) == max)
            {
                return self.HitBox.Location + new Point(-rightColDist, 0);
            }
            if (Math.Abs(topColDist) == max)
            {
                return self.HitBox.Location + new Point(0, -topColDist);
            }

            if (Math.Abs(bottomColDist) == max)
            {
                return self.HitBox.Location + new Point(0, -bottomColDist);

            }

            return self.HitBox.Location;



        }


        public static int[] HandleCollision(int box1Left, int box1Top,
                                           int box1Right, int box1Bottom,
                                           int box2Left, int box2Top,
                                           int box2Right, int box2Bottom,
                                           int box1PrevLeft, int box1PrevTop)
        {


            int leftColDist = box1Left - box2Right; // less than 0 means collision;
            int rightColDist = box1Right - box2Left; // greater than 0 means collision
            int topColDist = box1Top - box2Bottom; // less than 0 means collision;
            int bottomColDist = box1Bottom - box2Bottom; // greater than 0 means collision;

            bool leftCollision = leftColDist < 0; // is the left edge past the other right edge
            bool rightCollision = rightColDist > 0; // is the right edge past the other left edge
            bool topCollision = topColDist < 0; // is the top edge past the other bottom edge
            bool bottomCollision = bottomColDist > 0; // is the bottom edge past the other top edge



            if (leftCollision &&
                rightCollision &&
                topCollision &&
                bottomCollision) // detects current collision
            {

                int[] dists = { leftColDist, rightColDist, topColDist, bottomColDist };
                int max = dists.Max();
                if (leftColDist == max)
                {
                    return new int[] { box1Left - leftColDist, box1Top };
                }
                if (rightColDist == max)
                {
                    return new int[] { box1Left - rightColDist, box1Top };
                }
                if (topColDist == max)
                {
                    return new int[] { box1Left, box1Top - topColDist };
                }

                if (topColDist == max)
                {
                    return new int[] { box1Left, box1Top - bottomColDist };
                }



            }

            return null;






        }

    }
}