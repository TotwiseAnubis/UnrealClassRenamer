using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnrealClassRenamer
{
    class RenamerController
    {
        private static RenamerController instance;
        public static RenamerController Get()
        {
            if (instance == null)
            {
                instance = new RenamerController();
            }

            return instance;
        }


        private string selectedFolderURL = "";
        private string oldClassName = "";
        private string newClassName = "";
        private string oldClassNameWithoutPrefix;
        private string newClassNameWithoutPrefix;

        private Form1 form;

        public void SetForm(Form1 form)
        {
            this.form = form;

            Initialize();
        }

        private void Initialize()
        {
            string localPath = Assembly.GetEntryAssembly().Location;
            localPath = localPath.Replace("\\UnrealClassRenamer.exe", "");

            Console.WriteLine(localPath);

            if (File.Exists("UnrealClassRenamer.txt"))
            {
                TextReader tr = new StreamReader("UnrealClassRenamer.txt");
                selectedFolderURL = tr.ReadLine();
                tr.Close();
                form.SetURLLabel(selectedFolderURL);
            }
            else if (Directory.GetFiles(localPath, "*.uproject").Length != 0)
            {
                selectedFolderURL = localPath;
                form.SetURLLabel(localPath);
            }
        }

        public void OnFolderSelected(string url)
        {
            bool okURL = CheckUrl(url);

            if (okURL)
            {
                selectedFolderURL = url;
                form.SetURLLabel(url);

                TextWriter tw = new StreamWriter("savedURL.txt");
                tw.WriteLine(selectedFolderURL);
                tw.Close();
            }
        }

        private bool CheckUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Select a UE4 project folder.", "Incorrect Project Folder",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // check this is actually an UE4 project folder
            if (Directory.GetFiles(url, "*.uproject").Length == 0)
            {
                MessageBox.Show("Selected Folder Doesn't contain a .uproject file.", "Incorrect Project Folder",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        public void OnClickRename(string oldClassName, string newClassName)
        {
            // -- double check the selected folder is right
            if (!CheckUrl(selectedFolderURL))
                return;

            //--- check class names
            if (!CheckClassName(oldClassName, true))
                return;
            if (!CheckClassName(newClassName, false))
                return;

            if (!CheckNamesAreDifferent(oldClassName, newClassName))
                return;

            if (!CheckProjectFolderIsOkay())
                return;

            this.oldClassName = oldClassName;
            this.newClassName = newClassName;
            oldClassNameWithoutPrefix = oldClassName.Substring(1);
            newClassNameWithoutPrefix = newClassName.Substring(1);

            var confirmResult = MessageBox.Show("CLOSE UNREAL AND VISUAL STUDIO BEFORE CLICKING YES!!!!",
                                     "IMPORTANT WARNING!!",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                RenameClasses();
            }
        }

        private bool CheckNamesAreDifferent(string oldClassName, string newClassName)
        {
            if(string.Compare(oldClassName, newClassName) == 0)
            {
                MessageBox.Show("Both Class names are the same", "Incorrect Class Names",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckProjectFolderIsOkay()
        {
            // check this is actually an UE4 project folder
            if (!Directory.Exists(selectedFolderURL + "\\Source\\"))
            {
                MessageBox.Show("This project doesn't contain a Source Folder!!", "Incorrect Project Folder",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private bool CheckClassName(string className, bool isOldName)
        {
            string labelClass = isOldName ? "OldClassName" : "NewClassName";

            if (string.IsNullOrEmpty(className))
            {
                string errorMessage = "<{0}> is empty. Please put a valid class name.";

                MessageBox.Show(string.Format(errorMessage, labelClass), "Incorrect Class Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            char firstLetter = className[0];

            char[] acceptedFirstLetters = new char[] {'F', 'A', 'U' };

            if (!acceptedFirstLetters.Contains(firstLetter))
            {
                string errorMessage = "<{0}> must begin with capital F, A or U.";

                MessageBox.Show(string.Format(errorMessage, labelClass), "Incorrect Class Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void RenameClasses()
        {
            RenameSourceFiles();
            FixConfigFile();
            RegenerateFolders();
            MessageBox.Show("Finished!", "Class Renamed", MessageBoxButtons.OK);

            Application.Exit();
        }

        private void RegenerateFolders()
        {
            //----- CLEAN UP

            List<string> directoriesToDelete = new List<string>()
            {
                "\\.vs\\",
                "\\.vscode\\",
                "\\Binaries\\",
                "\\Intermediate\\",
                "\\Saved\\"
            };

            directoriesToDelete.ForEach(d => 
            {
                if (Directory.Exists(selectedFolderURL + d))
                    Directory.Delete(selectedFolderURL + d, true);
            });

            List<string> vsFiles = Directory.GetFiles(selectedFolderURL, "*.sln", SearchOption.TopDirectoryOnly).ToList();
            vsFiles.AddRange(Directory.GetFiles(selectedFolderURL, "*.code-workspace", SearchOption.TopDirectoryOnly).ToList());

            vsFiles.ForEach(f =>
            {
                File.Delete(f);
            });

            ///------- REGENERATION
            string[] uprojectFile = Directory.GetFiles(selectedFolderURL, "*.uproject", SearchOption.TopDirectoryOnly);
            string uprojectFilePath = uprojectFile[0];

            string regenerateCommandLine = Registry.GetValue(@"HKEY_CLASSES_ROOT\\Unreal.ProjectFile\\shell\\rungenproj\\command", "", "ERROR").ToString();
            regenerateCommandLine = regenerateCommandLine.Replace("%1", uprojectFilePath);
            // regenerateCommandLine = regenerateCommandLine.Replace("\"", "");

            string commandToExecute = regenerateCommandLine.Split(new string[] { "/projectfiles"}, StringSplitOptions.None)[0];
            string commandArguments = "/projectfiles" + regenerateCommandLine.Split(new string[] { "/projectfiles" }, StringSplitOptions.None)[1];

            Console.WriteLine("full: " + regenerateCommandLine);
            Console.WriteLine("command:  " + commandToExecute);
            Console.WriteLine("arg:  " + commandArguments);

            var psi = new ProcessStartInfo(@regenerateCommandLine)
            {
                UseShellExecute = false,
                CreateNoWindow = false
            };
            Process.Start(psi);

        }

        private void FixConfigFile()
        {
            string configFolder = selectedFolderURL + "\\Config\\";

            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            string configFilePath = configFolder + "DefaultEngine.ini";

            if (!File.Exists(configFilePath))
            {
                FileStream st = File.Create(configFilePath);
                st.Close();                
            }

            string sectionHeader = "[/Script/Engine.Engine]";
            string redictorString = "+ActiveClassRedirects=(OldClassName=\"{0}\",NewClassName=\"{1}\")";
            redictorString = string.Format(redictorString, oldClassNameWithoutPrefix, newClassNameWithoutPrefix);

            string text = File.ReadAllText(configFilePath);
            string resultantFileText = "";

            // -- if the class was already renamed in the past
            if (text.Contains("NewClassName=\"" + oldClassNameWithoutPrefix + "\")"))
            {
                resultantFileText = text.Replace("NewClassName=\"" + oldClassNameWithoutPrefix + "\")",
                             "NewClassName=\"" + newClassNameWithoutPrefix + "\")");
            }
            else
            {
                List<string> allLines = text.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();

                List<string> resultantTextLines = new List<string>();

                bool wasAdded = false;

                allLines.ForEach(line =>
                {
                    resultantTextLines.Add(line);

                    if (line.Trim() == sectionHeader)
                    {
                        resultantTextLines.Add(redictorString);
                        wasAdded = true;
                    }
                });

                if (!wasAdded)
                {
                    resultantTextLines.Add(sectionHeader);
                    resultantTextLines.Add(redictorString);
                }

                resultantFileText = string.Join(System.Environment.NewLine, resultantTextLines.ToArray());
            }
            
            File.WriteAllText(configFilePath, resultantFileText);
        }

        private void RenameSourceFiles()
        {
            //---- Rename all stuff in Source Folder
            string sourceFolder = selectedFolderURL + "\\Source\\";

            string[] allCPPFiles = Directory.GetFiles(sourceFolder, "*.cpp", SearchOption.AllDirectories);
            string[] allHFiles = Directory.GetFiles(sourceFolder, "*.h", SearchOption.AllDirectories);

            

            allHFiles.ToList().ForEach(st =>
            {
                string text = File.ReadAllText(st);
                text = text.Replace(oldClassNameWithoutPrefix, newClassNameWithoutPrefix);
                File.WriteAllText(st, text);

                string currentFileName = Path.GetFileName(st);
                if (currentFileName == oldClassNameWithoutPrefix + ".h")
                {
                    string newFileName = st.Replace(oldClassNameWithoutPrefix, newClassNameWithoutPrefix);
                    System.IO.File.Move(st, newFileName);
                }
            });

            allCPPFiles.ToList().ForEach(st =>
            {
                string text = File.ReadAllText(st);
                text = text.Replace(oldClassNameWithoutPrefix, newClassNameWithoutPrefix);
                File.WriteAllText(st, text);

                string currentFileName = Path.GetFileName(st);
                if (currentFileName == oldClassNameWithoutPrefix + ".cpp")
                {
                    string newFileName = st.Replace(oldClassNameWithoutPrefix, newClassNameWithoutPrefix);
                    System.IO.File.Move(st, newFileName);
                }
            });
        }


    }
}
