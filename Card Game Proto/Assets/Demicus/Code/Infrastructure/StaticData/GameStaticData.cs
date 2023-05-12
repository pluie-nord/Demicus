using System.Collections.Generic;
using UnityEngine;

namespace Demicus.Code.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "GameStaticData", menuName = "Static Data/GameStaticData")]
    public class GameStaticData : ScriptableObject
    {
        [SerializeField] private WindowConfig[] _windows;

        public IEnumerable<WindowConfig> Windows => _windows;
    }
}