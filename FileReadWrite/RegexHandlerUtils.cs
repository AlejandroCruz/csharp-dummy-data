using System;
using System.Collections.Generic;
using System.Text;

namespace FileReadWrite
{
    public class RegexHandlerUtils
    {
        public string AddPrefixToSequence(string prefixStr)
        {
            char validateZ = 'Z';
            List<char> prefixSequence = new List<char>();

            foreach (var item in prefixStr)
            {
                prefixSequence.Add(item);
            }

            /*
             * English alphabet 26 letters:
             *  26 ^ 4 = 456,976
             *  26 ^ 3 = 17,576
             *  26 ^ 2 = 676
             */
            int amountOfElements = prefixSequence.Count;
            switch (amountOfElements)
            {
                case 2:
                    if (prefixSequence[1].Equals(validateZ))
                    {
                        if (prefixSequence[0].Equals(validateZ))
                        {
                            prefixSequence[0] = 'A';
                            prefixSequence[1] = 'A';
                            prefixSequence.Add('A');
                        }
                        else
                        {
                            prefixSequence[0]++;
                            prefixSequence[1] = 'A';
                        }
                    }
                    else
                    {
                        prefixSequence[1]++;
                    }
                    break;
                case 3:
                    if (prefixSequence[2].Equals(validateZ))
                    {
                        if (prefixSequence[1].Equals(validateZ))
                        {
                            if (prefixSequence[0].Equals(validateZ))
                            {
                                prefixSequence[0] = 'A';
                                prefixSequence[1] = 'A';
                                prefixSequence[2] = 'A';
                                prefixSequence.Add('A');

                            }
                            else
                            {
                                prefixSequence[0]++;
                                prefixSequence[1] = 'A';
                                prefixSequence[2] = 'A';
                            }
                        }
                        else
                        {
                            prefixSequence[1]++;
                            prefixSequence[2] = 'A';
                        }
                    }
                    else
                    {
                        prefixSequence[2]++;
                    }
                    break;
                case 4:
                    throw new Exception();
                //if (prefixSequence[3].Equals(validateZ))
                //{
                //    if (prefixSequence[2].Equals(validateZ))
                //    {
                //        if (prefixSequence[1].Equals(validateZ))
                //        {
                //            if (prefixSequence[0].Equals(validateZ))
                //            {
                //                throw new Exception();
                //            }
                //            else
                //            {
                //                prefixSequence[0]++;
                //                prefixSequence[1] = 'A';
                //                prefixSequence[2] = 'A';
                //                prefixSequence[3] = 'A';
                //            }
                //        }
                //        else
                //        {
                //            prefixSequence[1]++;
                //            prefixSequence[2] = 'A';
                //            prefixSequence[3] = 'A';
                //        }
                //    }
                //    else
                //    {
                //        prefixSequence[2]++;
                //        prefixSequence[3] = 'A';
                //    }
                //}
                //else
                //{
                //    prefixSequence[3]++;
                //}
                //break;
                default:
                    if (prefixSequence[0].Equals(validateZ))
                    {
                        prefixSequence[0] = 'A';
                        prefixSequence.Add('A');
                    }
                    else
                    {
                        prefixSequence[0]++;
                    }
                    break;
            }

            StringBuilder strBuild = new StringBuilder();
            foreach (var item in prefixSequence)
            {
                strBuild.Append(item);
            }

            return strBuild.ToString();
        }
    }
}