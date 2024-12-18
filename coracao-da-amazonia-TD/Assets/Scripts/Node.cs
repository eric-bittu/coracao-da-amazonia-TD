using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject arqueiro;

    private Renderer rend;
    private Color startColor;

    //Chama Script Money
    public GameObject moneyManager;

    void Start()
    {
        //atribui Renderer do objeto a rend, para poder manipular cor do node
        rend = GetComponent<Renderer>();
        //cor inicial do node
        startColor = rend.material.color;

        //Puxa script money para ser utilizado no node
        moneyManager = GameObject.Find("GameMaster"); ;
    }

    //quando o jogador clica no node
    void OnMouseDown()
    {
        //verifica se tem objeto construido neste node
        if (arqueiro != null)
        {
            //se sim, impede que outro objeto seja construido no mesmo lugar
            Debug.Log("N�o da pra construir ai!");
            return;
        }
        moneyManager.GetComponent<MoneyManager>().MoneyCheck(100);
        if(moneyManager.GetComponent<MoneyManager>().moneyValidate == true) 
        { 
            //prefab do arqueiro construido atraves do BuildManager
            GameObject arqueiroToBuild = BuildManager.instance.GetArqueiroToBuild();
            //instancia o personagem no node, ajustando a posi�ao com um positionOffset no ponto Y
            arqueiro = (GameObject)Instantiate(arqueiroToBuild, transform.position + positionOffset, transform.rotation);
            moneyManager.GetComponent<MoneyManager>().SubtractMoney(100);

        }

    
    }

    //quando o cursor do mouse passa sobre o node
    void OnMouseEnter()
    {
        //altera a cor para indicar onde vai selecionar a constru�ao
        rend.material.color = hoverColor;
    }

    //quando o cursor do mouse sai do node
    void OnMouseExit()
    {
        //restaura a cor original
        rend.material.color = startColor;
    }
}
