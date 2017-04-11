namespace Speech
{
    partial class SpeechControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeechControl));
            this.SR = new System.Windows.Forms.TabPage();
            this.DelApp = new System.Windows.Forms.Button();
            this.Cmdlist = new System.Windows.Forms.ListBox();
            this.Save_File = new System.Windows.Forms.Button();
            this.AddApp = new System.Windows.Forms.Button();
            this.disableDictation = new System.Windows.Forms.Button();
            this.enableDictation = new System.Windows.Forms.Button();
            this.SpeechToTextBox = new System.Windows.Forms.TextBox();
            this.TTS = new System.Windows.Forms.TabPage();
            this.rateBar = new System.Windows.Forms.TrackBar();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.RateLabel = new System.Windows.Forms.Label();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.readFile = new System.Windows.Forms.Button();
            this.FileLoc = new System.Windows.Forms.TextBox();
            this.TextToSpeechBox = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.SpeakButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.SR.SuspendLayout();
            this.TTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // SR
            // 
            this.SR.BackColor = System.Drawing.Color.LightGray;
            this.SR.Controls.Add(this.DelApp);
            this.SR.Controls.Add(this.Cmdlist);
            this.SR.Controls.Add(this.Save_File);
            this.SR.Controls.Add(this.AddApp);
            this.SR.Controls.Add(this.disableDictation);
            this.SR.Controls.Add(this.enableDictation);
            this.SR.Controls.Add(this.SpeechToTextBox);
            resources.ApplyResources(this.SR, "SR");
            this.SR.Name = "SR";
            this.SR.Enter += new System.EventHandler(this.SR_Enter);
            // 
            // DelApp
            // 
            resources.ApplyResources(this.DelApp, "DelApp");
            this.DelApp.Name = "DelApp";
            this.DelApp.UseVisualStyleBackColor = true;
            this.DelApp.Click += new System.EventHandler(this.DelApp_Click);
            // 
            // Cmdlist
            // 
            this.Cmdlist.FormattingEnabled = true;
            resources.ApplyResources(this.Cmdlist, "Cmdlist");
            this.Cmdlist.Name = "Cmdlist";
            // 
            // Save_File
            // 
            resources.ApplyResources(this.Save_File, "Save_File");
            this.Save_File.Name = "Save_File";
            this.Save_File.UseVisualStyleBackColor = true;
            this.Save_File.Click += new System.EventHandler(this.Save_File_Click);
            // 
            // AddApp
            // 
            resources.ApplyResources(this.AddApp, "AddApp");
            this.AddApp.Name = "AddApp";
            this.AddApp.UseVisualStyleBackColor = true;
            this.AddApp.Click += new System.EventHandler(this.AddApp_Click);
            // 
            // disableDictation
            // 
            resources.ApplyResources(this.disableDictation, "disableDictation");
            this.disableDictation.Name = "disableDictation";
            this.disableDictation.UseVisualStyleBackColor = true;
            this.disableDictation.Click += new System.EventHandler(this.disableDictation_Click);
            // 
            // enableDictation
            // 
            resources.ApplyResources(this.enableDictation, "enableDictation");
            this.enableDictation.Name = "enableDictation";
            this.enableDictation.UseVisualStyleBackColor = true;
            this.enableDictation.Click += new System.EventHandler(this.enableDictation_Click);
            // 
            // SpeechToTextBox
            // 
            resources.ApplyResources(this.SpeechToTextBox, "SpeechToTextBox");
            this.SpeechToTextBox.Name = "SpeechToTextBox";
            // 
            // TTS
            // 
            this.TTS.BackColor = System.Drawing.Color.LightGray;
            this.TTS.Controls.Add(this.rateBar);
            this.TTS.Controls.Add(this.volumeBar);
            this.TTS.Controls.Add(this.RateLabel);
            this.TTS.Controls.Add(this.VolumeLabel);
            this.TTS.Controls.Add(this.ClearButton);
            this.TTS.Controls.Add(this.ResumeButton);
            this.TTS.Controls.Add(this.PauseButton);
            this.TTS.Controls.Add(this.readFile);
            this.TTS.Controls.Add(this.FileLoc);
            this.TTS.Controls.Add(this.TextToSpeechBox);
            this.TTS.Controls.Add(this.browse);
            this.TTS.Controls.Add(this.SpeakButton);
            resources.ApplyResources(this.TTS, "TTS");
            this.TTS.Name = "TTS";
            this.TTS.Enter += new System.EventHandler(this.TTS_Enter);
            // 
            // rateBar
            // 
            resources.ApplyResources(this.rateBar, "rateBar");
            this.rateBar.Minimum = -10;
            this.rateBar.Name = "rateBar";
            this.rateBar.Scroll += new System.EventHandler(this.rateBar_Scroll);
            // 
            // volumeBar
            // 
            resources.ApplyResources(this.volumeBar, "volumeBar");
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Value = 50;
            this.volumeBar.Scroll += new System.EventHandler(this.volumeBar_Scroll);
            // 
            // RateLabel
            // 
            resources.ApplyResources(this.RateLabel, "RateLabel");
            this.RateLabel.Name = "RateLabel";
            // 
            // VolumeLabel
            // 
            resources.ApplyResources(this.VolumeLabel, "VolumeLabel");
            this.VolumeLabel.Name = "VolumeLabel";
            // 
            // ClearButton
            // 
            resources.ApplyResources(this.ClearButton, "ClearButton");
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ResumeButton
            // 
            resources.ApplyResources(this.ResumeButton, "ResumeButton");
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // PauseButton
            // 
            resources.ApplyResources(this.PauseButton, "PauseButton");
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // readFile
            // 
            resources.ApplyResources(this.readFile, "readFile");
            this.readFile.Name = "readFile";
            this.readFile.UseVisualStyleBackColor = true;
            this.readFile.Click += new System.EventHandler(this.readFile_Click);
            // 
            // FileLoc
            // 
            resources.ApplyResources(this.FileLoc, "FileLoc");
            this.FileLoc.Name = "FileLoc";
            this.FileLoc.ReadOnly = true;
            this.FileLoc.TextChanged += new System.EventHandler(this.FileLoc_TextChanged);
            // 
            // TextToSpeechBox
            // 
            resources.ApplyResources(this.TextToSpeechBox, "TextToSpeechBox");
            this.TextToSpeechBox.Name = "TextToSpeechBox";
            this.TextToSpeechBox.TextChanged += new System.EventHandler(this.TextToSpeechBox_TextChanged);
            // 
            // browse
            // 
            resources.ApplyResources(this.browse, "browse");
            this.browse.Name = "browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // SpeakButton
            // 
            resources.ApplyResources(this.SpeakButton, "SpeakButton");
            this.SpeakButton.Name = "SpeakButton";
            this.SpeakButton.UseVisualStyleBackColor = true;
            this.SpeakButton.Click += new System.EventHandler(this.SpeakButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TTS);
            this.TabControl.Controls.Add(this.SR);
            resources.ApplyResources(this.TabControl, "TabControl");
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            // 
            // SpeechControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.TabControl);
            this.Name = "SpeechControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpeechControl_FormClosing);
            this.Load += new System.EventHandler(this.Project_Load);
            this.SR.ResumeLayout(false);
            this.SR.PerformLayout();
            this.TTS.ResumeLayout(false);
            this.TTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rateBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage SR;
        private System.Windows.Forms.TextBox SpeechToTextBox;
        private System.Windows.Forms.TabPage TTS;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button readFile;
        private System.Windows.Forms.TextBox FileLoc;
        private System.Windows.Forms.TextBox TextToSpeechBox;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Button SpeakButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button enableDictation;
        private System.Windows.Forms.Button disableDictation;
        private System.Windows.Forms.Button AddApp;
        private System.Windows.Forms.Button Save_File;
        private System.Windows.Forms.ListBox Cmdlist;
        private System.Windows.Forms.Button DelApp;
        private System.Windows.Forms.TrackBar rateBar;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label RateLabel;
        private System.Windows.Forms.Label VolumeLabel;



    }
}

