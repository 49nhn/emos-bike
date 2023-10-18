using Volo.Abp.Settings;

namespace Emos.Bike.Settings;

public class BikeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BikeSettings.MySetting1));
    }
}
