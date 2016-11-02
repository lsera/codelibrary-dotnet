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
    /// GETSubscriptionRatePlanChargesType
    /// </summary>
    [DataContract]
    public partial class GETSubscriptionRatePlanChargesType :  IEquatable<GETSubscriptionRatePlanChargesType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GETSubscriptionRatePlanChargesType" /> class.
        /// </summary>
        /// <param name="ApplyDiscountTo">Specifies the type of charges a specific discount applies to.   This field is only used when applied to a discount charge model. If you are not using a discount charge model, the value is null.  Possible values:  * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60; .</param>
        /// <param name="BillingDay">Billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account.    Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayofMonth(#)&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayOfWeek/dayofweek&#x60;: in which dayofweek is the day in the week you define your billing periods to start.  In the response data, a day-of-the-month value (&#x60;1&#x60;-&#x60;31&#x60;) appears in place of the hash sign above (\&quot;#\&quot;). If this value exceeds the number of days in a particular month, the last day of the month is used as the BCD. .</param>
        /// <param name="BillingPeriod">Allows billing period to be overridden on the rate plan charge. .</param>
        /// <param name="BillingPeriodAlignment">Possible values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60; .</param>
        /// <param name="BillingTiming">The billing timing for the charge. This field is only used if the &#x60;ratePlanChargeType&#x60; value is &#x60;Recurring&#x60;.  Possible values are:  * &#x60;In Advance&#x60; * &#x60;In Arrears&#x60;  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). .</param>
        /// <param name="ChargedThroughDate">The date through which a customer has been billed for the charge. .</param>
        /// <param name="Currency">Currency used by the account. For example, &#x60;USD&#x60; or &#x60;EUR&#x60;. .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="Description">Description of the rate plan charge. .</param>
        /// <param name="DiscountAmount">The amount of the discount. .</param>
        /// <param name="DiscountLevel">The level of the discount. Values: &#x60;RatePlan&#x60;, &#x60;Subscription&#x60;, &#x60;Account&#x60;. .</param>
        /// <param name="DiscountPercentage">The amount of the discount as a percentage. .</param>
        /// <param name="Dmrc">The change (delta) of monthly recurring charge exists when the change in monthly recurring revenue caused by an amendment or a new subscription. .</param>
        /// <param name="Done">A value of &#x60;true&#x60; indicates that an invoice for a charge segment has been completed. A value of &#x60;false&#x60; indicates that an invoice has not bee completed for the charge segment. .</param>
        /// <param name="Dtcv">After an amendment or an AutomatedPriceChange event, &#x60;dtcv&#x60; displays the change (delta) for the total contract value (TCV) amount for this charge, compared with its previous value with recurring charge types. .</param>
        /// <param name="EffectiveEndDate">The effective end date of the rate plan charge. .</param>
        /// <param name="EffectiveStartDate">The effective start date of the rate plan charge. .</param>
        /// <param name="EndDateCondition">Defines when the charge ends after the charge trigger date.  If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; .</param>
        /// <param name="Id">Rate plan charge ID. .</param>
        /// <param name="IncludedUnits">Specifies the number of units in the base set of units. .</param>
        /// <param name="ListPriceBase">List price base; possible values are:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60; .</param>
        /// <param name="Model">Charge model; possible values are:  * &#x60;FlatFee&#x60; * &#x60;PerUnit&#x60; * &#x60;Overage&#x60; * &#x60;Volume&#x60; * &#x60;Tiered&#x60; * &#x60;TieredWithOverage&#x60; * &#x60;DiscountFixedAmount&#x60; * &#x60;DiscountPercentage&#x60; .</param>
        /// <param name="Mrr">Monthly recurring revenue of the rate plan charge. .</param>
        /// <param name="Name">Charge name. .</param>
        /// <param name="Number">Charge number. .</param>
        /// <param name="NumberOfPeriods">Specifies the number of periods to use when calculating charges in an overage smoothing charge model. .</param>
        /// <param name="OriginalChargeId">The original ID of the rate plan charge. .</param>
        /// <param name="OverageCalculationOption">Determines when to calculate overage charges. .</param>
        /// <param name="OveragePrice">The price for units over the allowed amount. .</param>
        /// <param name="OverageUnusedUnitsCreditOption">Determines whether to credit the customer with unused units of usage. .</param>
        /// <param name="Price">The price associated with the rate plan charge expressed as a decimal. .</param>
        /// <param name="PriceChangeOption">When the following is true:  1. AutomatedPriceChange setting is on  2. Charge type is not one-time  3. Charge model is not discount percentage  Then an automatic price change can have a value for when a termed subscription is renewed.   Values (one of the following):  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60; .</param>
        /// <param name="PriceIncreasePercentage">A planned future price increase amount as a percentage. .</param>
        /// <param name="PricingSummary">Concise description of rate plan charge model. .</param>
        /// <param name="ProcessedThroughDate">The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. .</param>
        /// <param name="ProductRatePlanChargeId">.</param>
        /// <param name="Quantity">The quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. .</param>
        /// <param name="RatingGroup">Specifies a rating group based on which usage records are rated.   Possible values are:  * &#x60;ByBillingPeriod&#x60; (default) * &#x60;ByUsageStartDate&#x60; * &#x60;ByUsageRecord&#x60; * &#x60;ByUsageUpload&#x60;  **Note:** This field is only used for per unit, volume pricing, and tiered pricing charge models. Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). .</param>
        /// <param name="Segment">The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. .</param>
        /// <param name="SmoothingModel">Specifies when revenue recognition begins. When charge model is &#x60;Overage&#x60; or &#x60;TieredWithOverage&#x60;, &#x60;smoothingModel&#x60; will be one of the following values:  * &#x60;ContractEffectiveDate&#x60; * &#x60;ServiceActivationDate&#x60; * &#x60;CustomerAcceptanceDate&#x60; .</param>
        /// <param name="SpecificBillingPeriod">Customizes the number of month or week for the charges billing period. This field is required if you set the value of the &#x60;BillingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;. .</param>
        /// <param name="SpecificEndDate">The specific date on which the charge ends. If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. .</param>
        /// <param name="Tcv">The total contract value. .</param>
        /// <param name="Tiers">One or many defined ranges with distinct pricing. .</param>
        /// <param name="TriggerDate">The date that the rate plan charge will be triggered. .</param>
        /// <param name="TriggerEvent">The event that will cause the rate plan charge to be triggered.  Possible values:   * &#x60;ContractEffective&#x60; * &#x60;ServiceActivation&#x60; * &#x60;CustomerAcceptance&#x60; * &#x60;SpecificDate&#x60; .</param>
        /// <param name="Type">Charge type. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. .</param>
        /// <param name="UnusedUnitsCreditRates">Specifies the rate to credit a customer for unused units of usage. This field is applicable only for overage charge models when the  &#x60;OverageUnusedUnitsCreditOption&#x60; field value is &#x60;CreditBySpecificRate&#x60;. .</param>
        /// <param name="Uom">Specifies the units to measure usage.  .</param>
        /// <param name="UpToPeriods">Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends.  If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="UpToPeriodsType">The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60; .</param>
        /// <param name="UsageRecordRatingOption">Determines how Zuora processes usage records for per-unit usage charges.  .</param>
        /// <param name="Version">Rate plan charge revision number. .</param>
        public GETSubscriptionRatePlanChargesType(string ApplyDiscountTo = null, string BillingDay = null, string BillingPeriod = null, string BillingPeriodAlignment = null, string BillingTiming = null, DateTime? ChargedThroughDate = null, string Currency = null, string CustomFieldC = null, string Description = null, string DiscountAmount = null, string DiscountLevel = null, string DiscountPercentage = null, string Dmrc = null, bool? Done = null, string Dtcv = null, DateTime? EffectiveEndDate = null, DateTime? EffectiveStartDate = null, string EndDateCondition = null, string Id = null, string IncludedUnits = null, string ListPriceBase = null, string Model = null, string Mrr = null, string Name = null, string Number = null, long? NumberOfPeriods = null, string OriginalChargeId = null, string OverageCalculationOption = null, string OveragePrice = null, string OverageUnusedUnitsCreditOption = null, string Price = null, string PriceChangeOption = null, string PriceIncreasePercentage = null, string PricingSummary = null, DateTime? ProcessedThroughDate = null, string ProductRatePlanChargeId = null, string Quantity = null, string RatingGroup = null, DateTime? Segment = null, string SmoothingModel = null, long? SpecificBillingPeriod = null, DateTime? SpecificEndDate = null, string Tcv = null, List<GETTierType> Tiers = null, DateTime? TriggerDate = null, string TriggerEvent = null, string Type = null, string UnusedUnitsCreditRates = null, string Uom = null, string UpToPeriods = null, string UpToPeriodsType = null, string UsageRecordRatingOption = null, long? Version = null)
        {
            this.ApplyDiscountTo = ApplyDiscountTo;
            this.BillingDay = BillingDay;
            this.BillingPeriod = BillingPeriod;
            this.BillingPeriodAlignment = BillingPeriodAlignment;
            this.BillingTiming = BillingTiming;
            this.ChargedThroughDate = ChargedThroughDate;
            this.Currency = Currency;
            this.CustomFieldC = CustomFieldC;
            this.Description = Description;
            this.DiscountAmount = DiscountAmount;
            this.DiscountLevel = DiscountLevel;
            this.DiscountPercentage = DiscountPercentage;
            this.Dmrc = Dmrc;
            this.Done = Done;
            this.Dtcv = Dtcv;
            this.EffectiveEndDate = EffectiveEndDate;
            this.EffectiveStartDate = EffectiveStartDate;
            this.EndDateCondition = EndDateCondition;
            this.Id = Id;
            this.IncludedUnits = IncludedUnits;
            this.ListPriceBase = ListPriceBase;
            this.Model = Model;
            this.Mrr = Mrr;
            this.Name = Name;
            this.Number = Number;
            this.NumberOfPeriods = NumberOfPeriods;
            this.OriginalChargeId = OriginalChargeId;
            this.OverageCalculationOption = OverageCalculationOption;
            this.OveragePrice = OveragePrice;
            this.OverageUnusedUnitsCreditOption = OverageUnusedUnitsCreditOption;
            this.Price = Price;
            this.PriceChangeOption = PriceChangeOption;
            this.PriceIncreasePercentage = PriceIncreasePercentage;
            this.PricingSummary = PricingSummary;
            this.ProcessedThroughDate = ProcessedThroughDate;
            this.ProductRatePlanChargeId = ProductRatePlanChargeId;
            this.Quantity = Quantity;
            this.RatingGroup = RatingGroup;
            this.Segment = Segment;
            this.SmoothingModel = SmoothingModel;
            this.SpecificBillingPeriod = SpecificBillingPeriod;
            this.SpecificEndDate = SpecificEndDate;
            this.Tcv = Tcv;
            this.Tiers = Tiers;
            this.TriggerDate = TriggerDate;
            this.TriggerEvent = TriggerEvent;
            this.Type = Type;
            this.UnusedUnitsCreditRates = UnusedUnitsCreditRates;
            this.Uom = Uom;
            this.UpToPeriods = UpToPeriods;
            this.UpToPeriodsType = UpToPeriodsType;
            this.UsageRecordRatingOption = UsageRecordRatingOption;
            this.Version = Version;
        }
        
        /// <summary>
        /// Specifies the type of charges a specific discount applies to.   This field is only used when applied to a discount charge model. If you are not using a discount charge model, the value is null.  Possible values:  * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60; 
        /// </summary>
        /// <value>Specifies the type of charges a specific discount applies to.   This field is only used when applied to a discount charge model. If you are not using a discount charge model, the value is null.  Possible values:  * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60; </value>
        [DataMember(Name="applyDiscountTo", EmitDefaultValue=false)]
        public string ApplyDiscountTo { get; set; }
        /// <summary>
        /// Billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account.    Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayofMonth(#)&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayOfWeek/dayofweek&#x60;: in which dayofweek is the day in the week you define your billing periods to start.  In the response data, a day-of-the-month value (&#x60;1&#x60;-&#x60;31&#x60;) appears in place of the hash sign above (\&quot;#\&quot;). If this value exceeds the number of days in a particular month, the last day of the month is used as the BCD. 
        /// </summary>
        /// <value>Billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account.    Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayofMonth(#)&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayOfWeek/dayofweek&#x60;: in which dayofweek is the day in the week you define your billing periods to start.  In the response data, a day-of-the-month value (&#x60;1&#x60;-&#x60;31&#x60;) appears in place of the hash sign above (\&quot;#\&quot;). If this value exceeds the number of days in a particular month, the last day of the month is used as the BCD. </value>
        [DataMember(Name="billingDay", EmitDefaultValue=false)]
        public string BillingDay { get; set; }
        /// <summary>
        /// Allows billing period to be overridden on the rate plan charge. 
        /// </summary>
        /// <value>Allows billing period to be overridden on the rate plan charge. </value>
        [DataMember(Name="billingPeriod", EmitDefaultValue=false)]
        public string BillingPeriod { get; set; }
        /// <summary>
        /// Possible values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60; 
        /// </summary>
        /// <value>Possible values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60; </value>
        [DataMember(Name="billingPeriodAlignment", EmitDefaultValue=false)]
        public string BillingPeriodAlignment { get; set; }
        /// <summary>
        /// The billing timing for the charge. This field is only used if the &#x60;ratePlanChargeType&#x60; value is &#x60;Recurring&#x60;.  Possible values are:  * &#x60;In Advance&#x60; * &#x60;In Arrears&#x60;  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). 
        /// </summary>
        /// <value>The billing timing for the charge. This field is only used if the &#x60;ratePlanChargeType&#x60; value is &#x60;Recurring&#x60;.  Possible values are:  * &#x60;In Advance&#x60; * &#x60;In Arrears&#x60;  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). </value>
        [DataMember(Name="billingTiming", EmitDefaultValue=false)]
        public string BillingTiming { get; set; }
        /// <summary>
        /// The date through which a customer has been billed for the charge. 
        /// </summary>
        /// <value>The date through which a customer has been billed for the charge. </value>
        [DataMember(Name="chargedThroughDate", EmitDefaultValue=false)]
        public DateTime? ChargedThroughDate { get; set; }
        /// <summary>
        /// Currency used by the account. For example, &#x60;USD&#x60; or &#x60;EUR&#x60;. 
        /// </summary>
        /// <value>Currency used by the account. For example, &#x60;USD&#x60; or &#x60;EUR&#x60;. </value>
        [DataMember(Name="currency", EmitDefaultValue=false)]
        public string Currency { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// Description of the rate plan charge. 
        /// </summary>
        /// <value>Description of the rate plan charge. </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// The amount of the discount. 
        /// </summary>
        /// <value>The amount of the discount. </value>
        [DataMember(Name="discountAmount", EmitDefaultValue=false)]
        public string DiscountAmount { get; set; }
        /// <summary>
        /// The level of the discount. Values: &#x60;RatePlan&#x60;, &#x60;Subscription&#x60;, &#x60;Account&#x60;. 
        /// </summary>
        /// <value>The level of the discount. Values: &#x60;RatePlan&#x60;, &#x60;Subscription&#x60;, &#x60;Account&#x60;. </value>
        [DataMember(Name="discountLevel", EmitDefaultValue=false)]
        public string DiscountLevel { get; set; }
        /// <summary>
        /// The amount of the discount as a percentage. 
        /// </summary>
        /// <value>The amount of the discount as a percentage. </value>
        [DataMember(Name="discountPercentage", EmitDefaultValue=false)]
        public string DiscountPercentage { get; set; }
        /// <summary>
        /// The change (delta) of monthly recurring charge exists when the change in monthly recurring revenue caused by an amendment or a new subscription. 
        /// </summary>
        /// <value>The change (delta) of monthly recurring charge exists when the change in monthly recurring revenue caused by an amendment or a new subscription. </value>
        [DataMember(Name="dmrc", EmitDefaultValue=false)]
        public string Dmrc { get; set; }
        /// <summary>
        /// A value of &#x60;true&#x60; indicates that an invoice for a charge segment has been completed. A value of &#x60;false&#x60; indicates that an invoice has not bee completed for the charge segment. 
        /// </summary>
        /// <value>A value of &#x60;true&#x60; indicates that an invoice for a charge segment has been completed. A value of &#x60;false&#x60; indicates that an invoice has not bee completed for the charge segment. </value>
        [DataMember(Name="done", EmitDefaultValue=false)]
        public bool? Done { get; set; }
        /// <summary>
        /// After an amendment or an AutomatedPriceChange event, &#x60;dtcv&#x60; displays the change (delta) for the total contract value (TCV) amount for this charge, compared with its previous value with recurring charge types. 
        /// </summary>
        /// <value>After an amendment or an AutomatedPriceChange event, &#x60;dtcv&#x60; displays the change (delta) for the total contract value (TCV) amount for this charge, compared with its previous value with recurring charge types. </value>
        [DataMember(Name="dtcv", EmitDefaultValue=false)]
        public string Dtcv { get; set; }
        /// <summary>
        /// The effective end date of the rate plan charge. 
        /// </summary>
        /// <value>The effective end date of the rate plan charge. </value>
        [DataMember(Name="effectiveEndDate", EmitDefaultValue=false)]
        public DateTime? EffectiveEndDate { get; set; }
        /// <summary>
        /// The effective start date of the rate plan charge. 
        /// </summary>
        /// <value>The effective start date of the rate plan charge. </value>
        [DataMember(Name="effectiveStartDate", EmitDefaultValue=false)]
        public DateTime? EffectiveStartDate { get; set; }
        /// <summary>
        /// Defines when the charge ends after the charge trigger date.  If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; 
        /// </summary>
        /// <value>Defines when the charge ends after the charge trigger date.  If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; </value>
        [DataMember(Name="endDateCondition", EmitDefaultValue=false)]
        public string EndDateCondition { get; set; }
        /// <summary>
        /// Rate plan charge ID. 
        /// </summary>
        /// <value>Rate plan charge ID. </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Specifies the number of units in the base set of units. 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units. </value>
        [DataMember(Name="includedUnits", EmitDefaultValue=false)]
        public string IncludedUnits { get; set; }
        /// <summary>
        /// List price base; possible values are:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60; 
        /// </summary>
        /// <value>List price base; possible values are:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60; </value>
        [DataMember(Name="listPriceBase", EmitDefaultValue=false)]
        public string ListPriceBase { get; set; }
        /// <summary>
        /// Charge model; possible values are:  * &#x60;FlatFee&#x60; * &#x60;PerUnit&#x60; * &#x60;Overage&#x60; * &#x60;Volume&#x60; * &#x60;Tiered&#x60; * &#x60;TieredWithOverage&#x60; * &#x60;DiscountFixedAmount&#x60; * &#x60;DiscountPercentage&#x60; 
        /// </summary>
        /// <value>Charge model; possible values are:  * &#x60;FlatFee&#x60; * &#x60;PerUnit&#x60; * &#x60;Overage&#x60; * &#x60;Volume&#x60; * &#x60;Tiered&#x60; * &#x60;TieredWithOverage&#x60; * &#x60;DiscountFixedAmount&#x60; * &#x60;DiscountPercentage&#x60; </value>
        [DataMember(Name="model", EmitDefaultValue=false)]
        public string Model { get; set; }
        /// <summary>
        /// Monthly recurring revenue of the rate plan charge. 
        /// </summary>
        /// <value>Monthly recurring revenue of the rate plan charge. </value>
        [DataMember(Name="mrr", EmitDefaultValue=false)]
        public string Mrr { get; set; }
        /// <summary>
        /// Charge name. 
        /// </summary>
        /// <value>Charge name. </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Charge number. 
        /// </summary>
        /// <value>Charge number. </value>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public string Number { get; set; }
        /// <summary>
        /// Specifies the number of periods to use when calculating charges in an overage smoothing charge model. 
        /// </summary>
        /// <value>Specifies the number of periods to use when calculating charges in an overage smoothing charge model. </value>
        [DataMember(Name="numberOfPeriods", EmitDefaultValue=false)]
        public long? NumberOfPeriods { get; set; }
        /// <summary>
        /// The original ID of the rate plan charge. 
        /// </summary>
        /// <value>The original ID of the rate plan charge. </value>
        [DataMember(Name="originalChargeId", EmitDefaultValue=false)]
        public string OriginalChargeId { get; set; }
        /// <summary>
        /// Determines when to calculate overage charges. 
        /// </summary>
        /// <value>Determines when to calculate overage charges. </value>
        [DataMember(Name="overageCalculationOption", EmitDefaultValue=false)]
        public string OverageCalculationOption { get; set; }
        /// <summary>
        /// The price for units over the allowed amount. 
        /// </summary>
        /// <value>The price for units over the allowed amount. </value>
        [DataMember(Name="overagePrice", EmitDefaultValue=false)]
        public string OveragePrice { get; set; }
        /// <summary>
        /// Determines whether to credit the customer with unused units of usage. 
        /// </summary>
        /// <value>Determines whether to credit the customer with unused units of usage. </value>
        [DataMember(Name="overageUnusedUnitsCreditOption", EmitDefaultValue=false)]
        public string OverageUnusedUnitsCreditOption { get; set; }
        /// <summary>
        /// The price associated with the rate plan charge expressed as a decimal. 
        /// </summary>
        /// <value>The price associated with the rate plan charge expressed as a decimal. </value>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public string Price { get; set; }
        /// <summary>
        /// When the following is true:  1. AutomatedPriceChange setting is on  2. Charge type is not one-time  3. Charge model is not discount percentage  Then an automatic price change can have a value for when a termed subscription is renewed.   Values (one of the following):  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60; 
        /// </summary>
        /// <value>When the following is true:  1. AutomatedPriceChange setting is on  2. Charge type is not one-time  3. Charge model is not discount percentage  Then an automatic price change can have a value for when a termed subscription is renewed.   Values (one of the following):  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60; </value>
        [DataMember(Name="priceChangeOption", EmitDefaultValue=false)]
        public string PriceChangeOption { get; set; }
        /// <summary>
        /// A planned future price increase amount as a percentage. 
        /// </summary>
        /// <value>A planned future price increase amount as a percentage. </value>
        [DataMember(Name="priceIncreasePercentage", EmitDefaultValue=false)]
        public string PriceIncreasePercentage { get; set; }
        /// <summary>
        /// Concise description of rate plan charge model. 
        /// </summary>
        /// <value>Concise description of rate plan charge model. </value>
        [DataMember(Name="pricingSummary", EmitDefaultValue=false)]
        public string PricingSummary { get; set; }
        /// <summary>
        /// The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. 
        /// </summary>
        /// <value>The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. </value>
        [DataMember(Name="processedThroughDate", EmitDefaultValue=false)]
        public DateTime? ProcessedThroughDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="productRatePlanChargeId", EmitDefaultValue=false)]
        public string ProductRatePlanChargeId { get; set; }
        /// <summary>
        /// The quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. 
        /// </summary>
        /// <value>The quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. </value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public string Quantity { get; set; }
        /// <summary>
        /// Specifies a rating group based on which usage records are rated.   Possible values are:  * &#x60;ByBillingPeriod&#x60; (default) * &#x60;ByUsageStartDate&#x60; * &#x60;ByUsageRecord&#x60; * &#x60;ByUsageUpload&#x60;  **Note:** This field is only used for per unit, volume pricing, and tiered pricing charge models. Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). 
        /// </summary>
        /// <value>Specifies a rating group based on which usage records are rated.   Possible values are:  * &#x60;ByBillingPeriod&#x60; (default) * &#x60;ByUsageStartDate&#x60; * &#x60;ByUsageRecord&#x60; * &#x60;ByUsageUpload&#x60;  **Note:** This field is only used for per unit, volume pricing, and tiered pricing charge models. Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). </value>
        [DataMember(Name="ratingGroup", EmitDefaultValue=false)]
        public string RatingGroup { get; set; }
        /// <summary>
        /// The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. 
        /// </summary>
        /// <value>The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. </value>
        [DataMember(Name="segment", EmitDefaultValue=false)]
        public DateTime? Segment { get; set; }
        /// <summary>
        /// Specifies when revenue recognition begins. When charge model is &#x60;Overage&#x60; or &#x60;TieredWithOverage&#x60;, &#x60;smoothingModel&#x60; will be one of the following values:  * &#x60;ContractEffectiveDate&#x60; * &#x60;ServiceActivationDate&#x60; * &#x60;CustomerAcceptanceDate&#x60; 
        /// </summary>
        /// <value>Specifies when revenue recognition begins. When charge model is &#x60;Overage&#x60; or &#x60;TieredWithOverage&#x60;, &#x60;smoothingModel&#x60; will be one of the following values:  * &#x60;ContractEffectiveDate&#x60; * &#x60;ServiceActivationDate&#x60; * &#x60;CustomerAcceptanceDate&#x60; </value>
        [DataMember(Name="smoothingModel", EmitDefaultValue=false)]
        public string SmoothingModel { get; set; }
        /// <summary>
        /// Customizes the number of month or week for the charges billing period. This field is required if you set the value of the &#x60;BillingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;. 
        /// </summary>
        /// <value>Customizes the number of month or week for the charges billing period. This field is required if you set the value of the &#x60;BillingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;. </value>
        [DataMember(Name="specificBillingPeriod", EmitDefaultValue=false)]
        public long? SpecificBillingPeriod { get; set; }
        /// <summary>
        /// The specific date on which the charge ends. If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. 
        /// </summary>
        /// <value>The specific date on which the charge ends. If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. </value>
        [DataMember(Name="specificEndDate", EmitDefaultValue=false)]
        public DateTime? SpecificEndDate { get; set; }
        /// <summary>
        /// The total contract value. 
        /// </summary>
        /// <value>The total contract value. </value>
        [DataMember(Name="tcv", EmitDefaultValue=false)]
        public string Tcv { get; set; }
        /// <summary>
        /// One or many defined ranges with distinct pricing. 
        /// </summary>
        /// <value>One or many defined ranges with distinct pricing. </value>
        [DataMember(Name="tiers", EmitDefaultValue=false)]
        public List<GETTierType> Tiers { get; set; }
        /// <summary>
        /// The date that the rate plan charge will be triggered. 
        /// </summary>
        /// <value>The date that the rate plan charge will be triggered. </value>
        [DataMember(Name="triggerDate", EmitDefaultValue=false)]
        public DateTime? TriggerDate { get; set; }
        /// <summary>
        /// The event that will cause the rate plan charge to be triggered.  Possible values:   * &#x60;ContractEffective&#x60; * &#x60;ServiceActivation&#x60; * &#x60;CustomerAcceptance&#x60; * &#x60;SpecificDate&#x60; 
        /// </summary>
        /// <value>The event that will cause the rate plan charge to be triggered.  Possible values:   * &#x60;ContractEffective&#x60; * &#x60;ServiceActivation&#x60; * &#x60;CustomerAcceptance&#x60; * &#x60;SpecificDate&#x60; </value>
        [DataMember(Name="triggerEvent", EmitDefaultValue=false)]
        public string TriggerEvent { get; set; }
        /// <summary>
        /// Charge type. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. 
        /// </summary>
        /// <value>Charge type. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. </value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        /// Specifies the rate to credit a customer for unused units of usage. This field is applicable only for overage charge models when the  &#x60;OverageUnusedUnitsCreditOption&#x60; field value is &#x60;CreditBySpecificRate&#x60;. 
        /// </summary>
        /// <value>Specifies the rate to credit a customer for unused units of usage. This field is applicable only for overage charge models when the  &#x60;OverageUnusedUnitsCreditOption&#x60; field value is &#x60;CreditBySpecificRate&#x60;. </value>
        [DataMember(Name="unusedUnitsCreditRates", EmitDefaultValue=false)]
        public string UnusedUnitsCreditRates { get; set; }
        /// <summary>
        /// Specifies the units to measure usage.  
        /// </summary>
        /// <value>Specifies the units to measure usage.  </value>
        [DataMember(Name="uom", EmitDefaultValue=false)]
        public string Uom { get; set; }
        /// <summary>
        /// Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends.  If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value>Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends.  If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name="upToPeriods", EmitDefaultValue=false)]
        public string UpToPeriods { get; set; }
        /// <summary>
        /// The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60; 
        /// </summary>
        /// <value>The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60; </value>
        [DataMember(Name="upToPeriodsType", EmitDefaultValue=false)]
        public string UpToPeriodsType { get; set; }
        /// <summary>
        /// Determines how Zuora processes usage records for per-unit usage charges.  
        /// </summary>
        /// <value>Determines how Zuora processes usage records for per-unit usage charges.  </value>
        [DataMember(Name="usageRecordRatingOption", EmitDefaultValue=false)]
        public string UsageRecordRatingOption { get; set; }
        /// <summary>
        /// Rate plan charge revision number. 
        /// </summary>
        /// <value>Rate plan charge revision number. </value>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public long? Version { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GETSubscriptionRatePlanChargesType {\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillingDay: ").Append(BillingDay).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  ChargedThroughDate: ").Append(ChargedThroughDate).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountAmount: ").Append(DiscountAmount).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  DiscountPercentage: ").Append(DiscountPercentage).Append("\n");
            sb.Append("  Dmrc: ").Append(Dmrc).Append("\n");
            sb.Append("  Done: ").Append(Done).Append("\n");
            sb.Append("  Dtcv: ").Append(Dtcv).Append("\n");
            sb.Append("  EffectiveEndDate: ").Append(EffectiveEndDate).Append("\n");
            sb.Append("  EffectiveStartDate: ").Append(EffectiveStartDate).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Mrr: ").Append(Mrr).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  NumberOfPeriods: ").Append(NumberOfPeriods).Append("\n");
            sb.Append("  OriginalChargeId: ").Append(OriginalChargeId).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OveragePrice: ").Append(OveragePrice).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  PricingSummary: ").Append(PricingSummary).Append("\n");
            sb.Append("  ProcessedThroughDate: ").Append(ProcessedThroughDate).Append("\n");
            sb.Append("  ProductRatePlanChargeId: ").Append(ProductRatePlanChargeId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RatingGroup: ").Append(RatingGroup).Append("\n");
            sb.Append("  Segment: ").Append(Segment).Append("\n");
            sb.Append("  SmoothingModel: ").Append(SmoothingModel).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  SpecificEndDate: ").Append(SpecificEndDate).Append("\n");
            sb.Append("  Tcv: ").Append(Tcv).Append("\n");
            sb.Append("  Tiers: ").Append(Tiers).Append("\n");
            sb.Append("  TriggerDate: ").Append(TriggerDate).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UnusedUnitsCreditRates: ").Append(UnusedUnitsCreditRates).Append("\n");
            sb.Append("  Uom: ").Append(Uom).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UsageRecordRatingOption: ").Append(UsageRecordRatingOption).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
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
            return this.Equals(obj as GETSubscriptionRatePlanChargesType);
        }

        /// <summary>
        /// Returns true if GETSubscriptionRatePlanChargesType instances are equal
        /// </summary>
        /// <param name="other">Instance of GETSubscriptionRatePlanChargesType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETSubscriptionRatePlanChargesType other)
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
                    this.ChargedThroughDate == other.ChargedThroughDate ||
                    this.ChargedThroughDate != null &&
                    this.ChargedThroughDate.Equals(other.ChargedThroughDate)
                ) && 
                (
                    this.Currency == other.Currency ||
                    this.Currency != null &&
                    this.Currency.Equals(other.Currency)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.DiscountAmount == other.DiscountAmount ||
                    this.DiscountAmount != null &&
                    this.DiscountAmount.Equals(other.DiscountAmount)
                ) && 
                (
                    this.DiscountLevel == other.DiscountLevel ||
                    this.DiscountLevel != null &&
                    this.DiscountLevel.Equals(other.DiscountLevel)
                ) && 
                (
                    this.DiscountPercentage == other.DiscountPercentage ||
                    this.DiscountPercentage != null &&
                    this.DiscountPercentage.Equals(other.DiscountPercentage)
                ) && 
                (
                    this.Dmrc == other.Dmrc ||
                    this.Dmrc != null &&
                    this.Dmrc.Equals(other.Dmrc)
                ) && 
                (
                    this.Done == other.Done ||
                    this.Done != null &&
                    this.Done.Equals(other.Done)
                ) && 
                (
                    this.Dtcv == other.Dtcv ||
                    this.Dtcv != null &&
                    this.Dtcv.Equals(other.Dtcv)
                ) && 
                (
                    this.EffectiveEndDate == other.EffectiveEndDate ||
                    this.EffectiveEndDate != null &&
                    this.EffectiveEndDate.Equals(other.EffectiveEndDate)
                ) && 
                (
                    this.EffectiveStartDate == other.EffectiveStartDate ||
                    this.EffectiveStartDate != null &&
                    this.EffectiveStartDate.Equals(other.EffectiveStartDate)
                ) && 
                (
                    this.EndDateCondition == other.EndDateCondition ||
                    this.EndDateCondition != null &&
                    this.EndDateCondition.Equals(other.EndDateCondition)
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
                    this.Model == other.Model ||
                    this.Model != null &&
                    this.Model.Equals(other.Model)
                ) && 
                (
                    this.Mrr == other.Mrr ||
                    this.Mrr != null &&
                    this.Mrr.Equals(other.Mrr)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Number == other.Number ||
                    this.Number != null &&
                    this.Number.Equals(other.Number)
                ) && 
                (
                    this.NumberOfPeriods == other.NumberOfPeriods ||
                    this.NumberOfPeriods != null &&
                    this.NumberOfPeriods.Equals(other.NumberOfPeriods)
                ) && 
                (
                    this.OriginalChargeId == other.OriginalChargeId ||
                    this.OriginalChargeId != null &&
                    this.OriginalChargeId.Equals(other.OriginalChargeId)
                ) && 
                (
                    this.OverageCalculationOption == other.OverageCalculationOption ||
                    this.OverageCalculationOption != null &&
                    this.OverageCalculationOption.Equals(other.OverageCalculationOption)
                ) && 
                (
                    this.OveragePrice == other.OveragePrice ||
                    this.OveragePrice != null &&
                    this.OveragePrice.Equals(other.OveragePrice)
                ) && 
                (
                    this.OverageUnusedUnitsCreditOption == other.OverageUnusedUnitsCreditOption ||
                    this.OverageUnusedUnitsCreditOption != null &&
                    this.OverageUnusedUnitsCreditOption.Equals(other.OverageUnusedUnitsCreditOption)
                ) && 
                (
                    this.Price == other.Price ||
                    this.Price != null &&
                    this.Price.Equals(other.Price)
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
                    this.PricingSummary == other.PricingSummary ||
                    this.PricingSummary != null &&
                    this.PricingSummary.Equals(other.PricingSummary)
                ) && 
                (
                    this.ProcessedThroughDate == other.ProcessedThroughDate ||
                    this.ProcessedThroughDate != null &&
                    this.ProcessedThroughDate.Equals(other.ProcessedThroughDate)
                ) && 
                (
                    this.ProductRatePlanChargeId == other.ProductRatePlanChargeId ||
                    this.ProductRatePlanChargeId != null &&
                    this.ProductRatePlanChargeId.Equals(other.ProductRatePlanChargeId)
                ) && 
                (
                    this.Quantity == other.Quantity ||
                    this.Quantity != null &&
                    this.Quantity.Equals(other.Quantity)
                ) && 
                (
                    this.RatingGroup == other.RatingGroup ||
                    this.RatingGroup != null &&
                    this.RatingGroup.Equals(other.RatingGroup)
                ) && 
                (
                    this.Segment == other.Segment ||
                    this.Segment != null &&
                    this.Segment.Equals(other.Segment)
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
                    this.SpecificEndDate == other.SpecificEndDate ||
                    this.SpecificEndDate != null &&
                    this.SpecificEndDate.Equals(other.SpecificEndDate)
                ) && 
                (
                    this.Tcv == other.Tcv ||
                    this.Tcv != null &&
                    this.Tcv.Equals(other.Tcv)
                ) && 
                (
                    this.Tiers == other.Tiers ||
                    this.Tiers != null &&
                    this.Tiers.SequenceEqual(other.Tiers)
                ) && 
                (
                    this.TriggerDate == other.TriggerDate ||
                    this.TriggerDate != null &&
                    this.TriggerDate.Equals(other.TriggerDate)
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
                    this.UnusedUnitsCreditRates == other.UnusedUnitsCreditRates ||
                    this.UnusedUnitsCreditRates != null &&
                    this.UnusedUnitsCreditRates.Equals(other.UnusedUnitsCreditRates)
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
                    this.Version == other.Version ||
                    this.Version != null &&
                    this.Version.Equals(other.Version)
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
                if (this.ChargedThroughDate != null)
                    hash = hash * 59 + this.ChargedThroughDate.GetHashCode();
                if (this.Currency != null)
                    hash = hash * 59 + this.Currency.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.DiscountAmount != null)
                    hash = hash * 59 + this.DiscountAmount.GetHashCode();
                if (this.DiscountLevel != null)
                    hash = hash * 59 + this.DiscountLevel.GetHashCode();
                if (this.DiscountPercentage != null)
                    hash = hash * 59 + this.DiscountPercentage.GetHashCode();
                if (this.Dmrc != null)
                    hash = hash * 59 + this.Dmrc.GetHashCode();
                if (this.Done != null)
                    hash = hash * 59 + this.Done.GetHashCode();
                if (this.Dtcv != null)
                    hash = hash * 59 + this.Dtcv.GetHashCode();
                if (this.EffectiveEndDate != null)
                    hash = hash * 59 + this.EffectiveEndDate.GetHashCode();
                if (this.EffectiveStartDate != null)
                    hash = hash * 59 + this.EffectiveStartDate.GetHashCode();
                if (this.EndDateCondition != null)
                    hash = hash * 59 + this.EndDateCondition.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.IncludedUnits != null)
                    hash = hash * 59 + this.IncludedUnits.GetHashCode();
                if (this.ListPriceBase != null)
                    hash = hash * 59 + this.ListPriceBase.GetHashCode();
                if (this.Model != null)
                    hash = hash * 59 + this.Model.GetHashCode();
                if (this.Mrr != null)
                    hash = hash * 59 + this.Mrr.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Number != null)
                    hash = hash * 59 + this.Number.GetHashCode();
                if (this.NumberOfPeriods != null)
                    hash = hash * 59 + this.NumberOfPeriods.GetHashCode();
                if (this.OriginalChargeId != null)
                    hash = hash * 59 + this.OriginalChargeId.GetHashCode();
                if (this.OverageCalculationOption != null)
                    hash = hash * 59 + this.OverageCalculationOption.GetHashCode();
                if (this.OveragePrice != null)
                    hash = hash * 59 + this.OveragePrice.GetHashCode();
                if (this.OverageUnusedUnitsCreditOption != null)
                    hash = hash * 59 + this.OverageUnusedUnitsCreditOption.GetHashCode();
                if (this.Price != null)
                    hash = hash * 59 + this.Price.GetHashCode();
                if (this.PriceChangeOption != null)
                    hash = hash * 59 + this.PriceChangeOption.GetHashCode();
                if (this.PriceIncreasePercentage != null)
                    hash = hash * 59 + this.PriceIncreasePercentage.GetHashCode();
                if (this.PricingSummary != null)
                    hash = hash * 59 + this.PricingSummary.GetHashCode();
                if (this.ProcessedThroughDate != null)
                    hash = hash * 59 + this.ProcessedThroughDate.GetHashCode();
                if (this.ProductRatePlanChargeId != null)
                    hash = hash * 59 + this.ProductRatePlanChargeId.GetHashCode();
                if (this.Quantity != null)
                    hash = hash * 59 + this.Quantity.GetHashCode();
                if (this.RatingGroup != null)
                    hash = hash * 59 + this.RatingGroup.GetHashCode();
                if (this.Segment != null)
                    hash = hash * 59 + this.Segment.GetHashCode();
                if (this.SmoothingModel != null)
                    hash = hash * 59 + this.SmoothingModel.GetHashCode();
                if (this.SpecificBillingPeriod != null)
                    hash = hash * 59 + this.SpecificBillingPeriod.GetHashCode();
                if (this.SpecificEndDate != null)
                    hash = hash * 59 + this.SpecificEndDate.GetHashCode();
                if (this.Tcv != null)
                    hash = hash * 59 + this.Tcv.GetHashCode();
                if (this.Tiers != null)
                    hash = hash * 59 + this.Tiers.GetHashCode();
                if (this.TriggerDate != null)
                    hash = hash * 59 + this.TriggerDate.GetHashCode();
                if (this.TriggerEvent != null)
                    hash = hash * 59 + this.TriggerEvent.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.UnusedUnitsCreditRates != null)
                    hash = hash * 59 + this.UnusedUnitsCreditRates.GetHashCode();
                if (this.Uom != null)
                    hash = hash * 59 + this.Uom.GetHashCode();
                if (this.UpToPeriods != null)
                    hash = hash * 59 + this.UpToPeriods.GetHashCode();
                if (this.UpToPeriodsType != null)
                    hash = hash * 59 + this.UpToPeriodsType.GetHashCode();
                if (this.UsageRecordRatingOption != null)
                    hash = hash * 59 + this.UsageRecordRatingOption.GetHashCode();
                if (this.Version != null)
                    hash = hash * 59 + this.Version.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
