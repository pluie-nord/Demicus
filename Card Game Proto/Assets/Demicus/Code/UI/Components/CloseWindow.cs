using UnityEngine;
using Demicus.Code.Infrastructure.Data;
using Zenject;
using Demicus.Code.Infrastructure.Services.UIFactory;

public class CloseWindow : MonoBehaviour
{
    private IUIFactory _UIFactory;

    [Inject]
    private void Constructor(IUIFactory UIFactory)
    {
        _UIFactory = UIFactory;
    }

    public void Close()
    {
        _UIFactory.ClearUIRoot();
    }
}
