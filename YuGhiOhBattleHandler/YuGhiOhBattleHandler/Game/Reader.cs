using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGhiOhBattleHandler.Interfaces;

namespace YuGhiOhBattleHandler
{
    public sealed class Reader : BaseReader
    {
        public card_data readCard(int code)
        {
            return new card_data();
        }
    }
}
