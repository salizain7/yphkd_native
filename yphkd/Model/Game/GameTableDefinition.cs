using System;
using yphkd.Db;
namespace yphkd.Model.Game
{
    public class GameTableDefinition : GameTableDefinitionTable
    {
        #region GameTableType Enum
        public enum TypeEnum : int
        {
            THREEPLAYERTABLE = 10,
            FOURPLAYERTABLE = 30,
            FIVEPLAYERTABLE = 50,

        };
        #endregion
    }
}
