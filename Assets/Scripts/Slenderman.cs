using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slenderman : MonoBehaviour

   
{
    Camera mainCamera;
    GameObject player;
    public float speed;
    public int RESPAWNSECONDS;
    public System.DateTime startTime;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.Find("Player/Main Camera");
        startTime = System.DateTime.UtcNow;
        //Ignore the collisions between layer 0 (default) and layer 8 (custom layer you set in Inspector window)
        Physics.IgnoreLayerCollision(0, 8);
    }

    // Update is called once per frame
    void Update()
    {

        // Keep facing on player
        transform.LookAt(new Vector3(mainCamera.transform.position.x, transform.position.y, mainCamera.transform.position.z));

        float distance = Vector3.Distance(player.transform.position, transform.position);
        float angle = Vector3.Angle(player.transform.forward, transform.position - player.transform.position);

        // Stop walking
        if (!(angle < 60 && distance < 15))
        {
            Vector3 toTarget = player.transform.position - transform.position;

           transform.Translate(toTarget *  speed * Time.deltaTime);
           //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //Change location based on time
        System.TimeSpan ts = System.DateTime.UtcNow - startTime;
        if(ts.Seconds > RESPAWNSECONDS)
        {
            startTime = System.DateTime.UtcNow;
            transform.position = new Vector3(38, 0.752f, 21);
        }

        if(distance < 1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
