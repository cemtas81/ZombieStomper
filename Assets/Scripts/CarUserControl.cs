using System;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
   
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        
        public float Hinput2;
        public float Vinput2;
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


//        private void FixedUpdate()
//        {
//            // pass the input to the car!
//            Hinput2= CrossPlatformInputManager.GetAxis("Horizontal");
//            Vinput2 = CrossPlatformInputManager.GetAxis("Vertical");


//#if !MOBILE_INPUT
//            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
//            m_Car.Move(h, v, v, handbrake);
//#else
//        m_Car.Move(Hinput2, Vinput2, Vinput2, 0f);
//#endif
//        }
    }
}
