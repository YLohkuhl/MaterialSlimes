using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class NewbuckSlime // Slime name here
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
        SlimeDefinition newbuckDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME); // make sure to make slimeNameDefiniton your slime name btw-
        SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(newbuckDefinition);
        slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
        slimeDefinition.Diet.Produces = new Identifiable.Id[1]
        {
            ModdedIds.newbuckIds.NEWBUCK_PLORT
        };
        slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
        {
            SlimeEat.FoodGroup.NONTARRGOLD_SLIMES
        };
        foreach (Identifiable.Id slimeIds in Identifiable.SLIME_CLASS)
        {
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[] // additional foods
            {
                slimeIds,
                Identifiable.Id.GOLD_SLIME,
                Identifiable.Id.LUCKY_SLIME,
                Identifiable.Id.TARR_SLIME,
            };
        }
        slimeDefinition.Diet.Favorites = new Identifiable.Id[2] // favorites
        {
            Identifiable.Id.GOLD_SLIME,
            Identifiable.Id.LUCKY_SLIME
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
        slimeDefinition.Name = "Newbuck Slime";
        slimeDefinition.IdentifiableId = ModdedIds.newbuckIds.NEWBUCK_SLIME;
        // OBJECT
        GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
        slimeObject.name = "slimeNewbuck";
        slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
        slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
        slimeObject.GetComponent<Identifiable>().id = ModdedIds.newbuckIds.NEWBUCK_SLIME;
        slimeObject.AddComponent<MaterialDecay>();
        UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
        // APPEARANCE
        Color NewbuckColor = new Color32(244, 182, 73, 255);
        Color DarkerNewbuckColor = new Color32(158, 63, 20, 255);
        SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(newbuckDefinition.AppearancesDefault[0]);
        slimeDefinition.AppearancesDefault[0] = slimeAppearance;
        SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
        foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
        {
            Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
            if (defaultMaterials != null && defaultMaterials.Length != 0)
            {
                // SET MATERIALS HERE!! Btw above is if you want color vars-
                Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.QUANTUM_TABBY_LARGO).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                material.SetColor("_TopColor", NewbuckColor);
                material.SetColor("_MiddleColor", NewbuckColor);
                material.SetColor("_BottomColor", DarkerNewbuckColor);
                material.SetColor("_SpecColor", DarkerNewbuckColor);
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
                slimeExpressionFace.Mouth.SetColor("_MouthBot", DarkerNewbuckColor);
                slimeExpressionFace.Mouth.SetColor("_MouthMid", DarkerNewbuckColor);
                slimeExpressionFace.Mouth.SetColor("_MouthTop", DarkerNewbuckColor);
            }
            if ((bool)slimeExpressionFace.Eyes)
            {   /* this is the default one in frosty's wiki I think
                slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                */
                slimeExpressionFace.Eyes.SetColor("_EyeRed", DarkerNewbuckColor);
                slimeExpressionFace.Eyes.SetColor("_EyeGreen", DarkerNewbuckColor);
                slimeExpressionFace.Eyes.SetColor("_EyeBlue", DarkerNewbuckColor);
            }
        }
        slimeAppearance.Icon = CreateSprite(LoadImage("Assets.Slimes.Newbuck.newbuck_slime.png"));
        slimeAppearance.Face.OnEnable();
        slimeAppearance.ColorPalette = new SlimeAppearance.Palette
        {
            Top = NewbuckColor,
            Middle = DarkerNewbuckColor,
            Bottom = NewbuckColor
        };
        PediaRegistry.RegisterIdEntry(ModdedIds.newbuckIds.NEWBUCK_ENTRY, CreateSprite(LoadImage("Assets.Slimes.Newbuck.newbuck_slime.png")));
        slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
        return (slimeDefinition, slimeObject);
    }
}