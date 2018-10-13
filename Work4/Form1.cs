using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work4
{
    public partial class Form1 : Form
    {
        private Dictionary<string, bool> mp = new Dictionary<string, bool>(); //标记每个商品是否被选择过

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = comboBox1.Text;
            foreach(Product o in Program.product)
            {
                if(o.Name == str)
                {
                    label5.Text = o.Name;
                    float test = o.Price;
                    label6.Text = test.ToString("f2");
                    label7.Text = o.Stock.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float ans = 0;
            bool flag = false;
            string s1 = comboBox2.Text;
            string s2 = comboBox3.Text;
            string s3 = comboBox4.Text;
            string s4 = comboBox5.Text;
            string s5 = comboBox6.Text;
            int cnt1,  cnt2, cnt3, cnt4, cnt5;
            if (s1 == "无") cnt1 = 0;
            else cnt1 = int.Parse(textBox1.Text);
            if (s2 == "无") cnt2 = 0;
            else cnt2 = int.Parse(textBox2.Text);
            if (s3 == "无") cnt3 = 0;
            else cnt3 = int.Parse(textBox3.Text);
            if (s4 == "无") cnt4 = 0;
            else cnt4 = int.Parse(textBox4.Text);
            if (s5 == "无") cnt5 = 0;
            else cnt5 = int.Parse(textBox5.Text);

            if (Judge(s1, cnt1))
            {
                if(Judge(s2, cnt2))
                {
                    if(Judge(s3, cnt3))
                    {
                        if(Judge(s4, cnt4))
                        {
                            if(Judge(s5, cnt5))
                            {
                                flag = true;
                            }
                        }
                    }
                }
            }

            if (flag)
            {
                //所有产品的余额都充足
                ans += Find(s1).Price * cnt1;
                ans += Find(s2).Price * cnt2;
                ans += Find(s3).Price * cnt3;
                ans += Find(s4).Price * cnt4;
                ans += Find(s5).Price * cnt5;

                textBox6.Text = "您所选购的商品总额为： " + ans.ToString("f2");

                comboBox2.Text = "无";
                comboBox3.Text = "无";
                comboBox4.Text = "无";
                comboBox5.Text = "无";
                comboBox6.Text = "无";

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                mp.Clear();
            }

            //更新库存
            Find(s1).Stock -= cnt1;
            Find(s2).Stock -= cnt2;
            Find(s3).Stock -= cnt3;
            Find(s4).Stock -= cnt4;
            Find(s5).Stock -= cnt5;
        }
        
        private Product Find(string str)
        {
            foreach (Product o in Program.product)
            {
                if (o.Name == str)
                    return o;
            }
            return null;
        }

        private bool Judge(string s, int cnt)   //对每一个选择进行判断
        {
            bool x;
            if (s == "无") return true;  //若为“无”则跳过判断
            if (mp.TryGetValue(s, out x))   //判断是否选择了重复的商品
            {
                textBox6.Text = "不能选择重复的商品！";
                return false;
            }
            else if (Find(s).Stock < cnt)   //判断是否选择的商品数量大于库存
            {
                textBox6.Text = "产品库存不足！";
                return false;
            }
            else
            {
                mp[s] = true;
                return true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = textBox7.Text;
            int x = int.Parse(textBox8.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string choice = comboBox7.Text;
            if(choice == "修改")
            {
                Product o = Find(textBox7.Text);
                if (o == null)
                {
                    MessageBox.Show("没有这个商品！");
                }
                else
                {
                    o.Price = float.Parse(textBox8.Text);
                    o.Stock = int.Parse(textBox9.Text);
                    MessageBox.Show("修改成功！");
                    comboBox7.Text = "功能选择";
                    textBox7.Text = "";     //置空
                    textBox8.Text = "";
                    textBox9.Text = "";
                }
            }
            else if(choice == "添加")
            {
                string name = textBox7.Text;
                float price = float.Parse(textBox8.Text);
                int stock = int.Parse(textBox9.Text);
                Product o = new Product(name, price, stock);
                Program.product.Add(o);
                comboBox1.Items.Add(name);  //将各个下拉框添加该商品
                comboBox2.Items.Add(name);
                comboBox3.Items.Add(name);
                comboBox4.Items.Add(name);
                comboBox5.Items.Add(name);
                comboBox6.Items.Add(name);
                MessageBox.Show("添加成功！");
            }
            else
            {
                Product o = Find(textBox7.Text);
                if(o == null)
                {
                    MessageBox.Show("没有这个商品！");
                }
                else
                {
                    Program.product.Remove(o);
                    comboBox1.Items.Remove(textBox7.Text);  //将各个下拉框的该商品删除
                    comboBox2.Items.Remove(textBox7.Text);
                    comboBox3.Items.Remove(textBox7.Text);
                    comboBox4.Items.Remove(textBox7.Text);
                    comboBox5.Items.Remove(textBox7.Text);
                    comboBox6.Items.Remove(textBox7.Text);
                    MessageBox.Show("删除成功！");
                }
            }
        }
    }
}
