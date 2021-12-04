using UnityEngine;
using System.Collections;

namespace Avoidance
{
	/// <summary>
	/// Sets line renderer sort layer at start of game. 
	/// </summary>
	[RequireComponent(typeof(TrailRenderer))]
	public class SetLineRendererSortLayer : MonoBehaviour 
	{
		public string sortLayerName = "Game";
		private TrailRenderer _trailRenderer;

		// Use this for initialization
		void Awake () 
		{
			_trailRenderer = GetComponent<TrailRenderer> ();
		}

		void Start()
		{
			_trailRenderer.sortingLayerName = sortLayerName;
		}
		

	}
}
