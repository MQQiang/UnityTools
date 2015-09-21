using UnityEngine;
using System.Collections;


public sealed class ConstParameter
{
    public const float PlayerTillingX = (float)1 / 6;
    public const float PlayerTillingY = 0.2f;
    public const float PlayerTillMoveSpeed = 0.05f;
    public const float InfiniteDistance = 1000.0f;
    public const float AnimationRate = 0.1f;
    public const int StartFrame = 1;
    public const int EndFrame = 5;
    public const int StaticFrame = 0;
    public const float maxMoveRedis = 4.0f;
    public const float minMoveRedis = 2f;


    public const float CharacterUpdateTime = 0.2f;

    public const string BASE_URL = "http://115.29.196.122:3000/";

    //人物血条显示位置相对于人物位置的增量
    public const float BloodTextPosIncrement = 1.0f;
    //人物死亡后延迟销毁的时间
    public const float DeadDelayTime = 0.1f;

    //人物属性六芒星随窗口适配比例
    public const float hexa = 5 / 16;

    public const string dialogueJson = "";
}

public sealed class ConstString
{
    public const string AttackString = "Attack";
    public const string EnemyString = "Enemy";
    public const string PlayerString = "Player";
}

public sealed class ConstDictionary
{
    public static AnimationDirection[] AnimationDirctionary = { new AnimationDirection(EnumDefines.AnimationDirection.BACK, 0, 1), new AnimationDirection(EnumDefines.AnimationDirection.LEFT, -1, 0), new AnimationDirection(EnumDefines.AnimationDirection.RIGHT, 1, 0), new AnimationDirection(EnumDefines.AnimationDirection.FORWARD, 0, -1), new AnimationDirection(EnumDefines.AnimationDirection.BACK_LEFT, -1, 1), new AnimationDirection(EnumDefines.AnimationDirection.BACK_RIGHT, 1, 1), new AnimationDirection(EnumDefines.AnimationDirection.FORWARD_LEFT, -1, -1), new AnimationDirection(EnumDefines.AnimationDirection.FORWARD_RIGHT, 1, -1) };

}


public class Util : object
{

    public static bool IsDistanceNear(Vector3 start, Vector3 end, ref float distance, float standardDistance)
    {
        distance = Vector3.Distance(start, end);
        return Vector3.Distance(start, end) <= standardDistance;
    }
    public static bool IsDistanceNear(Vector3 start, Vector3 end, float standardDistance)
    {
        return Vector3.Distance(start, end) <= standardDistance;
    }
    public static bool IsDistanceNear(GameObject start, GameObject end, float standardDistance)
    {
        return Vector3.Distance(start.transform.position, end.transform.position) <= standardDistance;
    }
    public static bool IsDistanceNear(Vector3 start, GameObject end, float standardDistance)
    {
        return Vector3.Distance(start, end.transform.position) <= standardDistance;
    }

    public static bool IsDistanceNear(Vector3 start, GameObject end, ref float distance, float standardDistance)
    {
        return IsDistanceNear(start, end.transform.position, ref distance, standardDistance);
    }
    public static bool IsDistanceNear(GameObject start, GameObject end, ref float distance, float standardDistance)
    {
        return IsDistanceNear(start.transform.position, end, ref distance, standardDistance);
    }

    public static bool IsPositionZero(Vector3 dis)
    {
        return dis == Vector3.zero;
    }

    public static Vector2 TransformVector3ToVector2In2D(Vector3 position)
    {

        return new Vector2(position.x, position.z);
    }


    public static EnumDefines.AnimationDirection CaculateBestAngle(Vector3 originPosition, Vector3 tagetPosition)
    {
        Vector3 direction = tagetPosition - originPosition;
        return CaculateBestAngle(Util.TransformVector3ToVector2In2D(direction));
    }
    public static EnumDefines.AnimationDirection CaculateBestAngle(Vector2 direction)
    {
        //rotation + 45
        direction = new Vector2(direction.x - direction.y, direction.x + direction.y).normalized;

        float maxValue = 0f;
        EnumDefines.AnimationDirection style = new EnumDefines.AnimationDirection();

        foreach (AnimationDirection dir in ConstDictionary.AnimationDirctionary)
        {

            if (Vector2.Dot(direction, dir.direction.normalized) > maxValue)
            {
                maxValue = Vector2.Dot(direction, dir.direction.normalized);
                style = dir.style;
            }
        }
        return style;
    }
    public static bool HasNetError(ref WWW data)
    {
        if (data.error != null)
            return true;

        return false;
    }

    //遍历某个UI下面的物件，找到相对应名称UI的GameObject
    public static Transform FindChildrRecursion(Transform t, string name)
    {
        if (t.name == name)
        {
            return t;
        }

        Transform a = t.FindChild(name);
        if (a != null)
            return a;

        foreach (Transform r in t)
        {
            a = FindChildrRecursion(r, name);
            if (a != null)
                return a;
        }

        return null;
    }
}
