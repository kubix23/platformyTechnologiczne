using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformyTechnologiczne
{
    public partial class findBar : UserControl
    {
        public event ItemFoundEventHandler ItemFound;
        protected virtual void OnItemFound(ItemFoundEventArgs e)
        {
            if (ItemFound != null) ItemFound(this, e);
        }

        private BindingSource _data;
        public BindingSource Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public findBar()
        {
            InitializeComponent();
        }

        private void findBar_Load(object sender, EventArgs e)
        {
            if (_data == null) return;
            this.Type.Items.Clear();
            PropertyDescriptorCollection props = ((ITypedList)_data).GetItemProperties(null);
            foreach (PropertyDescriptor i in props)
            {
                this.Type.Items.Add(i.Name);
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            this.Find();
        }
        private void Find()
        {
            if (!((IBindingList)Data).SupportsSorting) return;
            string find = this.search.Text;
            if (string.IsNullOrEmpty(find)) return;
            string findIn = this.Type.Text;
            if (string.IsNullOrEmpty(findIn)) return;
            int index = _data.Find(findIn, find);
            this.OnItemFound(new ItemFoundEventArgs(index));
        }
    }
    public class ItemFoundEventArgs : EventArgs
    {
        private int _index;
        public ItemFoundEventArgs(int index) { _index = index; }
        public int Index { get { return _index; } }
    }
    public delegate void ItemFoundEventHandler(
     object sender, ItemFoundEventArgs e);
}
