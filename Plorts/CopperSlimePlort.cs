using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CopperSlime
{
    class CopperSlimePlort
    {
        public static GameObject CopperPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.ROCK_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Copper Plort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.copperIds.COPPER_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color CopperColor = new Color32(225, 173, 150, 255); // RGB   
            Color CopperTone = new Color32(134, 70, 43, 255);
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", CopperColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", CopperTone);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", CopperColor);
            Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_TopColor", Color.white);
            Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", CopperColor);
            Prefab.transform.Find("rocks").GetComponent<MeshRenderer>().material.SetColor("_BottomColor", CopperTone);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
