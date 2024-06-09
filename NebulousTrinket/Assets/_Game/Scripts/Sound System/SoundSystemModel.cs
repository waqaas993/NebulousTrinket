namespace NebulousTrinket
{
    public class SoundSystemModel
    {
        private SoundConfigs _Configs;
        private ConfigsController _ConfigsController;

        private SoundConfigs Configs => _Configs ?? (_Configs = ConfigsController.GetConfig<SoundConfigs>());
        private ConfigsController ConfigsController => _ConfigsController ?? (_ConfigsController = SingletonController<ConfigsController>.Instance);

        public SoundData GetSoundData(string sound, SoundType soundType) => Configs.GetSoundData(sound, soundType);
    }
}
