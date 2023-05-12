using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demicus.Code.Infrastructure.Services.CoroutineRunner
{
    /// <summary>
    /// Used to run coroutines from non MonoBehavior classes
    /// </summary>
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(IEnumerator coroutine);
    }
}
