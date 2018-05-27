using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twisty_Sudoku
{
    interface Monitor
    {
        void update();
    }
    class Observer
    {
        HashSet<Monitor> monitors;
        public Observer()
        {
            monitors = new HashSet<Monitor>();
        }
        public void notify()
        {
            foreach (Monitor monitor in monitors)
            {
                monitor.update();
            }
        }
        public void sub(Monitor to_sub)
        {
            monitors.Add(to_sub);
        }
        public void unsub(Monitor to_unsub)
        {
            if (monitors.Contains(to_unsub))
            {
                monitors.Remove(to_unsub);
            }
        }
    }
}
