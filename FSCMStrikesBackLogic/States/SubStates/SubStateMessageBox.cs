using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;

namespace FSCMStrikesBackLogic
{
    class SubStateMessageBox : SubStateAbstract
    {
        protected MessageBoxInterface[] messageBoxes;

        internal SubStateMessageBox(StateAbstract parent)
            : base(parent)
        {
        }

        public override MessageBoxInterface[] GetMessageBoxes
        {
            get
            {
                MessageBoxInterface[] temp;
                if (parent != null)
                    temp = Parent.GetMessageBoxes;
                else
                    temp = null;

                MessageBoxInterface[] toReturn = null;

                if (temp != null)
                {
                    toReturn = new MessageBoxInterface[temp.Length + messageBoxes.Length];

                    for (int i = 0; i < temp.Length; i++)
                        toReturn[i] = temp[i];

                    if (messageBoxes != null)
                    {
                        for (int i = 0; i < messageBoxes.Length; i++)
                            toReturn[temp.Length + i] = messageBoxes[i];
                    }
                }
                else if (messageBoxes != null)
                {
                    return messageBoxes;
                }

                return toReturn;
            }

            set
            {
                messageBoxes = value;
            }
        }

        internal override Actor CameraTarget
        {
            get { return Parent.CameraTarget; }
            set {  }
        }
    }
}
