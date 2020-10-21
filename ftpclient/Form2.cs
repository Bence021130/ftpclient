using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
namespace ftpclient
{
    public partial class Form2 : Form
    {
        string original_address = Form1.address;
        public static string actual_address = Form1.address;
        string previous_next;
        string previous;
        string back;
        int szam;
        int talalt;
        bool feltoltve = false;
        bool letoltve = false;
        public OpenFileDialog choofdlog = new OpenFileDialog();
        int click = 0;
        int curr_Upload = 0;
        int currDown = 0;


        //private int progressBarMax = 0;
        private int progMaxUp = 0;
        private int progMaxDown = 0;
        private int progMaxRecDown = 0;
        private int progMaxRecUp = 0;

        


        public static string newFolderName;
        string localPath;
        string downloadUrl;
        int szamlalo = 0;
        int currUp = 0;
        bool isFolderCreated = false;

        List<String> listItems = new List<String>();
        List<String> listOfUploadItems = new List<String>();

        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            original_address = "";
            actual_address = "";
            previous_next = "";
            previous = "";
            Form1.address = "";
            Form1.user = "";
            Form1.pass = "";
            click = 0;
            Form1 frm2 = new Form1();
            frm2.Show();
            Close();

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            root();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            root();
        }
        public void root()
        {
            // Cím:
            this.Text = "FTP - csatlakozva   -     " + original_address;
            //FÁJLOK KILISTÁZÁSA!!!!
            click = 0;
            listBox1.Items.Clear();
            FtpWebRequest Request = (FtpWebRequest)WebRequest.Create(original_address);
            Request.Method = WebRequestMethods.Ftp.ListDirectory;
            Request.Credentials = new NetworkCredential(Form1.user, Form1.pass);
            FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();
            Stream ResponseStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(ResponseStream);
            listBox1.Items.Add(Response.WelcomeMessage);
            listBox1.Items.Add("A célkönyvtárban található fájlok: ");

            while (!Reader.EndOfStream)//Read file name   
            {
                listBox1.Items.Add(Reader.ReadLine().ToString());
            }
            Response.Close();
            ResponseStream.Close();
            Reader.Close();
            Request = null;
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //NAVIGÁCIÓ A MAPPÁK KÖZÖTT
            if (listBox1.SelectedItem.ToString() == "<- Vissza")
            {
                szam = 0;
                for (int i = 0; i < actual_address.Length; i++)
                {
                    if (actual_address[i] == '/')
                    {
                        talalt = i;
                        szam++;
                    }
                }
                back = "";
                for (int i = 0; i < talalt; i++)
                {
                    back += actual_address[i];
                }
                actual_address = back;
                if (back == original_address)
                {
                    //MessageBox.Show("ROOT");
                    root();
                }
                else
                {
                    listazas(back);
                    click--;
                }
                
                for (int i = 0; i < actual_address.Length; i++)
                {
                    if (actual_address[i] == '/')
                    {
                        talalt = i;
                        szam++;
                    }
                }
                back = "";
                for (int i = 0; i < talalt; i++)
                {
                    back += actual_address[i];
                }
                previous_next = back;
                return;
            }

            click++;
            switch (click)
            {
                case 1:
                    actual_address = original_address + "/" + listBox1.SelectedItem;
                    previous_next = actual_address;
                    break;
                case 2:
                    Form1.address = original_address;
                    actual_address = Form1.address + "/" + listBox1.SelectedItem;
                    break;
            }
            if (click > 2)
            {
                actual_address = previous_next + "/" + listBox1.SelectedItem;
                previous = listBox1.SelectedItem.ToString();
                previous_next += "/";
                for (int i = 0; i < previous.Length; i++)
                {
                    if (previous[i] != '/') previous_next += previous[i];
                    else break;
                }
            }
            listazas(actual_address);
        }
        public void listazas(string be)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("<- Vissza");
            List<string> files = new List<string>();
            try
            {
                //Create FTP request
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(be);

                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(Form1.user, Form1.pass);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                while (!reader.EndOfStream)
                {
                    //Application.DoEvents();
                    files.Add(reader.ReadLine());
                }

                //Clean-up
                reader.Close();
                responseStream.Close(); //redundant
                response.Close();
                //actual_address = "";
            }
            catch
            {
                root();
                MessageBox.Show("Ilyen könyvtár nem létezik, vagy nincs jogosultsága hozzáférni.");
                return;
            }
            //If the list was successfully received, display it to the user
            //through a dialog
            if (files.Count != 0)
            {
                foreach (string file in files)
                {
                    listBox1.Items.Add(file);
                }
            }


            this.Text = this.Text = "FTP - csatlakozva   -     " + actual_address;


            if (listBox1.Items.Count == 1)
            {
                listBox1.Items.Add("Ebben a mappában nem található semmi!");
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
        private void gyökérkönyvtárbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            root();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            isFolderCreated = false;
            folderCreate(actual_address, textBox1.Text.ToString());
            if (isFolderCreated)
            {
                listazas(actual_address);
                MessageBox.Show("Mappa sikeresen létrehozva!");
            }
            textBox1.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            progMaxDown = 0;
            localPath = "";
            listItems.Clear();

            foreach (string str in listBox1.SelectedItems)
            {

                listItems.Add("/" + Path.GetFileName(str));

            }
            foreach (string str in listBox1.SelectedItems)
            {
                progMaxDown++;
            }
            progressBar2.Maximum = progMaxDown;
            folderBrowserDialog1.ShowDialog();
            Task.Run(() => download());
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
                if (MessageBox.Show("Biztosan törölni akarod?", "Figyelem", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    listItems.Clear();
                    foreach (string str in listBox1.SelectedItems)
                    {
                        listItems.Add("/" + Path.GetFileName(str));
                    }
                    Task.Run(() => deleteFiles());
                }
            
            
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }



        //TÖRLÉSEK


        private void deleteFiles()
        {
            string file;
            foreach (String fajl in listItems)
            {
                file = actual_address + "/" + Path.GetFileName(fajl);
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(file);
                    request.Credentials = new NetworkCredential(Form1.user, Form1.pass);
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    //this.Invoke((MethodInvoker)(() => MessageBox.Show("Delete status: {0}", response.StatusDescription))); 

                }
                catch 
                {
                    MessageBox.Show("Hiba. \n Nem lehet hogy egy mappát akartál kitörölni? :(");
                    this.Invoke((MethodInvoker)(() => root()));
                    return;
                }

            }
            this.Invoke((MethodInvoker)(() => MessageBox.Show("A törlés sikerült")));
            this.Invoke((MethodInvoker)(() => listazas(actual_address)));
        }
        void DeleteFtpDirectory(string url, NetworkCredential credentials)
        {
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (StreamReader listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    lines.Add(listReader.ReadLine());
                }
            }

            foreach (string line in lines)
            {
                try
                {
                    string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[8];
                    string permissions = tokens[0];
                    string fileUrl = url + "/" + name;

                    if (permissions[0] == 'd')
                    {
                        DeleteFtpDirectory(fileUrl + "/", credentials);
                    }
                    else
                    {
                        FtpWebRequest deleteRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                        deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                        deleteRequest.Credentials = credentials;

                        deleteRequest.GetResponse();
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            FtpWebRequest removeRequest = (FtpWebRequest)WebRequest.Create(url);
            removeRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
            removeRequest.Credentials = credentials;

            removeRequest.GetResponse();

        }
        private void mappaTörléseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan törölni akarod?", "Figyelem", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    NetworkCredential user = new NetworkCredential(Form1.user, Form1.pass);
                    string deleteUrl = actual_address + "/" + Path.GetFileName(listBox1.SelectedItem.ToString());

                    DeleteFtpDirectory(deleteUrl, user);
                    MessageBox.Show("Az eltávolítás befejeződött!");
                    this.Text = "FTP - csatlakozva   -     " + actual_address;
                    listazas(actual_address);
                }
                catch
                {
                    MessageBox.Show("Nincs kiválasztva mappa!");
                }
               
            }
        }



        //FELTÖLTÉSEK


        private void uploadFast()
        {
            //alapvető dolgok
            string file;
            bool over = false;
            curr_Upload = 0;
            progMaxUp = 0;
            if (actual_address != "")
            {
                Form1.address = actual_address;
            }
            if (choofdlog.FileName == "")
            {
                return;
            }

            //Felülírod vagy nem!

            if (listBox1.Items[1].ToString() != "Ebben a mappában nem található semmi!")
            {
                if (MessageBox.Show("Felülírod az azonos fájlokat?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    over = true;
                }
                else over = false;
            }
            else over = true;



            foreach (String progressBarValue in choofdlog.FileNames)
            {
                progMaxUp++;
            }
            this.Invoke((MethodInvoker)(() => label1.Text = curr_Upload.ToString() + "/" + progMaxUp.ToString()));
            this.Invoke((MethodInvoker)(() => progressBar2.Maximum = progMaxUp));

            foreach (String fajl in choofdlog.FileNames)
            {
                file = "/" + Path.GetFileName(fajl);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Form1.address + file);
                request.Credentials = new NetworkCredential(Form1.user, Form1.pass);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                FtpWebRequest requestSize = (FtpWebRequest)WebRequest.Create(Form1.address + file);
                requestSize.Credentials = new NetworkCredential(Form1.user, Form1.pass);
                requestSize.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                try
                {
                    curr_Upload++;
                    this.Invoke((MethodInvoker)(() => label1.Text = curr_Upload.ToString() + "/" + progMaxUp.ToString()));
                    if (file != "")
                    {

                        if (over == false)
                        {
                            //Van e már ilyen
                            try
                            {

                                FtpWebResponse response = (FtpWebResponse)requestSize.GetResponse();
                                continue;
                            }
                            catch
                            {
                                //MessageBox.Show(over + "::" + file + "::" + fajl);
                                goto fel;
                            }
                        }
                        else
                        {
                            goto fel;

                        }
                    //Feltöltés
                    fel:
                        

                        using (Stream fileStream = File.OpenRead(fajl))
                        using (Stream ftpStream = request.GetRequestStream())
                        {
                            long size = (long)fileStream.Length / 1048576;
                            progressBar1.Invoke(
                                (MethodInvoker)delegate { progressBar1.Maximum = Convert.ToInt32(size); });

                            byte[] buffer = new byte[20480];
                            int read;
                            while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                    long position;
                                    position = fileStream.Position / 1048576;

                                
                                progressBar1.Invoke(
                                    (MethodInvoker)delegate
                                    {
                                        progressBar1.Value = Convert.ToInt32(position);
                                    });
                                this.Invoke((MethodInvoker)(() => label8.Text = Convert.ToInt32(position).ToString() + "/" + Convert.ToInt32(size).ToString() + " MB"));

                               

                            }
                        }
                    }
                    else MessageBox.Show("Nincs kiválasztott fájl. Kérlek válassz ki egyet!");
                    feltoltve = true;
                    this.Invoke((MethodInvoker)(() => progressBar2.Value = curr_Upload));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (feltoltve == true)
            {
                this.Invoke((MethodInvoker)(() => listazas(actual_address)));
                MessageBox.Show("A feltöltés sikeresen megtörtént!");
                this.Invoke((MethodInvoker)(() => progressBar1.Value = 0));
                this.Invoke((MethodInvoker)(() => progressBar2.Value = 0));
                this.Invoke((MethodInvoker)(() => label1.Text = "0/0"));
                this.Invoke((MethodInvoker)(() => label8.Text = "0/0 MB"));
            }
        }
        private void uploadRecursiveFiles(string path, string fileName)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Credentials = new NetworkCredential(Form1.user, Form1.pass);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream fileStream = File.OpenRead(fileName))
            using (Stream ftpStream = request.GetRequestStream())
            {
                long size = (long)fileStream.Length / 1048576;
                progressBar1.Invoke(
                    (MethodInvoker)delegate { progressBar1.Maximum = Convert.ToInt32(size); });

                byte[] buffer = new byte[20480];
                int read;
                while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ftpStream.Write(buffer, 0, read);
                    long position = (long)fileStream.Position / 1048576;
                    progressBar1.Invoke(
                        (MethodInvoker)delegate
                        {
                                progressBar1.Value = Convert.ToInt32(position);
                        });

                    this.Invoke((MethodInvoker)(() => label8.Text = Convert.ToInt32(position).ToString() + "/" + Convert.ToInt32(size).ToString() + " MB"));
                }
            }
        }
        private void fájlokFeltöltéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progMaxUp = 0;
            //FÁJLOK FELTÖLTÉSE
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;
            choofdlog.ShowDialog();
            //KÜLÖN SZÁLON FUT AZ AKADÁSOK KIKÜSZÖBÖLÉSE MIATT
            if (choofdlog.FileName != "")
            {
                Task.Run(() => uploadFast());
            }
        }
        private void mappaFeltöltéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currUp = 0;
            progMaxRecUp = 0;
            folderBrowserDialog1.ShowDialog();
            

            //Kiválasztott mappa hozzáadása!!!
            if (folderBrowserDialog1.SelectedPath != "")
            {
                recursiveMaxLevelUpload(folderBrowserDialog1.SelectedPath);
                string uploadUrl = actual_address + "/" + Path.GetFileName(folderBrowserDialog1.SelectedPath.ToString());
                folderCreate(actual_address, Path.GetFileName(folderBrowserDialog1.SelectedPath.ToString()));
                Task.Run(() => recursiveUpload(folderBrowserDialog1.SelectedPath, uploadUrl));
            }

            
        }
        private void recursiveUpload(string dirPath, string uploadPath)
        {

            string[] files = Directory.GetFiles(dirPath, "*.*");
            string[] subDirs = Directory.GetDirectories(dirPath);

            foreach (string file in files)
            {
                currUp++;
                this.Invoke((MethodInvoker)(() => label1.Text = currUp.ToString() + "/" + progMaxRecUp.ToString()));
                this.Invoke((MethodInvoker)(() => progressBar2.Value = currUp));
                uploadRecursiveFiles(uploadPath + "/" + Path.GetFileName(file), file);
                if (progressBar2.Value == progMaxRecUp)
                {
                    this.Invoke((MethodInvoker)(() => listazas(actual_address)));
                    MessageBox.Show("A feltöltés sikeresen megtörtént!");
                    this.Invoke((MethodInvoker)(() => progressBar1.Value = 0));
                    this.Invoke((MethodInvoker)(() => progressBar2.Value = 0));
                    this.Invoke((MethodInvoker)(() => label1.Text = "0/0"));
                    this.Invoke((MethodInvoker)(() => label8.Text = "0/0 MB"));
                }

            }
            foreach (string subDir in subDirs)
            {
                folderCreate(uploadPath, "/" + Path.GetFileName(subDir));
                //currUp++;
                recursiveUpload(subDir, uploadPath + "/" + Path.GetFileName(subDir));
                if (progressBar2.Value == progMaxRecUp) feltoltve = true;
            }

        }
        private void recursiveMaxLevelUpload(string path)
        {
           
                //szamlalo = 0;
                string[] files = Directory.GetFiles(path, "*.*");
                string[] subDirs = Directory.GetDirectories(path);
                //összes file kiszámítása

                foreach (string file in files)
                {
                    szamlalo++;
                }
                foreach (string subDir in subDirs)
                {
                    //szamlalo++;
                    recursiveMaxLevelUpload(subDir);
                }
                //progMaxRecUp = szamlalo;
                progMaxRecUp = szamlalo;
                progressBar2.Maximum = szamlalo;
        }




        //LETÖLTÉSEK

        private void download()
        {
            bool over = false;

            if (MessageBox.Show("Felülírod az azonos fájlokat?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                over = true;
            }

            else over = false;
            currDown = 0;
            foreach (String fajl in listItems)
            {

                if (actual_address != "")
                {
                    Form1.address = actual_address;
                }
                downloadUrl = actual_address + "/" + Path.GetFileName(fajl);
                localPath = folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileName(downloadUrl);
                try
                {
                    currDown++;
                    this.Invoke((MethodInvoker)(() => label1.Text = currDown.ToString() + "/" + progMaxDown.ToString()));
                    if (over == false)
                    {
                        //Van e már ilyen

                        if (File.Exists(localPath) == true)
                        {
                            continue;
                        }
                        else
                        {
                            goto le;
                        }
                    }
                    else
                    {
                        goto le;

                    }
                le:

                    NetworkCredential credentials = new NetworkCredential(Form1.user, Form1.pass);
                    // Query size of the file to be downloaded
                    WebRequest sizeRequest = WebRequest.Create(downloadUrl);
                    sizeRequest.Credentials = credentials;
                    sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                    //int size = (int)sizeRequest.GetResponse().ContentLength;
                    long size = (long)sizeRequest.GetResponse().ContentLength / 1048576;    // túlcsordul a változó

                    progressBar1.Invoke(
                        (MethodInvoker)(() => progressBar1.Maximum = Convert.ToInt32(size)));

                    // Download the file

                    WebRequest request = WebRequest.Create(downloadUrl);
                    request.Credentials = credentials;
                    request.Method = WebRequestMethods.Ftp.DownloadFile;

                    using (Stream ftpStream = request.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(localPath))
                    {
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, read);
                            long position = (long)fileStream.Position / 1048576;
                            progressBar1.Invoke(
                                (MethodInvoker)(() => progressBar1.Value = Convert.ToInt32(position)));

                            this.Invoke((MethodInvoker)(() => label8.Text = Convert.ToInt32(position).ToString() + "/" + Convert.ToInt32(size).ToString() + " MB"));
                        }
                    }
                    letoltve = true;
                    this.Invoke((MethodInvoker)(() => progressBar2.Value = currDown));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }


            }

            if (letoltve == true)
            {
                letoltve = false;
                MessageBox.Show("A letöltés sikeresen megtörtént!");
                this.Invoke((MethodInvoker)(() => progressBar1.Value = 0));
                this.Invoke((MethodInvoker)(() => progressBar2.Value = 0));
                this.Invoke((MethodInvoker)(() => label1.Text = "0/0"));
                this.Invoke((MethodInvoker)(() => label8.Text = "0/0 MB"));
            }

        }
        private void mappaLetöltéseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currDown = 0;
            progMaxRecDown = 0;
            
                string downloadUrl = actual_address + "/" + Path.GetFileName(listBox1.SelectedItem.ToString());
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                NetworkCredential user = new NetworkCredential(Form1.user, Form1.pass);
                getProgressbarMaxDFD(downloadUrl, user, folderBrowserDialog1.SelectedPath);
                progressBar2.Maximum = progMaxRecDown;
                Directory.CreateDirectory(folderBrowserDialog1.SelectedPath + "/" + Path.GetFileName(listBox1.SelectedItem.ToString()));
                string downloadPath = folderBrowserDialog1.SelectedPath + @"\" + Path.GetFileName(listBox1.SelectedItem.ToString());
                Task.Run(() => DownloadFtpDirectory(downloadUrl, user, downloadPath));
            }
        }
        void getProgressbarMaxDFD(string url, NetworkCredential credentials, string localPath)
        {
            //Lista megtöltése a root fájlokkal
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url); //url = null
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (StreamReader listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    lines.Add(listReader.ReadLine());
                }
            }

            //Maximum meghatározása


            foreach (string line in lines)
            {
                string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[8];
                string permissions = tokens[0];

                string localFilePath = Path.Combine(localPath, name);
                string fileUrl = url + "/" + name;

                if (permissions[0] == 'd')
                {
                    getProgressbarMaxDFD(fileUrl + "/", credentials, localFilePath);
                }
                else
                {
                    progMaxRecDown++;
                }
            }
        }
        void DownloadFtpDirectory(string url, NetworkCredential credentials, string localPath)
        {

            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            listRequest.Credentials = credentials;

            List<string> lines = new List<string>();

            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
            using (Stream listStream = listResponse.GetResponseStream())
            using (StreamReader listReader = new StreamReader(listStream))
            {
                while (!listReader.EndOfStream)
                {
                    lines.Add(listReader.ReadLine());
                }
            }

            foreach (string line in lines)
            {
                try
                {
                    string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[8];
                    string permissions = tokens[0];

                    string localFilePath = Path.Combine(localPath, name);
                    string fileUrl = url + "/" + name;

                    if (permissions[0] == 'd')
                    {
                        if (!Directory.Exists(localFilePath))
                        {
                            Directory.CreateDirectory(localFilePath);
                        }

                        DownloadFtpDirectory(fileUrl + "/", credentials, localFilePath);
                    }
                    else
                    {
                        FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(fileUrl);
                        downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                        downloadRequest.Credentials = credentials;

                        //progressbar1 maximum

                        WebRequest sizeRequest = WebRequest.Create(fileUrl);
                        sizeRequest.Credentials = credentials;
                        sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                        long size = (long)sizeRequest.GetResponse().ContentLength / 1048576;

                        progressBar1.Invoke(
                            (MethodInvoker)(() => progressBar1.Maximum = Convert.ToInt32(size)));


                        //Fájl letöltése:


                        WebRequest request = WebRequest.Create(fileUrl);
                        request.Credentials = credentials;
                        request.Method = WebRequestMethods.Ftp.DownloadFile;

                        currDown++;
                        this.Invoke((MethodInvoker)(() => label1.Text = currDown.ToString() + "/" + progMaxRecDown.ToString()));
                        this.Invoke((MethodInvoker)(() => progressBar2.Value = currDown));

                        using (Stream ftpStream = request.GetResponse().GetResponseStream())
                        using (Stream fileStream = File.Create(localFilePath))
                        {
                            byte[] buffer = new byte[10240];
                            int read;
                            while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, read);
                                long position = (long)fileStream.Position / 1048576;
                                progressBar1.Invoke(
                                    (MethodInvoker)(() => progressBar1.Value = Convert.ToInt32(position)));

                                this.Invoke((MethodInvoker)(() => label8.Text = Convert.ToInt32(position).ToString() + "/" + Convert.ToInt32(size).ToString() + " MB"));
                            }
                        }
                        
                        if (progressBar2.Value == progMaxRecDown)
                        {
                            MessageBox.Show("A letöltés sikeresen megtörtént!");
                            this.Invoke((MethodInvoker)(() => progressBar1.Value = 0));
                            this.Invoke((MethodInvoker)(() => progressBar2.Value = 0));
                            this.Invoke((MethodInvoker)(() => label1.Text = "0/0"));
                            this.Invoke((MethodInvoker)(() => label8.Text = "0/0 MB"));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

        }




        //MAPPA KÉSZÍTÉS

        public void folderCreate(string address, string folderName)
        {
            //Create a folder
            try
            {
                WebRequest request = WebRequest.Create(address + "/" + folderName);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(Form1.user, Form1.pass);
                using (FtpWebResponse resp = (FtpWebResponse)request.GetResponse())
                {
                    isFolderCreated = true;
                }
            }
            catch
            {
                MessageBox.Show("A mappa már létezik!");
                listazas(actual_address);
            }
        }

        //FÁJL INFÓ
        void GetFileInfo(string path)
        {
            bool pont = false;
            int pontSzamlalo = 0;
            data1.Text = "-";
            data2.Text = "-";
            data3.Text = "-";
            data4.Text = "-";
            string item;
            try
            {
                item = listBox1.SelectedItem.ToString();
            }
            catch
            {
                item = "<- Vissza";
            }
                
                if (item != "<- Vissza")
                {


                    for (int i = 0; i < Path.GetFileName(listBox1.SelectedItem.ToString()).Length; i++)
                    {
                        if (Path.GetFileName(listBox1.SelectedItem.ToString())[i] == '.')
                        {
                            pont = true;
                            pontSzamlalo++;
                            if (pontSzamlalo > 2)
                            {
                                pontSzamlalo = 0;
                                break;
                            }

                        }
                    }
                    string line;
                    if (listBox1.SelectedItems.Count == 1 & pont == true)
                    {
                        pont = false;
                        try
                        {
                            NetworkCredential user = new NetworkCredential(Form1.user, Form1.pass);

                            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(path + "/" + Path.GetFileName(listBox1.SelectedItem.ToString()));
                            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                            listRequest.Credentials = user;

                            using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                            using (Stream listStream = listResponse.GetResponseStream())
                            using (StreamReader listReader = new StreamReader(listStream))

                                line = listReader.ReadLine();
                            // MessageBox.Show(line);
                            string[] tokens =
                                    line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);

                            string name = tokens[8];
                            string owner = tokens[3];
                            string size = tokens[4];
                            string lastModifMonth = tokens[5];
                            string lastModifDay = tokens[6];
                            string lastModifHour = tokens[7];
                            string permissions = tokens[0];

                            //ha nem mappa csak akkor meg tovább!!

                            if (permissions[0] != 'd')
                            {
                                //adatok kiírása

                                data1.Text = name;
                                double mb = Convert.ToInt64(size) * 0.0000001;
                                double ered = Math.Round(mb, 2);
                                data2.Text = ered.ToString() + " MB";
                                data3.Text = lastModifMonth + " " + lastModifDay + " " + lastModifHour;
                                data4.Text = permissions;
                            }
                            else return;
                        }
                        catch
                        {

                        }
                    }
                }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetFileInfo(actual_address);
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            GetFileInfo(actual_address);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFileInfo(actual_address);
        }
        }
    }
    
