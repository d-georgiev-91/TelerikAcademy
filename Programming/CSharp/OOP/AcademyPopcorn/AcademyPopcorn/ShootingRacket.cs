using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool isShot = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {

        }

        public void Shoot()
        {
            isShot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceBullet = new List<GameObject>();
            if (isShot)
            {
                isShot = false;
                produceBullet.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col + 2)));
            }
            return produceBullet;
        }
    }
}
