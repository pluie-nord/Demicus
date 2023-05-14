using Demicus.Code.Infrastructure.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Demicus.Code.Infrastructure.Services.UIFactory;

namespace Demicus.Code.Runtime.Components
{
    public class LocationInfoComponent : MonoBehaviour
    {
        [SerializeField] public SceneID _sceneToLoad;
        [TextArea] public string _name;
        [TextArea] public string _descriprion;
        
        
    }
}