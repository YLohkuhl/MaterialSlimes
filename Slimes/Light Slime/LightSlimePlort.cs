using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SRML.Utils;
using SRML.SR;
using Object = UnityEngine.Object;

class LightSlimePlort
{
    public static GameObject LightPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Light Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.lightIds.LIGHT_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color PureYellow = Color.yellow; // RGB   
        Color White = Color.white;
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", PureYellow);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", White);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", PureYellow);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}