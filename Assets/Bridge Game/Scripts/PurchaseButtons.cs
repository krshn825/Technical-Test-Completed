using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButtons : MonoBehaviour
{
	public enum PurchaseType {noAds,coins100, coins500, coins1000};
	public PurchaseType purchaseType;

	public void ClickPurchaseButton() {

				switch (purchaseType) {
		case PurchaseType.noAds:
			
			if(IAPManager.Instance){				
				IAPManager.Instance.BuyNoAds();
			}
					break;
		case PurchaseType.coins100:
			if (IAPManager.Instance) {
				IAPManager.Instance.BuyCoins100 ();
			}
					break;
		case PurchaseType.coins500:
			if (IAPManager.Instance) {
				IAPManager.Instance.BuyCoins500 ();
			}
					break;
		case PurchaseType.coins1000:
			if (IAPManager.Instance) {
				IAPManager.Instance.BuyCoins1000 ();
			}
					break;

				}

	}

   
}
