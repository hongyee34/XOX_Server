﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class LittleRobot : Building
    {
        public LittleRobot(string color, (int x, int y) index, int dir) {
            grade = 1;
            cost = 3;
            synergy = "Machine";
            delayTime = 1.5f;
            AttackDirectionList.Add((1, 1));

            maxHP = _currentHP = 900;
            power = 50;
            attackSpeed = 1.2f;

            objectPosition = Extensions.ConvertIndexToPosition(index);
            teamColor = color;
            direction = dir;

            RunCard();
        }

        protected override async void RunCard()
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
            TurnDirection();
            SetTargetList();
            Attack();
        }
    }
}
