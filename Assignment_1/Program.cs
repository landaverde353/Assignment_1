
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {   static void Main(string[] args)
        {// creating an obj of a custom class made
            Questions programQuestions = new Questions();
            //calling the method in questions class
            programQuestions.QuestionUser();
        }
    }
}
