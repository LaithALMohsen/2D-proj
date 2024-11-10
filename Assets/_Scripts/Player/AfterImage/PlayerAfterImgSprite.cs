using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImgSprite : MonoBehaviour
{

    [SerializeField]
    private float activTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.8f;
    private float alphaMultipier = 0.85f;


    private Transform player;

    private SpriteRenderer Sr;
    private SpriteRenderer PlayerSr ;

    private Color color;

    private void OnEnable()
    {
        Sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerSr = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        Sr.sprite = PlayerSr.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }
    private void Update()
    {
        alpha *= alphaMultipier;
        color = new Color(1f, 1f, alpha);
        Sr.color = color; 

        if(Time.time >= (timeActivated + activTime))
        {
            PlayerAfterImgPool.Instance.AddToPool(gameObject);


        }
    }

}
