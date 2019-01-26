using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject target;
    public GameObject avatar;
    public float speed = 0.5f;
    public float rotateSpeed;
    private Vector2 startPosition;
    public bool heal;
    public bool buildUp;
    public bool damage;
    public Collider2D thisOne;

    planetScript targetScript;
    public bool isMoving = true;

    public bool startTimer = false;
    public float pickUpTimer = 5f;



    // Start is called before the first frame update
        //quaternion.lookrotation might be your best bet to make the meteors point towards the planet
    void Start()
    {
        startPosition = this.transform.position;
        targetScript = target.GetComponent<planetScript>();

       
        //Vector2 direction = ((Vector2)target.transform.position - startPosition);
        //Quaternion heading = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, heading, 400 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);

            //Vector2 direction = ((Vector2)target.transform.position - startPosition);

            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //Quaternion heading = Quaternion.AngleAxis(angle, Vector3.right);
            //transform.rotation = Quaternion.Slerp(transform.rotation, heading, rotateSpeed * Time.deltaTime);

            //Quaternion heading = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, heading, 360 * Time.deltaTime);
        }

        if (isMoving == false)
        {
            pickUpTimer -= Time.deltaTime;

            if (pickUpTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damage == true)
        {
            if (collision.gameObject.tag == "planet")
            {
                targetScript.TakeDamage();
                Destroy(gameObject);
            }
        }

        if (buildUp == true)
        {
            if (collision.gameObject.tag == "planet")
            {
                isMoving = false;
            }

            if (collision.gameObject.tag == "Player")
            {
                targetScript.BuildUp();
                Destroy(gameObject);
            }


        }

        if (heal == true)
        {
            if (collision.gameObject.tag == "planet")
            {
                isMoving = false;
                //Timer = true;
            }

            if (collision.gameObject.tag == "Player")
            {
                targetScript.HealPlanet();
                Destroy(gameObject);
            }


        }
    }

}
