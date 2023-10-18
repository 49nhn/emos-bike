using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Emos.Bike.Localization;
using Emos.Bike.Permissions;
using Volo.Abp.Account.AuthorityDelegation;
using Volo.Abp.Account.Localization;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.LanguageManagement.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TextTemplateManagement.Web.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.OpenIddict.Pro.Web.Menus;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;
using Volo.Saas.Host.Navigation;

namespace Emos.Bike.Web.Menus;

public class BikeMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public BikeMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<BikeResource>();
        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                BikeMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        //Host Dashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                BikeMenus.HostDashboard,
                l["Menu:Dashboard"],
                "~/HostDashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(BikePermissions.Dashboard.Host)
        );

        //Tenant Dashboard
        context.Menu.AddItem(
            new ApplicationMenuItem(
                BikeMenus.TenantDashboard,
                l["Menu:Dashboard"],
                "~/Dashboard",
                icon: "fa fa-line-chart",
                order: 2
            ).RequirePermissions(BikePermissions.Dashboard.Tenant)
        );

        //Saas
        context.Menu.SetSubItemOrder(SaasHostMenuNames.GroupName, 3);


        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        //Administration->Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration->OpenIddict
        administration.SetSubItemOrder(OpenIddictProMenus.GroupName, 2);

        //Administration->Language Management
        administration.SetSubItemOrder(LanguageManagementMenuNames.GroupName, 3);

        //Administration->Text Template Management
        administration.SetSubItemOrder(TextTemplateManagementMainMenuNames.GroupName, 4);

        //Administration->Audit Logs
        administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 5);

        //Administration->Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 6);

        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();
        var authorityDelegationOptions = context.ServiceProvider.GetRequiredService<IOptions<AbpAccountAuthorityDelegationOptions>>().Value;

        var uiResource = context.GetLocalizer<AbpUiResource>();
        var accountResource = context.GetLocalizer<AccountResource>();


        var authServerUrl = _configuration["AuthServer:Authority"] ?? "~";
        var returnUrl = _configuration["App:SelfUrl"] ?? "";

        context.Menu.AddItem(new ApplicationMenuItem("Account.LinkedAccounts", accountResource["LinkedAccounts"], url: "javascript:void(0)", icon: "fa fa-link"));   
        if (currentUser.FindImpersonatorUserId() == null && authorityDelegationOptions.EnableDelegatedImpersonation)
        {
            context.Menu.AddItem(new ApplicationMenuItem("Account.AuthorityDelegation", accountResource["AuthorityDelegation"], url: "javascript:void(0)", icon: "fa fa-users"));
        }
        
        context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"], $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={returnUrl}", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", accountResource["MySecurityLogs"], $"{authServerUrl.EnsureEndsWith('/')}Account/SecurityLogs?returnUrl={returnUrl}", icon: "fa fa-user-shield", target: "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

        return Task.CompletedTask;
    }
}
