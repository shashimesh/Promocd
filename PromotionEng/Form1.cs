﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromotionEng
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] row = new string[] { "1", "A", "50",null,"3","130" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "B", "30", null, "2", "45" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "C", "20", null, "0", "0" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "4", "D", "15", null, "0", "0" };              
            dataGridView1.Rows.Add(row);                                    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbltotal.Text = "0";

            if (cmbTypes.SelectedIndex < 0)
            {
                MessageBox.Show("Please select promotion type");
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[3].Value == null && dataGridView1.Rows[i].Cells[3].ReadOnly == false)
                {
                    MessageBox.Show("pls enter Qnty for ID " + dataGridView1.Rows[i].Cells[0].Value);
                    return;
                }
            }
                     
            if (cmbTypes.SelectedIndex == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].ReadOnly == false)
                    { 
                    if ((int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) >= int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())) && (int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) > 0))
                    {
                        double iGet = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()) / Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());

                        if ((iGet % 1) == 0)
                        {
                            lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) * (int)iGet));
                        }
                        else
                        {
                            if (int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) % int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) == 2)
                            {
                                lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) * (int)iGet) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * 2);
                            }
                            else
                            {
                                lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) * (int)iGet) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            }

                        }

                    }
                    else
                    {
                        lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString())));
                    }
                    }
                }
            }
            else if (cmbTypes.SelectedIndex == 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if ((int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) >= int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())) && (int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) > 0))
                    {
                        double iGet = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()) / Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());

                        if ((iGet % 1) == 0)
                        {
                            lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) * (int)iGet));
                        }
                        else
                        {
                            if (int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) % int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) == 2)
                            {
                                lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) * (int)iGet) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) * 2);
                            }
                            else
                            {
                                lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + (int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()) * (int)iGet) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            }

                        }

                    }
                    else
                    {
                        lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + 15);
                    }
                }
            }
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypes.SelectedIndex == 0)
            {
                dataGridView1.Rows[3].Cells[3].Value = "NA";
                dataGridView1.Rows[3].Cells[3].ReadOnly = true;
                dataGridView1.Rows[2].Cells[3].ReadOnly = false;
            }
            else if (cmbTypes.SelectedIndex == 1)
            {
                dataGridView1.Rows[3].Cells[3].Value = "1";
                dataGridView1.Rows[2].Cells[3].Value = "1";
                dataGridView1.Rows[3].Cells[3].ReadOnly = true;                
                dataGridView1.Rows[2].Cells[3].ReadOnly = true;

            }
            else
            {
                dataGridView1.Rows[3].Cells[3].Value = "";
                dataGridView1.Rows[2].Cells[3].Value = "";
                dataGridView1.Rows[3].Cells[3].ReadOnly = false;
                dataGridView1.Rows[2].Cells[3].ReadOnly = false;
            }
        }
        
    }
}
