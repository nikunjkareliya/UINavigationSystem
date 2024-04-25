using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.StateSytem
{
    public static class GameState
    {
        //public const int Init = 206864754;
        //public const int Home = 200844433;
        //public const int LevelSelect = 109686765;
        //public const int Gameplay = 109686765;
        //public const int LevelFailed = -123341691;
        //public const int LevelCompleted = -124314179;
        //public const int Shop = 201780897;
        //public const int Tutorial = 105033005;

        public const int Init = 2068;
        public const int Home = 2008;
        public const int LevelSelect = 1096;
        public const int Gameplay = 1097;
        public const int LevelFailed = -1233;
        public const int LevelCompleted = -1243;
        public const int Shop = 2017;
        public const int Tutorial = 1050;

        public static string HashToName(int state)
        {
            string stateName = string.Empty;
            if (state == Init)
            {
                return "Init";
            }
            else if (state == Home)
            {
                return "Home";
            }
            else if (state == LevelSelect)
            {
                return "LevelSelect";
            }
            else if (state == Gameplay)
            {
                return "Gameplay";
            }
            else if (state == LevelFailed)
            {
                return "LevelFailed";
            }
            else if (state == LevelCompleted)
            {
                return "LevelCompleted";
            }
            else if (state == Shop)
            {
                return "Shop";
            }
            else if (state == Tutorial)
            {
                return "Tutorial";
            }

            return stateName;
        }
    }
}