using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    #region variables
    public GameObject followTarget;
    private Vector3 targetPosition;
    private static float followSpeed_Base = 2.0f;
    public float followSpeed_Multiplier = 1.0f;
    #endregion variables

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(followTarget != null)
        {
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, getFollowSpeed() * Time.deltaTime);
        }
    }

    #region getFollowSpeed()
    /*
     * getFollowSpeed()
     * Created to change the moving speed of camera in different operations
     */
    private float getFollowSpeed()
    {
        float cameraSpeed = 0.0f;
        cameraSpeed = followSpeed_Base;
        cameraSpeed *= followSpeed_Multiplier;
        return cameraSpeed;
    }
    #endregion getFollowSpeed()
}
