using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace yusuf.trello.Blazor;

[Dependency(ReplaceServices = true)]
public class trelloBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "trello";
}
