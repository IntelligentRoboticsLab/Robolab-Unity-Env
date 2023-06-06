using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class RandomizeGameObjects:MonoBehaviour
    {
        public List<GameObject> gameObjects;

        public void Step()
        {
            int newIdx = Random.Range(0, gameObjects.Count);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                var target = gameObjects[i];
                target.SetActive(false);
                if(i == newIdx) target.SetActive(true);
            }
        }
    }
}