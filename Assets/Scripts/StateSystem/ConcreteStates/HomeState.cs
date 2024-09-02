using Shared.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shared.UINavigationSystem;

namespace Shared.StateSytem
{
    public class HomeState : MonoBehaviour, IGameState
    {
        public int State => GameState.Home;

        void Start()
        {

        }

        public void EnterState()
        {
            Debug.Log($"Entered to state: <color=cyan>{GameState.HashToName(State)}</color>");

            Events.Execute<PanelID, Direction>(EventKeys.PANEL_SHOW, PanelID.Home, Direction.Left);
            Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.LevelSelect, Direction.Right);
            Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.Gameplay, Direction.Right);            
        }

        public void ExitState()
        {
            //Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.Home, Direction.Left);
        }

    }
}