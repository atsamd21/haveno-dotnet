using Haveno.Shared.Enums;

namespace Haveno.Api.Models;

public class PaymentAccountForm
{
    public FormId Id { get; set; }
    public List<PaymentAccountFormField> Fields { get; set; } = [];
}
