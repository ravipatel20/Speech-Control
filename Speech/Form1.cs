using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Speech.Recognition;
using System.Threading;
using System.IO;
using System.util;

namespace Speech
{
    public partial class SpeechControl : Form
    {
        public SpeechControl()
        {
            InitializeComponent();
            
        }

        String readText;
        TextToSpeech tts = new TextToSpeech();
        SpeechToText stt = new SpeechToText();
        public SpeechRecognitionEngine sre;
        public Thread recThread;
        public Grammar grammar;
        public List<string> ch = new List<string>();

        private void Project_Load(object sender, EventArgs e)
        {
            readFile.Enabled = false;
            SpeakButton.Enabled = false;
            ResumeButton.Enabled = false;
            ClearButton.Enabled = false;
            PauseButton.Enabled = false;

            sre = stt.sre;
            sre.SetInputToDefaultAudioDevice();
//            Cmdlist.DataSource = ch;
            
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);

            recThread = new Thread(new ThreadStart(recordVoice));
            recThread.Start();
        }


        //TEXT TO SPEECH

        private void TextToSpeechBox_TextChanged(object sender, EventArgs e)
        {
            if (this.TextToSpeechBox.Text != String.Empty)
            {
                SpeakButton.Enabled = true;
                ClearButton.Enabled = true;
            }
            else
            {
                SpeakButton.Enabled = false;
                ClearButton.Enabled = false;
            }
        }
        private void SpeakButton_Click(object sender, EventArgs e)
        {
            String speak = this.TextToSpeechBox.Text;
            SpeakButton.Enabled = false;
            PauseButton.Enabled = true;
            ClearButton.Enabled = true;
            tts.speakText(speak);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            tts.pauseSpeech();
            ResumeButton.Enabled = true;
            PauseButton.Enabled = false;
        }
        private void ResumeButton_Click(object sender, EventArgs e)
        {
            tts.resumeSpeech();
            ResumeButton.Enabled = false;
            PauseButton.Enabled = true;
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            tts.stopSpeech();
            this.TextToSpeechBox.Text = null;
            PauseButton.Enabled = false;
            ClearButton.Enabled = false;
            ResumeButton.Enabled = false;
            SpeakButton.Enabled = false;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Text Files|*.txt";
            ofd.Filter = "Text Files|*.txt|PDF Files|*.pdf";
            string filename = "";
            string path = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFileName(ofd.FileName);
                path = System.IO.Path.GetDirectoryName(ofd.FileName);
            }
            String backSlash = "\\";
            if (!path.Equals(string.Empty))
            {
                readText = path + backSlash + filename;
            }
            this.FileLoc.Text = readText;
        }

        private void readFile_Click(object sender, EventArgs e)
        {
            String text = new ReadFiles().readTextData(readText);
            tts.speakText(text);
            this.FileLoc.Text = String.Empty;
            readFile.Enabled = false;
            ResumeButton.Enabled = false;
            PauseButton.Enabled = true;
            ClearButton.Enabled = true;
        }

        private void FileLoc_TextChanged(object sender, EventArgs e)
        {
            if (this.FileLoc.Text == String.Empty)
                readFile.Enabled = false;
            else
                readFile.Enabled = true;
        }

        //SPEECH RECOGNITION
        public void recordVoice()
        {
            while (true)
            {
                try
                {
                    sre.Recognize();
                }
                catch { }
            }
        }
        
        String grammarName;
        String resultText;
        int x=0;
        private void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            this.Invoke(
                (MethodInvoker)delegate
                {
                    if (e.Result.Grammar.Name != null &&!e.Result.Grammar.Name.Equals(string.Empty))
                    {
                        grammarName = e.Result.Grammar.Name;
                        resultText = e.Result.Text; 
                    }
                    if (e.Result.Grammar.Name.Equals("Open Application Grammar"))
                    {
                        //if(e.Result.Text.Equals("notepad"))
                        //     Process.Start("");
                        while (x <= stt.i)
                        {

                            if (e.Result.Text.Equals(stt.nam[x]))
                                Process.Start(stt.add[x]);
                            x++;
                        }
                        x = 0;
                    }
                    else
                    {
                        if (SpeechToTextBox.Text == String.Empty)
                            SpeechToTextBox.Text = e.Result.Text;
                        else
                            SpeechToTextBox.Text += (" " + e.Result.Text);
                    }
                }
            );
        }
        private void SpeechControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            recThread.Abort();
            recThread = null;
        }

        private void enableDictation_Click(object sender, EventArgs e)
        {
            stt.dictationGrammar();
            sre = stt.sre;
            
            disableDictation.Enabled = true;
            enableDictation.Enabled = false;
        }

        private void disableDictation_Click(object sender, EventArgs e)
        {
            stt.controlGrammar();
            sre = stt.sre;
            
            enableDictation.Enabled = true;
            disableDictation.Enabled = false;
        }

        private void SR_Enter(object sender, EventArgs e)
        {
            
            stt.controlGrammar();
            sre = stt.sre;
            //ch.Add("Notepad");
            //ch.Add("Google Chrome");
            for (int j = 0; j < stt.i; j++)
            {
                ch.Add(stt.nam[j]);
            }
            Cmdlist.DataSource = ch;
            
        }

        private void TTS_Enter(object sender, EventArgs e)
        {
            stt.sre.UnloadAllGrammars();
            sre = stt.sre;
        }

        
        private void AddApp_Click(object sender, EventArgs e)
        {
                        
            string val=Prompt.ShowDialog();
            if (!val.Equals(""))
            {
                stt.controlGrammar();
                ch.Add(val);
                Cmdlist.DataSource = null;
                Cmdlist.DataSource = ch;
            }
           
        }
        
        private void DelApp_Click(object sender, EventArgs e)
        {
            int sel = Cmdlist.SelectedIndex;
            string temp = "";
            if (sel >= 2)
            {
                try
                {
                    temp = ch.ElementAt(sel);
                    ch.RemoveAt(sel);
                }
                catch
                { }

                string txt = "";
                int flag = 0;
                
                using (StreamReader sr = File.OpenText("abc.txt"))
                {

                    while ((txt = sr.ReadLine()) != null)
                    {
                        StringTokenizer st = new StringTokenizer(txt, "$@");
                        while (st.HasMoreTokens())
                        {
                            if (temp == st.NextToken())
                            {
                                st.NextToken();
                                flag = 1;
                            }

                        }
                        
                        if (flag == 0)
                        {
                            using (StreamWriter sw = File.AppendText("temp.txt"))
                            {
                                sw.WriteLine(txt);
                            }
                        }
                        else
                        {
                            flag = 0;
                        }

                    }
                }
                Cmdlist.DataSource = null;
                Cmdlist.DataSource = ch;

                try
                {
                    File.Delete("abc.txt");
                    File.Move("temp.txt", "abc.txt");

                    MessageBox.Show(temp);
                                    }
                catch
                {
                    MessageBox.Show("Database Empty");
                }
            }
            else
            {
                MessageBox.Show("Default Command provided by the developer and therefore cannot be deleted.");
            }
        }

        private void Save_File_Click(object sender, EventArgs e)
        {
            string path = "";
            path = prompt_2.ShowDialog();
            if (!path.Equals(""))
            {
                //path = "C:" + "\\" + "Users" + "\\" + "Ravi" + "\\" + "Documents" + "\\" + "Dictation" + "\\" + name + ".txt";
                try
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(SpeechToTextBox.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid File name or path");
                }
            }
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {

        }

        private void rateBar_Scroll(object sender, EventArgs e)
        {
            int val=this.rateBar.Value;
            tts.changeRate(val);
        }
          
    }
}
