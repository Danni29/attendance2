using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment.DB;

namespace Assignment.ModelView
{
    public class SubjectsOfClassModelView
    {
        IEnumerable<String> stringsFound;
        public IEnumerable<SubjectsOfClass> SubjectsOfClasses { get; set; }

        public IEnumerable<String>  SlotTime { get; set; }
    }

}