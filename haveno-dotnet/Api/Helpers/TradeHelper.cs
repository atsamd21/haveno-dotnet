using Haveno.Api.Models;

namespace Haveno.Api.Helpers;

public enum Role
{
    Buyer,
    Seller
}

public class TradeRoleAndStep
{
    public int Step { get; set; } = -1;
    public Role Role { get; set; }
}

public static class TradeHelper
{
    public static TradeRoleAndStep GetTradeRoleAndStep(TradeInfo tradeInfo)
    {
        TradeRoleAndStep tradeRoleAndStep = new();

        if (tradeInfo.Offer.IsMyOffer && tradeInfo.Offer.Direction == OfferDirection.BUY || !tradeInfo.Offer.IsMyOffer && tradeInfo.Offer.Direction == OfferDirection.SELL)
        {
            tradeRoleAndStep.Role = Role.Buyer;
        }
        else
        {
            tradeRoleAndStep.Role = Role.Seller;
        }

        switch (tradeInfo.PayoutState)
        {
            case PayoutState.PAYOUT_PUBLISHED:
            case PayoutState.PAYOUT_CONFIRMED:
            case PayoutState.PAYOUT_UNLOCKED:
                tradeRoleAndStep.Step = 4;
                return tradeRoleAndStep;
            default:
                break;
        }

        switch (tradeInfo.State)
        {
            case TradeState.ARBITRATOR_PUBLISHED_DEPOSIT_TXS:
            case TradeState.DEPOSIT_TXS_SEEN_IN_NETWORK:
            case TradeState.DEPOSIT_TXS_CONFIRMED_IN_BLOCKCHAIN:
                tradeRoleAndStep.Step = 1;
                break;
            case TradeState.DEPOSIT_TXS_UNLOCKED_IN_BLOCKCHAIN:
            case TradeState.DEPOSIT_TXS_FINALIZED_IN_BLOCKCHAIN:
                tradeRoleAndStep.Step = 2;
                break;
            case TradeState.BUYER_CONFIRMED_PAYMENT_SENT:
            case TradeState.BUYER_SENT_PAYMENT_SENT_MSG:
            case TradeState.BUYER_SAW_ARRIVED_PAYMENT_SENT_MSG:
                if (tradeRoleAndStep.Role == Role.Buyer)
                {
                    tradeRoleAndStep.Step = 2;
                }
                else
                {
                    tradeRoleAndStep.Step = tradeInfo.IsPayoutPublished ? 4 : 3;
                }
                break;
            case TradeState.BUYER_STORED_IN_MAILBOX_PAYMENT_SENT_MSG:
            case TradeState.SELLER_RECEIVED_PAYMENT_SENT_MSG:
                tradeRoleAndStep.Step = 3;
                break;
            case TradeState.BUYER_SEND_FAILED_PAYMENT_SENT_MSG:
                tradeRoleAndStep.Step = 2;
                break;
            case TradeState.SELLER_CONFIRMED_PAYMENT_RECEIPT:
                if (tradeRoleAndStep.Role == Role.Buyer)
                {
                    tradeRoleAndStep.Step = 3;
                }
                else
                {
                    tradeRoleAndStep.Step = tradeInfo.IsPayoutPublished ? 4 : 3;
                }
                break;
            case TradeState.SELLER_SENT_PAYMENT_RECEIVED_MSG:
                if (tradeRoleAndStep.Role == Role.Buyer)
                {
                    tradeRoleAndStep.Step = 4;
                }
                else
                {
                    tradeRoleAndStep.Step = tradeInfo.IsPayoutPublished ? 4 : 3;
                }
                break;
            case TradeState.SELLER_SEND_FAILED_PAYMENT_RECEIVED_MSG:
            case TradeState.SELLER_STORED_IN_MAILBOX_PAYMENT_RECEIVED_MSG:
            case TradeState.SELLER_SAW_ARRIVED_PAYMENT_RECEIVED_MSG:
            case TradeState.BUYER_RECEIVED_PAYMENT_RECEIVED_MSG:
                tradeRoleAndStep.Step = tradeInfo.IsPayoutPublished ? 4 : 3;
                break;
            default: break;
        }

        return tradeRoleAndStep;
    }
}
