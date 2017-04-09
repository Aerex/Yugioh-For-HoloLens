using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGhiOhBattleHandler.Interfaces;

namespace YuGhiOhBattleHandler
{
    public enum Phases
    {
        DRAW,
        STANDBY,
        MAIN,
        BATTLE,
        MAIN2,
        END
    
    }


    public struct field_info
    {
        public Int16 id;
        public Int16 copyId;
        public Int16 turnId;
        public Int16 cardId;
        public Phases phase;
        public PlayerTypes turnPlayer;
       // public UInt16[] priorities;
        public UInt16 shuffleCount;
    }

    public struct field_effect
    {
        public IDictionary<int, List<BaseEffect>> aura_effect;
        public IDictionary<int, List<BaseEffect>> ignition_effect;
        public IDictionary<int, List<BaseEffect>> activate_effect;
        public IDictionary<int, Object> trigger_o_effect;
        public IDictionary<int, List<BaseEffect>> quick_f_effect;
        public IDictionary<int, List<BaseEffect>> quick_o_effect;
        public IDictionary<int, List<BaseEffect>> continous_effect;
    }
    public sealed class Field
    {
        private field_info info;
        private field_effect effect;

        public field_info Info
        {
            get { return info; }
            set { info = value; }
        }
        public field_effect Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        private Duel m_duel;

        public Field(Duel duel)
        {
            info = new field_info();
            effect = new field_effect();
            effect.aura_effect = new Dictionary<int, List<BaseEffect>>();
            effect.ignition_effect = new Dictionary<int, List<BaseEffect>>();
            effect.activate_effect = new Dictionary<int, List<BaseEffect>>();
            effect.trigger_o_effect = new Dictionary<int, Object>();
            effect.quick_f_effect = new Dictionary<int, List<BaseEffect>>();
            effect.quick_o_effect = new Dictionary<int, List<BaseEffect>>();
            effect.continous_effect = new Dictionary<int, List<BaseEffect>>();

            m_duel = duel;
        }

    }
}
