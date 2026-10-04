using Haveno.Shared.Enums;
using ProtoBuf;

namespace Haveno.Proto.Models.Requests;

[ProtoContract(Name = "ValidateFormFieldRequest")]
internal class ValidateFormFieldRequest
{
    [ProtoMember(1)]
    public PaymentAccountForm Form { get; set; } = new();
    [ProtoMember(2)]
    public FieldId FieldId { get; set; }
    [ProtoMember(3)]
    public string Value { get; set; } = string.Empty;
}