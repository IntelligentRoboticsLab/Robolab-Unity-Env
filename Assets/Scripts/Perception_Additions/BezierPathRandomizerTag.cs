using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
using Random = UnityEngine.Random;

// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.

[Serializable]
[AddRandomizerMenu("Perception/RandomizerTags/Bezier Path Randomizer")]
[RequireComponent(typeof(TrackFollowingRandomizer))]
public class BezierPathRandomizerTag : RandomizerTag {}

[Serializable]
[AddRandomizerMenu("Perception/Bezier Path Randomizer")]
public class BezierPathRandomizer : Randomizer
{
    // Sample FloatParameter that can generate random floats in the [0,360) range. The range can be modified using the
    // Inspector UI of the Randomizer.

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<BezierPathRandomizerTag>();
        foreach (var tag in tags)
        {
            var follower = tag.GetComponent<TrackFollowingRandomizer>();

            float timeStep = Random.value;
            Vector3 targetPos = follower.pathCreator.path.GetPointAtTime(timeStep);
            tag.transform.position = targetPos;
        
            Quaternion targetRot = follower.pathCreator.path.GetRotation(timeStep);
            tag.transform.localRotation = targetRot;
        }
    }
}
