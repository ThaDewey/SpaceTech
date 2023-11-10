using System.CodeDom;
using UnityEngine;

public class AgentMover : MonoBehaviour {

	private Rigidbody2D rb2d;

	[SerializeField] private float maxSpeed = 5;
	[SerializeField] private float minSpeed = 2;
	[SerializeField] private float accelaration = 50;
	[SerializeField] private float deacceraltion = 100;


	private float currentSpeed = 0;
	private Vector2 oldMovementInput;

	public Vector2 MovementInput { get; set; }
	public bool isRunning { get; set; }


	public void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}


	private void FixedUpdate() {
		if (MovementInput.magnitude > 0 && currentSpeed >= 0) {
			oldMovementInput = MovementInput;
			if (isRunning) {
				IncreaseSpeed(maxSpeed);
			} else {
				IncreaseSpeed(minSpeed);
			}
		} else {
			DecreaseSpeed(maxSpeed);
		}

		if (isRunning) {
			currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

		} else {
			currentSpeed = Mathf.Clamp(currentSpeed, 0, minSpeed);
		}
		rb2d.velocity = oldMovementInput * currentSpeed;

	}

	private void IncreaseSpeed(float speed) {
		currentSpeed += CalcSpeed(speed);
	}
	private void DecreaseSpeed(float speed) {
		currentSpeed -= CalcSpeed(speed);
	}
	private float CalcSpeed(float speed) {
		return accelaration * speed * Time.deltaTime;
	}
}