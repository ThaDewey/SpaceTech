using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class CollidableObject : MonoBehaviour {
	private Collider2D col;
	[SerializeField] private ContactFilter2D filter;
	[SerializeField] private List<Collider2D> colliders;

	
	public virtual void Start() {
		col = GetComponent<Collider2D>();
	}

	public virtual void OnCollisionEnter2D(Collision2D collision) {
		col.OverlapCollider(filter, colliders);

		foreach (Collider2D c in colliders) {
			OnCollided(c.gameObject);
		}
	}

	public virtual void OnCollided(GameObject GO) {
		Debug.Log("Collided with " + GO.name);

	}

	



}
