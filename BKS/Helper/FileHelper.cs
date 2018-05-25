using BKS.DataModel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BKS.Helper
{
    public class FileHelper<TEntity>  where TEntity : class, IEntity
    {
        public char seperator = ';';
        public string dateFormat = "yyyy-MM-dd H:mm:ss";

        
        private GridControl grdCtrl { get; set; }
        private GridView grdView { get; set; }

        public FileHelper(GridControl grdCtrl)
        {
            this.grdCtrl = grdCtrl;
            this.grdView = grdCtrl.MainView as GridView;
        }


        public Func<TEntity, string> GetTextHeader { get; set; }
        public Func<TEntity, string> GetTextData { get; set; }

        public Func<string, TEntity> ParseTextData { get; set; }

        public void ExportFile()
        {
            SaveFileDialog saveDlg = new SaveFileDialog();

            saveDlg.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDlg.RestoreDirectory = true;

            if (saveDlg.ShowDialog() != DialogResult.OK)
                return;

            Stream stream = saveDlg.OpenFile();

            if (stream == null)
                return;

            int rwCnt = this.grdView.RowCount;

            Action<BackroundProcessArg> method = (arg) =>
            {
                arg.SetMaximum(rwCnt);

                StreamWriter streamwriter = new StreamWriter(stream);

                bool IsHeaderWriter = false;

                for (int index = 0; index < rwCnt; index++)
                {
                    TEntity entity = null;

                    this.grdCtrl.SafeInvoke(() => entity = (TEntity)this.grdView.GetRow(index), true);

                    #region Header

                    if (!IsHeaderWriter)
                    {
                        string columns = this.GetTextHeader(entity);
                        streamwriter.WriteLine(columns);
                        IsHeaderWriter = true;
                    }

                    #endregion

                    string data = this.GetTextData(entity);
                    streamwriter.WriteLine(data);

                    //Update Progress
                    arg.UpdateProgress();
                }

                streamwriter.Close();
                stream.Close();

                streamwriter.Dispose();
                stream.Dispose();
            };

            BackroundProcess.ShowAction(Messages.FileHelper_Export, method);
        }

        public void ImportFile()
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDlg.RestoreDirectory = true;
            openDlg.Multiselect = false;

            if (openDlg.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openDlg.FileName;

            if (string.IsNullOrEmpty(filePath))
                return;


            Action<BackroundProcessArg> method = (arg) =>
            {
                string[] lines = File.ReadAllLines(filePath);

                int lineCnt = lines.Length;

                arg.SetMaximum(lineCnt);

                bool IsHeaderReader = false;

                for (int index = 0; index < lineCnt; index++)
                {
                    if (!IsHeaderReader)
                    {
                        IsHeaderReader = true;
                        continue;
                    }

                    TEntity entity = this.ParseTextData(lines[index]);

                    if (entity==null)
                        continue;

                    string ex_message = "";
                    bool IsValid = ((IEntity)entity).Validate(out ex_message);

                    if (!IsValid)
                        continue;

                    this.grdCtrl.SafeInvoke(() => BKSEntities.DataContext.Add<TEntity>(entity) , true);
                    
                    BKSEntities.DataContext.SaveChanges();
                    

                    //Update Progress
                    arg.UpdateProgress();
                }


            };

            BackroundProcess.ShowAction(Messages.FileHelper_Import, method);
        }

        public string TextEncoding(string data)
        {
            if (string.IsNullOrEmpty(data))
                return data;

            return data.Replace(System.Environment.NewLine, " ").Replace(";", " ");
        }
       
    }
}
