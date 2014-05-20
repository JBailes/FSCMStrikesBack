using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSCMInterfaces
{
    public interface ActorInterface
    {
        Matrix World { get; }
        Model model { get; set; }
    }
}
