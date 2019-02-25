using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> list;
        Random rand = new Random();
        bool isNumber;
        Comparison<int> comparator;

        private void GenerateCollectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputBox.Text.First() != '0')
                {
                    for (int i = 0; i < InputBox.Text.Length; i++)
                    {
                        if (InputBox.Text[i] >= '0' && InputBox.Text[i] <= '9')
                        {
                            isNumber = true;
                        }
                        else
                        {
                            isNumber = false;
                        }

                    }
                    if (isNumber)
                    {
                        try
                        {
                            list = new List<int>(Int32.Parse(InputBox.Text));
                            for (int i = 0; i < Int32.Parse(InputBox.Text); i++)
                            {
                                list.Add(rand.Next(50));
                            }
                            CollectionElementsListBox.Items.Clear();
                            foreach (int el in list)
                            {
                                CollectionElementsListBox.Items.Add("Элемент коллекции = " + el.ToString());
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            MessageBox.Show("Размер коллекции не может быть отрицательным");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите целое положительное число");
                    }
                }
                else
                {
                    MessageBox.Show("Размер коллекции не может быть равен нулю");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int Comparator(int value1, int value2)
            {
                if (button.Name.ToString() == "SortAscendingButton")
                {
                    return value1.CompareTo(value2);
                }
                else if (button.Name.ToString() == "SortDescendingButton")
                {
                    return -1 * value1.CompareTo(value2);
                }
                else return 0;
            }
            try
            {
                comparator = Comparator;
                list.Sort(comparator);
                RequestCollectionElementsListBox.Items.Clear();
                foreach (int el in list)
                {
                    RequestCollectionElementsListBox.Items.Add("Элемент коллекции = " + el.ToString());
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Нельзя сортировать пустую коллекцию");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RequestButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                RequestCollectionElementsListBox.Items.Clear();
                if (button.Name.ToString() == "MinButton")
                {
                    RequestCollectionElementsListBox.Items.Add(list.Min());
                }
                else if (button.Name.ToString() == "MaxButton")
                {
                    RequestCollectionElementsListBox.Items.Add(list.Max());
                }
                else
                {
                    RequestCollectionElementsListBox.Items.Add(list.Average());
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Нельзя сортировать пустую коллекцию");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
