using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

// This was blatantly swiped from a Microsoft XNA tutorial.
// TODO: Rewrite from scratch.

namespace FSCMStrikesBackLogic
{
    class AnimationPlayer
    {
        AnimationClip currentClipValue;
        TimeSpan currentTimeValue;
        int currentKeyframe;
        Matrix[] boneTransforms;
        Matrix[] worldTransforms;
        Matrix[] skinTransforms;
        SkinningData skinningDataValue;

        public AnimationPlayer(SkinningData skinningData)
        {
            if (skinningData == null)
                throw new ArgumentNullException("skinningData");

            skinningDataValue = skinningData;

            boneTransforms = new Matrix[skinningData.BindPose.Count];
            worldTransforms = new Matrix[skinningData.BindPose.Count];
            skinTransforms = new Matrix[skinningData.BindPose.Count];
        }

        public void StartClip(AnimationClip clip)
        {
            if (clip == null)
                throw new ArgumentNullException("clip");

            currentClipValue = clip;
            currentTimeValue = TimeSpan.Zero;
            currentKeyframe = 0;

            skinningDataValue.BindPose.CopyTo(boneTransforms, 0);
        }

        public void Update(TimeSpan time, bool relativeToCurrentTime,
                           Matrix rootTransform)
        {
            UpdateBoneTransforms(time, relativeToCurrentTime);
            UpdateWorldTransforms(rootTransform);
            UpdateSkinTransforms();
        }

        public void UpdateBoneTransforms(TimeSpan time, bool relativeToCurrentTime)
        {
            if (currentClipValue == null)
                throw new InvalidOperationException(
                            "AnimationPlayer.Update was called before StartClip");

            if (relativeToCurrentTime)
            {
                time += currentTimeValue;

                while (time >= currentClipValue.Duration)
                    time -= currentClipValue.Duration;
            }

            if ((time < TimeSpan.Zero) || (time >= currentClipValue.Duration))
                throw new ArgumentOutOfRangeException("time");

            if (time < currentTimeValue)
            {
                currentKeyframe = 0;
                skinningDataValue.BindPose.CopyTo(boneTransforms, 0);
            }

            currentTimeValue = time;

            IList<Keyframe> keyframes = currentClipValue.Keyframes;

            while (currentKeyframe < keyframes.Count)
            {
                Keyframe keyframe = keyframes[currentKeyframe];

                if (keyframe.Time > currentTimeValue)
                    break;

                boneTransforms[keyframe.Bone] = keyframe.Transform;

                currentKeyframe++;
            }
        }

        public void UpdateWorldTransforms(Matrix rootTransform)
        {
            worldTransforms[0] = boneTransforms[0] * rootTransform;

            for (int bone = 1; bone < worldTransforms.Length; bone++)
            {
                int parentBone = skinningDataValue.SkeletonHierarchy[bone];

                worldTransforms[bone] = boneTransforms[bone] *
                                             worldTransforms[parentBone];
            }
        }

        public void UpdateSkinTransforms()
        {
            for (int bone = 0; bone < skinTransforms.Length; bone++)
            {
                skinTransforms[bone] = skinningDataValue.InverseBindPose[bone] *
                                            worldTransforms[bone];
            }
        }

        public Matrix[] GetBoneTransforms()
        {
            return boneTransforms;
        }

        public Matrix[] GetWorldTransforms()
        {
            return worldTransforms;
        }

        public Matrix[] GetSkinTransforms()
        {
            return skinTransforms;
        }

        public AnimationClip CurrentClip
        {
            get { return currentClipValue; }
        }

        public TimeSpan CurrentTime
        {
            get { return currentTimeValue; }
        }
    }
}
