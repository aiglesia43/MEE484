//============================================================================
// JointControl.cs    
// A mannequin control class to control individual joints
//============================================================================
using Godot;
using System;
using System.Dynamic;
using System.Collections.Immutable;


public class JointControl : ManneControl
{
    CharacterItf modelItf;
    MannequinScene mquinScene;
    
    float angleX;
    float angleY;
    float angleZ;
    float dAngle;
    JointType selectedJoint;


    private ImmutableDictionary<JointType,Vector3> hingeVectors;

    //------------------------------------------------------------------------
    // Constructor
    //------------------------------------------------------------------------
    public JointControl(CharacterItf mitf, MannequinScene mScene)
    {
        modelItf = mitf;
        mquinScene = mScene;
        selectedJoint = JointType.Waist; //sets defalut joint to waist
        angleX = angleY = angleZ = 0.0f;
        dAngle = Mathf.DegToRad(2.0f);
        hingeVectors = mitf.HingeVectors();

    }

    //------------------------------------------------------------------------
    // Process
    //------------------------------------------------------------------------
    public override void Process(double delta)
    {
        //base.Process(delta);

        //float waistAngle = (float)Math.Cos(time);
        //modelItf.SetSimpleWaistTwist(waistAngle);

        //Sets desired joint to be adjusted equal to a number pressed on the keypad
        if(Input.IsKeyPressed(Key.Key0)){
            selectedJoint = JointType.ShoulderL;
        }

        if(Input.IsKeyPressed(Key.Key1)){
            selectedJoint = JointType.ShoulderR;
        }

        if(Input.IsKeyPressed(Key.Key2)){
            selectedJoint = JointType.ElbowL;
        }

        if(Input.IsKeyPressed(Key.Key3)){
            selectedJoint = JointType.ElbowR;
        }

        if(Input.IsKeyPressed(Key.Key4)){
            selectedJoint = JointType.Waist;
        }

        if(Input.IsKeyPressed(Key.Key5)){
            selectedJoint = JointType.Torso;
        }

        if(Input.IsKeyPressed(Key.Key6)){
            selectedJoint = JointType.HipL;
        }

        if(Input.IsKeyPressed(Key.Key7)){
            selectedJoint = JointType.HipR;
        }

        if(Input.IsKeyPressed(Key.Key8)){
            selectedJoint = JointType.KneeL;
        }

        if(Input.IsKeyPressed(Key.Key9)){
            selectedJoint = JointType.KneeR;
        }

        if(Input.IsKeyPressed(Key.R)){
            modelItf.ResetAllJoints();
        }

        if(Input.IsKeyPressed(Key.T)){
            modelItf.ResetJoint(selectedJoint);
        }

        angleX = angleY = angleZ = 0.0f;
        // Takes inputs from key arrows. 
        if(Input.IsActionPressed("ui_right")){
            angleY += dAngle;
        }
        if(Input.IsActionPressed("ui_left")){
            angleY -= dAngle;
        }

        if(Input.IsActionPressed("ui_up")){
            angleZ += dAngle;
        }
        if(Input.IsActionPressed("ui_down")){
            angleZ -= dAngle;
        }

        if(Input.IsActionPressed("ui_other_right")){
            angleX += dAngle;
        }
        if(Input.IsActionPressed("ui_other_left")){
            angleX -= dAngle;
        }
        var currentQuat = modelItf.GetJointQuat(selectedJoint);

        // Use only right and left if a hinge joint
        if (hingeVectors.ContainsKey(selectedJoint)) {
            Quaternion q = new Quaternion(hingeVectors[selectedJoint],angleY);
            modelItf.SetJointQuat(selectedJoint,currentQuat*q);
        } else {
            modelItf.QuatCalcEulerYZX(angleX,angleY,angleZ);
            modelItf.SetJointQuat(selectedJoint,currentQuat*modelItf.qResult);
        }

        

        time += delta;
    }

    //------------------------------------------------------------------------
    // PhysicsProcess
    //------------------------------------------------------------------------
    public override void PhysicsProcess(double delta)
    {
        //base.PhysicsProcess(delta);
    }
}