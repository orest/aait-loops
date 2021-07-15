using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops.Model
{
    public class Adult : Person
    {
        public string LicenseNumber { get; set; }
        public string Job { get; set; }
        public override string ToString()
        {
            //var famNm= string.Format("    {0} - {1}, {2}, LicenseNumber = {3}", Name, Age, Job, LicenseNumber);
           return $"    {Name} - {Age}, {Job}, LicenseNumber = {LicenseNumber}";
         
        }
    }
}
