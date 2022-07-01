using SRML.Utils.Enum;

namespace ModdedIds
{
    [EnumHolder] //With this, you are indicating SRML that all the `public static readonly` variables are Enums
    internal class glueIds
    {
        public static readonly Identifiable.Id GLUE_SLIME; // Creates a new Identifiable.id with the first free value in Identifiable.Id with the name CUSTOM_IDENTIFIABLE

        public static readonly Identifiable.Id GLUE_PLORT;

        public static readonly PediaDirector.Id GLUE_ENTRY;
    }
    [EnumHolder]
    internal class plasticIds
    {
        public static readonly Identifiable.Id PLASTIC_SLIME;

        public static readonly Identifiable.Id PLASTIC_PLORT;

        public static readonly PediaDirector.Id PLASTIC_ENTRY;
    }
    [EnumHolder]
    internal class glassIds
    {
        public static readonly Identifiable.Id GLASS_SLIME;

        public static readonly Identifiable.Id GLASS_PLORT;

        public static readonly PediaDirector.Id GLASS_ENTRY;
    }
    [EnumHolder]
    internal class metalIds
    {
        public static readonly Identifiable.Id METAL_SLIME;

        public static readonly Identifiable.Id METAL_PLORT;

        public static readonly PediaDirector.Id METAL_ENTRY;
    }
    [EnumHolder]
    internal class woodIds
    {
        public static readonly Identifiable.Id WOOD_SLIME;

        public static readonly Identifiable.Id WOOD_PLORT;

        public static readonly PediaDirector.Id WOOD_ENTRY;
    }
    [EnumHolder]
    internal class discoveryIds
    {
        public static readonly Identifiable.Id DISCOVERY_SLIME;

        public static readonly PediaDirector.Id DISCOVERY_ENTRY;
    }
}