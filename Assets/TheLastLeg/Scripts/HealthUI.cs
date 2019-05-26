using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> HealthHearts;

    private void Start()
    {
        Debug.Assert(HealthHearts.Count >= 0, "Add reference to Heart UI Images.");   
    }

    public void UpdateHealth(int health)
    {
        int deltaHealth = HealthHearts.Count - health;
        if(deltaHealth < HealthHearts.Count)
        {
            int i = 0;
            for (; i < health; i++)
            {
                HealthHearts[i].SetActive(true);
            }
            for(; i < HealthHearts.Count; i++)
            {
                HealthHearts[i].SetActive(false);
            }
        }
    }
}
