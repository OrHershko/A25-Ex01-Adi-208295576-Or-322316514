using System.Text.Json;


namespace BasicFacebookFeatures
{
    partial class FormWeatherCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.labelUpcomingEvents = new System.Windows.Forms.Label();
            this.webBrowserWeather = new System.Windows.Forms.WebBrowser();
            this.labelWeather = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.Location = new System.Drawing.Point(96, 68);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(243, 355);
            this.listBoxEvents.TabIndex = 0;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // labelUpcomingEvents
            // 
            this.labelUpcomingEvents.AutoSize = true;
            this.labelUpcomingEvents.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpcomingEvents.Location = new System.Drawing.Point(93, 36);
            this.labelUpcomingEvents.Name = "labelUpcomingEvents";
            this.labelUpcomingEvents.Size = new System.Drawing.Size(134, 16);
            this.labelUpcomingEvents.TabIndex = 1;
            this.labelUpcomingEvents.Text = "Upcoming Events";
            // 
            // webBrowserWeather
            // 
            this.webBrowserWeather.Location = new System.Drawing.Point(383, 70);
            this.webBrowserWeather.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserWeather.Name = "webBrowserWeather";
            this.webBrowserWeather.ScriptErrorsSuppressed = true;
            this.webBrowserWeather.ScrollBarsEnabled = false;
            this.webBrowserWeather.Size = new System.Drawing.Size(378, 353);
            this.webBrowserWeather.TabIndex = 2;
            // 
            // labelWeather
            // 
            this.labelWeather.AutoSize = true;
            this.labelWeather.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeather.Location = new System.Drawing.Point(380, 36);
            this.labelWeather.Name = "labelWeather";
            this.labelWeather.Size = new System.Drawing.Size(72, 16);
            this.labelWeather.TabIndex = 3;
            this.labelWeather.Text = "Weather";
            // 
            // FormWeatherCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelWeather);
            this.Controls.Add(this.webBrowserWeather);
            this.Controls.Add(this.labelUpcomingEvents);
            this.Controls.Add(this.listBoxEvents);
            this.Name = "FormWeatherCheck";
            this.Text = "Upcoming Events Weather Check";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Label labelUpcomingEvents;
        private System.Windows.Forms.WebBrowser webBrowserWeather;
        private System.Windows.Forms.Label labelWeather;
    }
}