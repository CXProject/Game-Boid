using UnityEngine;

namespace GameBoids
{
    public class GameBoidsManager : MonoBehaviour
    {
        public static GameBoidsManager Instance { get; private set; }
        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }
            Instance = this;
        }
    }
}

