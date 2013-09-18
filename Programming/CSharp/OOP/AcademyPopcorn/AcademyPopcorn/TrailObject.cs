using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifeTime;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            :base(topLeft, body)
        {
            this.lifeTime = lifeTime;
        }

        public bool IsNotExpired()
        {
            if (lifeTime <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void Update()
        {
            if (this.lifeTime > 0)
            {
                lifeTime--;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
    }
}
