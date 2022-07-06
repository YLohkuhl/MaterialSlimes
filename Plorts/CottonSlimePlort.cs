using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CottonSlime
{
    class CottonSlimePlort
    {
        public static GameObject CottonPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.HUNTER_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Cotton Plort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.cottonIds.COTTON_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color CottonColor = new Color32(230, 226, 222, 255); // RGB   
            Color CottonTone = new Color32(255, 251, 246, 255);
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", CottonColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", CottonTone);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", CottonColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
