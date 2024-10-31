using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //velocidade do inimigo
    public float speed = 10.0f;

    //objeto transform que indica o waypoint atual que o inimigo se dirige
    private Transform target;
    //indice que rastreia o waypoint atual no array de waypoints
    private int wavepointIndex = 0;
    
    void Start()
    {
        //define o primeiro waypoint como alvo para o inimigo se mover
        target = Waypoints.points[0];
    }
    
    void Update()
    {
        //calcula a direçao entre a posiçao atual do inimigo e o proximo waypoint
        Vector3 dir = target.position - transform.position;
        //move o inimigo na direçao com uma velocidade constante, ajustada por Time.deltaTime para movimento suave
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //verifica se o inimigo esta proximo o suficiente do waypoint atual para ir para o proximo waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            //se sim, chama o metodo
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        //verifica se o inimigo chegou no ultimo waypoint
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            //se sim, signfica que completou o caminho e destroi o objeto
            Destroy(gameObject);
            return;
        }
        //se nao, define o proximo waypoint na lista como o novo alvo
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
   
}
