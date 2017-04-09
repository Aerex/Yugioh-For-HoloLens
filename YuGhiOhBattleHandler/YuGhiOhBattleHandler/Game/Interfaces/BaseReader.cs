using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGhiOhBattleHandler.Interfaces
{
    public interface BaseReader
    {
        card_data readCard(int code);
    }
}
