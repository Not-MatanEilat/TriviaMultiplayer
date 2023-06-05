using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public partial class GameResults : Page
    {

        private JObject results;
        public GameResults(JObject results)
        {
            InitializeComponent();
            this.results = results; 
        }
    }
}
