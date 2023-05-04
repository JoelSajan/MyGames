using System;
using System.Collections.Generic;

namespace WowSudoko.ViewModels
{
    public class IndexterClass
    {

        public Dictionary<string,string> _myDictionary { get; set; }
        public IndexterClass()
        {
            _myDictionary = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get { return _myDictionary[key]; }
            set { _myDictionary[key] = value; }
        }
    }
}
