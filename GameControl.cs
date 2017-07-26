using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Structure
{
    namespace Logic
    {
        public class GameControl : MonoBehaviour
        {
            // Properties
            public DataLinker Data;

            int timeSinceUpdate;
            int timeToUpdate;

            // Methods
            void Start()
            {
                // Prototype: manual goal setup (instead of player settings)
                Data.CurrentGoal = DataBase.GetGoal("Build Khufu Pyramid");

                // Init vars
                timeSinceUpdate = (int)Time.time;
                timeToUpdate = timeSinceUpdate + Data.GameTimeInterval;

                Data.FieldList = new List<GameObject>();
                Data.BuildingList = new List<GameObject>();
                Data.HandList = new List<GameObject>();

                Data.ResourcesCurrent = Data.CurrentGoal.startingResources;
                Data.ResourcesUpdate = new Resources();

                Data.GameOver = false;

                Data.GameTime = 0;
                Data.GameTimeInterval = Data.CurrentGoal.goalTimeInterval;
                Data.GameTimeLimit = Data.CurrentGoal.goalTimeLimit;

                Data.ScorePoints = 0;

                // Init vars from DB
                Data.ExploreCost = DataBase.GetExploreCost();
            }

            void Update()
            {
                if (!Data.GameOver)
                {
                    ResourceControl();
                    HandController();
                    TimeControl();
                    CheckWinState();
                }
            }

            void TimeControl()
            {
               Data.GameTime = (int)Time.time;
            }

            void ResourceControl()
            {
                if (timeSinceUpdate <= timeToUpdate)
                {
                    Data.ResourcesCurrent.food += Data.ResourcesUpdate.food;
                    Data.ResourcesCurrent.wood += Data.ResourcesUpdate.wood;
                    Data.ResourcesCurrent.stone += Data.ResourcesUpdate.stone;

                    timeSinceUpdate = (int)Time.time;
                    timeToUpdate = timeSinceUpdate + Data.GameTimeInterval;
                }
            }

            void CheckWinState()
            {
                if (Data.GameTime >= Data.GameTimeLimit)
                {
                    Data.ScorePoints = GetHighscoreValue();
                    Data.GameOver = true;
                    // LevelManager.LoadScene("GameOver");
                }

                switch (Data.CurrentGoal.winCondition)
                {
                    case WinningCondition.BuildPyramid:
                        foreach (GameObject building in Data.BuildingList)
                        {
                            if (building.GetComponent<Building>().Name == "Khufu Pyramid")
                            {
                                Data.ScorePoints = GetHighscoreValue();
                                Data.GameOver = true;
                                // LevelManager.LoadScene("GameWon");
                            }
                        }
                        break;
                    case WinningCondition.Gather100Stone:
                        foreach (GameObject building in Data.BuildingList)
                        {
                            if (building.GetComponent<Building>().Name == "")
                            {
                                Data.ScorePoints = GetHighscoreValue();
                                Data.GameOver = true;
                                // LevelManager.LoadScene("GameWon");
                            }
                        }
                        break;
                }
            }

            void HandController()
            {
                int cardsOnHand = 0;
                foreach(GameObject building in Data.HandList)
                {
                    cardsOnHand++;
                }

                if (cardsOnHand <= 5)
                {
                    string newCard = GetRandomHandCard();
                    // Data.LogicCardControl.AddField(newCard);
                }
            }

            int GetHighscoreValue()
            {
                // HighBase
                int hs = 0;

                // HighEnd
                hs += Data.GameTime;
                hs += 10 * (Data.ResourcesCurrent.food + Data.ResourcesCurrent.wood + Data.ResourcesCurrent.stone);
                return hs;
            }

            string GetRandomHandCard()
            {
                List<string> allCards = DataBase.GetCardNames();
                int amountCards = 0;
                foreach (string card in allCards)
                {
                    amountCards++;
                }

                int randomNumber = UnityEngine.Random.Range(0, amountCards);
                string chosenCard = allCards[randomNumber];
                return chosenCard;
            }
        }
    }

}