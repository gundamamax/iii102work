using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOTTE
{
    class LOTCOMPOSE
    {
        public List<LOTBTN> NUMOFBTN = new List<LOTBTN>();
        public int[] COMP = new int[12] ;
        public GROUPBTN RAND = new GROUPBTN();
        public GROUPBTN DELBTN = new GROUPBTN();
        public Label STAT = new Label();
        public int LOOT = 0;
        public int Vaild=0;
        public bool LotVail;
        
    }
}
