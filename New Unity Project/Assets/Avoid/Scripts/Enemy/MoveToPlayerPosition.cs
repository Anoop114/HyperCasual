using UnityEngine;
using System.Collections;

namespace Avoidance
{
	/// <summary>
	/// Lerps position towards GameObject with Player tag.
	/// </summary>
	public class MoveToPlayerPosition : MonoBehaviour 
	{
		/// <summary>
		/// The units to move towards player per second.
		/// </summary>
		public float moveUnitsPerSecond = 5f;

		private Transform _player;

		void Awake()
		{
			_player = GameObject.FindGameObjectWithTag ("Player").transform;
		}
			
		void Update () 
		{
			transform.position = Vector3.MoveTowards (transform.position, _player.position, moveUnitsPerSecond * Time.deltaTime);
		}
	}
}
