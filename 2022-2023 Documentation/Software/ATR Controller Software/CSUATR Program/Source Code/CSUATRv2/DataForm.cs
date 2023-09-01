using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSUATRv2
{
    public partial class DataForm : Form
    {
        #region Classes
        DataManager dataManager;
        EventManager eventManager;
        #endregion
        #region Forms
        SaveDataForm saveDataForm;
        LoadDataForm loadDataForm;
        WarningForm warningForm;
        #endregion
        #region Column Headers
        ColumnHeader chID;
        ColumnHeader chSParam;
        ColumnHeader chSourcePower;
        ColumnHeader chHorizontal;
        ColumnHeader chVertical;
        ColumnHeader chDepth;
        ColumnHeader chAzimuth;
        ColumnHeader chElevation;
        ColumnHeader chPolarization;
        #endregion

        public DataForm(DataManager dataManager, EventManager eventManager)
        {
            this.dataManager = dataManager;
            this.eventManager = eventManager;

            InitializeComponent();

            checkBoxWarn.Checked = true;
            
            chID = new ColumnHeader() { Text = "ID", Width = 80 };
            chSParam = new ColumnHeader() { Text = "S##", Width = 80 };
            chSourcePower = new ColumnHeader() { Text = "Power", Width = 160 };
            chHorizontal = new ColumnHeader() { Text = "Horizontal", Width = 160 };
            chVertical = new ColumnHeader() { Text = "Vertical", Width = 160 };
            chDepth = new ColumnHeader() { Text = "Depth", Width = 160 };
            chAzimuth = new ColumnHeader() { Text = "Azimuth", Width = 160 };
            chElevation = new ColumnHeader() { Text = "Elevation", Width = 160 };
            chPolarization = new ColumnHeader() { Text = "Polarization", Width = 160 };

            listView.Columns.Add(chID);
            listView.Columns.Add(chSParam);
            listView.Columns.Add(chSourcePower);
            listView.Columns.Add(chHorizontal);
            listView.Columns.Add(chVertical);
            listView.Columns.Add(chDepth);
            listView.Columns.Add(chAzimuth);
            listView.Columns.Add(chElevation);
            listView.Columns.Add(chPolarization);

            RepopulateItems();
        }

        #region Menu
        private void menuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "(1) Save: Saves current data to external file\n" +
                "(2) Load: Clears data and loads from external file.\n" +
                "(3) File Format: Each data point takes four lines:\n" +
                "     - Line 1: <ID> <S##> <Source Power> <IF Bandwidth> <Averaging Points> <Horizontal> <Vertical> <Depth> <Azimuth> <Elevation> <Polarization>\n" +
                "     - Line 2: <List of measurement frequencies in ascending order>\n" +
                "     - Line 3: <List of reals for each measurement cooresponding to its frequency>\n" +
                "     - Line 4: <List of imaginaries for each measurement cooresponding to its frequency>\n",
                "Help - Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region Buttons
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveDataForm != null) { saveDataForm.Close(); }
            saveDataForm = new SaveDataForm(dataManager, eventManager);
            saveDataForm.Show();
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (loadDataForm != null) { loadDataForm.Close(); }
            loadDataForm = new LoadDataForm(dataManager, eventManager);
            loadDataForm.Show();
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            if (checkBoxWarn.Checked == true)
            {
                if (warningForm != null) { warningForm.Close(); }
                warningForm = new WarningForm(RemoveSelected);
                warningForm.Show();
            }
            else
            {
                RemoveSelected(0);
            }
        }
        private void buttonRemoveFirst_Click(object sender, EventArgs e)
        {
            if (checkBoxWarn.Checked == true)
            {
                if (warningForm != null) { warningForm.Close(); }
                warningForm = new WarningForm(RemoveFirst);
                warningForm.Show();
            }
            else
            {
                RemoveFirst(0);
            }
        }
        private void buttonRemoveLast_Click(object sender, EventArgs e)
        {
            if (checkBoxWarn.Checked == true)
            {
                if (warningForm != null) { warningForm.Close(); }
                warningForm = new WarningForm(RemoveLast);
                warningForm.Show();
            }
            else
            {
                RemoveLast(0);
            }
        }
        private void buttonClearDataset_Click(object sender, EventArgs e)
        {
            if (warningForm != null) { warningForm.Close(); }
            warningForm = new WarningForm(ClearDataset);
            warningForm.Show();
        }
        #endregion
        #region Assistant Functions
        private void RemoveSelected(int i)
        {
            if (listView.SelectedIndices.Count > 0)
            {
                int index = listView.SelectedIndices[0];
                eventManager.AddEvent(new Function(dataManager.RemovePointAtIndex, new object[] { index }));
            }
        }
        private void RemoveFirst(int i)
        {
            eventManager.AddEvent(new Function(dataManager.RemoveFirstPoint, new object[] { }));
        }
        private void RemoveLast(int i)
        {
            eventManager.AddEvent(new Function(dataManager.RemoveLastPoint, new object[] { }));
        }
        private void ClearDataset(int i)
        {
            eventManager.AddEvent(new Function(dataManager.ClearDataset, new object[] { }));
        }
        #endregion

        #region GUI Updates
        // Repopulate Items
        public void RepopulateItems()
        {
            if (listView.InvokeRequired) { listView.Invoke(new MethodInvoker(delegate { _RepopulateItems(); })); }
            else { _RepopulateItems(); }
        }
        public void _RepopulateItems()
        {
            listView.Items.Clear();
            for (int index = 0; index < dataManager.data.Count; index++)
            {
                AppendItem(index);
            }
        }
        // Append Items
        public void AppendItem(int index)
        {
            if (listView.InvokeRequired) { listView.Invoke(new MethodInvoker(delegate { _AppendItem(index); })); }
            else { _AppendItem(index); }
        }
        public void _AppendItem(int index)
        {
            ListViewItem item = new ListViewItem(dataManager.data[index].id.ToString("N0"));
            item.SubItems.Add(dataManager.data[index].sParameter);
            item.SubItems.Add(dataManager.data[index].sourcePower.ToString("N3"));
            item.SubItems.Add(dataManager.data[index].horizontal.ToString("N2"));
            item.SubItems.Add(dataManager.data[index].vertical.ToString("N2"));
            item.SubItems.Add(dataManager.data[index].depth.ToString("N2"));
            item.SubItems.Add(dataManager.data[index].azimuth.ToString("N2"));
            item.SubItems.Add(dataManager.data[index].elevation.ToString("N2"));
            item.SubItems.Add(dataManager.data[index].polarization.ToString("N2"));
            listView.Items.Add(item);
        }
        // Remove Items
        public void RemoveItem(int index)
        {
            if (listView.InvokeRequired) { listView.Invoke(new MethodInvoker(delegate { _RemoveItem(index); })); }
            else { _RemoveItem(index); }
        }
        public void _RemoveItem(int index)
        {
            listView.Items.RemoveAt(index);
        }
        // Clear Items
        public void ClearItems()
        {
            if (listView.InvokeRequired) { listView.Invoke(new MethodInvoker(delegate { _ClearItems(); })); }
            else { _ClearItems(); }
        }
        public void _ClearItems()
        {
            listView.Items.Clear();
        }
        #endregion

    }
}
