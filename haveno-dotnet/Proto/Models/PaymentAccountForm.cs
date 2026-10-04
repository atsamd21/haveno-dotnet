using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models;

[ProtoContract(Name = "PaymentAccountForm")]
internal class PaymentAccountForm
{
    [ProtoMember(1)]
    public FormId Id { get; set; }
    [ProtoMember(2)]
    public List<PaymentAccountFormField> Fields { get; set; } = [];
}
