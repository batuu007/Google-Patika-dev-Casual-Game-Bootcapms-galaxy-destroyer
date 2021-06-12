using UnityEngine;
using UnityEngine.UI;
namespace SpaceShooterProject.UserInterface 
{
    public class QuoteCanvas : BaseCanvas
    {
        public delegate void QuoteRequestDelegate();
        public event QuoteRequestDelegate OnInGameMenuRequest;

        [SerializeField] private RectTransform backgroundImage;

        protected override void Init()
        {
           backgroundImage.sizeDelta = GetCanvasSize();
        }

        private Vector2 GetCanvasSize()
        {
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            CanvasScaler canvasScaler = GetComponent<CanvasScaler>();
            var m_ScreenMatchMode = canvasScaler.screenMatchMode;
            var m_ReferenceResolution = canvasScaler.referenceResolution;
            var m_MatchWidthOrHeight = canvasScaler.matchWidthOrHeight;

            float scaleFactor = 0;
            float logWidth = Mathf.Log(screenSize.x / m_ReferenceResolution.x, 2);
            float logHeight = Mathf.Log(screenSize.y / m_ReferenceResolution.y, 2);
            float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, m_MatchWidthOrHeight);
            scaleFactor = Mathf.Pow(2, logWeightedAverage);

            return new Vector2(screenSize.x / scaleFactor, screenSize.y / scaleFactor);
        }

        public void RequestInGameMenu() 
        {
            if (OnInGameMenuRequest != null) 
            {
                OnInGameMenuRequest();
            }
        }
    }
}
