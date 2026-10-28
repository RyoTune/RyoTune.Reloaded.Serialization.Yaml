using Reloaded.Mod.Interfaces;
using RyoTune.Reloaded.Serialization.Yaml.Interfaces;
using RyoTune.Reloaded.Serialization.Yaml.Template;

namespace RyoTune.Reloaded.Serialization.Yaml;

public class Mod : ModBase, IExports
{
    private readonly IModLoader _modLoader;
    private readonly ILogger _log;
    private readonly IMod _owner;
    private readonly IModConfig _modConfig;

    private readonly IReloadedYaml _reloadedYaml;

    public Mod(ModContext context)
    {
        _modLoader = context.ModLoader;
        _log = context.Logger;
        _owner = context.Owner;
        _modConfig = context.ModConfig;
        
        _reloadedYaml = new ReloadedYaml();
        _modLoader.AddOrReplaceController(_owner, _reloadedYaml);
    }

    #region For Exports, Serialization etc.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod()
    {
    }
#pragma warning restore CS8618

    #endregion

    public Type[] GetTypes() => [typeof(IReloadedYaml)];
}