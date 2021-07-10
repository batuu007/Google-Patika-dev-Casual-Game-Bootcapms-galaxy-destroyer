namespace SpaceShooterProject.UserInterface
{
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine;

    public class InGameCanvas : BaseCanvas
    {
        [SerializeField] private TextMeshProUGUI coinContainer;

        public delegate void InGameCanvasDelegate();

        public event InGameCanvasDelegate OnPauseButtonClick;

        protected override void Init()
        {
        }

        public void RequestPause()
        {
            if (OnPauseButtonClick != null)
                OnPauseButtonClick();
        }

        public void UpdateGoldCount(int coinCount)
        {
            if (coinContainer == null)
            {
                Debug.LogError("Coin container reference is null!!!");
                return;
            }

            coinContainer.text = coinCount.ToString();
        }
    }
}