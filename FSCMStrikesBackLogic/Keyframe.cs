using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

// This was blatantly swiped from a Microsoft XNA tutorial.
// TODO: Rewrite from scratch.

namespace FSCMStrikesBackLogic
{
    class Keyframe
    {
        public Keyframe(int bone, TimeSpan time, Matrix transform)
        {
            Bone = bone;
            Time = time;
            Transform = transform;
        }

        private Keyframe()
        {
        }

        [ContentSerializer]
        public int Bone { get; private set; }

        [ContentSerializer]
        public TimeSpan Time { get; private set; }

        [ContentSerializer]
        public Matrix Transform { get; private set; }
    }
}
