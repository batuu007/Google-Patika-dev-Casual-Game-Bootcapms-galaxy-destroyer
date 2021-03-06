namespace SpaceShooterProject.UserInterface 
{
    using Devkit.Base.Component;
    using Devkit.Base.Object;
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Canvas))]
    public abstract class BaseCanvas : MonoBehaviour
    {
        public delegate void ReturnToMainMenuDelegate();
        public event ReturnToMainMenuDelegate OnReturnToMainMenu;

        private Canvas canvasComponent = null;
        [SerializeField]
        private ICanvasElement[] canvasElements;    

        protected ComponentContainer componentContainer;


        public void Initialize(ComponentContainer componentContainer)
        {
            this.componentContainer = componentContainer;
            canvasComponent = this.GetComponent<Canvas>();
            canvasElements = transform.GetComponentsInChildren<ICanvasElement>();

            PreInit();
            Init();
        }

        public Canvas GetCanvasComponent()
        {
            return canvasComponent;
        }

        public void Activate()
        {
            canvasComponent.enabled = true;

            for (int i = 0; i < canvasElements.Length; i++)
            {
                if (canvasElements[i] != null)
                {
                    canvasElements[i].Activate();
                }
            }

        }

        public void Deactivate()
        {
            canvasComponent.enabled = false;

            for (int i = 0; i < canvasElements.Length; i++)
            {
                if (canvasElements[i] != null)
                {
                    canvasElements[i].Deactivate();
                }
            }

        }

        protected virtual void PreInit() { }
        protected virtual void Init() 
        {
            for (int i = 0; i < canvasElements.Length; i++)
            {
                canvasElements[i].Init();
            }
        }

        public void ReturnToMainMenu()
        {
            if (OnReturnToMainMenu != null)
            {
                OnReturnToMainMenu();
            }
        }
    }
}


