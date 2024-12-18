using yusuf.trello.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace yusuf.trello.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class trelloController : AbpControllerBase
{
    protected trelloController()
    {
        LocalizationResource = typeof(trelloResource);
    }
}
