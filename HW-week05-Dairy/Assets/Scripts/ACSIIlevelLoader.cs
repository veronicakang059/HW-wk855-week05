using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class ACSIIlevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject wall;
    [FormerlySerializedAs("flipper")] public GameObject MovingBlock;
    [FormerlySerializedAs("StillBlock")] [FormerlySerializedAs("goal")] public GameObject PortalGate;
    public GameObject CurrentPlayer;
    public GameObject level;
    public int currentLevel = 0;
    
    Vector2 StartPos;
    
    public string file_name;
    private string file_path;

    public int CURRENTLEVEL
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        Destroy(level);
        level = new GameObject("level");
        
        string current_file_path = Application.dataPath + "/LevelDesign/" + file_name.Replace("num",currentLevel+"");
        string[] filelines = File.ReadAllLines(current_file_path);

        for (int y = 0; y < filelines.Length; y++)
        {
            int xOffset = 8;
            int yOffset = 4;
            string LineText = filelines[y];
                  char[] characters = LineText.ToCharArray();
          
                  for (var x = 0; x < characters.Length; x++) 
                  {
                      char c = characters[x];
                      GameObject newOjb;
                      switch (c)
                      {
                          case'p':
                              newOjb = Instantiate<GameObject>(player);
                              CurrentPlayer = newOjb;
                              StartPos = new Vector2(x-xOffset, -y+yOffset);
                              
                              break;
                          case'!':
                              newOjb = Instantiate<GameObject>(wall);
                              break;
                          case'*':
                              newOjb = Instantiate<GameObject>(MovingBlock);
                              break;
                          case '?':
                              newOjb = Instantiate<GameObject>(PortalGate);
                              break;
                          default:
                              newOjb = null;
                              break;
                      }

                      if (newOjb != null)
                      {
                          if (!newOjb.name.Contains("Player"))
                          {
                              newOjb.transform.parent = level.transform;
                          }

                          newOjb.transform.position = new Vector3(x-xOffset, -y+yOffset, 0);
                          
                      }

                  }
        }
    }

    public void ResetPlayer()
    {
        CurrentPlayer.transform.position = StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
