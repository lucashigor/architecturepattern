using Business;
using CrossCulting;
using Domain;
using Repository;
using Moq;
using System;
using Xunit;

namespace UnitTests
{
    public class PersonBursinessTests
    {
        Mock<IExamplePersonRepository> _personRepository;
        ExamplesMessages _examplesMessages;

        public PersonBursinessTests()
        {
            _examplesMessages = new ExamplesMessages();
        }

        [Fact]
        public void ValidateMaxAge_ParticipanteForaDaIdade_test()
        {
            //Setup
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages);

            var person = new ExamplePerson()
            {
                Name = "Usuario 1",
                BirthDate = DateTime.Today.AddYears(-(ExamplesConstants.MAX_AGE + 1))
            };

            //Fact
            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            //Assert
            Assert.Equal(_examplesMessages.GetIdadeNaoPermitida(), ex.Message);
        }

        [Fact]
        public void ValidateAvancedAge_ParticipanteDentroDaIdadeWarningDate_test()
        {
            //Setup
            _personRepository = new Mock<IExamplePersonRepository>();

            var app = new ExamplePersonBusiness(_personRepository.Object, _examplesMessages);

            var person = new ExamplePerson()
            {
                Id = 1,
                Name = "Usuario 1",
                BirthDate = DateTime.Today.AddYears(-(ExamplesConstants.WARNING_MAX_AGE + 1))
            };

            _personRepository.Setup(x => x.Create(It.IsAny<ExamplePerson>())).Returns(person);

            //Fact
            BusinessException ex = Assert.Throws<BusinessException>(() => app.SavePerson(person));

            //Assert
            Assert.Equal(_examplesMessages.GetIdadeAvancada(), ex.Message);
        }
        
    }
}
