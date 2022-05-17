using System.Text;
using System.Text.RegularExpressions;

namespace TI
{
    public partial class Form1 : Form
    {
        string filename;
        readonly char[] Alphabet =
        {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У',
            'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };
        readonly char[] fairalph = { 'c','r','y','p','t', 'o','g','a','h','b','d', 'e','f','i','k', 'l', 'm', 'n', 'q', 's' , 'u', 'v', 'w', 'x', 'z'  };
        string Alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public Form1()
        {
            InitializeComponent();
        }

        string railCipher(string plaintext,string key)
        {
            int keyInt=int.Parse(key);
            plaintext = Regex.Replace(plaintext, @"[А-я0-9\s*$/\\]", string.Empty);
            plaintext=plaintext.ToLower();
            var rails = new List<StringBuilder>();
            for (int i = 0; i < keyInt; i++)
            {
                rails.Add(new StringBuilder());
            }
            int currentLine = 0;
            int direction = 1;
            if (keyInt <= 1)
            {
                MessageBox.Show("Bad key! Enter number from 2 to " + plaintext.Length);
                //cipherText.Text = "Bad key! Enter number from 2 to " + plaintext.Length;
                return "";
            }
            else
            {
                foreach (var symb in plaintext)
                {
                    rails[currentLine].Append(symb);

                    if (currentLine == 0)
                        direction = 1;
                    else if (currentLine == keyInt - 1)
                        direction = -1;

                    currentLine += direction;
                }
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < keyInt; i++)
                    result.Append(rails[i]);

                return result.ToString();
            }
        }
        string railPlain(string ciphertext,string key)
        {
            ciphertext = Regex.Replace(ciphertext, @"[А-я0-9]", string.Empty);
           
                int keyInt = int.Parse(key);
            var rails = new List<StringBuilder>();
            for (int i = 0; i < keyInt; i++)
                rails.Add(new StringBuilder());

            int[] linesLenght = Enumerable.Repeat(0, keyInt).ToArray();

            int currentLine = 0;
            int direction = 1;

            for (int i = 0; i < ciphertext.Length; i++)
            {
                linesLenght[currentLine]++;

                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == keyInt - 1)
                    direction = -1;

                currentLine += direction;
            }

            int currentChar = 0;

            for (int line = 0; line < keyInt; line++)
            {
                for (int c = 0; c < linesLenght[line]; c++)
                {
                    rails[line].Append(ciphertext[currentChar]);
                    currentChar++;
                }
            }


            StringBuilder result = new StringBuilder();

            currentLine = 0;
            direction = 1;

            int[] currentReadLine = Enumerable.Repeat(0, keyInt).ToArray();

            for (int i = 0; i < ciphertext.Length; i++)
            {
                result.Append(rails[currentLine][currentReadLine[currentLine]]);
                currentReadLine[currentLine]++;

                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == keyInt - 1)
                    direction = -1;

                currentLine += direction;
            }

            return result.ToString();
        }
        string VisionereCipher(string PlainText, string Key)
        {
            PlainText = Regex.Replace(PlainText, @"[A-z0-9\s*$/\\]", string.Empty);

            int KeyIndex = 0;
            string CryptoText = "";
            int KeyLength = Key.Length;
            PlainText = PlainText.ToLower();
            foreach (var symb in PlainText)
                if (Alphabet.Contains(symb))
                {
                    CryptoText += Alph[(Alph.IndexOf(symb) + (Alph.IndexOf(Key[KeyIndex]))) % 33];
                    KeyIndex++;

                    if (KeyIndex % Key.Length == 0)
                    {
                        KeyIndex = 0;
                        string Keytemp = Key;
                        Key = "";
                        for (int i = 0; i < KeyLength; i++)
                        {
                            Key += Alph[(Alph.IndexOf(Keytemp[i]) + 1) % 33];
                        }
                    }
                }
                else
                    CryptoText += symb;

            return CryptoText;
        }
        string VisionerePlain(string CryptoText, string Key)
        {
            int KeyIndex = 0;

            string PlainText = "";
            int KeyLength = Key.Length;

            foreach (var symb in CryptoText)
                if (Alphabet.Contains(symb))
                {
                    int z;
                    if ((Alph.IndexOf(symb) - (Alph.IndexOf(Key[KeyIndex]))) % 33 < 0)
                        z = 33 - Math.Abs((Alph.IndexOf(symb) - (Alph.IndexOf(Key[KeyIndex]))) % 33);
                    else
                        z = (Alph.IndexOf(symb) - (Alph.IndexOf(Key[KeyIndex]))) % 33;

                    PlainText += Alph[z];
                    KeyIndex++;

                    if (KeyIndex % Key.Length == 0)
                    {
                        KeyIndex = 0;
                        var Keytemp = Key;
                        Key = "";
                        for (int i = 0; i < KeyLength; i++)
                        {
                            Key += Alph[(Alph.IndexOf(Keytemp[i]) + 1) % 33];
                        }
                    }
                }
                else
                    PlainText += symb;

            return PlainText;
        }
        string PlayfairCipher(string plaintext,string key)
        {
            string cipherText="";
            int iFst = 0, jFst = 0;
            int iScnd=0,jScnd=0;
            int fstIndex, scndIndex = 0;
            string temp;
            plaintext =plaintext.ToLower();
            
            for (int k=0; k<plaintext.Length; k++)
            {
                if(plaintext[k] ==' ')
                {
                    plaintext=plaintext.Remove(k,1);
                    continue;
                }
                if (plaintext[k] == 'j')
                {
                    plaintext = plaintext.Remove(k, 1);
                    plaintext = plaintext.Insert(k, "i");
                    continue;
                }
                if (Array.IndexOf(fairalph,plaintext[k])==-1){
                    plaintext = plaintext.Remove(k, 1);
                    //MessageBox.Show("Недопустимый символ");
                    //return "";
                }

            }
            for(int k=0; k<plaintext.Length-1; k++)
            {
                if(plaintext[k] == plaintext[k + 1] && plaintext[k]!='x')
                {
                    
                    plaintext = plaintext.Insert(k + 1, "x");


                }
                else if(plaintext[k] == plaintext[k + 1] && plaintext[k] == 'x')
                {
                    plaintext = plaintext.Insert(k + 1, "z");
                }
              


            }
            if (plaintext.Length % 2 != 0)
            {
                plaintext = plaintext.Insert(plaintext.Length, "x");
            }
            for (int k = 0; k < plaintext.Length; k += 2)
            {
                fstIndex=Array.IndexOf(fairalph,plaintext[k]);
                scndIndex = Array.IndexOf(fairalph, plaintext[k+1]);
                iFst=fstIndex % 5;
                jFst = fstIndex / 5;
                iScnd = scndIndex % 5;
                jScnd = scndIndex / 5;
                int frstCiph, scndCiph = 0;
                if (iFst == iScnd)
                {
                    if (fstIndex + 5 <= 24 && scndIndex + 5 <= 24)
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 5].ToString());
                    }
                    else if (fstIndex + 5 <= 24 && scndIndex + 5 > 24)
                    {
                      
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 5-25].ToString());
                    }
                    else if (fstIndex + 5 > 24 && scndIndex + 5 <= 24)
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 5 - 25].ToString());
           
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 5].ToString());
                    }
                    else if (fstIndex + 5 > 24 && scndIndex + 5 > 24)
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 5 - 25].ToString());

                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 5-25].ToString());
                    }

                }
                if (jScnd==jFst)
                {
                    if ((((fstIndex+1) / 5) == jFst) && (((scndIndex + 1) / 5) == jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 1].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 1].ToString());
                    }
                    else if((((fstIndex + 1) / 5) != jFst) && (((scndIndex + 1) / 5) == jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 1-5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 1].ToString());
                    }
                    else if ((((fstIndex + 1) / 5) == jFst) && (((scndIndex + 1) / 5) != jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 1].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 1-5].ToString());
                    }
                    else if ((((fstIndex + 1) / 5) != jFst) && (((scndIndex + 1) / 5) != jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex + 1-5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex + 1 - 5].ToString());
                    }
                }
                if (jFst != jScnd && iFst != iScnd)
                {
                    frstCiph = jFst*5+iScnd;
                    scndCiph = jScnd*5+iFst;
                    cipherText = cipherText.Insert(k, fairalph[frstCiph].ToString());
                    cipherText = cipherText.Insert(k + 1, fairalph[scndCiph].ToString());
                }
               

            }
                return cipherText;
        }
        string PlayfairPlain(string plaintext, string key)
        {
            string cipherText = "";
            int iFst = 0, jFst = 0;
            int iScnd = 0, jScnd = 0;
            int fstIndex, scndIndex = 0;
            string temp;
            plaintext = plaintext.ToLower();
           
           
           
            for (int k = 0; k < plaintext.Length; k += 2)
            {

                fstIndex = Array.IndexOf(fairalph, plaintext[k]);
                scndIndex = Array.IndexOf(fairalph, plaintext[k + 1]);
                iFst = fstIndex % 5;
                jFst = fstIndex / 5;
                iScnd = scndIndex % 5;
                jScnd = scndIndex / 5;
                int frstCiph, scndCiph = 0;
                if (iFst == iScnd)
                {
                    if (fstIndex - 5 >=0 && scndIndex - 5 >= 0)
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 5].ToString());
                    }
                    else if (fstIndex - 5 >= 0 && scndIndex - 5 < 0)
                    {

                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 5 + 25].ToString());
                    }
                    else if (fstIndex - 5 < 0 && scndIndex - 5 >= 0)
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 5 + 25].ToString());

                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 5].ToString());
                    }
                    else if (fstIndex - 5 < 0 && scndIndex - 5 < 0)
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 5 + 25].ToString());

                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 5 + 25].ToString());
                    }

                }
                    if (jScnd == jFst)
                {
                    if ((((fstIndex - 1) / 5) == jFst && fstIndex-1>=0 && (((scndIndex - 1) / 5) == jFst && fstIndex - 1 >= 0)))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 1].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 1].ToString());
                    }
                    else if ((((fstIndex - 1) / 5) == jFst && fstIndex - 1 < 0 && (((scndIndex - 1) / 5) == jFst && scndIndex - 1 >= 0)))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 1+5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 1].ToString());
                    }
                    else if ((((fstIndex - 1) / 5) == jFst && fstIndex - 1 >= 0 && (((scndIndex - 1) / 5) == jFst && scndIndex - 1 <0)))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 1 ].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 1+5].ToString());
                    }
                    else if ((((fstIndex - 1) / 5) != jFst) && (((scndIndex - 1) / 5) == jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 1 + 5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 1].ToString());
                    }
                    else if ((((fstIndex-1) / 5) == jFst) && (((scndIndex - 1) / 5) != jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 1].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 1 + 5].ToString());
                    }
                    else if ((((fstIndex - 1) / 5) != jFst) && (((scndIndex - 1) / 5) != jFst))
                    {
                        cipherText = cipherText.Insert(k, fairalph[fstIndex - 1 + 5].ToString());
                        cipherText = cipherText.Insert(k + 1, fairalph[scndIndex - 1 + 5].ToString());
                    }
                }
                if (jFst != jScnd && iFst != iScnd)
                {
                    frstCiph = jFst * 5 + iScnd;
                    scndCiph = jScnd * 5 + iFst;
                    cipherText = cipherText.Insert(k, fairalph[frstCiph].ToString());
                    cipherText = cipherText.Insert(k + 1, fairalph[scndCiph].ToString());
                }


            }
            for(int i = 0; i < cipherText.Length-2; i++)
            {
                if(cipherText[i] == cipherText[i + 2]&&cipherText[i+1]=='x')
                {
                    cipherText=cipherText.Remove(i+1,1);
                }
                else if (cipherText[i] == cipherText[i + 2] && cipherText[i]=='x' && cipherText[i + 1] == 'z')
                {
                    cipherText = cipherText.Remove(i + 1, 1);
                }

                }
            while (true)
            {
                if(cipherText[cipherText.Length - 1] == 'x')
                {
                    cipherText = cipherText.Remove(cipherText.Length - 1, 1);
                }
                else
                {
                    break;
                }
            }
            return cipherText;
        }
        private void EncryptBtn_Click(object sender, EventArgs e)
        {
            if(keyEnter.Enabled==true && keyEnter.Text == "")
            {
                MessageBox.Show("Заполните поле ключа");
                return;
            }
            if (startTextEnter.Text=="")
            {
                MessageBox.Show("Заполните поле текста");
                return;
            }
            if (railCipherCheck.Checked)
            {
            cipherText.Text= railCipher(startTextEnter.Text,keyEnter.Text);
                File.WriteAllText("C:\\Users\\MSI\\Desktop\\TI\\railCipher.txt", string.Empty);

                File.AppendAllText("C:\\Users\\MSI\\Desktop\\TI\\railCipher.txt", cipherText.Text);

            }
            else if (VisionerCheck.Checked)
            {
                cipherText.Text = VisionereCipher(startTextEnter.Text, keyEnter.Text);
                File.WriteAllText("C:\\Users\\MSI\\Desktop\\TI\\VisionerCipher.txt", string.Empty);
                File.AppendAllText("C:\\Users\\MSI\\Desktop\\TI\\VisionerCipher.txt", cipherText.Text);
            }
            else if (PlayfairCheck.Checked)
            {
                cipherText.Text = PlayfairCipher(startTextEnter.Text, keyEnter.Text);
                File.WriteAllText("C:\\Users\\MSI\\Desktop\\TI\\PlayfairCipher.txt", string.Empty);
                File.AppendAllText("C:\\Users\\MSI\\Desktop\\TI\\PlayfairCipher.txt", cipherText.Text);
            }
            
        }

        private void DecryptBtn_Click(object sender, EventArgs e)
        {
            if (keyEnter.Enabled == true && keyEnter.Text == "")
            {
                MessageBox.Show("Заполните поле ключа");
                return;
            }
            if (cipherText.Text == "")
            {
                MessageBox.Show("Заполните поле текста");
                return;
            }
            if (railCipherCheck.Checked)
            {
                startTextEnter.Text = railPlain(cipherText.Text, keyEnter.Text);
                File.WriteAllText("C:\\Users\\MSI\\Desktop\\TI\\railPlain.txt", string.Empty);
                File.AppendAllText("C:\\Users\\MSI\\Desktop\\TI\\railPlain.txt", startTextEnter.Text);
            }
            else if (VisionerCheck.Checked)
            {
                startTextEnter.Text=VisionerePlain(cipherText.Text,keyEnter.Text);
                File.WriteAllText("C:\\Users\\MSI\\Desktop\\TI\\VisionerPlain.txt", string.Empty);
                File.AppendAllText("C:\\Users\\MSI\\Desktop\\TI\\VisionerPlain.txt", startTextEnter.Text);
            }
            else if (PlayfairCheck.Checked)
            {
                startTextEnter.Text = PlayfairPlain(cipherText.Text, keyEnter.Text);
                File.WriteAllText("C:\\Users\\MSI\\Desktop\\TI\\PlayfairPlain.txt", string.Empty);
                File.AppendAllText("C:\\Users\\MSI\\Desktop\\TI\\PlayfairPlain.txt", startTextEnter.Text);
            }
           
        }

        private void keyEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (railCipherCheck.Checked)
            {
                if (!((e.KeyChar >= '0') && (e.KeyChar <= '9')||(e.KeyChar == (char)8) || (e.KeyChar == ' ')))
                {
                    MessageBox.Show("Вводить только цифры");
                    e.Handled = true;
                    return;
                }
            }
            else if (VisionerCheck.Checked)
            {
                if (!((e.KeyChar >= 'А') && (e.KeyChar <= 'я') || (e.KeyChar == (char)8)|| (e.KeyChar == ' ')))
                {
                    MessageBox.Show("Вводить только русские символы");
                    e.Handled = true;
                    return;
                }
            }
        }

        private void PlayfairCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayfairCheck.Checked)
            {
                keyEnter.Enabled = false;
            }
            else
            {
                keyEnter.Enabled = true;
            }
            if (VisionerCheck.Checked)
            {
                PlayfairCheck.Checked = false;
            }
            if (railCipherCheck.Checked)
            {
                PlayfairCheck.Checked = false;
            }
        }

        private void VisionerCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayfairCheck.Checked)
            {
                VisionerCheck.Checked = false;
            }
            if (railCipherCheck.Checked)
            {
                VisionerCheck.Checked = false;
            }
        }

        private void railCipherCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayfairCheck.Checked)
            {
                railCipherCheck.Checked = false;
            }
            if (VisionerCheck.Checked)
            {
                railCipherCheck.Checked = false;
            }
        }

        private void startTextEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((railCipherCheck.Checked)||(PlayfairCheck.Checked))
            {
                if (!((e.KeyChar >= 'A') && (e.KeyChar <= 'z') || (e.KeyChar == (char)8) || (e.KeyChar == ' ') || (e.KeyChar == '.')))
                {
                    MessageBox.Show("Вводить только английские символы");
                    e.Handled = true;
                    return;
                }
            }
            else if (VisionerCheck.Checked)
            {
                if (!((e.KeyChar >= 'А') && (e.KeyChar <= 'я') || (e.KeyChar == (char)8) || (e.KeyChar == ' ')))
                {
                    MessageBox.Show("Вводить только русские символы");
                    e.Handled = true;
                    return;
                }
            }
        }

        private void addPlainBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.InitialDirectory = "C:\\Users\\MSI\\Desktop\\TI";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                startTextEnter.Text = fileText;
                return;
            }

            
           
         
        }

        private void addCipherBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.InitialDirectory = "C:\\Users\\MSI\\Desktop\\TI";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                cipherText.Text = fileText;
                return;
            }


            
        }
    }
}