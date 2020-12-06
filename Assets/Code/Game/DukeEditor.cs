using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Build;

#if UNITY_EDITOR
public class DukeEditor : MonoBehaviour
{
    [MenuItem("DukeSharp/Load Entities")]
    static void LoadNGEntities()
    {
        string path = EditorUtility.OpenFilePanel("Open Entities", Application.streamingAssetsPath, "entities");
        using (FileStream f = File.OpenRead(path))
        {
            using (BinaryReader reader = new BinaryReader(f))
            {
                int numLights = reader.ReadInt32();

                for(int i = 0; i < numLights; i++)
                {
                    string name = reader.ReadString();

                    // Make a game object
                    GameObject lightGameObject = new GameObject(name);

                    // Add the light component
                    Light lightComp = lightGameObject.AddComponent<Light>();

                    lightComp.type = (LightType)reader.ReadInt32();
                    lightComp.range = (float)reader.ReadDouble();
                    lightComp.intensity = (float)reader.ReadDouble();
                    Vector4 color = new Vector4();
                    color.x = (float)reader.ReadDouble();
                    color.y = (float)reader.ReadDouble();
                    color.z = (float)reader.ReadDouble();
                    color.w = (float)reader.ReadDouble();
                    lightComp.color = color;
                    Vector3 position = new Vector3();
                    position.x = (float)reader.ReadDouble();
                    position.y = (float)reader.ReadDouble();
                    position.z = (float)reader.ReadDouble();
                    lightComp.transform.position = position;

                    Vector3 angles = new Vector3();
                    angles.x = (float)reader.ReadDouble();
                    angles.y = (float)reader.ReadDouble();
                    angles.z = (float)reader.ReadDouble();
                    lightComp.transform.eulerAngles = angles;
                    lightComp.shadows = (LightShadows)reader.ReadInt32();
                }
            }
        }
    }

    [MenuItem("DukeSharp/Save Entities")]
    static void SaveNGEntities()
    {
        Light[] lights;

        string path = EditorUtility.SaveFilePanel("Save Entities", Application.streamingAssetsPath, "", "entities");

        using (FileStream f = File.OpenWrite(path))
        {
            using (BinaryWriter writer = new BinaryWriter(f))
            {
                lights = FindObjectsOfType(typeof(Light)) as Light[];

                writer.Write(lights.Length);

                foreach (Light light in lights)
                {
                    writer.Write(light.name);
                    writer.Write((int)light.type);
                    writer.Write((double)light.range);
                    writer.Write((double)light.intensity);
                    writer.Write((double)light.color.r);
                    writer.Write((double)light.color.g);
                    writer.Write((double)light.color.b);
                    writer.Write((double)light.color.a);
                    writer.Write((double)light.transform.position.x);
                    writer.Write((double)light.transform.position.y);
                    writer.Write((double)light.transform.position.z);
                    writer.Write((double)light.transform.eulerAngles.x);
                    writer.Write((double)light.transform.eulerAngles.y);
                    writer.Write((double)light.transform.eulerAngles.z);
                    writer.Write((int)light.shadows);
                }
            }
        }
    }

    [MenuItem("DukeSharp/Init Editor")]
    static void InitEditor()
    {
        GameEngine.AppPath = Application.dataPath;

        Engine.Init();
        GlobalMembers.DukeMain(""); // Get everything setup.

        Engine.palette.UpdatePaletteMainThread();
    }

    [MenuItem("DukeSharp/Open Build Map")]
    static void OpenMapForEdit()
    {
        string path = EditorUtility.OpenFilePanel("Open Build Map", Application.streamingAssetsPath, "map");
        if (path.Length != 0)
        {
            string mapname = Path.GetFileName(path);
            int daposx = 0;
            int daposy = 0;
            int daposz = 0;
            short daang = 0;
            short dacursectnum = 0;

            Engine.loadboard(path, ref daposx, ref daposy, ref daposz, ref daang, ref dacursectnum, true);
        }
    }
}
#endif