using UnityEditor.Rendering;
using UnityEngine;

public abstract class Motor : MonoBehaviour {

    [SerializeField] protected Rigidbody2D rb2d;
    [SerializeField] protected float speed = 500;
    [SerializeField] protected float range;
    [SerializeField] protected float jumpSpeed = 800;
    [SerializeField] protected float maxSpeedVertical = 3;


    protected virtual Vector2 ClampedVelocity(Rigidbody2D rb2d, float maxSpeedVertical) {
        var velX = rb2d.velocity.x;
        var velY = rb2d.velocity.y;

        var clampedVelocity = new Vector2(Mathf.Clamp(velX, -maxSpeedVertical, maxSpeedVertical), rb2d.velocity.y);
        return clampedVelocity;
    }

    protected virtual Vector2 Force(float input, float speed, float maxSpeedVertical) {
        Vector2 force = new Vector2(input * speed * Time.fixedDeltaTime, 0);
        return force;
    }

}