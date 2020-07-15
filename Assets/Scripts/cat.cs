using System.Collections;
using System.Collections.Generic;
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

    }

    IEnumerator ChangeAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
            float r = Random.value;
            anim.SetBool("isSleeping", r < 0.33f );
            anim.SetBool("isIdling",  r >= 0.33f && r < 0.66f);
            anim.SetBool("isWalking", r >= 0.66f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value < 0.05)
        if (Input.GetKeyDown(KeyCode.I))
            anim.SetBool("isSleeping", true);
    }
}
