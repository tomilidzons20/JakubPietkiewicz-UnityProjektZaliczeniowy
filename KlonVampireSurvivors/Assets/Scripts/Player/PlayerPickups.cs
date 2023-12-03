using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ExpPickup"))
        {
            collision.GetComponent<ExperiencePickup>().Collect();
        }
        else if (collision.CompareTag("HpPickup"))
        {
            collision.GetComponent<HealthPickup>().Collect();
        }
    }
}
