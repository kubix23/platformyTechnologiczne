
namespace PlatformyTechnologiczne
{
    partial class findBar
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(findBar));
            this.find = new System.Windows.Forms.ToolStrip();
            this.lable_search = new System.Windows.Forms.ToolStripLabel();
            this.search = new System.Windows.Forms.ToolStripTextBox();
            this.label_type = new System.Windows.Forms.ToolStripLabel();
            this.Type = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.findButton = new System.Windows.Forms.ToolStripButton();
            this.find.SuspendLayout();
            this.SuspendLayout();
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.find.CanOverflow = false;
            this.find.Dock = System.Windows.Forms.DockStyle.Fill;
            this.find.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.find.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.find.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lable_search,
            this.search,
            this.label_type,
            this.Type,
            this.toolStripSeparator1,
            this.findButton});
            this.find.Location = new System.Drawing.Point(0, 0);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(606, 40);
            this.find.TabIndex = 0;
            this.find.Text = "toolStrip1";
            // 
            // lable_search
            // 
            this.lable_search.Name = "lable_search";
            this.lable_search.Size = new System.Drawing.Size(60, 37);
            this.lable_search.Text = "Search: ";
            // 
            // search
            // 
            this.search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(100, 40);
            // 
            // label_type
            // 
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(67, 37);
            this.label_type.Text = "Column: ";
            // 
            // Type
            // 
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(121, 40);
            this.Type.Enter += new System.EventHandler(this.findBar_Load);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.findButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.findButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
            this.findButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(41, 37);
            this.findButton.Text = "Find";
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // findBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.find);
            this.Name = "findBar";
            this.Size = new System.Drawing.Size(606, 40);
            this.find.ResumeLayout(false);
            this.find.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip find;
        private System.Windows.Forms.ToolStripLabel lable_search;
        private System.Windows.Forms.ToolStripTextBox search;
        private System.Windows.Forms.ToolStripLabel label_type;
        private System.Windows.Forms.ToolStripComboBox Type;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton findButton;
    }
}
