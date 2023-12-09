using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class NCPMotor : Motor {

    [SerializeField] protected float range;
    [SerializeField] protected Vector2 waypoint;
    [SerializeField] private Vector2 target;
    [SerializeField] private Vector2 currentPos;
    [SerializeField] private float maxDistance;
  

    private void Awake() {

    }
    void Start() {

         target = Random.insideUnitCircle*range;
    }







}
