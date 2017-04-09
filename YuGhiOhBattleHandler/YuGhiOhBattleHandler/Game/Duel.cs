using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGhiOhBattleHandler
{
    public enum PlayerTypes
    {
        Player1,
        Player2,
        NONE,
        ALL
    }

    public sealed class Duel
    {
        private Field m_field;

        public Duel()
        {
            m_field = new Field(this);
        }

        public Field Field
        {
            get { return m_field; }
        }

  
    }
}
