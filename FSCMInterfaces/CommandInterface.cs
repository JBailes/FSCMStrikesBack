using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSCMInterfaces
{
    public interface CommandInterface
    {
        string name();
        int execute();
    }
}
