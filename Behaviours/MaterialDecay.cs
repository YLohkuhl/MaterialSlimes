using SimpleSRmodLibrary;
using System;
using UnityEngine;
class MaterialDecay : SlimeSubbehaviour
{
    public override void Awake() => base.Awake();

    public override void Action()
    {
        Destroyer.DestroyActor(base.gameObject, "MaterialDecay.Action", false);
        Console.WriteLine(base.gameObject + " has disappeared due to Agitation.");
    }

    public override float Relevancy(bool isGrounded)
    {
        if (this.emotions.GetCurr(SlimeEmotions.Emotion.AGITATION) >= 0.5f) //When the slime starts to get agitated
            return 1f; //This means do the action. Important; don't remove it
        return 0f; //This means don't do the actions. Important; don't remove it
    }

    public override void Selected() { }
}