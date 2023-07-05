namespace Ex05.UI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;

    public class Square : Button
    {
        private int m_Col;
        private int m_Row;

        public int Col
        { 
          get { return m_Col; } 
          set { m_Col = value; }
        }

        public int Row
        { 
            get { return m_Row; }
            set { m_Row = value; }
        }
    }
}