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

class Fertilizer
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
    static public void LoadFertilizer()
    {
        GameObject fertilizer = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.SILKY_SAND_CRAFT));
        fertilizer.GetComponent<Identifiable>().id = itemIds.FERTILIZER_CRAFT;
        fertilizer.name = "resourceFertilizer";

        Material SoilMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.soilIds.SOIL_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        Material DarkMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.darkIds.DARK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

        fertilizer.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().material = SoilMaterial;
        fertilizer.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = DarkMaterial;

        LookupRegistry.RegisterIdentifiablePrefab(fertilizer);
        AmmoRegistry.RegisterSiloAmmo((SiloStorage.StorageType x) => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.CRAFTING, itemIds.FERTILIZER_CRAFT);
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.FERTILIZER_CRAFT));
        AmmoRegistry.RegisterRefineryResource(itemIds.FERTILIZER_CRAFT);
        LookupRegistry.RegisterVacEntry(itemIds.FERTILIZER_CRAFT, new Color32(124, 94, 66, 255), CreateSprite(LoadImage("Assets.Items.Fertilizer.fertilizer_icon.png")));
        GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.FERTILIZER_CRAFT);
        prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
    }
}