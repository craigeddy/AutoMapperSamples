using AutoMapper;
using AutoMapperSamples.Destinations;
using AutoMapperSamples.Sources;
using NUnit.Framework;

namespace AutoMapperSamples
{
    [TestFixture]
    public class Tests
    {
        private Employee _stanley;
        private Employee _manager;
        private Employee _janeTheConsultant;

        [SetUp]
        public void Setup()
        {
            _manager = new Employee
            {
                FirstName = "Boisterous",
                LastName = "Bob"
            };

            _stanley = new Employee
            {
                FirstName = "Flat",
                LastName = "Stanley",
                Manager = _manager,
                Address = new Address
                {
                    Street = "1800 Kent St",
                    City = "Arlington",
                    State = "VA",
                    ZIP = 20222
                }
            };

            _janeTheConsultant = new Employee
            {
                FirstName = "Jane",
                LastName = "Consultant"
            };
        }

        [Test]
        public void Mapped_Stanley_Has_Manager_Name()
        {
            var mapper = new Mapper(Configurators.GetSingletonConfiguration());

            // use AutoMapper to construct Flat Stanley
            var flatStanley = mapper.Map<FlatStanley>(_stanley);

            Assert.That(flatStanley.ManagerFirstName, Is.EqualTo(_manager.FirstName));
            Assert.That(flatStanley.ManagerLastName, Is.EqualTo(_manager.LastName));
        }


        [Test]
        public void Mapped_Stanley_Has_City()
        {
            var mapper = new Mapper(Configurators.AutoMapper());

            // use AutoMapper to construct Flat Stanley
            var flatStanley = mapper.Map<FlatStanley>(_stanley);

            Assert.That(flatStanley.City, Is.EqualTo(_stanley.Address.City));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FactoryMethod_Stanley_Has_Manager_Name(bool forgetful)
        {
            // use the utility method to construct a Flat Stanley
            var flatStanley = Utilities.GetFlatStanley(_stanley, forgetful);

            Assert.That(flatStanley.ManagerFirstName, Is.EqualTo(_manager.FirstName));
            Assert.That(flatStanley.ManagerLastName, Is.EqualTo(_manager.LastName));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FactoryMethod_Stanley_Has_City(bool forgetful)
        {
            // use the utility method to construct a Flat Stanley
            var flatStanley = Utilities.GetFlatStanley(_stanley, forgetful);

            Assert.That(flatStanley.City, Is.EqualTo(_stanley.Address.City));
        }

        [Test]
        public void Mapped_Jane_Has_No_Manager_Name()
        {
            var mapper = new Mapper(Configurators.AutoMapper());

            var flatJane = mapper.Map<FlatStanley>(_janeTheConsultant);

            Assert.That(string.IsNullOrEmpty(flatJane.ManagerFirstName));
            Assert.That(string.IsNullOrEmpty(flatJane.ManagerLastName));
        }

        [Test]
        public void Mapped_Jane_Has_No_City()
        {
            var mapper = new Mapper(Configurators.AutoMapper());

            var flatJane = mapper.Map<FlatStanley>(_janeTheConsultant);

            Assert.That(string.IsNullOrEmpty(flatJane.City));
        }
    }
}