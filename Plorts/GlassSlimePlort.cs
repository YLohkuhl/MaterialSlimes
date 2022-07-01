using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GlassSlime
{
    class GlassSlimePlort
    {
        public static GameObject GlassPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Glass Plort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.glassIds.GLASS_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color GlassColor = new Color32(191, 238, 237, byte.MaxValue); // RGB   
            Color White = Color.white;
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", GlassColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", White);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", GlassColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
