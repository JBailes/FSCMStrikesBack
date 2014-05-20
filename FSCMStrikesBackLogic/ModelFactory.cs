using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace FSCMStrikesBackLogic
{
    static class ModelFactory
    {
        static List<ModelKey> models = new List<ModelKey>();

        public static Model loadModel(string toLoad)
        {
            ModelKey temp = models.FirstOrDefault(new ModelKey(toLoad).Equals);

            if (temp != null)
                return temp.model;

            temp = new ModelKey(toLoad, ContentLoader.getModel(@"Models\"+toLoad));

            models.Add(temp);

            return temp.model;
        }
    }
}