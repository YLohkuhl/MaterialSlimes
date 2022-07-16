using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class SoilSlimePlort
{
    public static GameObject SoilPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DERVISH_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Soil Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.soilIds.SOIL_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color ColorVar1 = new Color32(124, 94, 66, 255); // brown
        Color ColorVar2 = new Color32(219, 226, 233, 255); // gray? chrome? idk rock color
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", ColorVar1);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", ColorVar2);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", ColorVar1);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
    public static GameObject ActualRockPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROCK_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Actual Rock Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.soilIds.ACTUAL_ROCK_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        GameObject DervishPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DERVISH_PLORT));

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(DervishPrefab.GetComponent<MeshRenderer>().material);
        Color ColorVar1 = new Color32(124, 94, 66, 255); // brown
        Color ColorVar2 = new Color32(219, 226, 233, 255); // gray? chrome? idk rock color
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", ColorVar1);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", ColorVar2);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", ColorVar1);
        Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_TopColor", ColorVar2);
        Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", ColorVar2);
        Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_BottomColor", ColorVar2);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}
