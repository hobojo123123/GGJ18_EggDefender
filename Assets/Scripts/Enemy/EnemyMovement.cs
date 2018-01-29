using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class EnemyMovement : MonoBehaviour
{
    //health and speed of enemy
    private float health;
    private float speed;
    private float targetRadius;
    private float rotationSpeedInRadians;

    Health playerHealth;
    private Vector3 targetPosition;
    private GameObject target;

    void Start()
    {
        targetRadius = 100.0f;
        rotationSpeedInRadians = 10.0f;

        //grabbing info from the EnemyStatus Holder
        health = GetComponent<EnemyStats>().health;
        speed = GetComponent<EnemyStats>().speed;

        playerHealth = FindObjectOfType(typeof(Health)) as Health;

        //Checks if a gameobject contains the tag "egg", then sets "targetPosition" to that position
        if (GameObject.FindGameObjectWithTag("egg"))
        {
            target = GameObject.FindGameObjectWithTag("egg");
            targetPosition = target.transform.position;
        }

        ////Rotates the enemy towards the targetPosition, then propels the object foward. Then adds the slight spiral effect
        //transform.LookAt(targetPosition);
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //transform.Rotate(new Vector3(0, -90, 0));

        //Set the objects layer to enemy
        //gameObject.layer = LayerMask.NameToLayer("enemy");

        // make continuous spiral movement.
        StartCoroutine(SpiralMove());
    }
    private void FixedUpdate()
    {
        //checks if the health drops below zero. If it does, kill the enemy.
        if (health < 0)
            die();

        //checks if the enemy gets close to the target
        if (Mathf.Abs(targetPosition.z - transform.position.z) < 3)
        {
            //print(targetPosition.x + " " + transform.position.x);
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            //GetComponent<Rigidbody>().rotation = Quaternion.identity;

            //Here we would do stuff like hurt the player. For now, i'm going to outprint ("You lost!");
            if (GetComponent<EnemyStats>().type == EnemyType.instaKill)
            {
                print("You Lost");
            }
            else
            {
                print("Take some damage");
            }

            playerHealth.Damage(8f);
            die();
        }
    }

    IEnumerator SpiralMove()
    {
        while (true)
        {
            Vector3 r = Random.onUnitSphere;

            r = new Vector3(5 * r.x, r.y, - Mathf.Abs(r.z));

            Vector3 randomTargetPosition = targetPosition + r * targetRadius;

            Vector3 errPosition = randomTargetPosition - transform.position;

            GetComponent<Rigidbody>().velocity = Vector3.MoveTowards(GetComponent<Rigidbody>().velocity, speed * Vector3.Normalize(errPosition), 1.0f);

            transform.LookAt(target.transform);
            //transform.Rotate(0.0f, 0f, 0.0f);

            //transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.time * speed);

            yield return new WaitForSeconds(.4f);
        }
    }

    public void die()
    {
        //Play sound
        //Do any animations, particle effects, and such here.
        //For now...
        gameObject.SetActive(false);
    }

    /* *A FAILED EXPERIMENT*
     * 
    public int pushAmount;
    IEnumerator SpiralEffect()
    {
        Vector3[] pushes = {Vector3.up,Vector3.left,Vector3.down,Vector3.right};
        int count = 0;
        bool equilizedAlready = false;
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            GetComponent<Rigidbody>().AddForce(pushes[count] * pushAmount);
            if (count == 0)
            {
                GetComponent<Rigidbody>().AddForce(pushes[3] * pushAmount);
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(pushes[count - 1] * pushAmount);
            }
            if (count == 3)
                count = 0;
            else
                count++;
            if(!equilizedAlready)
                if(count == 2)
                {
                    GetComponent<Rigidbody>().AddForce(pushes[count] * pushAmount);
                    equilizedAlready = true;
                }
        }
    }
    */
}
