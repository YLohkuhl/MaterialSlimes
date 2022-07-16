using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class IceSlime
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
        SlimeDefinition boomSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.BOOM_SLIME);
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(boomSlimeDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.iceIds.ICE_PLORT
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[0];
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[4]
        {
            Identifiable.Id.PUDDLE_PLORT,
            Identifiable.Id.PUDDLE_SLIME,
            Identifiable.Id.OCAOCA_VEGGIE,
            itemIds.MATERIAL_SQUEEZE
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[1]
        {
            itemIds.MATERIAL_SQUEEZE
        };
        slimeDefinition.Diet.EatMap?.Clear();
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[0];
        slimeDefinition.Name = "Ice Slime";
        slimeDefinition.IdentifiableId = ModdedIds.iceIds.ICE_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
        slimeObject.name = "slimeIce";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.iceIds.ICE_SLIME;
        slimeObject.AddComponent<DamagePlayerOnTouch>();
        // UnityEngine.Object.Destroy(slimeObject.GetComponent<SlimeEatWater>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(boomSlimeDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                Material material = new Material(SceneContext.Instance.SlimeAppearanceDirector.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.BOOM_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", Color.cyan);
                material.SetColor("_MiddleColor", Color.cyan);
                material.SetColor("_BottomColor", Color.cyan);
                material.SetColor("_SpecColor", Color.cyan);
                material.SetColor("_CrackColor", Color.white);
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
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Ice.ice_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = new Color32(165, 242, 243, 255),
            Middle = Color.white,
            Bottom = new Color32(165, 242, 243, 255)
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.iceIds.ICE_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Ice.ice_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}