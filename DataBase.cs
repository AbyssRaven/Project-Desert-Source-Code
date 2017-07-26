using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structure;
using MiniJSON;

public class DataBase : MonoBehaviour {

    static public Field GetFieldObject(string name)
    {
        Field field = new Field();

        TextAsset jsonRaw = (TextAsset)UnityEngine.Resources.Load("Database/FieldData", typeof(TextAsset));
        string jsonString = jsonRaw.ToString();
        var dict = Json.Deserialize(jsonString) as Dictionary<string, object>;

        object fieldData;
        dict.TryGetValue(name, out fieldData);

        string field_name;

        string gain_food;
        string gain_wood;
        string gain_stone;

        string path_name;
        string path_artwork;
        string path_description;

        bool bool_supportgrand;

        field_name = (string)(((Dictionary<string, object>)fieldData)["Name"]);
        gain_food = (string)(((Dictionary<string, object>)fieldData)["FoodGain"]);
        gain_wood = (string)(((Dictionary<string, object>)fieldData)["WoodGain"]);
        gain_stone = (string)(((Dictionary<string, object>)fieldData)["StoneGain"]);
        path_name = (string)(((Dictionary<string, object>)fieldData)["ImagePathName"]);
        path_artwork = (string)(((Dictionary<string, object>)fieldData)["ImagePathArtwork"]);
        path_description = (string)(((Dictionary<string, object>)fieldData)["ImagePathDescription"]);
        bool_supportgrand = (bool)(((Dictionary<string, object>)fieldData)["SupportGrandBuilding"]);

        int struct_GainFood;
        int struct_GainWood;
        int struct_GainStone;

        int.TryParse(gain_food, out struct_GainFood);
        int.TryParse(gain_wood, out struct_GainWood);
        int.TryParse(gain_stone, out struct_GainStone);

        Structure.Resources fieldGain = new Structure.Resources();
        fieldGain.food = struct_GainFood;
        fieldGain.wood = struct_GainWood;
        fieldGain.stone = struct_GainStone;

        field.Name = field_name;
        field.IncomeResource = fieldGain;
        field.ImagePathName = path_name;
        field.ImagePathArtwork = path_artwork;
        field.ImagePathDescription = path_description;
        field.SupportGrandBuilding = bool_supportgrand;

        return field;
    }

    static public Building GetBuildingObject(string name)
    {
        Building building = new Building();

        TextAsset jsonRaw = (TextAsset)UnityEngine.Resources.Load("Database/BuildingData", typeof(TextAsset));
        string jsonString = jsonRaw.ToString();
        var dict = Json.Deserialize(jsonString) as Dictionary<string, object>;

        object buildingData;
        dict.TryGetValue(name, out buildingData);

        string building_name;

        string cost_food;
        string cost_wood;
        string cost_stone;
        string gain_food;
        string gain_wood;
        string gain_stone;

        string path_name;
        string path_artwork;
        string path_description;

        bool bool_grand;
        bool bool_onetime;
        bool bool_temple;

        building_name = (string)(((Dictionary<string, object>)buildingData)["Name"]);
        cost_food = (string)(((Dictionary<string, object>)buildingData)["FoodCost"]);
        cost_wood = (string)(((Dictionary<string, object>)buildingData)["WoodCost"]);
        cost_stone = (string)(((Dictionary<string, object>)buildingData)["WoodCost"]);
        gain_food = (string)(((Dictionary<string, object>)buildingData)["FoodGain"]);
        gain_wood = (string)(((Dictionary<string, object>)buildingData)["WoodGain"]);
        gain_stone = (string)(((Dictionary<string, object>)buildingData)["StoneGain"]);
        path_name = (string)(((Dictionary<string, object>)buildingData)["ImagePathName"]);
        path_artwork = (string)(((Dictionary<string, object>)buildingData)["ImagePathArtwork"]);
        path_description = (string)(((Dictionary<string, object>)buildingData)["ImagePathDescription"]);
        bool_grand = (bool)(((Dictionary<string, object>)buildingData)["GrandBuilding"]);
        bool_onetime = (bool)(((Dictionary<string, object>)buildingData)["OneTimeUse"]);
        bool_temple = (bool)(((Dictionary<string, object>)buildingData)["Temple"]);

        int struct_CostFood;
        int struct_CostWood;
        int struct_CostStone;
        int struct_GainFood;
        int struct_GainWood;
        int struct_GainStone;

        int.TryParse(cost_food, out struct_CostFood);
        int.TryParse(cost_wood, out struct_CostWood);
        int.TryParse(cost_stone, out struct_CostStone);
        int.TryParse(gain_food, out struct_GainFood);
        int.TryParse(gain_wood, out struct_GainWood);
        int.TryParse(gain_stone, out struct_GainStone);

        Structure.Resources buildingCost = new Structure.Resources();
        Structure.Resources buildingGain = new Structure.Resources();
        buildingCost.food = struct_CostFood;
        buildingCost.wood = struct_CostWood;
        buildingCost.stone = struct_CostStone;
        buildingGain.food = struct_GainFood;
        buildingGain.wood = struct_GainWood;
        buildingGain.stone = struct_GainStone;

        building.Name = building_name;
        building.CostResource = buildingCost;
        building.IncomeResource = buildingGain;
        building.ImagePathName = path_name;
        building.ImagePathArtwork = path_artwork;
        building.ImagePathDescription = path_description;
        building.GrandBuilding = bool_grand;

        return building;
    }

    static public Goal GetGoal(string goalName)
    {
        Goal goal = new Goal();
        goal.winCondition = WinningCondition.BuildPyramid;
        goal.goalTimeLimit = 60;
        goal.goalTimeInterval = 10;

        TextAsset jsonRaw = (TextAsset)UnityEngine.Resources.Load("Database/GoalData", typeof(TextAsset));
        string jsonString = jsonRaw.ToString();
        var dict = Json.Deserialize(jsonString) as Dictionary<string, object>;

        object goalData;
        dict.TryGetValue(goalName, out goalData);

        string win_condition;
        string time_limit;
        string time_interval;

        string start_food;
        string start_wood;
        string start_stone;

        win_condition = (string)(((Dictionary<string, object>)goalData)["WinCondition"]);
        time_limit = (string)(((Dictionary<string, object>)goalData)["GoalTimeLimit"]);
        time_interval = (string)(((Dictionary<string, object>)goalData)["GoalTimeInterval"]);
        start_food = (string)(((Dictionary<string, object>)goalData)["StartingFood"]);
        start_wood = (string)(((Dictionary<string, object>)goalData)["StartingWood"]);
        start_stone = (string)(((Dictionary<string, object>)goalData)["StartingStone"]);

        Structure.Resources startingRes;
        int struct_startFood;
        int struct_startWood;
        int struct_startStone;

        int timeLimit;
        int timeInterval;

        int indexWinCondition;

        int.TryParse(win_condition, out indexWinCondition);
        int.TryParse(start_food, out struct_startFood);
        int.TryParse(start_wood, out struct_startWood);
        int.TryParse(start_stone, out struct_startStone);
        int.TryParse(time_limit, out timeLimit);
        int.TryParse(time_interval, out timeInterval);

        WinningCondition winCondition = (WinningCondition)indexWinCondition;
        startingRes.food = struct_startFood;
        startingRes.wood = struct_startWood;
        startingRes.stone = struct_startStone;

        goal.winCondition = winCondition;
        goal.startingResources = startingRes;
        goal.goalTimeLimit = timeLimit;
        goal.goalTimeInterval = timeInterval;

        return goal;
    }

    static public List<string> GetCardNames()
    {
        List<string> cardNameList = new List<string>();

        // DB IMPLEMENTATION
        cardNameList.Add("Sawmill");
        cardNameList.Add("Irregation Area");

        return cardNameList;
    }

    static public Structure.Resources GetExploreCost()
    {
        Structure.Resources cost = new Structure.Resources();
        cost.food = 10;
        cost.wood = 5;
        cost.stone = 0;

        return cost;
    }
}
