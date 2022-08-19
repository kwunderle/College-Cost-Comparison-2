using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeCostComparison___Katharine_Wunderle
{
    //Author: Katharine Wunderle
    //ID: 623748
    //Date: 04/21/2021
    //Goal: Call a method with an out variable to compare costs of 2 colleges
    public partial class BYOMethodWithParmOut : Form
    {
        //Declare constants
        private const decimal GAS_PRICE = 2.50m;
        private const int MPG = 25;
        public BYOMethodWithParmOut()
        {
            InitializeComponent();
        }
        //Declare method to calculate fuel cost
        private void KatharineWunderleMETHODCalcOneYearFuelCostPART2 (int parm2_Trip, decimal parm2_Distance, out decimal localOUT_OneYearFuelCost, decimal parm2_GasCost = GAS_PRICE, int parm2_MPG = MPG)
        {
            localOUT_OneYearFuelCost = parm2_Trip * parm2_Distance/parm2_MPG * parm2_GasCost; }

        private void calcBtn_Click(object sender, EventArgs e)
        {
        //Declare variables
            int trips1 = 0;
            int trips2 = 0;
            decimal distance1;
            decimal distance2;
            decimal app1;
            decimal app2;
            decimal tuition1;
            decimal tuition2;
            decimal room1;
            decimal room2;
            decimal fuelTotal1;
            decimal fuelTotal2;
            decimal totalCost1;
            decimal totalCost2;
            bool tryParseBool;

        //Get college names and validate input from user
            if (college1NameInput.Text == "" || college2NameInput.Text == "")
                {
                    MessageBox.Show("Error: Please enter the college names.");
                    return;
                }

        //Get state names and validate input from user
            if (college1StateInput.Text == "" || college2StateInput.Text == "")
                {
                    MessageBox.Show("Error: Please enter the state names.");
                    return;
                }

        //Get trip numbers and validate input from user
            tryParseBool = int.TryParse(college1TripsInput.Text, out trips1);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the number of trips.");
                    return;
                }
            tryParseBool = int.TryParse(college2TripsInput.Text, out trips2);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the number of trips.");
                    return;
                }

        //Get distances and validate input from user
            tryParseBool = decimal.TryParse(college1Distance.Text, out distance1);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the distances.");
                    return;
                }
            tryParseBool = decimal.TryParse(college2Distance.Text, out distance2);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the distances.");
                    return;
                }

        //Get application fee cost and validate input from user
            tryParseBool = decimal.TryParse(college1AppFee.Text, out app1);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the application fees.");
                    return;
                }

            tryParseBool = decimal.TryParse(college2AppFee.Text, out app2);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the application fees.");
                    return;
                }

        //Get annual tuition cost and validate input from user
            tryParseBool = decimal.TryParse(college1Tuition.Text, out tuition1);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the tuition amounts.");
                    return;
                }
            tryParseBool = decimal.TryParse(college2Tuition.Text, out tuition2);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the tuition amounts.");
                    return;
                }

        //Get annual room and board cost and validate input from user
            tryParseBool = decimal.TryParse(college1RoomCost.Text, out room1);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter the room costs.");
                    return;
                }
            tryParseBool = decimal.TryParse(College2RoomCost.Text, out room2);
            if (tryParseBool == false)
                {
                    MessageBox.Show("Error: Please enter room costs.");
                    return;
                }
            //Calculate total fuel cost for each college
            //fuelTotal1 = (decimal)((trips1 * distance1) / MPG) * GAS_PRICE;
            //fuelTotal2 = (decimal)((trips2 * distance2) / MPG) * GAS_PRICE;

            //Call method for each fuel calculation
            //fuelTotal1 = KatharineWunderleMETHODCalcOneYearFuelCost(trips1, distance1, totalCost1);
            //fuelTotal2 = KatharineWunderleMETHODCalcOneYearFuelCost(trips2, distance2, totalCost2);

        //Call method with out variable for fuel calculation
            KatharineWunderleMETHODCalcOneYearFuelCostPART2(trips1, distance1, out fuelTotal1);
            KatharineWunderleMETHODCalcOneYearFuelCostPART2(trips2, distance2, out fuelTotal2);
            
        //Calculate all costs for 4 years
            totalCost1 = app1 + (fuelTotal1 * 4) + (tuition1 * 4) + (room1 * 4);
            totalCost2 = app2 + (fuelTotal2 * 4) + (tuition2 * 4) + (room2 * 4);

        //Display total fuel costs
            college1FuelCost.Text = fuelTotal1.ToString("c");
            college2FuelCost.Text = fuelTotal2.ToString("c");

        //Display 4 year total of all costs
            college1TotalCost.Text = totalCost1.ToString("c");
            college2TotalCost.Text = totalCost2.ToString("c");

                //Highlight higher cost in red
                if (totalCost1 > totalCost2)
                {
                    college1TotalCost.BackColor = Color.Red;
                    college2TotalCost.BackColor = Color.White;
                }
                if (totalCost1 < totalCost2)
                {
                    college1TotalCost.BackColor = Color.White;
                    college2TotalCost.BackColor = Color.Red;
                }
                if (totalCost1 == totalCost2)
                {
                    college1TotalCost.BackColor = Color.White;
                    college2TotalCost.BackColor = Color.White;
                }
            }
        }
    }
