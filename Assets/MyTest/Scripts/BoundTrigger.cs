using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundTrigger : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().isGameOver = true;
        }
    }
}
