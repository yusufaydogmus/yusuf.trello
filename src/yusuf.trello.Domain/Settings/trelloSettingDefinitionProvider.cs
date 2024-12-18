using Volo.Abp.Settings;

namespace yusuf.trello.Settings;

public class trelloSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(trelloSettings.MySetting1));
    }
}
