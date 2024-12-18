using System;
using System.Collections.Generic;
using System.Text;
using yusuf.trello.Localization;
using Volo.Abp.Application.Services;

namespace yusuf.trello;

/* Inherit your application services from this class.
 */
public abstract class trelloAppService : ApplicationService
{
    protected trelloAppService()
    {
        LocalizationResource = typeof(trelloResource);
    }
}
