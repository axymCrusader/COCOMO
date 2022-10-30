using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace COCOMO
{
    public partial class Form1 : Form
    {
        double[] a = new double[] { 2.4, 3.0, 3.6 };
        double[] b = new double[] { 1.05, 1.12, 1.20 };
        double c = 2.5;
        double[] d = new double[] { 0.38, 0.35, 0.32 };
        double SIZE = 0.0;
      
        public Form1()
        {
            InitializeComponent();
        }
        private double CalcEAF(int i)
        {
            double EAF = 1;
            int [] IndexBOX = new int[] {CB1_1.SelectedIndex,CB1_2.SelectedIndex
            ,CB1_3.SelectedIndex,CB2_1.SelectedIndex,CB2_2.SelectedIndex
            ,CB2_3.SelectedIndex,CB2_4.SelectedIndex,CB3_1.SelectedIndex
            ,CB3_2.SelectedIndex,CB3_3.SelectedIndex,CB3_4.SelectedIndex
            ,CB3_5.SelectedIndex,CB4_1.SelectedIndex,CB4_2.SelectedIndex
            ,CB4_3.SelectedIndex
            };
                switch (i)
                {
                    case 0:
                        switch (IndexBOX[0]) // Требуемая надежность ПО 
                        {
                            case 0: EAF = 0.75; break;
                            case 1: EAF = 0.88; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 1.15; break;
                            case 4: EAF = 1.4; break;
                        }
                        break;

                    case 1:
                        switch (IndexBOX[1]) // Размер БД приложения
                        {
                            case 0: EAF = 0.94; break;
                            case 1: EAF = 1; break;
                            case 2: EAF = 1.08; break;
                            case 3: EAF = 1.16; break;
                        }
                        break;
                    case 2:
                        switch (IndexBOX[2]) // Сложность продукта
                        {
                            case 0: EAF = 0.70; break;
                            case 1: EAF = 0.85; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 1.15; break;
                            case 4: EAF = 1.3; break;
                            case 5: EAF = 1.65; break;
                        }
                        break;
                    case 3:
                        switch (IndexBOX[3]) // Ограничения быстродействия при выполнении программы
                        {
                            case 0: EAF = 1; break;
                            case 1: EAF = 1.11; break;
                            case 2: EAF = 1.3; break;
                            case 3: EAF = 1.66; break;
                        }
                        break;
                    case 4:
                        switch (IndexBOX[4]) // Ограничения памяти 
                        {
                            case 0: EAF = 1; break;
                            case 1: EAF = 1.06; break;
                            case 2: EAF = 1.21; break;
                            case 3: EAF = 1.56; break;
                        }
                        break;
                    case 5:
                        switch (IndexBOX[5]) // Неустойчивость окружения виртуальноймашины
                        {
                            case 0: EAF = 0.87; break;
                            case 1: EAF = 1; break;
                            case 2: EAF = 1.15; break;
                            case 3: EAF = 1.3; break;
                        }
                        break;
                    case 6:
                        switch (IndexBOX[6]) // Требуемое время восстановления
                        {
                            case 0: EAF = 0.87; break;
                            case 1: EAF = 1; break;
                            case 2: EAF = 1.07; break;
                            case 3: EAF = 1.15; break;
                        }
                        break;
                    case 7:
                        switch (IndexBOX[7]) // Аналитические способности
                        {
                            case 0: EAF = 1.46; break;
                            case 1: EAF = 1.19; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.86; break;
                            case 4: EAF = 0.71; break;
                        }
                        break;
                    case 8:
                        switch (IndexBOX[8]) // Опыт разработки
                        {
                            case 0: EAF = 1.29; break;
                            case 1: EAF = 1.13; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.91; break;
                            case 4: EAF = 0.82; break;
                        }
                        break;
                    case 9:
                        switch (IndexBOX[9]) // Способности к разработке ПО
                        {
                            case 0: EAF = 1.42; break;
                            case 1: EAF = 1.17; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.86; break;
                            case 4: EAF = 0.70; break;
                        }
                        break;
                    case 10:
                        switch (IndexBOX[10]) // Опыт использования виртуальных машин 
                        {
                            case 0: EAF = 1.21; break;
                            case 1: EAF = 1.10; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.90; break;
                        }
                        break;
                    case 11:
                        switch (IndexBOX[11]) // Опыт разработки на языках программирования
                        {
                            case 0: EAF = 1.14; break;
                            case 1: EAF = 1.07; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.95; break;
                        }
                        break;
                    case 12:
                        switch (IndexBOX[12]) //  Применение методов разработки ПО
                        {
                            case 0: EAF = 1.24; break;
                            case 1: EAF = 1.10; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.91; break;
                            case 4: EAF = 0.82; break;
                        }
                        break;
                    case 13:
                        switch (IndexBOX[13]) // Использование инструментария разработки ПО
                        {
                            case 0: EAF = 1.24; break;
                            case 1: EAF = 1.10; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 0.91; break;
                            case 4: EAF = 0.83; break;
                        }
                        break;
                    case 14:
                        switch (IndexBOX[14]) // Требования соблюдения графика разработки
                        {
                            case 0: EAF = 1.23; break;
                            case 1: EAF = 1.08; break;
                            case 2: EAF = 1; break;
                            case 3: EAF = 1.04; break;
                            case 4: EAF = 1.10; break;
                        }
                        break;
                }
            return EAF;
        }
        private double CalcSF1(int i)
        {
            double sf = 0;
            int[] IndexBOX = new int[] {CBPD2_1.SelectedIndex, CBDF2_1.SelectedIndex, CBARR2_1.SelectedIndex, CBTC2_1.SelectedIndex, CBPM2_1.SelectedIndex};
                switch (i)
                {
                    case 0:
                        switch (IndexBOX[0])
                        {
                            case 0: sf = 6.2; break;
                            case 1: sf = 4.96; break;
                            case 2: sf = 3.72; break;
                            case 3: sf = 2.48; break;
                            case 4: sf = 1.24; break;
                            case 5: sf = 0; break;
                        }
                        break;
                    case 1:
                        switch (IndexBOX[1])
                        {
                            case 0: sf = 5.07; break;
                            case 1: sf = 4.05; break;
                            case 2: sf = 3.04; break;
                            case 3: sf = 2.03; break;
                            case 4: sf = 1.01; break;
                            case 5: sf = 0; break;
                        }
                        break;
                    case 2:
                        switch (IndexBOX[2])
                        {
                            case 0: sf = 7.07; break;
                            case 1: sf = 5.65; break;
                            case 2: sf = 4.24; break;
                            case 3: sf = 2.83; break;
                            case 4: sf = 1.41; break;
                            case 5: sf = 0; break;
                        }
                        break;
                    case 3:
                        switch (IndexBOX[3])
                        {
                            case 0: sf = 5.48; break;
                            case 1: sf = 4.38; break;
                            case 2: sf = 3.29; break;
                            case 3: sf = 2.19; break;
                            case 4: sf = 1.1; break;
                            case 5: sf = 0; break;
                        }
                        break;
                    case 4:
                        switch (IndexBOX[4])
                        {
                            case 0: sf = 7.8; break;
                            case 1: sf = 6.24; break;
                            case 2: sf = 4.68; break;
                            case 3: sf = 3.12; break;
                            case 4: sf = 1.56; break;
                            case 5: sf = 0; break;
                        }
                        break;
                }
            return sf;
        }
        private double CalcSF2(int i)
        {
            double sf = 0;
            int[] IndexBOX = new int[] { CBPD2_2.SelectedIndex, CBDF2_2.SelectedIndex, CBARR2_2.SelectedIndex, CBTC2_2.SelectedIndex, CBPM2_2.SelectedIndex };
            switch (i)
            {
                case 0:
                    switch (IndexBOX[0])
                    {
                        case 0: sf = 6.2; break;
                        case 1: sf = 4.96; break;
                        case 2: sf = 3.72; break;
                        case 3: sf = 2.48; break;
                        case 4: sf = 1.24; break;
                        case 5: sf = 0; break;
                    }
                    break;
                case 1:
                    switch (IndexBOX[1])
                    {
                        case 0: sf = 5.07; break;
                        case 1: sf = 4.05; break;
                        case 2: sf = 3.04; break;
                        case 3: sf = 2.03; break;
                        case 4: sf = 1.01; break;
                        case 5: sf = 0; break;
                    }
                    break;
                case 2:
                    switch (IndexBOX[2])
                    {
                        case 0: sf = 7.07; break;
                        case 1: sf = 5.65; break;
                        case 2: sf = 4.24; break;
                        case 3: sf = 2.83; break;
                        case 4: sf = 1.41; break;
                        case 5: sf = 0; break;
                    }
                    break;
                case 3:
                    switch (IndexBOX[3])
                    {
                        case 0: sf = 5.48; break;
                        case 1: sf = 4.38; break;
                        case 2: sf = 3.29; break;
                        case 3: sf = 2.19; break;
                        case 4: sf = 1.1; break;
                        case 5: sf = 0; break;
                    }
                    break;
                case 4:
                    switch (IndexBOX[4])
                    {
                        case 0: sf = 7.8; break;
                        case 1: sf = 6.24; break;
                        case 2: sf = 4.68; break;
                        case 3: sf = 3.12; break;
                        case 4: sf = 1.56; break;
                        case 5: sf = 0; break;
                    }
                    break;
            }
            return sf;
        }
        private double CalcEFA(int i)
        {
            double EFA = 0;
            int [] IndexBOX = new int [] {CBPERS.SelectedIndex,CBPREX.SelectedIndex,CBRCPX.SelectedIndex,CBRUSE.SelectedIndex,CBPDIF.SelectedIndex,CBFCIL.SelectedIndex,CBSCED.SelectedIndex};
            switch (i)
            {
                case 0:
                    switch (IndexBOX[0]) // PERS
                    {
                        case 0: EFA = 2.12; break;
                        case 1: EFA = 1.62; break;
                        case 2: EFA = 1.26; break;
                        case 3: EFA = 1; break;
                        case 4: EFA = 0.83; break;
                        case 5: EFA = 0.63; break;
                        case 6: EFA = 0.5; break;
                    }
                    break;
                case 1:
                    switch (IndexBOX[1]) // PREX
                    {
                        case 0: EFA = 1.59; break;
                        case 1: EFA = 1.33; break;
                        case 2: EFA = 1.22; break;
                        case 3: EFA = 1; break;
                        case 4: EFA = 0.87; break;
                        case 5: EFA = 0.74; break;
                        case 6: EFA = 0.62; break;
                    }
                    break;
                case 2:
                    switch (IndexBOX[2]) // PCPX
                    {
                        case 0: EFA = 0.49; break;
                        case 1: EFA = 0.6; break;
                        case 2: EFA = 0.83; break;
                        case 3: EFA = 1; break;
                        case 4: EFA = 1.33; break;
                        case 5: EFA = 1.91; break;
                        case 6: EFA = 2.72; break;
                    }
                    break;
                case 3:
                    switch (IndexBOX[3]) // RUSE
                    {
                        case 0: EFA = 0.95; break;
                        case 1: EFA = 1; break;
                        case 2: EFA = 1.07; break;
                        case 3: EFA = 1.15; break;
                        case 4: EFA = 1.24; break;
                    }
                    break;
                case 4:
                    switch (IndexBOX[4]) // PDIF
                    {
                        case 0: EFA = 0.87; break;
                        case 1: EFA = 1; break;
                        case 2: EFA = 1.29; break;
                        case 3: EFA = 1.81; break;
                        case 4: EFA = 2.61; break;
                    }
                    break;
                case 5:
                    switch (IndexBOX[5]) // FCIL
                    {
                        case 0: EFA = 1.43; break;
                        case 1: EFA = 1.3; break;
                        case 2: EFA = 1.1; break;
                        case 3: EFA = 1; break;
                        case 4: EFA = 0.87; break;
                        case 5: EFA = 0.73; break;
                        case 6: EFA = 0.62; break;
                    }
                    break;
            }
            return EFA;
        }
        private double CalcEM(int i)
        {
            double EM = 0;
            int[] IndexBOX = new int[] {CBACAP.SelectedIndex, CBAEXP.SelectedIndex,
            CBPCAP.SelectedIndex,CBPCON.SelectedIndex,CBPEXP.SelectedIndex,CBLTEX.SelectedIndex,
            CBRELY.SelectedIndex,CBDATA.SelectedIndex,CBCPLX.SelectedIndex,CBRUS.SelectedIndex,
            CBDOCU.SelectedIndex, CBTIME.SelectedIndex, CBSTOR.SelectedIndex,CBPVOL.SelectedIndex,
            CBTOOL.SelectedIndex,CBSITE.SelectedIndex,CBSCE.SelectedIndex};
            switch (i)
            {
                case 0:
                    switch (IndexBOX[0]) // ACAP
                    {
                        case 0: EM = 1.42; break;
                        case 1: EM = 1.29; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.85; break;
                        case 4: EM = 0.71; break;
                    }
                    break;
                case 1:
                    switch (IndexBOX[1]) // AEXP
                    {
                        case 0: EM = 1.22; break;
                        case 1: EM = 1.10; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.88; break;
                        case 4: EM = 0.81; break;
                    }
                    break;
                case 2:
                    switch (IndexBOX[2]) // PCAP
                    {
                        case 0: EM = 1.34; break;
                        case 1: EM = 1.15; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.88; break;
                        case 4: EM = 0.76; break;
                    }
                    break;
                case 3:
                    switch (IndexBOX[3]) // PCON
                    {
                        case 0: EM = 1.29; break;
                        case 1: EM = 1.12; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.90; break;
                        case 4: EM = 0.81; break;
                    }
                    break;
                case 4:
                    switch (IndexBOX[4]) // PEXP
                    {
                        case 0: EM = 1.19; break;
                        case 1: EM = 1.09; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.91; break;
                        case 4: EM = 0.85; break;
                    }
                    break;
                case 5:
                    switch (IndexBOX[5]) // LTEX
                    {
                        case 0: EM = 1.20; break;
                        case 1: EM = 1.09; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.91; break;
                        case 4: EM = 0.84; break;
                    }
                    break;
                case 6:
                    switch (IndexBOX[6]) // RELY
                    {
                        case 0: EM = 0.84; break;
                        case 1: EM = 0.92; break;
                        case 2: EM = 1; break;
                        case 3: EM = 1.10; break;
                        case 4: EM = 1.26; break;
                    }
                    break;
                case 7:
                    switch (IndexBOX[7]) // DATA
                    {
                        case 0: EM = 0.23; break;
                        case 1: EM = 1; break;
                        case 2: EM = 1.14; break;
                        case 3: EM = 1.28; break;  
                    }
                    break;
                case 8:
                    switch (IndexBOX[8]) // CPLX
                    {
                        case 0: EM = 0.73; break;
                        case 1: EM = 0.87; break;
                        case 2: EM = 1; break;
                        case 3: EM = 1.17; break;
                        case 4: EM = 1.34; break;
                        case 5: EM = 1.74; break;
                    }
                    break;
                case 9:
                    switch (IndexBOX[9]) // RUSE
                    {
                        case 0: EM = 0.95; break;
                        case 1: EM = 1; break;
                        case 2: EM = 1.07; break;
                        case 3: EM = 1.15; break;
                        case 4: EM = 1.24; break;
                    }
                    break;
                case 10:
                    switch (IndexBOX[10]) // DOCU
                    {
                        case 0: EM = 0.81; break;
                        case 1: EM = 0.91; break;
                        case 2: EM = 1; break;
                        case 3: EM = 1.11; break;
                        case 4: EM = 1.23; break;               
                    }
                    break;
                case 11:
                    switch (IndexBOX[11]) // TIME
                    {
                        case 0: EM = 1; break;
                        case 1: EM = 1.11; break;
                        case 2: EM = 1.29; break;
                        case 3: EM = 1.63; break;
                    }
                    break;
                case 12:
                    switch (IndexBOX[12]) //  STOR
                    {
                        case 0: EM = 1; break;
                        case 1: EM = 1.05; break;
                        case 2: EM = 1.17; break;
                        case 3: EM = 1.46; break;
                    }
                    break;
                case 13:
                    switch (IndexBOX[13]) // PVOL
                    {
                        case 0: EM = 0.87; break;
                        case 1: EM = 1; break;
                        case 2: EM = 1.15; break;
                        case 3: EM = 1.30; break;
                    }
                    break;
                case 14:
                    switch (IndexBOX[14]) // TOOL
                    {
                        case 0: EM = 1.17; break;
                        case 1: EM = 1.09; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.90; break;
                        case 4: EM = 0.78; break;
                    }
                    break;
                case 15:
                    switch (IndexBOX[14]) // SITE
                    {
                        case 0: EM = 1.22; break;
                        case 1: EM = 1.09; break;
                        case 2: EM = 1; break;
                        case 3: EM = 0.93; break;
                        case 4: EM = 0.86; break;
                        case 5: EM = 0.80; break;

                    }
                    break;
                case 16:
                    switch (IndexBOX[14]) // SCED
                    {
                        case 0: EM = 1.43; break;
                        case 1: EM = 1.14; break;
                        case 2: EM = 1; break;
                        case 3: EM = 1; break;
                        case 4: EM = 1; break;
                    }
                    break;
            }
            return EM;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            OPENPDF.Visible = false;
            label69.Visible = false;
            TXTCOPRIGHT.Visible = false;
            TXTNAME.Visible = false;
            tabControl1.Visible = true;
            
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            CBTEAM1_1.SelectedIndex = 0;
            CBTEAM1_2.SelectedIndex = 0;

            CB1_1.SelectedIndex = 2;
            CB1_2.SelectedIndex = 1;
            CB1_3.SelectedIndex = 2;
            CB2_1.SelectedIndex = 0;
            CB2_2.SelectedIndex = 0;
            CB2_3.SelectedIndex = 1;
            CB2_4.SelectedIndex = 1;
            CB3_1.SelectedIndex = 2;
            CB3_2.SelectedIndex = 2;
            CB3_3.SelectedIndex = 2;
            CB3_4.SelectedIndex = 2;
            CB3_5.SelectedIndex = 2;
            CB4_1.SelectedIndex = 2;
            CB4_2.SelectedIndex = 2;
            CB4_3.SelectedIndex = 2;
            
            CBARR2_1.SelectedIndex = 2;
            CBDF2_1.SelectedIndex = 2;
            CBPD2_1.SelectedIndex = 2;
            CBPM2_1.SelectedIndex = 2;
            CBTC2_1.SelectedIndex = 2;

            CBARR2_2.SelectedIndex = 2;
            CBDF2_2.SelectedIndex = 2;
            CBPD2_2.SelectedIndex = 2;
            CBPM2_2.SelectedIndex = 2;
            CBTC2_2.SelectedIndex = 2;


            CBPERS.SelectedIndex = 2;
            CBPREX.SelectedIndex = 2;
            CBRCPX.SelectedIndex = 2;
            CBRUSE.SelectedIndex = 0;
            CBPDIF.SelectedIndex = 0;
            CBFCIL.SelectedIndex = 2;
            CBSCED.SelectedIndex = 1;

            CBACAP.SelectedIndex = 2;
            CBAEXP.SelectedIndex = 2;
            CBPCAP.SelectedIndex = 2;
            CBPCON.SelectedIndex = 2;
            CBPEXP.SelectedIndex = 2;
            CBLTEX.SelectedIndex = 2;

            CBRELY.SelectedIndex = 2;
            CBDATA.SelectedIndex = 1;
            CBCPLX.SelectedIndex = 2;
            CBRUS.SelectedIndex = 1;
            CBDOCU.SelectedIndex = 2;

            CBTIME.SelectedIndex = 0;
            CBSTOR.SelectedIndex = 0;
            CBPVOL.SelectedIndex = 1;

            CBTOOL.SelectedIndex = 2;
            CBSITE.SelectedIndex = 2;
            CBSCE.SelectedIndex = 2;


            toolTip1.SetToolTip(label9, "Гибкость процесса разработки");
            toolTip1.SetToolTip(label5, "Прецедентность, наличие опыта аналогичных разработок");
            toolTip1.SetToolTip(label10, "Архитектура и разрешение рисков");
            toolTip1.SetToolTip(label11, "Сработанность команды");
            toolTip1.SetToolTip(label12, "Зрелость процессов");
            
            toolTip1.SetToolTip(TXTPERS, "Квалификация персонала");
            toolTip1.SetToolTip(TXTPREX, "Опыт персонала");
            toolTip1.SetToolTip(TXTRCPX, "Сложность и надежность продукта");
            toolTip1.SetToolTip(TXTRUSE, "Разработка для повторного использования");
            toolTip1.SetToolTip(TXTPDIF, "Сложность платформы разработки");
            toolTip1.SetToolTip(TXTFCIL, "Оборудование");
            toolTip1.SetToolTip(TXTSCED, "Требуемое выполнение графика работа");

            toolTip1.SetToolTip(label66, "Гибкость процесса разработки");
            toolTip1.SetToolTip(label67, "Прецедентность, наличие опыта аналогичных разработок");
            toolTip1.SetToolTip(label65, "Архитектура и разрешение рисков");
            toolTip1.SetToolTip(label64, "Сработанность команды");
            toolTip1.SetToolTip(label63, "Зрелость процессов");

            toolTip1.SetToolTip(TXTACAP, "Возможности аналитика");
            toolTip1.SetToolTip(TXTAEXP, "Опыт разработки приложений");
            toolTip1.SetToolTip(TXTPCAP, "Возможности программиста");
            toolTip1.SetToolTip(TXTPCON, "Продолжительность работы персонала");
            toolTip1.SetToolTip(TXTPEXP, "Опыт работы с платформой");
            toolTip1.SetToolTip(TXTLTEX, "Опыт использования языка программирования и инструментальных средств");
            toolTip1.SetToolTip(TXTRELY, "Требуемая надежность программы");
            toolTip1.SetToolTip(TXTDATA, "Размер базы данных");
            toolTip1.SetToolTip(TXTCPLX, "Сложность программы");
            toolTip1.SetToolTip(TXTRUS,  "Требуемая возможность многократного использования");
            toolTip1.SetToolTip(TXTDOCU, "Соответствие документации потребностям жизненного цикла");
            toolTip1.SetToolTip(TXTTIME, "Ограничения времени выполнения");
            toolTip1.SetToolTip(TXTSTOR, "Ограничения памяти");
            toolTip1.SetToolTip(TXTPVOL, "Изменяемость платформы");
            toolTip1.SetToolTip(TXTTOOL, "Использование инструментальных программных средств");
            toolTip1.SetToolTip(TXTSITE, "многоабонентская (удаленная) разработка");
            toolTip1.SetToolTip(TXTSCE,  "Требуемое выполнение графика работ");
            pictureBox1.Image = Image.FromFile("graph.jpg");
        }
        private void CALC1_1_Click(object sender, EventArgs e)
        {
            SIZE = 0.0;
            double.TryParse(TXTSIZE1_1.Text, out SIZE);

            if (String.IsNullOrEmpty(TXTSIZE1_1.Text) || SIZE == 0)
            {
                MessageBox.Show("Введены некорректные данные");
            }
            int index = CBTEAM1_1.SelectedIndex;
            double PM = 0.0, TM = 0.0;
            switch (index)
            {
                case 0:
                    PM = a[0] * Math.Pow(SIZE, b[0]);
                    TM = c * Math.Pow(PM, d[0]);
                    break;
                case 1:
                    PM = a[1] * Math.Pow(SIZE, b[1]);
                    TM = c * Math.Pow(PM, d[1]);
                    break;
                case 2:
                    PM = a[2] * Math.Pow(SIZE, b[2]);
                    TM = c * Math.Pow(PM, d[2]);
                    break;
            }
            PMoutput1_1.Text = Convert.ToString(Math.Round(PM, 2));
            TMoutput1_1.Text = Convert.ToString(Math.Round(TM, 2));

        }

        private void CALC1_2_Click(object sender, EventArgs e)
        {
            SIZE = 0.0;
            double.TryParse(TXTSIZE1_2.Text, out SIZE);

            if (String.IsNullOrEmpty(TXTSIZE1_2.Text) || SIZE == 0)
            {
                MessageBox.Show("Введены некорректные данные");
            }
            int index = CBTEAM1_2.SelectedIndex;
            double PM = 0.0, TM = 0.0, EAF = 1;
            for (int i = 0; i < 15; i++)
            {
                EAF *= CalcEAF(i);
            }
            switch (index)
            {
                case 0:
                    PM = EAF * a[0] * Math.Pow(SIZE, b[0]);
                    TM = c * Math.Pow(PM, d[0]);
                    break;
                case 1:
                    PM = EAF * a[1] * Math.Pow(SIZE, b[1]);
                    TM = c * Math.Pow(PM, d[1]);
                    break;
                case 2:
                    PM = EAF * a[2] * Math.Pow(SIZE, b[2]);
                    TM = c * Math.Pow(PM, d[2]);
                    break;
            }
            PMoutput1_2.Text = Convert.ToString(Math.Round(PM, 2));
            TMoutput1_2.Text = Convert.ToString(Math.Round(TM, 2));
        }

        private void CALC2_1_Click(object sender, EventArgs e)
        {
            double A = 2.94, B = 0.91, C = 3.67, D = 0.28, SF = 0, EAF = 1, SCED = 1, PM = 0, TM = 0, PMNS = 0;
            SIZE = 0.0;

            double.TryParse(TXTSIZE2_1.Text, out SIZE);

            if (String.IsNullOrEmpty(TXTSIZE2_1.Text) || SIZE == 0)
            {
                MessageBox.Show("Введены некорректные данные");
            }
            for (int i = 0; i < 5; i++)
            {
                SF += CalcSF1(i);
            }
            double E = B + (0.01 * SF);

            for (int j = 0; j < 5; j++)
            {
                EAF *= CalcEFA(j);
            }
            switch (CBSCED.SelectedIndex)
            {
                case 0: SCED = 1.43; break;
                case 1: SCED = 1.14; break;
                case 2: SCED = 1; break;
                case 3: SCED = 1; break;
            }
            PMNS = EAF * A * Math.Pow(SIZE, E);
            PM = Math.Round(EAF * SCED) * A * Math.Pow(SIZE, E);
            TM = SCED * C * Math.Pow(PMNS, (D + 0.2 * (E - B)));
            PMoutput2_1.Text = Convert.ToString(Math.Round(PM, 2));
            TMoutput2_1.Text = Convert.ToString(Math.Round(TM, 2));
        }

        private void CALC2_2_Click(object sender, EventArgs e)
        {
            double A = 2.45, B = 0.91, C = 3.67, D = 0.28, SF = 0, EAF = 1, SCED = 1, PM = 0, TM = 0, PMNS = 0;
            SIZE = 0.0;

            double.TryParse(TXTSIZE2_2.Text, out SIZE);
            if (String.IsNullOrEmpty(TXTSIZE2_2.Text) || SIZE == 0)
            {
                MessageBox.Show("Введены некорректные данные");
            }

            for (int i = 0; i < 5; i++)
            {
                SF += CalcSF2(i);
            }

            double E = B + 0.01 * SF;

            for (int j = 0; j < 6; j++)
            {
                EAF *= CalcEM(j);
            }
            switch (CBSCE.SelectedIndex)
            {
                case 0: SCED = 1.43; break;
                case 1: SCED = 1.14; break;
                case 2: SCED = 1; break;
                case 3: SCED = 1; break;
            }
            PMNS = EAF * A * Math.Pow(SIZE, E);
            PM = Math.Round(EAF * SCED) * A * Math.Pow(SIZE, E);
            TM = SCED * C * Math.Pow(PMNS, (D + 0.2 * (E - B)));
            PMoutput2_2.Text = Convert.ToString(Math.Round(PM, 2));
            TMoutput2_2.Text = Convert.ToString(Math.Round(TM, 2));
        }
        private void OPENPDF_Click(object sender, EventArgs e)
        {
            PDF pdf = new PDF();
            pdf.Show();
        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            button1.Visible = true;
            OPENPDF.Visible = true;
            label69.Visible = true;
        }
    }
}
