using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGhiOhBattleHandler
{
    class Parser
    {

        private int currentPlayer;
        
        internal enum Instruction
        {
            PLAYER,
            EQUIP,
            CARD,
            MONSTER,
            DESTROY,
            ALL,
            NONE,

            // Monster Types
            WARRIOR,
            BEAST,

            //Effect Types
            ATK,
            DEF

            
        } 
        
      /*  public Game.Result executeActions(Game.QueueType type)
        {
            Instruction cardType;
            Instruction cardAttr;
            Instruction cardEffect;
            Instruction amountDestroyed;
            int amount;
           

            if(currentGame == null)
            {
                return Game.Result.InvalidInstruction;
            }

            Stack cardStack = currentGame.getStack(type);
                
            while(cardStack.Count > 0)
            {

                Instruction instruction = (Instruction) Enum.Parse(typeof(Instruction), (string) cardStack.Peek());

                switch (instruction)
                {
                    case Instruction.PLAYER:
                        cardStack.Pop();
                        if ((string)cardStack.Peek() != "0" || (string)cardStack.Peek() != "1") {
                            // return error;
                            return Game.Result.InvalidInstruction;
                        }
                        currentPlayer = int.Parse((string)cardStack.Pop());
                        break;
                    case Instruction.DESTROY:
                        cardStack.Pop();
                        cardType = (Instruction)Enum.Parse(typeof(Instruction), (string)cardStack.Pop());
                        amountDestroyed = (Instruction)Enum.Parse(typeof(Instruction), (string)cardStack.Pop());

                        Action.destroy(currentGame, currentPlayer, cardType, amountDestroyed);
                        break;

                    case Instruction.EQUIP:
                        cardStack.Pop();

                        cardType = (Instruction)Enum.Parse(typeof(Instruction), (string)cardStack.Peek());
                        if ((string)cardStack.Peek() == "TYPE")
                        {
                            cardStack.Pop();
                            cardType = (Instruction) Enum.Parse(typeof(Instruction), (string)cardStack.Pop());
                        }

                        if ((string)cardStack.Peek() == "ATTR")
                        {
                            cardStack.Pop();
                            cardAttr = (Instruction)Enum.Parse(typeof(Instruction), (string)cardStack.Pop());
                        }

                        while((string) cardStack.Peek() != "END")
                        {
                            if((string) cardStack.Peek() == "EFFECT")
                            {
                                cardStack.Pop();
                                cardEffect = (Instruction)Enum.Parse(typeof(Instruction), (string)cardStack.Pop());
                                amount = (int)cardStack.Pop();
                            }
                        }

                        cardStack.Pop();
                        break;

                }
            }
      


       
        }
*/
/*
        public Game.Result executeCards()
        {
            Stack cards = currentGame.getStack(Game.QueueType.ChainStack);
   
            Object currentCard = null;

            while(cards.Count > 0)
            {
                currentCard = (Object) cards.Pop();

                if(currentCard is SpellAndTrapCard)
                {
                    SpellAndTrapCard currentSpellAndTrapCard = currentCard as SpellAndTrapCard;

                    if(currentSpellAndTrapCard.getIcon() == Icon.Equip)
                    {

                    }
                }

            }
        }
        */
    }


}
