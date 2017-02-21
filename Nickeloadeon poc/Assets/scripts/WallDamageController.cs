using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamageController : MonoBehaviour {
    public int damage_done_to_wall = 5;

    public int getDamage_done()
    {
        return this.damage_done_to_wall;
    }

    public void setDamage_done(int new_damage)
    {
        this.damage_done_to_wall = new_damage;
    }

}
