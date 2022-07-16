using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class OtherPlorts // slime name here, with plorts at the end so its easy to find? idk lol
{
    public static GameObject DangerousPlort()
    {
        GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.RAD_PLORT)); //It can be any plort, but pink works the best. 
        Prefab.name = "Dangerous Plort";

        Prefab.GetComponent<Identifiable>().id = otherIds.DANGEROUS_PLORT;
        Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
        Color BlackColor = Color.black;
        Color GreyColor = Color.grey;
        // SET PLORT COLORS HERE!! Btw above is if you want color vars-
        //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want. (man frosty and his comments collide with mines lol)
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", GreyColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", BlackColor);
        Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", GreyColor);

        LookupRegistry.RegisterIdentifiablePrefab(Prefab);

        return Prefab;
    }
}

