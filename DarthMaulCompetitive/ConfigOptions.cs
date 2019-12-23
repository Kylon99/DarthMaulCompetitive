using BS_Utils.Utilities;

namespace DarthMaulCompetitive
{
    public class ConfigOptions : PersistentSingleton<ConfigOptions>
    {
        private const string PluginName = "DarthMaulCompetitive";

        private const string TwoControllersOption = "TwoController";
        private const string OneHandedOption = "OneController";
        private const string UseLeftControllerOption = "UseLeftController";
        private const string ReverseDirectionOption = "ReverseDirection";
        private const string SeparationAmountOption = "SeparationAmount";

        private Config config;

        private bool twoControllers;
        private bool oneHanded;
        private bool useLeftController;
        private bool reverseDirection;
        private int separationAmount;

        public bool IsTwoControllers { get => twoControllers; set { twoControllers = value; config.SetBool(PluginName, TwoControllersOption, value); } }
        public bool IsOneHanded { get => oneHanded; set { oneHanded = value; config.SetBool(PluginName, OneHandedOption, value); } }
        public bool UseLeftController { get => useLeftController; set { useLeftController = value; config.SetBool(PluginName, UseLeftControllerOption, value); } }
        public bool ReverseDirection { get => reverseDirection; set { reverseDirection = value; config.SetBool(PluginName, ReverseDirectionOption, value); } }
        public int Separation { get => separationAmount; set { separationAmount = value; config.SetInt(PluginName, SeparationAmountOption, value); } }

        /// <summary>
        /// Called before Start or Updates by Unity infrastructure
        /// </summary>
        public void Awake()
        {
            config = new Config(PluginName);
            twoControllers = config.GetBool(PluginName, TwoControllersOption, false, true);
            oneHanded = config.GetBool(PluginName, OneHandedOption, false, true);
            useLeftController = config.GetBool(PluginName, UseLeftControllerOption, false, true);
            reverseDirection = config.GetBool(PluginName, ReverseDirectionOption, false, true);
            separationAmount = config.GetInt(PluginName, SeparationAmountOption, 15, true);
        }
    }
}
