using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Velocidade do inimigo
    public float speed = 10.0f;

    //Objeto transform que indica o waypoint atual que o inimigo se dirige
    private Transform target;
    //Indice que rastreia o waypoint atual no array de waypoints
    private int wavepointIndex = 0;
    public GameObject hpPlayer;
    void Start()
    {

        hpPlayer = GameObject.Find("GameMaster");
        

        //Define o primeiro waypoint como alvo para o inimigo se mover
        target = Waypoints.points[0];
    }
    
    void Update()
    {
        //Calcula a dire�ao entre a posi�ao atual do inimigo e o proximo waypoint
        Vector3 dir = target.position - transform.position;
        //Move o inimigo na dire�ao com uma velocidade constante, ajustada por Time.deltaTime para movimento suave
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Verifica se o inimigo esta proximo o suficiente do waypoint atual para ir para o proximo waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            //Se sim, chama o metodo
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        //Verifica se o inimigo chegou no ultimo waypoint
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            //Se sim, signfica que completou o caminho e destroi o objeto e d� dano
            hpPlayer.GetComponent<HpPlayer>().TomarDano(1);
            Destroy(gameObject);
            hpPlayer.GetComponent<HpPlayer>().Perder();
            return;
            
        }
        //Se nao, define o proximo waypoint na lista como o novo alvo
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
   
}
