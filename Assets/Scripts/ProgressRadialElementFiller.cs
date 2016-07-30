using UnityEngine;
using ProgressBar;
using System.Collections;

public class ProgressRadialElementFiller : MonoBehaviour{
    public ProgressRadialBehaviour radialElement;

	// Use this for initialization
	void Awake ()
    {
        Controller.FillRadialElement.Subscribe(OnDemoFire);
	}
	
	// Update is called once per frame
	public void OnDemoFire(float _shotForceRatio)
    {
        radialElement.SetFillerSizeAsPercentage(_shotForceRatio * 100);
    }
}
