using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerStatusModel
    {
        public int CurrentLevel { get; set; }
        public float Hp { get; set; }
        public int Coins { get; set; }
        
        public int CoinsToLevelUp { get; set; }
        
        public float xPos { get; set; }
        public float yPos { get; set; }
        public float zPos { get; set; }


        public PlayerStatusModel()
        {
            CurrentLevel = 1;
            Hp = 100;
            Coins = 0;
            CoinsToLevelUp = 4;
        }
    }
}