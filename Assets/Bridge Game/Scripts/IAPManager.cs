using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager Instance;
    private static IStoreController m_StoreController;          
    private static IExtensionProvider m_StoreExtensionProvider;  
    
    public static string noAds = "NO_ADS";
    public static string Product_coins_100 = "COINS_100";
    public static string Product_coins_500 = "COINS_500";
    public static string Product_coins_1000 = "COINS_1000";
    public static string Product_coins_1500 = "COINS_1500";

	public void Start() {
		
        Instance = this;
        if (m_StoreController == null) { InitializePurchasing(); }   

    }
	public void InitializePurchasing()
	{   
		
        if (IsInitialized())  { return;  }          
	    var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());           
	    builder.AddProduct(noAds, ProductType.NonConsumable);           
	    builder.AddProduct(Product_coins_100, ProductType.Consumable);
	    builder.AddProduct(Product_coins_500, ProductType.Consumable);
	    builder.AddProduct(Product_coins_1000, ProductType.Consumable);
	    UnityPurchasing.Initialize(this, builder);

    }
    private bool IsInitialized() {
     return m_StoreController != null && m_StoreExtensionProvider != null;
    }
	public void BuyNoAds() { BuyProductID(noAds); }
	public void BuyCoins100() { BuyProductID(Product_coins_100); }
	public void BuyCoins500() { BuyProductID(Product_coins_500); }
	public void BuyCoins1000() { BuyProductID(Product_coins_1000); }

	void BuyProductID(string productId){ 
		
        if (IsInitialized()) {
            Product product = m_StoreController.products.WithID(productId);                
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));                   
                m_StoreController.InitiatePurchase(product);
            } else
            {                   
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        } else
        {             
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }  
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
           
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;
           
        m_StoreExtensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
           
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
           
        if (String.Equals(args.purchasedProduct.definition.id, noAds, StringComparison.Ordinal))
        {
            Debug.Log("Remove Ads Succesful");
               
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Product_coins_100, StringComparison.Ordinal))
        {
			Debug.Log("you have just bought 100 coins! Good Time");                
        }           
        else if (String.Equals(args.purchasedProduct.definition.id, Product_coins_500, StringComparison.Ordinal))
        {
			Debug.Log("you have just bought 500 coins! Good Time");

        } else if (String.Equals(args.purchasedProduct.definition.id, Product_coins_1000, StringComparison.Ordinal))
        {
            Debug.Log("you have just bought 1000 coins! Good Time");

        } 
        else
        {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {           
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}