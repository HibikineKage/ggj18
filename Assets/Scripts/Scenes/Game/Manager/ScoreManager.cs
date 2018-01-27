using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ggj2018
{
    public class ScoreManager : MonoSingleton<ScoreManager>
    {
        private int[] _badScores = new int[GameConstants.PlayerNum];
            
        public int GetBadScore(int playerNum)
        {
            return _badScores[playerNum];
        }

        public void AddBadScore(int playerNum, int addValue)
        {
            _badScores[playerNum] =  _badScores[playerNum] + addValue;
        }
    }
}

