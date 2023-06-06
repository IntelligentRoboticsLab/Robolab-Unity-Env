using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
using Random = UnityEngine.Random;

// Add this Component to any GameObject that you would like to be randomized. This class must have an identical name to
// the .cs file it is defined in.

[Serializable]
[AddRandomizerMenu("Perception/RandomizerTags/Game Object Randomizer")]
[RequireComponent(typeof(RandomizeGameObjects))]
public class GameObjectRandomizerTag : RandomizerTag {}

[Serializable]
[AddRandomizerMenu("Perception/Game Object Randomizer")]
public class GameObjectRandomizer : Randomizer
{
    // Sample FloatParameter that can generate random floats in the [0,360) range. The range can be modified using the
    // Inspector UI of the Randomizer.

    protected override void OnIterationStart()
    {
        var tags = tagManager.Query<GameObjectRandomizerTag>();
        foreach (var tag in tags)
        {
            var gameObjRandomizer = tag.GetComponent<RandomizeGameObjects>();
            gameObjRandomizer.Step();
        }
    }
}