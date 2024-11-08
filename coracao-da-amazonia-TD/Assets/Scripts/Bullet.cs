using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int bulletDamageArqueiro = 10;
    private GameObject enemy;
    public int damageDeal = 0;
    
    public void Perseguir(Transform _target)
    {
        target = _target;
    }

    
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame )
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


    }

    void HitTarget()
    {
        
        Debug.Log("Dano foi de: " +  bulletDamageArqueiro);
    }
}
