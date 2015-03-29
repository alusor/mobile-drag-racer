using UnityEngine;
using System.Collections;

public class CarEngine : MonoBehaviour {

	float _power = 0f;
	int _gear = 0;
	float _engineRPM = 0f;
	
	float _wheelTorque;
	
	float minRPM = 200f;
	float peakRPM = 800f;
	float maxRPM = 1000f;
	
	float minTorque = 10f;
	float maxTorque = 30f;
	
	private float[] gearRatios = {0f, 6f, 3.5f, 2.5f};//TODO: Make need to make it 6 gears, I'll check for better ger ratios.


	void Update ()
	{      
		// Update the internals of the engine
		UpdateEngine();
		
		// Set torque on wheels and steering etc
		UpdateCar(); //Need to make this function.
	}
	
	
	public void UpdateEngine()
	{
		// Reset wheel torque to 0 every frame
		_wheelTorque = 0f;
		
		// Find RPM of wheels
		float wheelRPM = 0f;
		foreach (WheelCollider w in powerWheels) //TODO: need to assign a static variable for the wheels
		{
			wheelRPM += w.rpm;
		}
		wheelRPM /= powerWheels.Length;
		
		if (_gear > 0)
		{
			// How fast the shaft is turning at the engine end
			float rpmToEngine = wheelRPM * gearRatios[_gear];
			
			// Don't instantly set the engine to that RPM - the engine takes a while to get there.
			// This should be done better, but a lerp or something works now.
			_engineRPM = Mathf.MoveTowards(_engineRPM, rpmToEngine, Time.deltaTime * (maxRPM - minRPM));
			
			// Torque to the wheels is a function of the RPM, multiplied by the power. The gear then multiplies this torque again.
			_wheelTorque = GetEngineTorqueFromRPM(_engineRPM) * _power * gearRatios[_gear];                
		}
		else
		{
			// Neutral gear, simulate the engine idle. Lerp sucks, but it's fine for now.
			float targetRPM = Mathf.Lerp(minRPM, maxRPM, _power);
			_engineRPM += (targetRPM - _engineRPM) * Time.deltaTime;
		}
	}
	
	
	float GetEngineTorqueFromRPM(float rpm)
	{
		if (rpm < minRPM)
		{
			// 0 output below minimum RPM - we've stalled
			return 0f;
		}
		else if (rpm < peakRPM)
		{
			// Ramp up to the peak RPM value
			float range = rpm - minRPM;
			float x = range / (peakRPM - minRPM);
			
			return Mathf.Lerp(minTorque, maxTorque, x);
		}
		else if (rpm < maxRPM)
		{
			// Ramp down from peak to max
			float range = rpm - peakRPM;
			float x = range / minRPM;
			return Mathf.Lerp(maxTorque, minTorque, x);
		}
		else
		{
			// Spinning faster than max - negative torque!
			return -minTorque;
		}
	}
}
