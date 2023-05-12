using UnityEngine;

namespace Demicus.Code.Extensions
{
    public static class Utils
    {
        public static T ToDeserialized<T>(this string json) => JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);
        
        public static bool IsLayerMaskHasLayer(LayerMask mask, int layer)
        {
            return (mask.value & (1 << layer)) > 0;
        }
    }
}