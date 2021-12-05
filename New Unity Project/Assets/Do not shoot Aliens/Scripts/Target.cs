using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {
	
	public GameObject carveNavmesh;
	public Animator anim;
	public float leaveDistance;
	
	public Animator tutorial;
	
	public Text scoreText;
	int score;
	
	MoveArea area;
	Transform player;
	
	void Start(){
		area = GameObject.FindObjectOfType<MoveArea>();
		
		carveNavmesh.SetActive(false);
		scoreText.gameObject.SetActive(false);
	}
	
	void Update(){
		if(anim.GetBool("Open") && Vector3.Distance(transform.position, player.position) > leaveDistance){
			anim.SetBool("Open", false);
			
			StartCoroutine(LeftCircle());
		}
	}
	
	public void OnTriggerEnter(Collider other){
		if(!other.gameObject.CompareTag("Player"))
			return;
		
		carveNavmesh.SetActive(true);
		anim.SetBool("Open", true);
		
		player = other.gameObject.transform;
		player.GetComponent<PlayerController>().SwitchSafeState(true);
		
		AddPoints();
	}
	
	void AddPoints(){
		if(!scoreText.gameObject.activeSelf)
			scoreText.gameObject.SetActive(true);
		
		score++;
		scoreText.text = "" + score;
	}
	
	public int GetScore(){
		return score;
	}
	
	IEnumerator LeftCircle(){		
		if(!tutorial.GetBool("Invisible"))
			tutorial.SetBool("Invisible", true);
	
		yield return new WaitForSeconds(0.5f);
		
		carveNavmesh.SetActive(false);
		transform.position = area.RandomPosition();
		player.GetComponent<PlayerController>().SwitchSafeState(false);
	}
}
