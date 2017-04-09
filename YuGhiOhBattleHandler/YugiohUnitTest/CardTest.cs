using System.Collections.Generic;
using HyperMock;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using YuGhiOhBattleHandler;
using YuGhiOhBattleHandler.Interfaces;

namespace YuGhiOhTester.Tests
{

    [TestClass]
    public class CardTest
    {
        private Card card1;
        private Card card2;
        private Duel duel;

      
        public CardTest()
        {
            duel = new Duel();
            card1 = new Card(duel);
            card1.CardID = 123;
            card2 = new Card(duel);
            card2.CardID = 345;
        }

     
        /*

        [Test]
        public void testCardOperationSortController()
        {
            SortedList listOfCards = new SortedList(new CardCompare(duel));

            card1.CardState.controller = PlayerTypes.NONE;
            card2.CardState.controller = PlayerTypes.Player1;

           
            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.AreEqual(listOfCards.GetByIndex(0), card1);
            Assert.AreEqual(listOfCards.GetByIndex(1), card2);

            listOfCards.Clear();

            card1.CardState.controller = PlayerTypes.Player2;
            card2.CardState.controller = PlayerTypes.NONE;

            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.AreEqual(listOfCards.GetByIndex(0), card1);
            Assert.AreEqual(listOfCards.GetByIndex(1), card2);
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

            Assert.AreEqual(listOfCards.GetByIndex(0), card1);
            Assert.AreEqual(listOfCards.GetByIndex(1), card2);

            card1.Duel.Field.Info.turnPlayer = PlayerTypes.Player2;
            card2.Duel.Field.Info.turnPlayer = PlayerTypes.Player2;


            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.AreEqual(listOfCards.GetByIndex(0), card2);
            Assert.AreEqual(listOfCards.GetByIndex(1), card1);

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

            Assert.AreEqual(listOfCards.GetByIndex(0), card1);
            Assert.AreEqual(listOfCards.GetByIndex(1), card2);

            listOfCards.Clear();

            card1.CardState.location = Locations.EXTRA;
            card2.CardState.location = Locations.DECK;

            listOfCards.Add(card1.CardID, card1);
            listOfCards.Add(card2.CardID, card2);

            Assert.AreEqual(listOfCards.GetByIndex(0), card2);
            Assert.AreEqual(listOfCards.GetByIndex(1), card1);

        }

    */
    
      [TestMethod]
      public void testGetCode()
        {
            var mockReader = Mock.Create<BaseReader>();
            int expectedCode = 1;
            var expectedAlias = 123;
            card_data dbCard = new card_data();
            dbCard.alias = expectedAlias;
            mockReader.Setup(s => s.readCard(expectedCode)).Returns(dbCard);
            
            card_data data = new card_data();
            data.code = expectedCode;
            card1.CardData = data;

            int actualCode = card1.GetCode();

            Assert.AreEqual(actualCode, expectedCode);

            data.code = (int)effect_codes.EFFECT_CHANGE_CODE;
            card1.CardData = data;
      
            expectedCode = (int)effect_codes.EFFECT_CHANGE_CODE;
            var mockEffect1 = Mock.Create<BaseEffect>();
            mockEffect1.Setup(s => s.IsAvailable()).Returns(true);
            mockEffect1.Setup(s => s.IsFlag((int)effect_flag.EFFECT_FLAG_SINGLE_RANGE)).Returns(false);
            mockEffect1.Setup(s => s.IsTarget(card1)).Returns(true);
            mockEffect1.Setup(s => s.GetValue(card1)).Returns(expectedCode);
            mockEffect1.SetupGet(s => s.Code).Returns(expectedCode);
            mockEffect1.SetupGet(s => s.ID).Returns(1);


            BaseEffect effect = mockEffect1.Object;

            // test if code is equal to effect code
            List<BaseEffect> effectList = new List<BaseEffect>();
            effectList.Add(effect);
            SortedList<int, List<BaseEffect>> list = new SortedList<int, List<BaseEffect>>();
            list.Add(expectedCode, effectList);

            card1.SingleEffect = list;  
            actualCode = card1.GetCode();

            list.Add((int)effect_codes.EFFECT_ADD_CODE, effectList);
            card1.SingleEffect = list;

            // test if alias is set and effect is set
            data.alias = expectedAlias;
            card1.CardData = data;
            actualCode = card1.GetCode();
            Assert.AreEqual(actualCode, expectedAlias);


        }
        
      [TestMethod]
      public void testGetSetType()
        {
            card_data data = new card_data();
            data.setTypeCode = 839;

            card1.CardData = data;
            int expectedTypeCode = 839;
            Assert.IsTrue(card1.IsTypeCard(expectedTypeCode));
        
            expectedTypeCode = 4;
            Assert.IsFalse(card1.IsTypeCard(expectedTypeCode));
        }

      [TestMethod]
      public void testGetType()
      {
            uint expectedType = 2;

            uint actualType = card1.getType();

            Assert.AreEqual(expectedType, actualType);

            // test if effect_add_type is used
            // test if effect_remove_type is used
            // test if effect_change_type is used


      }
/*
      [TestMethod]

      public void testGetBaseAtk()
      {
            int expectedAtk = 200;
            card_data data = new card_data();

            data.atk = expectedAtk;
            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.AreEqual(expectedAtk, card1.getBaseAtk());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.AreEqual(expectedAtk, card1.getBaseAtk());

            // test if effect changes base atk
            // test if effect swaps base atk with def 

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.AreEqual(0, card1.getBaseAtk());
      }

      [TestMethod]
      public void testGetAtk()
      {
            int expectedAtk = 300;
            card_data data = new card_data();

            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.AreEqual(expectedAtk, card1.getBaseAtk());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.AreEqual(expectedAtk, card1.getAtk());

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

            Assert.AreEqual(0, card1.getBaseAtk());
     }

     [TestMethod]
     public void testBaseDef()
     {

            int expectedDef = 200;
            card_data data = new card_data();

            data.def = expectedDef;
            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.AreEqual(expectedDef, card1.getBaseDef());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.AreEqual(expectedDef, card1.getBaseDef());

            // test if effect changes base def
            // test if effect swaps base atk with def 

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.AreEqual(0, card1.getBaseDef());
        }

        [TestMethod]
        public void testDef()
        {
            int expectedDef = 400;
            card_data data = new card_data();

            data.type = (int)Types.MONSTER;
            card1.CardState.location = Locations.HAND;
            card1.setStatus((int)Status.SUMMONING);
            card1.CardData = data;

            Assert.AreEqual(expectedDef, card1.getDef());

            card1.setStatus((int)Status.SPSUMMON_STEP);

            Assert.AreEqual(expectedDef, card1.getDef());

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

            Assert.AreEqual(0, card1.getDef());
        }

        [TestMethod]
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

            Assert.AreEqual(expectedLevel, card1.getLevel());
        }

        [TestMethod]
        public void testGetAttr()
        {
            uint expectedAttr = (uint)Attributes.DARK;
            card_data data = new card_data();
            data.type = (int)Types.MONSTER;
            data.attr = expectedAttr;

            card1.CardData = data;

            Assert.AreEqual(expectedAttr, card1.getAttr());

            // test if effect add attribute
            // test if effect remote attribute
            // tset if effect change attribute
            // test if effect change fusion attribute
        }

        [TestMethod]
        public void testGetRace()
        {
            uint expectedRace = (uint)Races.DRAGON;
            card_data data = new card_data();
            data.type = (int)Types.MONSTER;
            data.race = expectedRace;

            Assert.AreEqual(expectedRace, card1.getRace());

            // test if effect add race
            // test if effect remove race
            // test if effect change race
          

            data.type = (int)Types.QUICK_PLAY;
            card1.CardData = data;

            Assert.AreEqual(0, card1.getRace());

        }

        [TestMethod]
        public void testEquip()
        {
           
            Assert.IsTrue(card1.Equip(card2, false));
            card1.EquipingTarget = card2;

            Assert.IsFalse(card1.Equip(card2, false));

        }

        [TestMethod]
        public void testUnEquip()
        {
            card1.EquipingTarget = card2;
            Assert.IsTrue(card1.UnEquip());

            card1.EquipingTarget = null;

            Assert.IsFalse(card1.UnEquip());
        }

        [TestMethod]
        public void testApplyFieldEffect()
        {
            card1.CardState.controller = PlayerTypes.NONE;
            Assert.IsFalse(card1.applyFieldEffect());

            card1.CardState.controller = PlayerTypes.Player1;
            Assert.IsTrue(card1.applyFieldEffect());
        }
        */

        [TestMethod]
        public void testIsAffectedByEffect()
        {
            int expectedCode = (int)effect_codes.EFFECT_ACTIVATE_COST;
            var mockEffect1 = Mock.Create<BaseEffect>();
            mockEffect1.Setup(s => s.IsAvailable()).Returns(true);
            mockEffect1.Setup(s => s.IsFlag((int)effect_flag.EFFECT_FLAG_SINGLE_RANGE)).Returns(false);
            mockEffect1.Setup(s => s.IsTarget(card1)).Returns(true);
            mockEffect1.SetupGet(s => s.Code).Returns(expectedCode);
            mockEffect1.SetupGet(s => s.ID).Returns(1);

            card1.EquipingCards = new List<Card>();
            BaseEffect effect = null;

            List<BaseEffect> effect1CardList = new List<BaseEffect>();

            BaseEffect effect1 = mockEffect1.Object;

            SortedList<int, List<BaseEffect>> effectList = new SortedList<int, List<BaseEffect>>();

            // test single effect
            effect1CardList.Add(effect1);
            effectList.Add(effect1.Code, effect1CardList);
            card1.SingleEffect = effectList;
            effect = card1.IsAffectedByEffect(expectedCode);
            Assert.AreEqual(effect.ID, 1);
            Assert.AreEqual(effect.Code, expectedCode);

        }

        [TestMethod]
        public void testCancelFieldEffect()
        {
            card1.CardState.controller = PlayerTypes.NONE;
            Assert.IsFalse(card1.cancelFieldEffect());

            card1.CardState.controller = PlayerTypes.Player1;
            Assert.IsTrue(card1.cancelFieldEffect());
        }

        /*
        [TestMethod]
        public void testEnableFieldEffect()
        {
            // test by counting field id

        }


        [TestMethod]
        public void testReplaceEffect()
        {
            // mock reader


        }

    */
        [TestMethod]
        public void testIsStatus()
        {
            card1.CardStatus = (int)Status.ACTIVATED;
            Assert.IsTrue(card1.isStatus((int)Status.ACTIVATED));
            Assert.IsFalse(card1.isStatus((int)Status.ATTACKED));
        
        }
        
        [TestMethod]
        public void testIsAffectByEffect()
        {
            var mockEffect = Mock.Create<BaseEffect>();
            mockEffect.Setup(s => s.IsImmuned(card1)).Returns(true);
            BaseEffect effect =  mockEffect.Object;
            card1.CardStatus = (int)Status.SUMMONING;

            mockEffect.SetupGet(s => s.Code).Returns((int)effect_codes.EFFECT_ACTIVATE_COST);
            //effect.Code = (int)effect_codes.EFFECT_ACTIVATE_COST;
            Assert.IsFalse(card1.IsAffectByEffect(effect));

            card1.CardStatus = (int)Status.ACTIVATED;
            Assert.IsTrue(card1.IsAffectByEffect(null));

     //       mockEffect.SetupGet(s => s.Flag).Returns((int)effect_flag.EFFECT_FLAG_IGNORE_IMMUNE);
//            effect.Flag = (int)effect_flag.EFFECT_FLAG_IGNORE_IMMUNE;
       //     Assert.IsTrue(card1.IsAffectByEffect(effect));

//            effect.Flag = (int)effect_flag.EFFECT_FLAG_BOTH_SIDE;
         //   mockEffect.SetupGet(s => s.Flag).Returns((int)effect_flag.EFFECT_FLAG_BOTH_SIDE);
           // Assert.IsFalse(card1.IsAffectByEffect(effect));

//            mockEffect.Setup(s => s.IsImmuned(card1)).Returns(false);
  //          Assert.IsTrue(card1.IsAffectByEffect(effect));
        }
       
        [TestMethod]
        public void testfilterEffect()
        {

            int expectedCode = (int)effect_codes.EFFECT_ACTIVATE_COST;
            var mockEffect1 = Mock.Create<BaseEffect>();
            mockEffect1.Setup(s => s.IsAvailable()).Returns(true);
            mockEffect1.Setup(s => s.IsFlag((int)effect_flag.EFFECT_FLAG_SINGLE_RANGE)).Returns(false);
            mockEffect1.Setup(s => s.IsTarget(card1)).Returns(true);
            mockEffect1.SetupGet(s => s.Code).Returns(expectedCode);
            mockEffect1.SetupGet(s => s.ID).Returns(1);

            var mockEffect2 = Mock.Create<BaseEffect>();
            mockEffect2.Setup(s => s.IsAvailable()).Returns(true);
            mockEffect2.Setup(s => s.IsFlag((int)effect_flag.EFFECT_FLAG_SINGLE_RANGE)).Returns(false);
            mockEffect2.Setup(s => s.IsTarget(card1)).Returns(true);
            mockEffect2.SetupGet(s => s.Code).Returns((int)effect_codes.EFFECT_ADD_RACE);
            card1.EquipingCards = new List<Card>();
           
            List<BaseEffect> actualList = null;
            List<BaseEffect> effect1CardList = new List<BaseEffect>();
            List<BaseEffect> effect2CardList = new List<BaseEffect>();

            BaseEffect effect1 = mockEffect1.Object;
            BaseEffect effect2 = mockEffect2.Object;

//            effect2.Code = (int)effect_codes.EFFECT_ADD_RACE;

            SortedList<int, List<BaseEffect>> effectList = new SortedList<int, List<BaseEffect>>();

            // test single effect if using different codes
            effect1CardList.Add(effect1);
            effect2CardList.Add(effect2);
            effectList.Add(effect1.Code, effect1CardList);
            effectList.Add(effect2.Code, effect2CardList);
            card1.SingleEffect = effectList;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.AreEqual(actualList.Count, 1);
            Assert.AreEqual(actualList[0].Code, expectedCode);

            effectList.Clear();
            effect1CardList.Clear();
            effect2CardList.Clear();

            // test single effect is using same codes different id
            //effect1.ID = 1;
            mockEffect1.SetupGet(s => s.Code).Returns(expectedCode);
            mockEffect2.SetupGet(s => s.ID).Returns(2);

            mockEffect2.SetupGet(s => s.Code).Returns(expectedCode);
            //effect2.ID = 2;

            //effect2.Code = expectedCode;

            effect1CardList.Add(effect1);
            effect1CardList.Add(effect2);
            effectList.Add(effect1.Code, effect1CardList);

            card1.SingleEffect = effectList;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.AreEqual(actualList.Count, 2);
            Assert.AreEqual(actualList[0].Code, expectedCode);
            Assert.AreEqual(actualList[0].ID, 1);
            Assert.AreEqual(actualList[1].Code, expectedCode);
            Assert.AreEqual(actualList[1].ID, 2);

            effect1CardList.Clear();

            // test equiping effect
            effect1CardList.Add(effect1);
            card_data data = new card_data();
            Card equipCard1 = new Card(duel);
            equipCard1.EquipEffect = effectList;
            data.code = 123;
            equipCard1.CardData = data;
            List<Card> equipCards = new List<Card>();
            equipCards.Add(equipCard1);
            card1.EquipingCards = equipCards;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.AreEqual(actualList.Count, 2);
            Assert.AreEqual(actualList[0].Code, expectedCode);
            Assert.AreEqual(actualList[0].ID, 1);
            Assert.AreEqual(actualList[1].Code, expectedCode);
            
            // test effect aura
            field_effect fieldEffects = new field_effect();
            fieldEffects.aura_effect = effectList;
            duel.Field.Effect = fieldEffects;
            actualList = card1.FilterEffect(expectedCode, true);

            Assert.AreEqual(actualList.Count, 3);
            Assert.AreEqual(actualList[0].Code, expectedCode);
            Assert.AreEqual(actualList[1].Code, expectedCode);
            Assert.AreEqual(actualList[2].Code, expectedCode);
            
        }




      


    }
   
}
