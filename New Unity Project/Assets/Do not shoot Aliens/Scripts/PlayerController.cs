using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
   public Joystick joystick;
   public CharacterController controller;
   public Animator anim;
   public Image bulletIndicator;
   public Transform targetIndicator;
   public Transform target;
   public ParticleSystem movementEffect;
   public ParticleSystem shootingEffect;
   public GameObject bloodEffect;
   
   public Transform gunFront;
   public GameObject bullet;
   
   public float speed;
   public float gravity;
   public float bulletCount;
   public float reloadSpeed;
   
   Vector3 moveDirection;
   float bullets = 1f;
   
   bool reloading;
   
   List<GameObject> bulletStorage = new List<GameObject>();
   
   [HideInInspector]
   public bool safe;
   
   GameManager manager;
   
   void Start(){
	   manager = GameObject.FindObjectOfType<GameManager>();
   }
   
   void Update(){
	   if(!manager.gameStarted)
		   return;
	   
	   Vector2 direction = joystick.direction;
	   
	   if(controller.isGrounded){
            moveDirection = new Vector3(direction.x, 0, direction.y);
			
			Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
			transform.rotation = targetRotation;
	
            moveDirection = moveDirection * speed;
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
		
		if(!reloading && !safe){
			if(bullets > 0){
				bullets -= Time.deltaTime * 1f/bulletCount;
			}
			else{
				reloading = true;
			}
		}
		else{
			if(bullets < 1f){
				bullets += Time.deltaTime * reloadSpeed;
			}
			else{
				reloading = false;
			}
		}
		
		bulletIndicator.fillAmount = bullets;
		
		if(anim.GetBool("Moving") != (direction != Vector2.zero)){
			anim.SetBool("Moving", direction != Vector2.zero);
			
			if(direction != Vector2.zero){
				movementEffect.Play();
			}
			else{
				movementEffect.Stop();
			}
		}
		
		if(anim.GetBool("Reloading") != (reloading || safe))
			anim.SetBool("Reloading", (reloading || safe));
		
		if(!safe){
			Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
			Quaternion targetIndicatorRotation = Quaternion.LookRotation((targetPosition - transform.position).normalized);
			targetIndicator.rotation = Quaternion.Slerp(targetIndicator.rotation, targetIndicatorRotation, Time.deltaTime * 50);
		}	
   }
   
   public void Fire(){
	   GameObject newBullet = bulletStorage.Count > 0 ? recycleBullet() : Instantiate(bullet);
	   
	   newBullet.transform.rotation = transform.rotation;
	   newBullet.transform.position = gunFront.position;
	   
	   Bullet bulletController = newBullet.GetComponent<Bullet>();
	   bulletController.player = this;
	   shootingEffect.Play();
   }
   
   public void SwitchSafeState(bool safe){
	   this.safe = safe;
	   
	   targetIndicator.gameObject.SetActive(!safe);
   }
   
   public void Die(){
	   Instantiate(bloodEffect, transform.position + Vector3.up * 1.5f, transform.rotation);
	   Destroy(gameObject);
   }
   
   GameObject recycleBullet(){
	   GameObject newBullet = bulletStorage[0];
	   bulletStorage.Remove(newBullet);
	   newBullet.SetActive(true);
	   
	   return newBullet;
   }
   
   public void DisableBullet(GameObject targetBullet){
	   targetBullet.SetActive(false);
	   bulletStorage.Add(targetBullet);
   }
}
