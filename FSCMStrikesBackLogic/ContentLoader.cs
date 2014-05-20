using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;

namespace FSCMStrikesBackLogic
{
    public static class ContentLoader
    {
        static ContentManager content;

        public static void onLoad(ContentManager Content)
        {
            content = Content;
        }

        public static Model getModel(string modelToGet)
        {
            //try
           // {
                return content.Load<Model>(modelToGet);/*
            }
            catch
            {
                return content.Load<Model>("oldman");
            }*/
        }
    }
}
