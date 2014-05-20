using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SubStateAbstract : StateAbstract, SubStateInterface
    {
        protected StateAbstract parent;

        internal override bool AlternateState()
        {
            return parent.AlternateState();
        }

        internal SubStateAbstract(StateAbstract parent)
        {
            Parent = parent;
        }

        public override StateAbstract Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public override List<Actor> GetSceneList()
        { /* For future reference.
            List<Actor> temp = new List<Actor>();

            temp.AddRange(parent.GetSceneList());

            return temp;*/

            if (parent != null)
                return parent.GetSceneList();
            else
                return null;
        }

        public override MessageBoxInterface[] GetMessageBoxes
        {
            get { return parent.GetMessageBoxes; }
            set { }
        }

        public override void ParentInput(int input)
        {
            parent.ParentInput(input);
        }

        internal override Actor CameraTarget
        {
            get { return Parent.CameraTarget; }
            set { }
        }
    }
}
