using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class NCPWander : MonoBehaviour {


    [SerializeField] private float range = 5;

    private Vector2 target;
    public bool usePhsysics;



    public void Move() {
        var dur = randomDuration(1, 3);
        var pos = GetPosition();
        transform.DOMove(pos, dur).OnComplete(DelayThings);
    }

    private void Awake() {

    }
    void Start() {
        Move();
    }


    public void DelayThings() {
        var delay = randomDelay(1, 3);
        DOVirtual.DelayedCall(delay, Move);

    }

    private float randomDelay(float min, float max) => Random.Range(min, max);
    private float randomDuration(float min, float max) => Random.Range(min, max);
    private Vector2 GetPosition() {
        return Random.insideUnitCircle * range;
    }



}
