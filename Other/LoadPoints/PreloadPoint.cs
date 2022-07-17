using MonomiPark.SlimeRancher.Regions;
using SRML.SR;
using SRML.SR.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PreloadPoint
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
    static public void PreLoadTranslations()
    {
        //-- PRE LOAD --\\

        // OTHER STUFF
        TranslationPatcher.AddUITranslation("m.foodgroup.plorts", "Plorts");
        // TranslationPatcher.AddUITranslation("m.foodgroup.fresh_water", "Fresh Water");
        TranslationPatcher.AddUITranslation("m.foodgroup.nontarrgold_slimes", "Slimes");

        // ITEMS
        TranslationPatcher.AddActorTranslation("l." + itemIds.MATERIAL_SQUEEZE_CRAFT.ToString().ToLower(), "Material Squeeze");

        TranslationPatcher.AddActorTranslation("l." + itemIds.FERTILIZER_CRAFT.ToString().ToLower(), "Fertilizer");

        TranslationPatcher.AddActorTranslation("l." + itemIds.ANONYMOUS_COMPOUND_CRAFT.ToString().ToLower(), "Anonymous Compound");

        TranslationPatcher.AddActorTranslation("l." + itemIds.SPIRITUAL_MATERIAL_CRAFT.ToString().ToLower(), "Spiritual Material");

        // FRAGMENTS

        // START SLIMEPEDIA ENTRY: FRAGMENT SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, otherIds.FRAGMENT_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(otherIds.FRAGMENT_ENTRY, otherIds.FRAGMENT_SLIME);
        PediaRegistry.SetPediaCategory(otherIds.FRAGMENT_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(otherIds.FRAGMENT_ENTRY)
            .SetTitleTranslation("(Fragment(?)) Slime")
            .SetIntroTranslation("(['COULD NOT LOAD PEDIA ENTRY: ??? SLIME INTRO'])")
            .SetDietTranslation("(['COULD NOT LOAD PEDIA ENTRY: ??? SLIME DIET'])")
            .SetFavoriteTranslation("(['COULD NOT LOAD PEDIA ENTRY: ??? SLIME FAVORITES'])")
            .SetSlimeologyTranslation("(['COULD NOT LOAD PEDI-]) ... What happen to your slime? Oh.. it ate a dangerous plort. Those plorts will turn slimes into fragments of themselves, usually taking the form of a puddle slime and looking like a gray puddle. They will eventually disappear due to agitation, or you can burn them in an incinerator.. wichever works for you. Tarrs also love the fragments of slimes, this could cause larger tarr outbreaks if a lot are around a Tarr. They also will eat almost everything, producing more dangerous plorts.. its best you separate them from food and other slimes.")
            .SetRisksTranslation("(['COULD NOT LOAD PEDIA ENTRY: ??? SLIME RISKES'])")
            .SetPlortonomicsTranslation("(['COULD NOT LOAD PEDIA ENTRY: ??? SLIME PLORTS'])");
        // END SLIMEPEDIA ENTRY: FRAGMENT SLIME

        // DANGEROUS PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + otherIds.DANGEROUS_PLORT.ToString().ToLower(), "Dangerous Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, otherIds.DANGEROUS_PLORT);
        Identifiable.PLORT_CLASS.Add(otherIds.DANGEROUS_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(otherIds.DANGEROUS_PLORT);

        /* START SLIMEPEDIA ENTRY: TEMPLATE SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, SLIME_ID_HERE);
        PediaRegistry.RegisterIdentifiableMapping(ENTRY_ID_HERE, SLIME_ID_HERE);
        PediaRegistry.SetPediaCategory(ENTRY_ID_HERE, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ENTRY_ID_HERE)
            .SetTitleTranslation("Template Title")
            .SetIntroTranslation("Template Intro (when you grab the slime)")
            .SetDietTranslation("Diet here")
            .SetFavoriteTranslation("Favorite here")
            .SetSlimeologyTranslation("Pretty much description of slime here")
            .SetRisksTranslation("Risk here")
            .SetPlortonomicsTranslation("Plort description here? Idk.");
        // END SLIMEPEDIA ENTRY: TEMPLATE SLIME*/


        // || SLIMEPEDIAS/PLORTS/ETC || \\


        //---------- GLUE (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: GLUE SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.glueIds.GLUE_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.glueIds.GLUE_ENTRY, ModdedIds.glueIds.GLUE_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.glueIds.GLUE_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.glueIds.GLUE_ENTRY)
            .SetTitleTranslation("Glue Slime")
            .SetIntroTranslation("Gooey, Hungry, Vegetarian Slime?")
            .SetDietTranslation("Veggies, (Sometimes Pink Slimes/Plorts)")
            .SetFavoriteTranslation("Heart Beet, Material Squeeze")
            .SetSlimeologyTranslation("Glue Slimes are your gooey little friends! They're made out of glue entirely, along with some slimey substance. They do get hungry to the point they may or may not eat something they shouldn't. Tarrs also dislike their gluey taste and will not eat them.")
            .SetRisksTranslation("There are no dangerous risk! Glue Slimes are usually friendly, but.. if they have no other food source, they may result to eating Pink Slimes. They're common so its easy for them to gobble on with no veggies around, so keep them away from your pink slimes if you must!")
            .SetPlortonomicsTranslation("Their plorts are made out of glue as well, great for gluing things together.. that's for sure!");
        // END SLIMEPEDIA ENTRY: GLUE SLIME

        // GLUE PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.glueIds.GLUE_PLORT.ToString().ToLower(), "Glue Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.glueIds.GLUE_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.glueIds.GLUE_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.glueIds.GLUE_PLORT);


        //---------- PLASTIC (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: PLASTIC SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.plasticIds.PLASTIC_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.plasticIds.PLASTIC_ENTRY, ModdedIds.plasticIds.PLASTIC_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.plasticIds.PLASTIC_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.plasticIds.PLASTIC_ENTRY)
            .SetTitleTranslation("Plastic Slime")
            .SetIntroTranslation("Sneaky little slimes, aren't they?")
            .SetDietTranslation("Fruits, (Sometimes Meat)")
            .SetFavoriteTranslation("Cuberry, Mint Mango, Material Squeeze")
            .SetSlimeologyTranslation("Ah, The Plastic Slimes. Plastic Slimes are a little sneaky, but also fun. These slimes will turn invisible sometimes, and become visible again! Its not that hard to notice they're there, but watch out.. you may bump into one. Tarrs also dislike their plastic taste and will not eat them.")
            .SetRisksTranslation("Plastic Slimes have no dangerous risk! If you care for your Glue Plorts though, they'll eat them sometimes as additional food. They seem to enjoy its gooey/gluey taste..")
            .SetPlortonomicsTranslation("The Plastic Plorts are made out of plastic. Plastic Plorts have many uses on Earth which gives them PLENTY of value, if you're interested in investing in Plastic Plorts, better start wrangling some Plastic Slimes!");
        // END SLIMEPEDIA ENTRY: PLASTIC SLIME

        // PLASTIC PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.plasticIds.PLASTIC_PLORT.ToString().ToLower(), "Plastic Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.plasticIds.PLASTIC_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.plasticIds.PLASTIC_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.plasticIds.PLASTIC_PLORT);


        //---------- GLASS (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: GLASS SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.glassIds.GLASS_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.glassIds.GLASS_ENTRY, ModdedIds.glassIds.GLASS_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.glassIds.GLASS_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.glassIds.GLASS_ENTRY)
            .SetTitleTranslation("Glass Slime")
            .SetIntroTranslation("Oh its so- clear..?")
            .SetDietTranslation("Meat, (Sometimes Veggies)")
            .SetFavoriteTranslation("Stony Hen, Material Squeeze")
            .SetSlimeologyTranslation("Glass Slimes? Well, these slimes are pretty friendly. They eat meat, sometimes veggies. Every few moments they might also start hovering, pretty cool, huh? Not much to say about glass slimes. Tarrs also dislike their.. glassy taste(?) and will not eat them.")
            .SetRisksTranslation("This slime provides no dangerous risk, keep them away from your coops!")
            .SetPlortonomicsTranslation("Glass Slimes produce Glass Plorts which are used often in experiments, on earth, etc. Although, their value is about the same as the Glue Slime and not popular demand as its materials could be re-created.");
        // END SLIMEPEDIA ENTRY: GLASS SLIME

        // GLASS PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.glassIds.GLASS_PLORT.ToString().ToLower(), "Glass Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.glassIds.GLASS_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.glassIds.GLASS_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.glassIds.GLASS_PLORT);

        //---------- METAL (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\

        // START SLIMEPEDIA ENTRY: METAL SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.metalIds.METAL_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.metalIds.METAL_ENTRY, ModdedIds.metalIds.METAL_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.metalIds.METAL_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.metalIds.METAL_ENTRY)
            .SetTitleTranslation("Metal Slime")
            .SetIntroTranslation("Pure Metal. Pure Heart. Pure Cuteness.")
            .SetDietTranslation("Veggies, Meat, (Sometimes Rock Slimes)")
            .SetFavoriteTranslation("Material Squeeze")
            .SetSlimeologyTranslation("Aww.. Metal Slimes are cute, aren't they? Although, they were first tarr look-alikes at one point then morphed into this cute little slime, pretty cool fact, right? Sometimes if there is no other food source.. they'll result to eating their own Metal Plorts or a Rock Slime. Tarrs also dislike their metal taste and will not eat them.")
            .SetRisksTranslation("Metal Slimes have no Rancher risks! The only possible risk is a shortage in Rock Slimes or Metal Plorts (Although they'd just produce another). Make sure to collect your Metal Plorts and keep them away from Rock Slimes if you wanna keep em!")
            .SetPlortonomicsTranslation("Metal Plorts have a GOOD amount of value. Used for making weapons, equipment, etc.. all the possibilities. So if you want to invest in Metal Plorts, better treat your Metal Slimes right! They're also too heavy for the vacpack to vaccuum so you can only pick them up one by one.");
        // END SLIMEPEDIA ENTRY: METAL SLIME

        // METAL PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.metalIds.METAL_PLORT.ToString().ToLower(), "Metal Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.metalIds.METAL_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.metalIds.METAL_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.metalIds.METAL_PLORT);


        //---------- WOOD (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: WOOD SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.woodIds.WOOD_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.woodIds.WOOD_ENTRY, ModdedIds.woodIds.WOOD_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.woodIds.WOOD_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.woodIds.WOOD_ENTRY)
            .SetTitleTranslation("Wood Slime")
            .SetIntroTranslation("Wood? Wood. Very much Wood.")
            .SetDietTranslation("Veggies, Fruit, Meat")
            .SetFavoriteTranslation("Material Squeeze")
            .SetSlimeologyTranslation("Wood Slimes are pretty normal. They eat, they jump around, they do anything a normal slime would. Best friends for life! Tarrs also dislike their wooden taste and will not eat them.")
            .SetRisksTranslation("Wood slimes are as safe as possible.")
            .SetPlortonomicsTranslation("Wood Plorts aren't worth much, there is trees everywhere around.. literally get wood from anywhere. Who cares though? They still came from one of the cutest slimes possible.. right?");
        // END SLIMEPEDIA ENTRY: WOOD SLIME

        // WOOD PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.woodIds.WOOD_PLORT.ToString().ToLower(), "Wood Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.woodIds.WOOD_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.woodIds.WOOD_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.woodIds.WOOD_PLORT);


        //---------- CONCRETE (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: CONCRETE SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.concreteIds.CONCRETE_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.concreteIds.CONCRETE_ENTRY, ModdedIds.concreteIds.CONCRETE_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.concreteIds.CONCRETE_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.concreteIds.CONCRETE_ENTRY)
            .SetTitleTranslation("Concrete Slime")
            .SetIntroTranslation("Their heavy.. so are their plorts.")
            .SetDietTranslation("Fresh Water, Rock Plorts")
            .SetFavoriteTranslation("Material Squeeze")
            .SetSlimeologyTranslation("Ah, Concrete Slimes. These slimes are indeed heavy, they'll barely move besides when they wanna eat! They munch on Fresh Water (This will not produce plorts.), Puddle Plorts or Rock Plorts, only these 2 things though.. otherwise, they'll probably starve. Tarrs cannot eat Concrete Slimes, who eats concrete? Concrete Slimes will also not run away from them.")
            .SetRisksTranslation("Concrete Slimes are safe, but make sure to keep some water on you (Which may not do much) or at least some puddle plorts/rock plorts.")
            .SetPlortonomicsTranslation("Concrete Plorts are made out of concrete which gives them plenty of usages, especially on earth. This makes them a good amount of value and possibly almost the same as the Plastic Slimes. They're also too heavy for the vacpack to vaccuum so you can only pick them up one by one. Due to this, you may or may not want to have their corrals next to the Plort Market.. or get ready for a lot of walking/running around!");
        // END SLIMEPEDIA ENTRY: CONCRETE SLIME

        // CONCRETE PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.concreteIds.CONCRETE_PLORT.ToString().ToLower(), "Concrete Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.concreteIds.CONCRETE_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.concreteIds.CONCRETE_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.concreteIds.CONCRETE_PLORT);


        //---------- COTTON (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: COTTON SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.cottonIds.COTTON_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.cottonIds.COTTON_ENTRY, ModdedIds.cottonIds.COTTON_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.cottonIds.COTTON_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.cottonIds.COTTON_ENTRY)
            .SetTitleTranslation("Cotton Slime")
            .SetIntroTranslation("So light.. its floating away!")
            .SetDietTranslation("Veggies")
            .SetFavoriteTranslation("Material Squeeze")
            .SetSlimeologyTranslation("Oh- This one floats! Cotton Slimes are almost 80% Cotton Material & 20% Slimey Substance. This makes the slime easily able to float away, so make sure to have air nets on your corrals. If not.. you may have to quickly try to catch it before it floats away, never to be seen again. Tarrs don't eat cotton, why would they eat cotton?")
            .SetRisksTranslation("Cotton Slimes are completely safe! Just make sure to watch out before it floats away.")
            .SetPlortonomicsTranslation("These Cotton Plorts they produce are at a good amount of value. Cotton is used for plenty of things, which makes them a very good resource for Slimes to just produce. Cotton Slimes are also not too hard to handle, so you should be able to have a whole lot of Cotton Plorts in no time!");
        // END SLIMEPEDIA ENTRY: COTTON SLIME

        // COTTON PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.cottonIds.COTTON_PLORT.ToString().ToLower(), "Cotton Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.cottonIds.COTTON_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.cottonIds.COTTON_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.cottonIds.COTTON_PLORT);


        //---------- COPPER (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: COPPER SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.copperIds.COPPER_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.copperIds.COPPER_ENTRY, ModdedIds.copperIds.COPPER_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.copperIds.COPPER_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.copperIds.COPPER_ENTRY)
            .SetTitleTranslation("Copper Slime")
            .SetIntroTranslation("How shiny and brown..?")
            .SetDietTranslation("Veggies, Meat")
            .SetFavoriteTranslation("Gilded Ginger, Elder Roostro, Material Squeeze")
            .SetSlimeologyTranslation("What a normal slime, right? Oh wait.. did it just.. it did. It teleported to a nearby area- Now that seems fun, doesn't it? Although, it may not be good if it teleports away from you. Why would Tarrs eat copper? No.")
            .SetRisksTranslation("If you don't want to risk it teleporting away, try putting it in a corral.. I think they'd stay inside, possibly.")
            .SetPlortonomicsTranslation("Copper.. Plorts, oh the uses of this plort. Its a shortcut to getting Copper way easier then it is on Earth, which gives them a good amount of value.. but not the best.");
        // END SLIMEPEDIA ENTRY: COPPER SLIME

        // COPPER PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.copperIds.COPPER_PLORT.ToString().ToLower(), "Copper Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.copperIds.COPPER_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.copperIds.COPPER_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.copperIds.COPPER_PLORT);


        //---------- ICE (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: ICE SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.iceIds.ICE_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.iceIds.ICE_ENTRY, ModdedIds.iceIds.ICE_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.iceIds.ICE_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.iceIds.ICE_ENTRY)
            .SetTitleTranslation("Ice Slime")
            .SetIntroTranslation("Be careful, its fragile!")
            .SetDietTranslation("Puddle Plorts, Puddle Slimes, Oca Oca")
            .SetFavoriteTranslation("Material Squeeze")
            .SetSlimeologyTranslation("It looks as if its about to crack! Ice Slimes need water-based items to live, it took forever for scientist to find something that it would eat that wasn't exactly water-based. They're pretty slippery as well- Don't expect them not to be slipping away! Ice slimes are apparently too cold for Tarrs to eat.")
            .SetRisksTranslation("..They're cold.")
            .SetPlortonomicsTranslation("Ice plorts are pretty rare due to that they don't melt after hours and hours of sitting out. Imagine how long your drink could stay cold for! Oh how magical.");
        // END SLIMEPEDIA ENTRY: ICE SLIME

        // ICE PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.iceIds.ICE_PLORT.ToString().ToLower(), "Ice Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.iceIds.ICE_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.iceIds.ICE_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.iceIds.ICE_PLORT);


        //---------- SOIL (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: SOIL SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.soilIds.SOIL_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.soilIds.SOIL_ENTRY, ModdedIds.soilIds.SOIL_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.soilIds.SOIL_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.soilIds.SOIL_ENTRY)
            .SetTitleTranslation("Soil Slime")
            .SetIntroTranslation("Who knew dirt could be so cute.")
            .SetDietTranslation("Everything")
            .SetFavoriteTranslation("Slime Fossils, Material Squeeze")
            .SetSlimeologyTranslation("Grass, Soil, they're all the same right? Oh wait.. they actually are! This is the Soil Slime, so friendly and cute. Not anything too special about it, besides its completely other form! When they consume deep brine, they grow into a beautiful Grass Slime! Eating a soil plort will revert it back to its original form, how interesting! Tarrs will not eat dirt.")
            .SetRisksTranslation("Soil Slimes have no risk, but if you don't want it to revert back keep the soil plorts away from its grass form!")
            .SetPlortonomicsTranslation("Soil Plorts don't have much value, its just dirt combined into diamond-shaped casing. Although its very good for your farms, it makes your food grow within only a few hours! These slimes may also produce a second plort, the Rock Plort.. or well the ACTUAL Rock plort. They have a little more value, but are interesting to look at!");
        // END SLIMEPEDIA ENTRY: SOIL SLIME

        // SOIL PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.soilIds.SOIL_PLORT.ToString().ToLower(), "Soil Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.soilIds.SOIL_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.soilIds.SOIL_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.soilIds.SOIL_PLORT);

        // ACTUAL ROCK PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.soilIds.ACTUAL_ROCK_PLORT.ToString().ToLower(), "Actual Rock Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.soilIds.ACTUAL_ROCK_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.soilIds.ACTUAL_ROCK_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.soilIds.ACTUAL_ROCK_PLORT);


        //---------- GRASS (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: GRASS SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.grassIds.GRASS_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.grassIds.GRASS_ENTRY, ModdedIds.grassIds.GRASS_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.grassIds.GRASS_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.grassIds.GRASS_ENTRY)
            .SetTitleTranslation("Grass Slime")
            .SetIntroTranslation("Grow.. Grow.. Wait- YOU GREW A BIT TOO MUCH- But its cute.")
            .SetDietTranslation("Veggies, Fruits")
            .SetFavoriteTranslation("Deep Brine, Material Squeeze")
            .SetSlimeologyTranslation("Seems your Soil Slime has.. emerged(?) or.. transformed.. I don't have the words. Its became a Grass Slime! It must've loved that deep brine so much it grew, how fun. Soil Slimes & Grass Slimes are pretty much the same slime, but one of them is.. forest greenish? Forget about that. These slimes have nothing too special about them besides being cute, also boost up the mood of soil slimes to jump around! Tarrs will not eat grass.")
            .SetRisksTranslation("Grass Slimes have no risk, clearly you've unlocked Soil Slimes Pedia by now, so please read that on them eating soil plorts.. well that is if you don't want it to revert back.")
            .SetPlortonomicsTranslation("Grass Plorts have a good amount of value if you ask me, mainly because grass that are provided/applied with materials from these plorts.. automatically kill weeds! No more manual work, they'll do it for you. Grass Slimes also randomly produce Plant Plorts, these plorts have even more value because of how they take care of themselves, helping the grass grow along with it! This is if you provide/apply them to your garden though..");
        // END SLIMEPEDIA ENTRY: GRASS SLIME

        // GRASS PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.grassIds.GRASS_PLORT.ToString().ToLower(), "Grass Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.grassIds.GRASS_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.grassIds.GRASS_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.grassIds.GRASS_PLORT);

        // PLANT PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.grassIds.PLANT_PLORT.ToString().ToLower(), "Plant Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.grassIds.PLANT_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.grassIds.PLANT_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.grassIds.PLANT_PLORT);


        // || PRETTY RARE SLIMEPEDIAS/PLORTS/ETC || \\


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

        // START SLIMEPEDIA ENTRY: UNCIVILIZED LIGHT SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.lightIds.UNCIVILIZED_LIGHT_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.lightIds.UNCIVILIZED_LIGHT_ENTRY, ModdedIds.lightIds.UNCIVILIZED_LIGHT_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.lightIds.UNCIVILIZED_LIGHT_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.lightIds.UNCIVILIZED_LIGHT_ENTRY)
            .SetTitleTranslation("Uncivilized Light Slime")
            .SetIntroTranslation("That's.. not quite right.")
            .SetDietTranslation("Slimes")
            .SetFavoriteTranslation("(none)")
            .SetSlimeologyTranslation("This Light Slime isn't exactly normal.. seems its behavior has reversed into Dark Slime Behavior? That's very.. odd. This could be possibly achieved if fed a special substance, but you didn't do that.. right? These Light Slimes are sided with tarrs, so they will not eat them.")
            .SetRisksTranslation("These Light Slimes are NOT safe, you must get rid of them as soon as possible! Seems they.. eat slimes, and create duplicants of themself, endless hunger.")
            .SetPlortonomicsTranslation("They have no plorts, they produce duplicants of themself.");
        // END SLIMEPEDIA ENTRY: UNCIVILIZED LIGHT SLIME


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
            .SetSlimeologyTranslation("You saw this slime? You may or may not want to get rid of it. They are produced by Self Discovery Slimes.. but its as if its a miniature Tarr Slime, they eat other slimes which produce more Dark Slimes (But only when they're hungry). The Light & Dark Slime will indeed try to eat eachother if ever needed, better off not pairing them together. Tarrs value the Dark Slimes hard work and will not eat them by any means. They also will not eat Material Slime Largos.. they don't have the same taste.")
            .SetRisksTranslation("Dark Slimes have the risk of loosing slimes, they will eat them when they're hungry and only them. They will not harm Ranchers, but it would be bad if you lost all your slimes. They will also not eat Self Discovery Slimes as those slimes created them, but will eat any other slime.")
            .SetPlortonomicsTranslation("There is no such thing as a 'Dark Plort' or any type of plort that this slime produces, it will produce other Dark Slimes.");
        // END SLIMEPEDIA ENTRY: DARK SLIME

        // START SLIMEPEDIA ENTRY: CIVILIZED DARK SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.darkIds.CIVILIZED_DARK_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.darkIds.CIVILIZED_DARK_ENTRY, ModdedIds.darkIds.CIVILIZED_DARK_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.darkIds.CIVILIZED_DARK_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.darkIds.CIVILIZED_DARK_ENTRY)
            .SetTitleTranslation("Civilized Dark Slime")
            .SetIntroTranslation("That's.. not quite right.")
            .SetDietTranslation("Plorts")
            .SetFavoriteTranslation("(none)")
            .SetSlimeologyTranslation("Oh- This Dark Slime has really.. had a turn on itself. LITERALLY- Seems its behavior has been swapped with the Light Slime.. how nice it is now. Much more ranchable indeed.. but what could have caused this? They weren't fed any unusual substances.. right? Tarrs are paranoid Civilized Slimes will start duplicating against them, so they will not eat them.")
            .SetRisksTranslation("Surprisingly.. they have no risk. Maybe keep them away from Uncivilized Light Slimes, Dark Slimes, etc though.")
            .SetPlortonomicsTranslation("Right after it didn't exist, 'Civilized Dark Plorts' now exist. These plorts have a good amount of value, especially when this is a rare thing to happen to a Dark Slime. These plorts help calm the uncivilized needs of people.");
        // END SLIMEPEDIA ENTRY: CIVILIZED DARK SLIME

        // CIVILIZED DARK PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.darkIds.CIVILIZED_DARK_PLORT.ToString().ToLower(), "Civilized Dark Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.darkIds.CIVILIZED_DARK_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.darkIds.CIVILIZED_DARK_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.darkIds.CIVILIZED_DARK_PLORT);

        //---------- NEWBUCK (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: NEWBUCK SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.newbuckIds.NEWBUCK_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.newbuckIds.NEWBUCK_ENTRY, ModdedIds.newbuckIds.NEWBUCK_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.newbuckIds.NEWBUCK_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.newbuckIds.NEWBUCK_ENTRY)
            .SetTitleTranslation("Newbuck Slime")
            .SetIntroTranslation("Ever met a slime that can make you richer then a gold slime?")
            .SetDietTranslation("Slimes (Not Material Slimes)")
            .SetFavoriteTranslation("Gold Slime, Lucky Slime (If possible)")
            .SetSlimeologyTranslation("Seems you've met a newbuck slime! Mixed in with old newbucks & slime.. it creates Newbuck Plorts! These plorts can really make you rich within a few days, isn't that great? Why would Tarrs eat money?")
            .SetRisksTranslation("Newbuck Slime has no risks, they dislike being vacced.")
            .SetPlortonomicsTranslation("Newbuck Plorts have an amazing amount of value! Usually worth over 100 newbucks. Its like exchanging a slime for money without the plort market.. but kinda with the plort market? Its confusing, but amazing! It also produces 3 types of its plort, regular, rich, richer. All of these go higher in values by order, some are rare to get so make sure to keep an eye out for one!");
        // END SLIMEPEDIA ENTRY: NEWBUCK SLIME

        // NEWBUCK PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.newbuckIds.NEWBUCK_PLORT.ToString().ToLower(), "Newbuck Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.newbuckIds.NEWBUCK_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.newbuckIds.NEWBUCK_PLORT);

        // RICH NEWBUCK PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT.ToString().ToLower(), "Rich Newbuck Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.newbuckIds.RICH_NEWBUCK_PLORT);

        // RICHER NEWBUCK PLORT TRANSLATION
        TranslationPatcher.AddActorTranslation("l." + ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT.ToString().ToLower(), "Richer Newbuck Plort");
        PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);
        Identifiable.PLORT_CLASS.Add(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);
        Identifiable.NON_SLIMES_CLASS.Add(ModdedIds.newbuckIds.RICHER_NEWBUCK_PLORT);


        //---------- PROVIDER (SLIMEPEDIA, TRANSLATION, ETC) ---------- \\


        // START SLIMEPEDIA ENTRY: PROVIDER SLIME
        PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, ModdedIds.providerIds.PROVIDER_SLIME);
        PediaRegistry.RegisterIdentifiableMapping(ModdedIds.providerIds.PROVIDER_ENTRY, ModdedIds.providerIds.PROVIDER_SLIME);
        PediaRegistry.SetPediaCategory(ModdedIds.providerIds.PROVIDER_ENTRY, (PediaRegistry.PediaCategory)1);
        new SlimePediaEntryTranslation(ModdedIds.providerIds.PROVIDER_ENTRY)
            .SetTitleTranslation("Provider Slime")
            .SetIntroTranslation("Mangos, Kookadobas, Carrots, Ginger? ..Everywhere!")
            .SetDietTranslation("Plorts")
            .SetFavoriteTranslation("(none)")
            .SetSlimeologyTranslation("All Hail The Provider Slimes! These slimes that feed other slimes for their plorts, how amazing. Plort goes in, Food comes out. This slime can produce Ginger, Kookadobas, Carrots, Pogofruit, anything imaginable! If you run into one of these, its best you ranch them and collect the food they produce! It could be very useful. They also produce a few special items that can be provided by Material Extractors, like Fertilizer or Material Squeeze! These slimes however are tasteful by Tarrs and will disappear if agitated.")
            .SetRisksTranslation("Provider Slimes have no risk, just keep them fed so they won't disappear.")
            .SetPlortonomicsTranslation("These slimes do not produce plorts, only foods.");
        // END SLIMEPEDIA ENTRY: PROVIDER SLIME

        return;
    }

    static public void PreloadSpawners()
    {

        // || SPAWNERS || \\

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
                                weight = 0.012f // The higher the value is the more often your slime will spawn (1.2%)
                            }
                        };
                    constraint.slimeset.members = members.ToArray();
                }
            }
        });
        // END ICE SLIME SPAWNER

        // START SOIL SLIME SPAWNER
        SRCallbacks.PreSaveGameLoad += (s =>
        {
            foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                .Where(ss =>
                {
                    ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                    return zone == ZoneDirector.Zone.WILDS || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.NONE;
                }))
            {
                foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                {
                    List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.soilIds.SOIL_SLIME),
                                weight = 0.2f // The higher the value is the more often your slime will spawn (1.2%)
                            }
                        };
                    constraint.slimeset.members = members.ToArray();
                }
            }
        });
        // END SOIL SLIME SPAWNER


        // || PRETTY RARE SPAWNERS || \\


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
                                weight = 0.002f // The higher the value is the more often your slime will spawn
                            }
                        };
                    constraint.slimeset.members = members.ToArray();
                }
            }
        });
        // END SELF DISCOVERY SLIME SPAWNER

        // START NEWBUCK SLIME SPAWNER
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
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.newbuckIds.NEWBUCK_SLIME),
                                weight = 0.002f // The higher the value is the more often your slime will spawn
                            }
                        };
                    constraint.slimeset.members = members.ToArray();
                }
            }
        });
        // END NEWBUCK SLIME SPAWNER

        // START PROVIDER SLIME SPAWNER
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
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(ModdedIds.providerIds.PROVIDER_SLIME),
                                weight = 0.05f // The higher the value is the more often your slime will spawn
                            }
                        };
                    constraint.slimeset.members = members.ToArray();
                }
            }
        });
        // END PROVIDER SLIME SPAWNER

        return;
    }

    static public void PreloadOtherPedias()
    {
        // SLIME SCIENCE RESOURCE SLIMEPEDIAS

        // --- MATERIAL SQUEEZE

        // START SLIMEPEDIA ENTRY: MATERIAL SQUEEZE
        PediaRegistry.RegisterIdentifiableMapping(itemIds.MATERIAL_SQUEEZE_ENTRY, itemIds.MATERIAL_SQUEEZE_CRAFT);
        PediaRegistry.RegisterIdEntry(itemIds.MATERIAL_SQUEEZE_ENTRY, CreateSprite(LoadImage("Assets.Items.MaterialSqueeze.squeeze_icon.png")));
        PediaRegistry.SetPediaCategory(itemIds.MATERIAL_SQUEEZE_ENTRY, (PediaRegistry.PediaCategory)2);
        new SlimePediaEntryTranslation(itemIds.MATERIAL_SQUEEZE_ENTRY).SetTitleTranslation("Material Squeeze").SetIntroTranslation("Some people say its squeezed from material slimes..?");
        TranslationPatcher.AddPediaTranslation("m.resource_type.material_squeeze_entry", "Slime Science Material, Provided by Provider Slimes.");
        TranslationPatcher.AddPediaTranslation("m.favored_by.material_squeeze_entry", "All Material Slimes. (Almost)");
        TranslationPatcher.AddPediaTranslation("m.desc.material_squeeze_entry", "Material Squeeze, loved by all Material Slimes! Instant favorite, provided by Provider Slimes & Material Extractors. Some people say it may or may not have been squeezed from material slimes.. is it true?");
        // END SLIMEPEDIA ENTRY: MATERIAL SQUEEZE

        // --- FERTILIZER

        // START SLIMEPEDIA ENTRY: FERTILIZER
        PediaRegistry.RegisterIdentifiableMapping(itemIds.FERTILIZER_ENTRY, itemIds.FERTILIZER_CRAFT);
        PediaRegistry.RegisterIdEntry(itemIds.FERTILIZER_ENTRY, CreateSprite(LoadImage("Assets.Items.Fertilizer.fertilizer_icon.png")));
        PediaRegistry.SetPediaCategory(itemIds.FERTILIZER_ENTRY, (PediaRegistry.PediaCategory)2);
        new SlimePediaEntryTranslation(itemIds.FERTILIZER_ENTRY).SetTitleTranslation("Fertilizer").SetIntroTranslation("Soil Slimes love it- A LOT!");
        TranslationPatcher.AddPediaTranslation("m.resource_type.fertilizer_entry", "Slime Science Material, Provided by Provider Slimes.");
        TranslationPatcher.AddPediaTranslation("m.favored_by.fertilizer_entry", "Soil Slimes");
        TranslationPatcher.AddPediaTranslation("m.desc.fertilizer_entry", "One bottle of this Fertilizer is sure to make that soil grow! They'll grow into a beautiful..? Oh, they become food! They grow into veggies and fruits, not meat though.");
        // END SLIMEPEDIA ENTRY: FERTILIZER

        // --- ANONYMOUS COMPOUND

        // START SLIMEPEDIA ENTRY: ANONYMOUS COMPOUND
        PediaRegistry.RegisterIdentifiableMapping(itemIds.ANONYMOUS_COMPOUND_ENTRY, itemIds.ANONYMOUS_COMPOUND_CRAFT);
        PediaRegistry.RegisterIdEntry(itemIds.ANONYMOUS_COMPOUND_ENTRY, CreateSprite(LoadImage("Assets.Items.AnonymousCompound.compound_icon.png")));
        PediaRegistry.SetPediaCategory(itemIds.ANONYMOUS_COMPOUND_ENTRY, (PediaRegistry.PediaCategory)2);
        new SlimePediaEntryTranslation(itemIds.ANONYMOUS_COMPOUND_ENTRY).SetTitleTranslation("Anonymous Compound").SetIntroTranslation("How.. anonymous.");
        TranslationPatcher.AddPediaTranslation("m.resource_type.anonymous_compound_entry", "Slime Science Material");
        TranslationPatcher.AddPediaTranslation("m.favored_by.anonymous_compound_entry", "Light Slimes & Dark Slimes.");
        TranslationPatcher.AddPediaTranslation("m.desc.anonymous_compound_entry", "This substance is unknown.. its been heard about that when fed to a Light or Dark slime, they start to act the opposite of their own behaviours. Maybe try it out?");
        // END SLIMEPEDIA ENTRY: ANONYMOUS COMPOUND

        // --- SPIRITUAL MATERIAL

        // START SLIMEPEDIA ENTRY: SPIRITUAL MATERIAL
        PediaRegistry.RegisterIdentifiableMapping(itemIds.SPIRITUAL_MATERIAL_ENTRY, itemIds.SPIRITUAL_MATERIAL_CRAFT);
        PediaRegistry.RegisterIdEntry(itemIds.SPIRITUAL_MATERIAL_ENTRY, CreateSprite(LoadImage("Assets.Items.SpiritualMaterial.spiritual_icon.png")));
        PediaRegistry.SetPediaCategory(itemIds.SPIRITUAL_MATERIAL_ENTRY, (PediaRegistry.PediaCategory)2);
        new SlimePediaEntryTranslation(itemIds.SPIRITUAL_MATERIAL_ENTRY).SetTitleTranslation("Spiritual Material").SetIntroTranslation("The spirit/soul of a Material Slime.. how interesting.");
        TranslationPatcher.AddPediaTranslation("m.resource_type.spiritual_material_entry", "Slime Science Material");
        TranslationPatcher.AddPediaTranslation("m.favored_by.spiritual_material_entry", "All slimes.");
        TranslationPatcher.AddPediaTranslation("m.desc.spiritual_material_entry", "A singular bottle, with a spirit of a Material Slime inside. Whatever slime eats this, will become whichever slime is stored inside. Why not set it free?");
        // END SLIMEPEDIA ENTRY: SPIRITUAL MATERIAL

        return;
    }
}
