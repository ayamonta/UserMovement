using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] public CircleCollider2D circleCollider;
    [SerializeField] private float colliderRadius;

    [SerializeField] private Vector2 thrustDirection = new Vector2(1, 0);
    [SerializeField] private float thrustForce = 25.75f;

    [SerializeField] private float rotateDegreesPerSecond = 50.0f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        colliderRadius = circleCollider.radius;
    }

    // Start is called before the first frame update
    void Start()
    {

        //colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        // calculate rotation amount and apply rotation
        float rotateInput = Input.GetAxis("Rotate");
        float rotateAmount = rotateDegreesPerSecond * Time.deltaTime;

        //if (rotateInput != 0)
        //{ 
            if (rotateInput < 0)
            {
                transform.Rotate(Vector3.forward, rotateAmount * -1);
            }
            if (rotateInput > 0)
            {
                transform.Rotate(Vector3.forward, rotateAmount);
            }
        //}

        
    }

    // for updates involving physics; used for accuracy in AddForce mode 'Force'
    void FixedUpdate()
    {
        float thrustInput = Input.GetAxis("Thrust");

        if (thrustInput > 0)
        {
            rb2d.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
        }
    }

    // for screen wrapping when ship is off-screen
    void OnBecameInvisible()
    {
        Vector2 newPosition = transform.position;

        if (transform.position.x + colliderRadius > ScreenUtils.ScreenRight)
        {
            newPosition.x = ScreenUtils.ScreenLeft - colliderRadius;
        }
        if (transform.position.x - colliderRadius < ScreenUtils.ScreenLeft)
        {
            newPosition.x = ScreenUtils.ScreenRight + colliderRadius;
        }
        if (transform.position.y - colliderRadius < ScreenUtils.ScreenBot)
        {
            newPosition.y = ScreenUtils.ScreenTop - colliderRadius;
        }
        if (transform.position.y + colliderRadius > ScreenUtils.ScreenTop)
        {
            newPosition.y = ScreenUtils.ScreenBot - colliderRadius;
        }
        
        transform.position = newPosition;
    }


}
