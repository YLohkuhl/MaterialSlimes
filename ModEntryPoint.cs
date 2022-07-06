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
using LightSlime;
using ConcreteSlime;
using CottonSlime;
using CopperSlime;
using IceSlime;

// bruh 2
/*using SecretStyles;
using SecretStyle;*/

namespace MaterialSlimes
{

    /*public struct SpeckleInstructions
    {
        public bool active;
        public float addR;
        public float addG;
        public float addB;
        public string applyTo;
    }

    public struct GlowInstructions
    {
        public Color32 color;
        public float[] max;
        public float[] min;
    }*/

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
            TranslationPatcher.AddUITranslation("m.foodgroup.plorts", "Plorts");
            // TranslationPatcher.AddUITranslation("m.foodgroup.fresh_water", "Fresh Water");
            TranslationPatcher.AddUITranslation("m.foodgroup.nontarrgold_slimes", "Slimes");


            // || SLIMEPEDIAS/SPAWNERS/ETC || \\


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

            //---------- METAL (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\

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
                .SetPlortonomicsTranslation("Metal Plorts have a GOOD amount of value. Used for making weapons, equipment, etc.. all the possibilities. So if you want to invest in Metal Plorts, better treat your Metal Slimes right! They're also too heavy for the vacpack to vaccuum so you can only pick them up one by one.");
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


            //---------- WOOD (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


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


            //---------- CONCRETE (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: CONCRETE SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.concreteIds.CONCRETE_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.concreteIds.CONCRETE_ENTRY, ModdedIds.concreteIds.CONCRETE_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.concreteIds.CONCRETE_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.concreteIds.CONCRETE_ENTRY)
                .SetTitleTranslation("Concrete Slime")
                .SetIntroTranslation("Their heavy.. so are their plorts.")
                .SetDietTranslation("Fresh Water, Rock Plorts")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Ah, Concrete Slimes. These slimes are indeed heavy, they'll barely move besides when they wanna eat! They munch on Fresh Water (This will not produce plorts.), Puddle Plorts or Rock Plorts, only these 2 things though.. otherwise, they'll probably starve. Tarrs cannot eat Concrete Slimes, who eats concrete? Concrete Slimes will also not run away from them.")
                .SetRisksTranslation("Concrete Slimes are safe, but make sure to keep some water on you (Which may not do much) or at least some puddle plorts/rock plorts.")
                .SetPlortonomicsTranslation("Concrete Plorts are made out of concrete which gives them plenty of usages, especially on earth. This makes them a good amount of value and possibly almost the same as the Plastic Slimes. They're also too heavy for the vacpack to vaccuum so you can only pick them up one by one. Due to this, you may or may not want to have their corrals next to the Plort Market.. or get ready for a lot of walking/running around!");
            // END SLIMEPEDIA ENTRY: CONCRETE SLIME

            // CONCRETE PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.concreteIds.CONCRETE_PLORT.ToString().ToLower(), "Concrete Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.concreteIds.CONCRETE_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.concreteIds.CONCRETE_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.concreteIds.CONCRETE_PLORT);

            // START CONCRETE SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.RUINS || zone == ZoneDirector.Zone.WILDS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.concreteIds.CONCRETE_SLIME),
                                weight = 0.2f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END CONCRETE SLIME SPAWNER


            //---------- COTTON (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: COTTON SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.cottonIds.COTTON_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.cottonIds.COTTON_ENTRY, ModdedIds.cottonIds.COTTON_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.cottonIds.COTTON_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.cottonIds.COTTON_ENTRY)
                .SetTitleTranslation("Cotton Slime")
                .SetIntroTranslation("So light.. its floating away!")
                .SetDietTranslation("Veggies")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Oh- This one floats! Cotton Slimes are almost 80% Cotton Material & 20% Slimey Substance. This makes the slime easily able to float away, so make sure to have air nets on your corrals. If not.. you may have to quickly try to catch it before it floats away, never to be seen again. Tarrs don't eat cotton, why would they eat cotton?")
                .SetRisksTranslation("Cotton Slimes are completely safe! Just make sure to watch out before it floats away.")
                .SetPlortonomicsTranslation("These Cotton Plorts they produce are at a good amount of value. Cotton is used for plenty of things, which makes them a very good resource for Slimes to just produce. Cotton Slimes are also not too hard to handle, so you should be able to have a whole lot of Cotton Plorts in no time!");
            // END SLIMEPEDIA ENTRY: COTTON SLIME

            // COTTON PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.cottonIds.COTTON_PLORT.ToString().ToLower(), "Cotton Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.cottonIds.COTTON_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.cottonIds.COTTON_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.cottonIds.COTTON_PLORT);

            // START COTTON SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.REEF;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.cottonIds.COTTON_SLIME),
                                weight = 0.2f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END COTTON SLIME SPAWNER


            //---------- COPPER (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: COPPER SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.copperIds.COPPER_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.copperIds.COPPER_ENTRY, ModdedIds.copperIds.COPPER_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.copperIds.COPPER_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.copperIds.COPPER_ENTRY)
                .SetTitleTranslation("Copper Slime")
                .SetIntroTranslation("How shiny and brown..?")
                .SetDietTranslation("Veggies, Meat")
                .SetFavoriteTranslation("Gilded Ginger, Elder Roostro")
                .SetSlimeologyTranslation("What a normal slime, right? Oh wait.. did it just.. it did. It teleported to a nearby area- Now that seems fun, doesn't it? Although, it may not be good if it teleports away from you. Why would Tarrs eat copper? No.")
                .SetRisksTranslation("If you don't want to risk it teleporting away, try putting it in a corral.. I think they'd stay inside, possibly.")
                .SetPlortonomicsTranslation("Copper.. Plorts, oh the uses of this plort. Its a shortcut to getting Copper way easier then it is on Earth, which gives them a good amount of value.. but not the best.");
            // END SLIMEPEDIA ENTRY: COPPER SLIME

            // COPPER PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.copperIds.COPPER_PLORT.ToString().ToLower(), "Copper Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.copperIds.COPPER_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.copperIds.COPPER_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.copperIds.COPPER_PLORT);

            // START COPPER SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.WILDS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.copperIds.COPPER_SLIME),
                                weight = 0.15f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END COPPER SLIME SPAWNER


            //---------- ICE (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: ICE SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.iceIds.ICE_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.iceIds.ICE_ENTRY, ModdedIds.iceIds.ICE_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.iceIds.ICE_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.iceIds.ICE_ENTRY)
                .SetTitleTranslation("Ice Slime")
                .SetIntroTranslation("Be careful, its fragile!")
                .SetDietTranslation("Puddle Plorts, Puddle Slimes, Oca Oca")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("It looks as if its about to crack! Ice Slimes need water-based items to live, it took forever for scientist to find something that it would eat that wasn't exactly water-based. They're pretty slippery as well- Don't expect them not to be slipping away! Ice slimes are apparently too cold for Tarrs to eat.")
                .SetRisksTranslation("..They're cold.")
                .SetPlortonomicsTranslation("Ice plorts are pretty rare due to that they don't melt after hours and hours of sitting out. Imagine how long your drink could stay cold for! Oh how magical.");
            // END SLIMEPEDIA ENTRY: ICE SLIME

            // ICE PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.iceIds.ICE_PLORT.ToString().ToLower(), "Ice Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.iceIds.ICE_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.iceIds.ICE_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.iceIds.ICE_PLORT);

            // START ICE SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.QUARRY || zone == ZoneDirector.Zone.MOSS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.iceIds.ICE_SLIME),
                                weight = 0.12f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END ICE SLIME SPAWNER


            // || PRETTY RARE SLIMEPEDIAS/SPAWNERS/ETC || \\


            //---------- SELF DISCOVERY (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: SELF DISCOVERY SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.discoveryIds.DISCOVERY_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.discoveryIds.DISCOVERY_ENTRY, ModdedIds.discoveryIds.DISCOVERY_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.discoveryIds.DISCOVERY_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.discoveryIds.DISCOVERY_ENTRY)
                .SetTitleTranslation("Self Discovery Slime")
                .SetIntroTranslation("Summon the Material Slimes..!")
                .SetDietTranslation("Kookadoba, Phase Lemons")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Seems you've encountered a Self Discovery Slime. These slimes will summon/spawn a material slime once it eats. Plastic, Glue, Wood, you name it! Although its all random and it will only spawn one. The slime munches on Kookadoba or Phase Lemons, so don't expect it to be too easy to feed. Tarrs eating Self Discovery Slimes? Not in a million years. These slimes will not run away from Tarr Slimes, they have no fear for the threats in this world..")
                .SetRisksTranslation("Self Discovery Slimes are safe, riskes are that a Dark Slime spawns and you have a little bit of an issue in your corral.. if you are sharing it with other slimes. Dark Slimes will not eat Self Discovery Slimes.")
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


            //---------- LIGHT (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: LIGHT SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.lightIds.LIGHT_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.lightIds.LIGHT_ENTRY, ModdedIds.lightIds.LIGHT_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.lightIds.LIGHT_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.lightIds.LIGHT_ENTRY)
                .SetTitleTranslation("Light Slime")
                .SetIntroTranslation("I see a bright light..! Oh, its just a Light Slime.")
                .SetDietTranslation("Plorts")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("Light Slimes.. oh how they shine their light. A Material Slime which doesn't spawn, but is produced by a Self Discovery Slime. Pretty rare if you ask me, the slimepedia.. but these slimes feed on plorts. ALMOST ALL PLORTS. Tarrs will shine of Light if they eat these slimes, they dislike that so they will not eat them. (NOTE: Keep away from Dark Slimes.)")
                .SetRisksTranslation("Light Slimes are safe, just be ready for a shortage of plorts.. or keep some extra ones just to feed them.")
                .SetPlortonomicsTranslation("Light Plorts are worth a PRETTY GOOD AMOUNT of value. Its literally light, what do you expect? Make a light powered portal gun while you're at it.");
            // END SLIMEPEDIA ENTRY: LIGHT SLIME

            // LIGHT PLORT TRANSLATION
            TranslationPatcher.AddActorTranslation("l." + ModdedIds.lightIds.LIGHT_PLORT.ToString().ToLower(), "Light Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.lightIds.LIGHT_PLORT);
            Identifiable.PLORT_CLASS.Add(ModdedIds.lightIds.LIGHT_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.lightIds.LIGHT_PLORT);


            //---------- DARK (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


            // START SLIMEPEDIA ENTRY: DARK SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.darkIds.DARK_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(ModdedIds.darkIds.DARK_ENTRY, ModdedIds.darkIds.DARK_SLIME);
            PediaRegistry.SetPediaCategory(ModdedIds.darkIds.DARK_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(ModdedIds.darkIds.DARK_ENTRY)
                .SetTitleTranslation("Dark Slime")
                .SetIntroTranslation("I see.. darkness! Help!! Oh, its just a Dark Slime.. WAIT-")
                .SetDietTranslation("Slimes")
                .SetFavoriteTranslation("(none)")
                .SetSlimeologyTranslation("You saw this slime? You may or may not want to get rid of it. They are produced by Self Discovery Slimes.. but its as if its a miniature Tarr Slime, they eat other slimes which produce more Dark Slimes (But only when they're hungry). The Light & Dark Slime will indeed try to eat eachother if ever needed, better off not pairing them together. Tarrs value the Dark Slimes hard work and will not eat them by any means.")
                .SetRisksTranslation("Dark Slimes have the risk of loosing slimes, they will eat them when they're hungry and only them. They will not harm Ranchers, but it would be bad if you lost all your slimes. They will also not eat Self Discovery Slimes as those slimes created them, but will eat any other slime.")
                .SetPlortonomicsTranslation("There is no such thing as a 'Dark Plort' or any type of plort that this slime produces, it will produce other Dark Slimes.");
            // END SLIMEPEDIA ENTRY: DARK SLIME
        }

        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            //-- LOAD --\\


            //./---------- MATERIAL SLIMES ----------\.\\

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


            //---------- CONCRETE ---------- \\


            // START LOAD CONCRETE SLIME
            (SlimeDefinition, GameObject) ConcreteTuple = ConcreteSlime.ConcreteSlime.CreateSlime(ModdedIds.concreteIds.CONCRETE_SLIME, "Concrete Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Concrete_Concrete_Definition = ConcreteTuple.Item1;
            GameObject Concrete_Concrete_Object = ConcreteTuple.Item2;

            Concrete_Concrete_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Concrete_Concrete_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.concreteIds.CONCRETE_SLIME, Color.grey, CreateSprite(LoadImage("Assets.concrete_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.concreteIds.CONCRETE_SLIME.ToString().ToLower(), "Concrete Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.concreteIds.CONCRETE_SLIME, Color.grey, CreateSprite(LoadImage("Assets.concrete_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Concrete_Concrete_Object);
            SlimeRegistry.RegisterSlimeDefinition(Concrete_Concrete_Definition);
            // END LOAD CONCRETE SLIME

            // START LOAD CONCRETE PLORT
            GameObject ConcretePlortTuple = ConcreteSlimePlort.ConcretePlort();

            GameObject ConcretePlort_ConcretePlort_Object = ConcretePlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, ConcretePlort_ConcretePlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite ConcretePlortIcon = CreateSprite(LoadImage("Assets.concrete_slime_plort.png"));
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


            // START LOAD COTTON SLIME
            (SlimeDefinition, GameObject) CottonTuple = CottonSlime.CottonSlime.CreateSlime(ModdedIds.cottonIds.COTTON_SLIME, "Cotton Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Cotton_Cotton_Definition = CottonTuple.Item1;
            GameObject Cotton_Cotton_Object = CottonTuple.Item2;

            Cotton_Cotton_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Cotton_Cotton_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.cottonIds.COTTON_SLIME, Color.white, CreateSprite(LoadImage("Assets.cotton_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.cottonIds.COTTON_SLIME.ToString().ToLower(), "Cotton Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.cottonIds.COTTON_SLIME, Color.white, CreateSprite(LoadImage("Assets.cotton_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Cotton_Cotton_Object);
            SlimeRegistry.RegisterSlimeDefinition(Cotton_Cotton_Definition);
            // END LOAD COTTON SLIME

            // START LOAD COTTON PLORT
            GameObject CottonPlortTuple = CottonSlimePlort.CottonPlort();

            GameObject CottonPlort_CottonPlort_Object = CottonPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, CottonPlort_CottonPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite CottonPlortIcon = CreateSprite(LoadImage("Assets.cotton_slime_plort.png"));
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


            // START LOAD COPPER SLIME
            (SlimeDefinition, GameObject) CopperTuple = CopperSlime.CopperSlime.CreateSlime(ModdedIds.copperIds.COPPER_SLIME, "Copper Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Copper_Copper_Definiton = CopperTuple.Item1;
            GameObject Copper_Copper_Object = CopperTuple.Item2;

            Copper_Copper_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Copper_Copper_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.copperIds.COPPER_SLIME, new Color32(140, 79, 55, 255), CreateSprite(LoadImage("Assets.copper_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.copperIds.COPPER_SLIME.ToString().ToLower(), "Copper Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.copperIds.COPPER_SLIME, new Color32(140, 79, 55, 255), CreateSprite(LoadImage("Assets.copper_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Copper_Copper_Object);
            SlimeRegistry.RegisterSlimeDefinition(Copper_Copper_Definiton);
            // END LOAD COPPER SLIME

            // START LOAD COPPER PLORT
            GameObject CopperPlortTuple = CopperSlimePlort.CopperPlort();

            GameObject CopperPlort_CopperPlort_Object = CopperPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, CopperPlort_CopperPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite CopperPlortIcon = CreateSprite(LoadImage("Assets.copper_slime_plort.png"));
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


            // START LOAD ICE SLIME
            (SlimeDefinition, GameObject) IceTuple = IceSlime.IceSlime.CreateSlime(ModdedIds.iceIds.ICE_SLIME, "Ice Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Ice_Ice_Definition = IceTuple.Item1;
            GameObject Ice_Ice_Object = IceTuple.Item2;

            Ice_Ice_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Ice_Ice_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.iceIds.ICE_SLIME, new Color(165, 242, 243, 255), CreateSprite(LoadImage("Assets.ice_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.iceIds.ICE_SLIME.ToString().ToLower(), "Ice Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.iceIds.ICE_SLIME, new Color(165, 242, 243, 255), CreateSprite(LoadImage("Assets.ice_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Ice_Ice_Object);
            SlimeRegistry.RegisterSlimeDefinition(Ice_Ice_Definition);
            // END LOAD ICE SLIME

            // START LOAD ICE PLORT
            GameObject IcePlortTuple = IceSlimePlort.IcePlort();

            GameObject IcePlort_IcePlort_Object = IcePlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, IcePlort_IcePlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite IcePlortIcon = CreateSprite(LoadImage("Assets.ice_slime_plort.png"));
            Color IceColor = Color.cyan; // RGB   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.iceIds.ICE_PLORT, IceColor, IcePlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.iceIds.ICE_PLORT);

            float icePrice = 50f; //Starting price for plort
            float iceSaturated = 1f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(ModdedIds.iceIds.ICE_PLORT, icePrice, iceSaturated); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(ModdedIds.iceIds.ICE_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(ModdedIds.iceIds.ICE_PLORT);
            // END LOAD ICE PLORT


            //./---------- PRETTY RARE MATERIAL SLIMES ----------\.\\

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


            //---------- LIGHT ---------- \\


            // START LOAD LIGHT SLIME
            (SlimeDefinition, GameObject) LightTuple = LightSlime.LightSlime.CreateSlime(ModdedIds.lightIds.LIGHT_SLIME, "Light Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Light_Light_Definition = LightTuple.Item1;
            GameObject Light_Light_Object = LightTuple.Item2;

            Light_Light_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Light_Light_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.lightIds.LIGHT_SLIME, Color.yellow, CreateSprite(LoadImage("Assets.light_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.lightIds.LIGHT_SLIME.ToString().ToLower(), "Light Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.lightIds.LIGHT_SLIME, Color.yellow, CreateSprite(LoadImage("Assets.light_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Light_Light_Object);
            SlimeRegistry.RegisterSlimeDefinition(Light_Light_Definition);
            // END LOAD LIGHT SLIME

            // START LOAD LIGHT PLORT
            GameObject LightPlortTuple = LightSlimePlort.LightPlort();

            GameObject LightPlort_LightPlort_Object = LightPlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, LightPlort_LightPlort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite LightPlortIcon = CreateSprite(LoadImage("Assets.light_slime_plort.png"));
            Color LightColor = Color.yellow; // RGB   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.lightIds.LIGHT_PLORT, LightColor, LightPlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, ModdedIds.lightIds.LIGHT_PLORT);

            float lightPrice = 60f; //Starting price for plort
            float lightSaturated = 7f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(ModdedIds.lightIds.LIGHT_PLORT, lightPrice, lightSaturated); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(ModdedIds.lightIds.LIGHT_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(ModdedIds.lightIds.LIGHT_PLORT);
            // END LOAD LIGHT PLORT



            //---------- DARK ---------- \\


            // START LOAD LIGHT SLIME
            (SlimeDefinition, GameObject) DarkTuple = DarkSlime.DarkSlime.CreateSlime(ModdedIds.darkIds.DARK_SLIME, "Dark Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Dark_Dark_Definition = DarkTuple.Item1;
            GameObject Dark_Dark_Object = DarkTuple.Item2;

            Dark_Dark_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Dark_Dark_Object);
            LookupRegistry.RegisterVacEntry(ModdedIds.darkIds.DARK_SLIME, Color.black, CreateSprite(LoadImage("Assets.dark_slime.png")));
            TranslationPatcher.AddPediaTranslation("t." + ModdedIds.darkIds.DARK_SLIME.ToString().ToLower(), "Dark Slime");
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(ModdedIds.darkIds.DARK_SLIME, Color.yellow, CreateSprite(LoadImage("Assets.dark_slime.png"))));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Dark_Dark_Object);
            SlimeRegistry.RegisterSlimeDefinition(Dark_Dark_Definition);
            // END LOAD LIGHT SLIME


            //./---------- GADGETS/ITEMS FOR MATERIAL SLIMES ----------\.\\


            //./---------- SECRET STYLES FOR MATERIAL SLIMES ----------\.\\


            /*if (SRModLoader.IsModPresent("mosecretstyles"))
            {
                SpeckleInstructions noSpeckle = new SpeckleInstructions() { active = false, addB = 0f, addR = 0f, addG = 0f, applyTo = "_None" };
                GlowInstructions noGlow = new GlowInstructions() { color = Color.clear, max = new float[] { 0f }, min = new float[] { 0f } };
                SlimeExpressionFace[] noface = new SlimeExpressionFace[0];
                SecretStyleFunctions.MSSDoTheThing(ModdedIds.glueIds.GLUE_SLIME, new Vector3(PodX, PodY, PodZ), Quaternion.Euler(PodRotX, PodRotY, PodRotZ), SpriteSS, "CellName", "SSname", "SlimenameLower", SecretStylesDesigns.GlueSlimeSS(), SplatTopSS, SplatMiddleSS, SplatBottomSS, VacColorSS, ChangeFaceBool, noFaceOrNewFace);
                if (SRModLoader.IsModPresent("secretstylethings"))
                {
                    Sprite GPICON = CreateSprite(LoadImage("Assets.glue_slime_plort.png"));
                    SecretStyleFunctionsSST.SSTDoTheThing(ModdedIds.glueIds.GLUE_PLORT, GPICON); //for plort
                }
            }*/
        }
        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {
            //-- POST LOAD --\\
        }

    }
}