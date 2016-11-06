/*
 * UX enhancement:
 * Add delay between displaying lines in order to not show all results at once when console output.
 */

using System;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UXEnhancements
    {
        private int time = 2000;
        private int loop;
        private string text;

        public UXEnhancements()
        {
            text = null;
            loop = 0;
        }
        public UXEnhancements(int inTime) : this()
        {
            time = inTime;
            addDelay(time, text, loop);
        }

        public void addDelay()
        {
            Task.Delay(time).Wait();
        }

        public void addDelay(int inTime, string inText, int inLoop)
        {
            time = inTime;
            text = inText;
            loop = inLoop;

            if (!String.IsNullOrEmpty(text) && loop > 1)
            {
                int i = 0;
                while ( i < loop)
                {
                    Task.Delay(time).Wait(); Console.Write(text);
                    i++;
                }
                Task.Delay(time).Wait();
            }
            else if(!String.IsNullOrEmpty(text))
            {
                Task.Delay(time).Wait(); Console.Write(text); Task.Delay(time).Wait();
            }
            else
            {
                Task.Delay(time).Wait();
            }
        }
    }
}
