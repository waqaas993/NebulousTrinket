using System;
using UnityEditor;
using UnityEngine;

namespace NebulousTrinket
{
    public class CreateAssetBundles
    {
        [MenuItem("Assets/Create Assets Bundles")]
        private static void BuildAllAssetBundles()
        {
            string assetBundleDirectoryPath = Application.dataPath + "/AssetsBundles";
            Debug.Log(assetBundleDirectoryPath);
            try
            {
                BuildPipeline.BuildAssetBundles(assetBundleDirectoryPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }
        }
    }
}