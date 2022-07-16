using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class LoadPoint
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

    static public void LoadSlimes()
    {
        //-- LOAD --\\

        //./---------- FRAGMENT SLIMES ----------\.\\


        // START LOAD FRAGMENT SLIME
        (SlimeDefinition, GameObject) FragmentTuple = Fragments.CreateSlime(otherIds.FRAGMENT_SLIME, "Fragment Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Fragment_Fragment_Definition = FragmentTuple.Item1;
        GameObject Fragment_Fragment_Object = FragmentTuple.Item2;

        Fragment_Fragment_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Fragment_Fragment_Object);
        TranslationPatcher.AddPediaTranslation("t." + otherIds.FRAGMENT_SLIME.ToString().ToLower(), "Fragment Slime");

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Fragment_Fragment_Object);
        SlimeRegistry.RegisterSlimeDefinition(Fragment_Fragment_Definition);
        // END LOAD FRAGMENT SLIME

        // START LOAD DANGEROUS PLORT
        GameObject DangerousPlortTuple = OtherPlorts.DangerousPlort();

        GameObject DangerousPlort_DangerousPlort_Object = DangerousPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, DangerousPlort_DangerousPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite DangerousPlortIcon = CreateSprite(LoadImage("Assets.Other.Fragment.dangerous_plort.png"));
        Color DangerousColor = Color.black; // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(otherIds.DANGEROUS_PLORT, DangerousColor, DangerousPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, otherIds.DANGEROUS_PLORT);
        // END LOAD DANGEROUS PLORT


        //./---------- MATERIAL SLIMES ----------\.\\

        //---------- GLUE ---------- \\


        // START LOAD GLUE SLIME
        (SlimeDefinition, GameObject) GlueTuple = GlueSlime.CreateSlime(ModdedIds.glueIds.GLUE_SLIME, "Glue Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Glue_Glue_Definition = GlueTuple.Item1;
        GameObject Glue_Glue_Object = GlueTuple.Item2;

        Glue_Glue_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Glue_Glue_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.glueIds.GLUE_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.Slimes.Glue.glue_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.glueIds.GLUE_SLIME.ToString().ToLower(), "Glue Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.glueIds.GLUE_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.Slimes.Glue.glue_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Glue_Glue_Object);
        SlimeRegistry.RegisterSlimeDefinition(Glue_Glue_Definition);
        // END LOAD GLUE SLIME


        //---------- PLASTIC ---------- \\


        // START LOAD PLASTIC SLIME
        (SlimeDefinition, GameObject) PlasticTuple = PlasticSlime.CreateSlime(ModdedIds.plasticIds.PLASTIC_SLIME, "Plastic Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Plastic_Plastic_Definition = PlasticTuple.Item1;
        GameObject Plastic_Plastic_Object = PlasticTuple.Item2;

        Plastic_Plastic_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Plastic_Plastic_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.plasticIds.PLASTIC_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.Slimes.Plastic.plastic_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.plasticIds.PLASTIC_SLIME.ToString().ToLower(), "Plastic Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.plasticIds.PLASTIC_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.Slimes.Plastic.plastic_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Plastic_Plastic_Object);
        SlimeRegistry.RegisterSlimeDefinition(Plastic_Plastic_Definition);
        // END LOAD PLASTIC SLIME


        //---------- GLASS ---------- \\


        // START LOAD GLASS SLIME
        (SlimeDefinition, GameObject) GlassTuple = GlassSlime.CreateSlime(ModdedIds.glassIds.GLASS_SLIME, "Glass Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Glass_Glass_Definition = GlassTuple.Item1;
        GameObject Glass_Glass_Object = GlassTuple.Item2;

        Glass_Glass_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Glass_Glass_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.glassIds.GLASS_SLIME, new Color32(246, 254, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.Slimes.Glass.glass_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.glassIds.GLASS_SLIME.ToString().ToLower(), "Glass Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.glassIds.GLASS_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.Slimes.Glass.glass_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Glass_Glass_Object);
        SlimeRegistry.RegisterSlimeDefinition(Glass_Glass_Definition);
        // END LOAD GLASS SLIME


        //---------- METAL ---------- \\


        // START LOAD METAL SLIME
        (SlimeDefinition, GameObject) MetalTuple = MetalSlime.CreateSlime(ModdedIds.metalIds.METAL_SLIME, "Metal Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Metal_Metal_Definition = MetalTuple.Item1;
        GameObject Metal_Metal_Object = MetalTuple.Item2;

        Metal_Metal_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Metal_Metal_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.metalIds.METAL_SLIME, Color.grey, CreateSprite(LoadImage("Assets.Slimes.Metal.metal_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.metalIds.METAL_SLIME.ToString().ToLower(), "Metal Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.metalIds.METAL_SLIME, Color.grey, CreateSprite(LoadImage("Assets.Slimes.Metal.metal_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Metal_Metal_Object);
        SlimeRegistry.RegisterSlimeDefinition(Metal_Metal_Definition);
        // END LOAD METAL SLIME


        //---------- WOOD ---------- \\


        // START LOAD WOOD SLIME
        (SlimeDefinition, GameObject) WoodTuple = WoodSlime.CreateSlime(ModdedIds.woodIds.WOOD_SLIME, "Wood Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Wood_Wood_Definition = WoodTuple.Item1;
        GameObject Wood_Wood_Object = WoodTuple.Item2;

        Wood_Wood_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Wood_Wood_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.woodIds.WOOD_SLIME, new Color32(150, 111, 51, 255), CreateSprite(LoadImage("Assets.Slimes.Wood.wood_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.woodIds.WOOD_SLIME.ToString().ToLower(), "Wood Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.woodIds.WOOD_SLIME, new Color32(150, 111, 51, 255), CreateSprite(LoadImage("Assets.Slimes.Wood.wood_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Wood_Wood_Object);
        SlimeRegistry.RegisterSlimeDefinition(Wood_Wood_Definition);
        // END LOAD WOOD SLIME


        //---------- CONCRETE ---------- \\


        // START LOAD CONCRETE SLIME
        (SlimeDefinition, GameObject) ConcreteTuple = ConcreteSlime.CreateSlime(ModdedIds.concreteIds.CONCRETE_SLIME, "Concrete Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Concrete_Concrete_Definition = ConcreteTuple.Item1;
        GameObject Concrete_Concrete_Object = ConcreteTuple.Item2;

        Concrete_Concrete_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Concrete_Concrete_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.concreteIds.CONCRETE_SLIME, Color.grey, CreateSprite(LoadImage("Assets.Slimes.Concrete.concrete_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.concreteIds.CONCRETE_SLIME.ToString().ToLower(), "Concrete Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.concreteIds.CONCRETE_SLIME, Color.grey, CreateSprite(LoadImage("Assets.Slimes.Concrete.concrete_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Concrete_Concrete_Object);
        SlimeRegistry.RegisterSlimeDefinition(Concrete_Concrete_Definition);
        // END LOAD CONCRETE SLIME


        //---------- COTTON ---------- \\


        // START LOAD COTTON SLIME
        (SlimeDefinition, GameObject) CottonTuple = CottonSlime.CreateSlime(ModdedIds.cottonIds.COTTON_SLIME, "Cotton Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Cotton_Cotton_Definition = CottonTuple.Item1;
        GameObject Cotton_Cotton_Object = CottonTuple.Item2;

        Cotton_Cotton_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Cotton_Cotton_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.cottonIds.COTTON_SLIME, Color.white, CreateSprite(LoadImage("Assets.Slimes.Cotton.cotton_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.cottonIds.COTTON_SLIME.ToString().ToLower(), "Cotton Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.cottonIds.COTTON_SLIME, Color.white, CreateSprite(LoadImage("Assets.Slimes.Cotton.cotton_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Cotton_Cotton_Object);
        SlimeRegistry.RegisterSlimeDefinition(Cotton_Cotton_Definition);
        // END LOAD COTTON SLIME


        //---------- COPPER ---------- \\


        // START LOAD COPPER SLIME
        (SlimeDefinition, GameObject) CopperTuple = CopperSlime.CreateSlime(ModdedIds.copperIds.COPPER_SLIME, "Copper Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Copper_Copper_Definiton = CopperTuple.Item1;
        GameObject Copper_Copper_Object = CopperTuple.Item2;

        Copper_Copper_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Copper_Copper_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.copperIds.COPPER_SLIME, new Color32(140, 79, 55, 255), CreateSprite(LoadImage("Assets.Slimes.Copper.copper_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.copperIds.COPPER_SLIME.ToString().ToLower(), "Copper Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.copperIds.COPPER_SLIME, new Color32(140, 79, 55, 255), CreateSprite(LoadImage("Assets.Slimes.Copper.copper_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Copper_Copper_Object);
        SlimeRegistry.RegisterSlimeDefinition(Copper_Copper_Definiton);
        // END LOAD COPPER SLIME


        //---------- ICE ---------- \\


        // START LOAD ICE SLIME
        (SlimeDefinition, GameObject) IceTuple = IceSlime.CreateSlime(ModdedIds.iceIds.ICE_SLIME, "Ice Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Ice_Ice_Definition = IceTuple.Item1;
        GameObject Ice_Ice_Object = IceTuple.Item2;

        Ice_Ice_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Ice_Ice_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.iceIds.ICE_SLIME, new Color(165, 242, 243, 255), CreateSprite(LoadImage("Assets.Slimes.Ice.ice_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.iceIds.ICE_SLIME.ToString().ToLower(), "Ice Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.iceIds.ICE_SLIME, new Color(165, 242, 243, 255), CreateSprite(LoadImage("Assets.Slimes.Ice.ice_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Ice_Ice_Object);
        SlimeRegistry.RegisterSlimeDefinition(Ice_Ice_Definition);
        // END LOAD ICE SLIME


        //---------- SOIL ---------- \\


        // START LOAD SOIL SLIME
        (SlimeDefinition, GameObject) SoilTuple = SoilSlime.CreateSlime(ModdedIds.soilIds.SOIL_SLIME, "Soil Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Soil_Soil_Definition = SoilTuple.Item1;
        GameObject Soil_Soil_Object = SoilTuple.Item2;

        Soil_Soil_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Color SoilColor = new Color32(165, 42, 42, 255); // brown

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Soil_Soil_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.soilIds.SOIL_SLIME, SoilColor, CreateSprite(LoadImage("Assets.Slimes.Soil.soil_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.soilIds.SOIL_SLIME.ToString().ToLower(), "Soil Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.soilIds.SOIL_SLIME, SoilColor, CreateSprite(LoadImage("Assets.Slimes.Soil.soil_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Soil_Soil_Object);
        SlimeRegistry.RegisterSlimeDefinition(Soil_Soil_Definition);
        // END LOAD SOIL SLIME


        //---------- GRASS ---------- \\


        // START LOAD GRASS SLIME
        (SlimeDefinition, GameObject) GrassTuple = GrassSlime.CreateSlime(ModdedIds.grassIds.GRASS_SLIME, "Grass Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Grass_Grass_Definition = GrassTuple.Item1;
        GameObject Grass_Grass_Object = GrassTuple.Item2;

        Grass_Grass_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Color GrassColor = new Color32(34, 139, 34, 255); // green

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Grass_Grass_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.grassIds.GRASS_SLIME, GrassColor, CreateSprite(LoadImage("Assets.Slimes.Grass.grass_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.grassIds.GRASS_SLIME.ToString().ToLower(), "Grass Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.grassIds.GRASS_SLIME, GrassColor, CreateSprite(LoadImage("Assets.Slimes.Soil.soil_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Grass_Grass_Object);
        SlimeRegistry.RegisterSlimeDefinition(Grass_Grass_Definition);
        // END LOAD GRASS SLIME


        //./---------- PRETTY RARE MATERIAL SLIMES ----------\.\\

        //---------- SELF DISCOVERY ---------- \\


        // START LOAD SELF DISCOVERY SLIME
        (SlimeDefinition, GameObject) DiscoveryTuple = SelfDiscoverySlime.CreateSlime(ModdedIds.discoveryIds.DISCOVERY_SLIME, "Self Discovery Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Discovery_Discovery_Definition = DiscoveryTuple.Item1;
        GameObject Discovery_Discovery_Object = DiscoveryTuple.Item2;

        Discovery_Discovery_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Discovery_Discovery_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.discoveryIds.DISCOVERY_SLIME, new Color32(255, 191, 94, 255), CreateSprite(LoadImage("Assets.Slimes.Discovery.selfdiscovery_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.discoveryIds.DISCOVERY_SLIME.ToString().ToLower(), "Self Discovery Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.discoveryIds.DISCOVERY_SLIME, new Color32(255, 191, 94, 255), CreateSprite(LoadImage("Assets.Slimes.Discovery.selfdiscovery_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Discovery_Discovery_Object);
        SlimeRegistry.RegisterSlimeDefinition(Discovery_Discovery_Definition);
        // END LOAD SELF DISCOVERY SLIME


        //---------- LIGHT ---------- \\


        // START LOAD LIGHT SLIME
        (SlimeDefinition, GameObject) LightTuple = LightSlime.CreateSlime(ModdedIds.lightIds.LIGHT_SLIME, "Light Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Light_Light_Definition = LightTuple.Item1;
        GameObject Light_Light_Object = LightTuple.Item2;

        Light_Light_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Light_Light_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.lightIds.LIGHT_SLIME, Color.yellow, CreateSprite(LoadImage("Assets.Slimes.Light.light_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.lightIds.LIGHT_SLIME.ToString().ToLower(), "Light Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.lightIds.LIGHT_SLIME, Color.yellow, CreateSprite(LoadImage("Assets.Slimes.Light.light_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Light_Light_Object);
        SlimeRegistry.RegisterSlimeDefinition(Light_Light_Definition);
        // END LOAD LIGHT SLIME


        //---------- DARK ---------- \\


        // START LOAD DARK SLIME
        (SlimeDefinition, GameObject) DarkTuple = DarkSlime.CreateSlime(ModdedIds.darkIds.DARK_SLIME, "Dark Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Dark_Dark_Definition = DarkTuple.Item1;
        GameObject Dark_Dark_Object = DarkTuple.Item2;

        Dark_Dark_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Dark_Dark_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.darkIds.DARK_SLIME, Color.black, CreateSprite(LoadImage("Assets.Slimes.Dark.dark_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.darkIds.DARK_SLIME.ToString().ToLower(), "Dark Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.darkIds.DARK_SLIME, Color.black, CreateSprite(LoadImage("Assets.Slimes.Dark.dark_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Dark_Dark_Object);
        SlimeRegistry.RegisterSlimeDefinition(Dark_Dark_Definition);
        // END LOAD DARK SLIME


        //---------- NEWBUCK ---------- \\


        // START LOAD NEWBUCK SLIME
        (SlimeDefinition, GameObject) NewbuckTuple = NewbuckSlime.CreateSlime(ModdedIds.newbuckIds.NEWBUCK_SLIME, "Newbuck Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Newbuck_Newbuck_Definition = NewbuckTuple.Item1;
        GameObject Newbuck_Newbuck_Object = NewbuckTuple.Item2;

        Newbuck_Newbuck_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Newbuck_Newbuck_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.newbuckIds.NEWBUCK_SLIME, new Color32(244, 182, 73, 255), CreateSprite(LoadImage("Assets.Slimes.Newbuck.newbuck_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.newbuckIds.NEWBUCK_SLIME.ToString().ToLower(), "Newbuck Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.newbuckIds.NEWBUCK_SLIME, new Color32(244, 182, 73, 255), CreateSprite(LoadImage("Assets.Slimes.Newbuck.newbuck_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Newbuck_Newbuck_Object);
        SlimeRegistry.RegisterSlimeDefinition(Newbuck_Newbuck_Definition);
        // END LOAD NEWBUCK SLIME


        //---------- PROVIDER ---------- \\


        // START LOAD PROVIDER SLIME
        (SlimeDefinition, GameObject) ProviderTuple = ProviderSlime.CreateSlime(ModdedIds.providerIds.PROVIDER_SLIME, "Provider Slime"); //Insert your own Id in the first argumeter

        //Getting the SlimeDefinition and GameObject separated
        SlimeDefinition Provider_Provider_Definiton = ProviderTuple.Item1;
        GameObject Provider_Provider_Object = ProviderTuple.Item2;

        Provider_Provider_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

        Color ProviderColor = new Color32(248, 222, 126, 255);

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Provider_Provider_Object);
        LookupRegistry.RegisterVacEntry(ModdedIds.providerIds.PROVIDER_SLIME, ProviderColor, CreateSprite(LoadImage("Assets.Slimes.Provider.provider_slime.png")));
        TranslationPatcher.AddPediaTranslation("t." + ModdedIds.providerIds.PROVIDER_SLIME.ToString().ToLower(), "Provider Slime");
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.providerIds.PROVIDER_SLIME, ProviderColor, CreateSprite(LoadImage("Assets.Slimes.Provider.provider_slime.png"))));

        //And well, registering it!
        LookupRegistry.RegisterIdentifiablePrefab(Provider_Provider_Object);
        SlimeRegistry.RegisterSlimeDefinition(Provider_Provider_Definiton);
        // END LOAD PROVIDER SLIME

        return;
    }

    public static void LoadPlorts()
    {
        //---------- GLUE ---------- \\


        // START LOAD GLUE PLORT
        GameObject GluePlortTuple = GlueSlimePlort.GluePlort();

        GameObject GluePlort_GluePlort_Object = GluePlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, GluePlort_GluePlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite GluePlortIcon = CreateSprite(LoadImage("Assets.Slimes.Glue.glue_slime_plort.png"));
        Color GluePureWhite = new Color32(255, 255, 255, byte.MaxValue); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.glueIds.GLUE_PLORT, GluePureWhite, GluePlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.glueIds.GLUE_PLORT);

        float gluePrice = 23f; //Starting price for plort   
        float glueSaturated = 7f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.glueIds.GLUE_PLORT, gluePrice, glueSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.glueIds.GLUE_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.glueIds.GLUE_PLORT);
        // END LOAD GLUE PLORT


        //---------- PLASTIC ---------- \\


        // START LOAD PLASTIC PLORT
        GameObject PlasticPlortTuple = PlasticSlimePlort.PlasticPlort();

        GameObject PlasticPlort_PlasticPlort_Object = PlasticPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, PlasticPlort_PlasticPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite PlasticPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Plastic.plastic_slime_plort.png"));
        Color PlasticMilkyWhite = new Color32(255, 254, 247, byte.MaxValue); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.plasticIds.PLASTIC_PLORT, PlasticMilkyWhite, PlasticPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.plasticIds.PLASTIC_PLORT);

        float plasticPrice = 43f; //Starting price for plort
        float plasticSaturated = 7f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.plasticIds.PLASTIC_PLORT, plasticPrice, plasticSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.plasticIds.PLASTIC_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.plasticIds.PLASTIC_PLORT);
        // END LOAD PLASTIC PLORT


        //---------- GLASS ---------- \\


        // START LOAD GLASS PLORT
        GameObject GlassPlortTuple = GlassSlimePlort.GlassPlort();

        GameObject GlassPlort_GlassPlort_Object = GlassPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, GlassPlort_GlassPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite GlassPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Glass.glass_slime_plort.png"));
        Color GlassColor = new Color32(246, 254, 255, byte.MaxValue); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.glassIds.GLASS_PLORT, GlassColor, GlassPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.glassIds.GLASS_PLORT);

        float glassPrice = 23f; //Starting price for plort
        float glassSaturated = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.glassIds.GLASS_PLORT, glassPrice, glassSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.glassIds.GLASS_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.glassIds.GLASS_PLORT);
        // END LOAD GLASS PLORT


        //---------- METAL ---------- \\


        // START LOAD METAL PLORT
        GameObject MetalPlortTuple = MetalSlimePlort.MetalPlort();

        GameObject MetalPlort_MetalPlort_Object = MetalPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, MetalPlort_MetalPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite MetalPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Metal.metal_slime_plort.png"));
        Color MetalColor = Color.grey; // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.metalIds.METAL_PLORT, MetalColor, MetalPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.metalIds.METAL_PLORT);

        float metalPrice = 43f; //Starting price for plort
        float metalSaturated = 7f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.metalIds.METAL_PLORT, metalPrice, metalSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.metalIds.METAL_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.metalIds.METAL_PLORT);
        // END LOAD METAL PLORT


        //---------- WOOD ---------- \\


        // START LOAD WOOD PLORT
        GameObject WoodPlortTuple = WoodSlimePlort.WoodPlort();

        GameObject WoodPlort_WoodPlort_Object = WoodPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, WoodPlort_WoodPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite WoodPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Wood.wood_slime_plort.png"));
        Color WoodColor = new Color32(150, 111, 51, 255); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.woodIds.WOOD_PLORT, WoodColor, WoodPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.woodIds.WOOD_PLORT);

        float woodPrice = 12f; //Starting price for plort
        float woodSaturated = 3f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.woodIds.WOOD_PLORT, woodPrice, woodSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.woodIds.WOOD_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.woodIds.WOOD_PLORT);
        // END LOAD WOOD PLORT


        //---------- CONCRETE ---------- \\


        // START LOAD CONCRETE PLORT
        GameObject ConcretePlortTuple = ConcreteSlimePlort.ConcretePlort();

        GameObject ConcretePlort_ConcretePlort_Object = ConcretePlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, ConcretePlort_ConcretePlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite ConcretePlortIcon = CreateSprite(LoadImage("Assets.Slimes.Concrete.concrete_slime_plort.png"));
        Color ConcreteColor = Color.grey; // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.concreteIds.CONCRETE_PLORT, ConcreteColor, ConcretePlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.concreteIds.CONCRETE_PLORT);

        float concretePrice = 40f; //Starting price for plort
        float concreteSaturated = 3f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.concreteIds.CONCRETE_PLORT, concretePrice, concreteSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.concreteIds.CONCRETE_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.concreteIds.CONCRETE_PLORT);
        // END LOAD CONCRETE PLORT


        //---------- COTTON ---------- \\


        // START LOAD COTTON PLORT
        GameObject CottonPlortTuple = CottonSlimePlort.CottonPlort();

        GameObject CottonPlort_CottonPlort_Object = CottonPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, CottonPlort_CottonPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite CottonPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Cotton.cotton_slime_plort.png"));
        Color CottonColor = Color.white; // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.cottonIds.COTTON_PLORT, CottonColor, CottonPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.cottonIds.COTTON_PLORT);

        float cottonPrice = 26f; //Starting price for plort
        float cottonSaturated = 2f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.cottonIds.COTTON_PLORT, cottonPrice, cottonSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.cottonIds.COTTON_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.cottonIds.COTTON_PLORT);
        // END LOAD COTTON PLORT


        //---------- COPPER ---------- \\


        // START LOAD COPPER PLORT
        GameObject CopperPlortTuple = CopperSlimePlort.CopperPlort();

        GameObject CopperPlort_CopperPlort_Object = CopperPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, CopperPlort_CopperPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite CopperPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Copper.copper_slime_plort.png"));
        Color CopperColor = new Color32(140, 79, 55, 255); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.copperIds.COPPER_PLORT, CopperColor, CopperPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.copperIds.COPPER_PLORT);

        float copperPrice = 48f; //Starting price for plort
        float copperSaturated = 3f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.copperIds.COPPER_PLORT, copperPrice, copperSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.copperIds.COPPER_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.copperIds.COPPER_PLORT);
        // END LOAD COPPER PLORT


        //---------- ICE ---------- \\


        // START LOAD ICE PLORT
        GameObject IcePlortTuple = IceSlimePlort.IcePlort();

        GameObject IcePlort_IcePlort_Object = IcePlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, IcePlort_IcePlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite IcePlortIcon = CreateSprite(LoadImage("Assets.Slimes.Ice.ice_slime_plort.png"));
        Color IceColor = Color.cyan; // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.iceIds.ICE_PLORT, IceColor, IcePlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.iceIds.ICE_PLORT);

        float icePrice = 50f; //Starting price for plort
        float iceSaturated = 1f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.iceIds.ICE_PLORT, icePrice, iceSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.iceIds.ICE_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.iceIds.ICE_PLORT);
        // END LOAD ICE PLORT


        //---------- SOIL ---------- \\


        // START LOAD SOIL PLORT
        GameObject SoilPlortTuple = SoilSlimePlort.SoilPlort();

        GameObject SoilPlort_SoilPlort_Object = SoilPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SoilPlort_SoilPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite SoilPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Soil.soil_slime_plort.png"));
        Color SoilColor = new Color32(124, 94, 66, 255); // brown
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.soilIds.SOIL_PLORT, SoilColor, SoilPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.soilIds.SOIL_PLORT);

        float soilPrice = 20f; //Starting price for plort
        float soilSaturated = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.soilIds.SOIL_PLORT, soilPrice, soilSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.soilIds.SOIL_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.soilIds.SOIL_PLORT);
        // END LOAD SOIL PLORT

        // START LOAD ACTUAL ROCK PLORT
        GameObject ActualRockPlortTuple = SoilSlimePlort.ActualRockPlort();

        GameObject ActualRockPlort_ActualRockPlort_Object = ActualRockPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, ActualRockPlort_ActualRockPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite ActualPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Soil.soil_slime_rock_plort.png"));
        Color ActualRockColor = new Color32(219, 226, 233, 255);
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.soilIds.ACTUAL_ROCK_PLORT, ActualRockColor, ActualPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.soilIds.ACTUAL_ROCK_PLORT);

        float actualRockPrice = 35f; //Starting price for plort
        float actualSoilSaturated = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.soilIds.ACTUAL_ROCK_PLORT, actualRockPrice, actualSoilSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.soilIds.ACTUAL_ROCK_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.soilIds.ACTUAL_ROCK_PLORT);
        // END LOAD ACTUAL ROCK PLORT


        //---------- GRASS ---------- \\


        // START LOAD GRASS PLORT
        GameObject GrassPlortTuple = GrassSlimePlort.GrassPlort();

        GameObject GrassPlort_GrassPlort_Object = GrassPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, GrassPlort_GrassPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite GrassPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Grass.grass_slime_plort.png"));
        Color GrassColor = new Color32(34, 139, 34, 255); // green
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.grassIds.GRASS_PLORT, GrassColor, GrassPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.grassIds.GRASS_PLORT);

        float grassPrice = 40f; //Starting price for plort
        float grassSaturated = 1f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.grassIds.GRASS_PLORT, grassPrice, grassSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.grassIds.GRASS_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.grassIds.GRASS_PLORT);
        // END LOAD GRASS PLORT

        // START LOAD PLANT PLORT
        GameObject PlantPlortTuple = GrassSlimePlort.PlantPlort();

        GameObject PlantPlort_PlantPlort_Object = PlantPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, PlantPlort_PlantPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite PlantPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Grass.grass_slime_plant_plort.png"));
        Color PlantColor = new Color32(34, 139, 34, 255); // green
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.grassIds.PLANT_PLORT, PlantColor, PlantPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.grassIds.GRASS_PLORT);

        float plantPrice = 50f; //Starting price for plort
        float plantSaturated = 7f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.grassIds.PLANT_PLORT, plantPrice, plantSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.grassIds.PLANT_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.grassIds.PLANT_PLORT);
        // END LOAD PLANT PLORT


        //./---------- PRETTY RARE MATERIAL SLIMES ----------\.\\


        //---------- LIGHT ---------- \\


        // START LOAD LIGHT PLORT
        GameObject LightPlortTuple = LightSlimePlort.LightPlort();

        GameObject LightPlort_LightPlort_Object = LightPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, LightPlort_LightPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite LightPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Light.light_slime_plort.png"));
        Color LightColor = Color.yellow; // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.lightIds.LIGHT_PLORT, LightColor, LightPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.lightIds.LIGHT_PLORT);

        float lightPrice = 60f; //Starting price for plort
        float lightSaturated = 7f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.lightIds.LIGHT_PLORT, lightPrice, lightSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.lightIds.LIGHT_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.lightIds.LIGHT_PLORT);
        // END LOAD LIGHT PLORT


        //---------- NEWBUCK ---------- \\


        // START LOAD NEWBUCK PLORT
        GameObject NewbuckPlortTuple = NewbuckSlimePlort.NewbuckPlort();

        GameObject NewbuckPlort_NewbuckPlort_Object = NewbuckPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, NewbuckPlort_NewbuckPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite NewbuckPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Newbuck.newbuck_slime_plort.png"));
        Color NewbuckColor = new Color32(244, 182, 73, 255); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.newbuckIds.NEWBUCK_PLORT, NewbuckColor, NewbuckPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.newbuckIds.NEWBUCK_PLORT);

        float newbuckPrice = 300f; //Starting price for plort
        float newbuckSaturated = 10f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.newbuckIds.NEWBUCK_PLORT, newbuckPrice, newbuckSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.newbuckIds.NEWBUCK_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.newbuckIds.NEWBUCK_PLORT);
        // END LOAD NEWBUCK PLORT

        // START LOAD RICH NEWBUCK PLORT
        GameObject RichNewbuckPlortTuple = NewbuckSlimePlort.RichNewbuckPlort();

        GameObject RichNewbuckPlort_RichNewbuckPlort_Object = RichNewbuckPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, RichNewbuckPlort_RichNewbuckPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite RichNewbuckPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Newbuck.rich_newbuck_slime_plort.png"));
        Color RichNewbuckColor = new Color32(244, 182, 73, 255); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT, RichNewbuckColor, RichNewbuckPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);

        float richNewbuckPrice = 600f; //Starting price for plort
        float richNewbuckSaturated = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT, richNewbuckPrice, richNewbuckSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);
        // END LOAD RICH NEWBUCK PLORT

        // START LOAD RICHER NEWBUCK PLORT
        GameObject RicherNewbuckPlortTuple = NewbuckSlimePlort.RicherNewbuckPlort();

        GameObject RicherNewbuckPlort_RicherNewbuckPlort_Object = RicherNewbuckPlortTuple;

        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, RicherNewbuckPlort_RicherNewbuckPlort_Object);
        // Icon that is below is just a placeholder. You can change it to anything or add your own! 
        Sprite RicherNewbuckPlortIcon = CreateSprite(LoadImage("Assets.Slimes.Newbuck.richer_newbuck_slime_plort.png"));
        Color RicherNewbuckColor = new Color32(244, 182, 73, 255); // RGB   
        LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT, RicherNewbuckColor, RicherNewbuckPlortIcon));
        AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);

        float richerNewbuckPrice = 800f; //Starting price for plort
        float richerNewbuckSaturated = 1f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
        PlortRegistry.AddEconomyEntry(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT, richerNewbuckPrice, richerNewbuckSaturated); //Allows it to be sold while the one below this adds it to plort market.   
        PlortRegistry.AddPlortEntry(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
        DroneRegistry.RegisterBasicTarget(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);
        // END LOAD RICHER NEWBUCK PLORT

        return;
    }

    static public void LoadItems()
    {
        MaterialSqueeze.LoadMaterialSqueeze();
        Fertilizer.LoadFertilizer();
    }

    static public void LoadGadgets()
    {
        MaterialExtractor.LoadMaterialExtractor();
    }
}

