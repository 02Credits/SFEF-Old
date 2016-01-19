using Artemis.Blackboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Artemis
{
    public static class BlackboardExtensions
    {
        public static void SetEntry<T, E>(this BlackBoard blackBoard, E enumValue, T obj)
        {
            blackBoard.SetEntry(Enum.GetName(typeof(E), enumValue), obj);
        }

        public static T GetEntry<T, E>(this BlackBoard blackBoard, E enumValue)
        {
            return blackBoard.GetEntry<T>(Enum.GetName(typeof(E), enumValue));
        }
    }
}
