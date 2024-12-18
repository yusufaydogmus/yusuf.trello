using yusuf.trello.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace yusuf.trello.Permissions;

public class trelloPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(trelloPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(trelloPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<trelloResource>(name);
    }
}
