using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizBuzz
{
    class ConnectionInfo
    {
        public ConnectionInfo(string sound) { SoundName = sound; }
        public string Name { get; set; }
        public string SoundName { get; set; }
    }
}
