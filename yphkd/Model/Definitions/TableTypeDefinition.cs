using System;
using yphkd.Db;
namespace yphkd.Model.Definitions
{
    public class TableDefinition : TableDefinitionTable
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
