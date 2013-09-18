using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Bullet : MovingObject
    {
        private bool isShot = false;   

        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '.' } }, new MatrixCoords(-1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return (otherCollisionGroupString == "block" || otherCollisionGroupString == "indestructible block" ||
                otherCollisionGroupString == "unstopable block");
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceBullet = new List<GameObject>();
            if (isShot)
            {
                isShot = false;
                produceBullet.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col+2)));
            }
            return produceBullet;
        }
    }
}
