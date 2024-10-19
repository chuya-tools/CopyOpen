namespace CopyOpen
{
    partial class CopyOpenForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyOpenForm));
            this.SuspendLayout();
            // 
            // CopyOpenForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 61);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyOpenForm";
            this.TopMost = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CopyOpenForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CopyOpenForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.CopyOpenForm_DragOver);
            this.DragLeave += new System.EventHandler(this.CopyOpenForm_DragLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

