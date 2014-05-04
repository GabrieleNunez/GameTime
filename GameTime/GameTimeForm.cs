using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameTime.Core.NHL;
using GameTime.Controls;
using GameTime.Forms.NHL;
namespace GameTime
{
    public partial class GameTimeForm : Form
    {
        private NHLGameGrabber nhlGrabber;

        public GameTimeForm()
        {
            InitializeComponent();
            nhlGrabber = new NHLGameGrabber();
        }

        private void GameTimeForm_Load(object sender, EventArgs e)
        {
            
        }    
    }
}
