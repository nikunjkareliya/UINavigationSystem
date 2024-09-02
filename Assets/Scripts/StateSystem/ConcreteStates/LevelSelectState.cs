using Shared.EventSystem;
using Shared.UINavigationSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.StateSytem
{
    public class LevelSelectState : MonoBehaviour, IGameState
    {
        public int State => GameState.LevelSelect;

        void Start()
        {

        }

        public void EnterState()
        {
            Debug.Log($"Entered to state: <color=cyan>{GameState.HashToName(State)}</color>");
            
            Events.Execute<PanelID, Direction>(EventKeys.PANEL_SHOW, PanelID.LevelSelect, Direction.Left);

            Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.Home, Direction.Left);            
            Events.Execute<PanelID, Direction>(EventKeys.PANEL_HIDE, PanelID.Gameplay, Direction.Right);
        }

        public void ExitState()
        {
            //Events<PanelID, Direction>.Execute(EventKeys.PANEL_HIDE, PanelID.LevelSelect, Direction.Right);
        }

    }
}