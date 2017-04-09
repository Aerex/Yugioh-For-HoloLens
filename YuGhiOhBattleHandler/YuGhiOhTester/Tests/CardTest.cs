using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YuGhiOhBattleHandler;
using System.Collections;

namespace YuGhiOhTester.Tests
{
    /*
    [TestFixture]
    public class CardTest
    {
        private Card card1;
        private Card card2;
        private Duel duel;

        [SetUp]
        protected void Setup()
        {
            duel = new Duel();
            card1 = new Card(duel);
            card1.CardID = 123;
            card2 = new Card(duel);
            card2.CardID = 345;
        }

        [TearDown]
        protected void TearDown()
        {

        }
        */
        /*

        [Test]
        public void testCardOperationSortController()
        {
            SortedList listOfCards = new SortedList(new CardCompare(duel));

            card1.CardState.controller = PlayerTypes.NONE;
            card2.CardState.controller = PlayerTypes.Player1;

           
            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.Equals(listOfCards.GetByIndex(0), card1);
            Assert.Equals(listOfCards.GetByIndex(1), card2);

            listOfCards.Clear();

            card1.CardState.controller = PlayerTypes.Player2;
            card2.CardState.controller = PlayerTypes.NONE;

            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.Equals(listOfCards.GetByIndex(0), card1);
            Assert.Equals(listOfCards.GetByIndex(1), card2);
        }

        [Test]
        public void testCardOperationSortTurnPlayer()
        {
            SortedList listOfCards = new SortedList(new CardCompare(duel));

            card1.CardState.controller = PlayerTypes.Player1;
            card2.CardState.controller = PlayerTypes.Player2;

            card1.Duel.Field.Info.turnPlayer = PlayerTypes.Player1;
            card2.Duel.Field.Info.turnPlayer = PlayerTypes.Player1;

            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.Equals(listOfCards.GetByIndex(0), card1);
            Assert.Equals(listOfCards.GetByIndex(1), card2);

            card1.Duel.Field.Info.turnPlayer = PlayerTypes.Player2;
            card2.Duel.Field.Info.turnPlayer = PlayerTypes.Player2;


            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.Equals(listOfCards.GetByIndex(0), card2);
            Assert.Equals(listOfCards.GetByIndex(1), card1);

        }

        [Test]
        public void testCardOperationSortLocation()
        {
            SortedList listOfCards = new SortedList(new CardCompare(duel));

            card1.CardState.controller = PlayerTypes.Player1;
            card2.CardState.controller = PlayerTypes.Player1;

            card1.CardState.location = Locations.DECK;
            card2.CardState.location = Locations.EXTRA;

            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.Equals(listOfCards.GetByIndex(0), card1);
            Assert.Equals(listOfCards.GetByIndex(1), card2);

            listOfCards.Clear();

            card1.CardState.location = Locations.EXTRA;
            card2.CardState.location = Locations.DECK;

            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.Equals(listOfCards.GetByIndex(0), card2);
            Assert.Equals(listOfCards.GetByIndex(1), card1);

        }

    */
    /*
      [Test]
      public void testGetCode()
        {
            var mockReader = Mock.Create<Reader>();
            uint expectedCode = 1;
            card_data dbCard = new card_data();
            dbCard.alias = 123;
            mockReader.Setup(s => s.readCard(expectedCode)).Returns(dbCard);
            
            card_data data = new card_data();
            data.code = expectedCode;
            card1.CardData = data;

            uint actualCode = card1.getCode();

            Assert.Equals(actualCode, expectedCode);

            // mock read_data also
        }

      [Test]
      public void testGetSetType()
        {
            card_data data = new card_data();
            data.setTypeCode = 4;

            card1.CardData = data;
            int setCode = 2;
            Assert.IsFalse(card1.isSetCard(setCode));
        
            setCode = 4;
            Assert.IsTrue(card1.isSetCard(setCode));
        }

      [Test]
      public void testGetType()
      {
            uint expectedType = 2;

            uint actualType = card1.getType();

            Assert.Equals(expectedType, actualType);

            // test if effect_add_type is used
            // test if effect_remove_type is used
            // test if effect_change_type is used


      }

      [Test]

      public void testGetBaseAtk()
      {
            int expectedAtk = 200;
            card_data data = new card_data();

            data.atk = expectedAtk;
            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.Equals(expectedAtk, card1.getBaseAtk());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.Equals(expectedAtk, card1.getBaseAtk());

            // test if effect changes base atk
            // test if effect swaps base atk with def 

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.Equals(0, card1.getBaseAtk());
      }

      [Test]
      public void testGetAtk()
      {
            int expectedAtk = 300;
            card_data data = new card_data();

            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.Equals(expectedAtk, card1.getBaseAtk());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.Equals(expectedAtk, card1.getAtk());

            // test if effect swap attack and def
            // test if effect update attack
            // test if effect set attack
            // test if set attack final??
            // test if swap attack final
            // test if swap base attakc with base def
            // test if set base attak
            // test if set base defense

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.Equals(0, card1.getBaseAtk());
     }

     [Test]
     public void testBaseDef()
     {

            int expectedDef = 200;
            card_data data = new card_data();

            data.def = expectedDef;
            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.Equals(expectedDef, card1.getBaseDef());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.Equals(expectedDef, card1.getBaseDef());

            // test if effect changes base def
            // test if effect swaps base atk with def 

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.Equals(0, card1.getBaseDef());
        }

        [Test]
        public void testDef()
        {
            int expectedDef = 400;
            card_data data = new card_data();

            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.Equals(expectedDef, card1.getDef());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.Equals(expectedDef, card1.getDef());

            // test if effect swap attack and def
            // test if effect update def
            // test if effect set def
            // test if set def final??
            // test if swap def final
            // test if swap base attakc with base def
            // test if set base attak
            // test if set base defense

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.Equals(0, card1.getDef());
        }

        [Test]
        public void testGetLevel()
        {
            uint expectedLevel = 2;
            card_data data = new card_data();
            data.level = expectedLevel;

            // test if effect update level
            // test if effect change level
            // test if effect change level final
            // test if effect ritual level change

            card1.CardData = data;

            Assert.Equals(expectedLevel, card1.getLevel());
        }

        [Test]
        public void testGetAttr()
        {
            uint expectedAttr = (uint)Attributes.DARK;
            card_data data = new card_data();
            data.type = (int)Types.MONSTER;
            data.attr = expectedAttr;

            card1.CardData = data;

            Assert.Equals(expectedAttr, card1.getAttr());

            // test if effect add attribute
            // test if effect remote attribute
            // tset if effect change attribute
            // test if effect change fusion attribute
        }

        [Test]
        public void testGetRace()
        {
            uint expectedRace = (uint)Races.DRAGON;
            card_data data = new card_data();
            data.type = (int)Types.MONSTER;
            data.race = expectedRace;

            Assert.Equals(expectedRace, card1.getRace());

            // test if effect add race
            // test if effect remove race
            // test if effect change race
          

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.Equals(0, card1.getRace());

        }

        [Test]
        public void testEquip()
        {
           
            Assert.IsTrue(card1.Equip(card2, false));
            card1.EquipingTarget = card2;

            Assert.IsFalse(card1.Equip(card2, false));

        }

        [Test]
        public void testUnEquip()
        {
            card1.EquipingTarget = card2;
            Assert.IsTrue(card1.UnEquip());

            card1.EquipingTarget = null;

            Assert.IsFalse(card1.UnEquip());
        }

        [Test]
        public void testApplyFieldEffect()
        {
            card1.CardState.controller = PlayerTypes.NONE;
            Assert.IsFalse(card1.applyFieldEffect());

            card1.CardState.controller = PlayerTypes.Player1;
            Assert.IsTrue(card1.applyFieldEffect());
        }

        [Test]
        public void testCancelFieldEffect()
        {
            card1.CardState.controller = PlayerTypes.NONE;
            Assert.IsFalse(card1.cancelFieldEffect());

            card1.CardState.controller = PlayerTypes.Player1;
            Assert.IsTrue(card1.cancelFieldEffect());
        }

        [Test]
        public void testEnableFieldEffect()
        {
            // test by counting field id

        }


        [Test]
        public void testReplaceEffect()
        {
            // mock reader


        }

        [Test]
        public void testIsStatus()
        {
            card1.Status = (int)Status.ACTIVATED;
            Assert.IsTrue(card1.isStatus((int)Status.ACTIVATED));
            Assert.IsFalse(card1.isStatus((int)Status.ATTACKED));
        
        }

        [Test]
        public void testIsAffectByEffect()
        {
            var mockEffect = Mock.Create<Effect>();
            mockEffect.Setup(s => s.IsImmuned(card1)).Returns(true);
            Effect effect = new Effect(duel);
            card1.Status = (int)Status.SUMMONING;
            effect.Code = (int)effect_codes.EFFECT_ACTIVATE_COST;
            Assert.IsFalse(card1.IsAffectByEffect(effect));

            card1.Status = (int)Status.ACTIVATED;
            Assert.IsTrue(card1.IsAffectByEffect(null));

            effect.Flag = (int)effect_flag.EFFECT_FLAG_IGNORE_IMMUNE;
            Assert.IsTrue(card1.IsAffectByEffect(effect));

            effect.Flag = (int)effect_flag.EFFECT_FLAG_BOTH_SIDE;
            Assert.IsFalse(card1.IsAffectByEffect(effect));

            mockEffect.Setup(s => s.IsImmuned(card1)).Returns(false);
            Assert.IsTrue(card1.IsAffectByEffect(effect));
        }

        [Test]
        public void testfilterEffect()
        {
            var mockEffect = Mock.Create<Effect>();
            mockEffect.Setup(s => s.IsAvailable()).Returns(true);
            mockEffect.Setup(s => s.IsFlag((int)effect_flag.EFFECT_FLAG_SINGLE_RANGE)).Returns(false);
            mockEffect.Setup(s => s.IsTarget(card1)).Returns(true);

            List<Effect> actualList = null;
            List<Effect> effect1CardList = new List<Effect>();
            List<Effect> effect2CardList = new List<Effect>();

            int expectedCode = (int)effect_codes.EFFECT_ACTIVATE_COST;
            Effect effect1 = new Effect(duel);
            effect1.Code = expectedCode;
            Effect effect2 = new Effect(duel);
            effect2.Code = (int)(int)effect_codes.EFFECT_ADD_RACE;

            SortedList<int, List<Effect>> effectList = new SortedList<int, List<Effect>>();

            // test single effect if using different codes
            effect1CardList.Add(effect1);
            effect2CardList.Add(effect2);
            effectList.Add(effect1.Code, effect1CardList);
            effectList.Add(effect2.Code, effect2CardList);
            card1.SingleEffect = effectList;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.Equals(actualList.Count, 1);
            Assert.Equals(actualList[0].Code, expectedCode);

            effectList.Clear();

            // test single effect is using same codes
            effect2.Code = expectedCode;

            effectList.Add(effect1.Code, effect1CardList);
            effectList.Add(effect2.Code, effect2CardList);
            card1.SingleEffect = effectList;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.Equals(actualList.Count, 2);
            Assert.Equals(actualList[0].Code, expectedCode);
            Assert.Equals(actualList[1].Code, expectedCode);

            // test equiping effect
            card_data data = new card_data();
            Card equipCard1 = new Card(duel);
            equipCard1.EquipEffect = effectList;
            data.code = 123;
            equipCard1.CardData = data;
            List<Card> equipCards = new List<Card>();
            equipCards.Add(equipCard1);
            card1.EquipingCards = equipCards;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.Equals(actualList.Count, 3);
            Assert.Equals(actualList[0].Code, expectedCode);
            Assert.Equals(actualList[1].Code, expectedCode);
            Assert.Equals(actualList[2].Code, expectedCode);

            // test effect aura
            field_effect fieldEffects = new field_effect();
            fieldEffects.aura_effect = effectList;
            duel.Field.Effect = fieldEffects;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.Equals(actualList.Count, 4);
            Assert.Equals(actualList[0].Code, expectedCode);
            Assert.Equals(actualList[1].Code, expectedCode);
            Assert.Equals(actualList[2].Code, expectedCode);
            Assert.Equals(actualList[3].Code, expectedCode);

        }




      


    }
    */
}
