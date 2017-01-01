/*
 * UX enhancement:
 * Add delay between output for enhanced user experience.
 */

using System;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UXEnhancements
    {
        private int time = 2000;
        private int loop = 0;
        private string text = null;

        public UXEnhancements()
        {
            addDelay();
        }

        public UXEnhancements(int inTime)
        {
            time = inTime;
            addDelay();
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
                    Task.Delay(time).Wait();
                    Console.Write(text);
                    i++;
                }
                Console.Write(Environment.NewLine);
                Task.Delay(time).Wait();
            }
            else if(!String.IsNullOrEmpty(text))
            {
                Task.Delay(time).Wait();
                Console.Write(text);
                Console.Write(Environment.NewLine);
                Task.Delay(time).Wait();
            }
            else
            {
                Task.Delay(time).Wait();
            }
        }
    }
}
