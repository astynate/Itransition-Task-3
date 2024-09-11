﻿namespace Itransition_Task_3
{
    public class Move
    {
        public int PlayerMoveIndex { get; private set; }
        public int ComputerMoveIndex { get; private set; }
        public Results Result { get; private set; }
        public ValidationCode Code { get; private set; }

        public Move(int player, int computer, ValidationCode code, int n) 
        {
            PlayerMoveIndex = player;
            ComputerMoveIndex = computer;
            Result = GetMoveResult(player, computer, n);
            Code = code;
        }

        public static Results GetMoveResult(int player, int computer, int n)
        {
            if (player == computer)
            {
                return Results.Draw;
            }

            return ((player + (n >> 1)) % n) < computer ? Results.Win : Results.Lose;
        }
    }
}