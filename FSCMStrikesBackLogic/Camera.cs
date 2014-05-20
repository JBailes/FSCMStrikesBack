using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FSCMStrikesBackLogic
{
    public static class Camera
    {
        
        private static Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(35), 1024f / 768f, 0.1f, 1000.0f);
        private static Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 0), new Vector3(0, 0, 0), Vector3.UnitY);//Vector3.UnitY
        private static float radius = 100;
        private static double angle = 360;
         //massive change
        public static Matrix rotation = Matrix.Identity;
     //   public Vector3 position = Vector3.Zero;

        // Simply feed this camera the position of whatever you want its target to be
        public static Vector3 targetPosition = Vector3.Zero;

    //    public Matrix viewMatrix = Matrix.Identity;
    //    public Matrix projectionMatrix = Matrix.Identity;
        public static float zoom = 30.0f;


        public static float verticalAngleMin = 0.01f;
        public static float verticalAngleMax = MathHelper.Pi - 0.01f;
        public static float zoomMin = 0.1f;
        public static float zoomMax = 50.0f;

        //end massive change

        public static Matrix View
        {
            get
            {
                // We need this for combat, Mick.
                //if(true)
                //if (StateHandler.FocusTarget())
                      return Matrix.CreateLookAt(new Vector3(StateHandler.TargetX + StateHandler.X, StateHandler.TargetY + StateHandler.Y - 45, StateHandler.Z + 25), new Vector3(StateHandler.TargetX, StateHandler.TargetY + 10, StateHandler.TargetZ + 10), Vector3.UnitZ);
                //else
                  //  return Matrix.CreateLookAt(new Vector3(StateHandler.X, StateHandler.Y+1000, StateHandler.Z), new Vector3(StateHandler.TargetX+100, StateHandler.TargetY+100, StateHandler.TargetZ+35), Vector3.UnitY);
            }
        }

        public static void RotateY(float rotation)
        {
            rotation = rotation /10;
            angle = (angle + rotation) % 360;
            StateHandler.X = (float)(radius * Math.Cos(angle));
            //StateHandler.X = (float)(radius * Math.Cos(angle));
            //StateHandler.Y = (float)(radius * Math.Sin(angle));
        }
        
        // Mick, this is for a sine/cosine rotation around the X axis
        // Camera movement left/right relative to the screen, no zoom.
 //       public static void RotateX(float toZoom)
  //      {
            /*
               // y += toRotate;
            if (toZoom >= 0 && StateHandler.Z < 35)
            {
                StateHandler.Z += toZoom;
            }
            if (toZoom <= 0 && StateHandler.Z >= 0)
            {
                StateHandler.Z += toZoom;
            }
             */  
    //    }
        //taken from
        //http://www.xnawiki.com/index.php?title=Arc-Ball_Camera
        /*
        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {    // Keep zoom within range
                zoom = MathHelper.Clamp(value, zoomMin, zoomMax);
            }

        }
        */
        // Mick, this is for a sine/cosine rotation around the Y axis
        // Camera movement up/down relative to the screen, no zoom.
        public static void RotateX(float toRotate)
        {
            /*
            if(x <= 45 && toRotate >= 0)
            {
                x += toRotate;
            }
            else if (x >= -45 && toRotate <= 0)
            {
                x += toRotate;
            }
             */
        }

        // Mick, this is for a zoom in and out function on the Z axis. No camera movement left/right or up/down, just a zoom in and out.
        public static void cameraZoom(float toZoom)
        {

           // toZoom = toZoom / 10;
           // angle = (angle + toZoom) % 360;
           // StateHandler.Y = (float)(radius * Math.Sin(angle));
          //  radius = toZoom;
         //   y += toRotate;
            /*
            if (StateHandler.Y <= 5 && toZoom >= 0)
            {
                StateHandler.Y += toZoom;
            }
            else if (StateHandler.Y >= -100 && toZoom <= 0)
            {
                StateHandler.Y += toZoom;
            }
            */
        }

      public static void Rotate(float toRotate)
      {
      }

        //taken from
        //http://www.xnawiki.com/index.php?title=Arc-Ball_Camera
        /*
        private float horizontalAngle = MathHelper.PiOver2;
        public float HorizontalAngle
        {
            get
            {
                return horizontalAngle;
            }
            set
            {    // Keep horizontalAngle between -pi and pi.
                horizontalAngle = value % MathHelper.Pi;
            }
        }
         */
        //taken from
        //http://www.xnawiki.com/index.php?title=Arc-Ball_Camera
        /*
        private float verticalAngle = MathHelper.PiOver2;
        public float VerticalAngle
        {
            get
            {
                return verticalAngle;
            }
            set
            {    // Keep vertical angle within tolerances
                verticalAngle = MathHelper.Clamp(value, verticalAngleMin, verticalAngleMax);
            }
        }
        */
 
        //http://www.xnawiki.com/index.php?title=Arc-Ball_Camera

        /// <summary>
        /// Points camera in direction of any position.
        /// </summary>
        /// <param name="targetPos">Target position for camera to face.</param>
        ///
        
        public static void LookAt(Vector3 targetPos)
        {
            Vector3 newForward = targetPos - new Vector3(StateHandler.TargetX, StateHandler.TargetY, StateHandler.TargetZ);
            newForward.Normalize();
            Vector3 referenceVector = Vector3.UnitZ;
        }
        
        public static Matrix Projection
        {
            get { return projection; }
            set { projection = value; }
        }

    }
}
