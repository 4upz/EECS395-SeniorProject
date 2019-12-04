using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody scissors;
    [SerializeField] private GameObject key;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "")
        {
            GameObject newKey = Instantiate(key);
            newKey.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Destroy(scissors.gameObject);
            Destroy(this.gameObject);
        }
    }
}
