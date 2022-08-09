using MonomiPark.SlimeRancher.Regions;
using SRML;
using SRML.SR;
using SRML.SR.Translation;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// bruh (lol this has no use anymore after organization thingy update kkasdjgjksd)

// bruh 2
/*using SecretStyles;
using SecretStyle;*/

namespace MaterialSlimes
{

    /*public struct SpeckleInstructions
    {
        public bool active;
        public float addR;
        public float addG;
        public float addB;
        public string applyTo;
    }

    public struct GlowInstructions
    {
        public Color32 color;
        public float[] max;
        public float[] min;
    }*/

    public class Main : ModEntryPoint
    {

        public static Texture2D LoadImage(string filename)
        {
            var a = Assembly.GetExecutingAssembly();
            var spriteData = a.GetManifestResourceStream(a.GetName().Name + "." + filename);
            var rawData = new byte[spriteData.Length];
            spriteData.Read(rawData, 0, rawData.Length);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(rawData);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }
        public static Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);

        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            PreloadPoint.PreLoadTranslations();
            PreloadPoint.PreloadSpawners();
            PreloadPoint.PreloadOtherPedias();

            /*if (Configs.Values.MATERIAL_LARGOS)
            {
                foreach (string name in typeof(largoIds).GetFields().Select(x => x.Name))
                {
                    IdentifiableRegistry.CreateIdentifiableId(EnumPatcher.GetFirstFreeValue(typeof(Identifiable.Id)), name);
                }
            }*/
        }

        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            LoadPoint.LoadSlimes(); LoadPoint.LoadPlorts(); // slime plort
            LargoLibFunc.LoadLargos(); // largoo
            LoadPoint.LoadGadgets(); LoadPoint.LoadItems(); // gadget item

            //./---------- GADGETS/ITEMS FOR MATERIAL SLIMES ----------\.\\


            //./---------- SECRET STYLES FOR MATERIAL SLIMES ----------\.\\


            /*if (SRModLoader.IsModPresent("mosecretstyles"))
            {
                SpeckleInstructions noSpeckle = new SpeckleInstructions() { active = false, addB = 0f, addR = 0f, addG = 0f, applyTo = "_None" };
                GlowInstructions noGlow = new GlowInstructions() { color = Color.clear, max = new float[] { 0f }, min = new float[] { 0f } };
                SlimeExpressionFace[] noface = new SlimeExpressionFace[0];
                SecretStyleFunctions.MSSDoTheThing(ModdedIds.glueIds.GLUE_SLIME, new Vector3(PodX, PodY, PodZ), Quaternion.Euler(PodRotX, PodRotY, PodRotZ), SpriteSS, "CellName", "SSname", "SlimenameLower", SecretStylesDesigns.GlueSlimeSS(), SplatTopSS, SplatMiddleSS, SplatBottomSS, VacColorSS, ChangeFaceBool, noFaceOrNewFace);
                if (SRModLoader.IsModPresent("secretstylethings"))
                {
                    Sprite GPICON = CreateSprite(LoadImage("Assets.Slimes.glue_slime_plort.png"));
                    SecretStyleFunctionsSST.SSTDoTheThing(ModdedIds.glueIds.GLUE_PLORT, GPICON); //for plort
                }
            }*/
        }
        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
            //-- POST LOAD --\\
        }

    }
}