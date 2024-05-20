using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ = SampleProject.PageObjectModel.DashBoardPage;
namespace SampleProject.PageObjectModel
{
    class DashBoardPage : Page<_>
    {
        [FindByContent]
        public Link<_> Products { get; set; }
        [FindByContent]
        public Link<_> Plans { get; set; }
    }
}
