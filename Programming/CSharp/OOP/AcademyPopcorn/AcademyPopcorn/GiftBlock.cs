using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> newGift = new List<GameObject>();
            if (this.IsDestroyed)
            {
                newGift.Add(new Gift(this.topLeft));
            }
            return newGift;
        }
    }
}
