using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_ado;

public class Student
{
   public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int ClassNumber { get; set; }

    public DateTime GraduationDate { get; set; }

    public override string ToString()
    {
        return $"Id : {Id} \n" +
            $"FirstName : {FirstName} \n" +
            $"LastName : {LastName} \n" +
            $"ClassNumber : {ClassNumber} \n" +
            $"GraduationDate : {GraduationDate} \n";
    }
}
