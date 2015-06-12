using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace BingOhm.Resistors
{
    class ResistorBand
    {
        private static readonly ResistorBand[] OPTS = { 
                                                      new ResistorBand("Black", Color.Black, 0, -1),
                                                      new ResistorBand("Brown", Color.Brown, 1, 1),
                                                      new ResistorBand("Red", Color.Red, 2, 2),
                                                      new ResistorBand("Orange", Color.Orange, 3, -1),
                                                      new ResistorBand("Yellow", Color.Yellow, 4, -1),
                                                      new ResistorBand("Green", Color.Green, 5, 0.5),
                                                      new ResistorBand("Blue", Color.Blue, 6, 0.25),
                                                      new ResistorBand("Violet", Color.Violet, 7, 0.1),
                                                      new ResistorBand("Gray", Color.Gray, 8, 0.05),
                                                      new ResistorBand("White", Color.White, 9, -1),
                                                      new ResistorBand("Gold", Color.Gold, -1, 5),
                                                      new ResistorBand("Silver", Color.Silver, -2, 10),
                                                      new ResistorBand("Transparent", Color.Transparent, -999, 20)
                                                      };
        private int index;

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

        private ResistorBand(string name, Color color, int value, double tolerance)
        {
            this.name = name;
            this.color = color;
            this.value = value;
            this.tolerance = tolerance;
        }
        private ResistorBand()
        {
            ResistorBand.OPTS.DefaultIfEmpty(new ResistorBand("ERROR", Color.HotPink, -999, -1));
        }
        public ResistorBand(string name) : this()
        {
            //ResistorBand.OPTS.Where(r => r.Name.Equals(name));
            //ResistorBand.OPTS.SingleOrDefault(r => r.Name.Equals(name));
            try
            {
                this.index = Array.IndexOf(ResistorBand.OPTS, ResistorBand.OPTS.Single(r => r.Name.Equals(name)));
            }
            catch
            {
                Console.WriteLine("Invalid Resistor Name!");
            }
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
}
