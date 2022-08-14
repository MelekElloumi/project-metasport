using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EmoteSystem : MonoBehaviour
{
    PhotonView pv;
    Animator anim;
    void Start()
    {
        pv=GetComponent<PhotonView>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.I))
            {
                anim.SetBool("Emoting", true);
                anim.SetInteger("Emote_type", 1);
                anim.Play("Waving");
                anim.SetBool("Emoting", false);
            }
        }
        
    }
}
