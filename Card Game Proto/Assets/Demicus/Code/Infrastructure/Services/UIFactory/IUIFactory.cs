using Demicus.Code.Infrastructure.Data;
using UnityEngine;

namespace Demicus.Code.Infrastructure.Services.UIFactory
{
    public interface IUIFactory
    {
        void CreateUiRoot();
        GameObject CreateWindow(WindowID windowID);
        T CreateWindow<T>(WindowID windowID);
        void ClearUIRoot();
    }
}