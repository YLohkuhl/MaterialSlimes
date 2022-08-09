using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class ProviderSlimePlort
{
    public static GameObject ProvidedPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PHOSPHOR_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Provided Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.providerIds.PROVIDED_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color ProviderColor = new Color32(248, 222, 126, 255);
        Color LightProviderColor = new Color32(250, 218, 94, 255);
        Color WhiteColor = new Color32(255, 255, 255, 255);
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", ProviderColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", LightProviderColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", WhiteColor);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}
