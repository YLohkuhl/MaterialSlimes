using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GrassSlime // Slime name here
{
    public static Texture2D LoadImage(string filename) // thanks aidan or whoever created this at first- lol
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
        SlimeDefinition grassDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.ROCK_SLIME); // make sure to make slimeNameDefiniton your slime name btw-
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(grassDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.grassIds.GRASS_PLORT
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[2]
        {
            SlimeEat.FoodGroup.VEGGIES,
            SlimeEat.FoodGroup.FRUIT
        };
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[2] // additional foods
        {
            Identifiable.Id.DEEP_BRINE_CRAFT,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[2] // favorites
        {
            Identifiable.Id.DEEP_BRINE_CRAFT,
            itemIds.MATERIAL_SQUEEZE_CRAFT
        };
        slimeDefinition.Diet.EatMap?.Clear(); // don't touch this unless your probably a little more advanced, idk
        /* TARR SUPPORT (this is if you want it)
        SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
        slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
        {
            Ids.YOUR_SLIME_ID
        };*/
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[1];
        slimeDefinition.Name = "Grass Slime";
        slimeDefinition.IdentifiableId = ModdedIds.grassIds.GRASS_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
        slimeObject.name = "slimeGrass";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.grassIds.GRASS_SLIME;
        // .AddComponent for new components, below with UnityEngine shows how to destroy components, and get them is pretty obvious.
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        Color ColorVar1 = new Color32(34, 139, 34, 255); // green
        Color ColorVar2 = new Color32(152, 251, 152, 255); // lighter green
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(grassDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                // SET MATERIALS HERE!! Btw above is if you want color vars-
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.ROCK_DERVISH_LARGO).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", ColorVar1);
                material.SetColor("_MiddleColor", ColorVar1);
                material.SetColor("_BottomColor", ColorVar1);
                material.SetColor("_SpecColor", ColorVar2);
                material.SetFloat("_Shininess", 1f); // idk what these are for tbh, but you can use it if you want
                material.SetFloat("_Gloss", 1f); // same thing here lol
                slimeAppearanceStructure.DefaultMaterials[0] = material;
                // THIS ADDS RAD SLIME AURAS, CAHNGE MIDDLE_COLOR AND EDGE_COLOR, IT WORKS I THINK, IT SHOULD AT LEAST.
                Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TANGLE_DERVISH_LARGO).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material2.SetColor("_TopColor", ColorVar2);
                material2.SetColor("_MiddleColor", ColorVar2);
                material2.SetColor("_BottomColor", ColorVar1);
                slimeAppearance.Structures[1].DefaultMaterials[0] = material2;
            }
        }
        SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
        for (int k = 0; k < expressionFaces.Length; k++)
        {
            SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
            if ((bool)slimeExpressionFace.Mouth)
            {
                slimeExpressionFace.Mouth.SetColor("_MouthBot", ColorVar2);
                slimeExpressionFace.Mouth.SetColor("_MouthMid", ColorVar2);
                slimeExpressionFace.Mouth.SetColor("_MouthTop", ColorVar2);
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /* this is the default one in frosty's wiki I think
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", ColorVar2);
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", ColorVar2);
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", ColorVar2);
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Grass.grass_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = ColorVar1,
            Middle = ColorVar2,
            Bottom = ColorVar1
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.grassIds.GRASS_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Grass.grass_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}