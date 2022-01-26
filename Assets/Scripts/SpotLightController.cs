using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public string code;
    public int i;

    void Start()
    {
        StartCoroutine(LoopLight());
        
    }


    System.Collections.IEnumerator LoopLight()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);
            
            i = int.Parse(code.Substring(0,1));
            while (i > 0)
            {
                light1.GetComponent<Animator>().SetTrigger("loop");
                i--;
                yield return new WaitForSeconds(1f);

            }

            i = int.Parse(code.Substring(1,1));
            yield return new WaitForSeconds(1f);

            while (i > 0)
            {
                light2.GetComponent<Animator>().SetTrigger("loop");
                i--;
                yield return new WaitForSeconds(1f);

            }

            i = int.Parse(code.Substring(2));
            yield return new WaitForSeconds(1f);

            while (i > 0)
            {
                light3.GetComponent<Animator>().SetTrigger("loop");
                i--;
                yield return new WaitForSeconds(1f);

            }
        }
        


    }
}
