using System.Collections.Generic;
using System.Windows.Forms;

namespace XISOExtractorGUI
{
    public partial class ExtractionResults : Form
    {
        public ExtractionResults()
        {
            InitializeComponent();
        }

        public void Show(IEnumerable<BwArgs> results)
        {
            foreach (var res in results)
            {
                var viewitem = res.Result ? new ListViewItem("OK") : new ListViewItem("FAILED");
                viewitem.SubItems.Add(res.Source);
                viewitem.SubItems.Add(res.Target);
                viewitem.SubItems.Add(Program.GetOptString(res));
                viewitem.SubItems.Add(!res.Result ? res.ErrorMsg : "");
                resultbox.Items.Add(viewitem);
            }
            Show();
        }
    }
}
