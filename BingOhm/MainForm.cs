using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BingOhm.Resistors;

namespace BingOhm
{
    public partial class MainForm : Form
    {
        private static ResistorStandard[] seriesStandards = { ResistorStandard.E6, ResistorStandard.E12, ResistorStandard.E24, ResistorStandard.E48, ResistorStandard.E96, ResistorStandard.E192};
        private ResistorStandard series;
        private static ResistorBandTolerance[] toleranceBands = { new ResistorBandTolerance("Gray"), new ResistorBandTolerance("Violet"), new ResistorBandTolerance("Blue"), new ResistorBandTolerance("Green"), new ResistorBandTolerance("Brown"), new ResistorBandTolerance("Red"), new ResistorBandTolerance("Gold"), new ResistorBandTolerance("Silver"), new ResistorBandTolerance("Transparent") };
        private ResistorBand tolerance;
        private static ResistorBandMultiplier[] decadeBandsB = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        private static ResistorBandMultiplier[] decadeBandsI = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        private static ResistorBandMultiplier[] decadeBandsN = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        private static ResistorBandMultiplier[] decadeBandsG = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        private static ResistorBandMultiplier[] decadeBandsO = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        private ResistorBand columnMultiplierB;
        private ResistorBand columnMultiplierI;
        private ResistorBand columnMultiplierN;
        private ResistorBand columnMultiplierG;
        private ResistorBand columnMultiplierO;
        private List<Resistor> allResistors;
        private List<Resistor> uncalledResistors;
        private List<CalledResistor> calledResistors;
        private Resistor currentResistor;

        private int pane_w, pane_h;
        private Rectangle background;
        private Rectangle wire_cross;
        private Rectangle wire_vert_left;
        private Rectangle wire_vert_right;
        private Rectangle resistor_base;
        private Rectangle resistor_outline;
        private Rectangle band1, band2, band3, band4, band5;
        private Rectangle band1_outline, band2_outline, band3_outline, band4_outline, band5_outline;
        private PointF band1_text, band2_text, band3_text, band4_text, band5_text;
        private PointF resistor_text;
        private Rectangle resistor_text_redraw_area;
        private Color background_color;
        private Color wire_color;
        private Color resistor_base_color;
        private Color outline_color;
        private Color default_band_color;
        private Color band_text_color;
        private Color resistor_text_color;
        private SolidBrush background_painter;
        private SolidBrush wire_painter;
        private SolidBrush resistor_base_painter;
        private SolidBrush band_painter;
        private SolidBrush band_text_painter;
        private SolidBrush resistor_text_painter;
        private Pen outline_painter;
        private bool display_bingohm_text;
        private Font band_text_font;
        private Font resistor_text_font;

        private Random rng;

        private int time_until_value_reveal;

        private bool reveal_countdown_inprogress;

        private bool listByValue = false;

        public MainForm()
        {
            InitializeComponent();

            reveal_countdown_inprogress = false;

            this.comboBoxSeriesSelector.DataSource = seriesStandards;
            this.comboBoxSeriesSelector.SelectedIndex = 1; //E12
            this.comboBoxTolerance.DataSource = toleranceBands;
            this.comboBoxTolerance.SelectedIndex = 6; //Gold, 5%
            this.comboBoxBColumn.DataSource = decadeBandsB;
            this.comboBoxBColumn.SelectedIndex = 3; //Brown, 10
            this.comboBoxIColumn.DataSource = decadeBandsI;
            this.comboBoxIColumn.SelectedIndex = 4; //Red, 100
            this.comboBoxNColumn.DataSource = decadeBandsN;
            this.comboBoxNColumn.SelectedIndex = 5; //Orange, 1000
            this.comboBoxGColumn.DataSource = decadeBandsG;
            this.comboBoxGColumn.SelectedIndex = 6; //Yellow, 10000
            this.comboBoxOColumn.DataSource = decadeBandsO;
            this.comboBoxOColumn.SelectedIndex = 7; //Green, 100000
            this.series = (ResistorStandard)this.comboBoxSeriesSelector.Items[this.comboBoxSeriesSelector.SelectedIndex];
            this.tolerance = (ResistorBand)this.comboBoxTolerance.Items[this.comboBoxTolerance.SelectedIndex];
            this.columnMultiplierB = (ResistorBand)this.comboBoxBColumn.Items[this.comboBoxBColumn.SelectedIndex];
            this.columnMultiplierI = (ResistorBand)this.comboBoxIColumn.Items[this.comboBoxIColumn.SelectedIndex];
            this.columnMultiplierN = (ResistorBand)this.comboBoxNColumn.Items[this.comboBoxNColumn.SelectedIndex];
            this.columnMultiplierG = (ResistorBand)this.comboBoxGColumn.Items[this.comboBoxGColumn.SelectedIndex];
            this.columnMultiplierO = (ResistorBand)this.comboBoxOColumn.Items[this.comboBoxOColumn.SelectedIndex];
            this.allResistors = new List<Resistor>(ResistorGenerator.generateResistorArray(this.series, this.tolerance, new ResistorBand[] { this.columnMultiplierB, this.columnMultiplierI, this.columnMultiplierN, this.columnMultiplierG, this.columnMultiplierO }));
            this.uncalledResistors = this.allResistors.ToList();
            this.calledResistors = new List<CalledResistor>();
            this.labelRemainingResistors.Text = "" + this.uncalledResistors.Count + " Resistors Remaining";
            this.currentResistor = new Resistor(new ResistorBand("Black"), new ResistorBand("Black"), new ResistorBand("Black"), new ResistorBand("Black"), new ResistorBand("Black"));
            this.display_bingohm_text = true;

            this.initDrawing();

            rng = new Random();
        }

        private void initDrawing ()
        {
            this.pane_w = this.pictureBoxDisplay.Width;
            this.pane_h = this.pictureBoxDisplay.Height;
            this.background = new Rectangle(new Point(0, 0), new Size(pane_w, pane_h));
            this.wire_cross = new Rectangle(new Point((int)(0.06 * pane_w), (int)(0.37 * pane_h)), new Size((int)(0.88 * pane_w), (int)(0.06 * pane_h)));
            this.wire_vert_left = new Rectangle(new Point((int)(0.06 * pane_w), (int)(0.37 * pane_h)), new Size((int)(0.04 * pane_w), (int)(0.53 * pane_h)));
            this.wire_vert_right = new Rectangle(new Point((int)(0.90 * pane_w), (int)(0.37 * pane_h)), new Size((int)(0.04 * pane_w), (int)(0.53 * pane_h)));
            this.resistor_base = new Rectangle(new Point((int)(0.16 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.68 * pane_w), (int)(0.60 * pane_h)));
            this.resistor_outline = new Rectangle(new Point((int)(0.16 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.68 * pane_w), (int)(0.60 * pane_h)));
            this.band1 = new Rectangle(new Point((int)(0.19 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band2 = new Rectangle(new Point((int)(0.32 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band3 = new Rectangle(new Point((int)(0.45 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band4 = new Rectangle(new Point((int)(0.58 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band5 = new Rectangle(new Point((int)(0.71 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band1_outline = new Rectangle(new Point((int)(0.19 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band2_outline = new Rectangle(new Point((int)(0.32 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band3_outline = new Rectangle(new Point((int)(0.45 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band4_outline = new Rectangle(new Point((int)(0.58 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band5_outline = new Rectangle(new Point((int)(0.71 * pane_w), (int)(0.1 * pane_h)), new Size((int)(0.1 * pane_w), (int)(0.60 * pane_h)));
            this.band1_text = new PointF((int)(0.19 * pane_w), (int)(0.7 * pane_h));
            this.band2_text = new PointF((int)(0.32 * pane_w), (int)(0.7 * pane_h));
            this.band3_text = new PointF((int)(0.45 * pane_w), (int)(0.7 * pane_h));
            this.band4_text = new PointF((int)(0.58 * pane_w), (int)(0.7 * pane_h));
            this.band5_text = new PointF((int)(0.71 * pane_w), (int)(0.7 * pane_h));
            this.resistor_text = new PointF((int)(0.16 * pane_w), (int)(0.75 * pane_h));
            this.resistor_text_redraw_area = new Rectangle((int)(0.16 * pane_w), (int)(0.75 * pane_h), (int)(0.68 * pane_w), (int)(0.90 * pane_h));
            this.background_color = Color.White;
            this.wire_color = Color.SlateGray;
            this.resistor_base_color = Color.Tan;
            this.outline_color = Color.Black;
            this.default_band_color = Color.Black;
            this.band_text_color = Color.Black;
            this.resistor_text_color = Color.Purple;
            this.background_painter = new SolidBrush(this.background_color);
            this.wire_painter = new SolidBrush(this.wire_color);
            this.resistor_base_painter = new SolidBrush(this.resistor_base_color);
            this.outline_painter = new Pen(this.outline_color);
            this.band_painter = new SolidBrush(this.default_band_color);
            this.band_text_painter = new SolidBrush(this.band_text_color);
            this.band_text_font = new Font(new FontFamily("Arial"), 20);
            this.resistor_text_painter = new SolidBrush(this.resistor_text_color);
            this.resistor_text_font = new Font(new FontFamily("Arial"), 40);
        }

        private void pictureBoxDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(this.background_painter, this.background);
            g.FillRectangle(this.wire_painter, this.wire_cross);
            g.FillRectangle(this.wire_painter, this.wire_vert_left);
            g.FillRectangle(this.wire_painter, this.wire_vert_right);
            g.FillRectangle(this.resistor_base_painter, this.resistor_base);
            g.DrawRectangle(this.outline_painter, this.resistor_outline);
            this.band_painter = new SolidBrush(this.currentResistor.Color1);
            g.FillRectangle(this.band_painter, this.band1);
            g.DrawRectangle(this.outline_painter, this.band1);
            this.band_painter = new SolidBrush(this.currentResistor.Color2);
            g.FillRectangle(this.band_painter, this.band2);
            g.DrawRectangle(this.outline_painter, this.band2);
            this.band_painter = new SolidBrush(this.currentResistor.Color3);
            g.FillRectangle(this.band_painter, this.band3);
            g.DrawRectangle(this.outline_painter, this.band3);
            if (this.currentResistor.IsFourColorStandard)
            {
                this.band_painter = new SolidBrush(this.currentResistor.Color4);
                g.FillRectangle(this.band_painter, this.band5);
                g.DrawRectangle(this.outline_painter, this.band5);
            }
            else
            {
                this.band_painter = new SolidBrush(this.currentResistor.Color4);
                g.FillRectangle(this.band_painter, this.band4);
                g.DrawRectangle(this.outline_painter, this.band4);
                this.band_painter = new SolidBrush(this.currentResistor.Color5);
                g.FillRectangle(this.band_painter, this.band5);
                g.DrawRectangle(this.outline_painter, this.band5);
            }
            if (this.display_bingohm_text)
            {
                g.DrawString("B", this.band_text_font, this.band_text_painter, this.band1_text);
                g.DrawString("I", this.band_text_font, this.band_text_painter, this.band2_text);
                g.DrawString("N", this.band_text_font, this.band_text_painter, this.band3_text);
                g.DrawString("G", this.band_text_font, this.band_text_painter, this.band4_text);
                g.DrawString(Constants.OMEGA, this.band_text_font, this.band_text_painter, this.band5_text);
                g.DrawString("UST IEEE", this.resistor_text_font, this.resistor_text_painter, this.resistor_text);
            }
            else
            {
                if (this.currentResistor.IsFourColorStandard)
                {
                    g.DrawString(this.currentResistor.ColorName1, this.band_text_font, this.band_text_painter, this.band1_text);
                    g.DrawString(this.currentResistor.ColorName2, this.band_text_font, this.band_text_painter, this.band2_text);
                    g.DrawString(this.currentResistor.ColorName3, this.band_text_font, this.band_text_painter, this.band3_text);
                    g.DrawString(this.currentResistor.ColorName4, this.band_text_font, this.band_text_painter, this.band5_text);
                }
                else
                {
                    g.DrawString(this.currentResistor.ColorName1, this.band_text_font, this.band_text_painter, this.band1_text);
                    g.DrawString(this.currentResistor.ColorName2, this.band_text_font, this.band_text_painter, this.band2_text);
                    g.DrawString(this.currentResistor.ColorName3, this.band_text_font, this.band_text_painter, this.band3_text);
                    g.DrawString(this.currentResistor.ColorName4, this.band_text_font, this.band_text_painter, this.band4_text);
                    g.DrawString(this.currentResistor.ColorName5, this.band_text_font, this.band_text_painter, this.band5_text);
                }
                if (this.reveal_countdown_inprogress)
                {
                    if (this.time_until_value_reveal > 0)
                    {
                        g.DrawString("Answer in " + this.time_until_value_reveal, this.resistor_text_font, this.resistor_text_painter, this.resistor_text);
                    }
                    else
                    {
                        g.DrawString("Value: " + this.currentResistor.ValueString, this.resistor_text_font, this.resistor_text_painter, this.resistor_text);
                        this.timerReveal.Stop();
                        this.reveal_countdown_inprogress = false;
                    }
                }
                else
                {
                    g.DrawString("Value: " + this.currentResistor.ValueString, this.resistor_text_font, this.resistor_text_painter, this.resistor_text);
                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.display_bingohm_text = false;

            if (this.timerReveal.Enabled)
            {
                Console.WriteLine("Timer was running when next resistor requested! Updating Called list first.");
                //this.calledResistors.Add(new CalledResistor(this.currentResistor, this.calledResistors.Count));
                this.listBoxCalled.Items.Add(new CalledResistor(this.currentResistor, this.calledResistors.Count));
                
            }

            int index = rng.Next(this.uncalledResistors.Count);
            this.currentResistor = this.uncalledResistors[index];
            this.pictureBoxDisplay.Invalidate();
            this.calledResistors.Add(new CalledResistor(this.currentResistor, this.calledResistors.Count));
            this.uncalledResistors.RemoveAt(index);
            this.labelRemainingResistors.Text = "" + this.uncalledResistors.Count + " Resistors Remaining";

            if (this.trackBarRevealTime.Value > 0)
            {
                if (this.reveal_countdown_inprogress)
                {
                    this.listBoxCalled.Items.Add(this.calledResistors[calledResistors.Count - 2]);
                }
                this.time_until_value_reveal = this.trackBarRevealTime.Value;
                this.timerReveal.Start();
                this.reveal_countdown_inprogress = true;
            }
            else
            {
                this.listBoxCalled.Items.Add(this.calledResistors[calledResistors.Count - 1]);
                if (this.listByValue)
                {
                    this.calledResistors = ResistorSorter.sortByValue(this.calledResistors);
                    this.listBoxCalled.Items.Clear();
                    this.listBoxCalled.Items.AddRange(this.calledResistors.ToArray());
                }
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            this.listBoxCalled.Items.Clear();
            this.allResistors = new List<Resistor>(ResistorGenerator.generateResistorArray(this.series, this.tolerance, new ResistorBand[] { this.columnMultiplierB, this.columnMultiplierI, this.columnMultiplierN, this.columnMultiplierG, this.columnMultiplierO }));
            this.uncalledResistors = this.allResistors.ToList();
            this.labelRemainingResistors.Text = "" + this.uncalledResistors.Count + " Resistors Remaining";
            this.calledResistors = new List<CalledResistor>();
            this.currentResistor = new Resistor(new ResistorBand("Black"), new ResistorBand("Black"), new ResistorBand("Black"), new ResistorBand("Black"), new ResistorBand("Black"));
            this.display_bingohm_text = true;
            this.pictureBoxDisplay.Invalidate();
        }

        private void trackBarRevealTime_Scroll(object sender, EventArgs e)
        {
            this.labelRevealTimeIndicator.Text = this.trackBarRevealTime.Value + " sec";
        }

        private void radioButtonSortOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonSortOrder.Checked)
            {
                this.listByValue = false;
                this.calledResistors = ResistorSorter.sortByOrder(this.calledResistors);
                this.listBoxCalled.Items.Clear();
                this.listBoxCalled.Items.AddRange(this.calledResistors.ToArray());
            }
        }

        private void radioButtonSortValue_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonSortValue.Checked)
            {
                this.listByValue = true;
                this.calledResistors = ResistorSorter.sortByValue(this.calledResistors);
                this.listBoxCalled.Items.Clear();
                this.listBoxCalled.Items.AddRange(this.calledResistors.ToArray());
            }
        }

        private void comboBoxSeriesSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.series = (ResistorStandard)this.comboBoxSeriesSelector.Items[this.comboBoxSeriesSelector.SelectedIndex];
        }

        private void comboBoxTolerance_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tolerance = (ResistorBand)this.comboBoxTolerance.Items[this.comboBoxTolerance.SelectedIndex];
        }

        private void comboBoxBColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.columnMultiplierB = (ResistorBand)this.comboBoxBColumn.Items[this.comboBoxBColumn.SelectedIndex];
        }

        private void comboBoxIColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.columnMultiplierI = (ResistorBand)this.comboBoxIColumn.Items[this.comboBoxIColumn.SelectedIndex];
        }

        private void comboBoxNColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.columnMultiplierN = (ResistorBand)this.comboBoxNColumn.Items[this.comboBoxNColumn.SelectedIndex];
        }

        private void comboBoxGColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.columnMultiplierG = (ResistorBand)this.comboBoxGColumn.Items[this.comboBoxGColumn.SelectedIndex];
        }

        private void comboBoxOColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.columnMultiplierO = (ResistorBand)this.comboBoxOColumn.Items[this.comboBoxOColumn.SelectedIndex];
        }

        private void timerReveal_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Reached a Timer Tick! timeLeft=" + this.time_until_value_reveal);
            this.time_until_value_reveal = this.time_until_value_reveal - 1;
            if (this.time_until_value_reveal == 0)
            {
                this.timerReveal.Stop();
            }
            this.pictureBoxDisplay.Invalidate(this.resistor_text_redraw_area);
        }

        private void buttonCheckValue_Click(object sender, EventArgs e)
        {

        }
    }

    public class Constants
    {
        public const string OMEGA = "\u03A9";

        public static readonly ResistorStandard[] OPTIONS_SERIES = { ResistorStandard.E6, ResistorStandard.E12, ResistorStandard.E24, ResistorStandard.E48, ResistorStandard.E96, ResistorStandard.E192 };
        public static readonly ResistorBandTolerance[] OPTIONS_TOLERANCE_BAND = { new ResistorBandTolerance("Gray"), new ResistorBandTolerance("Violet"), new ResistorBandTolerance("Blue"), new ResistorBandTolerance("Green"), new ResistorBandTolerance("Brown"), new ResistorBandTolerance("Red"), new ResistorBandTolerance("Gold"), new ResistorBandTolerance("Silver"), new ResistorBandTolerance("Transparent") };
        public static readonly ResistorBandMultiplier[] OPTIONS_DECADE_B = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        public static readonly ResistorBandMultiplier[] OPTIONS_DECADE_I = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        public static readonly ResistorBandMultiplier[] OPTIONS_DECADE_N = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        public static readonly ResistorBandMultiplier[] OPTIONS_DECADE_G = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
        public static readonly ResistorBandMultiplier[] OPTIONS_DECADE_O = { new ResistorBandMultiplier("Silver"), new ResistorBandMultiplier("Gold"), new ResistorBandMultiplier("Black"), new ResistorBandMultiplier("Brown"), new ResistorBandMultiplier("Red"), new ResistorBandMultiplier("Orange"), new ResistorBandMultiplier("Yellow"), new ResistorBandMultiplier("Green"), new ResistorBandMultiplier("Blue"), new ResistorBandMultiplier("Violet"), new ResistorBandMultiplier("Gray"), new ResistorBandMultiplier("White") };
    }

    public class ResistorBand
    {
        private static string[] NAMES = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Gray", "White", "Gold", "Silver", "Transparent" };
        private static Color[] COLORS = { Color.Black, Color.Brown, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Violet, Color.Gray, Color.White, Color.Gold, Color.Silver, Color.Transparent };
        private static int[] VALS = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, -1, -2, -999 };
        private static double[] TOLS = { -1, 1, 2, -1, -1, 0.5, 0.25, 0.1, 0.05, -1, 5, 10, 20 }; //percent

        private string name;
        private Color color;
        private int value;
        private double tolerance;

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Color Color
        {
            get
            {
                return this.color;
            }
        }
        public int Value
        {
            get
            {
                return this.value;
            }
        }
        public double Tolerance
        {
            get
            {
                return this.tolerance;
            }
        }

        public ResistorBand(string name)
        {
            this.name = name;
            this.color = COLORS[Array.IndexOf(NAMES, name)];
            this.value = VALS[Array.IndexOf(NAMES, name)];
            this.tolerance = TOLS[Array.IndexOf(NAMES, name)];
        }
        public ResistorBand(Color color)
        {
            this.name = NAMES[Array.IndexOf(COLORS, color)];
            this.color = color;
            this.value = VALS[Array.IndexOf(COLORS, color)];
            this.tolerance = TOLS[Array.IndexOf(COLORS, color)];
        }
        public ResistorBand(int value)
        {
            this.name = NAMES[Array.IndexOf(VALS, value)];
            this.color = COLORS[Array.IndexOf(VALS, value)];
            this.value = value;
            this.tolerance = TOLS[Array.IndexOf(VALS, value)];
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class ResistorBandMultiplier : ResistorBand
    {
        public ResistorBandMultiplier(string color) : base(color)
        {
            //nothing else
        }
        public override string ToString()
        {
            return base.ToString() + " " + Math.Pow(10,this.Value);
        }
    }

    public class ResistorBandTolerance : ResistorBand
    {
        public ResistorBandTolerance(string color) : base (color)
        {
            //nothing else
        }
        public override string ToString()
        {
            return base.ToString() + " " + this.Tolerance + "%";
        }
    }

    public class Resistor
    {
        private ResistorBand band1, band2, band3, band4, band5;
        private double value; //ohms
        private double tolerance; //percent
        private bool is4color; //else 5 color

        public double Value
        {
            get
            {
                return this.value;
            }
        }
        public string ValueString
        {
            get
            {
                double correctedValue = this.Value;
                string prefix = "";

                if (correctedValue > 999)
                {
                    correctedValue /= 1000.0;
                    prefix = "K";
                }
                if (correctedValue > 999)
                {
                    correctedValue /= 1000.0;
                    prefix = "M";
                }
                if (correctedValue > 999)
                {
                    correctedValue /= 1000.0;
                    prefix = "G";
                }
                return "" + correctedValue + prefix + Constants.OMEGA + " (+/-)" + this.Tolerance + "%";
            }
        }
        public double Tolerance
        {
            get
            {
                return this.tolerance;
            }
        }
        public bool IsFourColorStandard
        {
            get
            {
                return this.is4color;
            }
        }
        public bool IsFiveColorStandard
        {
            get
            {
                return !this.is4color;
            }
        }
        public Color Color1
        {
            get
            {
                return this.band1.Color;
            }
        }
        public Color Color2
        {
            get
            {
                return this.band2.Color;
            }
        }
        public Color Color3
        {
            get
            {
                return this.band3.Color;
            }
        }
        public Color Color4
        {
            get
            {
                if (this.IsFourColorStandard)
                {
                    return this.band5.Color;
                }
                else
                {
                    return this.band4.Color;
                }
            }
        }
        public Color Color5
        {
            get
            {
                if (this.IsFourColorStandard)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return this.band5.Color;
                }
            }
        }
        public string ColorName1
        {
            get
            {
                return this.band1.Name;
            }
        }
        public string ColorName2
        {
            get
            {
                return this.band2.Name;
            }
        }
        public string ColorName3
        {
            get
            {
                return this.band3.Name;
            }
        }
        public string ColorName4
        {
            get
            {
                if (this.IsFourColorStandard)
                {
                    return this.band5.Name;
                }
                else
                {
                    return this.band4.Name;
                }
            }
        }
        public string ColorName5
        {
            get
            {
                if (this.IsFourColorStandard)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return this.band5.Name;
                }
            }
        }

        public Resistor(ResistorBand band1, ResistorBand band2, ResistorBand band3, ResistorBand band4)
        {
            this.band1 = band1;
            this.band2 = band2;
            this.band3 = band3;
            this.band4 = null;
            this.band5 = band4;
            this.is4color = true;
            this.value = ((this.band1.Value * 10) + this.band2.Value) * Math.Pow(10, this.band3.Value);
            this.tolerance = this.band5.Tolerance;
        }
        public Resistor(ResistorBand band1, ResistorBand band2, ResistorBand band3, ResistorBand band4, ResistorBand band5)
        {
            this.band1 = band1;
            this.band2 = band2;
            this.band3 = band3;
            this.band4 = band4;
            this.band5 = band5;
            this.is4color = false;
            this.value = (((this.band1.Value * 100) + (this.band2.Value * 10) + this.band3.Value)) * Math.Pow(10, this.band4.Value);
            this.tolerance = this.band5.Tolerance;
        }

        public override string ToString()
        {
            double correctedValue = this.Value;
            string prefix = "";

            if (correctedValue > 999)
            {
                correctedValue /= 1000.0;
                prefix = "K";
            }
            if (correctedValue > 999)
            {
                correctedValue /= 1000.0;
                prefix = "M";
            }
            if (correctedValue > 999)
            {
                correctedValue /= 1000.0;
                prefix = "G";
            }

            if (this.IsFourColorStandard)
            {
                return "{" + correctedValue + prefix + Constants.OMEGA + " (+/-)" + this.Tolerance + "% " + ": " + this.ColorName1 + ", " + this.ColorName2 + ", " + this.ColorName3 + ", " + this.ColorName4 + "}";
            }
            else
            {
                return "{" + correctedValue + prefix + Constants.OMEGA + " (+/-)" + this.Tolerance + "% " + ": " + this.ColorName1 + ", " + this.ColorName2 + ", " + this.ColorName3 + ", " + this.ColorName4 + ", " + this.ColorName5 + "}";
            }
        }
    }

    public class ResistorStandard
    {
        public static ResistorStandard E6 = new ResistorStandard(new int[]{ 10, 15, 22, 33, 47, 68 });
        public static ResistorStandard E12 = new ResistorStandard(new int[] { 10, 12, 15, 18, 22, 27, 33, 39, 47, 56, 68, 82 });
        public static ResistorStandard E24 = new ResistorStandard(new int[] { 10, 11, 12, 13, 15, 16, 18, 20, 22, 24, 27, 30, 33, 36, 39, 43, 47, 51, 56, 62, 68, 75, 82, 91 });
        public static ResistorStandard E48 = new ResistorStandard(new int[] { 100, 105, 110, 115, 121, 127, 133, 140, 147, 154, 162, 169, 178, 187, 196, 205, 215, 226, 237, 249, 261, 274, 287, 301, 316, 332, 348, 365, 383, 402, 422, 442, 464, 487, 511, 536, 562, 590, 619, 649, 681, 715, 750, 787, 825, 866, 909, 953 });
        public static ResistorStandard E96 = new ResistorStandard(new int[] { 100, 102, 105, 107, 110, 113, 115, 118, 121, 124, 127, 130, 133, 137, 140, 143, 147, 150, 154, 158, 162, 165, 169, 174, 178, 182, 187, 191, 196, 200, 205, 210, 215, 221, 226, 232, 237, 243, 249, 255, 261, 267, 274, 280, 287, 294, 301, 309, 316, 324, 332, 340, 348, 357, 365, 374, 383, 392, 402, 412, 422, 432, 442, 453, 464, 475, 487, 499, 511, 523, 536, 549, 562, 576, 590, 604, 619, 634, 649, 665, 681, 698, 715, 732, 750, 768, 787, 806, 825, 845, 866, 887, 909, 931, 953, 976 });
        public static ResistorStandard E192 = new ResistorStandard(new int[] { 100, 101, 102, 104, 105, 106, 107, 109, 110, 111, 113, 114, 115, 117, 118, 120, 121, 123, 124, 126, 127, 129, 130, 132, 133, 135, 137, 138, 140, 142, 143, 145, 147, 149, 150, 152, 154, 156, 158, 160, 162, 164, 165, 167, 169, 172, 174, 176, 178, 180, 182, 184, 187, 189, 191, 193, 196, 198, 200, 203, 205, 208, 210, 213, 215, 218, 221, 223, 226, 229, 232, 234, 237, 240, 243, 246, 249, 252, 255, 258, 261, 264, 267, 271, 274, 277, 280, 284, 287, 291, 294, 298, 301, 305, 309, 312, 316, 320, 324, 328, 332, 336, 340, 344, 348, 352, 357, 361, 365, 370, 374, 379, 383, 388, 392, 397, 402, 407, 412, 417, 422, 427, 432, 437, 442, 448, 453, 459, 464, 470, 475, 481, 487, 493, 499, 505, 511, 517, 523, 530, 536, 542, 549, 556, 562, 569, 576, 583, 590, 597, 604, 612, 619, 626, 634, 642, 649, 657, 665, 673, 681, 690, 698, 706, 715, 723, 732, 741, 750, 759, 768, 777, 787, 796, 806, 816, 825, 835, 845, 856, 866, 876, 887, 898, 909, 920, 931, 942, 953, 965, 976, 988 });

        private int[] preferredValues;
        private bool is4color;

        public int[] PreferredValues
        {
            get
            {
                return this.preferredValues;
            }
        }
        public bool IsFourColorStandard
        {
            get
            {
                return this.is4color;
            }
        }
        public bool IsFiveColorStandard
        {
            get
            {
                return !this.is4color;
            }
        }

        private ResistorStandard(int[] preferredValues)
        {
            this.preferredValues = preferredValues;
            this.is4color = (this.preferredValues[0] / 100) == 0;
        }
        public override string ToString()
        {
            return "E" + this.PreferredValues.Length + " Standard";
        }
    }

    public class ResistorGenerator
    {
        public static Resistor[] generateResistorArray(ResistorStandard standard, ResistorBand tolerance, ResistorBand[] decades)
        {
            int[] prefVals = standard.PreferredValues;
            Resistor[] result = new Resistor[prefVals.Length * decades.Length];
            for (int itDecade = 0; itDecade < decades.Length; itDecade++)
            {
                for (int itPrefVal = 0; itPrefVal < prefVals.Length; itPrefVal++)
                {
                    if (standard.IsFourColorStandard)
                    {
                        result[(itDecade * prefVals.Length) + itPrefVal] = new Resistor(new ResistorBand(prefVals[itPrefVal] / 10), new ResistorBand(prefVals[itPrefVal] % 10), decades[itDecade], tolerance);
                    }
                    else
                    {
                        result[(itDecade * prefVals.Length) + itPrefVal] = new Resistor(new ResistorBand(prefVals[itPrefVal] / 100), new ResistorBand((prefVals[itPrefVal] % 100) / 10), new ResistorBand(prefVals[itPrefVal] % 10), decades[itDecade], tolerance);
                    }
                    //Console.WriteLine("Created resistor: " + result[(itDecade * prefVals.Length) + itPrefVal] + " at " + ((itDecade * prefVals.Length) + itPrefVal));
                }
            }
            return result;
        }
    }

    public class CalledResistor
    {
        private Resistor resistor;
        private int calledIndex;

        public Resistor Resistor
        {
            get
            {
                return this.resistor;
            }
        }
        public int Index
        {
            get
            {
                return this.calledIndex;
            }
        }

        public CalledResistor(Resistor resistor, int calledIndex)
        {
            this.resistor = resistor;
            this.calledIndex = calledIndex;
        }
        public override string ToString()
        {
            return this.resistor.ToString();
        }
    }

    public class ResistorSorter
    {
        public static List<CalledResistor> sortByValue(List<CalledResistor> list)
        {
            List<CalledResistor> sorted = new List<CalledResistor>();
            int originalLength = list.Count;
            for (int i = 0; i < originalLength; i++)
            {
                CalledResistor smallestResistor = list[0];
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].Resistor.Value < smallestResistor.Resistor.Value)
                    {
                        smallestResistor = list[j];
                    }
                }
                sorted.Add(smallestResistor);
                list.Remove(smallestResistor);
            }
            return sorted;
        }
        public static List<CalledResistor> sortByOrder(List<CalledResistor> list)
        {
            List<CalledResistor> sorted = new List<CalledResistor>();
            int originalLength = list.Count;
            for (int i = 0; i < originalLength; i++)
            {
                CalledResistor calledEarliest = list[0];
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j].Index < calledEarliest.Index)
                    {
                        calledEarliest = list[j];
                    }
                }
                sorted.Add(calledEarliest);
                list.Remove(calledEarliest);
            }
            return sorted;
        }
    }
}
