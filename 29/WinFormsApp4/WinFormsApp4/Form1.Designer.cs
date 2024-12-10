namespace WinFormsApp4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // gViewer1
            // 
            gViewer1.ArrowheadLength = 10D;
            gViewer1.AsyncLayout = false;
            gViewer1.AutoScroll = true;
            gViewer1.BackwardEnabled = false;
            gViewer1.BuildHitTree = true;
            gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            gViewer1.EdgeInsertButtonVisible = false;
            gViewer1.FileName = "";
            gViewer1.ForwardEnabled = false;
            gViewer1.Graph = null;
            gViewer1.IncrementalDraggingModeAlways = false;
            gViewer1.InsertingEdge = false;
            gViewer1.LayoutAlgorithmSettingsButtonVisible = false;
            gViewer1.LayoutEditingEnabled = true;
            gViewer1.Location = new Point(984, 510);
            gViewer1.LooseOffsetForRouting = 0.25D;
            gViewer1.MouseHitDistance = 0.05D;
            gViewer1.Name = "gViewer1";
            gViewer1.NavigationVisible = false;
            gViewer1.NeedToCalculateLayout = true;
            gViewer1.OffsetForRelaxingInRouting = 0.6D;
            gViewer1.PaddingForEdgeRouting = 8D;
            gViewer1.PanButtonPressed = false;
            gViewer1.SaveAsImageEnabled = true;
            gViewer1.SaveAsMsaglEnabled = true;
            gViewer1.SaveButtonVisible = false;
            gViewer1.SaveGraphButtonVisible = false;
            gViewer1.SaveInVectorFormatEnabled = true;
            gViewer1.Size = new Size(16, 61);
            gViewer1.TabIndex = 0;
            gViewer1.TightOffsetForRouting = 0.125D;
            gViewer1.ToolBarIsVisible = true;
            gViewer1.Transform = (Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)resources.GetObject("gViewer1.Transform");
            gViewer1.UndoRedoButtonsVisible = false;
            gViewer1.WindowZoomButtonPressed = false;
            gViewer1.ZoomF = 1D;
            gViewer1.ZoomWindowThreshold = 0.05D;
            gViewer1.Load += gViewer1_Load_1;
            // 
            // button1
            // 
            button1.Location = new Point(866, 577);
            button1.Name = "button1";
            button1.Size = new Size(236, 76);
            button1.TabIndex = 1;
            button1.Text = "Запустить сортировку";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(863, 464);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 2;
            label1.Text = "Результат сортировки:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1000, 464);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1000, 464);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 4;
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 702);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(gViewer1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}