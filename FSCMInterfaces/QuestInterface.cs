using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public interface QuestInterface
    {
        QuestInterface next { get; set; }
        void QuestUpdate(int[] updates);
        string Describe();
    }
}