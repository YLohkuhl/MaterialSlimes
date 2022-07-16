using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ProviderSlime // Slime name here
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
        SlimeDefinition providerDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.DERVISH_SLIME); // make sure to make slimeNameDefiniton your slime name btw-
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(providerDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            Identifiable.Id.CARROT_VEGGIE
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
        {
            SlimeEat.FoodGroup.PLORTS
        };
        slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[13] // additional foods
        {
            ModdedIds.glueIds.GLUE_PLORT,
            ModdedIds.plasticIds.PLASTIC_PLORT,
            ModdedIds.glassIds.GLASS_PLORT,
            ModdedIds.metalIds.METAL_PLORT,
            ModdedIds.woodIds.WOOD_PLORT,
            ModdedIds.concreteIds.CONCRETE_PLORT,
            ModdedIds.cottonIds.COTTON_PLORT,
            ModdedIds.copperIds.COPPER_PLORT,
            ModdedIds.iceIds.ICE_PLORT,
            ModdedIds.newbuckIds.NEWBUCK_PLORT,
            ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT,
            ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT,
            // special dang it
            ModdedIds.darkIds.DARK_SLIME
        };
        slimeDefinition.Diet.Favorites = new Identifiable.Id[0]; // favorites
        slimeDefinition.Diet.EatMap?.Clear(); // don't touch this unless your probably a little more advanced, idk
        // TARR SUPPORT (this is if you want it)
        SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
        slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
        {
            ModdedIds.providerIds.PROVIDER_SLIME
        };
        slimeDefinition.CanLargofy = false;
        slimeDefinition.FavoriteToys = new Identifiable.Id[1];
        slimeDefinition.Name = "Provider Slime";
        slimeDefinition.IdentifiableId = ModdedIds.providerIds.PROVIDER_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
        slimeObject.name = "slimeProvider";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.providerIds.PROVIDER_SLIME;
        // .AddComponent for new components, below with UnityEngine shows how to destroy components, and get them is pretty obvious.
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        Color ProviderColor = new Color32(248, 222, 126, 255);
        Color LightProviderColor = new Color32(250, 218, 94, 255);
        Color WhiteColor = new Color32(255, 255, 255, 255);
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(providerDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                // SET MATERIALS HERE!! Btw above is if you want color vars-
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.HONEY_PHOSPHOR_LARGO).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", ProviderColor);
                material.SetColor("_MiddleColor", LightProviderColor);
                material.SetColor("_BottomColor", WhiteColor);
                material.SetColor("_SpecColor", WhiteColor);
                material.SetColor("_GlowTop", ProviderColor);
                material.SetColor("_GlowMid", LightProviderColor);
                material.SetColor("_GlowBottom", WhiteColor);
                material.SetFloat("_Shininess", 1f); // idk what these are for tbh, but you can use it if you want
                material.SetFloat("_Gloss", 1f); // same thing here lol
                slimeAppearanceStructure.DefaultMaterials[0] = material;
            }
        }
        SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
        for (int k = 0; k < expressionFaces.Length; k++)
        {
            SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
            if ((bool)slimeExpressionFace.Mouth)
            {
                slimeExpressionFace.Mouth.SetColor("_MouthBot", WhiteColor);
                slimeExpressionFace.Mouth.SetColor("_MouthMid", WhiteColor);
                slimeExpressionFace.Mouth.SetColor("_MouthTop", WhiteColor);
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /* this is the default one in frosty's wiki I think
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", WhiteColor);
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", WhiteColor);
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", WhiteColor);
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Provider.provider_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = ProviderColor,
            Middle = LightProviderColor,
            Bottom = WhiteColor
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.providerIds.PROVIDER_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Provider.provider_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}