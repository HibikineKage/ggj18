using System;
using System.Collections;
using System.Collections.Generic;

namespace ggj2018
{
    public class ScenesDataManager : SimpleSingleton<ScenesDataManager>
    {
        #region Stage

        public int CurrentStageNum { get; private set; }

        public void InitStage()
        {
            CurrentStageNum = 0;
        }

        public void NextStage()
        {
            CurrentStageNum++;
        }

        #endregion

        #region PlayerData

        public enum AnimalType
        {
            Goat
        }

        public class PlayerData
        {
            public AnimalType AnimalType;

            private List<PlayerStageResult> _stages = new List<PlayerStageResult>(GameConstants.StageNum);

            public List<PlayerStageResult> Stages {
                get {
                    return _stages;
                }
            }

            public void AddStage(PlayerStageResult stage)
            {
                _stages.Add(stage);
            }
        }

        public class PlayerStageResult
        {
            public int Rank;
            public int RemainTime;
            public int BadScore;
        }
            
        private PlayerData[] _players;

        public PlayerData GetPlayer(int playerNum) 
        {
            return _players[playerNum];
        }

        public void InitPlayers(AnimalType[] AnimalTypes)
        {
            _players = new PlayerData[GameConstants.PlayerNum];

            for (var i = 0; i < GameConstants.PlayerNum; i++) 
            {
                _players[i].AnimalType = AnimalTypes[i];
            }
        }

        public void AddStageResult(int playerNum, PlayerStageResult stage)
        {
            _players[playerNum].AddStage(stage);
        }

        public int GetCurrentRank()
        {
            int rank = 0;
            foreach (var player in _players)
            {
                if (player.Stages.Count > CurrentStageNum) {
                    rank++;
                }
            }
            return rank;
        }

        public bool IsPlayerGoal(int playerNum)
        {
            return _players[playerNum].Stages.Count > CurrentStageNum;
        }

        public bool IsAllPlayerGoal()
        {
            for (var i = 0; i < GameConstants.PlayerNum; i++)
            {
                if (!IsPlayerGoal(i)) {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}

