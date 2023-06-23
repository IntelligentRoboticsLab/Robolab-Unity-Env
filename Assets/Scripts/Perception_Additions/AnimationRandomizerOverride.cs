using System;
using System.IO;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers.Tags;
using UnityEngine.Perception.Randomization.Samplers;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Perception.Randomization.Randomizers
{
    /// <summary>
    /// Chooses a random of frame of a random clip for a game object
    /// The Override Always Starts at Frame 0!
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Animation Randomizer Override")]
    public class AnimationRandomizerOverride : Randomizer
    {
        const string k_ClipName = "PlayerIdle";
        const string k_StateName = "Base Layer.RandomState";
        const string path = "D:/UserProjects/Joey/Unity/Robolab-Unity-Env/Datasets/animations_played.txt";
        private int count = 0;
        
        UniformSampler m_Sampler = new UniformSampler();

        void RandomizeAnimation(AnimationRandomizerTag tag)
        {
            if (!tag.gameObject.activeInHierarchy)
                return;

            var animator = tag.gameObject.GetComponent<Animator>();
            animator.applyRootMotion = tag.applyRootMotion;
            
            var overrider = tag.animatorOverrideController;
            if (overrider != null && tag.animationClips.Count > 0)
            {
                overrider[k_ClipName] = tag.animationClips.Sample();
                WriteToAnimationAnnotationFile($"{count}: {overrider[k_ClipName].name}");
                animator.speed = 0.2f;
                animator.Play(k_StateName, -1, 0);
            }

            count++;
        }

        private void WriteToAnimationAnnotationFile(string name)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(name);
            }
        }

        /// <inheritdoc/>
        protected override void OnIterationStart()
        {
            var taggedObjects = tagManager.Query<AnimationRandomizerTag>();
            foreach (var taggedObject in taggedObjects)
            {
                RandomizeAnimation(taggedObject);
            }
        }
    }
}