using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCrystal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            ScoreSystem.CrystalScore++;
            Destroy(this.gameObject);
        }
    }
}
