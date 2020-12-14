using System;
using System.Runtime.Serialization;

namespace skinet.Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        pending,
        [EnumMember(Value = "Payment Recived")]
        PaymentRecived,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
