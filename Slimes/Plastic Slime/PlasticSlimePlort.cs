using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class PlasticSlimePlort
{
    public static GameObject PlasticPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Plastic Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.plasticIds.PLASTIC_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color MilkyWhite = new Color32(255, 254, 247, byte.MaxValue); // RGB   
        Color Grey = Color.grey;
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", MilkyWhite);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", Grey);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", MilkyWhite);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}
