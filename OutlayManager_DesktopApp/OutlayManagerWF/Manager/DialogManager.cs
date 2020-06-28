using System.Windows.Forms;

namespace OutlayManagerWF.Manager
{
    public sealed class DialogManager
    {
        private Form sender;

        public enum DialogLevel
        {
            Exception,
            Information
        };

        public void ShowDialog(DialogLevel level, string message, Form sender)
        {
            switch (level)
            {
                case DialogLevel.Exception:

                    //Bloq user control
                    this.sender = sender ?? new Form();
                    this.sender.Enabled = false;

                    Dialog dialogException = new Dialog(message);
                    dialogException.FormClosed += ReleaseSenderBlock;

                    

                    dialogException.TopLevel = true;
                    dialogException.TopMost = true;
                    dialogException.ShowDialog();

                    break;

                case DialogLevel.Information:
                    Dialog dialogInfo = new Dialog(message);
                    dialogInfo.TopLevel = true;
                    dialogInfo.TopMost = true;
                    dialogInfo.ShowDialog();
                    break;
            }
        }

        private void ReleaseSenderBlock(object sender, FormClosedEventArgs e)
        {
            this.sender.Enabled = true;
        }
    }
}
