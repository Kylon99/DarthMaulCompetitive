namespace DarthMaulCompetitive
{
    public class DarthMaulCompetitiveUI
    {
        private const string darthMaulCompetitiveIconString = Plugin.assemblyName + ".Resources.DarthMaulCompetitive.png";

        public static void CreateUI()
        {
            //var darthMaulIcon = UIUtilities.LoadSpriteFromResources(darthMaulCompetitiveIconString);

            //var darthMaulMenu = GameplaySettingsUI.CreateSubmenuOption(
            //    GameplaySettingsPanels.ModifiersRight,
            //    "Darth Maul Settings",
            //    "MainMenu",
            //    "DarthMaulMenu1",
            //    "Darth Maul Plugin Options",
            //    darthMaulIcon);

            //var darthMaulToggle = GameplaySettingsUI.CreateToggleOption(
            //    GameplaySettingsPanels.ModifiersRight,
            //    "Two Controller Darth Maul",
            //    "DarthMaulMenu1",
            //    "Enable Darth Maul Mode",
            //    darthMaulIcon);
            //darthMaulToggle.GetValue = ConfigOptions.instance.IsTwoControllers;
            //darthMaulToggle.OnToggle += (value) => { ConfigOptions.instance.IsTwoControllers = value; };

            //var oneHandedToggle = GameplaySettingsUI.CreateToggleOption(
            //    GameplaySettingsPanels.ModifiersRight,
            //    "One Hand Darth Maul",
            //    "DarthMaulMenu1",
            //    "One Handed Darth Maul",
            //    darthMaulIcon);
            //oneHandedToggle.GetValue = ConfigOptions.instance.IsOneHanded;
            //oneHandedToggle.OnToggle += (value) => { ConfigOptions.instance.IsOneHanded = value; };

            //var useTriggerToSeparate = GameplaySettingsUI.CreateToggleOption(
            //    GameplaySettingsPanels.ModifiersRight,
            //    "Use Trigger to Separate",
            //    "DarthMaulMenu1",
            //    "Separate sabers with both trigger presses in 2 controller mode or one trigger in one hand mode.");
            //useTriggerToSeparate.GetValue = ConfigOptions.instance.UseTriggerToSeparate;
            //useTriggerToSeparate.OnToggle += (value) => { ConfigOptions.instance.UseTriggerToSeparate = value; };

            //var leftHandToggle = GameplaySettingsUI.CreateToggleOption(
            //    GameplaySettingsPanels.ModifiersRight,
            //    "Left Main Controller",
            //    "DarthMaulMenu1",
            //    "Whether the left controller is the main controller.");
            //leftHandToggle.GetValue = ConfigOptions.instance.UseLeftController == Plugin.ControllerType.LEFT ? true : false; ;
            //leftHandToggle.OnToggle += (value) => { ConfigOptions.instance.UseLeftController = value == true ? Plugin.ControllerType.LEFT : Plugin.ControllerType.RIGHT; };

            //var reverseDirectionToggle = GameplaySettingsUI.CreateToggleOption(
            //    GameplaySettingsPanels.ModifiersRight,
            //    "Reverse Saber Directions",
            //    "DarthMaulMenu1",
            //    "Reverse the directions of sabers in Darth Maul modes");
            //reverseDirectionToggle.GetValue = ConfigOptions.instance.ReverseDirection;
            //reverseDirectionToggle.OnToggle += (value) => { ConfigOptions.instance.ReverseDirection = value; };
        }
    }
}
