using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class EngineForShooting : Engine
    {
        public EngineForShooting(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            :base(renderer, userInterface, sleepTime)
        {

        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
