using UnityEngine;
using ProgressBar;
using System.Collections;

public class EnergyBarFiller : MonoBehaviour {

    private ProgressBarBehaviour _energyBar;

	// Use this for initialization
	void Awake () {
        _energyBar = GetComponent<ProgressBarBehaviour>();
        Controller.UpdateEnergyBar.Subscribe(UpdateEnergyBar);
	}
	
	// Update is called once per frame
	void UpdateEnergyBar(float newValue) {
        _energyBar.SetFillerSizeAsPercentage(newValue);
	}
}
