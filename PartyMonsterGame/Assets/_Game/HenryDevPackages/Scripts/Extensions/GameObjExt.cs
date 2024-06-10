using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

namespace HenryDev.Utilities
{
    public static class GameObjExt
    {
        public static void StripCloneName(this GameObject gameObject)
        {
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
        public static void DeleteChildren(this Transform transform)
        {
            int childCount = transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        public static T SafeAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var comp = gameObject.GetComponent<T>();
            if (comp != null)
                return comp;
            comp = gameObject.AddComponent<T>();
            return comp;
        }
        public static T SafeAddComponent<T>(this Transform transform) where T : Component
        {
            return transform.gameObject.SafeAddComponent<T>();
        }
    }
    public static class ObjectExt
    {
        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }
        public static T FromJson<T>(this string json) where T : class
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
