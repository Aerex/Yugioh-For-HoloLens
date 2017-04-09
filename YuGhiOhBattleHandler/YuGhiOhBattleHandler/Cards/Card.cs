using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using YuGhiOhBattleHandler.Interfaces;

namespace YuGhiOhBattleHandler
{

    internal enum CardAttributeOrType
    {
        Dark,
        Earth,
        Fire,
        Fight,
        Water,
        Wind,
        Spell,
        Trap,
        Light
    }

    internal enum Query
    {
        CODE,
        POSITION,
        ALIAS,
        TYPE,
        LEVEL,
        RANK,
        ATTRIBUTE,
        RACE,
        ATTACK,
        DEFENSE,
        BASE_ATTACK,
        BASE_DEFEENCE,
        REASON,
        REASON_CARD,
        EQUIP_CARD,
        TARGET_CARD,
        OVERLAY_CARD,
        COUNTERS,
        OWNER,
        IS_DISABLED,
        IS_PUBLIC,
        LSCALE,
        RSCALE
    }

    public enum AssumeY
    {
        CODE,
        TYPE,
        LEVEL,
        RANK,
        ATTRIBUTE,
        RACE,
        ATTACK,
        DEFENSE
    }

    public enum Attributes
    {
        EARTH = 0x01,
        WATER = 0x02,
        FIRE = 0x04,
        WIND = 0x08,
        LIGHT = 0x10,
        DARK = 0x20,
        DIVINE = 0x40
    }

    public enum Types
    {
        MONSTER,
        SPELL,
        TRAP,
        NORMAL,
        EFFECT,
        FUSION,
        RITUAL,
        TRAP_MONSTER,
        SPIRIT,
        UNION,
        DUAL,
        TOKEN,
        QUICK_PLAY,
        CONTINUOUS,
        EQUIP,
        FIELD,
        COUNTER,
        FLIP,
        TOON,
        XYZ,
        PENDULUM       
        
    }

    public enum Races
    {
        WARRIOR = 0x01,
        SPELLCASTER = 0x02,
        FAIRY = 0x04,
        FIEND = 0x08,
        ZOMBIE = 0x10,
        MACHINE = 0x20,
        AQUA = 0x40,
        PYRO = 0x80,
        ROCK = 0x100,
        WIND_BEAST = 0x200,
        PLANT = 0x400,
        INSECT = 0x800,
        THUNDER = 0x1000,
        DRAGON = 0x2000,
        BEAST = 0x3000,
        BEAST_WARRIOR = 0x4000,
        DINOSAUR = 0x8000,
        FISH = 0x10000,
        SEA_SERPENT  = 0x20000,
        REPTILE = 0x40000,
        PSYCHO = 0x80000
    }

   public enum Status
    {
        DISABLED = 0x01,
        TO_ENABLE = 0x02,
        TO_DISABLE = 0x04,
        PROC_COMPLTE = 0x08,
        SET_TURN = 0x10,
        NO_LEVEL = 0x20,
        REVIVE_LIMIT = 0x40,
        ATTACKED = 0x80,
        FORM_CHANGED  = 0x100,
        SUMMONING = 0x200,
        EFFECT_ENABLED = 0x400,
        SUMMON_TURN = 0x800,
        DESTROY_CONFIRMED = 0x1000,
        LEAVE_CONFIRMED = 0x2000,
        BATTLE_DESTROYED = 0x4000,
        COPYING_EFFECT = 0x8000,
        CHAINING = 0x10000,
        SUMMON_DISABLED = 0x20000,
        ACTIVATE_DISABLED = 0x40000,
        UNSUMMONABLE_CARD = 0x80000,
        UNION = 0x100000,
        ATTACK_CANCELD = 0x200000,
        INITIALIZING = 0x400000,
        ACTIVATED = 0x800000,
        JUST_POS = 0x1000000,
        CONTINOUS_POS = 0x2000000,
        SPSUMMON_TURN = 0x4000000,
        ACT_FROM_HAND = 0x8000000,
        OPPO_BATTLE = 0x10000000,
        FLIP_SUMMON_TURN = 0x20000000,
        SPSUMMON_STEP = 0x40000000
    }

    public enum xCounter
    {
        NEED_PERMIT,
        NEED_ENABLE
    }
    public enum Reason
    {
        DESTROY,
        RELEASE,
        TEMPORARY,
        MATERIAL,
        SUMMON,
        BATTLE,
        EFFECT,
        COST,
        ADJUST,
        LOST_TARGET,
        RULE,
        SPECIAL_SUMMON,
        DISSUMON,
        FLIP,
        DISCARD,
        RDAMAGE,
        RRECOVER,
        RETURN,
        FUSION,
        RITUAL,
        REPLACE,
        DRAW,
        REDIRECT
    
    }

    public enum Summon_Type
    {
        NORMAL,
        ADVANCE,
        DUAL,
        FLIP,
        SPECIAL,
        FUSION,
        RITUAL
    }

    public enum Positions
    {
        FACEUP_ATK,
        FACEDOWN_ATK,
        FACEUP_DEF,
        FACEDOWN_DEF,
        DEF,
        ATK,
        FACEUP,
        FACEDOWN,
        NO_FLIP_EFFECT
    }

    public enum Locations
    {
        DECK,
        HAND,
        MAIN_ZONE,
        SIDE_ZONE,
        GRAVE,
        REMOVED,
        EXTRA,
        OVERLAY,
        ON_FIELD,
        F_ZONE,
        P_ZONE
    }

   public struct card_data
    {
        public int code;
        public int alias;
        public UInt64 setTypeCode;
        public UInt32 type;
        public UInt32 level;
        public UInt32 attr;
        public UInt32 race;
        public Int32 atk;
        public Int32 def;
    }

    public sealed class card_state
    {
        public UInt16 code { get; set; }
        public UInt16 type { get; set; }
        public UInt16 level { get; set; }
        public UInt16 rank { get; set; }
        public UInt16 lscale { get; set; }
        public UInt16 rscale { get; set; }
        public UInt16 attr { get; set; }
        public UInt16 race { get; set; }
        public Int16 atk { get; set; }
        public Int16 def { get; set; }
        public Int16 base_attack { get; set; }
        public Int16 base_defense { get; set; }
        public PlayerTypes controller { get; set; }
        public Locations location { get; set; }
        public UInt16 sequence { get; set; }
        public UInt16 position { get; set; }
        public UInt16 reason { get; set; }
        public Card reasonCard { get; set; }
        public UInt16 reasonPlayer { get; set; }
        //Effect effect; 

    };

    internal struct query_cache
    {
        public UInt16 code;
        public UInt16 alias;
        public UInt16 type;
        public UInt16 level;
        public UInt16 rank;
        public UInt16 attr;
        public UInt16 lscale;
        public UInt16 rscale;
        public UInt16 race;
        public Int16 atk;
        public Int16 def;
        public Int16 base_attack;
        public Int16 base_defense;
        public Int16 isPublic;
        public Int16 isDisabled;
        public UInt16 reason;
    }


    //TODO: Figure out another comarer

    /*public sealed class CardCompare : IComparer
    {
        private Duel duel;
        public int Compare (Object x, Object y)
        {

            Card cardOne = (Card)x;
            Card cardTwo = (Card)y;

            PlayerTypes playerTypeCardOne = cardOne.CardState.controller;
            PlayerTypes playerTypeCardTwo = cardTwo.CardState.controller;

            Locations cardOneLocation = cardOne.CardState.location;
            Locations cardTwoLocation = cardTwo.CardState.location; 

            PlayerTypes currentTurnPlayer = duel.Field.Info.turnPlayer;

            if(playerTypeCardOne != playerTypeCardTwo)
            {
                if(playerTypeCardOne == PlayerTypes.NONE || playerTypeCardTwo == PlayerTypes.NONE)
                {
                    return (int) playerTypeCardOne < (int) playerTypeCardOne ? -1 : 1;
                }
                if(currentTurnPlayer == PlayerTypes.Player1)
                {
                    return (int) playerTypeCardOne < (int) playerTypeCardTwo ? -1 : 1;
                }
                else
                {
                    return (int) playerTypeCardOne > (int) playerTypeCardTwo ?  1 : -1;
                }
            }

            if(cardOneLocation != cardTwoLocation)
            {
                return (int)playerTypeCardOne < (int)playerTypeCardTwo ? -1 : 1;
            }

            return 0;
        }

        public CardCompare(Duel duel)
        {
            this.duel = duel;
        }

    }

        */

    /// <summary>
    /// Base class for YuGhiOh cards.
    /// </summary>
    public sealed class Card : Object
    {
        //private SortedList<UInt32, Effect> effectContainer;
       
        private List<Card> equipingCards;
        public List<Card> EquipingCards
        {
            get { return equipingCards; }
            set { equipingCards = value; }
        }
        //private IList<UInt32, Card> materialCards;
        private IDictionary<UInt32, Card> effectTargetOwner;
        private IDictionary<UInt32, Card> effectTargetCards;
        private List<Card> xyzMaterials;
        private SortedList<int, List<BaseEffect>> singleEffect;
        public SortedList<int, List<BaseEffect>> SingleEffect
        {
            get { return singleEffect; }
            set { singleEffect = value; }
        }
        private SortedList<int, BaseEffect> fieldEffect;
        public SortedList<int, BaseEffect> FieldEffect
        {
            get { return fieldEffect; }
            set { fieldEffect = value; }
        }
        private IDictionary<int, List<BaseEffect>> equipEffect;
        public IDictionary<int, List<BaseEffect>> EquipEffect
        {
            get { return equipEffect; }
            set { equipEffect = value; }
        }
        // private SortedList<UInt32, Effect> immuneEffect;
        //private List<Effect, UInt32> effectRelation;
        private Dictionary<Card, UInt32> relationMap;
        private Dictionary<UInt16, UInt16> counterMap;
        private Dictionary<UInt16, Card> attackerMap;
        private Int32 scrtype;
        private Duel m_duel;

        private card_state preivuos;
        private card_state temp;
        private card_state current;
        private card_state q_cache;
        private UInt32 owner;
        private UInt32 summonPlayer;
        private UInt32 summonInfo;
        private int status;
        public int CardStatus
        {
            get { return status; }
            set { status = value; }
        }
        private UInt32 operationParam;
        private UInt32 announceCount;
        private UInt32 attacked_count;
        private UInt32 attackAllTargets;
        private UInt32 cardId;
        private UInt32 fieldId;
        private UInt32 fieldIdR;
        private UInt32 turnId;
        private UInt32 turnCounter;
        private UInt32 uniquePos;
        private UInt32 uniqueUID;
        private UInt32 specialSummonCode;
        private UInt32 specialSummonCounter;
        private UInt32 specialSummonCounterRst;
       
        //private Effect uniqueEffect;
        private Card equipingTarget;

        public object getAttr()
        {
            throw new NotImplementedException();
        }

        private Card preEquipTarget;
        private Card overlayTarget;



        private string m_cardName;

        private CardAttributeOrType m_attribute;

        public object getRace()
        {
            throw new NotImplementedException();
        }

        private long m_cardNumber;
        private string m_cardDescription;
        private BitmapImage cardImage;
        private string m_actionSet;

        private card_data cardData;
        private card_state cardState;


        public card_state CardState
        {
            get { return cardState; }
            set { cardState = value; }
        }
        public card_data CardData
        {
            get { return CardData; }
            set { cardData = value; }
        }

        public Card EquipingTarget
        {
            get { return equipingTarget; }
            set { equipingTarget = value; }
        }

        public UInt32 CardID
        {
            get { return cardId; }
            set { cardId = value; }
        }

        public Duel Duel
        {
            get { return m_duel; }
        }

        public Card(Duel duel)
        {
            cardState = new card_state();
            m_duel = duel;
            singleEffect = new SortedList<int, List<BaseEffect>>();
            equipingCards = new List<Card>();
        }
       

        public Card()
        {

        }

      
        public UInt32 getInfoLocation()
        {
            return 0;
        }

        public bool IsTypeCard(int cardSetCode)
        {
            BaseReader reader = new Reader();
            int value = 0;
            int code = GetCode();
            int setcode = 0;
            if(code == cardData.code) {
                setcode = (int)cardData.setTypeCode;
            } else {
                card_data data = reader.readCard(code);
                setcode = (int)data.setTypeCode;
            }

            int settype = cardSetCode & 0xfff;
            int setsubtype = cardSetCode & 0xf000;

            while (Convert.ToBoolean(setcode))
            {
                if((setcode & 0xfff) == settype && (setcode & 0xf000) == setsubtype)
                {
                    return true;
                }
                setcode = setcode >> 16;
            }

            List<BaseEffect> effect = FilterEffect((int)effect_codes.EFFECT_ADD_SETCODE, false);
            for(int i = 0; i < effect.Count; i++)
            {
                value = effect[i].GetValue(this);
                if((value & 0xfff) == settype && (value & 0xf000 ) == setsubtype)
                {
                    return true;
                }
            }

            return false;
        }

        public UInt32 getType()
        {
            return 0;
        }

        public int getAtk()
        {
            return 0;
        }

        public int getBaseAtk()
        {
            return 0;
        }

        public int getBaseDef()
        {
            return 0;
        }

        public int getDef()
        {
            return 0;
        }

        public bool IsAffectByEffect(BaseEffect effect)
        {

            return !(isStatus((int)Status.SUMMONING) && effect.Code != (int)effect_flag.EFFECT_FLAG_CANNOT_DISABLE);
        }

        public void calcAtkDef()
        {

        }

        public UInt32 getLevel()
        {
            return 0;
        }

        public UInt32 getRank()
        {
            return 0;
        }

        public UInt32 getSynchroLevel()
        {
            return 0;
        }

        public UInt32 getRitualLevel()
        {
            return 0;
        }

        public UInt32 getXYZLevel()
        {
            return 0;
        }

        public bool isPosition(Positions pos)
        {
            return false;
        }

        public void setStatus(UInt32 status)
        {

        }
        
        public UInt32 getStatus(UInt32 status)
        {
            return 0;
        }

        public bool isStatus(int status)
        {
            return this.status == status;
        }

        public bool Equip(Card target, bool sendMsg)
        {
            return false;
        }

        public bool UnEquip()
        {
            return false;
        }

        public int getUnionCount()
        {
            return 0;
        }
    
        /*
        public void XYZOverlay(SortedList<UInt32, Card> materials)
        {
        
        }

        public void XYZAdd(Card material)
        {

        }

        public void XYZRemove(Card material)
        {

        }
        */

        public bool applyFieldEffect()
        {
            return false;
        }

        public bool cancelFieldEffect()
        {
            if(CardState.controller == PlayerTypes.NONE)
            {
                return false;
            }

            return true;
        }

        public bool enableFieldEffect(bool enable)
        {
            return false;
        }

        /*public int addEffect(Effect effect)
        {

        }

         public void removeEffect(Effect effect)
         {
            
         }

         public void removeEffect(Effect effect, Uint32 index)
         {

          }

            public int copyEffect(UInt32 code, UInt32 reset, UInt32 count)
         {

            }

            public void reset(UInt32 id, UInt32 resetType)
            {
            }

            public int refreshDisableStatus() 
            {

            }

            public UInt32 refreshControlStatus()
            {

            }


        */

        public void countTurn(UInt16 counter)
        {

        }

        public void createRelation(Card target, UInt32 reset)
        {

        }

        /*
        public void createRelation(Effect effect)
        {

        }

    */

        public int isHasRelation(Card target)
        {
            return 0;
        }

        /*        public int isHasRelation(Effect effect)
                {

                }
        */

        public void releaseRelation(Card target)
        {

        }

        /*
        public void releaseRelation(Effect effect)
        {

        }
        */

        public int leaveFieldRedirect(UInt32 reseason)
        {
            return 0;
        }

        public int destinationRedirect(UInt32 reason)
        {
            return 0;
        }

        public int addCounter(UInt32 playerId, UInt32 counterType, UInt32 reason)
        {
            return 0;
        }

        public int removeCounter(UInt32 counterType, UInt32 count)
        {
            return 0;
        }

        public int isCanAddCounter(UInt32 playerId, UInt32 counterType, UInt32 count)
        {
            return 0;
        }

        public int getCounter(UInt32 counterType)
        {
            return 0;
        }
        /*
        public void setMaterial(IDictionary<UInt16, Card> material)
        {

        }
        */

        public void addCardTarget(Card card)
        {

        }

        public void cancelCardTarget(Card card)
        {

        }
        
        public List<BaseEffect> FilterEffect(int code, bool sort)
        {
            List<BaseEffect> result = new List<BaseEffect>();
            BaseEffect effect = null;
            List<BaseEffect> output = null;
            List<BaseEffect> equipEffectForCode = null;
            List<BaseEffect> auraFieldEffectForCode = m_duel.Field.Effect.aura_effect.TryGetValue(code, out output) ? output : new List<BaseEffect>();
            List<BaseEffect> singleEffectsForCode = singleEffect.TryGetValue(code, out output) ? output : new List<BaseEffect>();
            for(int i = 0; i < singleEffectsForCode.Count; i++)
            {
                effect = singleEffectsForCode[i];
                if(effect.IsAvailable() && IsAffectByEffect(effect))
                {
                    result.Add(effect);
                }
            }

            for(int i = 0; i < equipingCards.Count; i++)
            {
                equipEffectForCode =  equipingCards[i].equipEffect.TryGetValue(code, out output) ? output : new List<BaseEffect>();
                for (int j = 0; j < equipEffectForCode.Count; j++)
                {
                    effect = equipEffectForCode[j];
                    if(effect.IsAvailable() && IsAffectByEffect(effect))
                    {
                        result.Add(effect);
                    }
                }
            }

            for(int i = 0; i < auraFieldEffectForCode.Count; i++)
            {
                effect = auraFieldEffectForCode[i];
                if(!effect.IsFlag((int)effect_flag.EFFECT_FLAG_PLAYER_TARGET) && IsAffectByEffect(effect) && effect.IsAvailable() && effect.IsTarget(this))
                {
                    result.Add(effect);
                }
            }

            if(sort)
            {
                result = result.OrderBy(e => e.ID).ToList();
            }

            return result;
        }
         
           
        /*

        public void filterSingleContinousEffect(int code, SortedList<UInt32, Effect> effectList, bool sort)
        {

        }

            */

        public void filterImmuneEffect()
        {

        }

        public void filterDisableRelatedCards()
        {

        }
        /*

        public int filterSummonProcedure(UInt32 playerID, SortedList<UInt32, Effect> effect, UInt32 ignoreCount, UInt32 minTribute)
        {
            return 0;
        }

        public int filterSetProcedure(UInt32 playerId, SortedList<UInt32, Effect> effect, UInt32 ignoreCount, UInt32 minTribute)
        {
            return 0;
        

        public void filterSpecialSummonProcedure(UInt32 playerId, SortedList<UInt32, Effect> effect, UInt32 summonType)
        {

        }

        public void filterSpecialSummonProcedure(UInt32 playerId, SortedList<UInt32, Effect> effect)
        {

        }
        
            */
        public BaseEffect IsAffectedByEffect(int code)
        {

            BaseEffect effect = null;
            List<BaseEffect> output = null;
            List<BaseEffect> equipEffectForCode = null;
            List<BaseEffect> auraFieldEffectForCode = m_duel.Field.Effect.aura_effect.TryGetValue(code, out output) ? output : new List<BaseEffect>();
            List<BaseEffect> singleEffectsForCode = singleEffect.TryGetValue(code, out output) ? output : new List<BaseEffect>();
            for(int i = 0; i < singleEffectsForCode.Count; i++)
            {
                effect = singleEffectsForCode[i];
                if(effect.IsAvailable() && IsAffectByEffect(effect))
                {
                    return effect;
                }
            }

            for(int i = 0; i < equipingCards.Count; i++)
            {
                equipEffectForCode =  equipingCards[i].equipEffect.TryGetValue(code, out output) ? output : new List<BaseEffect>();
                for (int j = 0; j < equipEffectForCode.Count; j++)
                {
                    effect = equipEffectForCode[j];
                    if(effect.IsAvailable() && IsAffectByEffect(effect))
                    {
                        return effect;
                    }
                }
            }

            for(int i = 0; i < auraFieldEffectForCode.Count; i++)
            {
                effect = auraFieldEffectForCode[i];
                if(!effect.IsFlag((int)effect_flag.EFFECT_FLAG_PLAYER_TARGET) && IsAffectByEffect(effect) && effect.IsAvailable() && effect.IsTarget(this))
                {
                    return effect;
                }
            }

           
            return null;
        }
        /*
        public Effect isAffectedByEffect(int code, Card target)
        {
            
        }

        public Effect checkEquipControlEffect()
        {

        */

        /*
    public int fusionCheck(IEnumerable<IGrouping<UInt32, SortedList<UInt32, Card>>> fusionList, Card card, int chkf)
    {
        return 0;
    }

    public void fusionSelect(UInt32 playerIdd, IEnumerable<IGrouping<UInt32, SortedList<UInt32, Card>>> fusionList, Card card, int chkf)
    {

    }
    */

        public int isEquipable(Card card)
        {
            return 0;
        }

        public int isSummonable()
        {
            return 0;
        }
        /*
        public int isSummoable(Effect effect)
        {
            return 0;
        }

        public int isCanBeSummoned(UInt32 playerId, UInt32 ignoreCount, Effect effect, UInt32 minTribute)
        {
            return 0;
        }
        */
        public int getSummonTributeCount()
        {
            return 0;
        }

        public int getSetTributeCount()
        {
            return 0;
        }

        public int isCanBeFlipSummoned(UInt32 playerId)
        {
            return 0;
        }

        public int isSpecialSummonable(UInt32 playerId, Summon_Type type)
        {
            return 0;
        }
        /*
        public int isCanBeSpecialSummoned(Effect reasonEffect, Summon_Type type, Positions pos, UInt32 sumPlayer, UInt32 toPlayer, UInt32 noCheck, UInt32 noLimit)
        {
            return 0;
        }
        
        public int isSetableMZone(UInt32 playerId, UInt32 ignoreCount, Effect effect, UInt32 minTribute)
        {
            return 0;
        }
        */

        public int isSetableSZone(UInt32 playerId)
        {
            return 0;
        }
        /*
        public int isAffectByEffect(Effect effect)
        {
            return 0;
        }
        */

        public int isDestructable()
        {
            return 0;
        }

        public int isDestructableByBattle(Card card)
        {
            return 0;
        }

        /*
        public Effect checkIndestructableByEffect(Effect effect, UInt32 playerId)
        {
            
        }
        */

        public int isRemoveable(UInt32 playerId)
        {
            return 0;
        }

        public int isRemovableAsCost(UInt32 playerId)
        {
            return 0;
        }

        public int isReleaseableBySummon(UInt32 playerId, Card card)
        {
            return 0;
        }

        public int isReleasableByNonSummon(UInt32 playerId)
        {
            return 0;
        }
        /*
        public int isReleasbleByEffect(UInt32 playerId, Effect effect)
        {
            return 0;
        }
        */

        public int isCapableSendToGrave(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableSendToHand(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableSendToDeck(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableSendToExtra(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableCostToGrave(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableCostToHand(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableCostToDeck(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableCostToExtra(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableAttack()
        {
            return 0;
        }

        public int isCapableAttackAnnounce(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableChangePosition(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableTurnSet(UInt32 playerId)
        {
            return 0;
        }

        public int isCapableChangeControl()
        {
            return 0;
        }

        public int isControlCanBeChanged()
        {
            return 0;
        }

        public int isCapableBeBattleTarget(Card card)
        {
            return 0;
        }
        /*
        public int isCapableBeEffectTarget(Effect effect, UInt32 playerId)
        {
            return 0;
        }
        */

        public int isCanBeFusionMaterial(UInt32 ignoreMon)
        {
            return 0;
        }

        /*
        public int isCanBeSynchroMaterial(Card card, Card tuner)
        {

        }
        

        public int isCanByXYZMaterial(Card card)
        {

        }
        */

      



        


        public string getCardName()
        {
            return m_cardName;
        }

        internal void setCardName(string s)
        {
            m_cardName = s;
        }

        internal CardAttributeOrType getAttributeOrType()
        {
            return m_attribute;
        }

        internal void setAttributeOrType(CardAttributeOrType s)
        {
            m_attribute = s;
        }

        public long getCardNumb()
        {
            return m_cardNumber;
        }

        internal void setCardNumb(long s)
        {
            m_cardNumber = s;
        }

        public string getCardDescrip()
        {
            return m_cardDescription;
        }

        public BitmapImage getImage()
        {
            return cardImage;
        }

        internal void setBitmapImage(BitmapImage bi)
        {
            cardImage = bi;
        }

        internal void setCardDescrip(string s)
        {
            m_cardDescription = s;
        }

        internal void setActionSet(string s)
        {
            m_actionSet = s;
        }

        public string getActionSet()
        {
            return m_actionSet;
        }

        public int GetCode()
        {
            BaseReader reader = new Reader();
            int code = cardData.code;
 
            List<BaseEffect> list = FilterEffect((int)effect_codes.EFFECT_CHANGE_CODE, false);
            if (list.Count > 0)
            {
                code = list[list.Count - 1].GetValue(this);
            }

            if (code == cardData.code)
            {
                if (Convert.ToBoolean(cardData.alias) && IsAffectedByEffect((int)effect_codes.EFFECT_ADD_CODE) != null)
                {
                    code = cardData.alias;
                }
            } else {
                card_data data = reader.readCard(code);
                if(Convert.ToBoolean(data.alias))
                {
                    code = data.alias;
                }
            }

            return code;
        }
    }
}
