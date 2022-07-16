using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class IceSlimePlort
{
    public static GameObject IcePlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.BOOM_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Ice Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.iceIds.ICE_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color IceColor = Color.cyan; // RGB
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", IceColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", Color.white);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", IceColor);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}
