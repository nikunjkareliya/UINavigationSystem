using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Shared.EventSystem;

namespace Shared.StateSytem
{
    public class GameStateController : MonoBehaviour
    {        
        private IGameState _currentState;
        public IGameState CurrentState => _currentState;

        private IGameState _previousState;

        public List<IGameState> _gameStates = new List<IGameState>();
        [SerializeField] private List<Transform> _gameStateObjects;

        private void Awake()
        {            
            // Initialize game states list
            for (int i = 0; i < _gameStateObjects.Count; i++)
            {                
                IGameState gameState = _gameStateObjects[i].GetComponent<IGameState>();
                _gameStates.Add(gameState);
            }

            Events<int>.Register(EventKeys.GAME_STATE_CHANGED, ChangeState);
        }

        private void OnDestroy()
        {
            Events<int>.Unregister(EventKeys.GAME_STATE_CHANGED, ChangeState);
        }

        private void ChangeState(int newState)
        {            
            if (_currentState != null)
            {
                // Catch previous state before changing to new state
                _previousState = _currentState;

                _currentState?.ExitState();
                Events<int>.Execute(EventKeys.GAME_STATE_EXITED, _currentState.State);
            }

            IGameState gameState = GetGameState(newState);
            _currentState = gameState;

            _currentState.EnterState();
            Events<int>.Execute(EventKeys.GAME_STATE_ENTERED, _currentState.State);
        }

        private IGameState GetGameState(int state)
        {            
            if (_gameStates.Exists(x => x.State == state))
            {
                IGameState gameState = _gameStates.Find(x => x.State == state);
                return gameState;
            }
            Debug.LogWarning($"No state found named {GameState.HashToName(state)}!");
            return null;
        }

        // ---- FOR TESTING PURPOSE ONLY ----
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {                
                Events<int>.Execute(EventKeys.GAME_STATE_CHANGED, GameState.Home);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Events<int>.Execute(EventKeys.GAME_STATE_CHANGED, GameState.LevelSelect);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Events<int>.Execute(EventKeys.GAME_STATE_CHANGED, GameState.Gameplay);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"Current State -> {GameState.HashToName(_currentState.State)}");
            }
        }

    }
}