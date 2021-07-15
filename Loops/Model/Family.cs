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

        public bool HasKidsYoungerThen(int age)
        {
            return Children.Any(p => p.Age < age);
        }

        public Person YoungestChild {
            get {
                Person youngest = null;
                int currMinAge = 999;
                if (Children != null) {
                    foreach (var person in Children) {
                        if (person.Age < currMinAge) {
                            youngest = person;
                            currMinAge = person.Age;
                        }
                    }
                }
                return youngest;
            }
        }


        public double AvrageAge {
            get {
                double result = 0.0;
                double age = Father.Age + Mother.Age;
                double familyCount = 2 + Children.Count;
                foreach (var child in Children) {
                    age += child.Age;
                }

                result =age / familyCount;
                return result;
            }
        }

        public double AvrageAgeLinq {
            get {
                List<Person> people = new List<Person> {Father, Mother};
                people.AddRange(Children);
                return people.Average(p => p.Age);

                //double result = 0.0;
                //double age = Father.Age + Mother.Age;
                //double familyCount = 2 + Children.Count;
                //foreach (var child in Children) {
                //    age += child.Age;
                //}

                //result = age / familyCount;
                //return result;
            }
        }

        public int? MinAge {
            get {
                int? minAge = null;
                if (Children.Count > 0) {
                    int currMinAge = Children[0].Age;
                    foreach (var kid in Children) {
                        if (kid.Age < currMinAge) {
                            currMinAge = kid.Age;
                        }
                    }
                    minAge = currMinAge;
                }
                return minAge;
            }
        }

        public bool IsNice {
            get {

                var isParentsNice = Father.Name.StartsWith("o", StringComparison.CurrentCultureIgnoreCase)
                                    || Mother.Name.StartsWith("O", StringComparison.CurrentCultureIgnoreCase);
                if (isParentsNice) {
                    return true;
                }

                if (Children != null) {
                    foreach (var kid in Children) {
                        bool isNiceKid = kid.Name.StartsWith("o", StringComparison.CurrentCultureIgnoreCase);
                        if (isNiceKid) return true;
                    }
                }
                return false;
            }
        }

        public override string ToString() {
            var builder = new StringBuilder();

            builder.AppendLine(Nickname + " MinAge: " + YoungestChild?.Age);
            builder.AppendLine(" Parents: ");

            builder.AppendLine(Father.ToString());
            builder.AppendLine(Mother.ToString());

            if (Children != null && Children.Count > 0) {
                builder.AppendLine(" Kids:");
                foreach (var kid in Children) {
                    builder.AppendFormat("    {0} - {1} \n", kid.Name, kid.Age);
                }
            }
            return builder.ToString();

        }
    }
}
