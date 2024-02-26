using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOTTE
{
    public partial class Form1 : Form
    {
        List<LOTCOMPOSE> LOTCOM = new List<LOTCOMPOSE>();
        List<Panel> COMPANEL = new List<Panel>();
        //List<Button> DelBtn = new List<Button>();
        int[] rndarray = new int[12];
        int[] rndarray2 = new int[12];
        int TO = 0, RA = 0, SAN = 0, SU = 0,KON=0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //產生新號碼組
        {

            Panel PN = new Panel();
            PN.BackColor = Color.LightPink;
            PN.ForeColor = Color.Blue;
            PN.Name = "PN" + COMPANEL.Count.ToString();
            PN.Font = new Font("微軟正黑體", 16);
            PN.Size = new Size(466, 109);
            PN.Location = new Point(9, 67 + 115 * COMPANEL.Count);

            Controls.Add(PN);
            COMPANEL.Add(PN);

            LOTFACE.Location = new Point(9, 67 + 115 * COMPANEL.Count);

            LOTCOMPOSE NWLC = new LOTCOMPOSE();//新號碼組別

            for (int i = 0; i < 3; i += 1)
            {
                for (int j = 0; j < 8; j += 1)
                {
                    LOTBTN dButton = new LOTBTN();
                    dButton.BackColor = Color.White;
                    dButton.ForeColor = Color.Black;
                    dButton.Text = (i * 8 + j + 1).ToString();
                    dButton.Name = "btn" + (i * 8 + j + 1).ToString();
                    dButton.Font = new Font("新細明體", 9);
                    dButton.Size = new Size(29, 31);
                    dButton.Location = new Point(46 + j * 35, 3 + i * 37);

                    dButton.GOUP = COMPANEL.Count - 1;
                    dButton.SeleteNum = i * 8 + j + 1;

                    COMPANEL[COMPANEL.Count-1].Controls.Add(dButton);
                    NWLC.NUMOFBTN.Add(dButton);
                    dButton.Click += new EventHandler(NUMBER_CLICK);
                }
            }//數字按鈕創建


            Label LL = new Label();
            LL.BackColor = System.Drawing.SystemColors.Info;
            LL.Location = new System.Drawing.Point(382, 4);
            LL.Name = "label2";
            LL.Size = new System.Drawing.Size(81, 105);
            LL.Text = "";
            LL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            COMPANEL[COMPANEL.Count - 1].Controls.Add(LL);
            NWLC.STAT = LL;


            GROUPBTN RDRD = new GROUPBTN(); 
            RDRD.BackColor = Color.White;
            RDRD.ForeColor = Color.Black;
            RDRD.Text = "隨機選號";
            RDRD.Name = "隨機選號";
            RDRD.Font = new Font("新細明體", 9);
            RDRD.Size = new Size(50, 104);
            RDRD.Location = new Point(326, 4);

            RDRD.GOUP = COMPANEL.Count - 1;

            COMPANEL[COMPANEL.Count - 1].Controls.Add(RDRD);
            NWLC.RAND = RDRD;
            RDRD.Click += new EventHandler(RND_CLICK);//隨機按鈕創建




            GROUPBTN DELBN = new GROUPBTN();
            DELBN.BackColor = Color.White;
            DELBN.ForeColor = Color.Black;
            DELBN.Text = "x";
            DELBN.Name = "x" ;
            DELBN.Font = new Font("新細明體", 9);
            DELBN.Size = new Size(36, 102);
            DELBN.Location = new Point(4, 4);


            DELBN.GOUP = COMPANEL.Count - 1;

            COMPANEL[COMPANEL.Count - 1].Controls.Add(DELBN);
            NWLC.DELBTN = DELBN;
            DELBN.Click += new EventHandler(DEL_CLICK);

            LOTCOM.Add(NWLC);


            ValDEMIN();
        }//產生新號碼組
        
        void NUMBER_CLICK(object sender, EventArgs e)  //泛用數字按鈕
        {

            LOTBTN myButton = (LOTBTN)sender;
            int CCC = myButton.GOUP;

            if (myButton.COUT)
            {


                myButton.BackColor = Color.White;
                myButton.COUT = false;
                LOTCOM[CCC].LOOT--;
                LOTCOM[CCC].Vaild = 0;
            }
            else
            {
                if (LOTCOM[CCC].LOOT < 12)
                {
                    myButton.BackColor = Color.Red;
                    myButton.COUT = true;
                    LOTCOM[CCC].LOOT++;
                    if (LOTCOM[CCC].LOOT == 12)
                    {
                        LOTCOM[CCC].Vaild = 1;
                    }
                }
                else
                {
                    MessageBox.Show("超過12個");

                }
            }

            ValDEMIN();
        }
        
        void DEL_CLICK(object sender, EventArgs e) //刪除按鈕
        {
            GROUPBTN DDD = (GROUPBTN)sender;
            int DL = DDD.GOUP;

            Controls.Remove(COMPANEL[DL]);
            COMPANEL.RemoveAt(DL);
            LOTCOM.RemoveAt(DL);

            REPILIE();
            ValDEMIN();

        }
        
        void REPILIE()
        {
            int a=0;
            for(int i=0;i< COMPANEL.Count(); i++)
            {
                COMPANEL[i].Location = new Point(9, 67 + 115 * i);
                LOTCOM[i].RAND.GOUP = i;
                LOTCOM[i].DELBTN.GOUP = i;
                for(int j = 0; j < 24; j++)
                {
                    LOTCOM[i].NUMOFBTN[j].GOUP = i;

                }

                a = i+1;

            }

            LOTFACE.Location = new Point(9, 67 + 115 * (a ));

        }//位置調整
        
        void RND_CLICK(object sender, EventArgs e) //隨機按鈕
        {
            GROUPBTN RRRR = (GROUPBTN)sender;
            int R = RRRR.GOUP;

            Rnd();
            LOTCOM[R].LOOT = 12;

            int j = 0;

            for (int i = 0; i < 24; i++)
            {

                    LOTCOM[R].NUMOFBTN[i].BackColor = Color.White;
                    LOTCOM[R].NUMOFBTN[i].COUT = false;
            }


            for (int i = 0; i < 12; i++)
            {
                for (j = j; j < 24; j++)
                {
                    if(rndarray[i]== LOTCOM[R].NUMOFBTN[j].SeleteNum)
                    {

                        LOTCOM[R].NUMOFBTN[j].BackColor = Color.Red;
                        LOTCOM[R].NUMOFBTN[j].COUT = true;
                        break;
                    }
                }
            }

            LOTCOM[R].Vaild = 1;
            ValDEMIN();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(500, 589);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new System.Drawing.Size(0, 0);
        }

        void Rnd()//方法:產生不重複隨機號碼陣列，並存在 陣列:rndarray (已排序)
        {
            Random RndN = new Random();
            rndarray[0] = RndN.Next(24) + 1;  //隨機數存在rndarray[0]
            for (int i = 1; i <= 11; i++) //rndarray[i](i從1開始)
            {
                rndarray[i] = RndN.Next(24) + 1; //rndarray[i]設隨機數
                for (int j = 0; j <= i - 1; j++) //迴圈從0比到i-1
                {
                    if (rndarray[i] == rndarray[j]) //rndarray[i]是否等於rndarray[0~i-1]
                    {
                        i--; //因為迴圈結束i+1，會變成比對下一個數所以先減1
                        break;//因為有重複了所以跳出
                    }
                }
            }
            Array.Sort(rndarray);

        }
        
        void ValDEMIN() //有效數目判定
        {
            int NN=0;
            for(int i = 0; i < LOTCOM.Count; i++)
            {
                NN += LOTCOM[i].Vaild;
            }
            LBLSTATE.Text = "選號組數:" + LOTCOM.Count.ToString()
                + "\n有效組數:" + NN.ToString()
                + "\n無效組數:" + (LOTCOM.Count - NN).ToString();
        }
        
        private void PASS_Click(object sender, EventArgs e)
        {
            
            for(int i=0;i< LOTCOM.Count; i++)
            {
                LOTCOM[i].COMP[11] = 0;
                int k = 0;
                for (int j = 0; j < 12; j++)
                {
                    for (k =k; k <= 23; k++)
                    {

                        if (LOTCOM[i].NUMOFBTN[k].COUT)
                        {
                            LOTCOM[i].COMP[j] = k + 1;
                            k++;
                            break;
                        }
                    }
                }

                if (LOTCOM[i].COMP[11] != 0)
                {
                    LOTCOM[i].LotVail = true;
                    LOTCOM[i].STAT.Text = "選號成功";
                    LOTCOM[i].Vaild = 1;
                }
                else
                {
                    LOTCOM[i].LotVail = false;
                    LOTCOM[i].STAT.Text = "選號尚未完成" ;
                    LOTCOM[i].Vaild = 0;
                }
            }

            ValDEMIN();

        }
        
        private void LOTTRY_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < LOTCOM.Count; i++)
            {
                LOTCOM[i].COMP[11] = 0;
                int k = 0;
                for (int j = 0; j < 12; j++)
                {
                    for (k = k; k <= 23; k++)
                    {

                        if (LOTCOM[i].NUMOFBTN[k].COUT)
                        {
                            LOTCOM[i].COMP[j] = k + 1;
                            k++;
                            break;
                        }
                    }
                }

                if (LOTCOM[i].COMP[11] != 0)
                {
                    LOTCOM[i].LotVail = true;
                    LOTCOM[i].STAT.Text = "選號成功";
                }
                else
                {
                    LOTCOM[i].LotVail = false;
                    LOTCOM[i].STAT.Text = "選號尚未完成";
                }
            }//確認


            Rnd();
            LBLLotNum.Text = "獎號:";
            foreach (int i in rndarray)
            {

                LBLLotNum.Text += i.ToString()+" ";
            }

            TO = 0; RA = 0; SAN = 0; SU = 0; KON = 0;

            ValDEMIN();

            for (int i = 0; i < LOTCOM.Count; i++)
            {
                if (LOTCOM[i].LotVail)
                { 
                    int HIT = 0;
                    for(int j = 0; j< 12; j++)
                    {
                        for(int k = 0; k< 12; k++)
                        {

                            if(rndarray[j]== LOTCOM[i].COMP[k])
                            {
                                HIT++;
                            }
                        }
                    }
                    
                    if (HIT == 0 || HIT == 12)
                    {
                        LOTCOM[i].STAT.Text = "頭獎!!!!";
                        TO++;
                    }
                    else if(HIT == 1 || HIT == 11)
                    {
                        LOTCOM[i].STAT.Text = "貳獎!!!";
                        RA++;
                    }
                    else if (HIT == 2 || HIT == 10)
                    {
                        LOTCOM[i].STAT.Text = "參獎!!";
                        SAN++;
                    }
                    else if (HIT == 3 || HIT == 9)
                    {
                        LOTCOM[i].STAT.Text = "肆獎!";
                        SU++;
                    }
                    else
                    {
                        LOTCOM[i].STAT.Text ="中"+HIT.ToString()+"個號碼\n"+"沒中";
                        KON++;
                    }
                }
            }//兌獎


            if((TO+ RA+ SAN+ SU) != 0)
            {
                LBLRESULT.Text = "您中了\n" + TO.ToString() + "個頭獎\n"
                    + RA.ToString() + "個貳獎\n" +
                    SAN.ToString() + "個參獎\n" +
                    SU.ToString() + "個肆獎\n" + KON.ToString() + "個摃辜"
                    + "\n獎金為:NT$"+(15000000*TO+ 100000*RA+ 500* SAN+100* SU).ToString()
                    +"\n您下了"+(TO + RA + SAN + SU+KON).ToString()+"注"
                    ;
                
            }
            else
            {
                LBLRESULT.Text = "你沒中半個獎QQ";
            }
        }
    }
}
