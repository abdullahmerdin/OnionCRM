using Microsoft.AspNetCore.Mvc.Razor;

namespace OnionCRM.Infrastructure.MiddleLayers;

public class ViewLocationExpander : IViewLocationExpander
{
    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        return new[] {
            "/Areas/Identity/Pages/{1}/{0}.cshtml",
            "Views/{1}/{0}.cshtml",
            "Views/Shared/_Layout.cshtml"
        };
    }
}