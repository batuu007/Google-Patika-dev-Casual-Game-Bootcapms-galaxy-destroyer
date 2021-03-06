namespace SpaceShooterProject.UserInterface.Market{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    public class ChestAnimation : MonoBehaviour
    {
        private Animator animator;

        public void Initialize()
        {
            animator = GetComponent<Animator>();
            animator.SetBool("isOpening", false);
        }

        public void OpenChest(){
            animator.SetBool("isOpening",true);
        }
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        internal void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
