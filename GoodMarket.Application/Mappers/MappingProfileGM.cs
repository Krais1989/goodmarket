using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Mappers
{
    public class TestMapEntity1
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class TestMapEntity2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class MappingProfileGM : AutoMapper.Profile
    {
        public MappingProfileGM()
        {
            CreateMap<TestMapEntity1, TestMapEntity2>();
        }
    }
}
