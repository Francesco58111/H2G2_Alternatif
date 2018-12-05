using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperspaceParticlesTransitions : MonoBehaviour {

    public ParticleSystemRenderer HyperSpaceParticlesSmall;
    public ParticleSystemRenderer HyperSpaceParticlesLarge;

    public ParticleSystem HyperSpaceParticlesSmall2;
    public ParticleSystem HyperSpaceParticlesLarge2;

    public float NormalSpeedLenghtScale;
    public float LightSpeedLenghtScale;

    // Use this for initialization
    void Start () {
        HyperSpaceParticlesSmall.lengthScale = NormalSpeedLenghtScale;
        HyperSpaceParticlesLarge.lengthScale = NormalSpeedLenghtScale;

        HyperSpaceParticlesSmall2 = GameObject.Find("Particle_hyperspace_small").GetComponent<ParticleSystem>();
        HyperSpaceParticlesLarge2 = GameObject.Find("Particle_hyperspace_large").GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.A))
        {
            SetToLightSpeed();
        }
        if (Input.GetKey(KeyCode.Z))
        {
            SetToNormalSpeed();
        }
    }

    void SetToLightSpeed()
    {
        var main = HyperSpaceParticlesSmall2.main;
        var main2 = HyperSpaceParticlesLarge2.main;
        main.simulationSpeed = Mathf.Lerp(main.simulationSpeed, 3f, 2 * Time.deltaTime);
        main2.simulationSpeed = Mathf.Lerp(main2.simulationSpeed, 1.5f, 2 * Time.deltaTime);

        HyperSpaceParticlesSmall.lengthScale = Mathf.Lerp(HyperSpaceParticlesSmall.lengthScale, LightSpeedLenghtScale, 2*Time.deltaTime);
        HyperSpaceParticlesLarge.lengthScale = Mathf.Lerp(HyperSpaceParticlesLarge.lengthScale, LightSpeedLenghtScale, 2*Time.deltaTime);
    }

    void SetToNormalSpeed()
    {
        var main = HyperSpaceParticlesSmall2.main;
        var main2 = HyperSpaceParticlesLarge2.main;
        main.simulationSpeed = Mathf.Lerp(main.simulationSpeed, 1f, 2 * Time.deltaTime);
        main2.simulationSpeed = Mathf.Lerp(main2.simulationSpeed, 0.75f, 2 * Time.deltaTime);

        HyperSpaceParticlesSmall.lengthScale = Mathf.Lerp(HyperSpaceParticlesSmall.lengthScale, NormalSpeedLenghtScale, 2*Time.deltaTime);
        HyperSpaceParticlesLarge.lengthScale = Mathf.Lerp(HyperSpaceParticlesLarge.lengthScale, NormalSpeedLenghtScale, 2*Time.deltaTime);
    }

}
