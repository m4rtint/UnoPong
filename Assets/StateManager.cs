using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MPHT
{
    public enum State
    {
        PREGAME,
        GAME,
        PAUSE,
        ENDGAME
    }

    public static class StateManager
    {
        private static State _state = State.PREGAME;
        public static State State => _state;

        public static void PlayGame()
        {
            _state = State.GAME;
        }

        public static bool IsInGame()
        {
            return _state == State.GAME;
        }

        public static bool IsPaused()
        {
            return _state == State.PAUSE;
        }
    }
}

