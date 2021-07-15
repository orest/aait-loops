using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops.Model {
    public class Family {
        public Family() {
            Children = new List<Person>();
        }
        public Family(int famId, string famName) {
            this.FamilyId = famId;
            this.Nickname = famName;
            Children = new List<Person>();
        }
        public int FamilyId { get; set; }
        public string Nickname { get; set; }
        public Adult Father { get; set; }
        public Adult Mother { get; set; }
        public List<Person> Children { get; set; }
    }
}
