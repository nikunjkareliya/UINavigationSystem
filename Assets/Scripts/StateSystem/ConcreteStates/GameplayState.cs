using Shared.EventSystem;
using Shared.UINavigationSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.StateSytem
{
    public class GameplayState : MonoBehaviour, IGameState
    {
        public int State => GameState.Gameplay;

        void Start()
        {

        }

        public void EnterState()
        {
            Debug.Log($"Entered to state: <color=cyan>{GameState.HashToName(State)}</color>");

            Events.Execute<PanelID, Direction>(EventKeys.PANEL_SHOW, PanelID.Gameplay, Direction.Left);

            Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.Home, Direction.Left);
            Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.LevelSelect, Direction.Left);
        }

        public void ExitState()
        {

        }

    }
}