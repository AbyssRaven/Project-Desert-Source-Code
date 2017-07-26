using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structure.Logic;

public class DataLinker : MonoBehaviour {

    public CardCheck LogicChecks;
    public CardControl LogicCardControl;
    public PlayerControl LogicPlayerControl;

    public GameObject FieldPrefab;
    public GameObject BuildingPrefab;

    public List<GameObject> FieldList { get; set; }
    public List<GameObject> HandList { get; set; }
    public List<GameObject> BuildingList { get; set; }

    public Structure.Resources ResourcesCurrent;
    public Structure.Resources ResourcesUpdate;
    public Structure.Resources ExploreCost;
    public Structure.Goal CurrentGoal { get; set; }

    public bool GameOver { get; set; }

    public int GameTime { get; set; }
    public int GameTimeLimit { get; set; }
    public int GameTimeInterval { get; set; }

    public int ScorePoints { get; set; }

    private void Start()
    {
        //LogicChecks = new CardCheck();
        //LogicCardControl = new CardControl();
        //LogicPlayerControl = new PlayerControl();
    }
}
