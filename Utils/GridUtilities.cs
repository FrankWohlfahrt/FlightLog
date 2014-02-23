using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Utilities.Grids {

    public class GridUtils {

        /// <summary>
        /// set autosizemode for column to fill
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="AutoSizeColumnIdx"></param>
        private static void adjustColumnSizeToAutoFill(DataGridView gridview, int AutoSizeColumnIdx) {
            gridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if ((AutoSizeColumnIdx >= 0) & (AutoSizeColumnIdx < gridview.Columns.Count)) {
                gridview.Columns[AutoSizeColumnIdx].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            gridview.Update();
        }

        /// <summary>
        /// get the index of a column
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="AutoSizeColumnName"></param>
        /// <returns></returns>
        public static int getIndexOfColumnName(DataGridView gridview, String AutoSizeColumnName) {
            int idx = -1;
            foreach (DataGridViewColumn dgc in gridview.Columns) {
                if (dgc.DataPropertyName.Equals(AutoSizeColumnName)) {
                    idx = dgc.Index;
                    break;
                }
            }
            return idx;
        }

        /// <summary>
        /// get the index of the currently selected row
        /// </summary>
        /// <param name="gridview"></param>
        /// <returns></returns>
        public static int getSelectedRowIdx(DataGridView gridview) {
            int res = -1;
            if (null != gridview.SelectedRows) {
                if (gridview.SelectedRows.Count > 0) {
                    res = gridview.SelectedRows[0].Index;
                }
            }
            return res;
        }

        /// <summary>
        /// initialise the datagrid according to our needs
        /// and set row height
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="AutoSizeColumnIdx"></param>
        public static void InitialiseDataGridView(DataGridView gridview, int AutoSizeColumnIdx = -1, int iRowHeight = 0) {
            gridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridview.MultiSelect = false;
            gridview.RowHeadersVisible = false;
            gridview.EditMode = DataGridViewEditMode.EditProgrammatically;
            gridview.AllowUserToAddRows = false;
            gridview.AllowUserToDeleteRows = false;
            gridview.AllowUserToOrderColumns = false;
            gridview.AllowUserToResizeColumns = false;
            gridview.AllowUserToResizeRows = false;
            gridview.Visible = true;

            adjustColumnSizeToAutoFill(gridview, AutoSizeColumnIdx);

            if (iRowHeight > 0) {
                gridview.RowTemplate.Height = iRowHeight;
                gridview.RowTemplate.MinimumHeight = iRowHeight;
            }
        }

        /// <summary>
        /// initialise the datagrid according to our needs
        /// and set row height
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="AutoSizeColumnName"></param>
        /// <param name="iRowHeight"></param>
        public static void InitialiseDataGridView(DataGridView gridview, String AutoSizeColumnName, int iRowHeight = 0) {
            int idx = getIndexOfColumnName(gridview, AutoSizeColumnName);
            InitialiseDataGridView(gridview, idx, iRowHeight);
        }

        /// <summary>
        /// update the datasource
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="list"></param>
        /// <param name="visibleColumns"></param>
        private static void updateDataSource(DataGridView gridview, object list, List<String> visibleColumns) {
            int displayIdx = gridview.FirstDisplayedScrollingRowIndex;
            int selIdx = getSelectedRowIdx(gridview);

            gridview.SuspendLayout();
            BindingSource source = new BindingSource();
            source.DataSource = list;
            gridview.DataSource = source;
            if (null != visibleColumns) {
                foreach (DataGridViewColumn dgc in gridview.Columns) {
                    dgc.Visible = visibleColumns.Contains(dgc.DataPropertyName);
                }
            }

            if ((displayIdx >= 0) && (displayIdx < gridview.Rows.Count)) {
                gridview.FirstDisplayedScrollingRowIndex = displayIdx;
            }
            if ((selIdx >= 0) && (selIdx < gridview.Rows.Count)) {
                gridview.Rows[selIdx].Selected = true;
                gridview.CurrentCell = gridview.Rows[selIdx].Cells[0];
            }
            gridview.ResumeLayout();
        }

        /// <summary>
        /// update the datasource of a grid and try to keep the marked line and scrolling position
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="list"></param>
        /// <param name="visibleColumns"></param>
        /// <param name="AutoSizeColumnName"></param>
        public static void updateDataSourceKeepPosition(DataGridView gridview, object list, List<String> visibleColumns = null, String AutoSizeColumnName = "", int iRowHeight = 0) {
            updateDataSource(gridview, list, visibleColumns);
            int idx = getIndexOfColumnName(gridview, AutoSizeColumnName);
            InitialiseDataGridView(gridview, idx, iRowHeight);
        }

        /// <summary>
        /// update the datasource of a grid and try to keep the marked line and scrolling position
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="source"></param>
        public static void updateDataSourceKeepPosition(DataGridView gridview, object list, List<String> visibleColumns = null, int AutoSizeColumnIdx = -1, int iRowHeight = 0) {
            updateDataSource(gridview, list, visibleColumns);
            InitialiseDataGridView(gridview, AutoSizeColumnIdx, iRowHeight);
        }
  
        /// <summary>
        /// init a grid
        /// </summary>
        /// <param name="grid"></param>
        public static void initDataGrid(DataGridView grid) {
            // Default settings
            bool bColumnHeader      = false;
            bool bUserResizeColumns = false;
            List<int> AutoSizeColumnsList = null;
            initDataGrid(grid, bColumnHeader, bUserResizeColumns, AutoSizeColumnsList);
        }

        /// <summary>
        /// init a grid
        /// </summary>
        /// <param name="grid"></param>
        public static void initDataGrid(DataGridView grid, bool bColumnHeader, bool bUserResizeColumns, List<int> AutoSizeColumnsList) {
            grid.ColumnHeadersVisible = bColumnHeader;
            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeColumns = bUserResizeColumns;
            grid.AllowUserToResizeRows = false;
            // Autosize for one column?
            if (AutoSizeColumnsList != null && AutoSizeColumnsList.Count > 0) {
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                foreach (int iIdx in AutoSizeColumnsList) {
                    grid.Columns[iIdx].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            else {
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            grid.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            grid.RowTemplate.Height = 30;
            grid.RowTemplate.MinimumHeight = 30;
            grid.RowTemplate.ReadOnly = true;
        }

        /// <summary>
        /// get object bound to current row as data item, will be null if no row is selected
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static object getDataBoundItem(DataGridView grid) {
            object item = null;

            if (null != grid) {
                if (null != grid.CurrentRow) {
                    item = grid.CurrentRow.DataBoundItem;
                }
            }

            return item;
        }

        /// <summary>
        /// create a new row and add it to the table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        public static void addRow(DataTable table, params String[] cols) {
            DataRow row;
            row = table.NewRow();
            row.BeginEdit();
            int maxcol = row.Table.Columns.Count;
            for (int i = 0; i < cols.Length; i++) {
                if (i < maxcol) {
                    row[i] = cols[i];
                }
            }
            row.EndEdit();
            table.Rows.Add(row);
        }

        /// <summary>
        /// add a column to the table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="colName"></param>
        public static void addColumn(DataTable table, String colName)
        {
            DataColumn col = new DataColumn();
            col.Caption = colName;
            col.ColumnName = colName;
            table.Columns.Add(col);
        }

        /// <summary>
        /// add a column to the table for each string in the list
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        public static void addColumns(DataTable table, List<String> columns)
        {
            foreach (String col in columns)
            {
                addColumn(table, col);
            }
        }
        
    }
}
