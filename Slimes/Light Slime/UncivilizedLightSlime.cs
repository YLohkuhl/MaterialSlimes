using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class UncivilizedLightSlime
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
        SlimeDefinition radSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME);
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(radSlimeDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.lightIds.UNCIVILIZED_LIGHT_SLIME
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
        {
            SlimeEat.FoodGroup.NONTARRGOLD_SLIMES
        };
        foreach (Identifiable.Id slimeIds in Identifiable.SLIME_CLASS)
        {
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[]
            {
                // just additional support if it even works lol
                Identifiable.Id.GOLD_SLIME,
                Identifiable.Id.TARR_SLIME,
                slimeIds,
                // other?
                otherIds.FRAGMENT_SLIME,
                // material slimes eashfjs
                ModdedIds.glueIds.GLUE_SLIME,
                ModdedIds.plasticIds.PLASTIC_SLIME,
                ModdedIds.glassIds.GLASS_SLIME,
                ModdedIds.metalIds.METAL_SLIME,
                ModdedIds.woodIds.WOOD_SLIME,
                ModdedIds.concreteIds.CONCRETE_SLIME,
                ModdedIds.cottonIds.COTTON_SLIME,
                ModdedIds.copperIds.COPPER_SLIME,
                ModdedIds.iceIds.ICE_SLIME,
                ModdedIds.soilIds.SOIL_SLIME,
                ModdedIds.grassIds.GRASS_SLIME,
                ModdedIds.silverIds.SILVER_SLIME,
                // special dang it
                ModdedIds.newbuckIds.NEWBUCK_SLIME,
                ModdedIds.providerIds.PROVIDER_SLIME,
                ModdedIds.lightIds.LIGHT_SLIME,
                ModdedIds.darkIds.CIVILIZED_DARK_SLIME,
            };
        }
        slimeDefinition.Diet.Favorites = new Identifiable.Id[0];
        slimeDefinition.Diet.EatMap?.Clear();
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[1];
        slimeDefinition.Name = "Uncivilized Light Slime";
        slimeDefinition.IdentifiableId = ModdedIds.lightIds.UNCIVILIZED_LIGHT_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
        slimeObject.name = "slimeUncivilizedLight";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.lightIds.UNCIVILIZED_LIGHT_SLIME;
        slimeObject.AddComponent<MaterialDecay>();
        UnityEngine.Object.Destroy(slimeObject.GetComponent<FleeThreats>());
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(radSlimeDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", Color.yellow);
                material.SetColor("_MiddleColor", Color.black);
                material.SetColor("_BottomColor", Color.yellow);
                material.SetColor("_SpecColor", Color.black);
                // material.SetColor("_MiddleColor", new Color32(255, 255, 0, 255));
                // material.SetColor("_EdgeColor", new Color32(255, 255, 0, 255));
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
                slimeAppearanceStructure.DefaultMaterials[0] = material;
                // you took way to dang long dang it
                Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.RAD_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                material2.SetColor("_MiddleColor", new Color32(255, 255, 0, 255));
                material2.SetColor("_EdgeColor", new Color32(0, 0, 0, 255));
                slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
            }
        }
        SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
        for (int k = 0; k < expressionFaces.Length; k++)
        {
            SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
            if ((bool)slimeExpressionFace.Mouth)
            {
                slimeExpressionFace.Mouth.SetColor("_MouthBot", Color.black);
                slimeExpressionFace.Mouth.SetColor("_MouthMid", Color.black);
                slimeExpressionFace.Mouth.SetColor("_MouthTop", Color.black);
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /*
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", Color.yellow);
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", Color.black);
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", Color.yellow);
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Light.uncivilized_light_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = Color.yellow,
            Middle = Color.black,
            Bottom = Color.yellow
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.lightIds.UNCIVILIZED_LIGHT_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Light.uncivilized_light_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}