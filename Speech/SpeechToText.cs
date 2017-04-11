using System;
using System.Speech.Recognition;
using System.IO;
using System.Windows.Forms;
using System.util;

namespace Speech
{
    class SpeechToText
    {
        //public List<string>=new List<string>();
        public Choices choices;
        public SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        public int flag = 0, i = 0;
        public String txt;
        public String[] nam = new String[20];
        public String[] add = new String[20];
        
        public void controlGrammar()
        {
           
            try { sre.UnloadAllGrammars(); }
            catch { }
            choices = new Choices(new string[] { "notepad", "mozilla firefox", "google chrome" });
            choices.Add(new string[] { "safari" });
            GrammarBuilder builder = new GrammarBuilder();
            if (File.Exists("abc.txt"))
            {
                using (StreamReader sr = File.OpenText("abc.txt"))
                {

                    while ((txt = sr.ReadLine()) != null)
                    {
                        StringTokenizer st = new StringTokenizer(txt, "$@");
                        while (st.HasMoreTokens())
                        {
                            if (flag == 0)
                            {
                                nam[i] = st.NextToken();
                                flag = 1;
                                choices.Add(nam[i]);
                            }
                            else if (flag == 1)
                            {
                                add[i++] = st.NextToken();
                                flag = 0;
                            }
                        }

                    }
                }
            }
            else 
            {
                File.CreateText("abc.txt");
            }
            builder.Append(choices);
            Grammar openApplicationGrammar = new Grammar(builder);
            openApplicationGrammar.Name = "Open Application Grammar";
            sre.LoadGrammar(openApplicationGrammar);
        }
        public void dictationGrammar()
        {
            DictationGrammar dictation = new DictationGrammar();
            dictation.Name = "Dictation Grammar";
            sre.UnloadAllGrammars();
            sre.LoadGrammar(dictation);
        }
    }
    public static class Prompt
    {
       
        public static string ShowDialog()
        {

            String nam = "", path, txt = "";
            Form prompt = new Form();
            
            prompt.Width = 500;
            prompt.Height = 150;
            //prompt.Text = caption;
            Label cmd_label = new Label() { Left = 50, Top = 22, Text = "Command Name : " };
            TextBox cmd_txt = new TextBox() { Left = 150, Top = 20, Width = 200 };
            Label path_label = new Label() { Left = 50, Top = 52, Text = "Path                   : " };
            TextBox path_txt = new TextBox() { Left = 150, Top = 50, Width = 200 };
            Button browse = new Button() { Text = "Browse", Left = 354, Width = 100, Top =49 };
            Button ok_button = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 80 };
            
            ok_button.Click += (sender, e) =>
            {
                if (cmd_txt.Text != String.Empty && path_txt.Text != String.Empty)
                {
                    //ok_button.Enabled = true;
                    nam = cmd_txt.Text;
                    path = path_txt.Text;
                    txt = "$" + nam + "@" + path;
                    using (StreamWriter sw = File.AppendText("abc.txt"))
                    {
                        sw.WriteLine(txt);

                    }
                    prompt.Close();
                }
                else
                {
                    MessageBox.Show("Fill up the empty fields");
                }
            };
            
            String readText = "";
            browse.Click += (sender, e) =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string filename = "";
                string path_temp = "";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = System.IO.Path.GetFileName(ofd.FileName);
                    path_temp = System.IO.Path.GetDirectoryName(ofd.FileName);
                }
                String backSlash = "\\";
                if (!path_temp.Equals(string.Empty))
                {
                    readText = path_temp + backSlash + filename;
                }
                path_txt.Text = readText;
            };
            
            prompt.Controls.Add(ok_button);
            prompt.Controls.Add(browse);
            prompt.Controls.Add(cmd_label);
            prompt.Controls.Add(cmd_txt);
            prompt.Controls.Add(path_label);
            prompt.Controls.Add(path_txt);
            prompt.ShowDialog();

            return nam;
        }
    }

    public static class prompt_2
    {
        public static string ShowDialog()
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            
            string path = "", filename = "";

            Label file_label = new Label() { Left = 50, Top = 22, Text = "File Name : " };
            TextBox file_txt = new TextBox() { Left = 150, Top = 20, Width = 200 };
            Label path_label = new Label() { Left = 50, Top = 52, Text = "Path                   : " };
            TextBox path_txt = new TextBox() { Left = 150, Top = 50, Width = 200 };
            Button folder = new Button() { Text = "Browse", Left = 354, Width = 100, Top = 49 };
            //Button folder = new Button() { Text="Browse", Left = 50, Top = 52 };
            Button ok_button = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 80 };
            
            ok_button.Click += (sender, e) => {

                if (file_txt.Text == String.Empty)
                {
                    MessageBox.Show("Enter a valid file name");
                }
                else
                {
                    prompt.Close();
                }    
            };

            folder.Click += (sender, e) =>
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    filename = System.IO.Path.GetFileName(fbd.SelectedPath);
                    path = System.IO.Path.GetDirectoryName(fbd.SelectedPath);
                }
                String backSlash = "\\";
                if (!path.Equals(string.Empty))
                {
                    path = path + backSlash + filename + backSlash;
                }
                path_txt.Text = path;
                                                          
            };


            prompt.Controls.Add(ok_button);
            prompt.Controls.Add(file_label);
            prompt.Controls.Add(file_txt);
            prompt.Controls.Add(folder);
            prompt.Controls.Add(path_label);
            prompt.Controls.Add(path_txt);
            prompt.ShowDialog();

            path = path + file_txt.Text;
            return path;
        }
    }
}