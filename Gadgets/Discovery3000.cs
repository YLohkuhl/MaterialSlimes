using System;
using System.IO;
using System.Reflection;
using ModdedIds;
using MonomiPark.SlimeRancher.DataModel;
using SRML.SR;
using SRML.SR.SaveSystem;
using SRML.SR.Translation;
using SRML.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

public class Discovery3000 : GadgetModel, ISerializableModel
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

    public Discovery3000(Gadget.Id ident, string siteId, Transform transform) : base(ident, siteId, transform)
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


    static public void LoadDiscovery3000()
    {
        // OBJECTS, PRODUCES, ETC
        GameObject gadgetObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.EXTRACTOR_PUMP_ABYSSAL).prefab);

        GameObject fx = gadgetObject.GetComponent<Extractor>().produces[0].spawnFX;

        var itemProduced = new Extractor.ProduceEntry[13]
        {
            new Extractor.ProduceEntry() {
                id = woodIds.WOOD_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = concreteIds.CONCRETE_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = copperIds.COPPER_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = cottonIds.COTTON_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = darkIds.DARK_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = glassIds.GLASS_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = iceIds.ICE_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = glueIds.GLUE_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = soilIds.SOIL_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = lightIds.LIGHT_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = metalIds.METAL_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = plasticIds.PLASTIC_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
            new Extractor.ProduceEntry() {
                id = providerIds.PROVIDER_SLIME,
                weight = 1f,
                restrictZone = false,
                spawnFX = fx
            },
        };

        // GADGET COMPONENTS
        gadgetObject.GetComponent<Gadget>().id = gadgetIds.DISCOVERY_3000;
        gadgetObject.GetComponent<Extractor>().produces = itemProduced;
        // gadgetObject.GetComponent<Extractor>().cycles = 3;
        gadgetObject.GetComponent<Extractor>().produceMin = 1;
        gadgetObject.GetComponent<Extractor>().produceMax = 2;
        gadgetObject.GetComponent<Extractor>().hoursPerCycle = 22;
        gadgetObject.GetComponent<Extractor>().infiniteCycles = true;
        // UnityEngine.Object.Destroy(gadgetObject.GetComponent<Extractor>());

        // REGISTER THE GADGET
        Sprite GadgetIcon = CreateSprite(LoadImage("Assets.Gadgets.Discovery3000.discovery3000_icon.png"));
        LookupRegistry.RegisterGadget(new GadgetDefinition
        {
            prefab = gadgetObject, //Just use another, already, existing GameObject of a gadget. Tutorials about custom models ASAP.
            id = gadgetIds.DISCOVERY_3000,
            pediaLink = PediaDirector.Id.EXTRACTORS,
            blueprintCost = 4250,
            buyCountLimit = 1,
            icon = GadgetIcon,
            craftCosts = new GadgetDefinition.CraftCost[]
            {
                new GadgetDefinition.CraftCost
                {
                    amount = 80,
                    id = itemIds.MATERIAL_SQUEEZE_CRAFT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 50,
                    id = ModdedIds.plasticIds.PLASTIC_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 50,
                    id = ModdedIds.glueIds.GLUE_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 35,
                    id = ModdedIds.metalIds.METAL_PLORT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 25,
                    id = Identifiable.Id.PRIMORDY_OIL_CRAFT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 15,
                    id = itemIds.SILVER_SHARD_CRAFT
                },
                new GadgetDefinition.CraftCost
                {
                    amount = 5,
                    id = itemIds.ANONYMOUS_COMPOUND_CRAFT
                },
            },
        });

        // ADD CLASS, TRANSLATION, BLUEPRINT, OTHER STUFF THAT ENDS IT OFF
        Gadget.EXTRACTOR_CLASS.Add(gadgetIds.DISCOVERY_3000);

        new GadgetTranslation(gadgetIds.DISCOVERY_3000).SetNameTranslation("Discovery 3000").SetDescriptionTranslation("A gadget that takes fragments of Material Slimes and forms them into one, sorta like a Self Discovery Slime. Last infinite cycles.");

        // SaveRegistry.RegisterSerializableGadgetModel<Squeezer>(0);
        // DataModelRegistry.RegisterCustomGadgetModel(gadgetIds.SQUEEZER, typeof(Squeezer));
        GadgetRegistry.RegisterBlueprintLock(gadgetIds.DISCOVERY_3000, x => x.CreateBasicLock(gadgetIds.DISCOVERY_3000, Gadget.Id.NONE, ProgressDirector.ProgressType.UNLOCK_LAB, 12f)); //Replace 'YOUR_ZONE' with the Zone you want.
    }
}