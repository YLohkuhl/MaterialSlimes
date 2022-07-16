using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class WoodSlimePlort
{
    public static GameObject WoodPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Wood Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.woodIds.WOOD_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color WoodColor = new Color32(150, 111, 51, 255); // RGB   
        Color LightWoodColor = new Color32(205, 170, 125, 255);
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", WoodColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", LightWoodColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", WoodColor);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}
