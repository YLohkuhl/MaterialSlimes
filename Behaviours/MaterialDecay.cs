using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static SlimeEmotions;

// this code is broken, stop snooping
namespace Behaviours
{
    class MaterialDecay : SlimeSubbehaviour
    {
        private GameObject discoverySlime;
        public override void Awake()
        {
            discoverySlime = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(ModdedIds.discoveryIds.DISCOVERY_SLIME));
        }
        public override void Action()
        {
            Destroy(discoverySlime);
            Console.WriteLine("Self Discovery Slime disappeared due to not being fed. :[");
        }
        public override float Relevancy(bool isGrounded)
        {
            if (emotions.GetCurr(SlimeEmotions.Emotion.AGITATION) >= 0.5f) //When the slime starts to get agitated
                return 1f; //This means do the action. Important; don't remove it
            return 0f; //This means don't do the actions. Important; don't remove it
        }

        public override void Selected() { }
    }
}
