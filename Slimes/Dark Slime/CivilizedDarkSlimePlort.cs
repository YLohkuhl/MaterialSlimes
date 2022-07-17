using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SRML.Utils;
using SRML.SR;
using Object = UnityEngine.Object;

class CivilizedDarkSlimePlort
{
    public static GameObject CivilizedDarkPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Civilized Dark Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.darkIds.CIVILIZED_DARK_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color PureBlack = Color.black; // RGB   
        Color PureYellow = Color.yellow;
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", PureBlack);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", PureYellow);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", PureBlack);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}