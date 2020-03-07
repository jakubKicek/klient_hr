using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_To_AWS
{
    public partial class Form1 : Form
    {
        DEMO_KD_1Entities context = new DEMO_KD_1Entities();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void RunBTN_Click(object sender, EventArgs e)
        {

            // var ActiveInstance = BaseContext.PRAC_EVENT_INSTANCE_TO_PORTION(secondParametr).ToArray<Model.PRAC_EVENT_INSTANCE_TO_PORTION_Result>();
            // var Resp = ActiveInstance.First();

            var ProcState = context.AWS_PRAC_TO_VECTOR();//.ToArray<>(DEMO_KD_1Model.Store.AWS_PRAC_TO_VECTOR);
            //var Resp = ActiveInstance.First();
        }
        private void ReadBTN_Click(object sender, EventArgs e)
        {
            AWS_PRAC_WEKTOR emp = context.AWS_PRAC_WEKTOR.FirstOrDefault();
            MessageBox.Show(emp.id.ToString());
        }
    }
}
