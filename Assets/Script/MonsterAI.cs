using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("distance", Vector2.Distance(transform.position, player.transform.position));
    }
}
