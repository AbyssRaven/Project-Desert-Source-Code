using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

namespace Structure
{
    namespace Logic
    {
        public class CardControl : MonoBehaviour
        {
            // Properties
            public DataLinker Data;

            // Methods
            public void AddField(string field)
            {
                // DataBase part
                Field newField = new Field();

                newField.Name = "Nile";
                Structure.Resources income = new Resources();
                income.food = 10;
                income.wood = 0;
                income.stone = 0;
                newField.IncomeResource = income;

                // Instantiate

                // Interface part

            }

            public void AddBuilding(string building)
            {

            }

            public void RemoveBuilding(string building)
            {

            }
        }
    }
}


