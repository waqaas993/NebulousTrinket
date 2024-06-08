using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace NebulousTrinket
{
    public class DownloadAssetBundle : MonoBehaviour
    {
        public void GetRandomSprites(int numberOfSprites, System.Action<Sprite[]> callback)
        {
            StartCoroutine(DownloadAssetBundleFromLocalDirectory(numberOfSprites, callback));
        }

        private IEnumerator DownloadAssetBundleFromLocalDirectory(int numberOfSprites, System.Action<Sprite[]> callback)
        {
            string assetBundleDirectoryPath = Application.dataPath + "/AssetBundles";
            string assetBundlePath = Path.Combine(assetBundleDirectoryPath, "yourAssetBundleName");

            if (!File.Exists(assetBundlePath))
            {
                Debug.LogWarning("Asset Bundle not found at path: " + assetBundlePath);
                callback(null);
                yield break;
            }

            using (UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("file://" + assetBundlePath))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogWarning("Error on the get request at: " + assetBundlePath + " " + www.error);
                    callback(null);
                    yield break;
                }
                else
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                    string[] assetNames = bundle.GetAllAssetNames();
                    Sprite[] sprites = new Sprite[numberOfSprites];

                    if (numberOfSprites > assetNames.Length)
                    {
                        Debug.LogWarning("Requested number of sprites exceeds the available sprites in the asset bundle.");
                        callback(null);
                        yield break;
                    }

                    HashSet<int> selectedIndices = new();

                    for (int i = 0; i < numberOfSprites; i++)
                    {
                        int randomIndex;
                        do
                        {
                            randomIndex = Random.Range(0, assetNames.Length);
                        }
                        while (!selectedIndices.Add(randomIndex));

                        sprites[i] = bundle.LoadAsset<Sprite>(assetNames[randomIndex]);
                        yield return null;
                    }

                    bundle.Unload(false);
                    callback(sprites);
                }
            }
        }
    }
}