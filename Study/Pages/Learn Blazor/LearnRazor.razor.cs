using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Pages.Learn_Blazor
{
    public class LearnRazorBase: ComponentBase
    {

        protected string name = "spark";

        protected string txtWelcome = "Time to learn Blazor!";

        protected void getname()
        {
            name = "Blazoer Learner";
        }
    }
}
