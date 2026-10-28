using RyoTune.Reloaded.Serialization.Yaml.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace RyoTune.Reloaded.Serialization.Yaml;

public class ReloadedYaml : IReloadedYaml
{
    public IYamlDeserializer CreateDeserializer() => CreateDeserializer(DeserializerConfig.Default);

    public IYamlDeserializer CreateDeserializer(DeserializerConfig config)
    {
        var builder = new DeserializerBuilder();
        
        if (config.IgnoreUnmatchedProperties) builder.IgnoreUnmatchedProperties();
        if (config.IgnoreFields) builder.IgnoreFields();

        switch (config.NamingConvention)
        {
            case NamingConvention.CamelCase:
                builder.WithNamingConvention(CamelCaseNamingConvention.Instance);
                break;
            case NamingConvention.Hyphenated:
                builder.WithNamingConvention(HyphenatedNamingConvention.Instance);
                break;
            case NamingConvention.LowerCase:
                builder.WithNamingConvention(LowerCaseNamingConvention.Instance);
                break;
            case NamingConvention.Null:
                builder.WithNamingConvention(NullNamingConvention.Instance);
                break;
            case NamingConvention.PascalCase:
                builder.WithNamingConvention(PascalCaseNamingConvention.Instance);
                break;
            case NamingConvention.Underscored:
                builder.WithNamingConvention(UnderscoredNamingConvention.Instance);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(config), $"Unknown naming convention '{config.NamingConvention}'.");
        }
        
        return new YamlDeserializer(builder.Build());
    }

    public IYamlSerializer CreateSerializer() => CreateSerializer(SerializerConfig.Default);

    public IYamlSerializer CreateSerializer(SerializerConfig config)
    {
        var builder = new SerializerBuilder();
        
        builder.ConfigureDefaultValuesHandling((YamlDotNet.Serialization.DefaultValuesHandling)config.DefaultValuesHandling);
        if (config.IgnoreFields) builder.IgnoreFields();
        if (config.WithIndentedSequences) builder.WithIndentedSequences();
        if (config.DisableAliases) builder.DisableAliases();

        switch (config.NamingConvention)
        {
            case NamingConvention.CamelCase:
                builder.WithNamingConvention(CamelCaseNamingConvention.Instance);
                break;
            case NamingConvention.Hyphenated:
                builder.WithNamingConvention(HyphenatedNamingConvention.Instance);
                break;
            case NamingConvention.LowerCase:
                builder.WithNamingConvention(LowerCaseNamingConvention.Instance);
                break;
            case NamingConvention.Null:
                builder.WithNamingConvention(NullNamingConvention.Instance);
                break;
            case NamingConvention.PascalCase:
                builder.WithNamingConvention(PascalCaseNamingConvention.Instance);
                break;
            case NamingConvention.Underscored:
                builder.WithNamingConvention(UnderscoredNamingConvention.Instance);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(config), $"Unknown naming convention '{config.NamingConvention}'.");
        }
        
        return new YamlSerializer(builder.Build());       
    }

    private class YamlDeserializer(IDeserializer deserializer) : IYamlDeserializer
    {
        public T Deserialize<T>(string input) => deserializer.Deserialize<T>(input);

        public T Deserialize<T>(TextReader input) => deserializer.Deserialize<T>(input);

        public object? Deserialize(string input) => deserializer.Deserialize(input);

        public object? Deserialize(TextReader input) => deserializer.Deserialize(input);       

        public object? Deserialize(string input, Type type) => deserializer.Deserialize(input, type);

        public object? Deserialize(TextReader input, Type type) => deserializer.Deserialize(input, type);
    }

    private class YamlSerializer(ISerializer serializer) : IYamlSerializer
    {
        public string Serialize(object? graph) => serializer.Serialize(graph);

        public string Serialize(object? graph, Type type) => serializer.Serialize(graph, type);

        public void Serialize(TextWriter writer, object? graph) => serializer.Serialize(writer, graph);

        public void Serialize(TextWriter writer, object? graph, Type type) => serializer.Serialize(writer, graph, type);
    }
}