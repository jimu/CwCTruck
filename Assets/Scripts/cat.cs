using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class cat : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();

        if (Random.value < 0.6)
            anim.SetBool("isSleeping", true);

        StartCoroutine(ChangeAnimation());
    }

    IEnumerator ChangeAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 12.0f));
            float r = Random.value;
            anim.SetBool("isSleeping", r < 0.5f );
            anim.SetBool("isIdling",  r >= 0.5);
            //anim.SetBool("isWalking", r >= 0.66f);
            //Debug.Log("Change cat: r=" + r);
        }
    }

}
