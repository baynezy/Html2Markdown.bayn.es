using Html2Markdown.Scheme;

namespace Application.Schemes;

public class SchemeCollection
{
    private readonly Dictionary<string,IScheme> _schemeLookUp = new();

    public void Add(Type type)
    {
        var scheme = ConvertToScheme(type);
        Schemes.Add(scheme.Name);
        _schemeLookUp.Add(scheme.Name, scheme.Instance);
    }
    
    public List<string> Schemes { get; } = [];

    public IScheme GetScheme(string schemeName)
    {
        return _schemeLookUp[schemeName];
    }
    
    private static Scheme ConvertToScheme(Type type)
    {
        var schemeName = type.Name;
        var schemeType = (IScheme) Activator.CreateInstance(type)!;
        var scheme = new Scheme(schemeName, schemeType);
        return scheme;
    }
    
    private class Scheme(string schemeName, IScheme schemeType)
    {
        internal string Name { get; } = schemeName;
        internal IScheme Instance { get; } = schemeType;
    }
}