using System.Collections;

namespace plumsailbackend.Models
{
    public class Form
    {
        public Form(string firstName, string lastName, string carModel, string engineType, int checkedOptionsCount,
            ArrayList checkedOptions)
        {
            FirstName = firstName;
            LastName = lastName;
            CarModel = carModel;
            EngineType = engineType;
            CheckedOptionsCount = checkedOptionsCount;
            CheckedOptions = checkedOptions;
        }

        public Form(long id, string firstName, string lastName, string carModel, string engineType, string? checkedOptions)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CarModel = carModel;
            EngineType = engineType;
            CheckedOptionsString = checkedOptions;
        }

        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CarModel { get; set; }
        public string EngineType { get; set; }

        public int CheckedOptionsCount { get; set; }
        public ArrayList CheckedOptions { get; set; }
        public string? CheckedOptionsString { get; set; }
    }
}