using System;

namespace CrushLink.Code.Infrastructure.Services.UpdateBehaviorService
{
    public interface IUpdateBehaviourService
    {
        event Action UpdateEvent;
        event Action FixedUpdateEvent;
        event Action LateUpdateEvent;
    }
}