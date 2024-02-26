using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update

    private double random;
    void Start()
    {
        random = new System.Random().NextDouble();

        StartCoroutine(BounceSprite());
    }

    IEnumerator BounceSprite() {

        float bounce_dist = .2f;

        while (true) {

            yield return new WaitForSeconds((float)random);

            transform.position = new Vector3(transform.position.x, transform.position.y+bounce_dist, transform.position.z);

            yield return new WaitForSeconds(1.0f);

            transform.position = new Vector3(transform.position.x, transform.position.y-bounce_dist, transform.position.z);

            yield return new WaitForSeconds(1.0f);

        }

    }
}
