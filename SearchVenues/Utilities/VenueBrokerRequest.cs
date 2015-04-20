using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchVenues.Utilities
{
    public class VenueBrokerRequest
    {
        public VenueBrokerRequest()
        {
            CurrentPage = 1;
            PageSize = 10;
            TotalItems = 0;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int StartIndex { get { return (CurrentPage > 0 ? CurrentPage - 1 : 0) * PageSize; } }
        public string SortDirection { get; set; }
        public string SortField { get; set; }
        public string GroupBy { get; set; }
        public string Criteria {
            get
            {
                return JsonConvert.SerializeObject(SearchCriteria);
            }
            set
            {
                DictionaryEntry[] entries = JsonConvert.DeserializeObject<DictionaryEntry[]>(value);
                SearchCriteria = new Dictionary<string, string>();
                foreach (DictionaryEntry entry in entries)
                {
                    SearchCriteria.Add(entry.Key, entry.Value);
                }
            }
        }
        public Dictionary<string,string> SearchCriteria { get; set; }
        class DictionaryEntry
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}