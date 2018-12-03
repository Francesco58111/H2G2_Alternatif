using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperspaceParticlesTransitions : MonoBehaviour {

    public ParticleSystemRenderer HyperSpaceParticlesSmall;
    public ParticleSystemRenderer HyperSpaceParticlesLarge;

    public float NormalSpeedLenghtScale;
    public float LightSpeedLenghtScale;

    // Use this for initialization
    void Start () {
        HyperSpaceParticlesSmall.lengthScale = NormalSpeedLenghtScale;
        HyperSpaceParticlesLarge.lengthScale = NormalSpeedLenghtScale;
    }
	
	// Update is called once per frame
	void Update ()
    {

        /*if (Input.GetKey(KeyCode.A))
        {
            SetToLightSpeed();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            SetToNormalSpeed();
        }*/
    }

    void SetToLightSpeed()
    {
        HyperSpaceParticlesSmall.lengthScale = Mathf.Lerp(HyperSpaceParticlesSmall.lengthScale, LightSpeedLenghtScale, 2*Time.deltaTime);
        HyperSpaceParticlesLarge.lengthScale = Mathf.Lerp(HyperSpaceParticlesLarge.lengthScale, LightSpeedLenghtScale, 2*Time.deltaTime);
    }

    void SetToNormalSpeed()
    {
        HyperSpaceParticlesSmall.lengthScale = Mathf.Lerp(HyperSpaceParticlesSmall.lengthScale, NormalSpeedLenghtScale, 2*Time.deltaTime);
        HyperSpaceParticlesLarge.lengthScale = Mathf.Lerp(HyperSpaceParticlesLarge.lengthScale, NormalSpeedLenghtScale, 2*Time.deltaTime);
    }

}
