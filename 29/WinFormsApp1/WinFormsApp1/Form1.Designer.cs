namespace WinFormsApp1
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
            gViewer1.EdgeInsertButtonVisible = true;
            gViewer1.FileName = "";
            gViewer1.ForwardEnabled = false;
            gViewer1.Graph = null;
            gViewer1.IncrementalDraggingModeAlways = false;
            gViewer1.InsertingEdge = false;
            gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            gViewer1.LayoutEditingEnabled = true;
            gViewer1.Location = new Point(145, 32);
            gViewer1.LooseOffsetForRouting = 0.25D;
            gViewer1.MouseHitDistance = 0.05D;
            gViewer1.Name = "gViewer1";
            gViewer1.NavigationVisible = true;
            gViewer1.NeedToCalculateLayout = true;
            gViewer1.OffsetForRelaxingInRouting = 0.6D;
            gViewer1.PaddingForEdgeRouting = 8D;
            gViewer1.PanButtonPressed = false;
            gViewer1.SaveAsImageEnabled = true;
            gViewer1.SaveAsMsaglEnabled = true;
            gViewer1.SaveButtonVisible = true;
            gViewer1.SaveGraphButtonVisible = true;
            gViewer1.SaveInVectorFormatEnabled = true;
            gViewer1.Size = new Size(434, 392);
            gViewer1.TabIndex = 0;
            gViewer1.TightOffsetForRouting = 0.125D;
            gViewer1.ToolBarIsVisible = true;
            gViewer1.Transform = (Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)resources.GetObject("gViewer1.Transform");
            gViewer1.UndoRedoButtonsVisible = true;
            gViewer1.WindowZoomButtonPressed = false;
            gViewer1.ZoomF = 1D;
            gViewer1.ZoomWindowThreshold = 0.05D;
            gViewer1.Load += gViewer1_Load;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gViewer1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
    }
}