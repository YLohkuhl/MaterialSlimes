using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ConcreteSlime
{
    class ConcreteSlimePlort
    {
        public static GameObject ConcretePlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.SABER_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Concrete Plort";

            Prefab.GetComponent<Identifiable>().id = ModdedIds.concreteIds.CONCRETE_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color ConcreteColor = Color.grey; // RGB   
            Color White = Color.white;
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", ConcreteColor);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", White);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", ConcreteColor);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
