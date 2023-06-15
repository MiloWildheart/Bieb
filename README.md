using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bieb
{
    public partial class README: Component
    {    
        public README()
        {
            InitializeComponent();
        }

        public README(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
