using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScripts : MonoBehaviour
{
    public Transform[] combPoints;
    private float moveSpeed = 20f;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeeMovement());
    }

    // Update is called once per frame
    void Update()
    {
        step = moveSpeed;
    }

    IEnumerator BeeMovement()
    {
        //int beePos = Random.Range(0, combPoints.Length);
        for (int i = 0; i < combPoints.Length; i++) {
            transform.position = Vector2.MoveTowards(transform.position, combPoints[i].position, step);
            yield return new WaitForSeconds(3f);
        }
        //yield return new WaitForSeconds(3);
        //StartCoroutine(BeeMovement());
    }
}
