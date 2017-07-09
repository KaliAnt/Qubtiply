using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent (typeof(FPSCounterTerminal))] //component to retrieve the value from
public class FPSDisplay : MonoBehaviour {
   // public Text fpsLabel;
    FPSCounter fpsCounter;
    public Text highestFPSLabel, averageFPSLabel, lowestFPSLabel;
    static string[] stringsFrom00To99 = {
        "00", "01", "02", "03", "04", "05", "06", "07", "08", "09",
        "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
        "20", "21", "22", "23", "24", "25", "26", "27", "28", "29",
        "30", "31", "32", "33", "34", "35", "36", "37", "38", "39",
        "40", "41", "42", "43", "44", "45", "46", "47", "48", "49",
        "50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
        "60", "61", "62", "63", "64", "65", "66", "67", "68", "69",
        "70", "71", "72", "73", "74", "75", "76", "77", "78", "79",
        "80", "81", "82", "83", "84", "85", "86", "87", "88", "89",
        "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"
    };
    void Awake()
    {
        //caches the reference to the counter so we dont need to invoke GetComponent every time
        fpsCounter = GetComponent<FPSCounter>();
    }
    void Update()
    {
       // highestFPSLabel.text =stringsFrom00To99[Mathf.Clamp(fpsCounter.HighestFPS, 0, 99)];
        averageFPSLabel.text =stringsFrom00To99[Mathf.Clamp(fpsCounter.AverageFPS, 0, 99)];
       // lowestFPSLabel.text =stringsFrom00To99[Mathf.Clamp(fpsCounter.LowestFPS, 0, 99)];
    }

}
