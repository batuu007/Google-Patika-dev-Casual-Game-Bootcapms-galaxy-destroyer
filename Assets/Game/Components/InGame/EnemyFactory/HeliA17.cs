﻿namespace SpaceShooterProject.Component
{ 
    using UnityEngine;
    using System.Collections;

    public class HeliA17 : Enemy
    {
        public override void Attack()
        {
        }

        public override void Death()
        {
            inGameMessageBroadcaster.TriggerEnemyDeath(this);
        }

        public override void OutOfScreen()
        {
        }

        public override void Patrol()
        {
        }
    }
}
