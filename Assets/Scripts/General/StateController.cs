using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateManager
{

    public enum GameState
    {
        Paused,
        Loading,
        Active,
        Start
    }

    public class StateController
    {
        public static GameState CurrentGameState { get; private set; } = GameState.Active;
        public static GameState PreviousGameState { get; private set; } = GameState.Active;

        public static Action<GameState> OnGameStateChange;

        public static void ChangeState(GameState gameState)
        {
            PreviousGameState = CurrentGameState;
            CurrentGameState = gameState;
        }
        /// <summary>
        /// Go to previous state
        /// </summary>
        public static void ChangeState()
        {
            (CurrentGameState, PreviousGameState) = (PreviousGameState, CurrentGameState);
        }
    }
}