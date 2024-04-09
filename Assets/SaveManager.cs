using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get { return instance; } }
    private static SaveManager instance;

    // Fields
    public SaveState save;
    private const string saveFileName = "Alif.ss";
    private BinaryFormatter formatter;

    // Actions
    public Action<SaveState> OnLoad;
    public Action<SaveState> OnSave;

    private void Awake()
    {
        instance = this;
        formatter = new BinaryFormatter();

        // Try and load the previous save state
        Load();
    }

    public void Load()
    {
        try
        {
            FileStream file = new FileStream(Application.persistentDataPath + saveFileName, FileMode.Open, FileAccess.Read);
            save = (SaveState)formatter.Deserialize(file);
            file.Close();
            OnLoad?.Invoke(save);
        }
        catch
        {
            Debug.Log("Save file not found, let's create a new one!");
            Save();
        }
    }

    public void Save()
    {
        // If theres no previous state found, create a new one!
        if (save == null)
            save = new SaveState();

        // Set the time at which we've tried saving
        save.LastSaveTime = DateTime.Now;

        // Open a file on our system, and write to it
        FileStream file = new FileStream(Application.persistentDataPath + saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, save);
        file.Close();

        OnSave?.Invoke(save);
    }


}
