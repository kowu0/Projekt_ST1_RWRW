using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthDisable : MonoBehaviour
{
    public Boss boss;
    public GameObject test123;

    public void SliderDisable(){
        if(boss.health <= 0){
            test123.SetActive(false);
        }
    }
}
