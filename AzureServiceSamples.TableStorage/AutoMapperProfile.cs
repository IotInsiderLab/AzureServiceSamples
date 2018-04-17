using AzureServiceSamples.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AzureServiceSamples.TableStorage
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SampleObject, SampleObjectEntity>()
                .ForMember(dest => dest.PartitionKey, config => config.MapFrom(src => src.DeviceId))
                .ForMember(dest => dest.RowKey, config => config.MapFrom(src => (long.MaxValue - src.Ticks).ToString(CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.MessageType, config => config.MapFrom(src => src.MessageType))
                .ForMember(dest => dest.Temperature, config => config.MapFrom(src => src.Temperature))
                .ForMember(dest => dest.ETag, config => config.Ignore())
                .ForMember(dest => dest.Timestamp, config => config.Ignore());

            CreateMap<SampleObjectEntity, SampleObject>()
                .ForMember(dest => dest.Ticks, config => config.MapFrom(src => long.MaxValue - long.Parse(src.RowKey)))
                .ForMember(dest => dest.DeviceId, config => config.MapFrom(src => src.PartitionKey))
                .ForMember(dest => dest.MessageType, config => config.MapFrom(src => src.MessageType))
                .ForMember(dest => dest.Temperature, config => config.MapFrom(src => src.Temperature));

        }
    }
}
