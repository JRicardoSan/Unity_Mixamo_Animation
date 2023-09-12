using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using the Animation namespace created for this project
using Animation;

public class greatSwordMariaInputController : MonoBehaviour
{

    greatSwordMariaAnimationStateController dummySC;
    [SerializeField] private float acceleration = 2.0f;

    [SerializeField] private float deceleration = 5.0f;
    [SerializeField] private float input_vel_fbw = 0.0f;
    [SerializeField] private float input_vel_lat = 0.0f;

    float runLimit = 2.0f;
    float walkLimit = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        dummySC = GetComponent<greatSwordMariaAnimationStateController>();

    }

    // Update is called once per frame
    void Update()
    {

        bool forwardPressed  =   Input.GetKey("w");
        bool backwardPressed =   Input.GetKey("s");
        bool leftPressed     =   Input.GetKey("a");
        bool rightPressed    =   Input.GetKey("d");
        bool runPressed      =   Input.GetKey("left shift");
        bool mousePressed    =   Input.GetKey(KeyCode.Mouse0);


        // First, we reset any trigger to avoid it being still activated
        dummySC.ResetTriggers();

        // Forward Key is pressed
        if (forwardPressed)
        {
            input_vel_fbw = Accelerate( runPressed, input_vel_fbw );
        }
        else if (backwardPressed)
        {
            input_vel_fbw = -Accelerate( runPressed, -input_vel_fbw );
        }
        else
        {
            input_vel_fbw = Decelerate( input_vel_fbw );
        }
        

        // Right Key is pressed
        if ( rightPressed )
        {
            input_vel_lat = Accelerate( runPressed, input_vel_lat );
        }
        else if (leftPressed)
        {
            input_vel_lat = -Accelerate( runPressed, -input_vel_lat );
        }
        else
        {
            input_vel_lat = Decelerate( input_vel_lat );
        }
        
        if (mousePressed)
        {
            dummySC.AnimateAttackDownwardSlash();
        }
        

        dummySC.AnimateMotion( input_vel_fbw, input_vel_lat );
        

    }

    float Accelerate( bool isRunPressed, float inputVelocity )
    {
        float outputVelocity = inputVelocity;

            if ( isRunPressed )
            {

                if ( outputVelocity <= runLimit )
                {

                    outputVelocity += Time.deltaTime * acceleration;

                    outputVelocity = Mathf.Min( outputVelocity, runLimit );

                }
                else
                {
                    outputVelocity = runLimit;
                }

            }
            else // Not running, but rather walking
            {

                if ( outputVelocity <= walkLimit )
                {
                    outputVelocity += Time.deltaTime * acceleration;
                    outputVelocity = Mathf.Min( outputVelocity, walkLimit );
                }
                else
                {

                    outputVelocity -= Time.deltaTime * deceleration;

                }

            }
        return outputVelocity;
            
    }

    float Decelerate( float inputVelocity )
    {

        float outputVelocity = inputVelocity;

        if ( outputVelocity > 0.0f )
        {

            outputVelocity -= Time.deltaTime * deceleration;
            outputVelocity = outputVelocity = Mathf.Max( outputVelocity, 0.0f );

        }
        else if ( outputVelocity < 0.0f )
        {

            outputVelocity += Time.deltaTime * deceleration;
            outputVelocity = outputVelocity = Mathf.Min( outputVelocity, 0.0f );

        }

        return outputVelocity;

    }
        

}
