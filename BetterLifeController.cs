using Mafi;
using Mafi.Core;
using Mafi.Core.GameLoop;
using Mafi.Unity;
using Mafi.Unity.InputControl;
using System;
using UnityEngine;


namespace BetterLife.UI
{
//    public class BetterLifeController : WindowController<vehPropertyWindows>
//    {
//        //private readonly ToolbarController _toolbarController;
//        private readonly KeyBindings WindowKey = KeyBindings.FromKey(KbCategory.General, ShortcutMode.Game, KeyCode.F6);
//        private bool windowOpen = false;
//        private ShortcutsManager _shortcutsManager;
//        private vehPropertyWindows _window;

//        public BetterLifeController(
//            IUnityInputMgr inputManager,
//            IGameLoopEvents gameLoop,
//            vehPropertyWindows window,
//            ShortcutsManager shortcutsManager,
//            UiBuilder builder)
//                    : base(inputManager, gameLoop, builder, window)
//        {
//            _shortcutsManager = shortcutsManager;
//            _window = window;
//            inputManager.RegisterGlobalShortcut((Func<ShortcutsManager, KeyBindings>)(m => { return WindowKey; }), this);
//        }

//        public override void Activate()
//        {
//            windowOpen = true;

//            base.Activate();
//            _window.Show();
//        }

//        public override void Deactivate()
//        {
//            windowOpen = false;
//            _window.Hide();
//            base.Deactivate();
//        }
//    }
}

