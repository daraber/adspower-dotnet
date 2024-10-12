using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Internal;

internal class EmptyObjectToNullListConverter<T> : EmptyObjectToNullConverter<LocalApiList<T>> where T : class;