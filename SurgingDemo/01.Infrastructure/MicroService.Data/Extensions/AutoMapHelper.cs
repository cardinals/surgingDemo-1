using AutoMapper;
using MicroService.Core;
using Surging.Core.CPlatform;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroService.Data.Ext
{
    public static class AutoMapHelper
    {
        /// <summary>
        /// 集合列表类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的model，可以理解为viewmodel</typeparam>
        /// <typeparam name="TSource">要被转化的实体，Entity</typeparam>
        /// <param name="source">可以使用这个扩展方法的类型，任何引用类型</param>
        /// <returns>转化之后的实体列表</returns>
        public static IEnumerable<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
            where TDestination : class
            where TSource : class
        {
            if (source == null) return new List<TDestination>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<TDestination>>(source);
        }
        public static TDestination MapToEntity<TSource, TDestination>(this TSource source)
         where TDestination : RequestData
         where TSource : RequestData
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()
             .ForMember(dest => dest.Payload, opt => opt.Ignore()));
            var mapper = config.CreateMapper();

            return mapper.Map<TDestination>(source);
        }
        public static TDestination MapEntity<TSource, TDestination>(this TSource source)
  where TDestination : RequestData
  where TSource : Entity<string>
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()
             .ForMember(dest => dest.Payload, opt => opt.Ignore()));
            var mapper = config.CreateMapper();

            return mapper.Map<TDestination>(source);
        }

    } 


}
