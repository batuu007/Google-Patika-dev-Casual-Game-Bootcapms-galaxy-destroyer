namespace SpaceShooterProject.AI
{
    using System.Collections;
    using System.Collections.Generic;
    using Devkit.HSM;
    using SpaceShooterProject.AI.Enemies;
    using SpaceShooterProject.AI.State;
    using UnityEngine;

    public class AITestGame : MonoBehaviour
    {
        private HelicopterEventContainer helicopterEventContainer;
        private HelicopterMainState helicopterMainState;

        [SerializeField]
        Helicopter helicopter;
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("Merhaba");
            helicopter.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            helicopter.helicopterMainState.Update();
        }
    }
}

