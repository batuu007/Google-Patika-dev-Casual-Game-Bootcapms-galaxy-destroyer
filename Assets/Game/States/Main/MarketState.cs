namespace SpaceShooterProject.State 
{
    using Devkit.Base.Component;
    using Devkit.HSM;
    using SpaceShooterProject.Component;
    using SpaceShooterProject.UserInterface;
    using SpaceShooterProject.UserInterface.Market;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MarketState : StateMachine
    {
        private UIComponent uiComponent;
        private MarketCanvas marketCanvas;
        private MarketComponent marketComponent;
        
        public MarketState(ComponentContainer componentContainer)
        {
            marketComponent = componentContainer.GetComponent("MarketComponent") as MarketComponent;
            uiComponent = componentContainer.GetComponent("UIComponent") as UIComponent;
            marketCanvas = uiComponent.GetCanvas(UIComponent.MenuName.MARKET) as MarketCanvas;
        }

        protected override void OnEnter()
        {
            uiComponent.EnableCanvas(UIComponent.MenuName.MARKET);
            marketComponent.OnMarketActivated();
            marketCanvas.OnReturnToMainMenu += OnReturnToMainMenu;
            marketCanvas.IsBackgroundActive(true);
        }

        private void OnReturnToMainMenu()
        {
            SendTrigger((int)StateTriggers.GO_TO_MAIN_MENU_REQUEST);
        }

        protected override void OnExit()
        {
            marketComponent.OnMarketDeactivated();
            marketCanvas.OnReturnToMainMenu -= OnReturnToMainMenu;
            marketCanvas.IsBackgroundActive(false);
        }

        protected override void OnUpdate()
        {
            if(Input.GetMouseButtonUp(0)){
                var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                    RaycastHit hit;
                        if( Physics.Raycast(ray.origin, ray.direction, out hit)){
                            var chest = hit.collider.GetComponent<ChestAnimation>();
                                if(chest){
                                    chest.OpenChest();
                                } 
                        }
            }
           
        }
    }
}

