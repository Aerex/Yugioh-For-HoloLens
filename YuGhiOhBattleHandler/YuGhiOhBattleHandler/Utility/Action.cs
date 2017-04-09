using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGhiOhBattleHandler
{
    class Action
    {
        /*
        static public Game.Result destroy(Game game, int playerId, Parser.Instruction type, Parser.Instruction amount)
        {
            Parser.Instruction[] types = new Parser.Instruction[1] { Parser.Instruction.MONSTER };
            Parser.Instruction[] amounts = new Parser.Instruction[1] { Parser.Instruction.ALL };
            if (!types.Contains(type) || !amounts.Contains(amount)) {
                return Game.Result.InvalidInstruction;
            }

            if (type == Parser.Instruction.MONSTER && amount == Parser.Instruction.ALL)
            {
                return game.destroyAllMonstersOnField(playerid);
            }

        }
        */
        /*
        static public Game.Result equip(Game game, Parser.Instruction type, Parser.Instruction attr, Parser.Instruction effect, int amount)
        {
            Parser.Instruction[] types = new Parser.Instruction[2] { Parser.Instruction.NONE, Parser.Instruction.WARRIOR };
            Parser.Instruction[] attrs = new Parser.Instruction[1] { Parser.Instruction.NONE };
            Parser.Instruction[] effects = new Parser.Instruction[2] { Parser.Instruction.ATK, Parser.Instruction.DEF };

            if (!types.Contains(type) || !attrs.Contains(attr) || !effects.Contains(effect))
            {
                return Game.Result.InvalidInstruction;
            }

            return game.equip(type, attr, effect, amount);

        }
        */
    }
}
