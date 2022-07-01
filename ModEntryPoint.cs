using MonomiPark.SlimeRancher.Regions;
using SRML;
using SRML.SR;
using SRML.SR.Translation;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// bruh
using GlueSlime;
using PlasticSlime;
using GlassSlime;
using MetalSlime;
using WoodSlime;

namespace MaterialSlimes
{
    public class Main : ModEntryPoint
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

        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            //-- PRE LOAD --\\

            // OTHER STUFF
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());


            //---------- GLUE (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: GLUE SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.glueIds.GLUE_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.glueIds.GLUE_ENTRY, ModdedIds.glueIds.GLUE_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.glueIds.GLUE_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.glueIds.GLUE_ENTRY)
                .SetTitleTranslation("Glue Slime")
                .SetIntroTranslation("Gooey, Hungry, Vegetarian Slime?")
                .SetDietTranslation("Veggies, (Sometimes Pink Slimes/Plorts)")
                .SetFavoriteTranslation("Heart Beet")
                .SetSlimeologyTranslation("Glue Slimes are your gooey little friends! They're made out of glue entirely, along with some slimey substance. They do get hungry to the point they may or may not eat something they shouldn't. Tarrs also dislike their gluey taste and will not eat them.")
                .SetRisksTranslation("There are no dangerous risk! Glue Slimes are usually friendly, but.. if they have no other food source, they may result to eating Pink Slimes. They're common so its easy for them to gobble on with no veggies around, so keep them away from your pink slimes if you must!")
                .SetPlortonomicsTranslation("Their plorts are made out of glue as well, great for gluing things together.. that's for sure!");
            // END SLIMEPEDIA ENTRY: GLUE SLIME

            // GLUE PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.glueIds.GLUE_PLORT.ToString().ToLower(), "Glue Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.glueIds.GLUE_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.glueIds.GLUE_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.glueIds.GLUE_PLORT);

            // START GLUE SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.REEF;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.glueIds.GLUE_SLIME),
                                weight = 0.3f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END GLUE SLIME SPAWNER


            //---------- PLASTIC (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: PLASTIC SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.plasticIds.PLASTIC_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.plasticIds.PLASTIC_ENTRY, ModdedIds.plasticIds.PLASTIC_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.plasticIds.PLASTIC_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.plasticIds.PLASTIC_ENTRY)
                .SetTitleTranslation("Plastic Slime")
                .SetIntroTranslation("Sneaky little slimes, aren't they?")
                .SetDietTranslation("Fruits, (Sometimes Meat)")
                .SetFavoriteTranslation("Cuberry, Mint Mango")
                .SetSlimeologyTranslation("Ah, The Plastic Slimes. Plastic Slimes are a little sneaky, but also fun. These slimes will turn invisible sometimes, and become visible again! Its not that hard to notice they're there, but watch out.. you may bump into one. Tarrs also dislike their plastic taste and will not eat them.")
                .SetRisksTranslation("Plastic Slimes have no dangerous risk! If you care for your Glue Plorts though, they'll eat them sometimes as additional food. They seem to enjoy its gooey/gluey taste..")
                .SetPlortonomicsTranslation("The Plastic Plorts are made out of plastic. Plastic Plorts have many uses on Earth which gives them PLENTY of value, if you're interested in investing in Plastic Plorts, better start wrangling some Plastic Slimes!");
            // END SLIMEPEDIA ENTRY: PLASTIC SLIME

            // PLASTIC PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.plasticIds.PLASTIC_PLORT.ToString().ToLower(), "Plastic Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.plasticIds.PLASTIC_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.plasticIds.PLASTIC_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.plasticIds.PLASTIC_PLORT);

            // START PLASTIC SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.MOSS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.plasticIds.PLASTIC_SLIME),
                                weight = 0.08f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END PLASTIC SLIME SPAWNER


            //---------- GLASS (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: GLASS SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.glassIds.GLASS_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.glassIds.GLASS_ENTRY, ModdedIds.glassIds.GLASS_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.glassIds.GLASS_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.glassIds.GLASS_ENTRY)
                .SetTitleTranslation("Glass Slime")
                .SetIntroTranslation("Oh its so- clear..?")
                .SetDietTranslation("Meat, (Sometimes Veggies)")
                .SetFavoriteTranslation("Stony Hen")
                .SetSlimeologyTranslation("Glass Slimes? Well, these slimes are pretty friendly. They eat meat, sometimes veggies. Every few moments they might also start hovering, pretty cool, huh? Not much to say about glass slimes. Tarrs also dislike their.. glassy taste(?) and will not eat them.")
                .SetRisksTranslation("This slime provides no dangerous risk, keep them away from your coops!")
                .SetPlortonomicsTranslation("Glass Slimes produce Glass Plorts which are used often in experiments, on earth, etc. Although, their value is about the same as the Glue Slime and not popular demand as its materials could be re-created.");
            // END SLIMEPEDIA ENTRY: GLASS SLIME

            // GLASS PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.glassIds.GLASS_PLORT.ToString().ToLower(), "Glass Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.glassIds.GLASS_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.glassIds.GLASS_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.glassIds.GLASS_PLORT);

            // START GLASS SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.DESERT;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.glassIds.GLASS_SLIME),
                                weight = 0.1f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END GLASS SLIME SPAWNER

            // START SLIMEPEDIA ENTRY: METAL SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.metalIds.METAL_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.metalIds.METAL_ENTRY, ModdedIds.metalIds.METAL_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.metalIds.METAL_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.metalIds.METAL_ENTRY)
                .SetTitleTranslation("Metal Slime")
                .SetIntroTranslation("Pure Metal. Pure Heart. Pure Cuteness.")
                .SetDietTranslation("Veggies, Meat, (Sometimes Rock Slimes)")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Aww.. Metal Slimes are cute, aren't they? Although, they were first tarr look-alikes at one point then morphed into this cute little slime, pretty cool fact, right? Sometimes if there is no other food source.. they'll result to eating their own Metal Plorts or a Rock Slime. Tarrs also dislike their metal taste and will not eat them.")
                .SetRisksTranslation("Metal Slimes have no Rancher risks! The only possible risk is a shortage in Rock Slimes or Metal Plorts (Although they'd just produce another). Make sure to collect your Metal Plorts and keep them away from Rock Slimes if you wanna keep em!")
                .SetPlortonomicsTranslation("Metal Plorts have a GOOD amount of value. Used for making weapons, equipment, etc.. all the possibilities. So if you want to invest in Metal Plorts, better treat your Metal Slimes right!");
            // END SLIMEPEDIA ENTRY: METAL SLIME

            // METAL PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.metalIds.METAL_PLORT.ToString().ToLower(), "Metal Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.metalIds.METAL_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.metalIds.METAL_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.metalIds.METAL_PLORT);

            // START METAL SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.QUARRY;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.metalIds.METAL_SLIME),
                                weight = 0.09f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END METAL SLIME SPAWNER

            // START SLIMEPEDIA ENTRY: WOOD SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.woodIds.WOOD_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.woodIds.WOOD_ENTRY, ModdedIds.woodIds.WOOD_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.woodIds.WOOD_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.woodIds.WOOD_ENTRY)
                .SetTitleTranslation("Wood Slime")
                .SetIntroTranslation("Wood? Wood. Very much Wood.")
                .SetDietTranslation("Veggies, Fruit, Meat")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Wood Slimes are pretty normal. They eat, they jump around, they do anything a normal slime would. Best friends for life! Tarrs also dislike their wooden taste and will not eat them.")
                .SetRisksTranslation("Wood slimes are as safe as possible.")
                .SetPlortonomicsTranslation("Wood Plorts aren't worth much, there is trees everywhere around.. literally get wood from anywhere. Who cares though? They still came from one of the cutest slimes possible.. right?");
            // END SLIMEPEDIA ENTRY: WOOD SLIME

            // WOOD PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.woodIds.WOOD_PLORT.ToString().ToLower(), "Wood Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.woodIds.WOOD_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.woodIds.WOOD_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.woodIds.WOOD_PLORT);

            // START WOOD SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.RANCH || zone == ZoneDirector.Zone.REEF || zone == ZoneDirector.Zone.QUARRY || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.DESERT || zone == ZoneDirector.Zone.SEA || zone == ZoneDirector.Zone.RUINS || zone == ZoneDirector.Zone.RUINS_TRANSITION || zone == ZoneDirector.Zone.WILDS || zone == ZoneDirector.Zone.SLIMULATIONS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.woodIds.WOOD_SLIME),
                                weight = 0.5f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END WOOD SLIME SPAWNER

            // START SLIMEPEDIA ENTRY: SELF DISCOVERY SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.discoveryIds.DISCOVERY_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.discoveryIds.DISCOVERY_ENTRY, ModdedIds.discoveryIds.DISCOVERY_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.discoveryIds.DISCOVERY_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.discoveryIds.DISCOVERY_ENTRY)
                .SetTitleTranslation("Self Discovery Slime")
                .SetIntroTranslation("Summon the Material Slimes..!")
                .SetDietTranslation("Kookadoba, Tarrs")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Seems you've encountered a Self Discovery Slime. These slimes will summon/spawn a material slime once it eats. Plastic, Glue, Wood, you name it! Although its all random and it will only spawn one. The slime munches on Kookadoba or Tarr Slimes, so don't expect it to be easy to feed. Tarrs also dislike the Self Discovery Slime due to it eating their kind. These slimes will not run away from Tarr Slimes and instead go towards them for food.")
                .SetRisksTranslation("Self Discovery Slimes are safe, riskes are that you have a tarr outbreak if you take the shortcut of feeding it Tarrs. Sometimes.. they might even pretend to eat it but don't? If they pretend, they won't produce a Material Slime. Make sure to have water on you, or a lake nearby when feeding them Tarrs!")
                .SetPlortonomicsTranslation("This slime has no plorts, it produces Material Slimes. All of these Material Slimes have a slimepedia on their plorts.");
            // END SLIMEPEDIA ENTRY: SELF DISCOVERY SLIME

            // START SELF DISCOVERY SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.RANCH || zone == ZoneDirector.Zone.REEF || zone == ZoneDirector.Zone.QUARRY || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.DESERT || zone == ZoneDirector.Zone.SEA || zone == ZoneDirector.Zone.RUINS || zone == ZoneDirector.Zone.RUINS_TRANSITION || zone == ZoneDirector.Zone.WILDS || zone == ZoneDirector.Zone.SLIMULATIONS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.discoveryIds.DISCOVERY_SLIME),
                                weight = 0.02f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END SELF DISCOVERY SLIME SPAWNER
        }

        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            //-- LOAD --\\


            //---------- GLUE ---------- \\


            // START LOAD GLUE SLIME
            (SlimeDefinition, GameObject) GlueTuple = GlueSlime.GlueSlime.CreateSlime(ModdedIds.glueIds.GLUE_SLIME, "Glue Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Glue_Glue_Definition = GlueTuple.Item1;
            GameObject Glue_Glue_Object = GlueTuple.Item2;

            Glue_Glue_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Glue_Glue_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.glueIds.GLUE_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.glue_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.glueIds.GLUE_SLIME.ToString().ToLower(), "Glue Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.glueIds.GLUE_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.glue_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Glue_Glue_Object);
            SlimeRegistry.RegisterSlimeDefinition(Glue_Glue_Definition);
            // END LOAD GLUE SLIME

            // START LOAD GLUE PLORT
            GameObject GluePlortTuple = GlueSlimePlort.GluePlort();

            GameObject GluePlort_GluePlort_Object = GluePlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, GluePlort_GluePlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite GluePlortIcon = CreateSprite(LoadImage("Assets.glue_slime_plort.png"));
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


            // START LOAD PLASTIC SLIME
            (SlimeDefinition, GameObject) PlasticTuple = PlasticSlime.PlasticSlime.CreateSlime(ModdedIds.plasticIds.PLASTIC_SLIME, "Plastic Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Plastic_Plastic_Definition = PlasticTuple.Item1;
            GameObject Plastic_Plastic_Object = PlasticTuple.Item2;

            Plastic_Plastic_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Plastic_Plastic_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.plasticIds.PLASTIC_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.plastic_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.plasticIds.PLASTIC_SLIME.ToString().ToLower(), "Plastic Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.plasticIds.PLASTIC_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.plastic_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Plastic_Plastic_Object);
            SlimeRegistry.RegisterSlimeDefinition(Plastic_Plastic_Definition);
            // END LOAD PLASTIC SLIME

            // START LOAD PLASTIC PLORT
            GameObject PlasticPlortTuple = PlasticSlimePlort.PlasticPlort();

            GameObject PlasticPlort_PlasticPlort_Object = PlasticPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, PlasticPlort_PlasticPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite PlasticPlortIcon = CreateSprite(LoadImage("Assets.plastic_slime_plort.png"));
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


            // START LOAD GLASS SLIME
            (SlimeDefinition, GameObject) GlassTuple = GlassSlime.GlassSlime.CreateSlime(ModdedIds.glassIds.GLASS_SLIME, "Glass Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Glass_Glass_Definition = GlassTuple.Item1;
            GameObject Glass_Glass_Object = GlassTuple.Item2;

            Glass_Glass_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Glass_Glass_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.glassIds.GLASS_SLIME, new Color32(246, 254, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.glass_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.glassIds.GLASS_SLIME.ToString().ToLower(), "Glass Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.glassIds.GLASS_SLIME, new Color32(255, 255, 255, byte.MaxValue), CreateSprite(LoadImage("Assets.glass_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Glass_Glass_Object);
            SlimeRegistry.RegisterSlimeDefinition(Glass_Glass_Definition);
            // END LOAD GLASS SLIME

            // START LOAD GLASS PLORT
            GameObject GlassPlortTuple = GlassSlimePlort.GlassPlort();

            GameObject GlassPlort_GlassPlort_Object = GlassPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, GlassPlort_GlassPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite GlassPlortIcon = CreateSprite(LoadImage("Assets.glass_slime_plort.png"));
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


            // START LOAD METAL SLIME
            (SlimeDefinition, GameObject) MetalTuple = MetalSlime.MetalSlime.CreateSlime(ModdedIds.metalIds.METAL_SLIME, "Metal Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Metal_Metal_Definition = MetalTuple.Item1;
            GameObject Metal_Metal_Object = MetalTuple.Item2;

            Metal_Metal_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Metal_Metal_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.metalIds.METAL_SLIME, Color.grey, CreateSprite(LoadImage("Assets.metal_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.metalIds.METAL_SLIME.ToString().ToLower(), "Metal Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.metalIds.METAL_SLIME, Color.grey, CreateSprite(LoadImage("Assets.metal_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Metal_Metal_Object);
            SlimeRegistry.RegisterSlimeDefinition(Metal_Metal_Definition);
            // END LOAD METAL SLIME

            // START LOAD METAL PLORT
            GameObject MetalPlortTuple = MetalSlimePlort.MetalPlort();

            GameObject MetalPlort_MetalPlort_Object = MetalPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, MetalPlort_MetalPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite MetalPlortIcon = CreateSprite(LoadImage("Assets.metal_slime_plort.png"));
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


            // START LOAD WOOD SLIME
            (SlimeDefinition, GameObject) WoodTuple = WoodSlime.WoodSlime.CreateSlime(ModdedIds.woodIds.WOOD_SLIME, "Wood Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Wood_Wood_Definition = WoodTuple.Item1;
            GameObject Wood_Wood_Object = WoodTuple.Item2;

            Wood_Wood_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Wood_Wood_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.woodIds.WOOD_SLIME, new Color32(150, 111, 51, 255), CreateSprite(LoadImage("Assets.wood_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.woodIds.WOOD_SLIME.ToString().ToLower(), "Wood Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.woodIds.WOOD_SLIME, new Color32(150, 111, 51, 255), CreateSprite(LoadImage("Assets.wood_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Wood_Wood_Object);
            SlimeRegistry.RegisterSlimeDefinition(Wood_Wood_Definition);
            // END LOAD WOOD SLIME

            // START LOAD WOOD PLORT
            GameObject WoodPlortTuple = WoodSlimePlort.WoodPlort();

            GameObject WoodPlort_WoodPlort_Object = WoodPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, WoodPlort_WoodPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite WoodPlortIcon = CreateSprite(LoadImage("Assets.wood_slime_plort.png"));
            Color WoodColor = new Color32(150, 111, 51, 255); // RGB   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.woodIds.WOOD_PLORT, WoodColor, WoodPlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.woodIds.WOOD_PLORT);

            float woodPrice = 12f; //Starting price for plort
            float woodSaturated = 3f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(ModdedIds.woodIds.WOOD_PLORT, woodPrice, woodSaturated); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(ModdedIds.woodIds.WOOD_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(ModdedIds.woodIds.WOOD_PLORT);
            // END LOAD WOOD PLORT


            //---------- SELF DISCOVERY ---------- \\


            // START LOAD SELF DISCOVERY SLIME
            (SlimeDefinition, GameObject) DiscoveryTuple = SelfDiscoverySlime.SelfDiscoverySlime.CreateSlime(ModdedIds.woodIds.WOOD_SLIME, "Wood Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Discovery_Discovery_Definition = DiscoveryTuple.Item1;
            GameObject Discovery_Discovery_Object = DiscoveryTuple.Item2;

            Discovery_Discovery_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Discovery_Discovery_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.discoveryIds.DISCOVERY_SLIME, new Color32(255, 191, 94, 255), CreateSprite(LoadImage("Assets.selfdiscovery_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.discoveryIds.DISCOVERY_SLIME.ToString().ToLower(), "Self Discovery Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.discoveryIds.DISCOVERY_SLIME, new Color32(255, 191, 94, 255), CreateSprite(LoadImage("Assets.selfdiscovery_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Discovery_Discovery_Object);
            SlimeRegistry.RegisterSlimeDefinition(Discovery_Discovery_Definition);
            // END LOAD SELF DISCOVERY SLIME
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
            //-- POST LOAD --\\
        }

    }
}