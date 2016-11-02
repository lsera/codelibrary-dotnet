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
    /// PUTScAddType
    /// </summary>
    [DataContract]
    public partial class PUTScAddType :  IEquatable<PUTScAddType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PUTScAddType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PUTScAddType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PUTScAddType" /> class.
        /// </summary>
        /// <param name="ApplyDiscountTo">Specifies the type of charges that you want a specific discount to apply to.  Values:  * &#x60;ONETIME&#x60; * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60;  Available for the following charge type for the Discount-Fixed Amount and Discount-Percentage charge models:  * Recurring .</param>
        /// <param name="BillCycleDay">Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed.  Values: &#x60;1&#x60;-&#x60;31&#x60;  Available for the following charge types:  * Recurring * Usage-based .</param>
        /// <param name="BillCycleType">Specifies how to determine the billing day for the charge. When this field is set to &#x60;SpecificDayOfMonth&#x60;, set the &#x60;BillCycleDay&#x60; field. When this field is set to &#x60;SpecificDayOfWeek&#x60;, set the &#x60;weeklyBillCycleDay&#x60; field.  Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayOfMonth&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayOfWeek&#x60;  Available for the following charge types:  * Recurring * Usage-based .</param>
        /// <param name="BillingPeriod">Billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values:  * &#x60;Month&#x60; * &#x60;Quarter&#x60; * &#x60;Semi_Annual&#x60; * &#x60;Annual&#x60; * &#x60;Eighteen_Months&#x60; * &#x60;Two_Years&#x60; * &#x60;Three_Years&#x60; * &#x60;Five_Years&#x60; * &#x60;Specific_Months&#x60; * &#x60;Subscription_Term&#x60; * &#x60;Week&#x60; * &#x60;Specific_Weeks&#x60;  Available for the following charge types:  * Recurring * Usage-based .</param>
        /// <param name="BillingPeriodAlignment">Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based .</param>
        /// <param name="BillingTiming">Billing timing for the charge for recurring charge types. Not avaliable for one time, usage and discount charges.  Values:  * &#x60;IN_ADVANCE&#x60; (default) * &#x60;IN_ARREARS&#x60; .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="Description">Description of the charge. .</param>
        /// <param name="DiscountAmount">Specifies the amount of fixed-amount discount.  Available for the following charge type for the Discount-Fixed Amount charge model:  * Recurring .</param>
        /// <param name="DiscountLevel">Specifies if the discount applies to the product rate plan only , the entire subscription, or to any activity in the account.  Values:  * &#x60;rateplan&#x60; * &#x60;subscription&#x60; * &#x60;account&#x60;  Available for the following charge type for the Discount-Fixed Amount and Discount-Percentage charge models:  * Recurring .</param>
        /// <param name="DiscountPercentage">Specifies the percentage of a percentage discount.   Available for the following charge type for the Discount-Percentage charge model:  * Recurring .</param>
        /// <param name="EndDateCondition">Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; .</param>
        /// <param name="IncludedUnits">Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;&#x60;0&#x60;.  Available for the following charge types for the Overage charge model:  * Recurring * Usage-based .</param>
        /// <param name="ListPriceBase">The list price base for the product rate plan charge.  Values:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60;  Available for the following charge type for the Flat Fee, Per Unit, Volume Pricing, and Tiered Pricing charge models:  * Recurring .</param>
        /// <param name="Number">Unique number that identifies the charge. System-generated if not provided. .</param>
        /// <param name="NumberOfPeriods">Specifies the number of periods to use when calculating charges in an overage smoothing charge model.  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based .</param>
        /// <param name="OveragePrice">Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based .</param>
        /// <param name="OverageUnusedUnitsCreditOption">Determines whether to credit the customer with unused units of usage.  Values:  * &#x60;NoCredit&#x60; * &#x60;CreditBySpecificRate&#x60;  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based .</param>
        /// <param name="Price">Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models .</param>
        /// <param name="PriceChangeOption">Applies an automatic price change when a termed subscription is renewed. The Z-Billing Admin setting Enable Automatic Price Change When Subscriptions are Renewed?  must be set to Yes to use this field.  See Define Default Subscription Settings for more information on setting this option.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based * Not available for the Fixed-Amount Discount charge model. .</param>
        /// <param name="PriceIncreasePercentage">Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between -100 and 100.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. .</param>
        /// <param name="ProductRatePlanChargeId"> (required).</param>
        /// <param name="Quantity">Number of units. Must be &gt;&#x3D;&#x60;0&#x60;.  Available for the following charge types for the Per Unit, Volume Pricing, and Tiered Pricing charge models:  * One-time * Recurring .</param>
        /// <param name="RatingGroup">Specifies a rating group based on which usage records are rated. See [Usages Rating by Group](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/Usage/Usage_Rating_by_Group) for more information.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  Values:  * &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period.        * &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  * &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. * &#x60;ByUsageUpload&#x60;: The rating is based on all the usages in a uploaded usage file (.xls or .csv).  The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models. The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models. Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. .</param>
        /// <param name="SpecificBillingPeriod">Specifies the number of month or week for the charges billing period. Required if you set the value of the &#x60;billingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;.  Available for the following charge types:  * Recurring * Usage-based .</param>
        /// <param name="SpecificEndDate">Defines when the charge ends after the charge trigger date.  This field is only applicable when the &#x60;endDateCondition&#x60; field is set to &#x60;Specific_End_Date&#x60;.  If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. .</param>
        /// <param name="Tiers">Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based .</param>
        /// <param name="TriggerDate">Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to &#x60;USD&#x60;. .</param>
        /// <param name="TriggerEvent">Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60; .</param>
        /// <param name="UnusedUnitsCreditRates">Specifies the rate to credit a customer for unused units of usage. This field applies only for overage charge models when the &#x60;OverageUnusedUnitsCreditOption&#x60; field is set to &#x60;CreditBySpecificRate&#x60;.  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based .</param>
        /// <param name="UpToPeriods">The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60;  You must use this field together with the &#x60;upToPeriods&#x60; field to specify the time period.  This field is applicable only when the &#x60;endDateCondition&#x60; field is set to &#x60;Fixed_Period&#x60;.  .</param>
        /// <param name="UpToPeriodsType">The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60;  You must use this field together with the &#x60;upToPeriods&#x60; field to specify the time period.  This field is applicable only when the &#x60;endDateCondition&#x60; field is set to &#x60;Fixed_Period&#x60;.  .</param>
        public PUTScAddType(string ApplyDiscountTo = null, string BillCycleDay = null, string BillCycleType = null, string BillingPeriod = null, string BillingPeriodAlignment = null, string BillingTiming = null, string CustomFieldC = null, string Description = null, string DiscountAmount = null, string DiscountLevel = null, string DiscountPercentage = null, string EndDateCondition = null, string IncludedUnits = null, string ListPriceBase = null, string Number = null, long? NumberOfPeriods = null, string OveragePrice = null, string OverageUnusedUnitsCreditOption = null, string Price = null, string PriceChangeOption = null, string PriceIncreasePercentage = null, string ProductRatePlanChargeId = null, string Quantity = null, string RatingGroup = null, long? SpecificBillingPeriod = null, DateTime? SpecificEndDate = null, List<POSTTierType> Tiers = null, DateTime? TriggerDate = null, string TriggerEvent = null, string UnusedUnitsCreditRates = null, long? UpToPeriods = null, string UpToPeriodsType = null)
        {
            // to ensure "ProductRatePlanChargeId" is required (not null)
            if (ProductRatePlanChargeId == null)
            {
                throw new InvalidDataException("ProductRatePlanChargeId is a required property for PUTScAddType and cannot be null");
            }
            else
            {
                this.ProductRatePlanChargeId = ProductRatePlanChargeId;
            }
            this.ApplyDiscountTo = ApplyDiscountTo;
            this.BillCycleDay = BillCycleDay;
            this.BillCycleType = BillCycleType;
            this.BillingPeriod = BillingPeriod;
            this.BillingPeriodAlignment = BillingPeriodAlignment;
            this.BillingTiming = BillingTiming;
            this.CustomFieldC = CustomFieldC;
            this.Description = Description;
            this.DiscountAmount = DiscountAmount;
            this.DiscountLevel = DiscountLevel;
            this.DiscountPercentage = DiscountPercentage;
            this.EndDateCondition = EndDateCondition;
            this.IncludedUnits = IncludedUnits;
            this.ListPriceBase = ListPriceBase;
            this.Number = Number;
            this.NumberOfPeriods = NumberOfPeriods;
            this.OveragePrice = OveragePrice;
            this.OverageUnusedUnitsCreditOption = OverageUnusedUnitsCreditOption;
            this.Price = Price;
            this.PriceChangeOption = PriceChangeOption;
            this.PriceIncreasePercentage = PriceIncreasePercentage;
            this.Quantity = Quantity;
            this.RatingGroup = RatingGroup;
            this.SpecificBillingPeriod = SpecificBillingPeriod;
            this.SpecificEndDate = SpecificEndDate;
            this.Tiers = Tiers;
            this.TriggerDate = TriggerDate;
            this.TriggerEvent = TriggerEvent;
            this.UnusedUnitsCreditRates = UnusedUnitsCreditRates;
            this.UpToPeriods = UpToPeriods;
            this.UpToPeriodsType = UpToPeriodsType;
        }
        
        /// <summary>
        /// Specifies the type of charges that you want a specific discount to apply to.  Values:  * &#x60;ONETIME&#x60; * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60;  Available for the following charge type for the Discount-Fixed Amount and Discount-Percentage charge models:  * Recurring 
        /// </summary>
        /// <value>Specifies the type of charges that you want a specific discount to apply to.  Values:  * &#x60;ONETIME&#x60; * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60;  Available for the following charge type for the Discount-Fixed Amount and Discount-Percentage charge models:  * Recurring </value>
        [DataMember(Name="applyDiscountTo", EmitDefaultValue=false)]
        public string ApplyDiscountTo { get; set; }
        /// <summary>
        /// Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed.  Values: &#x60;1&#x60;-&#x60;31&#x60;  Available for the following charge types:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed.  Values: &#x60;1&#x60;-&#x60;31&#x60;  Available for the following charge types:  * Recurring * Usage-based </value>
        [DataMember(Name="billCycleDay", EmitDefaultValue=false)]
        public string BillCycleDay { get; set; }
        /// <summary>
        /// Specifies how to determine the billing day for the charge. When this field is set to &#x60;SpecificDayOfMonth&#x60;, set the &#x60;BillCycleDay&#x60; field. When this field is set to &#x60;SpecificDayOfWeek&#x60;, set the &#x60;weeklyBillCycleDay&#x60; field.  Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayOfMonth&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayOfWeek&#x60;  Available for the following charge types:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Specifies how to determine the billing day for the charge. When this field is set to &#x60;SpecificDayOfMonth&#x60;, set the &#x60;BillCycleDay&#x60; field. When this field is set to &#x60;SpecificDayOfWeek&#x60;, set the &#x60;weeklyBillCycleDay&#x60; field.  Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayOfMonth&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayOfWeek&#x60;  Available for the following charge types:  * Recurring * Usage-based </value>
        [DataMember(Name="billCycleType", EmitDefaultValue=false)]
        public string BillCycleType { get; set; }
        /// <summary>
        /// Billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values:  * &#x60;Month&#x60; * &#x60;Quarter&#x60; * &#x60;Semi_Annual&#x60; * &#x60;Annual&#x60; * &#x60;Eighteen_Months&#x60; * &#x60;Two_Years&#x60; * &#x60;Three_Years&#x60; * &#x60;Five_Years&#x60; * &#x60;Specific_Months&#x60; * &#x60;Subscription_Term&#x60; * &#x60;Week&#x60; * &#x60;Specific_Weeks&#x60;  Available for the following charge types:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD).  Values:  * &#x60;Month&#x60; * &#x60;Quarter&#x60; * &#x60;Semi_Annual&#x60; * &#x60;Annual&#x60; * &#x60;Eighteen_Months&#x60; * &#x60;Two_Years&#x60; * &#x60;Three_Years&#x60; * &#x60;Five_Years&#x60; * &#x60;Specific_Months&#x60; * &#x60;Subscription_Term&#x60; * &#x60;Week&#x60; * &#x60;Specific_Weeks&#x60;  Available for the following charge types:  * Recurring * Usage-based </value>
        [DataMember(Name="billingPeriod", EmitDefaultValue=false)]
        public string BillingPeriod { get; set; }
        /// <summary>
        /// Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Aligns charges within the same subscription if multiple charges begin on different dates.  Values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60;  Available for the following charge types:  * Recurring * Usage-based </value>
        [DataMember(Name="billingPeriodAlignment", EmitDefaultValue=false)]
        public string BillingPeriodAlignment { get; set; }
        /// <summary>
        /// Billing timing for the charge for recurring charge types. Not avaliable for one time, usage and discount charges.  Values:  * &#x60;IN_ADVANCE&#x60; (default) * &#x60;IN_ARREARS&#x60; 
        /// </summary>
        /// <value>Billing timing for the charge for recurring charge types. Not avaliable for one time, usage and discount charges.  Values:  * &#x60;IN_ADVANCE&#x60; (default) * &#x60;IN_ARREARS&#x60; </value>
        [DataMember(Name="billingTiming", EmitDefaultValue=false)]
        public string BillingTiming { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// Description of the charge. 
        /// </summary>
        /// <value>Description of the charge. </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Specifies the amount of fixed-amount discount.  Available for the following charge type for the Discount-Fixed Amount charge model:  * Recurring 
        /// </summary>
        /// <value>Specifies the amount of fixed-amount discount.  Available for the following charge type for the Discount-Fixed Amount charge model:  * Recurring </value>
        [DataMember(Name="discountAmount", EmitDefaultValue=false)]
        public string DiscountAmount { get; set; }
        /// <summary>
        /// Specifies if the discount applies to the product rate plan only , the entire subscription, or to any activity in the account.  Values:  * &#x60;rateplan&#x60; * &#x60;subscription&#x60; * &#x60;account&#x60;  Available for the following charge type for the Discount-Fixed Amount and Discount-Percentage charge models:  * Recurring 
        /// </summary>
        /// <value>Specifies if the discount applies to the product rate plan only , the entire subscription, or to any activity in the account.  Values:  * &#x60;rateplan&#x60; * &#x60;subscription&#x60; * &#x60;account&#x60;  Available for the following charge type for the Discount-Fixed Amount and Discount-Percentage charge models:  * Recurring </value>
        [DataMember(Name="discountLevel", EmitDefaultValue=false)]
        public string DiscountLevel { get; set; }
        /// <summary>
        /// Specifies the percentage of a percentage discount.   Available for the following charge type for the Discount-Percentage charge model:  * Recurring 
        /// </summary>
        /// <value>Specifies the percentage of a percentage discount.   Available for the following charge type for the Discount-Percentage charge model:  * Recurring </value>
        [DataMember(Name="discountPercentage", EmitDefaultValue=false)]
        public string DiscountPercentage { get; set; }
        /// <summary>
        /// Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; 
        /// </summary>
        /// <value>Defines when the charge ends after the charge trigger date. If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; </value>
        [DataMember(Name="endDateCondition", EmitDefaultValue=false)]
        public string EndDateCondition { get; set; }
        /// <summary>
        /// Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;&#x60;0&#x60;.  Available for the following charge types for the Overage charge model:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units for this charge. Must be &gt;&#x3D;&#x60;0&#x60;.  Available for the following charge types for the Overage charge model:  * Recurring * Usage-based </value>
        [DataMember(Name="includedUnits", EmitDefaultValue=false)]
        public string IncludedUnits { get; set; }
        /// <summary>
        /// The list price base for the product rate plan charge.  Values:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60;  Available for the following charge type for the Flat Fee, Per Unit, Volume Pricing, and Tiered Pricing charge models:  * Recurring 
        /// </summary>
        /// <value>The list price base for the product rate plan charge.  Values:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60;  Available for the following charge type for the Flat Fee, Per Unit, Volume Pricing, and Tiered Pricing charge models:  * Recurring </value>
        [DataMember(Name="listPriceBase", EmitDefaultValue=false)]
        public string ListPriceBase { get; set; }
        /// <summary>
        /// Unique number that identifies the charge. System-generated if not provided. 
        /// </summary>
        /// <value>Unique number that identifies the charge. System-generated if not provided. </value>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public string Number { get; set; }
        /// <summary>
        /// Specifies the number of periods to use when calculating charges in an overage smoothing charge model.  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based 
        /// </summary>
        /// <value>Specifies the number of periods to use when calculating charges in an overage smoothing charge model.  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based </value>
        [DataMember(Name="numberOfPeriods", EmitDefaultValue=false)]
        public long? NumberOfPeriods { get; set; }
        /// <summary>
        /// Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based 
        /// </summary>
        /// <value>Price for units over the allowed amount.   Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based </value>
        [DataMember(Name="overagePrice", EmitDefaultValue=false)]
        public string OveragePrice { get; set; }
        /// <summary>
        /// Determines whether to credit the customer with unused units of usage.  Values:  * &#x60;NoCredit&#x60; * &#x60;CreditBySpecificRate&#x60;  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based 
        /// </summary>
        /// <value>Determines whether to credit the customer with unused units of usage.  Values:  * &#x60;NoCredit&#x60; * &#x60;CreditBySpecificRate&#x60;  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based </value>
        [DataMember(Name="overageUnusedUnitsCreditOption", EmitDefaultValue=false)]
        public string OverageUnusedUnitsCreditOption { get; set; }
        /// <summary>
        /// Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models 
        /// </summary>
        /// <value>Price for units in the subscription rate plan.  Supports all charge types for the Flat Fee and Per Unit charge models </value>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public string Price { get; set; }
        /// <summary>
        /// Applies an automatic price change when a termed subscription is renewed. The Z-Billing Admin setting Enable Automatic Price Change When Subscriptions are Renewed?  must be set to Yes to use this field.  See Define Default Subscription Settings for more information on setting this option.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based * Not available for the Fixed-Amount Discount charge model. 
        /// </summary>
        /// <value>Applies an automatic price change when a termed subscription is renewed. The Z-Billing Admin setting Enable Automatic Price Change When Subscriptions are Renewed?  must be set to Yes to use this field.  See Define Default Subscription Settings for more information on setting this option.  Values:  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60;  Available for the following charge types:  * Recurring * Usage-based * Not available for the Fixed-Amount Discount charge model. </value>
        [DataMember(Name="priceChangeOption", EmitDefaultValue=false)]
        public string PriceChangeOption { get; set; }
        /// <summary>
        /// Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between -100 and 100.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. 
        /// </summary>
        /// <value>Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Required if you set the &#x60;PriceChangeOption&#x60; field to &#x60;SpecificPercentageValue&#x60;.  Decimal between -100 and 100.  Available for the following charge types:  * Recurring * Usage-based  Not available for the Fixed-Amount Discount charge model. </value>
        [DataMember(Name="priceIncreasePercentage", EmitDefaultValue=false)]
        public string PriceIncreasePercentage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="productRatePlanChargeId", EmitDefaultValue=false)]
        public string ProductRatePlanChargeId { get; set; }
        /// <summary>
        /// Number of units. Must be &gt;&#x3D;&#x60;0&#x60;.  Available for the following charge types for the Per Unit, Volume Pricing, and Tiered Pricing charge models:  * One-time * Recurring 
        /// </summary>
        /// <value>Number of units. Must be &gt;&#x3D;&#x60;0&#x60;.  Available for the following charge types for the Per Unit, Volume Pricing, and Tiered Pricing charge models:  * One-time * Recurring </value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public string Quantity { get; set; }
        /// <summary>
        /// Specifies a rating group based on which usage records are rated. See [Usages Rating by Group](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/Usage/Usage_Rating_by_Group) for more information.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  Values:  * &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period.        * &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  * &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. * &#x60;ByUsageUpload&#x60;: The rating is based on all the usages in a uploaded usage file (.xls or .csv).  The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models. The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models. Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. 
        /// </summary>
        /// <value>Specifies a rating group based on which usage records are rated. See [Usages Rating by Group](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/Usage/Usage_Rating_by_Group) for more information.  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  Values:  * &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period.        * &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  * &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. * &#x60;ByUsageUpload&#x60;: The rating is based on all the usages in a uploaded usage file (.xls or .csv).  The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models. The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models. Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. </value>
        [DataMember(Name="ratingGroup", EmitDefaultValue=false)]
        public string RatingGroup { get; set; }
        /// <summary>
        /// Specifies the number of month or week for the charges billing period. Required if you set the value of the &#x60;billingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;.  Available for the following charge types:  * Recurring * Usage-based 
        /// </summary>
        /// <value>Specifies the number of month or week for the charges billing period. Required if you set the value of the &#x60;billingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;.  Available for the following charge types:  * Recurring * Usage-based </value>
        [DataMember(Name="specificBillingPeriod", EmitDefaultValue=false)]
        public long? SpecificBillingPeriod { get; set; }
        /// <summary>
        /// Defines when the charge ends after the charge trigger date.  This field is only applicable when the &#x60;endDateCondition&#x60; field is set to &#x60;Specific_End_Date&#x60;.  If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. 
        /// </summary>
        /// <value>Defines when the charge ends after the charge trigger date.  This field is only applicable when the &#x60;endDateCondition&#x60; field is set to &#x60;Specific_End_Date&#x60;.  If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. </value>
        [DataMember(Name="specificEndDate", EmitDefaultValue=false)]
        public DateTime? SpecificEndDate { get; set; }
        /// <summary>
        /// Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based 
        /// </summary>
        /// <value>Container for Volume, Tiered or Tiered with Overage charge models. Supports the following charge types:  * One-time * Recurring * Usage-based </value>
        [DataMember(Name="tiers", EmitDefaultValue=false)]
        public List<POSTTierType> Tiers { get; set; }
        /// <summary>
        /// Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to &#x60;USD&#x60;. 
        /// </summary>
        /// <value>Specifies when to start billing the customer for the charge. Required if the &#x60;triggerEvent&#x60; field is set to &#x60;USD&#x60;. </value>
        [DataMember(Name="triggerDate", EmitDefaultValue=false)]
        public DateTime? TriggerDate { get; set; }
        /// <summary>
        /// Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60; 
        /// </summary>
        /// <value>Specifies when to start billing the customer for the charge.  Values:  * &#x60;UCE&#x60; * &#x60;USA&#x60; * &#x60;UCA&#x60; * &#x60;USD&#x60; </value>
        [DataMember(Name="triggerEvent", EmitDefaultValue=false)]
        public string TriggerEvent { get; set; }
        /// <summary>
        /// Specifies the rate to credit a customer for unused units of usage. This field applies only for overage charge models when the &#x60;OverageUnusedUnitsCreditOption&#x60; field is set to &#x60;CreditBySpecificRate&#x60;.  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based 
        /// </summary>
        /// <value>Specifies the rate to credit a customer for unused units of usage. This field applies only for overage charge models when the &#x60;OverageUnusedUnitsCreditOption&#x60; field is set to &#x60;CreditBySpecificRate&#x60;.  Available for the following charge type for the Overage and Tiered with Overage charge models:  * Usage-based </value>
        [DataMember(Name="unusedUnitsCreditRates", EmitDefaultValue=false)]
        public string UnusedUnitsCreditRates { get; set; }
        /// <summary>
        /// The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60;  You must use this field together with the &#x60;upToPeriods&#x60; field to specify the time period.  This field is applicable only when the &#x60;endDateCondition&#x60; field is set to &#x60;Fixed_Period&#x60;.  
        /// </summary>
        /// <value>The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60;  You must use this field together with the &#x60;upToPeriods&#x60; field to specify the time period.  This field is applicable only when the &#x60;endDateCondition&#x60; field is set to &#x60;Fixed_Period&#x60;.  </value>
        [DataMember(Name="upToPeriods", EmitDefaultValue=false)]
        public long? UpToPeriods { get; set; }
        /// <summary>
        /// The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60;  You must use this field together with the &#x60;upToPeriods&#x60; field to specify the time period.  This field is applicable only when the &#x60;endDateCondition&#x60; field is set to &#x60;Fixed_Period&#x60;.  
        /// </summary>
        /// <value>The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60;  You must use this field together with the &#x60;upToPeriods&#x60; field to specify the time period.  This field is applicable only when the &#x60;endDateCondition&#x60; field is set to &#x60;Fixed_Period&#x60;.  </value>
        [DataMember(Name="upToPeriodsType", EmitDefaultValue=false)]
        public string UpToPeriodsType { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PUTScAddType {\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillCycleDay: ").Append(BillCycleDay).Append("\n");
            sb.Append("  BillCycleType: ").Append(BillCycleType).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountAmount: ").Append(DiscountAmount).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  DiscountPercentage: ").Append(DiscountPercentage).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  NumberOfPeriods: ").Append(NumberOfPeriods).Append("\n");
            sb.Append("  OveragePrice: ").Append(OveragePrice).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  ProductRatePlanChargeId: ").Append(ProductRatePlanChargeId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RatingGroup: ").Append(RatingGroup).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  SpecificEndDate: ").Append(SpecificEndDate).Append("\n");
            sb.Append("  Tiers: ").Append(Tiers).Append("\n");
            sb.Append("  TriggerDate: ").Append(TriggerDate).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  UnusedUnitsCreditRates: ").Append(UnusedUnitsCreditRates).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
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
            return this.Equals(obj as PUTScAddType);
        }

        /// <summary>
        /// Returns true if PUTScAddType instances are equal
        /// </summary>
        /// <param name="other">Instance of PUTScAddType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PUTScAddType other)
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
                    this.BillCycleDay == other.BillCycleDay ||
                    this.BillCycleDay != null &&
                    this.BillCycleDay.Equals(other.BillCycleDay)
                ) && 
                (
                    this.BillCycleType == other.BillCycleType ||
                    this.BillCycleType != null &&
                    this.BillCycleType.Equals(other.BillCycleType)
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
                    this.EndDateCondition == other.EndDateCondition ||
                    this.EndDateCondition != null &&
                    this.EndDateCondition.Equals(other.EndDateCondition)
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
                    this.UnusedUnitsCreditRates == other.UnusedUnitsCreditRates ||
                    this.UnusedUnitsCreditRates != null &&
                    this.UnusedUnitsCreditRates.Equals(other.UnusedUnitsCreditRates)
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
                if (this.BillCycleDay != null)
                    hash = hash * 59 + this.BillCycleDay.GetHashCode();
                if (this.BillCycleType != null)
                    hash = hash * 59 + this.BillCycleType.GetHashCode();
                if (this.BillingPeriod != null)
                    hash = hash * 59 + this.BillingPeriod.GetHashCode();
                if (this.BillingPeriodAlignment != null)
                    hash = hash * 59 + this.BillingPeriodAlignment.GetHashCode();
                if (this.BillingTiming != null)
                    hash = hash * 59 + this.BillingTiming.GetHashCode();
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
                if (this.EndDateCondition != null)
                    hash = hash * 59 + this.EndDateCondition.GetHashCode();
                if (this.IncludedUnits != null)
                    hash = hash * 59 + this.IncludedUnits.GetHashCode();
                if (this.ListPriceBase != null)
                    hash = hash * 59 + this.ListPriceBase.GetHashCode();
                if (this.Number != null)
                    hash = hash * 59 + this.Number.GetHashCode();
                if (this.NumberOfPeriods != null)
                    hash = hash * 59 + this.NumberOfPeriods.GetHashCode();
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
                if (this.ProductRatePlanChargeId != null)
                    hash = hash * 59 + this.ProductRatePlanChargeId.GetHashCode();
                if (this.Quantity != null)
                    hash = hash * 59 + this.Quantity.GetHashCode();
                if (this.RatingGroup != null)
                    hash = hash * 59 + this.RatingGroup.GetHashCode();
                if (this.SpecificBillingPeriod != null)
                    hash = hash * 59 + this.SpecificBillingPeriod.GetHashCode();
                if (this.SpecificEndDate != null)
                    hash = hash * 59 + this.SpecificEndDate.GetHashCode();
                if (this.Tiers != null)
                    hash = hash * 59 + this.Tiers.GetHashCode();
                if (this.TriggerDate != null)
                    hash = hash * 59 + this.TriggerDate.GetHashCode();
                if (this.TriggerEvent != null)
                    hash = hash * 59 + this.TriggerEvent.GetHashCode();
                if (this.UnusedUnitsCreditRates != null)
                    hash = hash * 59 + this.UnusedUnitsCreditRates.GetHashCode();
                if (this.UpToPeriods != null)
                    hash = hash * 59 + this.UpToPeriods.GetHashCode();
                if (this.UpToPeriodsType != null)
                    hash = hash * 59 + this.UpToPeriodsType.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
