using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IGatherer, IFighter
    {
        public Ninja(string name, Point position, int owner) 
            : base (name, position, owner)
        {
            this.HitPoints = 1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone || resource.Type == ResourceType.Lumber)
            {
                return true;
            }

            return false;
        }

        public int AttackPoints
        {
            get
            {
                return 0;
            }
        }

        public int DefensePoints
        {
            get 
            {
                throw new NotImplementedException(); 
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
