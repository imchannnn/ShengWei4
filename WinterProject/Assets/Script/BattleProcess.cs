using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleProcess : MonoBehaviour
{
    [SerializeField] private float myMaxHP, enemyMaxHP;
    [SerializeField] private HealthControl myHP;
    [SerializeField] private HealthControl enemyHP;
    [SerializeField] private int enemyDamage, myDamage;

    // Start is called before the first frame update
    void Start()
    {
        myHP.SetMaxHP(myMaxHP);
        enemyHP.SetMaxHP(enemyMaxHP);
    }

    // Update is called once per frame

    void Battle(bool val)
    {
        if (val)
        {
            enemyHP.Damage(myDamage);
        }
        else
        {
            myHP.Damage(enemyDamage);
        }
    }
}
