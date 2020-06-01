using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float moveSpeed = 2f;
	public float boardOffset = 0.25f;

    private float screenHeight = 10;
    private float screenWeigth = 5;

	private float minXpos = -2f;
	private float maxXpos = 2f;
	private float offsetPos = 0.5f;

	private float horizontalInput = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        screenHeight = 2f * mainCamera.orthographicSize;
 		screenWeigth = screenHeight * mainCamera.aspect;

 		float gameObjSizeX = GetComponent<Renderer>().bounds.size.x;
 		offsetPos = gameObjSizeX/2;
 		maxXpos = (screenWeigth/2) - offsetPos - boardOffset;
 		minXpos = -1 * maxXpos;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() 
    {
    	Vector3 currPosition = transform.position;
    	float nextXPos = currPosition.x + (horizontalInput * moveSpeed * Time.deltaTime);
    	if(nextXPos >= maxXpos)
    	{
    		nextXPos = maxXpos;
    	}
    	else if(nextXPos <= minXpos)
    	{
    		nextXPos = minXpos;
    	}
    	transform.position = new Vector3(nextXPos, currPosition.y, currPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
    	Debug.Log("Cpalyer ollision!!!");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

}
