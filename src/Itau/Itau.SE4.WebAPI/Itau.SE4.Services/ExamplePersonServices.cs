﻿using System.Collections.Generic;
using Itau.SE4.Business;
using Itau.SE4.Entities;

namespace Itau.SE4.Services
{
    public class ExamplePersonServices : IExamplePersonServices
    {
        IExamplePersonBusiness _examplePersonBusiness;

        public ExamplePersonServices(IExamplePersonBusiness examplePersonBusiness)
        {
            _examplePersonBusiness = examplePersonBusiness;
        }

        public void Delete(ExamplePerson person)
        {
            _examplePersonBusiness.Delete(person);
        }

        public void Delete(int id)
        {
            _examplePersonBusiness.Delete(id);
        }

        public ExamplePerson Get(int Id)
        {
            return _examplePersonBusiness.Get(Id);
        }

        public ICollection<ExamplePerson> GetCollection()
        {
            return _examplePersonBusiness.GetCollection();
        }

        public ExamplePerson SavePerson(ExamplePerson person)
        {
            return _examplePersonBusiness.SavePerson(person);
        }
    }
}
