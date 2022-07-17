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

class MaterialSqueeze
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
    static public void LoadMaterialSqueeze()
    {
        GameObject materialSqueeze = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PRIMORDY_OIL_CRAFT));
        materialSqueeze.GetComponent<Identifiable>().id = itemIds.MATERIAL_SQUEEZE_CRAFT;
        materialSqueeze.name = "resourceMaterialSqueeze";

        Material GlueMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.glueIds.GLUE_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        Material DarkMaterial = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(ModdedIds.darkIds.DARK_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);

        materialSqueeze.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().material = GlueMaterial;
        materialSqueeze.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = DarkMaterial;

        LookupRegistry.RegisterIdentifiablePrefab(materialSqueeze);
        AmmoRegistry.RegisterSiloAmmo((SiloStorage.StorageType x) => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.CRAFTING, itemIds.MATERIAL_SQUEEZE_CRAFT);
        AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.MATERIAL_SQUEEZE_CRAFT));
        AmmoRegistry.RegisterRefineryResource(itemIds.MATERIAL_SQUEEZE_CRAFT);
        LookupRegistry.RegisterVacEntry(itemIds.MATERIAL_SQUEEZE_CRAFT, new Color32(255, 254, 247, 255), CreateSprite(LoadImage("Assets.Items.MaterialSqueeze.squeeze_icon.png")));
        GameObject prefab = SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(itemIds.MATERIAL_SQUEEZE_CRAFT);
        prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
    }
}