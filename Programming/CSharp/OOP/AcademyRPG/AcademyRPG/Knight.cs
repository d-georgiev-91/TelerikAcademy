using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 100;
        }

        public int AttackPoints
        {
            get { return 100; }
        }

        public int DefensePoints
        {
            get { return 100; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int firstAvailableTargetToAttack = -1;
            foreach (var target in availableTargets)
            {
                if (target.Owner != this.Owner && target.Owner!=0 && !(target is Ninja))
                {
                    firstAvailableTargetToAttack++;
                    break;
                }
            }
            return firstAvailableTargetToAttack;
        }

        public string Name
        {
            get { return base.Name; }
        }

        public bool IsDestroyed
        {
            get
            {
                if (this.HitPoints < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Point Position
        {
            get;
            set;
        }
    }
}
