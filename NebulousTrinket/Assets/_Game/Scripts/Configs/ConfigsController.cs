using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace NebulousTrinket
{
    public class ConfigsController : BaseController
    {
        private List<BaseConfigs> BaseConfigs = new();

        public override void Initialize(params object[] parameters)
        {
            BaseConfigs = Resources.LoadAll<BaseConfigs>("Configs").ToList();
        }

        public T GetConfig<T>() where T : BaseConfigs
        {
            foreach (var baseConfig in BaseConfigs)
            {
                if (baseConfig is T)
                {
                    return baseConfig as T;
                }
            }
            return null;
        }
    }
}