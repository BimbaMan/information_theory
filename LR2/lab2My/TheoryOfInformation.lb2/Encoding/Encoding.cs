﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TheoryOfInformation.LFSR;

namespace TheoryOfInformation.lb2.Encoding
{

    internal class Encoder
    {
        #region Constant
        private const int BITES = 8;
        #endregion
      
        #region Method
        // Encode inforamtion from source file and write it to result file, show generated key
        public static void Encode(int[] PolynomPowers, string initialKey, string pathToSrcFile, string pathToResFile, TextBox srcFile, TextBox generatedKey, TextBox resFile)
        {
            try
            {
                resFile.Text = string.Empty;
                srcFile.Text = string.Empty;
                generatedKey.Text = string.Empty;

                //polinom degrees and key state
                Register reg = new Register(PolynomPowers, initialKey);

                byte[] srcBytes = File.ReadAllBytes(pathToSrcFile);

                string KEY = "";
                string baseText = "";
                string res = "";

                for (long i = 0; i < srcBytes.Length; i++)
                {

                    baseText += Convert.ToString(srcBytes[i], 2).PadLeft(BITES, '0') + " ";
                    

                    string currKey = string.Empty;

                    for (int j = 0; j < BITES; j++)
                        currKey += reg.GenerateKeyBit();

                    byte keyByte = 0;
                    for (int j = 0; j < currKey.Length; j++)
                        keyByte += (byte)((byte)(currKey[j] - '0') * Math.Pow(2, BITES - 1 - j));

                    KEY += currKey + " ";
                    

                    srcBytes[i] ^= (byte)keyByte;

                    res += Convert.ToString(srcBytes[i], 2).PadLeft(BITES, '0') + " ";
                    
                }
                File.WriteAllBytes(pathToResFile, srcBytes);
                srcFile.AppendText(baseText);
                resFile.AppendText(res);
                generatedKey.AppendText(KEY);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found");
            }
        }
        #endregion
    }
}
