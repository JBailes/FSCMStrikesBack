using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

// This was blatantly swiped from a Microsoft XNA tutorial.
// TODO: Rewrite from scratch.

namespace FSCMStrikesBackLogic
{
    class AnimationClip
    {
        public AnimationClip(TimeSpan duration, List<Keyframe> keyframes)
        {
            Duration = duration;
            Keyframes = keyframes;
        }

        private AnimationClip()
        {
        }

        [ContentSerializer]
        public TimeSpan Duration { get; private set; }

        [ContentSerializer]
        public List<Keyframe> Keyframes { get; private set; }
    }
}
