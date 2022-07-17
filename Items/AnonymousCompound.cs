using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

class AnonymousCompound
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
    static public void LoadAnonymousCompound()
    {
        GameObject anonymousCompound = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.DEEP_BRINE_CRAFT));
        anonymousCompound.GetComponent<Identifiable>().id = itemIds.ANONYMOUS_COMPOUND_CRAFT;
        anonymousCompound.name = "resourceAnonymousCompound";

        Material LightMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.lightIds.LIGHT_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        Material DarkMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.darkIds.DARK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

        anonymousCompound.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().material = LightMaterial;
        anonymousCompound.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = DarkMaterial;

        LookupRegistry.RegisterIdentifiablePrefab(anonymousCompound);
        AmmoRegistry.RegisterSiloAmmo((SiloStorage.StorageType x) => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.CRAFTING, itemIds.ANONYMOUS_COMPOUND_CRAFT);
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.ANONYMOUS_COMPOUND_CRAFT));
        AmmoRegistry.RegisterRefineryResource(itemIds.ANONYMOUS_COMPOUND_CRAFT);
        LookupRegistry.RegisterVacEntry(itemIds.ANONYMOUS_COMPOUND_CRAFT, Color.gray, CreateSprite(LoadImage("Assets.Items.AnonymousCompound.compound_icon.png")));
        GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.ANONYMOUS_COMPOUND_CRAFT);
        prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
    }
}