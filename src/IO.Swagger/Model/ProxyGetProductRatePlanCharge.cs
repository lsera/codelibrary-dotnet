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
    /// ProxyGetProductRatePlanCharge
    /// </summary>
    [DataContract]
    public partial class ProxyGetProductRatePlanCharge :  IEquatable<ProxyGetProductRatePlanCharge>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetProductRatePlanCharge" /> class.
        /// </summary>
        /// <param name="AccountingCode">The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts .</param>
        /// <param name="ApplyDiscountTo">Specifies the type of charges that you want a specific discount to apply to. All field values are case sensitive: note that these values are in all-caps. **Character limit**: 21 **Values**: one of the following:  - &#x60;ONETIME (1)&#x60; - &#x60;RECURRING (2)&#x60; - &#x60;USAGE (4)&#x60; - &#x60;ONETIMERECURRING (3)&#x60; - &#x60;ONETIMEUSAGE (5)&#x60; - &#x60;RECURRINGUSAGE (6)&#x60; - &#x60;ONETIMERECURRINGUSAGE (7)&#x60; .</param>
        /// <param name="BillCycleDay"> Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed. The BCD value in the account can override the BCD in this object. **Character limit**: 2 **Values**: a valid BCD integer, 1 - 31 .</param>
        /// <param name="BillCycleType"> Specifies how to determine the billing day for the charge. **Character limit**: 20 **Values**: one of the following:  - &#x60;DefaultFromCustomer&#x60; - &#x60;SpecificDayofMonth:&#x60; - &#x60;SubscriptionStartDay&#x60; - &#x60;ChargeTriggerDay&#x60; - &#x60;SpecificDayofWeek&#x60; **Note**:  - If you set this field to &#x60;SpecificDayofMonth&#x60;, you must specify which day of the month as the billing day for the charge in the BillCycleDay field. - If you set this field to &#x60;SpecificDayofWeek&#x60;, you must specify which day of the week as the billing day for the charge in the WeeklyBillCycleDay field. .</param>
        /// <param name="BillingPeriod"> The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD). **Character limit**: 15 **Values**: one of the following  - &#x60;Month&#x60; - &#x60;Quarter&#x60; - &#x60;Annual&#x60; - &#x60;Semi-Annual&#x60; - &#x60;Specific Months&#x60; - &#x60;Subscription Term&#x60; (This value is in **Limited Availability**.) - &#x60;Week&#x60; - &#x60;Specific Weeks&#x60; **Note**: Specify the number of months or weeks in the SpecificBillingPeriod field if you set this field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. .</param>
        /// <param name="BillingPeriodAlignment"> Aligns charges within the same subscription if multiple charges begin on different dates. **Character limit**: 24 **Values**: one of the following:  - &#x60;AlignToCharge&#x60; - &#x60;AlignToSubscriptionStart&#x60; - &#x60;AlignToTermStart&#x60; .</param>
        /// <param name="BillingTiming"> The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - &#x60;In Advance&#x60; - &#x60;In Arrears&#x60;  This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="ChargeModel"> Determines how to calculate charges. Charge models must be individually activated in Z-Billing administration. **Character limit**: 27 **Values**: one of the following:  - &#x60;Discount-Fixed Amount&#x60; - &#x60;Discount-Percentage&#x60; - &#x60;Flat Fee Pricing&#x60; - &#x60;Per Unit Pricing&#x60; - &#x60;Overage Pricing&#x60; - &#x60;Tiered Pricing&#x60; - &#x60;Tiered with Overage Pricing&#x60; - &#x60;Volume Pricing&#x60; .</param>
        /// <param name="ChargeType"> Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; .</param>
        /// <param name="CreatedById">The ID of the Zuora user who created the &#x60;ProductRatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date when the  &#x60;ProductRatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="DefaultQuantity"> The default quantity of units, such as the number of authors in a hosted wiki service. This field is required if you use a per-unit pricing model. **Character limit**: 16 **Values**: a valid quantity value .</param>
        /// <param name="DeferredRevenueAccount"> The name of the deferred revenue account for this charge. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="Description">A description of the charge. **Character limit**: 500 **Values**: a string of 500 characters or fewer .</param>
        /// <param name="DiscountLevel"> Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: one of the following:  - &#x60;rateplan&#x60; - &#x60;subscription&#x60;, &#x60;account&#x60; .</param>
        /// <param name="EndDateCondition"> Defines when the charge ends after the charge trigger date. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after a specified period based on the trigger date of the charge. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="IncludedUnits">Specifies the number of units in the base set of units. **Character limit**: 16 **Values**: a positive decimal value .</param>
        /// <param name="LegacyRevenueReporting">.</param>
        /// <param name="ListPriceBase">The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; .</param>
        /// <param name="MaxQuantity"> Specifies the maximum number of units for this charge. Use this field and the &#x60;MinQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value .</param>
        /// <param name="MinQuantity">Specifies the minimum number of units for this charge. Use this field and the &#x60;MaxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value .</param>
        /// <param name="Name">The name of the product rate plan charge. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="NumberOfPeriod">Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: **Values**: a positive whole number .</param>
        /// <param name="OverageCalculationOption">Determines when to calculate overage charges. If the value of the SmoothingMode field is not specified, the value of this field is ignored. **Character limit**: 20 **Values**: one of the following:  - &#x60;EndOfSmoothingPeriod&#x60;: This option is used by default. The overage is charged at the end of the smoothing period. - &#x60;PerBillingPeriod&#x60;: The overage is charged on-demand rather than waiting until the end of the smoothing period. .</param>
        /// <param name="OverageUnusedUnitsCreditOption"> Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: one of the following:  - &#x60;NoCredit&#x60; - &#x60;CreditBySpecificRate&#x60; .</param>
        /// <param name="PriceChangeOption"> Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; .</param>
        /// <param name="PriceIncreasePercentage"> Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the [&#x60;PriceChangeOption&#x60;](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/ProductRatePlanCharge#PriceIncreaseOption) value to &#x60;SpecificPercentageValue&#x60;. **Character limit**: 16 **Values**: a decimal value between -100 and 100 .</param>
        /// <param name="ProductRatePlanId"> The ID of the product rate plan associated with this product rate plan charge. **Character limit**: 32 **Values**: a valid product rate plan ID .</param>
        /// <param name="RecognizedRevenueAccount"> The name of the recognized revenue account for this charge.  - Required when the Allow Blank Accounting Code setting is No. - Optional when the Allow Blank Accounting Code setting is Yes. Navigate to **Z-Finance Settings &gt; Configure Accounting Rules** to check this setting. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="RevRecCode">Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code .</param>
        /// <param name="RevRecTriggerCondition"> Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  - &#x60;ContractEffectiveDate&#x60; - &#x60;ServiceActivationDate&#x60; - &#x60;CustomerAcceptanceDate&#x60; .</param>
        /// <param name="RevenueRecognitionRuleName">Determines when to recognize the revenue for this charge. **Character limit**: 25 **Values**: one of the following:  - &#x60;Recognize upon invoicing&#x60; - &#x60;Recognize daily over time&#x60; .</param>
        /// <param name="SmoothingModel"> Specifies the smoothing model for an overage smoothing charge model. **Character limit**: 22 **Values**: one of the following:  - &#x60;RollingWindow&#x60; - &#x60;Rollover&#x60; .</param>
        /// <param name="SpecificBillingPeriod"> Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Values**: a positive integer .</param>
        /// <param name="TaxCode"> Specifies the tax code for taxation rules. Required when the Taxable field is set to &#x60;True&#x60;. **Character limit**: 64 **Values**: a valid tax code .</param>
        /// <param name="TaxMode"> Determines how to define taxation for the charge. Required when the Taxable field is set to &#x60;True&#x60;. **Character limit**: 12 **Values**: one of the following:  - &#x60;TaxExclusive&#x60; - &#x60;TaxInclusive&#x60; .</param>
        /// <param name="Taxable"> Determines whether the charge is taxable. When set to &#x60;True&#x60;, the TaxMode and TaxCode fields are required when creating or updating th ProductRatePlanCharge object. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; .</param>
        /// <param name="TriggerEvent"> Specifies when to start billing the customer for the charge. **Character limit**: 18 **Values**: one of the following:  - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription. .</param>
        /// <param name="UOM"> Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings**. **Character limit**: 25 **Values**: a configured unit of measure **Note**: You must specify this field when creating the following charge models:  - Per Unit Pricing - Volume Pricing - Overage Pricing - Tiered Pricing - Tiered with Overage Pricing .</param>
        /// <param name="UpToPeriods"> Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: a whole number between 0 and 65535, exclusive **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="UpToPeriodsType"> The period type used to define when the charge ends. **Character limit**: - - **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - Years **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. .</param>
        /// <param name="UpdatedById">The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="UpdatedDate">The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="UseDiscountSpecificAccountingCode">Determines whether to define a new accounting code for the new discount charge. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; .</param>
        /// <param name="UseTenantDefaultForPriceChange"> Applies the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Z-Billing &gt; Define Default Subscription Settings** **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="WeeklyBillCycleDay"> Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; .</param>
        public ProxyGetProductRatePlanCharge(string AccountingCode = null, string ApplyDiscountTo = null, int? BillCycleDay = null, string BillCycleType = null, string BillingPeriod = null, string BillingPeriodAlignment = null, string BillingTiming = null, string ChargeModel = null, string ChargeType = null, string CreatedById = null, DateTime? CreatedDate = null, double? DefaultQuantity = null, string DeferredRevenueAccount = null, string Description = null, string DiscountLevel = null, string EndDateCondition = null, string Id = null, double? IncludedUnits = null, bool? LegacyRevenueReporting = null, string ListPriceBase = null, double? MaxQuantity = null, double? MinQuantity = null, string Name = null, long? NumberOfPeriod = null, string OverageCalculationOption = null, string OverageUnusedUnitsCreditOption = null, string PriceChangeOption = null, double? PriceIncreasePercentage = null, string ProductRatePlanId = null, string RecognizedRevenueAccount = null, string RevRecCode = null, string RevRecTriggerCondition = null, string RevenueRecognitionRuleName = null, string SmoothingModel = null, long? SpecificBillingPeriod = null, string TaxCode = null, string TaxMode = null, bool? Taxable = null, string TriggerEvent = null, string UOM = null, long? UpToPeriods = null, string UpToPeriodsType = null, string UpdatedById = null, DateTime? UpdatedDate = null, bool? UseDiscountSpecificAccountingCode = null, bool? UseTenantDefaultForPriceChange = null, string WeeklyBillCycleDay = null)
        {
            this.AccountingCode = AccountingCode;
            this.ApplyDiscountTo = ApplyDiscountTo;
            this.BillCycleDay = BillCycleDay;
            this.BillCycleType = BillCycleType;
            this.BillingPeriod = BillingPeriod;
            this.BillingPeriodAlignment = BillingPeriodAlignment;
            this.BillingTiming = BillingTiming;
            this.ChargeModel = ChargeModel;
            this.ChargeType = ChargeType;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.DefaultQuantity = DefaultQuantity;
            this.DeferredRevenueAccount = DeferredRevenueAccount;
            this.Description = Description;
            this.DiscountLevel = DiscountLevel;
            this.EndDateCondition = EndDateCondition;
            this.Id = Id;
            this.IncludedUnits = IncludedUnits;
            this.LegacyRevenueReporting = LegacyRevenueReporting;
            this.ListPriceBase = ListPriceBase;
            this.MaxQuantity = MaxQuantity;
            this.MinQuantity = MinQuantity;
            this.Name = Name;
            this.NumberOfPeriod = NumberOfPeriod;
            this.OverageCalculationOption = OverageCalculationOption;
            this.OverageUnusedUnitsCreditOption = OverageUnusedUnitsCreditOption;
            this.PriceChangeOption = PriceChangeOption;
            this.PriceIncreasePercentage = PriceIncreasePercentage;
            this.ProductRatePlanId = ProductRatePlanId;
            this.RecognizedRevenueAccount = RecognizedRevenueAccount;
            this.RevRecCode = RevRecCode;
            this.RevRecTriggerCondition = RevRecTriggerCondition;
            this.RevenueRecognitionRuleName = RevenueRecognitionRuleName;
            this.SmoothingModel = SmoothingModel;
            this.SpecificBillingPeriod = SpecificBillingPeriod;
            this.TaxCode = TaxCode;
            this.TaxMode = TaxMode;
            this.Taxable = Taxable;
            this.TriggerEvent = TriggerEvent;
            this.UOM = UOM;
            this.UpToPeriods = UpToPeriods;
            this.UpToPeriodsType = UpToPeriodsType;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
            this.UseDiscountSpecificAccountingCode = UseDiscountSpecificAccountingCode;
            this.UseTenantDefaultForPriceChange = UseTenantDefaultForPriceChange;
            this.WeeklyBillCycleDay = WeeklyBillCycleDay;
        }
        
        /// <summary>
        /// The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts 
        /// </summary>
        /// <value>The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts </value>
        [DataMember(Name="AccountingCode", EmitDefaultValue=false)]
        public string AccountingCode { get; set; }
        /// <summary>
        /// Specifies the type of charges that you want a specific discount to apply to. All field values are case sensitive: note that these values are in all-caps. **Character limit**: 21 **Values**: one of the following:  - &#x60;ONETIME (1)&#x60; - &#x60;RECURRING (2)&#x60; - &#x60;USAGE (4)&#x60; - &#x60;ONETIMERECURRING (3)&#x60; - &#x60;ONETIMEUSAGE (5)&#x60; - &#x60;RECURRINGUSAGE (6)&#x60; - &#x60;ONETIMERECURRINGUSAGE (7)&#x60; 
        /// </summary>
        /// <value>Specifies the type of charges that you want a specific discount to apply to. All field values are case sensitive: note that these values are in all-caps. **Character limit**: 21 **Values**: one of the following:  - &#x60;ONETIME (1)&#x60; - &#x60;RECURRING (2)&#x60; - &#x60;USAGE (4)&#x60; - &#x60;ONETIMERECURRING (3)&#x60; - &#x60;ONETIMEUSAGE (5)&#x60; - &#x60;RECURRINGUSAGE (6)&#x60; - &#x60;ONETIMERECURRINGUSAGE (7)&#x60; </value>
        [DataMember(Name="ApplyDiscountTo", EmitDefaultValue=false)]
        public string ApplyDiscountTo { get; set; }
        /// <summary>
        ///  Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed. The BCD value in the account can override the BCD in this object. **Character limit**: 2 **Values**: a valid BCD integer, 1 - 31 
        /// </summary>
        /// <value> Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed. The BCD value in the account can override the BCD in this object. **Character limit**: 2 **Values**: a valid BCD integer, 1 - 31 </value>
        [DataMember(Name="BillCycleDay", EmitDefaultValue=false)]
        public int? BillCycleDay { get; set; }
        /// <summary>
        ///  Specifies how to determine the billing day for the charge. **Character limit**: 20 **Values**: one of the following:  - &#x60;DefaultFromCustomer&#x60; - &#x60;SpecificDayofMonth:&#x60; - &#x60;SubscriptionStartDay&#x60; - &#x60;ChargeTriggerDay&#x60; - &#x60;SpecificDayofWeek&#x60; **Note**:  - If you set this field to &#x60;SpecificDayofMonth&#x60;, you must specify which day of the month as the billing day for the charge in the BillCycleDay field. - If you set this field to &#x60;SpecificDayofWeek&#x60;, you must specify which day of the week as the billing day for the charge in the WeeklyBillCycleDay field. 
        /// </summary>
        /// <value> Specifies how to determine the billing day for the charge. **Character limit**: 20 **Values**: one of the following:  - &#x60;DefaultFromCustomer&#x60; - &#x60;SpecificDayofMonth:&#x60; - &#x60;SubscriptionStartDay&#x60; - &#x60;ChargeTriggerDay&#x60; - &#x60;SpecificDayofWeek&#x60; **Note**:  - If you set this field to &#x60;SpecificDayofMonth&#x60;, you must specify which day of the month as the billing day for the charge in the BillCycleDay field. - If you set this field to &#x60;SpecificDayofWeek&#x60;, you must specify which day of the week as the billing day for the charge in the WeeklyBillCycleDay field. </value>
        [DataMember(Name="BillCycleType", EmitDefaultValue=false)]
        public string BillCycleType { get; set; }
        /// <summary>
        ///  The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD). **Character limit**: 15 **Values**: one of the following  - &#x60;Month&#x60; - &#x60;Quarter&#x60; - &#x60;Annual&#x60; - &#x60;Semi-Annual&#x60; - &#x60;Specific Months&#x60; - &#x60;Subscription Term&#x60; (This value is in **Limited Availability**.) - &#x60;Week&#x60; - &#x60;Specific Weeks&#x60; **Note**: Specify the number of months or weeks in the SpecificBillingPeriod field if you set this field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. 
        /// </summary>
        /// <value> The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD). **Character limit**: 15 **Values**: one of the following  - &#x60;Month&#x60; - &#x60;Quarter&#x60; - &#x60;Annual&#x60; - &#x60;Semi-Annual&#x60; - &#x60;Specific Months&#x60; - &#x60;Subscription Term&#x60; (This value is in **Limited Availability**.) - &#x60;Week&#x60; - &#x60;Specific Weeks&#x60; **Note**: Specify the number of months or weeks in the SpecificBillingPeriod field if you set this field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. </value>
        [DataMember(Name="BillingPeriod", EmitDefaultValue=false)]
        public string BillingPeriod { get; set; }
        /// <summary>
        ///  Aligns charges within the same subscription if multiple charges begin on different dates. **Character limit**: 24 **Values**: one of the following:  - &#x60;AlignToCharge&#x60; - &#x60;AlignToSubscriptionStart&#x60; - &#x60;AlignToTermStart&#x60; 
        /// </summary>
        /// <value> Aligns charges within the same subscription if multiple charges begin on different dates. **Character limit**: 24 **Values**: one of the following:  - &#x60;AlignToCharge&#x60; - &#x60;AlignToSubscriptionStart&#x60; - &#x60;AlignToTermStart&#x60; </value>
        [DataMember(Name="BillingPeriodAlignment", EmitDefaultValue=false)]
        public string BillingPeriodAlignment { get; set; }
        /// <summary>
        ///  The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - &#x60;In Advance&#x60; - &#x60;In Arrears&#x60;  This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - &#x60;In Advance&#x60; - &#x60;In Arrears&#x60;  This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name="BillingTiming", EmitDefaultValue=false)]
        public string BillingTiming { get; set; }
        /// <summary>
        ///  Determines how to calculate charges. Charge models must be individually activated in Z-Billing administration. **Character limit**: 27 **Values**: one of the following:  - &#x60;Discount-Fixed Amount&#x60; - &#x60;Discount-Percentage&#x60; - &#x60;Flat Fee Pricing&#x60; - &#x60;Per Unit Pricing&#x60; - &#x60;Overage Pricing&#x60; - &#x60;Tiered Pricing&#x60; - &#x60;Tiered with Overage Pricing&#x60; - &#x60;Volume Pricing&#x60; 
        /// </summary>
        /// <value> Determines how to calculate charges. Charge models must be individually activated in Z-Billing administration. **Character limit**: 27 **Values**: one of the following:  - &#x60;Discount-Fixed Amount&#x60; - &#x60;Discount-Percentage&#x60; - &#x60;Flat Fee Pricing&#x60; - &#x60;Per Unit Pricing&#x60; - &#x60;Overage Pricing&#x60; - &#x60;Tiered Pricing&#x60; - &#x60;Tiered with Overage Pricing&#x60; - &#x60;Volume Pricing&#x60; </value>
        [DataMember(Name="ChargeModel", EmitDefaultValue=false)]
        public string ChargeModel { get; set; }
        /// <summary>
        ///  Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; 
        /// </summary>
        /// <value> Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; </value>
        [DataMember(Name="ChargeType", EmitDefaultValue=false)]
        public string ChargeType { get; set; }
        /// <summary>
        /// The ID of the Zuora user who created the &#x60;ProductRatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The ID of the Zuora user who created the &#x60;ProductRatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date when the  &#x60;ProductRatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the  &#x60;ProductRatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///  The default quantity of units, such as the number of authors in a hosted wiki service. This field is required if you use a per-unit pricing model. **Character limit**: 16 **Values**: a valid quantity value 
        /// </summary>
        /// <value> The default quantity of units, such as the number of authors in a hosted wiki service. This field is required if you use a per-unit pricing model. **Character limit**: 16 **Values**: a valid quantity value </value>
        [DataMember(Name="DefaultQuantity", EmitDefaultValue=false)]
        public double? DefaultQuantity { get; set; }
        /// <summary>
        ///  The name of the deferred revenue account for this charge. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The name of the deferred revenue account for this charge. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name="DeferredRevenueAccount", EmitDefaultValue=false)]
        public string DeferredRevenueAccount { get; set; }
        /// <summary>
        /// A description of the charge. **Character limit**: 500 **Values**: a string of 500 characters or fewer 
        /// </summary>
        /// <value>A description of the charge. **Character limit**: 500 **Values**: a string of 500 characters or fewer </value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        ///  Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: one of the following:  - &#x60;rateplan&#x60; - &#x60;subscription&#x60;, &#x60;account&#x60; 
        /// </summary>
        /// <value> Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: one of the following:  - &#x60;rateplan&#x60; - &#x60;subscription&#x60;, &#x60;account&#x60; </value>
        [DataMember(Name="DiscountLevel", EmitDefaultValue=false)]
        public string DiscountLevel { get; set; }
        /// <summary>
        ///  Defines when the charge ends after the charge trigger date. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after a specified period based on the trigger date of the charge. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. 
        /// </summary>
        /// <value> Defines when the charge ends after the charge trigger date. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after a specified period based on the trigger date of the charge. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. </value>
        [DataMember(Name="EndDateCondition", EmitDefaultValue=false)]
        public string EndDateCondition { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Specifies the number of units in the base set of units. **Character limit**: 16 **Values**: a positive decimal value 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units. **Character limit**: 16 **Values**: a positive decimal value </value>
        [DataMember(Name="IncludedUnits", EmitDefaultValue=false)]
        public double? IncludedUnits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="LegacyRevenueReporting", EmitDefaultValue=false)]
        public bool? LegacyRevenueReporting { get; set; }
        /// <summary>
        /// The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; 
        /// </summary>
        /// <value>The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; </value>
        [DataMember(Name="ListPriceBase", EmitDefaultValue=false)]
        public string ListPriceBase { get; set; }
        /// <summary>
        ///  Specifies the maximum number of units for this charge. Use this field and the &#x60;MinQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value 
        /// </summary>
        /// <value> Specifies the maximum number of units for this charge. Use this field and the &#x60;MinQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value </value>
        [DataMember(Name="MaxQuantity", EmitDefaultValue=false)]
        public double? MaxQuantity { get; set; }
        /// <summary>
        /// Specifies the minimum number of units for this charge. Use this field and the &#x60;MaxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value 
        /// </summary>
        /// <value>Specifies the minimum number of units for this charge. Use this field and the &#x60;MaxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value </value>
        [DataMember(Name="MinQuantity", EmitDefaultValue=false)]
        public double? MinQuantity { get; set; }
        /// <summary>
        /// The name of the product rate plan charge. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value>The name of the product rate plan charge. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: **Values**: a positive whole number 
        /// </summary>
        /// <value>Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: **Values**: a positive whole number </value>
        [DataMember(Name="NumberOfPeriod", EmitDefaultValue=false)]
        public long? NumberOfPeriod { get; set; }
        /// <summary>
        /// Determines when to calculate overage charges. If the value of the SmoothingMode field is not specified, the value of this field is ignored. **Character limit**: 20 **Values**: one of the following:  - &#x60;EndOfSmoothingPeriod&#x60;: This option is used by default. The overage is charged at the end of the smoothing period. - &#x60;PerBillingPeriod&#x60;: The overage is charged on-demand rather than waiting until the end of the smoothing period. 
        /// </summary>
        /// <value>Determines when to calculate overage charges. If the value of the SmoothingMode field is not specified, the value of this field is ignored. **Character limit**: 20 **Values**: one of the following:  - &#x60;EndOfSmoothingPeriod&#x60;: This option is used by default. The overage is charged at the end of the smoothing period. - &#x60;PerBillingPeriod&#x60;: The overage is charged on-demand rather than waiting until the end of the smoothing period. </value>
        [DataMember(Name="OverageCalculationOption", EmitDefaultValue=false)]
        public string OverageCalculationOption { get; set; }
        /// <summary>
        ///  Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: one of the following:  - &#x60;NoCredit&#x60; - &#x60;CreditBySpecificRate&#x60; 
        /// </summary>
        /// <value> Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: one of the following:  - &#x60;NoCredit&#x60; - &#x60;CreditBySpecificRate&#x60; </value>
        [DataMember(Name="OverageUnusedUnitsCreditOption", EmitDefaultValue=false)]
        public string OverageUnusedUnitsCreditOption { get; set; }
        /// <summary>
        ///  Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; 
        /// </summary>
        /// <value> Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; </value>
        [DataMember(Name="PriceChangeOption", EmitDefaultValue=false)]
        public string PriceChangeOption { get; set; }
        /// <summary>
        ///  Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the [&#x60;PriceChangeOption&#x60;](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/ProductRatePlanCharge#PriceIncreaseOption) value to &#x60;SpecificPercentageValue&#x60;. **Character limit**: 16 **Values**: a decimal value between -100 and 100 
        /// </summary>
        /// <value> Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the [&#x60;PriceChangeOption&#x60;](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/ProductRatePlanCharge#PriceIncreaseOption) value to &#x60;SpecificPercentageValue&#x60;. **Character limit**: 16 **Values**: a decimal value between -100 and 100 </value>
        [DataMember(Name="PriceIncreasePercentage", EmitDefaultValue=false)]
        public double? PriceIncreasePercentage { get; set; }
        /// <summary>
        ///  The ID of the product rate plan associated with this product rate plan charge. **Character limit**: 32 **Values**: a valid product rate plan ID 
        /// </summary>
        /// <value> The ID of the product rate plan associated with this product rate plan charge. **Character limit**: 32 **Values**: a valid product rate plan ID </value>
        [DataMember(Name="ProductRatePlanId", EmitDefaultValue=false)]
        public string ProductRatePlanId { get; set; }
        /// <summary>
        ///  The name of the recognized revenue account for this charge.  - Required when the Allow Blank Accounting Code setting is No. - Optional when the Allow Blank Accounting Code setting is Yes. Navigate to **Z-Finance Settings &gt; Configure Accounting Rules** to check this setting. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The name of the recognized revenue account for this charge.  - Required when the Allow Blank Accounting Code setting is No. - Optional when the Allow Blank Accounting Code setting is Yes. Navigate to **Z-Finance Settings &gt; Configure Accounting Rules** to check this setting. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name="RecognizedRevenueAccount", EmitDefaultValue=false)]
        public string RecognizedRevenueAccount { get; set; }
        /// <summary>
        /// Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code 
        /// </summary>
        /// <value>Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code </value>
        [DataMember(Name="RevRecCode", EmitDefaultValue=false)]
        public string RevRecCode { get; set; }
        /// <summary>
        ///  Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  - &#x60;ContractEffectiveDate&#x60; - &#x60;ServiceActivationDate&#x60; - &#x60;CustomerAcceptanceDate&#x60; 
        /// </summary>
        /// <value> Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  - &#x60;ContractEffectiveDate&#x60; - &#x60;ServiceActivationDate&#x60; - &#x60;CustomerAcceptanceDate&#x60; </value>
        [DataMember(Name="RevRecTriggerCondition", EmitDefaultValue=false)]
        public string RevRecTriggerCondition { get; set; }
        /// <summary>
        /// Determines when to recognize the revenue for this charge. **Character limit**: 25 **Values**: one of the following:  - &#x60;Recognize upon invoicing&#x60; - &#x60;Recognize daily over time&#x60; 
        /// </summary>
        /// <value>Determines when to recognize the revenue for this charge. **Character limit**: 25 **Values**: one of the following:  - &#x60;Recognize upon invoicing&#x60; - &#x60;Recognize daily over time&#x60; </value>
        [DataMember(Name="RevenueRecognitionRuleName", EmitDefaultValue=false)]
        public string RevenueRecognitionRuleName { get; set; }
        /// <summary>
        ///  Specifies the smoothing model for an overage smoothing charge model. **Character limit**: 22 **Values**: one of the following:  - &#x60;RollingWindow&#x60; - &#x60;Rollover&#x60; 
        /// </summary>
        /// <value> Specifies the smoothing model for an overage smoothing charge model. **Character limit**: 22 **Values**: one of the following:  - &#x60;RollingWindow&#x60; - &#x60;Rollover&#x60; </value>
        [DataMember(Name="SmoothingModel", EmitDefaultValue=false)]
        public string SmoothingModel { get; set; }
        /// <summary>
        ///  Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Values**: a positive integer 
        /// </summary>
        /// <value> Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Values**: a positive integer </value>
        [DataMember(Name="SpecificBillingPeriod", EmitDefaultValue=false)]
        public long? SpecificBillingPeriod { get; set; }
        /// <summary>
        ///  Specifies the tax code for taxation rules. Required when the Taxable field is set to &#x60;True&#x60;. **Character limit**: 64 **Values**: a valid tax code 
        /// </summary>
        /// <value> Specifies the tax code for taxation rules. Required when the Taxable field is set to &#x60;True&#x60;. **Character limit**: 64 **Values**: a valid tax code </value>
        [DataMember(Name="TaxCode", EmitDefaultValue=false)]
        public string TaxCode { get; set; }
        /// <summary>
        ///  Determines how to define taxation for the charge. Required when the Taxable field is set to &#x60;True&#x60;. **Character limit**: 12 **Values**: one of the following:  - &#x60;TaxExclusive&#x60; - &#x60;TaxInclusive&#x60; 
        /// </summary>
        /// <value> Determines how to define taxation for the charge. Required when the Taxable field is set to &#x60;True&#x60;. **Character limit**: 12 **Values**: one of the following:  - &#x60;TaxExclusive&#x60; - &#x60;TaxInclusive&#x60; </value>
        [DataMember(Name="TaxMode", EmitDefaultValue=false)]
        public string TaxMode { get; set; }
        /// <summary>
        ///  Determines whether the charge is taxable. When set to &#x60;True&#x60;, the TaxMode and TaxCode fields are required when creating or updating th ProductRatePlanCharge object. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; 
        /// </summary>
        /// <value> Determines whether the charge is taxable. When set to &#x60;True&#x60;, the TaxMode and TaxCode fields are required when creating or updating th ProductRatePlanCharge object. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; </value>
        [DataMember(Name="Taxable", EmitDefaultValue=false)]
        public bool? Taxable { get; set; }
        /// <summary>
        ///  Specifies when to start billing the customer for the charge. **Character limit**: 18 **Values**: one of the following:  - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription. 
        /// </summary>
        /// <value> Specifies when to start billing the customer for the charge. **Character limit**: 18 **Values**: one of the following:  - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription. </value>
        [DataMember(Name="TriggerEvent", EmitDefaultValue=false)]
        public string TriggerEvent { get; set; }
        /// <summary>
        ///  Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings**. **Character limit**: 25 **Values**: a configured unit of measure **Note**: You must specify this field when creating the following charge models:  - Per Unit Pricing - Volume Pricing - Overage Pricing - Tiered Pricing - Tiered with Overage Pricing 
        /// </summary>
        /// <value> Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings**. **Character limit**: 25 **Values**: a configured unit of measure **Note**: You must specify this field when creating the following charge models:  - Per Unit Pricing - Volume Pricing - Overage Pricing - Tiered Pricing - Tiered with Overage Pricing </value>
        [DataMember(Name="UOM", EmitDefaultValue=false)]
        public string UOM { get; set; }
        /// <summary>
        ///  Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: a whole number between 0 and 65535, exclusive **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value> Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: a whole number between 0 and 65535, exclusive **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name="UpToPeriods", EmitDefaultValue=false)]
        public long? UpToPeriods { get; set; }
        /// <summary>
        ///  The period type used to define when the charge ends. **Character limit**: - - **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - Years **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. 
        /// </summary>
        /// <value> The period type used to define when the charge ends. **Character limit**: - - **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - Years **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. </value>
        [DataMember(Name="UpToPeriodsType", EmitDefaultValue=false)]
        public string UpToPeriodsType { get; set; }
        /// <summary>
        /// The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        /// The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value>The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Determines whether to define a new accounting code for the new discount charge. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; 
        /// </summary>
        /// <value>Determines whether to define a new accounting code for the new discount charge. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; </value>
        [DataMember(Name="UseDiscountSpecificAccountingCode", EmitDefaultValue=false)]
        public bool? UseDiscountSpecificAccountingCode { get; set; }
        /// <summary>
        ///  Applies the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Z-Billing &gt; Define Default Subscription Settings** **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value> Applies the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. You set the tenant uplift value in the web-based UI: **Z-Billing &gt; Define Default Subscription Settings** **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name="UseTenantDefaultForPriceChange", EmitDefaultValue=false)]
        public bool? UseTenantDefaultForPriceChange { get; set; }
        /// <summary>
        ///  Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; 
        /// </summary>
        /// <value> Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; </value>
        [DataMember(Name="WeeklyBillCycleDay", EmitDefaultValue=false)]
        public string WeeklyBillCycleDay { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetProductRatePlanCharge {\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillCycleDay: ").Append(BillCycleDay).Append("\n");
            sb.Append("  BillCycleType: ").Append(BillCycleType).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  ChargeModel: ").Append(ChargeModel).Append("\n");
            sb.Append("  ChargeType: ").Append(ChargeType).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  DefaultQuantity: ").Append(DefaultQuantity).Append("\n");
            sb.Append("  DeferredRevenueAccount: ").Append(DeferredRevenueAccount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  LegacyRevenueReporting: ").Append(LegacyRevenueReporting).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  MaxQuantity: ").Append(MaxQuantity).Append("\n");
            sb.Append("  MinQuantity: ").Append(MinQuantity).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NumberOfPeriod: ").Append(NumberOfPeriod).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  ProductRatePlanId: ").Append(ProductRatePlanId).Append("\n");
            sb.Append("  RecognizedRevenueAccount: ").Append(RecognizedRevenueAccount).Append("\n");
            sb.Append("  RevRecCode: ").Append(RevRecCode).Append("\n");
            sb.Append("  RevRecTriggerCondition: ").Append(RevRecTriggerCondition).Append("\n");
            sb.Append("  RevenueRecognitionRuleName: ").Append(RevenueRecognitionRuleName).Append("\n");
            sb.Append("  SmoothingModel: ").Append(SmoothingModel).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxMode: ").Append(TaxMode).Append("\n");
            sb.Append("  Taxable: ").Append(Taxable).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  UOM: ").Append(UOM).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  UseDiscountSpecificAccountingCode: ").Append(UseDiscountSpecificAccountingCode).Append("\n");
            sb.Append("  UseTenantDefaultForPriceChange: ").Append(UseTenantDefaultForPriceChange).Append("\n");
            sb.Append("  WeeklyBillCycleDay: ").Append(WeeklyBillCycleDay).Append("\n");
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
            return this.Equals(obj as ProxyGetProductRatePlanCharge);
        }

        /// <summary>
        /// Returns true if ProxyGetProductRatePlanCharge instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetProductRatePlanCharge to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetProductRatePlanCharge other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountingCode == other.AccountingCode ||
                    this.AccountingCode != null &&
                    this.AccountingCode.Equals(other.AccountingCode)
                ) && 
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
                    this.ChargeModel == other.ChargeModel ||
                    this.ChargeModel != null &&
                    this.ChargeModel.Equals(other.ChargeModel)
                ) && 
                (
                    this.ChargeType == other.ChargeType ||
                    this.ChargeType != null &&
                    this.ChargeType.Equals(other.ChargeType)
                ) && 
                (
                    this.CreatedById == other.CreatedById ||
                    this.CreatedById != null &&
                    this.CreatedById.Equals(other.CreatedById)
                ) && 
                (
                    this.CreatedDate == other.CreatedDate ||
                    this.CreatedDate != null &&
                    this.CreatedDate.Equals(other.CreatedDate)
                ) && 
                (
                    this.DefaultQuantity == other.DefaultQuantity ||
                    this.DefaultQuantity != null &&
                    this.DefaultQuantity.Equals(other.DefaultQuantity)
                ) && 
                (
                    this.DeferredRevenueAccount == other.DeferredRevenueAccount ||
                    this.DeferredRevenueAccount != null &&
                    this.DeferredRevenueAccount.Equals(other.DeferredRevenueAccount)
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
                    this.LegacyRevenueReporting == other.LegacyRevenueReporting ||
                    this.LegacyRevenueReporting != null &&
                    this.LegacyRevenueReporting.Equals(other.LegacyRevenueReporting)
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
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.NumberOfPeriod == other.NumberOfPeriod ||
                    this.NumberOfPeriod != null &&
                    this.NumberOfPeriod.Equals(other.NumberOfPeriod)
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
                    this.ProductRatePlanId == other.ProductRatePlanId ||
                    this.ProductRatePlanId != null &&
                    this.ProductRatePlanId.Equals(other.ProductRatePlanId)
                ) && 
                (
                    this.RecognizedRevenueAccount == other.RecognizedRevenueAccount ||
                    this.RecognizedRevenueAccount != null &&
                    this.RecognizedRevenueAccount.Equals(other.RecognizedRevenueAccount)
                ) && 
                (
                    this.RevRecCode == other.RevRecCode ||
                    this.RevRecCode != null &&
                    this.RevRecCode.Equals(other.RevRecCode)
                ) && 
                (
                    this.RevRecTriggerCondition == other.RevRecTriggerCondition ||
                    this.RevRecTriggerCondition != null &&
                    this.RevRecTriggerCondition.Equals(other.RevRecTriggerCondition)
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
                    this.UOM == other.UOM ||
                    this.UOM != null &&
                    this.UOM.Equals(other.UOM)
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
                    this.UpdatedById == other.UpdatedById ||
                    this.UpdatedById != null &&
                    this.UpdatedById.Equals(other.UpdatedById)
                ) && 
                (
                    this.UpdatedDate == other.UpdatedDate ||
                    this.UpdatedDate != null &&
                    this.UpdatedDate.Equals(other.UpdatedDate)
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
                ) && 
                (
                    this.WeeklyBillCycleDay == other.WeeklyBillCycleDay ||
                    this.WeeklyBillCycleDay != null &&
                    this.WeeklyBillCycleDay.Equals(other.WeeklyBillCycleDay)
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
                if (this.AccountingCode != null)
                    hash = hash * 59 + this.AccountingCode.GetHashCode();
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
                if (this.ChargeModel != null)
                    hash = hash * 59 + this.ChargeModel.GetHashCode();
                if (this.ChargeType != null)
                    hash = hash * 59 + this.ChargeType.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.DefaultQuantity != null)
                    hash = hash * 59 + this.DefaultQuantity.GetHashCode();
                if (this.DeferredRevenueAccount != null)
                    hash = hash * 59 + this.DeferredRevenueAccount.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.DiscountLevel != null)
                    hash = hash * 59 + this.DiscountLevel.GetHashCode();
                if (this.EndDateCondition != null)
                    hash = hash * 59 + this.EndDateCondition.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.IncludedUnits != null)
                    hash = hash * 59 + this.IncludedUnits.GetHashCode();
                if (this.LegacyRevenueReporting != null)
                    hash = hash * 59 + this.LegacyRevenueReporting.GetHashCode();
                if (this.ListPriceBase != null)
                    hash = hash * 59 + this.ListPriceBase.GetHashCode();
                if (this.MaxQuantity != null)
                    hash = hash * 59 + this.MaxQuantity.GetHashCode();
                if (this.MinQuantity != null)
                    hash = hash * 59 + this.MinQuantity.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.NumberOfPeriod != null)
                    hash = hash * 59 + this.NumberOfPeriod.GetHashCode();
                if (this.OverageCalculationOption != null)
                    hash = hash * 59 + this.OverageCalculationOption.GetHashCode();
                if (this.OverageUnusedUnitsCreditOption != null)
                    hash = hash * 59 + this.OverageUnusedUnitsCreditOption.GetHashCode();
                if (this.PriceChangeOption != null)
                    hash = hash * 59 + this.PriceChangeOption.GetHashCode();
                if (this.PriceIncreasePercentage != null)
                    hash = hash * 59 + this.PriceIncreasePercentage.GetHashCode();
                if (this.ProductRatePlanId != null)
                    hash = hash * 59 + this.ProductRatePlanId.GetHashCode();
                if (this.RecognizedRevenueAccount != null)
                    hash = hash * 59 + this.RecognizedRevenueAccount.GetHashCode();
                if (this.RevRecCode != null)
                    hash = hash * 59 + this.RevRecCode.GetHashCode();
                if (this.RevRecTriggerCondition != null)
                    hash = hash * 59 + this.RevRecTriggerCondition.GetHashCode();
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
                if (this.UOM != null)
                    hash = hash * 59 + this.UOM.GetHashCode();
                if (this.UpToPeriods != null)
                    hash = hash * 59 + this.UpToPeriods.GetHashCode();
                if (this.UpToPeriodsType != null)
                    hash = hash * 59 + this.UpToPeriodsType.GetHashCode();
                if (this.UpdatedById != null)
                    hash = hash * 59 + this.UpdatedById.GetHashCode();
                if (this.UpdatedDate != null)
                    hash = hash * 59 + this.UpdatedDate.GetHashCode();
                if (this.UseDiscountSpecificAccountingCode != null)
                    hash = hash * 59 + this.UseDiscountSpecificAccountingCode.GetHashCode();
                if (this.UseTenantDefaultForPriceChange != null)
                    hash = hash * 59 + this.UseTenantDefaultForPriceChange.GetHashCode();
                if (this.WeeklyBillCycleDay != null)
                    hash = hash * 59 + this.WeeklyBillCycleDay.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
