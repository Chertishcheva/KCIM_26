namespace KSIM_HW
{
    partial class gameOfLifeForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gameOfLifeForm));
            canvas = new PictureBox();
            toolStrip1 = new ToolStrip();
            skipGenerationButton = new ToolStripButton();
            fastSkipGenerationButton = new ToolStripButton();
            stopButton = new ToolStripButton();
            restartButton = new ToolStripButton();
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            generationNumber = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // canvas
            // 
            canvas.Location = new Point(0, 26);
            canvas.Name = "canvas";
            canvas.Size = new Size(400, 400);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseLeave += canvas_MouseLeave;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { skipGenerationButton, fastSkipGenerationButton, stopButton, restartButton });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(401, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // skipGenerationButton
            // 
            skipGenerationButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            skipGenerationButton.Image = (Image)resources.GetObject("skipGenerationButton.Image");
            skipGenerationButton.ImageTransparentColor = Color.Magenta;
            skipGenerationButton.Name = "skipGenerationButton";
            skipGenerationButton.Size = new Size(29, 24);
            skipGenerationButton.Text = "Вперед одне покоління";
            skipGenerationButton.Click += skipGenerationButton_Click;
            // 
            // fastSkipGenerationButton
            // 
            fastSkipGenerationButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            fastSkipGenerationButton.Image = (Image)resources.GetObject("fastSkipGenerationButton.Image");
            fastSkipGenerationButton.ImageTransparentColor = Color.Magenta;
            fastSkipGenerationButton.Name = "fastSkipGenerationButton";
            fastSkipGenerationButton.Size = new Size(29, 24);
            fastSkipGenerationButton.Text = "Запуск симуляції";
            fastSkipGenerationButton.Click += fastSkipGenerationButton_Click;
            // 
            // stopButton
            // 
            stopButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            stopButton.Image = (Image)resources.GetObject("stopButton.Image");
            stopButton.ImageTransparentColor = Color.Magenta;
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(29, 24);
            stopButton.Text = "Зупинка симуляції";
            stopButton.Click += stopButton_Click;
            // 
            // restartButton
            // 
            restartButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            restartButton.Image = (Image)resources.GetObject("restartButton.Image");
            restartButton.ImageTransparentColor = Color.Magenta;
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(29, 24);
            restartButton.Text = "Запустити заново";
            restartButton.Click += restartButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 150;
            timer1.Tick += timer1_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel, generationNumber });
            statusStrip1.Location = new Point(0, 427);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(401, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.BackColor = SystemColors.Control;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(86, 20);
            toolStripStatusLabel.Text = "Покоління:";
            // 
            // generationNumber
            // 
            generationNumber.BackColor = SystemColors.Control;
            generationNumber.Name = "generationNumber";
            generationNumber.Size = new Size(17, 20);
            generationNumber.Text = "0";
            // 
            // gameOfLifeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(401, 453);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(canvas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "gameOfLifeForm";
            Text = "Game Of Life";
            MouseLeave += canvas_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox canvas;
        private ToolStrip toolStrip1;
        private ToolStripButton skipGenerationButton;
        private ToolStripButton fastSkipGenerationButton;
        private ToolStripButton stopButton;
        private System.Windows.Forms.Timer timer1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel generationNumber;
        private ToolStripButton restartButton;
    }
}
