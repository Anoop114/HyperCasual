using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour {
    
	public Vector3 center;
	public Vector3 size;
	
	public Vector3 RandomPosition(){
		float xPos = Random.Range(center.x - size.x * 0.5f, center.x + size.x * 0.5f);
		float zPos = Random.Range(center.z - size.z * 0.5f, center.z + size.z * 0.5f);
		
		return new Vector3(xPos, 0, zPos);
	}
	
	void OnDrawGizmosSelected(){
		Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawCube(center, size);
	}
}
