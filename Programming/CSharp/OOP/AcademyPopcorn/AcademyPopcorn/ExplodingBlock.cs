using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public const char Symbol = '@';

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { 'q' } }, new MatrixCoords(-1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { 'q' } }, new MatrixCoords(1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { 'q' } }, new MatrixCoords(0, 1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { 'q' } }, new MatrixCoords(0, -1)));
            }
            return produceObjects;
        }
    }
}
