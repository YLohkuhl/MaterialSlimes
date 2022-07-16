using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class GrassSlimePlort
{
    public static GameObject GrassPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DERVISH_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Grass Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.grassIds.GRASS_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color ColorVar1 = new Color32(34, 139, 34, 255); // green
        Color ColorVar2 = new Color32(152, 251, 152, 255); // lighter green
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", ColorVar1);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", ColorVar2);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", ColorVar1);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
    public static GameObject PlantPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.TANGLE_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Plant Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.grassIds.PLANT_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        GameObject DervishPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DERVISH_PLORT));

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(DervishPrefab.GetComponent<MeshRenderer>().material);
        Color ColorVar1 = new Color32(34, 139, 34, 255); // green
        Color ColorVar2 = new Color32(152, 251, 152, 255); // lighter green
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", ColorVar1);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", ColorVar2);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", ColorVar1);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}
