using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	//Variables visible in the inspector
    public float distance;
    public float height;
	public float smoothness;
	
	public Transform camTarget;
	
	Vector3 velocity;
 
    void LateUpdate(){
		//Check if the camera has a target to follow
        if(!camTarget)
            return;
		
		Vector3 pos = Vector3.zero;
		pos.x = camTarget.position.x;
		pos.y = camTarget.position.y + height;
		pos.z = camTarget.position.z - distance;
		
		transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);
		//transform.LookAt(camTarget.position);
    }
}
