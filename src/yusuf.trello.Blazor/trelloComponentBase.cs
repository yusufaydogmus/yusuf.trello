using yusuf.trello.Localization;
using Volo.Abp.AspNetCore.Components;

namespace yusuf.trello.Blazor;

public abstract class trelloComponentBase : AbpComponentBase
{
    protected trelloComponentBase()
    {
        LocalizationResource = typeof(trelloResource);
    }
}
