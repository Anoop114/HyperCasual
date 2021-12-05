using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
   
   public Transform player;
   public GameObject enemy;
   public MoveArea area;
   public bool spawning = true;
   
   public float spawnRange;
   public float delay;
   
   public void StartSpawning(){
	   StartCoroutine(Spawn());
   }
   
   IEnumerator Spawn(){
	   while(spawning){
		   yield return new WaitForSeconds(delay);
		   
		   SpawnEnemy();
	   }
   }
   
   void SpawnEnemy(){
	   if(player == null)
		   return;
	   
	   Vector3 spawnPosition = player.position;
	   Vector3 randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
	   
	   spawnPosition += randomPosition;
	   
	   while(!ValidSpawnPoint(spawnPosition)){
		   randomPosition = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
		   spawnPosition = player.position + randomPosition;
	   }
	   
	   Instantiate(enemy, spawnPosition, Quaternion.identity);
   }
   
   bool ValidSpawnPoint(Vector3 position){
	   if(position.x < area.center.x - area.size.x * 0.5f || position.x > area.center.x + area.size.x * 0.5f)
		   return false;
	   
	   if(position.z < area.center.z - area.size.z * 0.5f || position.z > area.center.z + area.size.z * 0.5f)
		   return false;
	   
	   return true;
   }
}
