using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_Winning_Player : MonoBehaviour
{
    // Marks Start and finish of map
    public Transform startMarker;
    public Transform endMarker;
    public Transform player1;
    public Transform player2;
    public Transform EndGoal;

    private float averageY;


    private Vector3 winningPlayerPosition;
    private Vector3 losingPlayerPosition;

    private float distanceBetween;

    public float positionInJourney;
    private float mapLength;

    private Movement movingObject;


    // Start is called before the first frame update
    void Start()
    {


        mapLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = (player1.transform.position - player2.transform.position).magnitude ;
        
        GetComponent<Camera>().orthographicSize = Mathf.Clamp (distanceBetween,5,10);


        if ( Vector3.Distance(EndGoal.position,player1.position) < Vector3.Distance(EndGoal.position, player2.position))
        { winningPlayerPosition = player1.position; losingPlayerPosition = player2.position;

        }
        else
        { winningPlayerPosition = player2.position; losingPlayerPosition = player1.position; }
        
        positionInJourney = Vector3.Distance(winningPlayerPosition, startMarker.position) / mapLength;

        //will make camera follow as player on x axis, but focuses on the players for y axis

        Vector3 targetPoint = Vector3.Lerp(losingPlayerPosition, winningPlayerPosition, 0.75f) + new Vector3(0,0,-100);
        transform.position = Vector3.Lerp(transform.position, targetPoint, 0.5f);
    }
}
