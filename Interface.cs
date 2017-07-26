using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Structure
{
    public class Interface : MonoBehaviour
    {
        public DataLinker Data;

        public Text FoodResourceNum;
        public Text WoodResourceNum;
        public Text StoneResourceNum;

        public Text TimerGoalRemaining;
        public Text TimerIntervalRemaining;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            updateResourceBar();
            updateTimer();
        }

        void updateResourceBar()
        {
            FoodResourceNum.text = Data.ResourcesCurrent.food.ToString();
            WoodResourceNum.text = Data.ResourcesCurrent.wood.ToString();
            StoneResourceNum.text = Data.ResourcesCurrent.stone.ToString();
        }

        void updateTimer()
        {
            int remaining = Data.GameTimeLimit - Data.GameTime;
            TimerGoalRemaining.text = remaining.ToString();

            int intervalPassed = Data.GameTime % Data.GameTimeInterval;
            int intervalRemaining = Data.GameTimeInterval - intervalPassed;
            TimerIntervalRemaining.text = intervalRemaining.ToString();
        }
    }
}