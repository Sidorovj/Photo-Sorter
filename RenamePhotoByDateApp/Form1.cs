using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Recognizers.Text.DateTime;
using System.Threading;

namespace RenamePhotoByDateApp
{
    /// TODO: Записывать в лог: потр. время, сумм. объем файлов, - передавать по инету на сервак для статы
    /// Распараллелить
    /// Настройка выбора расширений изображений
    /// !Сделать парсилку даты из названия 
    /// Автонастройка ширины LabelSelectedPath_SizeChanged
    /// учесть ограничение на объем оперативки
    /// 
    /// Done: Оптимизировать на перехват исключений
    /// 
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        private int _initialFormWidth = -1;
        private const int BorderLabelWidth = 5;

        public Form1()
        {
            InitializeComponent();
            labelSelectedPath.SizeChanged += LabelSelectedPath_SizeChanged;
            _initialFormWidth = Form1.ActiveForm.Width;
            progressBar.Maximum = 100;
            progressBar.Step = 1;
            progressBar.Value = 0;
        }

        private void LabelSelectedPath_SizeChanged(object sender, EventArgs e)
        {
            //int lblAllWidth = labelSelectedPath.Width + BorderLabelWidth + labelSelectedPath.Left;
            //ActiveForm.Width = _initialFormWidth < lblAllWidth ? lblAllWidth : _initialFormWidth;
        }

        private void buttonStartRename_Click(object sender, EventArgs e)
        {
            if (labelSelectedPath.Text == "C:/")
            {
                if (MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
                    return;
            }
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            labelSelectedPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ImageRenamer ir = new ImageRenamer(labelSelectedPath.Text);
            (new Thread(() =>
            {
                while (ir.FilesCount == 0)
                    Thread.Sleep(10);
                while (ir.Progress != ir.FilesCount)
                {
                    try
                    {
                        backgroundWorker.ReportProgress(ir.Progress * 100 / ir.FilesCount);
                    }
                    catch (InvalidOperationException)
                    {
                        return;
                    }
                    labelProgress.Invoke((MethodInvoker)delegate { labelProgress.Text = $"Done {ir.Progress} of {ir.FilesCount}"; });
                    Thread.Sleep(50);
                }
            })).Start();
            ir.RenameInFolder(radioButtonAsc.Checked, checkBoxSaveOldVersions.Checked);
            backgroundWorker.ReportProgress(100);
            labelProgress.Invoke((MethodInvoker)delegate { labelProgress.Text = $"Done {ir.FilesCount} files"; });
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
