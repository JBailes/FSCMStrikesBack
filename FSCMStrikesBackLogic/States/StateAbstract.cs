using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    public abstract class StateAbstract : StateInterface
    {
        protected bool fresh = true;
        protected Actor cameraTarget;
        protected float x = 0;
        protected float y = 0;
        protected float z = 0;
        protected float rotationX = 0;
        protected float rotationY = 0;
        protected float rotationZ = 0;

        public virtual StateAbstract Parent
        {
            get
            {
                return null;
            }
            set { }
        }

        public virtual void Update()
        {
            if (Parent != null)
                Parent.Update();
        }

        public virtual void Input(int input)
        {
        }

        public virtual void Input(float input, int target)
        {
        }

        internal virtual bool AlternateState()
        {
            return false;
        }

        public virtual void ParentInput(int input)
        {
        }

        public virtual List<Actor> GetSceneList()
        {
            return null;
        }

        public virtual MessageBoxInterface[] GetMessageBoxes
        {
            get { return null; }
            set { }
        }

        public virtual bool focusTarget()
        {
            return true;
        }

        public virtual float X
        {
            get { return x; }
            set { x = value; }
        }

        public virtual float Y
        {
            get { return y; }
            set { y = value; }
        }

        public virtual float Z
        {
            get { return z; }
            set { z = value; }
        }

        public virtual float RotationX
        {
            get { return rotationX; }
            set { rotationX = value; }
        }

        public virtual float RotationY
        {
            get { return rotationY; }
            set { rotationY = value; }
        }

        public virtual float RotationZ
        {
            get { return rotationZ; }
            set { rotationZ = value; }
        }

        public virtual float TargetX
        {
            get
            {
                if (cameraTarget == null)
                    return 5;
                else
                    return cameraTarget.X;
            }
        }

        public virtual float TargetY
        {
            get 
            { 
                if (cameraTarget == null)
                    return 5;
                else
                    return cameraTarget.Y; 
            }
        }

        public virtual float TargetZ
        {
            get 
            { 
                if (cameraTarget == null)
                    return 5;
                else
                    return cameraTarget.Z; 
            }
        }

        protected virtual void refresh()
        {
        }

        internal virtual Actor CameraTarget
        {
            get { return cameraTarget; }
            set { cameraTarget = value; }
        }
    }
}
