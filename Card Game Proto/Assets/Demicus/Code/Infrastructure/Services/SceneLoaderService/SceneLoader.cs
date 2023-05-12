using System;
using System.Collections;
using DG.Tweening;
using Demicus.Code.Infrastructure.Data;
using Demicus.Code.Infrastructure.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Demicus.Code.Infrastructure.Services.SceneLoaderService
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _faderImage;
        [SerializeField] private float _fadeTime;
        [SerializeField] private float _delayTime;

        private IEnumerator _loadingRoutine;
        private Tween _imageTween;

        //Fading on load
        public void LoadScene(string sceneName, Action onLoaded = null)
        {
            _faderImage.raycastTarget = true;
            _imageTween?.Kill();
            Debug.Log("Fading");
            _imageTween = _canvasGroup.DOFade(1, _fadeTime)
                .OnComplete(() => StartLoadingOperation(sceneName, onLoaded))
                .SetUpdate(true);
        }

        public void LoadScene(SceneID sceneID, Action onLoaded = null)
        {
            LoadScene(sceneID.ToString(), onLoaded);
        }

        private void StartLoadingOperation(string sceneName, Action onLoaded)
        {
            Time.timeScale = 1;
            _loadingRoutine = LoadingScreenStartRoutine(sceneName, onLoaded);
            StartCoroutine(_loadingRoutine);
        }

        private IEnumerator LoadingScreenStartRoutine(string sceneName, Action onLoaded)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            while (operation != null && !operation.isDone)
                yield return 0;
            yield return new WaitForSecondsRealtime(_delayTime);
            onLoaded?.Invoke();
            _loadingRoutine = null;
            _imageTween = _canvasGroup.DOFade(0, _fadeTime).SetUpdate(true);
            _faderImage.raycastTarget = false;
        }

        private void OnDestroy()
        {
            _imageTween?.Kill();
        }
    }
}