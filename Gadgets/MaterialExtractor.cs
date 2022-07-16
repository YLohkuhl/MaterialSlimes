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

public class MaterialExtractor : GadgetModel, ISerializableModel
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

    public MaterialExtractor(Gadget.Id ident, string siteId, Transform transform) : base(ident, siteId, transform)
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


    static public void LoadMaterialExtractor()
    {
        // OBJECTS, PRODUCES, ETC
        GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_PUMP_ADVANCED).prefab);

        GameObject fx = gadgetObject.GetComponent<Extractor>().produces[0].spawnFX;

        var itemProduced = new Extractor.ProduceEntry[2]
        {
            new Extractor.ProduceEntry() {
                id = itemIds.MATERIAL_SQUEEZE,
                weight = 6f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = itemIds.FERTILIZER,
                weight = 3f,
                restrictZone = false,
                spawnFX = fx
            }
        };

        // GADGET COMPONENTS
        gadgetObject.GetComponent<Gadget>().id = gadgetIds.MATERIAL_EXTRACTOR;
        gadgetObject.GetComponent<Extractor>().produces = itemProduced;
        // gadgetObject.GetComponent<Extractor>().cycles = 3;
        gadgetObject.GetComponent<Extractor>().produceMin = 3;
        gadgetObject.GetComponent<Extractor>().produceMax = 6;
        gadgetObject.GetComponent<Extractor>().hoursPerCycle = 15;
        gadgetObject.GetComponent<Extractor>().infiniteCycles = true;
        // UnityEngine.Object.Destroy(gadgetObject.GetComponent<Extractor>());

        // REGISTER THE GADGET
        Sprite GadgetIcon = CreateSprite(LoadImage("Assets.Gadgets.MaterialExtractor.materialExtract_icon.png"));
        LookupRegistry.RegisterGadget(new GadgetDefinition
        {
            prefab = gadgetObject, //Just use another, already, existing GameObject of a gadget. Tutorials about custom models ASAP.
            id = gadgetIds.MATERIAL_EXTRACTOR,
            pediaLink = PediaDirector.Id.EXTRACTORS,
            blueprintCost = 1250,
            buyCountLimit = 10,
            icon = GadgetIcon,
            craftCosts = new GadgetDefinition.CraftCost[]
            {
                new GadgetDefinition.CraftCost
                {
                    amount = 20,
                    id = ModdedIds.plasticIds.PLASTIC_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 20,
                    id = ModdedIds.glueIds.GLUE_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 15,
                    id = ModdedIds.metalIds.METAL_PLORT
                }
            },
        });

        // ADD CLASS, TRANSLATION, BLUEPRINT, OTHER STUFF THAT ENDS IT OFF
        Gadget.EXTRACTOR_CLASS.Add(gadgetIds.MATERIAL_EXTRACTOR);

        new GadgetTranslation(gadgetIds.MATERIAL_EXTRACTOR).SetNameTranslation("Material Extractor").SetDescriptionTranslation("An extractor that produces material resources, very useful. Last infinite cycles.");

        // SaveRegistry.RegisterSerializableGadgetModel<Squeezer>(0);
        // DataModelRegistry.RegisterCustomGadgetModel(gadgetIds.SQUEEZER, typeof(Squeezer));
        GadgetRegistry.RegisterBlueprintLock(gadgetIds.MATERIAL_EXTRACTOR, x => x.CreateBasicLock(gadgetIds.MATERIAL_EXTRACTOR, Gadget.Id.NONE, ProgressDirector.ProgressType.UNLOCK_LAB, 1f)); //Replace 'YOUR_ZONE' with the Zone you want.
    }
}