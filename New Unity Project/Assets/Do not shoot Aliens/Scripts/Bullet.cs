using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	public float force;
	public float lifetime;
	
	[HideInInspector]
	public PlayerController player;
	
	void OnEnable(){
		StartCoroutine(DestroySelf());
	}
	
	void Update(){
		transform.Translate(Vector3.forward * Time.deltaTime * force);
	}
	
	void OnTriggerEnter(Collider other){
		if(!other.gameObject.CompareTag("Enemy"))
			return;
		
		other.gameObject.GetComponent<Enemy>().Hit();
		player.DisableBullet(gameObject);
	}
	
	IEnumerator DestroySelf(){
		yield return new WaitForSeconds(lifetime);
		
		player.DisableBullet(gameObject);
	}
}
