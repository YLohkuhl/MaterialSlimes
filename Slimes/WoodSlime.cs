using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WoodSlime
{
    class WoodSlime
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
        public static (SlimeDefinition, GameObject) CreateSlime(Identifiable.Id SlimeId, String SlimeName)
        {
            // DEFINE
            SlimeDefinition honeySlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(honeySlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
                ModdedIds.woodIds.WOOD_PLORT
            };
            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[3]
            {
                SlimeEat.FoodGroup.VEGGIES,
                SlimeEat.FoodGroup.FRUIT,
                SlimeEat.FoodGroup.MEAT
            };
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];
            slimeDefinition.Diet.Favorites = new Identifiable.Id[0];
            slimeDefinition.Diet.EatMap?.Clear();
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[0];
            slimeDefinition.Name = "Wood Slime";
            slimeDefinition.IdentifiableId = ModdedIds.woodIds.WOOD_SLIME;
            // OBJECT
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeWood";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = ModdedIds.woodIds.WOOD_SLIME;
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            // APPEARANCE
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(honeySlimeDefinition.AppearancesDefault[0]);
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", new Color32(150, 111, 51, 255));
                    material.SetColor("_MiddleColor", new Color32(205, 170, 125, 255));
                    material.SetColor("_BottomColor", new Color32(150, 111, 51, 255));
                    material.SetColor("_SpecColor", new Color32(205, 170, 125, 255));
                    material.SetFloat("_Shininess", 1f);
                    material.SetFloat("_Gloss", 1f);
                    slimeAppearanceStructure.DefaultMaterials[0] = material;
                }
            }
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", Color.white);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", Color.white);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", Color.white);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {   /*
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                    */
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", Color.white);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", Color.white);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", Color.white);
                }
            }
            slimeAppearance.Icon = CreateSprite(LoadImage("Assets.wood_slime.png"));
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = new Color32(150, 111, 51, 255),
                Middle = new Color32(205, 170, 125, 255),
                Bottom = new Color32(150, 111, 51, 255)
            };
            PediaRegistry.RegisterIdEntry(ModdedIds.woodIds.WOOD_ENTRY, CreateSprite(LoadImage("Assets.wood_slime.png")));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            return (slimeDefinition, slimeObject);
        }
    }
}
