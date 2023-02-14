using MongoDB.Bson.Serialization;

namespace CarrBnk.Financial.Report.Infra.Serializer
{
    public class MongoDBDateTimeSerializer<TDateTime> : IBsonSerializer
    {
        static MongoDBDateTimeSerializer()
        {
            if (typeof(TDateTime) != typeof(DateTime) && typeof(TDateTime) != typeof(DateTime?))
            {
                throw new InvalidOperationException($"MyCustomDateTimeSerializer could be used only with {nameof(DateTime)} or {nameof(Nullable<DateTime>)}");
            }
        }
        public Type ValueType => typeof(TDateTime);

        //public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        //{
        //    var obj = base.Deserialize(context, args);

        //    return new DateTime(obj.Ticks, DateTimeKind.Unspecified);
        //}

        //public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        //{
        //    var utcValue = new DateTime(value.Ticks, DateTimeKind.Utc);
        //    base.Serialize(context, args, utcValue);
        //}

        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            throw new NotImplementedException();
        }

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
