﻿using System;
using System.Collections.Generic;

namespace FileReadWrite
{
    class EntryPointTest
    {
        public static void Main(string[] args)
        {
            string csvRawFileName = "rawData.csv";
            string csvPath = @"C:\Users\FISH-1\Documents\MS_Workspace\FileReadWrite\FileReadWrite\Assets\";
            char valueDelimiter = ',';

            string[] rawLines = System.IO.File.ReadAllLines(csvPath + csvRawFileName);

            ProcessLines objProcessLine = new ProcessLines();

            string charToDelete = "\"";
            string headLine = objProcessLine.removeChar(rawLines[0], charToDelete);
            string lineLine = objProcessLine.removeChar(rawLines[1], charToDelete);
            //string[] headArr = new string[rawLines[0].Length];
            //string[] lineArr = new string[rawLines[1].Length];
            List<string> headList = new List<string>();
            List<string> lineList = new List<string>();
            headList = objProcessLine.splitValues(headLine, valueDelimiter);
            lineList = objProcessLine.splitValues(lineLine, valueDelimiter);

            int[] elementIndex = new int[] { 0, 7 };
            UpdateLine objUpdateHead = new UpdateLine();
            UpdateLine objUpdateLine = new UpdateLine();
            objUpdateHead.modifyLine(headList, elementIndex);
            objUpdateLine.modifyLine(lineList, elementIndex);

            elementIndex = new int[] { 0, 7 };
            int totalLines = 3;
            objUpdateLine.multiLine(elementIndex, totalLines);

            int count = objUpdateLine.StrListArr.Count;
            objUpdateLine.StrList.ForEach(Console.WriteLine);
            //for (int i = 0; i < count; i++)
            //{
            //    foreach(string s in objUpdateLine.strListArr)
            //    Console.WriteLine("Multi line: {0}", s);
            //}

            Console.WriteLine("\n>>> Press any key to exit.");
            Console.ReadKey();
        }
    }
}
