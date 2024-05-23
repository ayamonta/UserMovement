using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2d;
    public Vector2 thrustDirection = new Vector2(1, 0);
    public float thrustForce = 27.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // for updates involving physics
    private void FixedUpdate()
    {
        float thrustInput = Input.GetAxis("Thrust");

        if (thrustInput > 0)
        {
            rb2d.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
        }
    }
}
