using UnityEngine;

public static class Utils {


    public static Vector2 SetNewDestination(float min, float max) {

        float x = RandomFloat(min, max);
        float y = RandomFloat(min, max);

        return new Vector2(x, y);
    }
    public static float RandomFloat(float f) => Random.Range(-f, f);
    public static float RandomFloat(float min, float max) => Random.Range(min, max);

    public static int RandomInt(int min, int max) => Random.Range(min, max);
    public static int RandomInt(int i) => Random.Range(-i, i);
    public static Vector2Int RandomVector2Int(int min, int max) {
        int x = RandomInt(min, max);
        int y = RandomInt(min, max);
        return new Vector2Int(x, y);
    }

    public static Vector2 RandomPoint(float range) {
        return Random.insideUnitCircle * range;
    }

    public static bool CheckDestinationReached(Vector2 pos, Vector2 target, float threshhold) {
        float distanceToTarget = Vector2.Distance(pos, target);
        if (distanceToTarget < threshhold) {
            return false;
        }
        else {
            return true;
        }
    }
}