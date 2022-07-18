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

class SilverShard
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
    static public void LoadSilverShard()
    {
        GameObject silverShard = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.STRANGE_DIAMOND_CRAFT));
        silverShard.GetComponent<Identifiable>().id = itemIds.SILVER_SHARD_CRAFT;
        silverShard.name = "resourceSilverShard";

        Material SilverMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.silverIds.SILVER_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        Material DarkMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.darkIds.DARK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

        silverShard.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = SilverMaterial;

        LookupRegistry.RegisterIdentifiablePrefab(silverShard);
        AmmoRegistry.RegisterSiloAmmo((SiloStorage.StorageType x) => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.CRAFTING, itemIds.SILVER_SHARD_CRAFT);
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.SILVER_SHARD_CRAFT));
        AmmoRegistry.RegisterRefineryResource(itemIds.SILVER_SHARD_CRAFT);
        LookupRegistry.RegisterVacEntry(itemIds.SILVER_SHARD_CRAFT, new Color32(192, 192, 192, 255), CreateSprite(LoadImage("Assets.Items.SilverShard.shard_icon.png")));
        GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.SILVER_SHARD_CRAFT);
        prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
    }
}