using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentMover : MonoBehaviour {

    [SerializeField] float destinationReachedTreshold;
    private NavMeshAgent agent;
    public bool isStopped;
    public float remainingDistance;
    public bool isTraveling;
    public float threshold;
    public float range = 1;
      private Coroutine _currentRoutine;
    private void Start() {

        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        Travel();

    }

    private void Update() {
        isStopped = agent.isStopped;
        remainingDistance = agent.remainingDistance;
    }

    private void Travel() {
        Vector2 randoPoint = Utils.RandomPoint(range);
        //agent.SetDestination(randoPoint);
        MoveTo(randoPoint,threshold,Travel);
    }

    private bool hasArrived {
        get {
            return Vector3.Distance(transform.position, agent.destination) < threshold;
        }
    }

    public void MoveTo(Vector3 position, float stopDistance, Action onArrivedAtPosition) {
        // Here can/have to decide
        // Either Option A
        // do not allow a new move call if there is already one running
        if (_currentRoutine != null) return;
        // OR Option B
        // interrupt the current routine and start a new one
        if (_currentRoutine != null) StopCoroutine(_currentRoutine);

        // Set the destination directly
        agent.SetDestination(position);

        // and start a new routine
        _currentRoutine = StartCoroutine(WaitUntilArivedPosition(position, onArrivedAtPosition));
    }

    private IEnumerator WaitUntilArivedPosition(Vector3 position, Action onArrivedAtPosition) {
        // yield return tells Unity "pause the routine here,
        // render this frame and continue from here in the next frame"
        // WaitWhile does what the name suggests
        // waits until the given condition is true
        yield return new WaitUntil(() => hasArrived);

        _currentRoutine = null;
        onArrivedAtPosition?.Invoke();
    }

    private Vector2 GetNewTarget() {

        return Vector2.one;

    }
    public bool CheckDestinationReached(Vector2 pos, Vector2 target, float threshhold) {
        float distanceToTarget = Vector2.Distance(pos, target);
        if (distanceToTarget < threshhold) {
            return false;
        }
        else {
            return true;
        }
    }
}