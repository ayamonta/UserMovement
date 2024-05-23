using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] public CircleCollider2D circleCollider;
    public float colliderRadius;

    public Vector2 thrustDirection = new Vector2(1, 0);
    public float thrustForce = 27.0f;

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
