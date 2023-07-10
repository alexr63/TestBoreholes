using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaMoney;

namespace TestBoreholes;

public class MoneySerializer : SerializerBase<Money>
{
    public override Money Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        // Deserialize the Money object
        // You may need to customize this logic based on your requirements
        var doc = BsonDocumentSerializer.Instance.Deserialize(context);
        decimal amount = doc["amount"].AsDecimal;
        string currencyCode = doc["currencyCode"].AsString;
        return new Money(amount, Currency.FromCode(currencyCode));
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Money value)
    {
        // Serialize the Money object
        // You may need to customize this logic based on your requirements
        var doc = new BsonDocument
        {
            { "amount", value.Amount },
            { "currencyCode", value.Currency.Code }
        };
        BsonDocumentSerializer.Instance.Serialize(context, doc);
    }
}