using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGhiOhBattleHandler.Interfaces
{
    public interface BaseEffect
    {
        int Code
        {
            get;
            set;
        }

        int Type
        {
            get;
            set;
        }

        int Flag
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        bool IsAvailable();

        bool IsFlag(int flag);

        bool IsImmuned(Card card);

        bool IsTarget(Card card);

        int GetValue(Card card);
    }
}
