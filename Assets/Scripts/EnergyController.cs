using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour {

    private int _energy = 100;
    void Start()
    {
        UpdateEnergyBar();
    }
	
	public void IncEnergy()
    {
        _energy++;
        UpdateEnergyBar();
    }

    public void DecrEnergy()
    {
        _energy--;
        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        Controller.UpdateEnergyBar.Say(_energy);
    }
}
