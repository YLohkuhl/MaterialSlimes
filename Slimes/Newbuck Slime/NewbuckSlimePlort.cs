using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SRML.Utils;
using SRML.SR;
using Object = UnityEngine.Object;

class NewbuckSlimePlort
{
    public static GameObject NewbuckPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PHOSPHOR_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Newbuck Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.newbuckIds.NEWBUCK_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color NewbuckColor = new Color32(244, 182, 73, 255);
        Color DarkerNewbuckColor = new Color32(158, 63, 20, 255);
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", NewbuckColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", DarkerNewbuckColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", NewbuckColor);
        /*Prefab.transform.Find("glow").GetComponent<MeshRenderer>().material.SetColor("_TopColor", Color.white);
        Prefab.transform.Find("glow").GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", NewbuckColor);
        Prefab.transform.Find("glow").GetComponent<MeshRenderer>().material.SetColor("_BottomColor", DarkerNewbuckColor);*/

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
    public static GameObject RichNewbuckPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PHOSPHOR_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Rich Newbuck Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color NewbuckColor = new Color32(244, 182, 73, 255);
        Color DarkerNewbuckColor = new Color32(158, 63, 20, 255);
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", DarkerNewbuckColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", NewbuckColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", DarkerNewbuckColor);
        /*Prefab.transform.Find("glow").GetComponent<MeshRenderer>().material.SetColor("_TopColor", Color.white);
        Prefab.transform.Find("glow").GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", NewbuckColor);
        Prefab.transform.Find("glow").GetComponent<MeshRenderer>().material.SetColor("_BottomColor", DarkerNewbuckColor);*/

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
    public static GameObject RicherNewbuckPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PHOSPHOR_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Richer Newbuck Plort";

        Prefab.GetComponent<Identifiable>().id = ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        GameObject QuantumPrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.QUANTUM_PLORT));

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(QuantumPrefab.GetComponent<MeshRenderer>().material);
        Color NewbuckColor = new Color32(244, 182, 73, 255);
        Color DarkerNewbuckColor = new Color32(158, 63, 20, 255);
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", DarkerNewbuckColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", NewbuckColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", DarkerNewbuckColor);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}