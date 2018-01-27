using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public class PlayerData
        {
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

        public PlayerStageResult GetPlayerStage(int playerNum) 
        {
            return _players[playerNum].Stages[CurrentStageNum];
        }

        public void InitPlayers()
        {
            _players = new PlayerData[GameConstants.PlayerNum];
            for (var i = 0; i < GameConstants.PlayerNum; i++) {
                _players[i] = new PlayerData();
            }
        }

        public void AddStageResult(int playerNum, PlayerStageResult stage)
        {
            _players[playerNum].AddStage(stage);

            Debug.LogFormat("Result[{0}] Rank[{1}] RemainTime[{2}] BadScore[{3}]", playerNum, stage.Rank, stage.RemainTime, stage.BadScore);
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

