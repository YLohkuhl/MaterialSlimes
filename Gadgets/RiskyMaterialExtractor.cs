using System;
using System.IO;
using System.Reflection;
using MonomiPark.SlimeRancher.DataModel;
using SRML.SR;
using SRML.SR.SaveSystem;
using SRML.SR.Translation;
using SRML.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

public class RiskyMaterialExtractor : GadgetModel, ISerializableModel
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

    private int Version
    {
        get
        {
            return 0;
        }
    }

    public RiskyMaterialExtractor(Gadget.Id ident, string siteId, Transform transform) : base(ident, siteId, transform)
    {
    }

    public void LoadData(BinaryReader reader)
    {
        int num = reader.ReadInt32();
        this.testProperty = reader.ReadSingle();
    }

    public void WriteData(BinaryWriter writer)
    {
        writer.Write(this.Version);
        writer.Write(this.testProperty);
    }

    public float testProperty;


    static public void LoadRiskyMaterialExtractor()
    {
        // OBJECTS, PRODUCES, ETC
        GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_DRILL_ADVANCED).prefab);

        GameObject fx = gadgetObject.GetComponent<Extractor>().produces[0].spawnFX;

        var itemProduced = new Extractor.ProduceEntry[5]
        {
            new Extractor.ProduceEntry() {
                id = itemIds.MATERIAL_SQUEEZE_CRAFT,
                weight = 6f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = otherIds.DANGEROUS_PLORT,
                weight = 3.8f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = itemIds.FERTILIZER_CRAFT,
                weight = 3f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = itemIds.ANONYMOUS_COMPOUND_CRAFT,
                weight = 0.5f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = itemIds.SPIRITUAL_MATERIAL_CRAFT,
                weight = 0.5f,
                restrictZone = false,
                spawnFX = fx
            },
        };

        // GADGET COMPONENTS
        gadgetObject.GetComponent<Gadget>().id = gadgetIds.RISKY_MATERIAL_EXTRACTOR;
        gadgetObject.GetComponent<Extractor>().produces = itemProduced;
        gadgetObject.GetComponent<Extractor>().cycles = 6;
        gadgetObject.GetComponent<Extractor>().produceMin = 6;
        gadgetObject.GetComponent<Extractor>().produceMax = 9;
        gadgetObject.GetComponent<Extractor>().hoursPerCycle = 18;
        // gadgetObject.GetComponent<Extractor>().infiniteCycles = true;
        // UnityEngine.Object.Destroy(gadgetObject.GetComponent<Extractor>());

        // REGISTER THE GADGET
        Sprite GadgetIcon = CreateSprite(LoadImage("Assets.Gadgets.RiskyMaterialExtractor.risky_materialExtract_icon.png"));
        LookupRegistry.RegisterGadget(new GadgetDefinition
        {
            prefab = gadgetObject, //Just use another, already, existing GameObject of a gadget. Tutorials about custom models ASAP.
            id = gadgetIds.RISKY_MATERIAL_EXTRACTOR,
            pediaLink = PediaDirector.Id.EXTRACTORS,
            blueprintCost = 2500,
            buyCountLimit = 3,
            icon = GadgetIcon,
            craftCosts = new GadgetDefinition.CraftCost[]
            {
                new GadgetDefinition.CraftCost
                {
                    amount = 35,
                    id = ModdedIds.plasticIds.PLASTIC_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 35,
                    id = ModdedIds.glueIds.GLUE_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 25,
                    id = ModdedIds.metalIds.METAL_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 15,
                    id = Identifiable.Id.PRIMORDY_OIL_CRAFT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 5,
                    id = itemIds.MATERIAL_SQUEEZE_CRAFT
                }
            },
        });

        // ADD CLASS, TRANSLATION, BLUEPRINT, OTHER STUFF THAT ENDS IT OFF
        Gadget.EXTRACTOR_CLASS.Add(gadgetIds.RISKY_MATERIAL_EXTRACTOR);

        new GadgetTranslation(gadgetIds.RISKY_MATERIAL_EXTRACTOR).SetNameTranslation("Risky Material Extractor").SetDescriptionTranslation("An extractor that is a little more risky then others but produces more, could produce dangerous plorts. Last 6 cycles.");

        // SaveRegistry.RegisterSerializableGadgetModel<Squeezer>(0);
        // DataModelRegistry.RegisterCustomGadgetModel(gadgetIds.SQUEEZER, typeof(Squeezer));
        GadgetRegistry.RegisterBlueprintLock(gadgetIds.RISKY_MATERIAL_EXTRACTOR, x => x.CreateBasicLock(gadgetIds.RISKY_MATERIAL_EXTRACTOR, Gadget.Id.NONE, ProgressDirector.ProgressType.UNLOCK_LAB, 3f)); //Replace 'YOUR_ZONE' with the Zone you want.
    }
}