using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceSamples.WebCore
{
    public class MapperProvider
    {
        private readonly IEnumerable<Profile> _profiles;


        public MapperProvider(IEnumerable<AutoMapper.Profile> profiles)
        {
            _profiles = profiles;
        }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

                foreach (var profile in _profiles)
                {
                    cfg.AddProfile(profile);
                }

            });

            config.AssertConfigurationIsValid();

            return new Mapper(config);

        }
    }
}
