using Html2Markdown.Scheme;

namespace Application.Schemes;

public class SchemeService
{
    private static SchemeCollection GetSchemes()
    {
        var schemeCollection = new SchemeCollection();
        var type = typeof(IScheme);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && p is {IsInterface: false, IsAbstract: false})
            .OrderBy(t => t.Name);

        foreach (var scheme in types)
        {
            schemeCollection.Add(scheme);
        }
        
        return schemeCollection;

    }

    public SchemeCollection Schemes { get; } = GetSchemes();
}