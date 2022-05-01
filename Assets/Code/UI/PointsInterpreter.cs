using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public static class PointsInterpreter
    {
        public static string Interpret(float value)
        {
            string marker;
            int count = Mathf.Abs((int)(value / 1000000));
            marker = "M";
            if (count <= 0)
            {
                count = Mathf.Abs((int)(value / 1000));
                marker = "K";

                if (count <= 0)
                {
                    count = (int)value;
                    marker = "";

                }
            }

            return $"{count}{marker}";
        }

    }

}


