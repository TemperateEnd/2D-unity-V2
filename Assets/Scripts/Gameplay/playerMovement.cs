using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.25f;
        player = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       Vector2 movement =  new Vector2 (horizontal * speed, vertical * speed);

       player.Translate(movement);
    }
}