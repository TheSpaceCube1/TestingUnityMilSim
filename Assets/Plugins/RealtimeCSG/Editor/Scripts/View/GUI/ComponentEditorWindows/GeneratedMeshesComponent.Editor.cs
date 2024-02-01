﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using InternalRealtimeCSG;

namespace RealtimeCSG
{
	[CustomEditor(typeof(GeneratedMeshes))]
	internal sealed class GeneratedMeshesComponentEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			if (EditorApplication.isPlayingOrWillChangePlaymode)
				return;

			var reference = this.target as GeneratedMeshes;
			if (!reference)
				return;

			var destination = reference.owner;
			if (!destination)
			{
				GUILayout.Space(10);
				GUILayout.Label("The owner of this mesh doesn't exist anymore!");
				GUILayout.Space(10);
			} else
			{
				var defaultModel = InternalCSGModelManager.GetDefaultCSGModelForObject(reference);
				GUILayout.Space(10);
				if (destination == defaultModel || !defaultModel || !destination)
				{
					GUILayout.Label("This mesh was automatically generated by the default CSG-model");
				} else
				{ 
					GUILayout.Label("This mesh was automatically generated by a CSG-model called '" + destination.name + "'");
					GUILayout.Space(10);
					if (GUILayout.Button("Take me there"))
					{
						Selection.activeObject = destination;
					}
				}
				GUILayout.Space(10);
			}
		}
	}
}
#endif