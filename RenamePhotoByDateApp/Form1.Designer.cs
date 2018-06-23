namespace RenamePhotoByDateApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBoxSaveOldVersions = new System.Windows.Forms.CheckBox();
            this.buttonSelectPath = new System.Windows.Forms.Button();
            this.labelSort = new System.Windows.Forms.Label();
            this.buttonStartRename = new System.Windows.Forms.Button();
            this.radioButtonDescending = new System.Windows.Forms.RadioButton();
            this.radioButtonAsc = new System.Windows.Forms.RadioButton();
            this.labelSelectedPath = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // checkBoxSaveOldVersions
            // 
            this.checkBoxSaveOldVersions.AutoSize = true;
            this.checkBoxSaveOldVersions.Checked = true;
            this.checkBoxSaveOldVersions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveOldVersions.Location = new System.Drawing.Point(12, 68);
            this.checkBoxSaveOldVersions.Name = "checkBoxSaveOldVersions";
            this.checkBoxSaveOldVersions.Size = new System.Drawing.Size(188, 21);
            this.checkBoxSaveOldVersions.TabIndex = 0;
            this.checkBoxSaveOldVersions.Text = "Save files with old names";
            this.checkBoxSaveOldVersions.UseVisualStyleBackColor = true;
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.Size = new System.Drawing.Size(89, 23);
            this.buttonSelectPath.TabIndex = 1;
            this.buttonSelectPath.Text = "Select path";
            this.buttonSelectPath.UseVisualStyleBackColor = true;
            this.buttonSelectPath.Click += new System.EventHandler(this.buttonSelectPath_Click);
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Location = new System.Drawing.Point(12, 102);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(169, 17);
            this.labelSort.TabIndex = 2;
            this.labelSort.Text = "Sort by photo created on:";
            // 
            // buttonStartRename
            // 
            this.buttonStartRename.Location = new System.Drawing.Point(12, 183);
            this.buttonStartRename.Name = "buttonStartRename";
            this.buttonStartRename.Size = new System.Drawing.Size(89, 33);
            this.buttonStartRename.TabIndex = 3;
            this.buttonStartRename.Text = "Start!";
            this.buttonStartRename.UseVisualStyleBackColor = true;
            this.buttonStartRename.Click += new System.EventHandler(this.buttonStartRename_Click);
            // 
            // radioButtonDescending
            // 
            this.radioButtonDescending.AutoSize = true;
            this.radioButtonDescending.Location = new System.Drawing.Point(12, 144);
            this.radioButtonDescending.Name = "radioButtonDescending";
            this.radioButtonDescending.Size = new System.Drawing.Size(183, 21);
            this.radioButtonDescending.TabIndex = 4;
            this.radioButtonDescending.TabStop = true;
            this.radioButtonDescending.Text = "Descending (newer first)";
            this.radioButtonDescending.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsc
            // 
            this.radioButtonAsc.AutoSize = true;
            this.radioButtonAsc.Checked = true;
            this.radioButtonAsc.Location = new System.Drawing.Point(12, 122);
            this.radioButtonAsc.Name = "radioButtonAsc";
            this.radioButtonAsc.Size = new System.Drawing.Size(168, 21);
            this.radioButtonAsc.TabIndex = 5;
            this.radioButtonAsc.TabStop = true;
            this.radioButtonAsc.Text = "Ascending (older first)";
            this.radioButtonAsc.UseVisualStyleBackColor = true;
            // 
            // labelSelectedPath
            // 
            this.labelSelectedPath.AutoSize = true;
            this.labelSelectedPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectedPath.Location = new System.Drawing.Point(12, 38);
            this.labelSelectedPath.Name = "labelSelectedPath";
            this.labelSelectedPath.Size = new System.Drawing.Size(21, 15);
            this.labelSelectedPath.TabIndex = 6;
            this.labelSelectedPath.Text = "C:/";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(107, 201);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(125, 15);
            this.progressBar.TabIndex = 7;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProgress.Location = new System.Drawing.Point(107, 183);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 15);
            this.labelProgress.TabIndex = 8;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 226);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelSelectedPath);
            this.Controls.Add(this.radioButtonAsc);
            this.Controls.Add(this.radioButtonDescending);
            this.Controls.Add(this.buttonStartRename);
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.buttonSelectPath);
            this.Controls.Add(this.checkBoxSaveOldVersions);
            this.Name = "Form1";
            this.Text = "Rename photos from diffetent devices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox checkBoxSaveOldVersions;
        private System.Windows.Forms.Button buttonSelectPath;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.Button buttonStartRename;
        private System.Windows.Forms.RadioButton radioButtonDescending;
        private System.Windows.Forms.RadioButton radioButtonAsc;
        private System.Windows.Forms.Label labelSelectedPath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

