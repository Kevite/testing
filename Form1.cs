using System;
using System.Collections;
using System.IO;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Лабораторная__3_5
{
    public partial class AdminForm : Form
    {
        ArrayList list = new ArrayList();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddHotelDialog dlg = new AddHotelDialog();
            dlg.HotelAdded += (s, args) =>
            {
                if (!string.IsNullOrEmpty(dlg.City) && !string.IsNullOrEmpty(dlg.HotelName) && dlg.Rooms > 0 && dlg.Rate > 0)
                {
                    Hotel ob = new Hotel(dlg.City, dlg.HotelName, dlg.Rooms, dlg.Rate);
                    list.Add(ob);

                    String a = dlg.City + "," + dlg.HotelName + "," + dlg.Rooms.ToString() + "," + dlg.Rate.ToString();
                    hotellist.Items.Add(a);
                }
                else
                {
                    MessageBox.Show("Введите корректные данные", "Hotel Broker Administration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            };

            dlg.ShowDialog();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите закрыть?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hotel ob1 = new Hotel("Москва", "Россия", 200, 1500);
            list.Add(ob1);
            Hotel ob2 = new Hotel("Москва", "Прага", 200, 3000);
            list.Add(ob2);
            Hotel ob3 = new Hotel("Новосибирск", "Объ", 150, 1500);
            list.Add(ob3);
            Hotel ob4 = new Hotel("Новосибирск", "Тратата", 300, 1200);
            list.Add(ob4);

            hotellist.Items.Clear();
            if (list == null)
            {
                return;
            }
            foreach (Hotel hotel in list)
            {
                String city = hotel.City.Trim();
                String name = hotel.HotelName.Trim();
                String rooms = hotel.Rooms.ToString();
                String rate = hotel.Rate.ToString();
                String str = city + "," + name + "," + rooms + "," + rate;
                hotellist.Items.Add(str);
            }
        }

        private void hotellist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hotellist.SelectedIndex != -1)
            {
                String selected = hotellist.SelectedItem.ToString();
                String[] fields;
                fields = selected.Split(',');
                label1.Text = fields[0];
                label2.Text = fields[1];
                label3.Text = fields[2];
                label4.Text = fields[3];
            }
            else
            {
                label1.Text = "";
            }
        }
    }
}