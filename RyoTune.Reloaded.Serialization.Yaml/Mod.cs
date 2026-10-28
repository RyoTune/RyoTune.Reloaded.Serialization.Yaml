#if DEBUG
using System.Diagnostics;
#endif
using Reloaded.Mod.Interfaces;
using RyoTune.Reloaded.Serialization.Yaml.Template;

namespace RyoTune.Reloaded.Serialization.Yaml;

public class Mod : ModBase
{
    private readonly IModLoader _modLoader;
    private readonly ILogger _log;
    private readonly IMod _owner;
    private readonly IModConfig _modConfig;

    public Mod(ModContext context)
    {
        _modLoader = context.ModLoader;
        _log = context.Logger;
        _owner = context.Owner;
        _modConfig = context.ModConfig;
    }

    #region For Exports, Serialization etc.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod()
    {
    }
#pragma warning restore CS8618

    #endregion
}