using System;
using yphkd.Db;
namespace yphkd.Model.Definitions
{
    public class TableTypeDefinition : GameTableTypeDefinitionTable
    {
        #region GameTableType Enum
        public enum TypeEnum : int
        {
            TABLE1 = 10,
            TABLE2 = 20,
            TABLE3 = 30,

        };
        #endregion
    }
}
