﻿using UnityEditor;
using System.IO;
using UnityEngine;
using System;

namespace MVR {
namespace AssetBundles {

/// <summary>
/// The class handles the building of AssetBundles and creates a menu item under "assets" to run it.
/// </summary>
public class BuildAssetBundles {
    // create menu item under "assets" for BuildAllAssetBundles function
    [MenuItem("Assets/Build AssetBundles")]

    /// <summary>
    /// Builds all AssetBundles.
    /// </summary>
    /// <remarks>
    /// Add a new directory to the "buildTargetSubDirs" array and a new BuildPipeline line when adding a new build target.
    /// </remarks>
    public static void BuildAllAssetBundles() {
        // set up all of the build target sub-directories
        string[] buildTargetSubDirs = { "", "/iOS", "/Android" };
        // preset path to build the bundle in
        string assetBundleDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/MoleculeBundles";

        // create local directories if they does not exist already
        for (int targets = 0; targets < buildTargetSubDirs.Length; targets++) {
            string newPath = assetBundleDirectory + buildTargetSubDirs[targets];
            if (!Directory.Exists(newPath)) {
                Directory.CreateDirectory(newPath);
                Debug.Log("Created new directory: " + newPath);
            }
        }

        //TODO: automate using buildTargetSubDirs

        // builds for iOS to directory, uses LZMA compression & LZ4 recompression
        BuildPipeline.BuildAssetBundles(assetBundleDirectory + buildTargetSubDirs[1], BuildAssetBundleOptions.None, BuildTarget.iOS);
        // builds for Android to directory, uses LZMA compression & LZ4 recompression
        BuildPipeline.BuildAssetBundles(assetBundleDirectory + buildTargetSubDirs[2], BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}

} // namespace AssetBundles
} // namespace MVR