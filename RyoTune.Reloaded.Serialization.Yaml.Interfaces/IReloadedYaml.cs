namespace RyoTune.Reloaded.Serialization.Yaml.Interfaces;

public interface IReloadedYaml
{
    IYamlDeserializer CreateDeserializer();
    
    IYamlDeserializer CreateDeserializer(DeserializerConfig config);
    
    IYamlSerializer CreateSerializer();
    
    IYamlSerializer CreateSerializer(SerializerConfig config);
}

public class DeserializerConfig
{
    public static readonly DeserializerConfig Default = new();
    
    public bool IgnoreFields { get; init; }
    
    public bool IgnoreUnmatchedProperties { get; init; }

    public NamingConvention NamingConvention { get; init; } = NamingConvention.Underscored;
}

public class SerializerConfig
{
    public static readonly SerializerConfig Default = new();
    
    public bool IgnoreFields { get; init; }

    public NamingConvention NamingConvention { get; init; } = NamingConvention.Underscored;
    
    public DefaultValuesHandling DefaultValuesHandling { get; init; }

    public bool WithIndentedSequences { get; set; } = true;

    public bool DisableAliases { get; init; } = true;
}

[Flags]
public enum DefaultValuesHandling
{
    Preserve             = 0,
    OmitNull             = 1 << 0, // 1
    OmitDefaults         = 1 << 1, // 2
    OmitEmptyCollections = 1 << 2, // 4
}

public enum NamingConvention
{
    CamelCase,
    Hyphenated,
    LowerCase,
    Null,
    PascalCase,
    Underscored,
}

public interface IYamlDeserializer
{
    T Deserialize<T>(string input);
    T Deserialize<T>(TextReader input);
    
    object? Deserialize(string input);
    object? Deserialize(TextReader input);
    object? Deserialize(string input, Type type);
    object? Deserialize(TextReader input, Type type);
}

public interface IYamlSerializer
{
    string Serialize(object? graph);
    string Serialize(object? graph, Type type);
    void Serialize(TextWriter writer, object? graph);
    void Serialize(TextWriter writer, object? graph, Type type);
}
