using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSCMInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSCMStrikesBackLogic
{
    public class Actor : ActorInterface
    {
        BoundingBox collisionBox;
        private float x, y, z;
        private Model _model;
        private Matrix rotation = Matrix.Identity;
        private float scale = 1.0f;
        private bool phong;
        protected Matrix[] boneTransforms;
        protected TimeSpan lastCall;
        protected TimeSpan animationElapsedTime;
        protected bool isAnimated;
        protected bool isPaused;

        public Matrix GetWorld()
        {
            return Matrix.CreateScale(scale) * rotation * World;
        }

        public Matrix World
        {
            get { return Matrix.CreateTranslation(new Vector3(X, Y, Z)); }
            // There's no set for World. It doesn't exist as a Vector. See: X, Y, Z
        }
        
        public bool Animated
        {
            get { return isAnimated; }
            set { isAnimated = value; }
        }

        public bool Paused
        {
            get { return isPaused; }
            set { isPaused = value; }
        }

        public Matrix Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Model model
        {
            get { return _model; }
            set
            {
                if (value == null)
                    return;

                _model = value;
                boneTransforms = new Matrix[_model.Bones.Count];
                _model.CopyAbsoluteBoneTransformsTo(boneTransforms);
            }
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public bool Phong
        {
            get { return phong; }
            set { phong = value; }
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

        public void Move(float targetMove, int vector)
        {
            float move;
            if (targetMove > 0)
                move = targetMove + 3.5f;
            else
                move = targetMove + 0.5f;

            float secondaryMove;

            if (targetMove > 0)
                secondaryMove = 2.0f;
            else
                secondaryMove = 2.0f;

            switch (vector)
            {
                case Globals.VECTOR_X:
                    x += move;
                    y += secondaryMove;
                    break;
                case Globals.VECTOR_Y:
                    y += move;
                    x += secondaryMove;
                    break;
                case Globals.VECTOR_Z:
                    z += move;
                    break;
            }//end switch(vector)

            if (findGlobalCollision())
            {
                switch (vector)
                {
                    case Globals.VECTOR_X:
                        x -= move;
                        y -= secondaryMove;
                        break;
                    case Globals.VECTOR_Y:
                        y -= move;
                        x -= secondaryMove;
                        break;
                    case Globals.VECTOR_Z:
                        z -= move;
                        break;
                }//end swithc(vector)
            }//end if(collision)
            else //move > 0
            {
                switch (vector)
                {
                    case Globals.VECTOR_X:
                        x -= move-targetMove;
                        y -= secondaryMove;
                        break;
                    case Globals.VECTOR_Y:
                        y -= move-targetMove;
                        x -= secondaryMove;
                        break;
                    case Globals.VECTOR_Z:
                            z -= 3.5f;
                        break;
                }//end switch(vector)

                int[] updates = {Globals.QUEST_EXPLORE, ((int)x+1)/4, ((int)y+1)/4};
                StateHandler.Quest.QuestUpdate(updates);

                StateInGame.checkCombat(targetMove);
            }//end else move > 0
        }//end move(float, int)

        public void Move(float moveX, float moveY, float moveZ)
        {
            x += moveX;
            y += moveY;
            z += moveZ;

            if (findGlobalCollision())
            {
                x -= moveX;
                y -= moveY;
                z -= moveZ;
            }
            else
                StateInGame.checkCombat(moveX + moveY + moveZ);
        }

        public bool findGlobalCollision()
        {
            
            if (StateHandler.GetSceneList() != null)
            {
                if ((int)y / 4 < 0 || (int)x / 4 < 0)
                    return true;

                if ((int)y / 4 >= MapFactory.map.GetLength(0) || (int)x / 4 >= MapFactory.map.GetLength(1))
                    return true;
   
                if (MapFactory.map[(int)y/4, (int)x/4] != Globals.TILE_PASSABLE && MapFactory.map[(int)y/4, (int)x/4] != Globals.TILE_BOSS)
                    return true;

                /*
                foreach (Actor actor in FSCMStrikesBackLogic.Pulse.getSceneList())
                {
                    if (this != actor)
                    {
                        if (this.DetectCollision(actor))
                        {
                            return true;
                        }
                    }
                }//*/
            }

            return false;
        }

        public virtual bool DetectCollision(Actor toDetect)//work here
        {
            if (collisionBox.Intersects(toDetect.collisionBox))
                return true;

            return false;
        }

        public void MoveX(float move)
        {
            Move(move, Globals.VECTOR_X);
        }

        public void MoveY(float move)
        {
            Move(move, Globals.VECTOR_Y);
        }

        public void MoveZ(float move)
        {
            Move(move, Globals.VECTOR_Z);
        }

        // Be wary of this. It's an absolute! No checking!
        public void setVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public virtual void draw(TimeSpan elapsed)
        {
            if (_model == null || _model.Meshes == null)
                return;

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = GetWorld();
                    effect.View = Camera.View;
                    effect.Projection = Camera.Projection;
                    effect.EnableDefaultLighting();
                    // Removed previous code, went with the API.
                    // Set to True for Phong lighting, False for Gouraud.
                    if (!Phong)
                        effect.PreferPerPixelLighting = false;
                }

                mesh.Draw();
            }
        }
    }
}
