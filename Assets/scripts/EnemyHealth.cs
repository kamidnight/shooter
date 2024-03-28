using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }
    // Start is called before the first frame update
    private void EnemyDeath()
    {
        animator.SetTrigger("death");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
