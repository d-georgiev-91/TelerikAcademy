using System;
using System.Linq;

namespace BattleShips
{
    public class DummyException : ApplicationException
    {
        public DummyException(string message) : base(message)
        {
        }
    }
}