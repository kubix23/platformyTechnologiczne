using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyTechnologiczne
{
    class CarBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;
        public CarBindingList(IList<T> list) : base(list)
        { AllowNew = true;}
        override protected bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override bool IsSortedCore
        {
            get { return _isSorted; }
        }
        protected override ListSortDirection SortDirectionCore {
            get { return _sortDirection; }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;
            if (_isSorted && _sortProperty == prop)
            {
                items.Reverse();
            }
            else if (items != null && prop.PropertyType.GetInterface("IComparable") != null)
            {
                items.Sort((emp1, emp2) => (((IComparable)prop.GetValue(emp2)).CompareTo(prop.GetValue(emp1))));
                _isSorted = true;
            }
            else
            {
                _isSorted = false;
            }
            _sortProperty = prop;
            _sortDirection = direction;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortProperty = null;
        }
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            if (prop == null) return -1;
            int rr = -1;
            List<T> items = this.Items as List<T>;                   
                                                                     
            foreach(T item in items)                                 
            {                                                        
                var value = prop.GetValue(item).ToString();          
                if (key.Equals(value))                               
                {                                                    
                    rr = IndexOf(item);                              
                    break;
                }
            }
            return rr;
        }
    }
}
