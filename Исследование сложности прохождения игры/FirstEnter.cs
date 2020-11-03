using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Исследование_сложности_прохождения_игры
{
    struct FirstEnter
    {
        public int PlayerUid { get; }

        public int MaxAchievedStep { get; }

        public FirstEnter(int playerUid, int maxAchievedStep)
        {
            PlayerUid = playerUid;
            MaxAchievedStep = maxAchievedStep;
        }
    }
}
