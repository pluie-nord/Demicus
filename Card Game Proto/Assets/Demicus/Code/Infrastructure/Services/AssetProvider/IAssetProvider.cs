using System.Collections;
using System.Collections.Generic;
using Demicus.Code.Infrastructure.StaticData;
using UnityEngine;

namespace Demicus.Code.Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        void Load();
        GameStaticData GetGameStaticData();
    }
}

