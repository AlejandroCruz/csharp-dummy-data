using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UXEnhancements
    {
        private int time;
        private int loop;
        private string text;

        //TODO: Constructor inherit(?)//
        public UXEnhancements()
        {
            time = 2000;
            addDelay();
        }
        public UXEnhancements(int inTime)
        {
            time = inTime;
            addDelay();
        }
        public UXEnhancements(int inTime, string inText)
        {
            time = inTime;
            text = inText;
            addDelay();
        }
        public UXEnhancements(int inTime, string inText, int repeat)
        {
            time = inTime;
            text = inText;
            loop = repeat;
            addDelay();
        }

        public void addDelay()
        {
            if (!String.IsNullOrEmpty(text) && loop > 1)
            {
                int i = 0;
                while ( i < loop)
                {
                    Task.Delay(time).Wait(); System.Console.Write(text);
                    i++;
                }
                Task.Delay(time).Wait();
            }
            else if(!String.IsNullOrEmpty(text))
            {
                Task.Delay(time).Wait(); System.Console.Write(text); Task.Delay(time).Wait();
            }
            else
            {
                Task.Delay(time).Wait();
            }
        }
    }
}
