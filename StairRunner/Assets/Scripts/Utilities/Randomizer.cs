using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StairRunner.Utilities
{
    public class Randomizer : MonoBehaviour
    {
        public static int RollTheDice(int lower, int higher)
        {
            return Random.Range(lower, higher);
        }
        
    }

}
