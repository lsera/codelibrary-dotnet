/* 
 * Zuora API Reference
 *
 *  # Introduction  Welcome to the reference for the Zuora REST API!  <a href=\"http://en.wikipedia.org/wiki/REST_API\" target=\"_blank\">REST</a> is a web-service protocol that lends itself to rapid development by using everyday HTTP and JSON technology.  The Zuora REST API provides a broad set of operations and resources that:  * Enable Web Storefront integration between your websites. * Support self-service subscriber sign-ups and account management. * Process revenue schedules through custom revenue rule models.  ## Endpoints  The Zuora REST services are provided via the following endpoints.  | Service                 | Base URL for REST Endpoints                                                                                                                                         | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Production REST service | https://rest.zuora.com/v1                                                                                                                                           | | Sandbox REST service    | https://rest.apisandbox.zuora.com/v1                                                                                                                                |  The production service provides access to your live user data. The sandbox environment is a good place to test your code without affecting real-world data. To use it, you must be provisioned with a sandbox tenant - your Zuora representative can help with this if needed.  ## Accessing the API  If you have a Zuora tenant, you already have access the the API.  If you don't have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a trial tenant. The tenant comes with seed data, such as a sample product catalog.   We recommend that you <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">create an API user</a> specifically for making API calls. Don't log in to the Zuora UI with this account. Logging in to the UI enables a security feature that periodically expires the account's password, which may eventually cause authentication failures with the API. Note that a user role does not have write access to Zuora REST services unless it has the API Write Access permission as described in those instructions.   # Authentication  There are three ways to authenticate:  * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the REST  `connections` resource with the following API user information:     *   ID     *   password     *   entity Id or entity name (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.)  *   Include the following parameters in the request header, which re-authenticates the user with each request:     *   `apiAccessKeyId`     *   `apiSecretAccessKey`     *   `entityId` or `entityName` (Only for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Multi-entity\"). See \"Entity Id and Entity Name\" below for more information.) *   For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.   ## Entity Id and Entity Name  The `entityId` and `entityName`  parameters are only used for  [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity).  The  `entityId` parameter specifies the Id of the entity that you want to access. The `entityName` parameter specifies the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access. Note that you must have permission to access the entity. You can get the entity Id and entity name through the REST GET Entities call.  You can specify either the  `entityId` or `entityName` parameter in the authentication to access and view an entity.  *   If both `entityId` and `entityName` are specified in the authentication, an error occurs.  *   If neither  `entityId` nor  `entityName` is specified in the authentication, you will log in to the entity in which your user account is created.   See [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"Zuora Multi-entity\") for more information.  ## Token Authentication for CORS-Enabled APIs  The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and makes your payment forms look just like any other part of your website.  For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.  The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should not be considered a replacement to the existing cookie authentication** mechanism.  See [Zuora CORS REST ](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/G_CORS_REST \"Zuora CORS REST\")for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](/BC_Developers/REST_API/B_REST_API_reference/HMAC_Signatures \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.    # Requests and Responses   ## Request IDs  As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or the number of the entity.  ## HTTP Request Body  Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request.  The Zuora REST API accepts JSON in the HTTP request body.  No other data format (e.g., XML) is supported.   ## Testing a Request  Use a third party client, such as Postman or Advanced REST Client, to test the Zuora REST API.  You can test the Zuora REST API from the Zuora sandbox or  production service. If connecting to the production service, bear in mind that you are working with your live production data, not sample data or test data.  ## Testing with Credit Cards  Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\").       ## Error Handling  Responses and error codes are detailed in [Responses and errors](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/3_Responses_and_errors \"Responses and errors\").    # Pagination  When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.  The default value for the maximum number of rows retrieved can be overridden at the method level.  If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.  ## Array Size  For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.   # API Versions  The Zuora REST API is in version control. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.   ## Major Version  The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example,  `POST https://rest.zuora.com/v1/subscriptions` .   ## Minor Version  Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it.   Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error.   If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the  `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.  The supported minor versions are not serial, see [Zuora REST API Minor Version History](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics/Zuora_REST_API_Minor_Version_History \"Zuora REST API Minor Version History\") for the fields and their supported minor versions. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.  You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.   For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration.     # Zuora Object Model The following diagram presents a high-level view of the key Zuora objects. Click the image to open it in a new tab to resize it.  <a href=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" target=\"_blank\"><img src=\"https://www.zuora.com/wp-content/uploads/2016/10/ZuoraERD-compressor-1.jpeg\" alt=\"Zuora Object Model Diagram\"></a> 
 *
 * OpenAPI spec version: 0.0.1
 * Contact: docs@zuora.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// GETProductRatePlanChargeType
    /// </summary>
    [DataContract]
    public partial class GETProductRatePlanChargeType :  IEquatable<GETProductRatePlanChargeType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GETProductRatePlanChargeType" /> class.
        /// </summary>
        /// <param name="ApplyDiscountTo">Specifies where (to what charge type) the discount will be applied. These field values are case-sensitive.  Permissible values: - RECURRING - USAGE - ONETIMERECURRING - ONETIMEUSAGE - RECURRINGUSAGE - ONETIMERECURRINGUSAGE .</param>
        /// <param name="BillingDay">The [bill cycle day](https://knowledgecenter.zuora.com/CB_Billing/WA_Dates_in_Zuora/C_Customer_Account_Dates%3A_Bill_Cycle_Day) (BCD) for the charge. The BCD determines which day of the month or week the customer is billed. The BCD value in the account can override the BCD in this object. .</param>
        /// <param name="BillingPeriod">The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values: - Month - Quarter - Annual - Semi-Annual - Specific Months - Week - Specific_Weeks .</param>
        /// <param name="BillingPeriodAlignment">Aligns charges within the same subscription if multiple charges begin on different dates.  Possible values: - AlignToCharge - AlignToSubscriptionStart - AlignToTermStart .</param>
        /// <param name="BillingTiming">The billing timing for the charge. You can choose to bill for charges in advance or in arrears.  Values: - In Advance - In Arrears  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="DefaultQuantity">The default quantity of units.  This field is required if you use a per-unit charge model. .</param>
        /// <param name="Description">Usually a brief line item summary of the Rate Plan Charge. .</param>
        /// <param name="DiscountLevel">The level of the discount.   Values: - RatePlan - Subscription - Account .</param>
        /// <param name="EndDateCondition">Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values: - Subscription_End - Fixed_Period .</param>
        /// <param name="FinanceInformation">FinanceInformation.</param>
        /// <param name="Id">Unique product rate-plan charge ID. .</param>
        /// <param name="IncludedUnits">Specifies the number of units in the base set of units when the charge model is Overage. .</param>
        /// <param name="ListPriceBase">The list price base for the product rate plan charge.  Values: - Month - Billing Period - Per_Week .</param>
        /// <param name="MaxQuantity">Specifies the maximum number of units for this charge. Use this field and the &#x60;minQuantity&#x60; field to create a range of units allowed in a product rate plan charge. .</param>
        /// <param name="MinQuantity">Specifies the minimum number of units for this charge. Use this field and the &#x60;maxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. .</param>
        /// <param name="Model">Charge model which determines how charges are calculated.  [Charge models](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models) must be individually activated in Z-Billing administration.   Possible values are: - FlatFee - PerUnit - Overage - Volume - Tiered - TieredWithOverage - DiscountFixedAmount - DiscountPercentage The [Pricing Summaries](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Catalog#Pricing_Summaries) section below details these charge models and their associated pricingSummary values. .</param>
        /// <param name="Name">Name of the product rate-plan charge. (Not required to be unique.) .</param>
        /// <param name="NumberOfPeriods">Value specifies the number of periods used in the smoothing model calculations Used when overage smoothing model is &#x60;RollingWindow&#x60; or &#x60;Rollover&#x60;. .</param>
        /// <param name="OverageCalculationOption">Value specifies when to calculate overage charges.  Values: - EndOfSmoothingPeriod - PerBillingPeriod .</param>
        /// <param name="OverageUnusedUnitsCreditOption">Determines whether to credit the customer with unused units of usage.  Values: - NoCredit - CreditBySpecificRate .</param>
        /// <param name="PrepayPeriods">The number of periods to which prepayment is set.   **Note:** This field is only available if you already have the [prepayment](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/A_Product_Catalog_Concepts/zz_Prepayments) feature enabled. The prepayment feature is deprecated and available only for backward compatibility. Zuora does not support enabling this feature anymore. .</param>
        /// <param name="PriceChangeOption">Applies an automatic price change when a termed subscription is renewed and the following applies:  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: - NoChange (default) - SpecificPercentageValue - UseLatestProductCatalogPricing .</param>
        /// <param name="PriceIncreasePercentage">Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the &#x60;PriceChangeOption&#x60; value to &#x60;SpecificPercentageValue&#x60;.  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: a decimal between -100 and 100 .</param>
        /// <param name="Pricing">One or more price charge models with attributes that further describe the model.  Some attributes show as null values when not applicable. .</param>
        /// <param name="PricingSummary">A concise description of the charge model and pricing that is suitable to show to your customers. See [Pricing Summaries](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Catalog#Pricing_Summaries) below for more information. .</param>
        /// <param name="RatingGroup">Specifies a rating group based on which usage records are rated.   **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="RevenueRecognitionRuleName">The name of the revenue recognition rule governing the revenue schedule. .</param>
        /// <param name="SmoothingModel">Specifies the smoothing model for an [overage smoothing charge model](https://knowledgecenter.zuora.com/CB_Billing/D_Product_Catalog/B_Charge_Models/A_Overage_Smoothing_Charge_Model) or an tiered with overage model, which is an advanced type of a usage model that avoids spikes in usage charges. If a customer&#39;s usage spikes in a single period, then an overage smoothing model eases overage charges by considering usage and multiple periods.  One of the following values shows which smoothing model will be applied to the charge when &#x60;Overage&#x60; or &#x60;Tiered with Overage&#x60; is used:  - &#x60;RollingWindow&#x60; considers a number of periods to smooth usage. The rolling window starts and increments forward based on billing frequency. When allowed usage is met, then period resets and a new window begins. - &#x60;Rollover&#x60; considers a fixed number of periods before calculating usage. The net balance at the end of a period is unused usage, which is carried over to the next period&#39;s balance. .</param>
        /// <param name="SpecificBillingPeriod">When the billing period is set to &#x60;Specific&#x60; Months then this positive integer reflects the number of months for billing period charges. .</param>
        /// <param name="TaxCode">Specifies the [tax code](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/L_Taxes/A_Z-Tax/B_Configure_Tax_Codes_in_Z-Billing) for taxation rules; used by Z-Tax. .</param>
        /// <param name="TaxMode">Specifies how to define taxation for the charge; used by Z-Tax. Possible values are: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;. .</param>
        /// <param name="Taxable">Specifies whether the charge is taxable; used by Z-Tax. Possible values are:&#x60;true&#x60;, &#x60;false&#x60;. .</param>
        /// <param name="TriggerEvent">Specifies when to start billing the customer for the charge.  Values: one of the following: - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription.  - &#x60;SpecificDate&#x60; is the date specified. .</param>
        /// <param name="Type">The type of charge. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. .</param>
        /// <param name="Uom">Describes the Units of Measure (uom) configured in **Z-Billing &gt; Settings** for the productRatePlanCharges.  Values: &#x60;Each&#x60;, &#x60;License&#x60;, &#x60;Seat&#x60;, or &#x60;null&#x60; .</param>
        /// <param name="UpToPeriods">Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="UpToPeriodsType">The period type used to define when the charge ends.  Values: - Billing_Periods - Days - Weeks - Months - Years    .</param>
        /// <param name="UsageRecordRatingOption">Determines how Zuora processes usage records for per-unit usage charges.  .</param>
        /// <param name="UseDiscountSpecificAccountingCode">Determines whether to define a new accounting code for the new discount charge. Values: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="UseTenantDefaultForPriceChange">Shows the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Z-Billing &gt; Define Default Subscription Settings**.  Values: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        public GETProductRatePlanChargeType(string ApplyDiscountTo = null, string BillingDay = null, string BillingPeriod = null, string BillingPeriodAlignment = null, string BillingTiming = null, string CustomFieldC = null, string DefaultQuantity = null, string Description = null, string DiscountLevel = null, string EndDateCondition = null, FinanceInformation FinanceInformation = null, string Id = null, string IncludedUnits = null, string ListPriceBase = null, string MaxQuantity = null, string MinQuantity = null, string Model = null, string Name = null, long? NumberOfPeriods = null, string OverageCalculationOption = null, string OverageUnusedUnitsCreditOption = null, long? PrepayPeriods = null, string PriceChangeOption = null, string PriceIncreasePercentage = null, List<GETProductRatePlanChargePricingType> Pricing = null, List<string> PricingSummary = null, string RatingGroup = null, string RevenueRecognitionRuleName = null, string SmoothingModel = null, long? SpecificBillingPeriod = null, string TaxCode = null, string TaxMode = null, bool? Taxable = null, string TriggerEvent = null, string Type = null, string Uom = null, long? UpToPeriods = null, string UpToPeriodsType = null, string UsageRecordRatingOption = null, bool? UseDiscountSpecificAccountingCode = null, bool? UseTenantDefaultForPriceChange = null)
        {
            this.ApplyDiscountTo = ApplyDiscountTo;
            this.BillingDay = BillingDay;
            this.BillingPeriod = BillingPeriod;
            this.BillingPeriodAlignment = BillingPeriodAlignment;
            this.BillingTiming = BillingTiming;
            this.CustomFieldC = CustomFieldC;
            this.DefaultQuantity = DefaultQuantity;
            this.Description = Description;
            this.DiscountLevel = DiscountLevel;
            this.EndDateCondition = EndDateCondition;
            this.FinanceInformation = FinanceInformation;
            this.Id = Id;
            this.IncludedUnits = IncludedUnits;
            this.ListPriceBase = ListPriceBase;
            this.MaxQuantity = MaxQuantity;
            this.MinQuantity = MinQuantity;
            this.Model = Model;
            this.Name = Name;
            this.NumberOfPeriods = NumberOfPeriods;
            this.OverageCalculationOption = OverageCalculationOption;
            this.OverageUnusedUnitsCreditOption = OverageUnusedUnitsCreditOption;
            this.PrepayPeriods = PrepayPeriods;
            this.PriceChangeOption = PriceChangeOption;
            this.PriceIncreasePercentage = PriceIncreasePercentage;
            this.Pricing = Pricing;
            this.PricingSummary = PricingSummary;
            this.RatingGroup = RatingGroup;
            this.RevenueRecognitionRuleName = RevenueRecognitionRuleName;
            this.SmoothingModel = SmoothingModel;
            this.SpecificBillingPeriod = SpecificBillingPeriod;
            this.TaxCode = TaxCode;
            this.TaxMode = TaxMode;
            this.Taxable = Taxable;
            this.TriggerEvent = TriggerEvent;
            this.Type = Type;
            this.Uom = Uom;
            this.UpToPeriods = UpToPeriods;
            this.UpToPeriodsType = UpToPeriodsType;
            this.UsageRecordRatingOption = UsageRecordRatingOption;
            this.UseDiscountSpecificAccountingCode = UseDiscountSpecificAccountingCode;
            this.UseTenantDefaultForPriceChange = UseTenantDefaultForPriceChange;
        }
        
        /// <summary>
        /// Specifies where (to what charge type) the discount will be applied. These field values are case-sensitive.  Permissible values: - RECURRING - USAGE - ONETIMERECURRING - ONETIMEUSAGE - RECURRINGUSAGE - ONETIMERECURRINGUSAGE 
        /// </summary>
        /// <value>Specifies where (to what charge type) the discount will be applied. These field values are case-sensitive.  Permissible values: - RECURRING - USAGE - ONETIMERECURRING - ONETIMEUSAGE - RECURRINGUSAGE - ONETIMERECURRINGUSAGE </value>
        [DataMember(Name="applyDiscountTo", EmitDefaultValue=false)]
        public string ApplyDiscountTo { get; set; }
        /// <summary>
        /// The [bill cycle day](https://knowledgecenter.zuora.com/CB_Billing/WA_Dates_in_Zuora/C_Customer_Account_Dates%3A_Bill_Cycle_Day) (BCD) for the charge. The BCD determines which day of the month or week the customer is billed. The BCD value in the account can override the BCD in this object. 
        /// </summary>
        /// <value>The [bill cycle day](https://knowledgecenter.zuora.com/CB_Billing/WA_Dates_in_Zuora/C_Customer_Account_Dates%3A_Bill_Cycle_Day) (BCD) for the charge. The BCD determines which day of the month or week the customer is billed. The BCD value in the account can override the BCD in this object. </value>
        [DataMember(Name="billingDay", EmitDefaultValue=false)]
        public string BillingDay { get; set; }
        /// <summary>
        /// The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values: - Month - Quarter - Annual - Semi-Annual - Specific Months - Week - Specific_Weeks 
        /// </summary>
        /// <value>The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values: - Month - Quarter - Annual - Semi-Annual - Specific Months - Week - Specific_Weeks </value>
        [DataMember(Name="billingPeriod", EmitDefaultValue=false)]
        public string BillingPeriod { get; set; }
        /// <summary>
        /// Aligns charges within the same subscription if multiple charges begin on different dates.  Possible values: - AlignToCharge - AlignToSubscriptionStart - AlignToTermStart 
        /// </summary>
        /// <value>Aligns charges within the same subscription if multiple charges begin on different dates.  Possible values: - AlignToCharge - AlignToSubscriptionStart - AlignToTermStart </value>
        [DataMember(Name="billingPeriodAlignment", EmitDefaultValue=false)]
        public string BillingPeriodAlignment { get; set; }
        /// <summary>
        /// The billing timing for the charge. You can choose to bill for charges in advance or in arrears.  Values: - In Advance - In Arrears  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  
        /// </summary>
        /// <value>The billing timing for the charge. You can choose to bill for charges in advance or in arrears.  Values: - In Advance - In Arrears  **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](https://support.zuora.com).  </value>
        [DataMember(Name="billingTiming", EmitDefaultValue=false)]
        public string BillingTiming { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// The default quantity of units.  This field is required if you use a per-unit charge model. 
        /// </summary>
        /// <value>The default quantity of units.  This field is required if you use a per-unit charge model. </value>
        [DataMember(Name="defaultQuantity", EmitDefaultValue=false)]
        public string DefaultQuantity { get; set; }
        /// <summary>
        /// Usually a brief line item summary of the Rate Plan Charge. 
        /// </summary>
        /// <value>Usually a brief line item summary of the Rate Plan Charge. </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// The level of the discount.   Values: - RatePlan - Subscription - Account 
        /// </summary>
        /// <value>The level of the discount.   Values: - RatePlan - Subscription - Account </value>
        [DataMember(Name="discountLevel", EmitDefaultValue=false)]
        public string DiscountLevel { get; set; }
        /// <summary>
        /// Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values: - Subscription_End - Fixed_Period 
        /// </summary>
        /// <value>Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values: - Subscription_End - Fixed_Period </value>
        [DataMember(Name="endDateCondition", EmitDefaultValue=false)]
        public string EndDateCondition { get; set; }
        /// <summary>
        /// Gets or Sets FinanceInformation
        /// </summary>
        [DataMember(Name="financeInformation", EmitDefaultValue=false)]
        public FinanceInformation FinanceInformation { get; set; }
        /// <summary>
        /// Unique product rate-plan charge ID. 
        /// </summary>
        /// <value>Unique product rate-plan charge ID. </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Specifies the number of units in the base set of units when the charge model is Overage. 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units when the charge model is Overage. </value>
        [DataMember(Name="includedUnits", EmitDefaultValue=false)]
        public string IncludedUnits { get; set; }
        /// <summary>
        /// The list price base for the product rate plan charge.  Values: - Month - Billing Period - Per_Week 
        /// </summary>
        /// <value>The list price base for the product rate plan charge.  Values: - Month - Billing Period - Per_Week </value>
        [DataMember(Name="listPriceBase", EmitDefaultValue=false)]
        public string ListPriceBase { get; set; }
        /// <summary>
        /// Specifies the maximum number of units for this charge. Use this field and the &#x60;minQuantity&#x60; field to create a range of units allowed in a product rate plan charge. 
        /// </summary>
        /// <value>Specifies the maximum number of units for this charge. Use this field and the &#x60;minQuantity&#x60; field to create a range of units allowed in a product rate plan charge. </value>
        [DataMember(Name="maxQuantity", EmitDefaultValue=false)]
        public string MaxQuantity { get; set; }
        /// <summary>
        /// Specifies the minimum number of units for this charge. Use this field and the &#x60;maxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. 
        /// </summary>
        /// <value>Specifies the minimum number of units for this charge. Use this field and the &#x60;maxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. </value>
        [DataMember(Name="minQuantity", EmitDefaultValue=false)]
        public string MinQuantity { get; set; }
        /// <summary>
        /// Charge model which determines how charges are calculated.  [Charge models](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models) must be individually activated in Z-Billing administration.   Possible values are: - FlatFee - PerUnit - Overage - Volume - Tiered - TieredWithOverage - DiscountFixedAmount - DiscountPercentage The [Pricing Summaries](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Catalog#Pricing_Summaries) section below details these charge models and their associated pricingSummary values. 
        /// </summary>
        /// <value>Charge model which determines how charges are calculated.  [Charge models](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models) must be individually activated in Z-Billing administration.   Possible values are: - FlatFee - PerUnit - Overage - Volume - Tiered - TieredWithOverage - DiscountFixedAmount - DiscountPercentage The [Pricing Summaries](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Catalog#Pricing_Summaries) section below details these charge models and their associated pricingSummary values. </value>
        [DataMember(Name="model", EmitDefaultValue=false)]
        public string Model { get; set; }
        /// <summary>
        /// Name of the product rate-plan charge. (Not required to be unique.) 
        /// </summary>
        /// <value>Name of the product rate-plan charge. (Not required to be unique.) </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Value specifies the number of periods used in the smoothing model calculations Used when overage smoothing model is &#x60;RollingWindow&#x60; or &#x60;Rollover&#x60;. 
        /// </summary>
        /// <value>Value specifies the number of periods used in the smoothing model calculations Used when overage smoothing model is &#x60;RollingWindow&#x60; or &#x60;Rollover&#x60;. </value>
        [DataMember(Name="numberOfPeriods", EmitDefaultValue=false)]
        public long? NumberOfPeriods { get; set; }
        /// <summary>
        /// Value specifies when to calculate overage charges.  Values: - EndOfSmoothingPeriod - PerBillingPeriod 
        /// </summary>
        /// <value>Value specifies when to calculate overage charges.  Values: - EndOfSmoothingPeriod - PerBillingPeriod </value>
        [DataMember(Name="overageCalculationOption", EmitDefaultValue=false)]
        public string OverageCalculationOption { get; set; }
        /// <summary>
        /// Determines whether to credit the customer with unused units of usage.  Values: - NoCredit - CreditBySpecificRate 
        /// </summary>
        /// <value>Determines whether to credit the customer with unused units of usage.  Values: - NoCredit - CreditBySpecificRate </value>
        [DataMember(Name="overageUnusedUnitsCreditOption", EmitDefaultValue=false)]
        public string OverageUnusedUnitsCreditOption { get; set; }
        /// <summary>
        /// The number of periods to which prepayment is set.   **Note:** This field is only available if you already have the [prepayment](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/A_Product_Catalog_Concepts/zz_Prepayments) feature enabled. The prepayment feature is deprecated and available only for backward compatibility. Zuora does not support enabling this feature anymore. 
        /// </summary>
        /// <value>The number of periods to which prepayment is set.   **Note:** This field is only available if you already have the [prepayment](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/A_Product_Catalog_Concepts/zz_Prepayments) feature enabled. The prepayment feature is deprecated and available only for backward compatibility. Zuora does not support enabling this feature anymore. </value>
        [DataMember(Name="prepayPeriods", EmitDefaultValue=false)]
        public long? PrepayPeriods { get; set; }
        /// <summary>
        /// Applies an automatic price change when a termed subscription is renewed and the following applies:  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: - NoChange (default) - SpecificPercentageValue - UseLatestProductCatalogPricing 
        /// </summary>
        /// <value>Applies an automatic price change when a termed subscription is renewed and the following applies:  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: - NoChange (default) - SpecificPercentageValue - UseLatestProductCatalogPricing </value>
        [DataMember(Name="priceChangeOption", EmitDefaultValue=false)]
        public string PriceChangeOption { get; set; }
        /// <summary>
        /// Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the &#x60;PriceChangeOption&#x60; value to &#x60;SpecificPercentageValue&#x60;.  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: a decimal between -100 and 100 
        /// </summary>
        /// <value>Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the &#x60;PriceChangeOption&#x60; value to &#x60;SpecificPercentageValue&#x60;.  1. AutomatedPriceChange setting is on 2. Charge type is not one-time 3. Charge model is not discount fixed amount  Values: a decimal between -100 and 100 </value>
        [DataMember(Name="priceIncreasePercentage", EmitDefaultValue=false)]
        public string PriceIncreasePercentage { get; set; }
        /// <summary>
        /// One or more price charge models with attributes that further describe the model.  Some attributes show as null values when not applicable. 
        /// </summary>
        /// <value>One or more price charge models with attributes that further describe the model.  Some attributes show as null values when not applicable. </value>
        [DataMember(Name="pricing", EmitDefaultValue=false)]
        public List<GETProductRatePlanChargePricingType> Pricing { get; set; }
        /// <summary>
        /// A concise description of the charge model and pricing that is suitable to show to your customers. See [Pricing Summaries](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Catalog#Pricing_Summaries) below for more information. 
        /// </summary>
        /// <value>A concise description of the charge model and pricing that is suitable to show to your customers. See [Pricing Summaries](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Catalog#Pricing_Summaries) below for more information. </value>
        [DataMember(Name="pricingSummary", EmitDefaultValue=false)]
        public List<string> PricingSummary { get; set; }
        /// <summary>
        /// Specifies a rating group based on which usage records are rated.   **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value>Specifies a rating group based on which usage records are rated.   **Note:** This feature is in Limited Availability. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name="ratingGroup", EmitDefaultValue=false)]
        public string RatingGroup { get; set; }
        /// <summary>
        /// The name of the revenue recognition rule governing the revenue schedule. 
        /// </summary>
        /// <value>The name of the revenue recognition rule governing the revenue schedule. </value>
        [DataMember(Name="revenueRecognitionRuleName", EmitDefaultValue=false)]
        public string RevenueRecognitionRuleName { get; set; }
        /// <summary>
        /// Specifies the smoothing model for an [overage smoothing charge model](https://knowledgecenter.zuora.com/CB_Billing/D_Product_Catalog/B_Charge_Models/A_Overage_Smoothing_Charge_Model) or an tiered with overage model, which is an advanced type of a usage model that avoids spikes in usage charges. If a customer&#39;s usage spikes in a single period, then an overage smoothing model eases overage charges by considering usage and multiple periods.  One of the following values shows which smoothing model will be applied to the charge when &#x60;Overage&#x60; or &#x60;Tiered with Overage&#x60; is used:  - &#x60;RollingWindow&#x60; considers a number of periods to smooth usage. The rolling window starts and increments forward based on billing frequency. When allowed usage is met, then period resets and a new window begins. - &#x60;Rollover&#x60; considers a fixed number of periods before calculating usage. The net balance at the end of a period is unused usage, which is carried over to the next period&#39;s balance. 
        /// </summary>
        /// <value>Specifies the smoothing model for an [overage smoothing charge model](https://knowledgecenter.zuora.com/CB_Billing/D_Product_Catalog/B_Charge_Models/A_Overage_Smoothing_Charge_Model) or an tiered with overage model, which is an advanced type of a usage model that avoids spikes in usage charges. If a customer&#39;s usage spikes in a single period, then an overage smoothing model eases overage charges by considering usage and multiple periods.  One of the following values shows which smoothing model will be applied to the charge when &#x60;Overage&#x60; or &#x60;Tiered with Overage&#x60; is used:  - &#x60;RollingWindow&#x60; considers a number of periods to smooth usage. The rolling window starts and increments forward based on billing frequency. When allowed usage is met, then period resets and a new window begins. - &#x60;Rollover&#x60; considers a fixed number of periods before calculating usage. The net balance at the end of a period is unused usage, which is carried over to the next period&#39;s balance. </value>
        [DataMember(Name="smoothingModel", EmitDefaultValue=false)]
        public string SmoothingModel { get; set; }
        /// <summary>
        /// When the billing period is set to &#x60;Specific&#x60; Months then this positive integer reflects the number of months for billing period charges. 
        /// </summary>
        /// <value>When the billing period is set to &#x60;Specific&#x60; Months then this positive integer reflects the number of months for billing period charges. </value>
        [DataMember(Name="specificBillingPeriod", EmitDefaultValue=false)]
        public long? SpecificBillingPeriod { get; set; }
        /// <summary>
        /// Specifies the [tax code](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/L_Taxes/A_Z-Tax/B_Configure_Tax_Codes_in_Z-Billing) for taxation rules; used by Z-Tax. 
        /// </summary>
        /// <value>Specifies the [tax code](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/L_Taxes/A_Z-Tax/B_Configure_Tax_Codes_in_Z-Billing) for taxation rules; used by Z-Tax. </value>
        [DataMember(Name="taxCode", EmitDefaultValue=false)]
        public string TaxCode { get; set; }
        /// <summary>
        /// Specifies how to define taxation for the charge; used by Z-Tax. Possible values are: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;. 
        /// </summary>
        /// <value>Specifies how to define taxation for the charge; used by Z-Tax. Possible values are: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60;. </value>
        [DataMember(Name="taxMode", EmitDefaultValue=false)]
        public string TaxMode { get; set; }
        /// <summary>
        /// Specifies whether the charge is taxable; used by Z-Tax. Possible values are:&#x60;true&#x60;, &#x60;false&#x60;. 
        /// </summary>
        /// <value>Specifies whether the charge is taxable; used by Z-Tax. Possible values are:&#x60;true&#x60;, &#x60;false&#x60;. </value>
        [DataMember(Name="taxable", EmitDefaultValue=false)]
        public bool? Taxable { get; set; }
        /// <summary>
        /// Specifies when to start billing the customer for the charge.  Values: one of the following: - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription.  - &#x60;SpecificDate&#x60; is the date specified. 
        /// </summary>
        /// <value>Specifies when to start billing the customer for the charge.  Values: one of the following: - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription.  - &#x60;SpecificDate&#x60; is the date specified. </value>
        [DataMember(Name="triggerEvent", EmitDefaultValue=false)]
        public string TriggerEvent { get; set; }
        /// <summary>
        /// The type of charge. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. 
        /// </summary>
        /// <value>The type of charge. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. </value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        /// Describes the Units of Measure (uom) configured in **Z-Billing &gt; Settings** for the productRatePlanCharges.  Values: &#x60;Each&#x60;, &#x60;License&#x60;, &#x60;Seat&#x60;, or &#x60;null&#x60; 
        /// </summary>
        /// <value>Describes the Units of Measure (uom) configured in **Z-Billing &gt; Settings** for the productRatePlanCharges.  Values: &#x60;Each&#x60;, &#x60;License&#x60;, &#x60;Seat&#x60;, or &#x60;null&#x60; </value>
        [DataMember(Name="uom", EmitDefaultValue=false)]
        public string Uom { get; set; }
        /// <summary>
        /// Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value>Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name="upToPeriods", EmitDefaultValue=false)]
        public long? UpToPeriods { get; set; }
        /// <summary>
        /// The period type used to define when the charge ends.  Values: - Billing_Periods - Days - Weeks - Months - Years    
        /// </summary>
        /// <value>The period type used to define when the charge ends.  Values: - Billing_Periods - Days - Weeks - Months - Years    </value>
        [DataMember(Name="upToPeriodsType", EmitDefaultValue=false)]
        public string UpToPeriodsType { get; set; }
        /// <summary>
        /// Determines how Zuora processes usage records for per-unit usage charges.  
        /// </summary>
        /// <value>Determines how Zuora processes usage records for per-unit usage charges.  </value>
        [DataMember(Name="usageRecordRatingOption", EmitDefaultValue=false)]
        public string UsageRecordRatingOption { get; set; }
        /// <summary>
        /// Determines whether to define a new accounting code for the new discount charge. Values: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value>Determines whether to define a new accounting code for the new discount charge. Values: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name="useDiscountSpecificAccountingCode", EmitDefaultValue=false)]
        public bool? UseDiscountSpecificAccountingCode { get; set; }
        /// <summary>
        /// Shows the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Z-Billing &gt; Define Default Subscription Settings**.  Values: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value>Shows the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Z-Billing &gt; Define Default Subscription Settings**.  Values: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name="useTenantDefaultForPriceChange", EmitDefaultValue=false)]
        public bool? UseTenantDefaultForPriceChange { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GETProductRatePlanChargeType {\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillingDay: ").Append(BillingDay).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  DefaultQuantity: ").Append(DefaultQuantity).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  FinanceInformation: ").Append(FinanceInformation).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  MaxQuantity: ").Append(MaxQuantity).Append("\n");
            sb.Append("  MinQuantity: ").Append(MinQuantity).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NumberOfPeriods: ").Append(NumberOfPeriods).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  PrepayPeriods: ").Append(PrepayPeriods).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  Pricing: ").Append(Pricing).Append("\n");
            sb.Append("  PricingSummary: ").Append(PricingSummary).Append("\n");
            sb.Append("  RatingGroup: ").Append(RatingGroup).Append("\n");
            sb.Append("  RevenueRecognitionRuleName: ").Append(RevenueRecognitionRuleName).Append("\n");
            sb.Append("  SmoothingModel: ").Append(SmoothingModel).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxMode: ").Append(TaxMode).Append("\n");
            sb.Append("  Taxable: ").Append(Taxable).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Uom: ").Append(Uom).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UsageRecordRatingOption: ").Append(UsageRecordRatingOption).Append("\n");
            sb.Append("  UseDiscountSpecificAccountingCode: ").Append(UseDiscountSpecificAccountingCode).Append("\n");
            sb.Append("  UseTenantDefaultForPriceChange: ").Append(UseTenantDefaultForPriceChange).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as GETProductRatePlanChargeType);
        }

        /// <summary>
        /// Returns true if GETProductRatePlanChargeType instances are equal
        /// </summary>
        /// <param name="other">Instance of GETProductRatePlanChargeType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETProductRatePlanChargeType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ApplyDiscountTo == other.ApplyDiscountTo ||
                    this.ApplyDiscountTo != null &&
                    this.ApplyDiscountTo.Equals(other.ApplyDiscountTo)
                ) && 
                (
                    this.BillingDay == other.BillingDay ||
                    this.BillingDay != null &&
                    this.BillingDay.Equals(other.BillingDay)
                ) && 
                (
                    this.BillingPeriod == other.BillingPeriod ||
                    this.BillingPeriod != null &&
                    this.BillingPeriod.Equals(other.BillingPeriod)
                ) && 
                (
                    this.BillingPeriodAlignment == other.BillingPeriodAlignment ||
                    this.BillingPeriodAlignment != null &&
                    this.BillingPeriodAlignment.Equals(other.BillingPeriodAlignment)
                ) && 
                (
                    this.BillingTiming == other.BillingTiming ||
                    this.BillingTiming != null &&
                    this.BillingTiming.Equals(other.BillingTiming)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.DefaultQuantity == other.DefaultQuantity ||
                    this.DefaultQuantity != null &&
                    this.DefaultQuantity.Equals(other.DefaultQuantity)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.DiscountLevel == other.DiscountLevel ||
                    this.DiscountLevel != null &&
                    this.DiscountLevel.Equals(other.DiscountLevel)
                ) && 
                (
                    this.EndDateCondition == other.EndDateCondition ||
                    this.EndDateCondition != null &&
                    this.EndDateCondition.Equals(other.EndDateCondition)
                ) && 
                (
                    this.FinanceInformation == other.FinanceInformation ||
                    this.FinanceInformation != null &&
                    this.FinanceInformation.Equals(other.FinanceInformation)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.IncludedUnits == other.IncludedUnits ||
                    this.IncludedUnits != null &&
                    this.IncludedUnits.Equals(other.IncludedUnits)
                ) && 
                (
                    this.ListPriceBase == other.ListPriceBase ||
                    this.ListPriceBase != null &&
                    this.ListPriceBase.Equals(other.ListPriceBase)
                ) && 
                (
                    this.MaxQuantity == other.MaxQuantity ||
                    this.MaxQuantity != null &&
                    this.MaxQuantity.Equals(other.MaxQuantity)
                ) && 
                (
                    this.MinQuantity == other.MinQuantity ||
                    this.MinQuantity != null &&
                    this.MinQuantity.Equals(other.MinQuantity)
                ) && 
                (
                    this.Model == other.Model ||
                    this.Model != null &&
                    this.Model.Equals(other.Model)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.NumberOfPeriods == other.NumberOfPeriods ||
                    this.NumberOfPeriods != null &&
                    this.NumberOfPeriods.Equals(other.NumberOfPeriods)
                ) && 
                (
                    this.OverageCalculationOption == other.OverageCalculationOption ||
                    this.OverageCalculationOption != null &&
                    this.OverageCalculationOption.Equals(other.OverageCalculationOption)
                ) && 
                (
                    this.OverageUnusedUnitsCreditOption == other.OverageUnusedUnitsCreditOption ||
                    this.OverageUnusedUnitsCreditOption != null &&
                    this.OverageUnusedUnitsCreditOption.Equals(other.OverageUnusedUnitsCreditOption)
                ) && 
                (
                    this.PrepayPeriods == other.PrepayPeriods ||
                    this.PrepayPeriods != null &&
                    this.PrepayPeriods.Equals(other.PrepayPeriods)
                ) && 
                (
                    this.PriceChangeOption == other.PriceChangeOption ||
                    this.PriceChangeOption != null &&
                    this.PriceChangeOption.Equals(other.PriceChangeOption)
                ) && 
                (
                    this.PriceIncreasePercentage == other.PriceIncreasePercentage ||
                    this.PriceIncreasePercentage != null &&
                    this.PriceIncreasePercentage.Equals(other.PriceIncreasePercentage)
                ) && 
                (
                    this.Pricing == other.Pricing ||
                    this.Pricing != null &&
                    this.Pricing.SequenceEqual(other.Pricing)
                ) && 
                (
                    this.PricingSummary == other.PricingSummary ||
                    this.PricingSummary != null &&
                    this.PricingSummary.SequenceEqual(other.PricingSummary)
                ) && 
                (
                    this.RatingGroup == other.RatingGroup ||
                    this.RatingGroup != null &&
                    this.RatingGroup.Equals(other.RatingGroup)
                ) && 
                (
                    this.RevenueRecognitionRuleName == other.RevenueRecognitionRuleName ||
                    this.RevenueRecognitionRuleName != null &&
                    this.RevenueRecognitionRuleName.Equals(other.RevenueRecognitionRuleName)
                ) && 
                (
                    this.SmoothingModel == other.SmoothingModel ||
                    this.SmoothingModel != null &&
                    this.SmoothingModel.Equals(other.SmoothingModel)
                ) && 
                (
                    this.SpecificBillingPeriod == other.SpecificBillingPeriod ||
                    this.SpecificBillingPeriod != null &&
                    this.SpecificBillingPeriod.Equals(other.SpecificBillingPeriod)
                ) && 
                (
                    this.TaxCode == other.TaxCode ||
                    this.TaxCode != null &&
                    this.TaxCode.Equals(other.TaxCode)
                ) && 
                (
                    this.TaxMode == other.TaxMode ||
                    this.TaxMode != null &&
                    this.TaxMode.Equals(other.TaxMode)
                ) && 
                (
                    this.Taxable == other.Taxable ||
                    this.Taxable != null &&
                    this.Taxable.Equals(other.Taxable)
                ) && 
                (
                    this.TriggerEvent == other.TriggerEvent ||
                    this.TriggerEvent != null &&
                    this.TriggerEvent.Equals(other.TriggerEvent)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Uom == other.Uom ||
                    this.Uom != null &&
                    this.Uom.Equals(other.Uom)
                ) && 
                (
                    this.UpToPeriods == other.UpToPeriods ||
                    this.UpToPeriods != null &&
                    this.UpToPeriods.Equals(other.UpToPeriods)
                ) && 
                (
                    this.UpToPeriodsType == other.UpToPeriodsType ||
                    this.UpToPeriodsType != null &&
                    this.UpToPeriodsType.Equals(other.UpToPeriodsType)
                ) && 
                (
                    this.UsageRecordRatingOption == other.UsageRecordRatingOption ||
                    this.UsageRecordRatingOption != null &&
                    this.UsageRecordRatingOption.Equals(other.UsageRecordRatingOption)
                ) && 
                (
                    this.UseDiscountSpecificAccountingCode == other.UseDiscountSpecificAccountingCode ||
                    this.UseDiscountSpecificAccountingCode != null &&
                    this.UseDiscountSpecificAccountingCode.Equals(other.UseDiscountSpecificAccountingCode)
                ) && 
                (
                    this.UseTenantDefaultForPriceChange == other.UseTenantDefaultForPriceChange ||
                    this.UseTenantDefaultForPriceChange != null &&
                    this.UseTenantDefaultForPriceChange.Equals(other.UseTenantDefaultForPriceChange)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.ApplyDiscountTo != null)
                    hash = hash * 59 + this.ApplyDiscountTo.GetHashCode();
                if (this.BillingDay != null)
                    hash = hash * 59 + this.BillingDay.GetHashCode();
                if (this.BillingPeriod != null)
                    hash = hash * 59 + this.BillingPeriod.GetHashCode();
                if (this.BillingPeriodAlignment != null)
                    hash = hash * 59 + this.BillingPeriodAlignment.GetHashCode();
                if (this.BillingTiming != null)
                    hash = hash * 59 + this.BillingTiming.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.DefaultQuantity != null)
                    hash = hash * 59 + this.DefaultQuantity.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.DiscountLevel != null)
                    hash = hash * 59 + this.DiscountLevel.GetHashCode();
                if (this.EndDateCondition != null)
                    hash = hash * 59 + this.EndDateCondition.GetHashCode();
                if (this.FinanceInformation != null)
                    hash = hash * 59 + this.FinanceInformation.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.IncludedUnits != null)
                    hash = hash * 59 + this.IncludedUnits.GetHashCode();
                if (this.ListPriceBase != null)
                    hash = hash * 59 + this.ListPriceBase.GetHashCode();
                if (this.MaxQuantity != null)
                    hash = hash * 59 + this.MaxQuantity.GetHashCode();
                if (this.MinQuantity != null)
                    hash = hash * 59 + this.MinQuantity.GetHashCode();
                if (this.Model != null)
                    hash = hash * 59 + this.Model.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.NumberOfPeriods != null)
                    hash = hash * 59 + this.NumberOfPeriods.GetHashCode();
                if (this.OverageCalculationOption != null)
                    hash = hash * 59 + this.OverageCalculationOption.GetHashCode();
                if (this.OverageUnusedUnitsCreditOption != null)
                    hash = hash * 59 + this.OverageUnusedUnitsCreditOption.GetHashCode();
                if (this.PrepayPeriods != null)
                    hash = hash * 59 + this.PrepayPeriods.GetHashCode();
                if (this.PriceChangeOption != null)
                    hash = hash * 59 + this.PriceChangeOption.GetHashCode();
                if (this.PriceIncreasePercentage != null)
                    hash = hash * 59 + this.PriceIncreasePercentage.GetHashCode();
                if (this.Pricing != null)
                    hash = hash * 59 + this.Pricing.GetHashCode();
                if (this.PricingSummary != null)
                    hash = hash * 59 + this.PricingSummary.GetHashCode();
                if (this.RatingGroup != null)
                    hash = hash * 59 + this.RatingGroup.GetHashCode();
                if (this.RevenueRecognitionRuleName != null)
                    hash = hash * 59 + this.RevenueRecognitionRuleName.GetHashCode();
                if (this.SmoothingModel != null)
                    hash = hash * 59 + this.SmoothingModel.GetHashCode();
                if (this.SpecificBillingPeriod != null)
                    hash = hash * 59 + this.SpecificBillingPeriod.GetHashCode();
                if (this.TaxCode != null)
                    hash = hash * 59 + this.TaxCode.GetHashCode();
                if (this.TaxMode != null)
                    hash = hash * 59 + this.TaxMode.GetHashCode();
                if (this.Taxable != null)
                    hash = hash * 59 + this.Taxable.GetHashCode();
                if (this.TriggerEvent != null)
                    hash = hash * 59 + this.TriggerEvent.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.Uom != null)
                    hash = hash * 59 + this.Uom.GetHashCode();
                if (this.UpToPeriods != null)
                    hash = hash * 59 + this.UpToPeriods.GetHashCode();
                if (this.UpToPeriodsType != null)
                    hash = hash * 59 + this.UpToPeriodsType.GetHashCode();
                if (this.UsageRecordRatingOption != null)
                    hash = hash * 59 + this.UsageRecordRatingOption.GetHashCode();
                if (this.UseDiscountSpecificAccountingCode != null)
                    hash = hash * 59 + this.UseDiscountSpecificAccountingCode.GetHashCode();
                if (this.UseTenantDefaultForPriceChange != null)
                    hash = hash * 59 + this.UseTenantDefaultForPriceChange.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
