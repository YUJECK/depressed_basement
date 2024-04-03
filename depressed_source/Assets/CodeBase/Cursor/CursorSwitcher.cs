using System;
using CodeBase.Inputs;
using UnityEngine;

namespace CodeBase.CursorLogic
{
    public static class CursorSwitcher
    {
        private static readonly CursorConfig Config;
        private static CursorState _currentCursor;

        private static bool _mouseDown = false;
        
        static CursorSwitcher()
        {
            Config = Resources.Load<CursorConfig>("Configs/CursorConfig");
                
            InputsHandler.OnLeftMouseButtonDown += OnDown;
            InputsHandler.OnLeftMouseButtonUp += OnUp;
        }

        private static void OnDown()
        {
            _mouseDown = true;
            Cursor.SetCursor(_currentCursor.OnClick, Vector2.zero, CursorMode.Auto);
        }

        private static void OnUp()
        {
            _mouseDown = false;
            Cursor.SetCursor(_currentCursor.Default, Vector2.zero, CursorMode.Auto);
        }

        public static void SwitchToDefault()
        {
            SwitchTo(Config.Default);
        }
        
        public static void SwitchToFight()
        {
            SwitchTo(Config.Fight);
        }
        
        public static void SwitchToInteractions()
        {
            SwitchTo(Config.Interaction);
        }
        
        private static void SwitchTo(CursorState state)
        {
            if (state != _currentCursor)
            {
                if(_mouseDown)
                {
                    Cursor.SetCursor(state.OnClick, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(state.Default, Vector2.zero, CursorMode.Auto);    
                }
                
                _currentCursor = state;
            }
        }
    }

    [Serializable]
    public sealed class CursorState
    {
        public Texture2D Default;
        public Texture2D OnClick;
    }
}