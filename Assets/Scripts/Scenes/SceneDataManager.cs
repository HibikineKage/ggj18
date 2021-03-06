﻿using System;
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
            public enum AnimalType
            {
                goat,
                dobe,
                cat,
                penguin
            }
            AnimalType _animalType;

            public void SetAnimalType(AnimalType type)
            {
                _animalType = type;
            }

            private List<PlayerStageResult> _stages = new List<PlayerStageResult>(GameConstants.StageNum);

            public List<PlayerStageResult> Stages {
                get {
                    return _stages;
                }
            }

            public void AddStage(PlayerStageResult stage)
            {
                var score = 1000 / stage.Rank * 1.5f;
                if (score <= 200) {
                    stage.Level = 0;
                }
                else if (score <= 400) {
                    stage.Level = 1;
                }
                else if (score <= 600) {
                    stage.Level = 2;
                }
                else if (score <= 800) {
                    stage.Level = 3;
                }
                else if (score < 1000) {
                    stage.Level = 4;
                }
                else {
                    stage.Level = 5;
                }
                _stages.Add(stage);
            }
        }

        public class PlayerStageResult
        {
            public int Rank;
            public int RemainTime;
            public int Damage;
            public int Level;
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

        public bool IsInitPlayers {
            get {
                return _players != null;
            }
        }

        public void AddStageResult(int playerNum, PlayerStageResult stage)
        {
            _players[playerNum].AddStage(stage);

            Debug.LogFormat("Result[{0}] Level[{1}] Rank[{2}] RemainTime[{3}] Damage[{4}]", playerNum, stage.Level, stage.Rank, stage.RemainTime, stage.Damage);
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
            return rank + 1;
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

