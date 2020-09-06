using System;
namespace yphkd.Model.GameDefinition
{
    public class GameEnums
    {
        public GameEnums()
        {
        }
        public enum HandEnum : int
        {
            YASSU = 1,
            PANJU = 2,
            HAAR = 3,
            KABOOTAR = 4,
            DOLI = 5
        };
        public enum UserStatusEnum : int
        {
            INACTIVE = -100,
            ACTIVE = 100
            
        };
        public enum GameStatusEnum : int
        {
            ERROR = -999,
            WAITING_PLAYERS = 50,
            ACTIVE = 100,
            WINNER = 500,
            FINISHED= 1000
        };


    }
}
