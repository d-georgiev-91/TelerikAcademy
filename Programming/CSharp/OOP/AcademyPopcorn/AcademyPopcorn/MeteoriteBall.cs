using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trialObjects = new List<GameObject>();
            trialObjects.Add(new TrailObject(base.topLeft, new char[,] { { '@' } }, 3));
            return trialObjects;
        }
    }
}
