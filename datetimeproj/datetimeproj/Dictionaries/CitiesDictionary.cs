using System;
namespace datetimeproj
{
    public class CitiesDictionary
    {
        private readonly Dictionary<string, int> _cityUTC = new Dictionary<string, int>
        {
            { "London", 0 },
            { "Moscow", 3 },
            { "New York", -5 },
            { "Alma-Aty", 6 },
            { "Beijing", 8 },
            { "Inskoy", 7 }
        };

        public Dictionary<string, int> CityUTC => _cityUTC;
    }
};
