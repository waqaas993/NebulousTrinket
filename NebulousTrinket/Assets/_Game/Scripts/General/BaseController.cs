using UnityEngine;

namespace NebulousTrinket
{
    public abstract class BaseController : MonoBehaviour
    {
        public abstract void Initialize(params object[] parameters);
    }
}
