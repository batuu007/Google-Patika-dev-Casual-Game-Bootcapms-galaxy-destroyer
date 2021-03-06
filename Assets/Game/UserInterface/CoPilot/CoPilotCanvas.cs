namespace SpaceShooterProject.UserInterface 
{
    using UnityEngine;

    public class CoPilotCanvas : BaseCanvas
    {
        public delegate void RequestNextCoPilotDelegate();
        public delegate void SelectCoPilotDelegate();
        public event RequestNextCoPilotDelegate OnNextCoPilotRequest;
        public event RequestNextCoPilotDelegate OnPreviousCoPilotRequest;
        public event SelectCoPilotDelegate OnCoPilotSelected;

        [SerializeField]
        private CoPilotAvatar coPilotAvatar;

        public void SetCurrentCoPilotData(/*CoPilotData data*/) //TODO Pass co pilot data into this method!!!
        {
            
        }

        public void OnNextCoPilotButtonClick() 
        {
            if (OnNextCoPilotRequest != null) 
            {
                OnNextCoPilotRequest();
            }
        }

        public void OnPreviousCoPilotButtonClick()
        {
            if (OnPreviousCoPilotRequest != null)
            {
                OnPreviousCoPilotRequest();
            }
        }

        public void OnCoPilotSelectButtonClick()
        {
            if (OnCoPilotSelected != null)
            {
                OnCoPilotSelected();
            }
        }

    }
}


