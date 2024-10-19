using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyOpen
{
    public partial class CopyOpenForm : Form
    {
        /// <summary>
        /// デフォルトカラー
        /// </summary>
        private Color defaultColor = Color.FromArgb(100, 149, 237);
        /// <summary>
        /// マウスオーバー時のカラー
        /// </summary>
        private Color overColor = Color.FromArgb(250,128,114);
        /// <summary>
        /// ドロップ時のカラー
        /// </summary>
        private Color dragDropColor = Color.FromArgb(255, 255, 77);
        /// <summary>
        /// 一時保存ディレクトリ
        /// </summary>
        private string baseDir = "C:\\temp\\";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CopyOpenForm()
        {
            InitializeComponent();

            // デフォルト背景色
            this.BackColor = defaultColor;

            // tempフォルダの中身を削除する
            if (Directory.Exists(baseDir) )
            {
                var files = Directory.GetFiles(baseDir);
                foreach ( var file in files )
                {
                    File.Delete(file);
                }
            }
            // フォルダがなければ作成
            else
            {
                Directory.CreateDirectory(baseDir);
            }
        }

        /// <summary>
        /// 色変更(マウスが乗ったとき)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOpenForm_DragOver(object sender, DragEventArgs e)
        {
            this.BackColor = overColor;
        }

        /// <summary>
        /// 色変更(マウスが離れたとき)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOpenForm_DragLeave(object sender, EventArgs e)
        {
            this.BackColor = defaultColor;
        }

        /// <summary>
        /// D&D時の処理(ファイルコピー、ファイルオープン)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOpenForm_DragDrop(object sender, DragEventArgs e)
        {
            this.BackColor = dragDropColor;

            // ファイル受け取り
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // コピー元ファイルフルパス
            string actualFileFullPath = string.Empty;
            for (int i = 0; i < files.Length; i++)
            {
                actualFileFullPath = files[i];
            }
            var arr = actualFileFullPath.Split('\\');

            // コピー元ファイル名
            string actualFileName = arr[arr.Length - 1];

            // コピーファイル名
            string copyFileName = string.Format("{0}-{1}", DateTime.Now.ToString("yyMMddHHmmss"), actualFileName);

            // コピーファイルフルパス
            string copyFileFullPath = string.Format("{0}{1}", baseDir, copyFileName);

            // コピー実施
            File.Copy(actualFileFullPath, copyFileFullPath);

            // ファイルを既定のプログラムで開く
            var startInfo = new System.Diagnostics.ProcessStartInfo()
            {
                FileName = copyFileFullPath,
                UseShellExecute = true,
                CreateNoWindow = true,
            };
            System.Diagnostics.Process.Start(startInfo);

            // 色変更
            this.BackColor = defaultColor;
        }

        /// <summary>
        /// ドラッグ時にカーソル変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyOpenForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
