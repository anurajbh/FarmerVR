using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] int speed = 0;
    	// Start is called before the first frame update
    	void Start()
    	{
        
    	}
    	// Update is called once per frame
    	void Update()
    	{
        	float moveHor = Input.GetAxis("Horizontal");
		float moveVert = Input.GetAxis("Vertical");
		Vector3 position = transform.position;
      		position.x += moveHor * speed * Time.deltaTime;
      		position.z += moveVert * speed * Time.deltaTime;
      		transform.position = position;	
    	}
}
