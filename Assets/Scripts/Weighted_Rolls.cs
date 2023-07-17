using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weighted_Rolls
{
    public String_Weights Weighted_String(String_Weights[] weights)
    {
        int total_weight = 0;
        foreach (String_Weights w in weights)
        {
            total_weight += w.weight;
        }
        int random = UnityEngine.Random.Range(0, total_weight);
        int total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i].weight;
            if (total > random)
            {
                return weights[i];
            }
            else
            {
                continue;
            }
        }
        Debug.Log("Error Weighted_String failed to roll weight");
        return Weighted_String(weights);
    }
    public Int_Weights Weighted_Int(Int_Weights[] weights)
    {
        int total_weight = 0;
        foreach (Int_Weights w in weights)
        {
            total_weight += w.weight;
        }
        int random = UnityEngine.Random.Range(0, total_weight);
        int total = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i].weight;
            if (total > random)
            {
                return weights[i];
            }
            else
            {
                continue;
            }
        }
        Debug.Log("Error Weighted_Int failed to roll weight");
        return Weighted_Int(weights);
    }
    public struct Int_Weights
    {
        int int_int;
        int weight_int;
        public int int_
        {
            get { return int_int; }
            set { int_int = value; }
        }
        public int weight
        {
            get { return weight_int; }
            set { weight_int = value; }
        }
        public Int_Weights(int int_, int weight)
        {
            int_int = int_;
            weight_int = weight;
        }
    }
    public struct String_Weights
    {
        string string_string;
        int weight_int;
        public string string_
        {
            get { return string_string; }
            set { string_string = value; }
        }
        public int weight
        {
            get { return weight_int; }
            set { weight_int = value; }
        }

        public String_Weights(string string_, int weight)
        {
            string_string = string_;
            weight_int = weight;
        }
    }
}
