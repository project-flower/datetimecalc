using System;
using System.Windows.Forms;

namespace datetimecalc
{
    public partial class FormMain : Form
    {
        void calcDays()
        {
            numericUpDownDay.Value = (dateTimePicker2.Value - dateTimePicker1.Value).Days;
        }

        void showErrorMessage(Exception exception)
        {
            MessageBox.Show(exception.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public FormMain()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker1.MaxDate = DateTimePicker.MaximumDateTime;
            dateTimePicker2.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker2.MaxDate = DateTimePicker.MaximumDateTime;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1.Value = dateTimePicker1.Value.Date;
            dateTimePicker2.Value = dateTimePicker2.Value.Date;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownDay.ValueChanged -= numericUpDownDay_ValueChanged;

            try
            {
                numericUpDownDay.Maximum = (dateTimePicker1.MaxDate - dateTimePicker1.Value.Date).Days;
                numericUpDownDay.Minimum = ((dateTimePicker1.Value.Date - dateTimePicker1.MinDate).Days * -1);
                calcDays();
            }
            catch (Exception exception)
            {
                showErrorMessage(exception);
            }
            finally
            {
                numericUpDownDay.ValueChanged += numericUpDownDay_ValueChanged;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownDay.ValueChanged -= numericUpDownDay_ValueChanged;

            try
            {
                calcDays();
            }
            catch (Exception exception)
            {
                showErrorMessage(exception);
            }
            finally
            {
                numericUpDownDay.ValueChanged += numericUpDownDay_ValueChanged;
            }
        }

        private void numericUpDownDay_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.ValueChanged -= dateTimePicker2_ValueChanged;

            try
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays((double)numericUpDownDay.Value);
            }
            catch (Exception exception)
            {
                showErrorMessage(exception);
            }
            finally
            {
                dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            }
        }
    }
}
