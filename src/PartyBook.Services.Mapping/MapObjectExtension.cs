namespace PartyBook.Services.Mapping
{
    using AutoMapper;

    public static class MapObjectExtension
    {
        public static TDestination MapTo<TDestination>(this object obj)
            => AutoMapperConfig.MapperInstance.Map<TDestination>(obj);
    }
}
