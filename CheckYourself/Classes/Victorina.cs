using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CheckYourself.Classes
{
    class Victorina
    {
        public int count;
        public string quest;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public int cost;

        public Victorina(int count, string quest, string answer1, string answer2, string answer3, string answer4, int cost)
        {
            this.count = count;
            this.quest = quest;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.cost = cost;
        }

        
    }
}
