using Microsoft.AspNetCore.Mvc.Razor;

namespace OnionCRM.Infrastructure.Extensions;

public class ViewLocationExpander : IViewLocationExpander
{
    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }

    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        return new[] {
            "/Areas/Identity/Pages/{1}/{0}.cshtml"
        };
    }
}