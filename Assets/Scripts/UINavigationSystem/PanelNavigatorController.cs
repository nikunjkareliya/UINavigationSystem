using DG.Tweening;
using Shared.EventSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.UINavigationSystem
{
    public class PanelNavigatorController : MonoBehaviour
    {
        //[SerializeField] private PanelID _startPanelID;
        [SerializeField] private List<PanelModel> _panels;

        [SerializeField] private float _transitionDuration = 0.5f;
        private Stack<PanelModel> _navigationHistory = new Stack<PanelModel>();

        private void Start()
        {
            HideAllPanels();
            //ShowPanel(_startPanelID, Direction.Left);
        }

        private void Awake()
        {
            Events<PanelID, Direction>.Register(EventKeys.PANEL_SHOW, ShowPanel);
            Events<PanelID, Direction>.Register(EventKeys.PANEL_HIDE, HidePanel);
        }

        private void OnDestroy()
        {
            Events<PanelID, Direction>.Unregister(EventKeys.PANEL_SHOW, ShowPanel);
            Events<PanelID, Direction>.Unregister(EventKeys.PANEL_HIDE, HidePanel);
        }

        private void ShowPanel(PanelID panelID, Direction fromDirection)
        {
            Vector2 startPos = Vector2.zero;
            Vector2 destinationPos = Vector2.zero;
            switch (fromDirection)
            {
                case Direction.Up:
                    startPos = new Vector2(0, -Screen.height);
                    break;
                case Direction.Down:
                    startPos = new Vector2(0, Screen.height);
                    break;
                case Direction.Right:
                    startPos = new Vector2(-Screen.width, 0);
                    break;
                case Direction.Left:
                    startPos = new Vector2(Screen.width, 0);
                    break;
            }

            if (_panels.Exists(x => x.ID == panelID))
            {
                PanelModel panelModel = _panels.Find(x => x.ID == panelID);

                if (fromDirection == Direction.None)
                {
                    panelModel.Panel.anchoredPosition = destinationPos;
                }
                else
                {
                    panelModel.Panel.anchoredPosition = startPos;
                    panelModel.Panel.DOAnchorPos(destinationPos, _transitionDuration).OnComplete(() =>
                    {

                    });
                }
                _navigationHistory.Push(panelModel);
            }

        }

        private void HidePanel(PanelID panelID, Direction toDirection)
        {
            Vector2 startPos = Vector2.zero;
            Vector2 destinationPos = Vector2.zero;
            switch (toDirection)
            {
                case Direction.Up:
                    destinationPos = new Vector2(0, Screen.height);
                    break;
                case Direction.Down:
                    destinationPos = new Vector2(0, -Screen.height);
                    break;
                case Direction.Right:
                    destinationPos = new Vector2(Screen.width, 0);
                    break;
                case Direction.Left:
                    destinationPos = new Vector2(-Screen.width, 0);
                    break;
                case Direction.None:
                    destinationPos = new Vector2(Screen.width, 0);
                    break;
            }

            if (_panels.Exists(x => x.ID == panelID))
            {
                PanelModel panelModel = _panels.Find(x => x.ID == panelID);

                if (toDirection == Direction.None)
                {
                    panelModel.Panel.anchoredPosition = destinationPos;
                }
                else
                {
                    panelModel.Panel.anchoredPosition = startPos;
                    panelModel.Panel.DOAnchorPos(destinationPos, _transitionDuration).OnComplete(() =>
                    {

                    });
                }

                if (_navigationHistory.Count > 0)
                {
                    _navigationHistory.Pop();
                }
            }

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ShowPanel(PanelID.Home, Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                HidePanel(PanelID.Home, Direction.Right);
            }
        }

        private void HideAllPanels()
        {
            if (_panels.Count > 0)
            {
                for (int i = 0; i < _panels.Count; i++)
                {
                    HidePanel(_panels[i].ID, Direction.None);
                }
            }
        }

    }

    [System.Serializable]
    public class PanelModel
    {
        [SerializeField] private PanelID _id;
        public PanelID ID => _id;

        [SerializeField] private RectTransform _panel;
        public RectTransform Panel => _panel;

        [SerializeField] private RectTransform _content;
        public RectTransform Content => _content;

        [SerializeField] private RectTransform _background;
        public RectTransform Background => _background;
    }
}