using System;
using System.Threading.Tasks;

namespace FileReadWrite
{
    class UXEnhancements
    {
        private int time;
        private int loop;
        private string text;

// TODO: Constructor inherit(?) //
        public UXEnhancements()
        {
            time = 2000;
            text = null;
            loop = 0;
        }
        public UXEnhancements(int inTime)
        {
            time = inTime;
            text = null;
            loop = 0;
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
