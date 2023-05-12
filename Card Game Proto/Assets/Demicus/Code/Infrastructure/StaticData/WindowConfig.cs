using System;
using Demicus.Code.Infrastructure.Data;
using UnityEngine;

namespace Demicus.Code.Infrastructure.StaticData
{
    [Serializable]
    public class WindowConfig
    {
        public WindowID ID;
        public RectTransform Window;
    }
}