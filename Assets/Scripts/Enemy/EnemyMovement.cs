using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour {

    //health and speed of enemy
    private int health;
    private float speed;
    private Vector3 targetPosition;

	void Start () {
        //grabbing info from the EnemyStatus Holder
        health = GetComponent<EnemyStats>().health;
        speed = GetComponent<EnemyStats>().speed;

        //Checks if a gameobject contains the tag "egg", then sets "targetPosition" to that position
        if (GameObject.FindGameObjectWithTag("egg"))
            targetPosition = GameObject.FindGameObjectWithTag("egg").transform.position;

        //Rotates the enemy towards the targetPosition, then propels the object foward. Then adds the slight spiral effect
        transform.LookAt(targetPosition);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        transform.Rotate(new Vector3(0, -90, 0));

        //Set the objects layer to enemy
        gameObject.layer = LayerMask.NameToLayer("enemy");
	}
    private void FixedUpdate()
    {
        //checks if the health drops below zero. If it does, kill the enemy.
        if (health < 0)
            die();

        //checks if the enemy gets close to the target
        if ((transform.position.z - targetPosition.z) < 3)
        {
            //Here we would do stuff like hurt the player. For now, i'm going to outprint ("You lost!");
            if (GetComponent<EnemyStats>().type == EnemyType.instaKill)
            {
                print("You Lost");
                die();
            }
            else
            {
                print("Take some damage");
                die();
            }
        }
    }
    private void die()
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
