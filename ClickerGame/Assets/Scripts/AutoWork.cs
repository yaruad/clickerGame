using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWork : MonoBehaviour
{
    public static long autoMoneyIncreaseAmount = 10;
    public static long autoIncreasePrice = 1000;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        yield return new WaitForSeconds(1.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
