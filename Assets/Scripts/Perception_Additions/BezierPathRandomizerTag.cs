using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
using Random = UnityEngine.Random;

// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.

[Serializable]
[AddRandomizerMenu("Perception/RandomizerTags/Bezier Path Randomizer")]
[RequireComponent(typeof(TrackFollowingRandomizer))]
public class BezierPathRandomizerTag : RandomizerTag
{
    public Vector2 positionOffsetRange;
    public bool randomInvert;
}

[Serializable]
[AddRandomizerMenu("Perception/Bezier Path Randomizer")]
public class BezierPathRandomizer : Randomizer
{
    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<BezierPathRandomizerTag>();
        foreach (var tag in tags)
        {
            var follower = tag.GetComponent<TrackFollowingRandomizer>();
            float timeStep = Random.value;
            Vector3 targetPos = follower.pathCreator.path.GetPointAtTime(timeStep);
            tag.transform.position = targetPos;

            float randomPosition = Random.Range(tag.positionOffsetRange.x, tag.positionOffsetRange.y);
            
            tag.transform.localPosition += new Vector3(randomPosition, 0.0f, 0.0f);

            Quaternion targetRot = follower.pathCreator.path.GetRotation(timeStep);

            var resultRotation = targetRot.eulerAngles;
            if (tag.randomInvert && Random.value <= 0.5f)
            {
                resultRotation += new Vector3(0.0f, 180.0f, 0.0f);
            }
            
            tag.transform.localRotation = Quaternion.Euler(resultRotation);
            
        }
    }
}
