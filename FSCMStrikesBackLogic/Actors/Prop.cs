using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSCMStrikesBackLogic
{
    public class Prop : Actor
    {

        internal void startAnimation()
        {
        }

        internal void stopAnimation()
        {
        }

        public override void draw(TimeSpan elapsed)
        {
            if (model == null || model.Meshes == null)
                return;

            if (!isPaused)
            {
                animationElapsedTime += elapsed - lastCall;
            }

            lastCall = elapsed;

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    //if (boneTransforms != null)
                      //  effect.SetBoneTransforms(boneTransforms);

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
