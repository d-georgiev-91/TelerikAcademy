using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IGatherer, IFighter
    {

        public Giant(string name, Point position)
            :base(name, position, 0)
        {
            this.HitPoints = 200;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                return true;
            }

            return false;
        }

        public int AttackPoints
        {
            get 
            {
                return 150;
            }
        }

        public int DefensePoints
        {
            get
            {
                return 80;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int firstAvailableTargetToAttack = -1;
            foreach (var target in availableTargets)
            {
                if (target.Owner != this.Owner && target.Owner != 0 && !(target is Ninja))
                {
                    firstAvailableTargetToAttack++;
                    break;
                }
            }
            return firstAvailableTargetToAttack;
        }
    }
}
