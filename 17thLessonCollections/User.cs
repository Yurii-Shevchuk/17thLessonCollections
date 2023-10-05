using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17thLessonCollections
{
    internal record User(string Name, bool HasVoted) : IUser //тут мало бути більше типів юзерів, але щось дуже сильно не пішло і тепер їх немає
    {
        public bool HasVoted { get; set; }
    }
    
}
