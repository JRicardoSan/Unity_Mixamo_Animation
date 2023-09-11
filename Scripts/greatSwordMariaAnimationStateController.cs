// Script written by JRicardoSan (jricardosan.tech@gmail.com)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class greatSwordMariaAnimationStateController : MonoBehaviour
    {

        // Internal class parameters
        private Animator animator;
        private int moveVelFbwHash;
        private int moveVelLatHash;
        private int attackDownwardSlashHash;
        private int attackLowSlashHash;

        void Start()
        {

            // Animator component
            animator                = GetComponent<Animator>();

            // 'Move' Parameters
            moveVelFbwHash          = Animator.StringToHash("Move_Vel_Fbw");
            moveVelLatHash          = Animator.StringToHash("Move_Vel_Lat");

            // 'Attack' Parameters
            attackDownwardSlashHash = Animator.StringToHash("Attack_Downward_Slash");
            attackLowSlashHash      = Animator.StringToHash("Attack_Low_Slash");

        }

        /* AnimateMotion
         * It indicates the State Controller the motion animation
         * to perform according to two input parameters:
         * - vel_fbw: Forward/backward velocity.
         * - vel_lat: Lateral velocity.
         * For both input parameters, the values work this way:
         * - 0.0 = Idle
         * - 1.0 = Walk forwards/right
         * - 2.0 = Run forwards/right
         * - -1.0 = Walk backwards/left
         * - -2.0 = Run backwards/left
        */
        public void AnimateMotion( float vel_fbw, float vel_lat )
        {

            animator.SetFloat( moveVelFbwHash, vel_fbw );
            animator.SetFloat( moveVelLatHash, vel_lat );

        }

        public void AnimateAttackDownwardSlash()
        {

            animator.ResetTrigger( attackDownwardSlashHash );
            animator.SetTrigger(   attackDownwardSlashHash );
            
        }
        
    }

}

