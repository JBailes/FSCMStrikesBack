using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace FSCMStrikesBackLogic
{
    class ModelKey : IEquatable<ModelKey>
    {
        private string _name;
        private Model _model;

        public ModelKey(string name)
        {
            _name = name;
        }
        
        public ModelKey(string name, Model __model)
        {
            _name = name;
            _model = __model;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Model model
        {
            get { return _model; }
            set 
            { 
                _model = value;
            }
        }

        public bool Equals(ModelKey toCompare)
        {
            if (this._name == toCompare._name)
                return true;

            return false;
        }
    }
}
