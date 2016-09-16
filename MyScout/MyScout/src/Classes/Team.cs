﻿using System;
using System.Collections.Generic;

namespace MyScout
{
    /// <summary>
    /// This defines the "Team" type variable.
    /// </summary>
    public class Team
    {
        #region Variables
        #region Constants
        /// <summary>
        /// The name of the team (E.G. "Channel Cats").
        /// </summary>
        public string name = "NO NAME LOADED";
        /// <summary>
        /// The id of the team (E.G. "1094").
        /// </summary>
        public int id = 0000;
        #endregion

        private List<DataPoint> dataset;
        private List<DataPoint> scoreDataset;

        /// <summary>
        /// The team's total score.
        /// </summary>
        public int avgScore = 0;

        public List<DataPoint> GetTeamSpecificDataset()
        {
            return dataset;
        }

        public List<DataPoint> GetCompiledTeamDataset()
        {
            return scoreDataset;
        }

        #endregion

        /// <summary>
        /// TODO: Documentation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Team(int id, string name)
        {
            this.id = id;
            this.name = name;
            InitData();
        }

        public void InitData()
        {
            //CalcCrossingPower();
            //CalcAvgScore();
            dataset = Program.dataset[0];
            scoreDataset = Program.dataset[2];
        }

        /// <summary>
        /// Calculate and save the total score based on the point values
        /// for each scoring opportunity. Point values are from the official rules
        /// </summary>
        //public int CalcAvgScore()
        //{
        //    avgScore = 0;
        //    avgScore = Convert.ToInt16(
        //        autoDefensesReached * 2 +
        //        autoHighGoals * 10 +
        //        autoLowGoals * 5 +
        //        teleHighGoals * 5 +
        //        teleLowGoals * 2 +
        //        towersScaled * 15
        //        );

        //    foreach (int times in defensesCrossed)
        //    {
        //        avgScore += times * 5;
        //    }
        //    foreach (int times in autoDefensesCrossed)
        //    {
        //        avgScore += times * 10;
        //    }

        //    return avgScore;
        //}

        /// <summary>
        /// Calculate and save the crossing power based on the difficulty
        /// of circumventing defenses.
        /// </summary>
        //public int CalcCrossingPower()
        //{
        //    crossingPowerScore = 0;
        //    for(int i = 0; i < 8; i++)
        //    {
        //        if (defensesCrossable[i])
        //        {
        //            switch (i)
        //            {
        //                case 0: //portcullis
        //                    crossingPowerScore += 4;
        //                    break;

        //                case 1: //cheval de frise
        //                    crossingPowerScore += 4;
        //                    break;

        //                case 2: //moat
        //                    crossingPowerScore += 3;
        //                    break;

        //                case 4: //drawbridge
        //                    crossingPowerScore += 3;
        //                    break;

        //                case 8: //low bar
        //                    crossingPowerScore += 1;
        //                    break;

        //                default:
        //                    crossingPowerScore += 2;
        //                    break;
        //            }
        //        }
        //    }
        //    return crossingPowerScore;
        //}

        /// <summary>
        /// Updates defensesCrossable[] with data from defensesCrossed[]
        /// </summary>
        //public void updateDefenseStats()
        //{
        //    for(int i = 0; i < 9; i++)
        //    {
        //        defensesCrossable[i] = defensesCrossable[i] ? true : defensesCrossed[i] > 0;
        //    }
        //}
    }
}
