using System;

namespace MovieDbInf.Application.Model
{
    public class MovieParameters : QuerystringParameters
    {
        public string Title { get; set; }

        public int _maxPublishYear = DateTime.Now.Year;

        public int MinPublisYear { get; set; }

        public int MaxPublishYear
        {
            get
            {
                return _maxPublishYear;
            }
            set
            {
                _maxPublishYear = value > _maxPublishYear ? _maxPublishYear : value;
            }
        }
    }
}