using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPowerStatus : MonoBehaviour {

    public int power_status;
    
    public void setpower_status(int new_powers_status)
    {
        this.power_status = new_powers_status;
    }

    public int getPower_status()
    {
        return this.power_status;
    }

}
