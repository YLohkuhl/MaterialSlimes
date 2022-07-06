using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MetalSlime
{
    class MetalSlimePlort
    {
        public static GameObject MetalPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROCK_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Metal Plort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.metalIds.METAL_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color MetalColor = Color.grey; // RGB   
            Color Black = Color.black;
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", MetalColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", Black);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", MetalColor);
            Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_TopColor", Color.white);
            Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", MetalColor);
            Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_BottomColor", MetalColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
