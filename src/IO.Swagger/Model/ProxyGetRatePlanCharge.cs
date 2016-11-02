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
    /// ProxyGetRatePlanCharge
    /// </summary>
    [DataContract]
    public partial class ProxyGetRatePlanCharge :  IEquatable<ProxyGetRatePlanCharge>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetRatePlanCharge" /> class.
        /// </summary>
        /// <param name="AccountingCode">The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;ProductRatePlanCharge.AccountingCode&#x60; .</param>
        /// <param name="ApplyDiscountTo"> Specifies the type of charges a specific discount applies to. **Character limit**: 21 **Values**: inherited from &#x60;ProductRatePlanCharge.ApplyDiscountTo&#x60; .</param>
        /// <param name="BillCycleDay"> Indicates the charge&#39;s billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account. **Character limit**: 2 **Values**: inherited from &#x60;ProductRatePlanCharge.BillCycleDay&#x60; .</param>
        /// <param name="BillCycleType"> Specifies how to determine the billing day for the charge. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.BillCycleType&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. .</param>
        /// <param name="BillingPeriod"> Allows billing period to be overridden on rate plan charge. ****Values**: **inherited from &#x60;ProductRatePlanCharge.BillingPeriod&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. .</param>
        /// <param name="BillingPeriodAlignment"> Aligns charges within the same subscription if multiple charges begin on different dates. **Character limit**: 24 **Values**: inherited from &#x60;ProductRatePlanCharge.BillingPeriodAlignment&#x60; .</param>
        /// <param name="BillingTiming"> The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - I&#x60;n Advance&#x60; - &#x60;In Arrears&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge when a subscription has a recurring charge type. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="ChargeModel"> Determines how to evaluate charges. Charge models must be individually activated in the web-based UI. **Character limit**: 29 **Values**: inherited from &#x60;ProductRatePlanCharge.ChargeModel&#x60; .</param>
        /// <param name="ChargeNumber"> A unique number that identifies the charge. This number is returned as a string. **Character limit**: 50 **Values**: one of the following:  - automatically generated if left null - a unique number of 50 characters or fewer .</param>
        /// <param name="ChargeType"> Specifies the type of charge. **Character limit**: 9 **Values**: inherited from &#x60;ProductRatePlanCharge.ChargeType&#x60; .</param>
        /// <param name="ChargedThroughDate"> The date through which a customer has been billed for the charge. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="CreatedById">The ID of the Zuora user who created the &#x60;RatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date when the &#x60;RatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="DMRC">A delta monthly recurring charge is the change in monthly recurring revenue caused by an amendment or a new subscription. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="DTCV"> After an Amendment, the change in the total contract value (TCV) amount for this charge, compared with its previous value. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="Description"> A description of the charge. **Character limit**: 500 **Values**: inherited from &#x60;ProductRatePlanCharge.Description&#x60; .</param>
        /// <param name="DiscountLevel">Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: inherited from &#x60;ProductRatePlanCharge.DiscountLevel&#x60; .</param>
        /// <param name="EffectiveEndDate"> The date when the segmented charge ends or ended. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="EffectiveStartDate"> The date when the segmented charge starts or started. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="EndDateCondition"> Defines when the charge ends after the charge trigger date. This field can be updated when **Status** is &#x60;Draft&#x60;. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after the charge trigger date. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. - &#x60;SpecificEndDate&#x60;: The specific date on which the charge ends. If you set this field to &#x60;SpecificEndDate&#x60;, you must specify the specific date by defining the &#x60;SpecificEndDate&#x60; field.  **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="IsLastSegment">Indicates if the segment of the rate plan charge is the most recent segment. **Character limit**: 5 **Values**: automatically generated: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="ListPriceBase">The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; .</param>
        /// <param name="MRR">Monthly recurring revenue (MRR) is the amount of recurring charges in a given month. The MRR calculation doesn&#39;t include one-time charges nor usage charges. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="Name">The name of the rate plan charge. **Character limit**: 100 **Values**: automatically generated .</param>
        /// <param name="NumberOfPeriods">Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.NumberOfPeriod&#x60; .</param>
        /// <param name="OriginalId">The original ID of the rate plan charge. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="OverageCalculationOption">Determines when to calculate overage charges. If the value of the SmoothingMode field is null (not specified and not inherited from ProductRatePlanCharge.SmoothingMode), the value of this field is ignored. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.OverageCalculationOption&#x60; .</param>
        /// <param name="OverageUnusedUnitsCreditOption"> Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.OverageUnusedUnitsCreditOption&#x60; .</param>
        /// <param name="PriceChangeOption"> Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; .</param>
        /// <param name="PriceIncreasePercentage"> Specifies the percentage to increase or decrease the price of renewed subscriptions. Use this field if the [&#x60;ProductRatePlanCharge.PriceChangeOption&#x60;](/D_Zuora_APIs/SOAP_API/C_SOAP_API_Reference/F_API_Objects/ProductRatePlanCharge#PriceChangeOption) value is set to SpecificPercentageValue. **Character limit**: 16 **Values**: a decimal value between -100 and 100 .</param>
        /// <param name="ProcessedThroughDate"> The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Quantity"> The default quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. **Character limit**: 16 **Values**: a valid quantity value .</param>
        /// <param name="RatePlanId"> The ID of the rate plan associated with the rate plan charge. **Character limit**: 32 **Values**: inherited from &#x60;RatePlan.Id&#x60; .</param>
        /// <param name="RevRecCode"> Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code .</param>
        /// <param name="RevRecTriggerCondition"> Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  -  &#x60;ContractEffectiveDate&#x60;  -  &#x60;ServiceActivationDate&#x60;  -  &#x60;CustomerAcceptanceDate&#x60;  .</param>
        /// <param name="RevenueRecognitionRuleName"> Specifies the Revenue Recognition Rule that you want the Rate Plan Charge to use. This field can be updated when **Status** is &#x60;Draft&#x60;. By default, the Revenue Recognition Rule is inherited from the Product Rate Plan Charge. For Amend() calls, you can use this field only for NewProduct amendments. For Update() calls, you can use this field only to update subscriptions in draft status. Note that if you use this field to specify a Revenue Recognition Rule for the Rate Plan Charge, the rule will remain as specified even if you later change the rule used by the corresponding Product Rate Plan Charge. See [Z-Billing User Role](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) permission enabled to use this field.  **Character limit**: n/a **Values**: name of an active Revenue Recognition Rule .</param>
        /// <param name="Segment"> The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. **Character limit**: 2 **Values**: automatically generated .</param>
        /// <param name="SpecificBillingPeriod"> Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.BillingPeriod&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. .</param>
        /// <param name="SpecificEndDate"> The specific date on which the charge ends. **Character limit**: 29 **Values**: a valid date and time value **Note**:  - This field is only applicable when the &#x60;EndDateCondition&#x60; field is set to &#x60;SpecificEndDate&#x60;. - If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. .</param>
        /// <param name="TCV"> The total contract value (TCV) is the value of a single rate plan charge in a subscription over the lifetime of the subscription. This value does not represent all charges on the subscription. The TCV includes recurring charges and one-time charges, but it doesn&#39;t include usage charge. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="TriggerDate"> The date when the charge becomes effective, and billing begins. This field is required if the &#x60;TriggerEvent&#x60; field value is &#x60;SpecificDate&#x60;. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) .</param>
        /// <param name="TriggerEvent"> Specifies when to start billing the customer for the charge. **Note: **This field can be passed through the subscribe() and amend() calls and will override the default value set on the Product Rate Plan Charge. **Character limit**: 18 **Values**: inherited from &#x60;ProductRatePlanCharge.TriggerEvent&#x60; and can be one of the following values:  - &#x60;ContractEffective &#x60;is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivationDate &#x60;is when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance &#x60;is when the customer accepts the services or products for a subscription. - SpecificDate is valid only on the RatePlanCharge. .</param>
        /// <param name="UOM"> Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings**. **Character limit**: 25 **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60; .</param>
        /// <param name="UpToPeriods"> Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.UpToPeriods&#x60; **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is only applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. - Use this field to override the value in &#x60;ProductRatePlanCharge.UpToPeriod&#x60;. - If you override the value in this field, enter a whole number between 0 and 65535, exclusive. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="UpToPeriodsType"> The period type used to define when the charge ends. This field can be updated when **Status** is &#x60;Draft&#x60;. **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - &#x60;Years&#x60; **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is only applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. .</param>
        /// <param name="UpdatedById">The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="UpdatedDate"> The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Version"> The version of the rate plan charge. Each time a charge is amended, Zuora creates a new version of the rate plan charge. **Character limit**: 5 **Values**: automatically generated .</param>
        /// <param name="WeeklyBillCycleDay"> Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; .</param>
        public ProxyGetRatePlanCharge(string AccountingCode = null, string ApplyDiscountTo = null, int? BillCycleDay = null, string BillCycleType = null, string BillingPeriod = null, string BillingPeriodAlignment = null, string BillingTiming = null, string ChargeModel = null, string ChargeNumber = null, string ChargeType = null, DateTime? ChargedThroughDate = null, string CreatedById = null, DateTime? CreatedDate = null, double? DMRC = null, double? DTCV = null, string Description = null, string DiscountLevel = null, DateTime? EffectiveEndDate = null, DateTime? EffectiveStartDate = null, string EndDateCondition = null, string Id = null, bool? IsLastSegment = null, string ListPriceBase = null, double? MRR = null, string Name = null, long? NumberOfPeriods = null, string OriginalId = null, string OverageCalculationOption = null, string OverageUnusedUnitsCreditOption = null, string PriceChangeOption = null, double? PriceIncreasePercentage = null, DateTime? ProcessedThroughDate = null, double? Quantity = null, string RatePlanId = null, string RevRecCode = null, string RevRecTriggerCondition = null, string RevenueRecognitionRuleName = null, int? Segment = null, long? SpecificBillingPeriod = null, DateTime? SpecificEndDate = null, double? TCV = null, DateTime? TriggerDate = null, string TriggerEvent = null, string UOM = null, long? UpToPeriods = null, string UpToPeriodsType = null, string UpdatedById = null, DateTime? UpdatedDate = null, long? Version = null, string WeeklyBillCycleDay = null)
        {
            this.AccountingCode = AccountingCode;
            this.ApplyDiscountTo = ApplyDiscountTo;
            this.BillCycleDay = BillCycleDay;
            this.BillCycleType = BillCycleType;
            this.BillingPeriod = BillingPeriod;
            this.BillingPeriodAlignment = BillingPeriodAlignment;
            this.BillingTiming = BillingTiming;
            this.ChargeModel = ChargeModel;
            this.ChargeNumber = ChargeNumber;
            this.ChargeType = ChargeType;
            this.ChargedThroughDate = ChargedThroughDate;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.DMRC = DMRC;
            this.DTCV = DTCV;
            this.Description = Description;
            this.DiscountLevel = DiscountLevel;
            this.EffectiveEndDate = EffectiveEndDate;
            this.EffectiveStartDate = EffectiveStartDate;
            this.EndDateCondition = EndDateCondition;
            this.Id = Id;
            this.IsLastSegment = IsLastSegment;
            this.ListPriceBase = ListPriceBase;
            this.MRR = MRR;
            this.Name = Name;
            this.NumberOfPeriods = NumberOfPeriods;
            this.OriginalId = OriginalId;
            this.OverageCalculationOption = OverageCalculationOption;
            this.OverageUnusedUnitsCreditOption = OverageUnusedUnitsCreditOption;
            this.PriceChangeOption = PriceChangeOption;
            this.PriceIncreasePercentage = PriceIncreasePercentage;
            this.ProcessedThroughDate = ProcessedThroughDate;
            this.Quantity = Quantity;
            this.RatePlanId = RatePlanId;
            this.RevRecCode = RevRecCode;
            this.RevRecTriggerCondition = RevRecTriggerCondition;
            this.RevenueRecognitionRuleName = RevenueRecognitionRuleName;
            this.Segment = Segment;
            this.SpecificBillingPeriod = SpecificBillingPeriod;
            this.SpecificEndDate = SpecificEndDate;
            this.TCV = TCV;
            this.TriggerDate = TriggerDate;
            this.TriggerEvent = TriggerEvent;
            this.UOM = UOM;
            this.UpToPeriods = UpToPeriods;
            this.UpToPeriodsType = UpToPeriodsType;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
            this.Version = Version;
            this.WeeklyBillCycleDay = WeeklyBillCycleDay;
        }
        
        /// <summary>
        /// The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;ProductRatePlanCharge.AccountingCode&#x60; 
        /// </summary>
        /// <value>The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;ProductRatePlanCharge.AccountingCode&#x60; </value>
        [DataMember(Name="AccountingCode", EmitDefaultValue=false)]
        public string AccountingCode { get; set; }
        /// <summary>
        ///  Specifies the type of charges a specific discount applies to. **Character limit**: 21 **Values**: inherited from &#x60;ProductRatePlanCharge.ApplyDiscountTo&#x60; 
        /// </summary>
        /// <value> Specifies the type of charges a specific discount applies to. **Character limit**: 21 **Values**: inherited from &#x60;ProductRatePlanCharge.ApplyDiscountTo&#x60; </value>
        [DataMember(Name="ApplyDiscountTo", EmitDefaultValue=false)]
        public string ApplyDiscountTo { get; set; }
        /// <summary>
        ///  Indicates the charge&#39;s billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account. **Character limit**: 2 **Values**: inherited from &#x60;ProductRatePlanCharge.BillCycleDay&#x60; 
        /// </summary>
        /// <value> Indicates the charge&#39;s billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account. **Character limit**: 2 **Values**: inherited from &#x60;ProductRatePlanCharge.BillCycleDay&#x60; </value>
        [DataMember(Name="BillCycleDay", EmitDefaultValue=false)]
        public int? BillCycleDay { get; set; }
        /// <summary>
        ///  Specifies how to determine the billing day for the charge. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.BillCycleType&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. 
        /// </summary>
        /// <value> Specifies how to determine the billing day for the charge. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.BillCycleType&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. </value>
        [DataMember(Name="BillCycleType", EmitDefaultValue=false)]
        public string BillCycleType { get; set; }
        /// <summary>
        ///  Allows billing period to be overridden on rate plan charge. ****Values**: **inherited from &#x60;ProductRatePlanCharge.BillingPeriod&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. 
        /// </summary>
        /// <value> Allows billing period to be overridden on rate plan charge. ****Values**: **inherited from &#x60;ProductRatePlanCharge.BillingPeriod&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. </value>
        [DataMember(Name="BillingPeriod", EmitDefaultValue=false)]
        public string BillingPeriod { get; set; }
        /// <summary>
        ///  Aligns charges within the same subscription if multiple charges begin on different dates. **Character limit**: 24 **Values**: inherited from &#x60;ProductRatePlanCharge.BillingPeriodAlignment&#x60; 
        /// </summary>
        /// <value> Aligns charges within the same subscription if multiple charges begin on different dates. **Character limit**: 24 **Values**: inherited from &#x60;ProductRatePlanCharge.BillingPeriodAlignment&#x60; </value>
        [DataMember(Name="BillingPeriodAlignment", EmitDefaultValue=false)]
        public string BillingPeriodAlignment { get; set; }
        /// <summary>
        ///  The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - I&#x60;n Advance&#x60; - &#x60;In Arrears&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge when a subscription has a recurring charge type. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - I&#x60;n Advance&#x60; - &#x60;In Arrears&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge when a subscription has a recurring charge type. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name="BillingTiming", EmitDefaultValue=false)]
        public string BillingTiming { get; set; }
        /// <summary>
        ///  Determines how to evaluate charges. Charge models must be individually activated in the web-based UI. **Character limit**: 29 **Values**: inherited from &#x60;ProductRatePlanCharge.ChargeModel&#x60; 
        /// </summary>
        /// <value> Determines how to evaluate charges. Charge models must be individually activated in the web-based UI. **Character limit**: 29 **Values**: inherited from &#x60;ProductRatePlanCharge.ChargeModel&#x60; </value>
        [DataMember(Name="ChargeModel", EmitDefaultValue=false)]
        public string ChargeModel { get; set; }
        /// <summary>
        ///  A unique number that identifies the charge. This number is returned as a string. **Character limit**: 50 **Values**: one of the following:  - automatically generated if left null - a unique number of 50 characters or fewer 
        /// </summary>
        /// <value> A unique number that identifies the charge. This number is returned as a string. **Character limit**: 50 **Values**: one of the following:  - automatically generated if left null - a unique number of 50 characters or fewer </value>
        [DataMember(Name="ChargeNumber", EmitDefaultValue=false)]
        public string ChargeNumber { get; set; }
        /// <summary>
        ///  Specifies the type of charge. **Character limit**: 9 **Values**: inherited from &#x60;ProductRatePlanCharge.ChargeType&#x60; 
        /// </summary>
        /// <value> Specifies the type of charge. **Character limit**: 9 **Values**: inherited from &#x60;ProductRatePlanCharge.ChargeType&#x60; </value>
        [DataMember(Name="ChargeType", EmitDefaultValue=false)]
        public string ChargeType { get; set; }
        /// <summary>
        ///  The date through which a customer has been billed for the charge. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date through which a customer has been billed for the charge. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="ChargedThroughDate", EmitDefaultValue=false)]
        public DateTime? ChargedThroughDate { get; set; }
        /// <summary>
        /// The ID of the Zuora user who created the &#x60;RatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The ID of the Zuora user who created the &#x60;RatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date when the &#x60;RatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the &#x60;RatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// A delta monthly recurring charge is the change in monthly recurring revenue caused by an amendment or a new subscription. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value>A delta monthly recurring charge is the change in monthly recurring revenue caused by an amendment or a new subscription. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="DMRC", EmitDefaultValue=false)]
        public double? DMRC { get; set; }
        /// <summary>
        ///  After an Amendment, the change in the total contract value (TCV) amount for this charge, compared with its previous value. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> After an Amendment, the change in the total contract value (TCV) amount for this charge, compared with its previous value. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="DTCV", EmitDefaultValue=false)]
        public double? DTCV { get; set; }
        /// <summary>
        ///  A description of the charge. **Character limit**: 500 **Values**: inherited from &#x60;ProductRatePlanCharge.Description&#x60; 
        /// </summary>
        /// <value> A description of the charge. **Character limit**: 500 **Values**: inherited from &#x60;ProductRatePlanCharge.Description&#x60; </value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        /// Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: inherited from &#x60;ProductRatePlanCharge.DiscountLevel&#x60; 
        /// </summary>
        /// <value>Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: inherited from &#x60;ProductRatePlanCharge.DiscountLevel&#x60; </value>
        [DataMember(Name="DiscountLevel", EmitDefaultValue=false)]
        public string DiscountLevel { get; set; }
        /// <summary>
        ///  The date when the segmented charge ends or ended. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the segmented charge ends or ended. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="EffectiveEndDate", EmitDefaultValue=false)]
        public DateTime? EffectiveEndDate { get; set; }
        /// <summary>
        ///  The date when the segmented charge starts or started. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the segmented charge starts or started. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="EffectiveStartDate", EmitDefaultValue=false)]
        public DateTime? EffectiveStartDate { get; set; }
        /// <summary>
        ///  Defines when the charge ends after the charge trigger date. This field can be updated when **Status** is &#x60;Draft&#x60;. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after the charge trigger date. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. - &#x60;SpecificEndDate&#x60;: The specific date on which the charge ends. If you set this field to &#x60;SpecificEndDate&#x60;, you must specify the specific date by defining the &#x60;SpecificEndDate&#x60; field.  **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. 
        /// </summary>
        /// <value> Defines when the charge ends after the charge trigger date. This field can be updated when **Status** is &#x60;Draft&#x60;. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after the charge trigger date. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. - &#x60;SpecificEndDate&#x60;: The specific date on which the charge ends. If you set this field to &#x60;SpecificEndDate&#x60;, you must specify the specific date by defining the &#x60;SpecificEndDate&#x60; field.  **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. </value>
        [DataMember(Name="EndDateCondition", EmitDefaultValue=false)]
        public string EndDateCondition { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Indicates if the segment of the rate plan charge is the most recent segment. **Character limit**: 5 **Values**: automatically generated: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value>Indicates if the segment of the rate plan charge is the most recent segment. **Character limit**: 5 **Values**: automatically generated: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name="IsLastSegment", EmitDefaultValue=false)]
        public bool? IsLastSegment { get; set; }
        /// <summary>
        /// The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; 
        /// </summary>
        /// <value>The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; </value>
        [DataMember(Name="ListPriceBase", EmitDefaultValue=false)]
        public string ListPriceBase { get; set; }
        /// <summary>
        /// Monthly recurring revenue (MRR) is the amount of recurring charges in a given month. The MRR calculation doesn&#39;t include one-time charges nor usage charges. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value>Monthly recurring revenue (MRR) is the amount of recurring charges in a given month. The MRR calculation doesn&#39;t include one-time charges nor usage charges. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="MRR", EmitDefaultValue=false)]
        public double? MRR { get; set; }
        /// <summary>
        /// The name of the rate plan charge. **Character limit**: 100 **Values**: automatically generated 
        /// </summary>
        /// <value>The name of the rate plan charge. **Character limit**: 100 **Values**: automatically generated </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.NumberOfPeriod&#x60; 
        /// </summary>
        /// <value>Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.NumberOfPeriod&#x60; </value>
        [DataMember(Name="NumberOfPeriods", EmitDefaultValue=false)]
        public long? NumberOfPeriods { get; set; }
        /// <summary>
        /// The original ID of the rate plan charge. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The original ID of the rate plan charge. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="OriginalId", EmitDefaultValue=false)]
        public string OriginalId { get; set; }
        /// <summary>
        /// Determines when to calculate overage charges. If the value of the SmoothingMode field is null (not specified and not inherited from ProductRatePlanCharge.SmoothingMode), the value of this field is ignored. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.OverageCalculationOption&#x60; 
        /// </summary>
        /// <value>Determines when to calculate overage charges. If the value of the SmoothingMode field is null (not specified and not inherited from ProductRatePlanCharge.SmoothingMode), the value of this field is ignored. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.OverageCalculationOption&#x60; </value>
        [DataMember(Name="OverageCalculationOption", EmitDefaultValue=false)]
        public string OverageCalculationOption { get; set; }
        /// <summary>
        ///  Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.OverageUnusedUnitsCreditOption&#x60; 
        /// </summary>
        /// <value> Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: inherited from &#x60;ProductRatePlanCharge.OverageUnusedUnitsCreditOption&#x60; </value>
        [DataMember(Name="OverageUnusedUnitsCreditOption", EmitDefaultValue=false)]
        public string OverageUnusedUnitsCreditOption { get; set; }
        /// <summary>
        ///  Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; 
        /// </summary>
        /// <value> Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; </value>
        [DataMember(Name="PriceChangeOption", EmitDefaultValue=false)]
        public string PriceChangeOption { get; set; }
        /// <summary>
        ///  Specifies the percentage to increase or decrease the price of renewed subscriptions. Use this field if the [&#x60;ProductRatePlanCharge.PriceChangeOption&#x60;](/D_Zuora_APIs/SOAP_API/C_SOAP_API_Reference/F_API_Objects/ProductRatePlanCharge#PriceChangeOption) value is set to SpecificPercentageValue. **Character limit**: 16 **Values**: a decimal value between -100 and 100 
        /// </summary>
        /// <value> Specifies the percentage to increase or decrease the price of renewed subscriptions. Use this field if the [&#x60;ProductRatePlanCharge.PriceChangeOption&#x60;](/D_Zuora_APIs/SOAP_API/C_SOAP_API_Reference/F_API_Objects/ProductRatePlanCharge#PriceChangeOption) value is set to SpecificPercentageValue. **Character limit**: 16 **Values**: a decimal value between -100 and 100 </value>
        [DataMember(Name="PriceIncreasePercentage", EmitDefaultValue=false)]
        public double? PriceIncreasePercentage { get; set; }
        /// <summary>
        ///  The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="ProcessedThroughDate", EmitDefaultValue=false)]
        public DateTime? ProcessedThroughDate { get; set; }
        /// <summary>
        ///  The default quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. **Character limit**: 16 **Values**: a valid quantity value 
        /// </summary>
        /// <value> The default quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. **Character limit**: 16 **Values**: a valid quantity value </value>
        [DataMember(Name="Quantity", EmitDefaultValue=false)]
        public double? Quantity { get; set; }
        /// <summary>
        ///  The ID of the rate plan associated with the rate plan charge. **Character limit**: 32 **Values**: inherited from &#x60;RatePlan.Id&#x60; 
        /// </summary>
        /// <value> The ID of the rate plan associated with the rate plan charge. **Character limit**: 32 **Values**: inherited from &#x60;RatePlan.Id&#x60; </value>
        [DataMember(Name="RatePlanId", EmitDefaultValue=false)]
        public string RatePlanId { get; set; }
        /// <summary>
        ///  Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code 
        /// </summary>
        /// <value> Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code </value>
        [DataMember(Name="RevRecCode", EmitDefaultValue=false)]
        public string RevRecCode { get; set; }
        /// <summary>
        ///  Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  -  &#x60;ContractEffectiveDate&#x60;  -  &#x60;ServiceActivationDate&#x60;  -  &#x60;CustomerAcceptanceDate&#x60;  
        /// </summary>
        /// <value> Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  -  &#x60;ContractEffectiveDate&#x60;  -  &#x60;ServiceActivationDate&#x60;  -  &#x60;CustomerAcceptanceDate&#x60;  </value>
        [DataMember(Name="RevRecTriggerCondition", EmitDefaultValue=false)]
        public string RevRecTriggerCondition { get; set; }
        /// <summary>
        ///  Specifies the Revenue Recognition Rule that you want the Rate Plan Charge to use. This field can be updated when **Status** is &#x60;Draft&#x60;. By default, the Revenue Recognition Rule is inherited from the Product Rate Plan Charge. For Amend() calls, you can use this field only for NewProduct amendments. For Update() calls, you can use this field only to update subscriptions in draft status. Note that if you use this field to specify a Revenue Recognition Rule for the Rate Plan Charge, the rule will remain as specified even if you later change the rule used by the corresponding Product Rate Plan Charge. See [Z-Billing User Role](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) permission enabled to use this field.  **Character limit**: n/a **Values**: name of an active Revenue Recognition Rule 
        /// </summary>
        /// <value> Specifies the Revenue Recognition Rule that you want the Rate Plan Charge to use. This field can be updated when **Status** is &#x60;Draft&#x60;. By default, the Revenue Recognition Rule is inherited from the Product Rate Plan Charge. For Amend() calls, you can use this field only for NewProduct amendments. For Update() calls, you can use this field only to update subscriptions in draft status. Note that if you use this field to specify a Revenue Recognition Rule for the Rate Plan Charge, the rule will remain as specified even if you later change the rule used by the corresponding Product Rate Plan Charge. See [Z-Billing User Role](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/d_Billing_Roles) permission enabled to use this field.  **Character limit**: n/a **Values**: name of an active Revenue Recognition Rule </value>
        [DataMember(Name="RevenueRecognitionRuleName", EmitDefaultValue=false)]
        public string RevenueRecognitionRuleName { get; set; }
        /// <summary>
        ///  The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. **Character limit**: 2 **Values**: automatically generated 
        /// </summary>
        /// <value> The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. **Character limit**: 2 **Values**: automatically generated </value>
        [DataMember(Name="Segment", EmitDefaultValue=false)]
        public int? Segment { get; set; }
        /// <summary>
        ///  Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.BillingPeriod&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. 
        /// </summary>
        /// <value> Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.BillingPeriod&#x60; **Note:** You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. </value>
        [DataMember(Name="SpecificBillingPeriod", EmitDefaultValue=false)]
        public long? SpecificBillingPeriod { get; set; }
        /// <summary>
        ///  The specific date on which the charge ends. **Character limit**: 29 **Values**: a valid date and time value **Note**:  - This field is only applicable when the &#x60;EndDateCondition&#x60; field is set to &#x60;SpecificEndDate&#x60;. - If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. 
        /// </summary>
        /// <value> The specific date on which the charge ends. **Character limit**: 29 **Values**: a valid date and time value **Note**:  - This field is only applicable when the &#x60;EndDateCondition&#x60; field is set to &#x60;SpecificEndDate&#x60;. - If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. </value>
        [DataMember(Name="SpecificEndDate", EmitDefaultValue=false)]
        public DateTime? SpecificEndDate { get; set; }
        /// <summary>
        ///  The total contract value (TCV) is the value of a single rate plan charge in a subscription over the lifetime of the subscription. This value does not represent all charges on the subscription. The TCV includes recurring charges and one-time charges, but it doesn&#39;t include usage charge. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The total contract value (TCV) is the value of a single rate plan charge in a subscription over the lifetime of the subscription. This value does not represent all charges on the subscription. The TCV includes recurring charges and one-time charges, but it doesn&#39;t include usage charge. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="TCV", EmitDefaultValue=false)]
        public double? TCV { get; set; }
        /// <summary>
        ///  The date when the charge becomes effective, and billing begins. This field is required if the &#x60;TriggerEvent&#x60; field value is &#x60;SpecificDate&#x60;. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) 
        /// </summary>
        /// <value> The date when the charge becomes effective, and billing begins. This field is required if the &#x60;TriggerEvent&#x60; field value is &#x60;SpecificDate&#x60;. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) </value>
        [DataMember(Name="TriggerDate", EmitDefaultValue=false)]
        public DateTime? TriggerDate { get; set; }
        /// <summary>
        ///  Specifies when to start billing the customer for the charge. **Note: **This field can be passed through the subscribe() and amend() calls and will override the default value set on the Product Rate Plan Charge. **Character limit**: 18 **Values**: inherited from &#x60;ProductRatePlanCharge.TriggerEvent&#x60; and can be one of the following values:  - &#x60;ContractEffective &#x60;is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivationDate &#x60;is when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance &#x60;is when the customer accepts the services or products for a subscription. - SpecificDate is valid only on the RatePlanCharge. 
        /// </summary>
        /// <value> Specifies when to start billing the customer for the charge. **Note: **This field can be passed through the subscribe() and amend() calls and will override the default value set on the Product Rate Plan Charge. **Character limit**: 18 **Values**: inherited from &#x60;ProductRatePlanCharge.TriggerEvent&#x60; and can be one of the following values:  - &#x60;ContractEffective &#x60;is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivationDate &#x60;is when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance &#x60;is when the customer accepts the services or products for a subscription. - SpecificDate is valid only on the RatePlanCharge. </value>
        [DataMember(Name="TriggerEvent", EmitDefaultValue=false)]
        public string TriggerEvent { get; set; }
        /// <summary>
        ///  Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings**. **Character limit**: 25 **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60; 
        /// </summary>
        /// <value> Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings**. **Character limit**: 25 **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60; </value>
        [DataMember(Name="UOM", EmitDefaultValue=false)]
        public string UOM { get; set; }
        /// <summary>
        ///  Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.UpToPeriods&#x60; **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is only applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. - Use this field to override the value in &#x60;ProductRatePlanCharge.UpToPeriod&#x60;. - If you override the value in this field, enter a whole number between 0 and 65535, exclusive. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value> Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: inherited from &#x60;ProductRatePlanCharge.UpToPeriods&#x60; **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is only applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - You can override the value inherited from the Product Rate Plan Charge, but only when creating a new subscription or a New Product amendment. - Use this field to override the value in &#x60;ProductRatePlanCharge.UpToPeriod&#x60;. - If you override the value in this field, enter a whole number between 0 and 65535, exclusive. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name="UpToPeriods", EmitDefaultValue=false)]
        public long? UpToPeriods { get; set; }
        /// <summary>
        ///  The period type used to define when the charge ends. This field can be updated when **Status** is &#x60;Draft&#x60;. **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - &#x60;Years&#x60; **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is only applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. 
        /// </summary>
        /// <value> The period type used to define when the charge ends. This field can be updated when **Status** is &#x60;Draft&#x60;. **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - &#x60;Years&#x60; **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is only applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. </value>
        [DataMember(Name="UpToPeriodsType", EmitDefaultValue=false)]
        public string UpToPeriodsType { get; set; }
        /// <summary>
        /// The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        ///  The version of the rate plan charge. Each time a charge is amended, Zuora creates a new version of the rate plan charge. **Character limit**: 5 **Values**: automatically generated 
        /// </summary>
        /// <value> The version of the rate plan charge. Each time a charge is amended, Zuora creates a new version of the rate plan charge. **Character limit**: 5 **Values**: automatically generated </value>
        [DataMember(Name="Version", EmitDefaultValue=false)]
        public long? Version { get; set; }
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
            sb.Append("class ProxyGetRatePlanCharge {\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillCycleDay: ").Append(BillCycleDay).Append("\n");
            sb.Append("  BillCycleType: ").Append(BillCycleType).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  ChargeModel: ").Append(ChargeModel).Append("\n");
            sb.Append("  ChargeNumber: ").Append(ChargeNumber).Append("\n");
            sb.Append("  ChargeType: ").Append(ChargeType).Append("\n");
            sb.Append("  ChargedThroughDate: ").Append(ChargedThroughDate).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  DMRC: ").Append(DMRC).Append("\n");
            sb.Append("  DTCV: ").Append(DTCV).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  EffectiveEndDate: ").Append(EffectiveEndDate).Append("\n");
            sb.Append("  EffectiveStartDate: ").Append(EffectiveStartDate).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsLastSegment: ").Append(IsLastSegment).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  MRR: ").Append(MRR).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NumberOfPeriods: ").Append(NumberOfPeriods).Append("\n");
            sb.Append("  OriginalId: ").Append(OriginalId).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  ProcessedThroughDate: ").Append(ProcessedThroughDate).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RatePlanId: ").Append(RatePlanId).Append("\n");
            sb.Append("  RevRecCode: ").Append(RevRecCode).Append("\n");
            sb.Append("  RevRecTriggerCondition: ").Append(RevRecTriggerCondition).Append("\n");
            sb.Append("  RevenueRecognitionRuleName: ").Append(RevenueRecognitionRuleName).Append("\n");
            sb.Append("  Segment: ").Append(Segment).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  SpecificEndDate: ").Append(SpecificEndDate).Append("\n");
            sb.Append("  TCV: ").Append(TCV).Append("\n");
            sb.Append("  TriggerDate: ").Append(TriggerDate).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  UOM: ").Append(UOM).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
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
            return this.Equals(obj as ProxyGetRatePlanCharge);
        }

        /// <summary>
        /// Returns true if ProxyGetRatePlanCharge instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetRatePlanCharge to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetRatePlanCharge other)
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
                    this.ChargeNumber == other.ChargeNumber ||
                    this.ChargeNumber != null &&
                    this.ChargeNumber.Equals(other.ChargeNumber)
                ) && 
                (
                    this.ChargeType == other.ChargeType ||
                    this.ChargeType != null &&
                    this.ChargeType.Equals(other.ChargeType)
                ) && 
                (
                    this.ChargedThroughDate == other.ChargedThroughDate ||
                    this.ChargedThroughDate != null &&
                    this.ChargedThroughDate.Equals(other.ChargedThroughDate)
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
                    this.DMRC == other.DMRC ||
                    this.DMRC != null &&
                    this.DMRC.Equals(other.DMRC)
                ) && 
                (
                    this.DTCV == other.DTCV ||
                    this.DTCV != null &&
                    this.DTCV.Equals(other.DTCV)
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
                    this.IsLastSegment == other.IsLastSegment ||
                    this.IsLastSegment != null &&
                    this.IsLastSegment.Equals(other.IsLastSegment)
                ) && 
                (
                    this.ListPriceBase == other.ListPriceBase ||
                    this.ListPriceBase != null &&
                    this.ListPriceBase.Equals(other.ListPriceBase)
                ) && 
                (
                    this.MRR == other.MRR ||
                    this.MRR != null &&
                    this.MRR.Equals(other.MRR)
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
                    this.OriginalId == other.OriginalId ||
                    this.OriginalId != null &&
                    this.OriginalId.Equals(other.OriginalId)
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
                    this.ProcessedThroughDate == other.ProcessedThroughDate ||
                    this.ProcessedThroughDate != null &&
                    this.ProcessedThroughDate.Equals(other.ProcessedThroughDate)
                ) && 
                (
                    this.Quantity == other.Quantity ||
                    this.Quantity != null &&
                    this.Quantity.Equals(other.Quantity)
                ) && 
                (
                    this.RatePlanId == other.RatePlanId ||
                    this.RatePlanId != null &&
                    this.RatePlanId.Equals(other.RatePlanId)
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
                    this.Segment == other.Segment ||
                    this.Segment != null &&
                    this.Segment.Equals(other.Segment)
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
                    this.TCV == other.TCV ||
                    this.TCV != null &&
                    this.TCV.Equals(other.TCV)
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
                    this.Version == other.Version ||
                    this.Version != null &&
                    this.Version.Equals(other.Version)
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
                if (this.ChargeNumber != null)
                    hash = hash * 59 + this.ChargeNumber.GetHashCode();
                if (this.ChargeType != null)
                    hash = hash * 59 + this.ChargeType.GetHashCode();
                if (this.ChargedThroughDate != null)
                    hash = hash * 59 + this.ChargedThroughDate.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.DMRC != null)
                    hash = hash * 59 + this.DMRC.GetHashCode();
                if (this.DTCV != null)
                    hash = hash * 59 + this.DTCV.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.DiscountLevel != null)
                    hash = hash * 59 + this.DiscountLevel.GetHashCode();
                if (this.EffectiveEndDate != null)
                    hash = hash * 59 + this.EffectiveEndDate.GetHashCode();
                if (this.EffectiveStartDate != null)
                    hash = hash * 59 + this.EffectiveStartDate.GetHashCode();
                if (this.EndDateCondition != null)
                    hash = hash * 59 + this.EndDateCondition.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.IsLastSegment != null)
                    hash = hash * 59 + this.IsLastSegment.GetHashCode();
                if (this.ListPriceBase != null)
                    hash = hash * 59 + this.ListPriceBase.GetHashCode();
                if (this.MRR != null)
                    hash = hash * 59 + this.MRR.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.NumberOfPeriods != null)
                    hash = hash * 59 + this.NumberOfPeriods.GetHashCode();
                if (this.OriginalId != null)
                    hash = hash * 59 + this.OriginalId.GetHashCode();
                if (this.OverageCalculationOption != null)
                    hash = hash * 59 + this.OverageCalculationOption.GetHashCode();
                if (this.OverageUnusedUnitsCreditOption != null)
                    hash = hash * 59 + this.OverageUnusedUnitsCreditOption.GetHashCode();
                if (this.PriceChangeOption != null)
                    hash = hash * 59 + this.PriceChangeOption.GetHashCode();
                if (this.PriceIncreasePercentage != null)
                    hash = hash * 59 + this.PriceIncreasePercentage.GetHashCode();
                if (this.ProcessedThroughDate != null)
                    hash = hash * 59 + this.ProcessedThroughDate.GetHashCode();
                if (this.Quantity != null)
                    hash = hash * 59 + this.Quantity.GetHashCode();
                if (this.RatePlanId != null)
                    hash = hash * 59 + this.RatePlanId.GetHashCode();
                if (this.RevRecCode != null)
                    hash = hash * 59 + this.RevRecCode.GetHashCode();
                if (this.RevRecTriggerCondition != null)
                    hash = hash * 59 + this.RevRecTriggerCondition.GetHashCode();
                if (this.RevenueRecognitionRuleName != null)
                    hash = hash * 59 + this.RevenueRecognitionRuleName.GetHashCode();
                if (this.Segment != null)
                    hash = hash * 59 + this.Segment.GetHashCode();
                if (this.SpecificBillingPeriod != null)
                    hash = hash * 59 + this.SpecificBillingPeriod.GetHashCode();
                if (this.SpecificEndDate != null)
                    hash = hash * 59 + this.SpecificEndDate.GetHashCode();
                if (this.TCV != null)
                    hash = hash * 59 + this.TCV.GetHashCode();
                if (this.TriggerDate != null)
                    hash = hash * 59 + this.TriggerDate.GetHashCode();
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
                if (this.Version != null)
                    hash = hash * 59 + this.Version.GetHashCode();
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
