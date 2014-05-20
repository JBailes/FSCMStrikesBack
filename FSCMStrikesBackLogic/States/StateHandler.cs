using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    public static class StateHandler
    {
        private static int difficulty;
        private static int delay;
        private static StateAbstract savedState = null;
        private static StateAbstract state;
        private static QuestAbstract quest;
        private static bool paused = false;
        private static Character[] pcs;

        private static bool exit = false;

        public static void Update()
        {
            if (delay > 0)
                delay--;

            state.Update();
        }

        internal static void AddDelay()
        {
            delay = Globals.BUTTON_DELAY;
        }

        internal static void SetDelay(int toSet)
        {
            delay = toSet;
        }

        internal static int GetDelay()
        {
            return delay;
        }

        public static void changeState(StateAbstract newState)
        {
            state = newState;
        }

        internal static int Difficulty
        {
            set { difficulty = value; }
            get { return difficulty; }
        }

        internal static QuestAbstract Quest
        {
            get { return quest; }
            set { quest = value; }
        }

        internal static StateAbstract State
        {
            get { return state; }
            set { state = value; }
        }

        public static StateAbstract SavedState
        {
            get { return savedState; }
            internal set { state = value; }
        }

        public static void initialize()
        {
            state = new StateEngineLogo();
        }

        public static bool Paused
        {
            get { return paused; }
            internal set { paused = value; }
        }
        
        public static float X
        {
            get { return state.X; }
            set { state.X = value; }
        }

        public static float Y
        {
            get { return state.Y; }
            set { state.Y = value; }
        }

        public static float Z
        {
            get { return state.Z; }
            set { state.Z = value; }
        }

        public static float TargetX
        {
            get { return state.TargetX; }
        }

        public static float TargetY
        {
            get { return state.TargetY; }
        }

        public static float TargetZ
        {
            get { return state.TargetZ; }
        }

        internal static bool FocusTarget()
        {
            return state.focusTarget();
        }
        
        internal static Actor CameraTarget
        {
            get { return state.CameraTarget; }
            set { state.CameraTarget = value; }
        }

        public static List<Actor> GetSceneList()
        {
            return state.GetSceneList();
        }

        public static MessageBoxInterface[] GetMessageBoxes()
        {
            return state.GetMessageBoxes;
        }

        public static bool Exit()
        {
            return exit;
        }

        public static void Input(int input)
        {
            if (input == Globals.KEY_EXIT)
                StateHandler.Exit(true);

            if (StateHandler.GetDelay() > 0)
                return;

            if (StateHandler.Paused && input != Globals.KEY_START)
                return;

            StateHandler.State.Input(input);
        }

        public static void interpret_analog(float value, int target)
        {
            if (StateHandler.Paused)
                return;

            StateHandler.State.Input(value, target);
        }

        internal static void Exit(bool toExit)
        {
            exit = toExit;
        }
    }
}
