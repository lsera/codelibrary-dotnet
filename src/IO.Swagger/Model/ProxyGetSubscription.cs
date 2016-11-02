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
    /// ProxyGetSubscription
    /// </summary>
    [DataContract]
    public partial class ProxyGetSubscription :  IEquatable<ProxyGetSubscription>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetSubscription" /> class.
        /// </summary>
        /// <param name="AccountId"> This field can be updated when **Status** is &#x60;Draft&#x60;. The ID of the [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) .</param>
        /// <param name="AutoRenew"> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if the subscription automatically renews at the end of the term. **Values**: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="CancelledDate"> The date of the [Amendment object](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Amendment) that canceled the subscription. **Values**: inherited from &#x60;Amendment.EffectiveDate&#x60; .</param>
        /// <param name="ContractAcceptanceDate"> The date when the customer accepts the contract. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: The service activation date is only required if the [Require Service Activation of Orders?](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) Setting is set to &#x60;Yes&#x60;. If this setting is set to &#x60;Yes&#x60;:  - If ContractAcceptanceDate field is required, you must set this field, ContractAcceptanceDate, and ContractEffectiveDate fields in the subscribe call to activate a subscription. - If ContractAcceptanceDate field is not required, you must set both this field and the ContractEffectiveDate field in the subscribe call to activate a subscription. If you only set a valid date in the ContractEffectiveDate field, the subscribe call still returns success, but the subscription is in &#x60;DRAT&#x60; status. .</param>
        /// <param name="ContractEffectiveDate"> The date when the contract takes effect. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: This field is required in the subscribe call. If you set the value of this field to null and both the ServiceActivationDate and ContractAcceptanceDate fields are not required, the subscribe call still returns success, but the new subscription is in &#x60;DRAFT&#x60; status. To activate the subscription, you must set a valid date to this field. .</param>
        /// <param name="CpqBundleJsonIdQT"> The Bundle product structures from Zuora Quotes if you utilize Bundling in Salesforce. Do not change the value in this field. **Character limit**: 32 **Values**: N/A .</param>
        /// <param name="CreatedById">The user ID of the person who created the subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date the subscription was created. This value is the same as the OriginalCreatedDate value until the subscription is amended. **Values**: automatically generated .</param>
        /// <param name="CreatorAccountId"> The account ID that created the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatorInvoiceOwnerId"> The [account](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) ID that owns the invoices associated with the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CurrentTerm"> The length of the period for the current subscription term. If TermType is set to &#x60;TERMED&#x60;, this field is required and must be greater than &#x60;0&#x60;. If TermType is set to &#x60;EVERGREEN&#x60;, this value is ignored. Default is &#x60;0&#x60;. **Character limit**: 20 **Values**: automatically generated .</param>
        /// <param name="CurrentTermPeriodType"> The period type for the current subscription term. This field is used with the CurrentTerm field to specify the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="InitialTerm"> The length of the period for the first subscription term. This field can be updated when Status is &#x60;Draft&#x60;. If you use the subscribe() call, this field is required. **Required**: If TermType is Termed **Character limit**: 20 **Values**: any valid number. The default value is 0. .</param>
        /// <param name="InitialTermPeriodType"> The period type for the first subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the InitialTerm field to specify the initial subscription term. .</param>
        /// <param name="InvoiceOwnerId"> This field can be updated when **Status** is &#x60;Draft&#x60;. The [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) .</param>
        /// <param name="IsInvoiceSeparate"> Determines if the subscription is invoiced separately. If &#x60;TRUE&#x60;, then all charges for this subscription are collected into the subscription&#39;s own invoice. **V****alues**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) .</param>
        /// <param name="Name"> The unique identifier of the subscription. If you don&#39;t specify a value, then Zuora generates a name automatically. Whether auto-generated or manually specified, the subscription name must be unique. Otherwise an error will occur. In WSDL 69+, you can change this value only when the subscription is in &#x60;Draft&#x60; status. Once the subscription is activated, you can&#39;t change this value, nor can you use this value for a different subscription. **Character limit**: 100 **Values**: one of the following:  - leave null to automatically generate - a string of 100 characters or fewer .</param>
        /// <param name="Notes"> Use this field to record comments about the subscription. **Character limit**: 500 **Values**: a string of 500 characters or fewer .</param>
        /// <param name="OpportunityCloseDateQT"> The closing date of the Opportunity. This field is used in Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: **Values**: populated by Zuora Quotes .</param>
        /// <param name="OpportunityNameQT"> The unique identifier of the Opportunity. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 100 **Values**: populated by Zuora Quotes .</param>
        /// <param name="OriginalCreatedDate"> The date when the subscription was originally created. This value is the same as the CreatedDate value until the subscription is amended. **Values**: automatically generated .</param>
        /// <param name="OriginalId"> The original ID of this subscription. **Values**: automatically generated .</param>
        /// <param name="PreviousSubscriptionId"> The subscription ID immediately prior to the current subscription. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="QuoteBusinessTypeQT"> The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes .</param>
        /// <param name="QuoteNumberQT"> The unique identifier of the Quote. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes .</param>
        /// <param name="QuoteTypeQT"> The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes .</param>
        /// <param name="RenewalSetting"> This field can be updated when **Status** is &#x60;Draft&#x60;. Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: &#x60;RENEW_WITH_SPECIFIC_TERM &#x60;(default), &#x60;RENEW_TO_EVERGREEN&#x60; .</param>
        /// <param name="RenewalTerm"> The length of the period for the subscription renewal term. This field can be updated when **Status** is &#x60;Draft&#x60;. If you use the subscribe() call, this field is required. **Required**: If TermType is Termed. **Character limit**: 20 **Values**: one of the following:  - leave null to default to &#x60;0&#x60; - any number .</param>
        /// <param name="RenewalTermPeriodType"> The period type for the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field is used with the RenewalTerm field to specify the subscription renewal term. - This field can be updated when Status is &#x60;Draft&#x60;. .</param>
        /// <param name="ServiceActivationDate"> The date when the subscription is activated. This field can be updated when **Status** is &#x60;Draft&#x60;. **Character limit**: 29 **Note**: The service activation date is only required if the [Require Service Activation of Orders?](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) Setting is set to &#x60;Yes&#x60;. If this setting is set to &#x60;Yes&#x60;:  - If ContractAcceptanceDate field is required, you must set this field, ContractAcceptanceDate, and ContractEffectiveDate fields in the subscribe call to activate a subscription. - If ContractAcceptanceDate field is not required, you must set both this field and the ContractEffectiveDate field in the subscribe call to activate a subscription. If you only set a valid date in the ContractEffectiveDate field, the subscribe call still returns success, but the subscription is in &#x60;DRAT&#x60; status. .</param>
        /// <param name="Status"> The status of the subscription. **Character limit**: 17 **Values**: automatically generated **Possible values**: one of the following:  - &#x60;Draft&#x60; - &#x60;PendingActivation&#x60; - &#x60;PendingAcceptance&#x60; - &#x60;Active&#x60; - &#x60;Cancelled&#x60; - &#x60;Expired&#x60; - &#x60;Suspended&#x60; (This value is in **Limited Availability**.) .</param>
        /// <param name="SubscriptionEndDate"> The date when the subscription term ends, where the subscription ends at midnight the day before. For example, if the SubscriptionEndDate is 12/31/2016, the subscriptions ends at midnight (00:00:00 hours) on 12/30/2016. This date is the same as the term end date or the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="SubscriptionStartDate"> The date when the subscription term starts. This date is the same as the start date of the original term, which isn&#39;t necessarily the start date of the current or new term. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="TermEndDate"> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term ends. If the subscription is evergreen, the TermEndDate value is null or is the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="TermStartDate"> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term begins. If this is a renewal subscription, then this date is different from the subscription start date. **Character limit**: 29 **Version notes**: - - .</param>
        /// <param name="TermType"> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if a subscription is [termed or evergreen](https://knowledgecenter.zuora.com/BC_Subscription_Management/Subscriptions#Termed_and_Evergreen_Subscriptions). A termed subscription has a specific end date and requires manual renewal. An evergreen subscription doesn&#39;t have an end date and doesn&#39;t need renewal. This field can be updated when the subscription status is Draft. **Character limit**: 9 **Values**: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60; .</param>
        /// <param name="UpdatedById"> The ID of the user who last updated the subscription. **Character limit:** 32 **Values: **automatically generated .</param>
        /// <param name="UpdatedDate"> The date when the subscription was last updated. **Character limit:** 29 **Values**: automatically generated .</param>
        /// <param name="Version"> The version number of the subscription. **Values**: automatically generated .</param>
        public ProxyGetSubscription(string AccountId = null, bool? AutoRenew = null, DateTime? CancelledDate = null, DateTime? ContractAcceptanceDate = null, DateTime? ContractEffectiveDate = null, string CpqBundleJsonIdQT = null, string CreatedById = null, DateTime? CreatedDate = null, string CreatorAccountId = null, string CreatorInvoiceOwnerId = null, int? CurrentTerm = null, string CurrentTermPeriodType = null, string Id = null, int? InitialTerm = null, string InitialTermPeriodType = null, string InvoiceOwnerId = null, bool? IsInvoiceSeparate = null, string Name = null, string Notes = null, DateTime? OpportunityCloseDateQT = null, string OpportunityNameQT = null, DateTime? OriginalCreatedDate = null, string OriginalId = null, string PreviousSubscriptionId = null, string QuoteBusinessTypeQT = null, string QuoteNumberQT = null, string QuoteTypeQT = null, string RenewalSetting = null, int? RenewalTerm = null, string RenewalTermPeriodType = null, DateTime? ServiceActivationDate = null, string Status = null, DateTime? SubscriptionEndDate = null, DateTime? SubscriptionStartDate = null, DateTime? TermEndDate = null, DateTime? TermStartDate = null, string TermType = null, string UpdatedById = null, DateTime? UpdatedDate = null, int? Version = null)
        {
            this.AccountId = AccountId;
            this.AutoRenew = AutoRenew;
            this.CancelledDate = CancelledDate;
            this.ContractAcceptanceDate = ContractAcceptanceDate;
            this.ContractEffectiveDate = ContractEffectiveDate;
            this.CpqBundleJsonIdQT = CpqBundleJsonIdQT;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.CreatorAccountId = CreatorAccountId;
            this.CreatorInvoiceOwnerId = CreatorInvoiceOwnerId;
            this.CurrentTerm = CurrentTerm;
            this.CurrentTermPeriodType = CurrentTermPeriodType;
            this.Id = Id;
            this.InitialTerm = InitialTerm;
            this.InitialTermPeriodType = InitialTermPeriodType;
            this.InvoiceOwnerId = InvoiceOwnerId;
            this.IsInvoiceSeparate = IsInvoiceSeparate;
            this.Name = Name;
            this.Notes = Notes;
            this.OpportunityCloseDateQT = OpportunityCloseDateQT;
            this.OpportunityNameQT = OpportunityNameQT;
            this.OriginalCreatedDate = OriginalCreatedDate;
            this.OriginalId = OriginalId;
            this.PreviousSubscriptionId = PreviousSubscriptionId;
            this.QuoteBusinessTypeQT = QuoteBusinessTypeQT;
            this.QuoteNumberQT = QuoteNumberQT;
            this.QuoteTypeQT = QuoteTypeQT;
            this.RenewalSetting = RenewalSetting;
            this.RenewalTerm = RenewalTerm;
            this.RenewalTermPeriodType = RenewalTermPeriodType;
            this.ServiceActivationDate = ServiceActivationDate;
            this.Status = Status;
            this.SubscriptionEndDate = SubscriptionEndDate;
            this.SubscriptionStartDate = SubscriptionStartDate;
            this.TermEndDate = TermEndDate;
            this.TermStartDate = TermStartDate;
            this.TermType = TermType;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
            this.Version = Version;
        }
        
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The ID of the [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The ID of the [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) </value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if the subscription automatically renews at the end of the term. **Values**: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if the subscription automatically renews at the end of the term. **Values**: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name="AutoRenew", EmitDefaultValue=false)]
        public bool? AutoRenew { get; set; }
        /// <summary>
        ///  The date of the [Amendment object](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Amendment) that canceled the subscription. **Values**: inherited from &#x60;Amendment.EffectiveDate&#x60; 
        /// </summary>
        /// <value> The date of the [Amendment object](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Amendment) that canceled the subscription. **Values**: inherited from &#x60;Amendment.EffectiveDate&#x60; </value>
        [DataMember(Name="CancelledDate", EmitDefaultValue=false)]
        public DateTime? CancelledDate { get; set; }
        /// <summary>
        ///  The date when the customer accepts the contract. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: The service activation date is only required if the [Require Service Activation of Orders?](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) Setting is set to &#x60;Yes&#x60;. If this setting is set to &#x60;Yes&#x60;:  - If ContractAcceptanceDate field is required, you must set this field, ContractAcceptanceDate, and ContractEffectiveDate fields in the subscribe call to activate a subscription. - If ContractAcceptanceDate field is not required, you must set both this field and the ContractEffectiveDate field in the subscribe call to activate a subscription. If you only set a valid date in the ContractEffectiveDate field, the subscribe call still returns success, but the subscription is in &#x60;DRAT&#x60; status. 
        /// </summary>
        /// <value> The date when the customer accepts the contract. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: The service activation date is only required if the [Require Service Activation of Orders?](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) Setting is set to &#x60;Yes&#x60;. If this setting is set to &#x60;Yes&#x60;:  - If ContractAcceptanceDate field is required, you must set this field, ContractAcceptanceDate, and ContractEffectiveDate fields in the subscribe call to activate a subscription. - If ContractAcceptanceDate field is not required, you must set both this field and the ContractEffectiveDate field in the subscribe call to activate a subscription. If you only set a valid date in the ContractEffectiveDate field, the subscribe call still returns success, but the subscription is in &#x60;DRAT&#x60; status. </value>
        [DataMember(Name="ContractAcceptanceDate", EmitDefaultValue=false)]
        public DateTime? ContractAcceptanceDate { get; set; }
        /// <summary>
        ///  The date when the contract takes effect. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: This field is required in the subscribe call. If you set the value of this field to null and both the ServiceActivationDate and ContractAcceptanceDate fields are not required, the subscribe call still returns success, but the new subscription is in &#x60;DRAFT&#x60; status. To activate the subscription, you must set a valid date to this field. 
        /// </summary>
        /// <value> The date when the contract takes effect. This field can be updated when **Status** is &#x60;Draft&#x60;. **Note**: This field is required in the subscribe call. If you set the value of this field to null and both the ServiceActivationDate and ContractAcceptanceDate fields are not required, the subscribe call still returns success, but the new subscription is in &#x60;DRAFT&#x60; status. To activate the subscription, you must set a valid date to this field. </value>
        [DataMember(Name="ContractEffectiveDate", EmitDefaultValue=false)]
        public DateTime? ContractEffectiveDate { get; set; }
        /// <summary>
        ///  The Bundle product structures from Zuora Quotes if you utilize Bundling in Salesforce. Do not change the value in this field. **Character limit**: 32 **Values**: N/A 
        /// </summary>
        /// <value> The Bundle product structures from Zuora Quotes if you utilize Bundling in Salesforce. Do not change the value in this field. **Character limit**: 32 **Values**: N/A </value>
        [DataMember(Name="CpqBundleJsonId__QT", EmitDefaultValue=false)]
        public string CpqBundleJsonIdQT { get; set; }
        /// <summary>
        /// The user ID of the person who created the subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The user ID of the person who created the subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date the subscription was created. This value is the same as the OriginalCreatedDate value until the subscription is amended. **Values**: automatically generated 
        /// </summary>
        /// <value> The date the subscription was created. This value is the same as the OriginalCreatedDate value until the subscription is amended. **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///  The account ID that created the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The account ID that created the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatorAccountId", EmitDefaultValue=false)]
        public string CreatorAccountId { get; set; }
        /// <summary>
        ///  The [account](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) ID that owns the invoices associated with the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The [account](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) ID that owns the invoices associated with the subscription or the amended subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatorInvoiceOwnerId", EmitDefaultValue=false)]
        public string CreatorInvoiceOwnerId { get; set; }
        /// <summary>
        ///  The length of the period for the current subscription term. If TermType is set to &#x60;TERMED&#x60;, this field is required and must be greater than &#x60;0&#x60;. If TermType is set to &#x60;EVERGREEN&#x60;, this value is ignored. Default is &#x60;0&#x60;. **Character limit**: 20 **Values**: automatically generated 
        /// </summary>
        /// <value> The length of the period for the current subscription term. If TermType is set to &#x60;TERMED&#x60;, this field is required and must be greater than &#x60;0&#x60;. If TermType is set to &#x60;EVERGREEN&#x60;, this value is ignored. Default is &#x60;0&#x60;. **Character limit**: 20 **Values**: automatically generated </value>
        [DataMember(Name="CurrentTerm", EmitDefaultValue=false)]
        public int? CurrentTerm { get; set; }
        /// <summary>
        ///  The period type for the current subscription term. This field is used with the CurrentTerm field to specify the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; 
        /// </summary>
        /// <value> The period type for the current subscription term. This field is used with the CurrentTerm field to specify the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; </value>
        [DataMember(Name="CurrentTermPeriodType", EmitDefaultValue=false)]
        public string CurrentTermPeriodType { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        ///  The length of the period for the first subscription term. This field can be updated when Status is &#x60;Draft&#x60;. If you use the subscribe() call, this field is required. **Required**: If TermType is Termed **Character limit**: 20 **Values**: any valid number. The default value is 0. 
        /// </summary>
        /// <value> The length of the period for the first subscription term. This field can be updated when Status is &#x60;Draft&#x60;. If you use the subscribe() call, this field is required. **Required**: If TermType is Termed **Character limit**: 20 **Values**: any valid number. The default value is 0. </value>
        [DataMember(Name="InitialTerm", EmitDefaultValue=false)]
        public int? InitialTerm { get; set; }
        /// <summary>
        ///  The period type for the first subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the InitialTerm field to specify the initial subscription term. 
        /// </summary>
        /// <value> The period type for the first subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the InitialTerm field to specify the initial subscription term. </value>
        [DataMember(Name="InitialTermPeriodType", EmitDefaultValue=false)]
        public string InitialTermPeriodType { get; set; }
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) </value>
        [DataMember(Name="InvoiceOwnerId", EmitDefaultValue=false)]
        public string InvoiceOwnerId { get; set; }
        /// <summary>
        ///  Determines if the subscription is invoiced separately. If &#x60;TRUE&#x60;, then all charges for this subscription are collected into the subscription&#39;s own invoice. **V****alues**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) 
        /// </summary>
        /// <value> Determines if the subscription is invoiced separately. If &#x60;TRUE&#x60;, then all charges for this subscription are collected into the subscription&#39;s own invoice. **V****alues**: &#x60;TRUE&#x60;, &#x60;FALSE &#x60;(default) </value>
        [DataMember(Name="IsInvoiceSeparate", EmitDefaultValue=false)]
        public bool? IsInvoiceSeparate { get; set; }
        /// <summary>
        ///  The unique identifier of the subscription. If you don&#39;t specify a value, then Zuora generates a name automatically. Whether auto-generated or manually specified, the subscription name must be unique. Otherwise an error will occur. In WSDL 69+, you can change this value only when the subscription is in &#x60;Draft&#x60; status. Once the subscription is activated, you can&#39;t change this value, nor can you use this value for a different subscription. **Character limit**: 100 **Values**: one of the following:  - leave null to automatically generate - a string of 100 characters or fewer 
        /// </summary>
        /// <value> The unique identifier of the subscription. If you don&#39;t specify a value, then Zuora generates a name automatically. Whether auto-generated or manually specified, the subscription name must be unique. Otherwise an error will occur. In WSDL 69+, you can change this value only when the subscription is in &#x60;Draft&#x60; status. Once the subscription is activated, you can&#39;t change this value, nor can you use this value for a different subscription. **Character limit**: 100 **Values**: one of the following:  - leave null to automatically generate - a string of 100 characters or fewer </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        ///  Use this field to record comments about the subscription. **Character limit**: 500 **Values**: a string of 500 characters or fewer 
        /// </summary>
        /// <value> Use this field to record comments about the subscription. **Character limit**: 500 **Values**: a string of 500 characters or fewer </value>
        [DataMember(Name="Notes", EmitDefaultValue=false)]
        public string Notes { get; set; }
        /// <summary>
        ///  The closing date of the Opportunity. This field is used in Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: **Values**: populated by Zuora Quotes 
        /// </summary>
        /// <value> The closing date of the Opportunity. This field is used in Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: **Values**: populated by Zuora Quotes </value>
        [DataMember(Name="OpportunityCloseDate__QT", EmitDefaultValue=false)]
        public DateTime? OpportunityCloseDateQT { get; set; }
        /// <summary>
        ///  The unique identifier of the Opportunity. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 100 **Values**: populated by Zuora Quotes 
        /// </summary>
        /// <value> The unique identifier of the Opportunity. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 100 **Values**: populated by Zuora Quotes </value>
        [DataMember(Name="OpportunityName__QT", EmitDefaultValue=false)]
        public string OpportunityNameQT { get; set; }
        /// <summary>
        ///  The date when the subscription was originally created. This value is the same as the CreatedDate value until the subscription is amended. **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription was originally created. This value is the same as the CreatedDate value until the subscription is amended. **Values**: automatically generated </value>
        [DataMember(Name="OriginalCreatedDate", EmitDefaultValue=false)]
        public DateTime? OriginalCreatedDate { get; set; }
        /// <summary>
        ///  The original ID of this subscription. **Values**: automatically generated 
        /// </summary>
        /// <value> The original ID of this subscription. **Values**: automatically generated </value>
        [DataMember(Name="OriginalId", EmitDefaultValue=false)]
        public string OriginalId { get; set; }
        /// <summary>
        ///  The subscription ID immediately prior to the current subscription. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The subscription ID immediately prior to the current subscription. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="PreviousSubscriptionId", EmitDefaultValue=false)]
        public string PreviousSubscriptionId { get; set; }
        /// <summary>
        ///  The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes 
        /// </summary>
        /// <value> The specific identifier for the type of business transaction the Quote represents such as New, Upsell, Downsell, Renewal or Churn. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes </value>
        [DataMember(Name="QuoteBusinessType__QT", EmitDefaultValue=false)]
        public string QuoteBusinessTypeQT { get; set; }
        /// <summary>
        ///  The unique identifier of the Quote. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes 
        /// </summary>
        /// <value> The unique identifier of the Quote. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes </value>
        [DataMember(Name="QuoteNumber__QT", EmitDefaultValue=false)]
        public string QuoteNumberQT { get; set; }
        /// <summary>
        ///  The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes 
        /// </summary>
        /// <value> The Quote type that represents the subscription lifecycle stage such as New, Amendment, Renew or Cancel. This field is used in the Zuora Reporting Data Sources to report on Subscription metrics. If the subscription was originated from Zuora Quotes, the value is populated with the value from Zuora Quotes. **Character limit**: 32 **Values**: populated by Zuora Quotes </value>
        [DataMember(Name="QuoteType__QT", EmitDefaultValue=false)]
        public string QuoteTypeQT { get; set; }
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: &#x60;RENEW_WITH_SPECIFIC_TERM &#x60;(default), &#x60;RENEW_TO_EVERGREEN&#x60; 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: &#x60;RENEW_WITH_SPECIFIC_TERM &#x60;(default), &#x60;RENEW_TO_EVERGREEN&#x60; </value>
        [DataMember(Name="RenewalSetting", EmitDefaultValue=false)]
        public string RenewalSetting { get; set; }
        /// <summary>
        ///  The length of the period for the subscription renewal term. This field can be updated when **Status** is &#x60;Draft&#x60;. If you use the subscribe() call, this field is required. **Required**: If TermType is Termed. **Character limit**: 20 **Values**: one of the following:  - leave null to default to &#x60;0&#x60; - any number 
        /// </summary>
        /// <value> The length of the period for the subscription renewal term. This field can be updated when **Status** is &#x60;Draft&#x60;. If you use the subscribe() call, this field is required. **Required**: If TermType is Termed. **Character limit**: 20 **Values**: one of the following:  - leave null to default to &#x60;0&#x60; - any number </value>
        [DataMember(Name="RenewalTerm", EmitDefaultValue=false)]
        public int? RenewalTerm { get; set; }
        /// <summary>
        ///  The period type for the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field is used with the RenewalTerm field to specify the subscription renewal term. - This field can be updated when Status is &#x60;Draft&#x60;. 
        /// </summary>
        /// <value> The period type for the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field is used with the RenewalTerm field to specify the subscription renewal term. - This field can be updated when Status is &#x60;Draft&#x60;. </value>
        [DataMember(Name="RenewalTermPeriodType", EmitDefaultValue=false)]
        public string RenewalTermPeriodType { get; set; }
        /// <summary>
        ///  The date when the subscription is activated. This field can be updated when **Status** is &#x60;Draft&#x60;. **Character limit**: 29 **Note**: The service activation date is only required if the [Require Service Activation of Orders?](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) Setting is set to &#x60;Yes&#x60;. If this setting is set to &#x60;Yes&#x60;:  - If ContractAcceptanceDate field is required, you must set this field, ContractAcceptanceDate, and ContractEffectiveDate fields in the subscribe call to activate a subscription. - If ContractAcceptanceDate field is not required, you must set both this field and the ContractEffectiveDate field in the subscribe call to activate a subscription. If you only set a valid date in the ContractEffectiveDate field, the subscribe call still returns success, but the subscription is in &#x60;DRAT&#x60; status. 
        /// </summary>
        /// <value> The date when the subscription is activated. This field can be updated when **Status** is &#x60;Draft&#x60;. **Character limit**: 29 **Note**: The service activation date is only required if the [Require Service Activation of Orders?](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Default_Subscription_Settings#Require_Service_Activation_of_Orders.3F) Setting is set to &#x60;Yes&#x60;. If this setting is set to &#x60;Yes&#x60;:  - If ContractAcceptanceDate field is required, you must set this field, ContractAcceptanceDate, and ContractEffectiveDate fields in the subscribe call to activate a subscription. - If ContractAcceptanceDate field is not required, you must set both this field and the ContractEffectiveDate field in the subscribe call to activate a subscription. If you only set a valid date in the ContractEffectiveDate field, the subscribe call still returns success, but the subscription is in &#x60;DRAT&#x60; status. </value>
        [DataMember(Name="ServiceActivationDate", EmitDefaultValue=false)]
        public DateTime? ServiceActivationDate { get; set; }
        /// <summary>
        ///  The status of the subscription. **Character limit**: 17 **Values**: automatically generated **Possible values**: one of the following:  - &#x60;Draft&#x60; - &#x60;PendingActivation&#x60; - &#x60;PendingAcceptance&#x60; - &#x60;Active&#x60; - &#x60;Cancelled&#x60; - &#x60;Expired&#x60; - &#x60;Suspended&#x60; (This value is in **Limited Availability**.) 
        /// </summary>
        /// <value> The status of the subscription. **Character limit**: 17 **Values**: automatically generated **Possible values**: one of the following:  - &#x60;Draft&#x60; - &#x60;PendingActivation&#x60; - &#x60;PendingAcceptance&#x60; - &#x60;Active&#x60; - &#x60;Cancelled&#x60; - &#x60;Expired&#x60; - &#x60;Suspended&#x60; (This value is in **Limited Availability**.) </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        ///  The date when the subscription term ends, where the subscription ends at midnight the day before. For example, if the SubscriptionEndDate is 12/31/2016, the subscriptions ends at midnight (00:00:00 hours) on 12/30/2016. This date is the same as the term end date or the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription term ends, where the subscription ends at midnight the day before. For example, if the SubscriptionEndDate is 12/31/2016, the subscriptions ends at midnight (00:00:00 hours) on 12/30/2016. This date is the same as the term end date or the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="SubscriptionEndDate", EmitDefaultValue=false)]
        public DateTime? SubscriptionEndDate { get; set; }
        /// <summary>
        ///  The date when the subscription term starts. This date is the same as the start date of the original term, which isn&#39;t necessarily the start date of the current or new term. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription term starts. This date is the same as the start date of the original term, which isn&#39;t necessarily the start date of the current or new term. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="SubscriptionStartDate", EmitDefaultValue=false)]
        public DateTime? SubscriptionStartDate { get; set; }
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term ends. If the subscription is evergreen, the TermEndDate value is null or is the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term ends. If the subscription is evergreen, the TermEndDate value is null or is the cancelation date, as appropriate. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="TermEndDate", EmitDefaultValue=false)]
        public DateTime? TermEndDate { get; set; }
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term begins. If this is a renewal subscription, then this date is different from the subscription start date. **Character limit**: 29 **Version notes**: - - 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. The date when the subscription term begins. If this is a renewal subscription, then this date is different from the subscription start date. **Character limit**: 29 **Version notes**: - - </value>
        [DataMember(Name="TermStartDate", EmitDefaultValue=false)]
        public DateTime? TermStartDate { get; set; }
        /// <summary>
        ///  This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if a subscription is [termed or evergreen](https://knowledgecenter.zuora.com/BC_Subscription_Management/Subscriptions#Termed_and_Evergreen_Subscriptions). A termed subscription has a specific end date and requires manual renewal. An evergreen subscription doesn&#39;t have an end date and doesn&#39;t need renewal. This field can be updated when the subscription status is Draft. **Character limit**: 9 **Values**: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60; 
        /// </summary>
        /// <value> This field can be updated when **Status** is &#x60;Draft&#x60;. Indicates if a subscription is [termed or evergreen](https://knowledgecenter.zuora.com/BC_Subscription_Management/Subscriptions#Termed_and_Evergreen_Subscriptions). A termed subscription has a specific end date and requires manual renewal. An evergreen subscription doesn&#39;t have an end date and doesn&#39;t need renewal. This field can be updated when the subscription status is Draft. **Character limit**: 9 **Values**: &#x60;TERMED&#x60;, &#x60;EVERGREEN&#x60; </value>
        [DataMember(Name="TermType", EmitDefaultValue=false)]
        public string TermType { get; set; }
        /// <summary>
        ///  The ID of the user who last updated the subscription. **Character limit:** 32 **Values: **automatically generated 
        /// </summary>
        /// <value> The ID of the user who last updated the subscription. **Character limit:** 32 **Values: **automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the subscription was last updated. **Character limit:** 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the subscription was last updated. **Character limit:** 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        ///  The version number of the subscription. **Values**: automatically generated 
        /// </summary>
        /// <value> The version number of the subscription. **Values**: automatically generated </value>
        [DataMember(Name="Version", EmitDefaultValue=false)]
        public int? Version { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetSubscription {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AutoRenew: ").Append(AutoRenew).Append("\n");
            sb.Append("  CancelledDate: ").Append(CancelledDate).Append("\n");
            sb.Append("  ContractAcceptanceDate: ").Append(ContractAcceptanceDate).Append("\n");
            sb.Append("  ContractEffectiveDate: ").Append(ContractEffectiveDate).Append("\n");
            sb.Append("  CpqBundleJsonIdQT: ").Append(CpqBundleJsonIdQT).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CreatorAccountId: ").Append(CreatorAccountId).Append("\n");
            sb.Append("  CreatorInvoiceOwnerId: ").Append(CreatorInvoiceOwnerId).Append("\n");
            sb.Append("  CurrentTerm: ").Append(CurrentTerm).Append("\n");
            sb.Append("  CurrentTermPeriodType: ").Append(CurrentTermPeriodType).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InitialTerm: ").Append(InitialTerm).Append("\n");
            sb.Append("  InitialTermPeriodType: ").Append(InitialTermPeriodType).Append("\n");
            sb.Append("  InvoiceOwnerId: ").Append(InvoiceOwnerId).Append("\n");
            sb.Append("  IsInvoiceSeparate: ").Append(IsInvoiceSeparate).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  OpportunityCloseDateQT: ").Append(OpportunityCloseDateQT).Append("\n");
            sb.Append("  OpportunityNameQT: ").Append(OpportunityNameQT).Append("\n");
            sb.Append("  OriginalCreatedDate: ").Append(OriginalCreatedDate).Append("\n");
            sb.Append("  OriginalId: ").Append(OriginalId).Append("\n");
            sb.Append("  PreviousSubscriptionId: ").Append(PreviousSubscriptionId).Append("\n");
            sb.Append("  QuoteBusinessTypeQT: ").Append(QuoteBusinessTypeQT).Append("\n");
            sb.Append("  QuoteNumberQT: ").Append(QuoteNumberQT).Append("\n");
            sb.Append("  QuoteTypeQT: ").Append(QuoteTypeQT).Append("\n");
            sb.Append("  RenewalSetting: ").Append(RenewalSetting).Append("\n");
            sb.Append("  RenewalTerm: ").Append(RenewalTerm).Append("\n");
            sb.Append("  RenewalTermPeriodType: ").Append(RenewalTermPeriodType).Append("\n");
            sb.Append("  ServiceActivationDate: ").Append(ServiceActivationDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubscriptionEndDate: ").Append(SubscriptionEndDate).Append("\n");
            sb.Append("  SubscriptionStartDate: ").Append(SubscriptionStartDate).Append("\n");
            sb.Append("  TermEndDate: ").Append(TermEndDate).Append("\n");
            sb.Append("  TermStartDate: ").Append(TermStartDate).Append("\n");
            sb.Append("  TermType: ").Append(TermType).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
            return this.Equals(obj as ProxyGetSubscription);
        }

        /// <summary>
        /// Returns true if ProxyGetSubscription instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetSubscription to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetSubscription other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountId == other.AccountId ||
                    this.AccountId != null &&
                    this.AccountId.Equals(other.AccountId)
                ) && 
                (
                    this.AutoRenew == other.AutoRenew ||
                    this.AutoRenew != null &&
                    this.AutoRenew.Equals(other.AutoRenew)
                ) && 
                (
                    this.CancelledDate == other.CancelledDate ||
                    this.CancelledDate != null &&
                    this.CancelledDate.Equals(other.CancelledDate)
                ) && 
                (
                    this.ContractAcceptanceDate == other.ContractAcceptanceDate ||
                    this.ContractAcceptanceDate != null &&
                    this.ContractAcceptanceDate.Equals(other.ContractAcceptanceDate)
                ) && 
                (
                    this.ContractEffectiveDate == other.ContractEffectiveDate ||
                    this.ContractEffectiveDate != null &&
                    this.ContractEffectiveDate.Equals(other.ContractEffectiveDate)
                ) && 
                (
                    this.CpqBundleJsonIdQT == other.CpqBundleJsonIdQT ||
                    this.CpqBundleJsonIdQT != null &&
                    this.CpqBundleJsonIdQT.Equals(other.CpqBundleJsonIdQT)
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
                    this.CreatorAccountId == other.CreatorAccountId ||
                    this.CreatorAccountId != null &&
                    this.CreatorAccountId.Equals(other.CreatorAccountId)
                ) && 
                (
                    this.CreatorInvoiceOwnerId == other.CreatorInvoiceOwnerId ||
                    this.CreatorInvoiceOwnerId != null &&
                    this.CreatorInvoiceOwnerId.Equals(other.CreatorInvoiceOwnerId)
                ) && 
                (
                    this.CurrentTerm == other.CurrentTerm ||
                    this.CurrentTerm != null &&
                    this.CurrentTerm.Equals(other.CurrentTerm)
                ) && 
                (
                    this.CurrentTermPeriodType == other.CurrentTermPeriodType ||
                    this.CurrentTermPeriodType != null &&
                    this.CurrentTermPeriodType.Equals(other.CurrentTermPeriodType)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.InitialTerm == other.InitialTerm ||
                    this.InitialTerm != null &&
                    this.InitialTerm.Equals(other.InitialTerm)
                ) && 
                (
                    this.InitialTermPeriodType == other.InitialTermPeriodType ||
                    this.InitialTermPeriodType != null &&
                    this.InitialTermPeriodType.Equals(other.InitialTermPeriodType)
                ) && 
                (
                    this.InvoiceOwnerId == other.InvoiceOwnerId ||
                    this.InvoiceOwnerId != null &&
                    this.InvoiceOwnerId.Equals(other.InvoiceOwnerId)
                ) && 
                (
                    this.IsInvoiceSeparate == other.IsInvoiceSeparate ||
                    this.IsInvoiceSeparate != null &&
                    this.IsInvoiceSeparate.Equals(other.IsInvoiceSeparate)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) && 
                (
                    this.OpportunityCloseDateQT == other.OpportunityCloseDateQT ||
                    this.OpportunityCloseDateQT != null &&
                    this.OpportunityCloseDateQT.Equals(other.OpportunityCloseDateQT)
                ) && 
                (
                    this.OpportunityNameQT == other.OpportunityNameQT ||
                    this.OpportunityNameQT != null &&
                    this.OpportunityNameQT.Equals(other.OpportunityNameQT)
                ) && 
                (
                    this.OriginalCreatedDate == other.OriginalCreatedDate ||
                    this.OriginalCreatedDate != null &&
                    this.OriginalCreatedDate.Equals(other.OriginalCreatedDate)
                ) && 
                (
                    this.OriginalId == other.OriginalId ||
                    this.OriginalId != null &&
                    this.OriginalId.Equals(other.OriginalId)
                ) && 
                (
                    this.PreviousSubscriptionId == other.PreviousSubscriptionId ||
                    this.PreviousSubscriptionId != null &&
                    this.PreviousSubscriptionId.Equals(other.PreviousSubscriptionId)
                ) && 
                (
                    this.QuoteBusinessTypeQT == other.QuoteBusinessTypeQT ||
                    this.QuoteBusinessTypeQT != null &&
                    this.QuoteBusinessTypeQT.Equals(other.QuoteBusinessTypeQT)
                ) && 
                (
                    this.QuoteNumberQT == other.QuoteNumberQT ||
                    this.QuoteNumberQT != null &&
                    this.QuoteNumberQT.Equals(other.QuoteNumberQT)
                ) && 
                (
                    this.QuoteTypeQT == other.QuoteTypeQT ||
                    this.QuoteTypeQT != null &&
                    this.QuoteTypeQT.Equals(other.QuoteTypeQT)
                ) && 
                (
                    this.RenewalSetting == other.RenewalSetting ||
                    this.RenewalSetting != null &&
                    this.RenewalSetting.Equals(other.RenewalSetting)
                ) && 
                (
                    this.RenewalTerm == other.RenewalTerm ||
                    this.RenewalTerm != null &&
                    this.RenewalTerm.Equals(other.RenewalTerm)
                ) && 
                (
                    this.RenewalTermPeriodType == other.RenewalTermPeriodType ||
                    this.RenewalTermPeriodType != null &&
                    this.RenewalTermPeriodType.Equals(other.RenewalTermPeriodType)
                ) && 
                (
                    this.ServiceActivationDate == other.ServiceActivationDate ||
                    this.ServiceActivationDate != null &&
                    this.ServiceActivationDate.Equals(other.ServiceActivationDate)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.SubscriptionEndDate == other.SubscriptionEndDate ||
                    this.SubscriptionEndDate != null &&
                    this.SubscriptionEndDate.Equals(other.SubscriptionEndDate)
                ) && 
                (
                    this.SubscriptionStartDate == other.SubscriptionStartDate ||
                    this.SubscriptionStartDate != null &&
                    this.SubscriptionStartDate.Equals(other.SubscriptionStartDate)
                ) && 
                (
                    this.TermEndDate == other.TermEndDate ||
                    this.TermEndDate != null &&
                    this.TermEndDate.Equals(other.TermEndDate)
                ) && 
                (
                    this.TermStartDate == other.TermStartDate ||
                    this.TermStartDate != null &&
                    this.TermStartDate.Equals(other.TermStartDate)
                ) && 
                (
                    this.TermType == other.TermType ||
                    this.TermType != null &&
                    this.TermType.Equals(other.TermType)
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
                if (this.AccountId != null)
                    hash = hash * 59 + this.AccountId.GetHashCode();
                if (this.AutoRenew != null)
                    hash = hash * 59 + this.AutoRenew.GetHashCode();
                if (this.CancelledDate != null)
                    hash = hash * 59 + this.CancelledDate.GetHashCode();
                if (this.ContractAcceptanceDate != null)
                    hash = hash * 59 + this.ContractAcceptanceDate.GetHashCode();
                if (this.ContractEffectiveDate != null)
                    hash = hash * 59 + this.ContractEffectiveDate.GetHashCode();
                if (this.CpqBundleJsonIdQT != null)
                    hash = hash * 59 + this.CpqBundleJsonIdQT.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.CreatorAccountId != null)
                    hash = hash * 59 + this.CreatorAccountId.GetHashCode();
                if (this.CreatorInvoiceOwnerId != null)
                    hash = hash * 59 + this.CreatorInvoiceOwnerId.GetHashCode();
                if (this.CurrentTerm != null)
                    hash = hash * 59 + this.CurrentTerm.GetHashCode();
                if (this.CurrentTermPeriodType != null)
                    hash = hash * 59 + this.CurrentTermPeriodType.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.InitialTerm != null)
                    hash = hash * 59 + this.InitialTerm.GetHashCode();
                if (this.InitialTermPeriodType != null)
                    hash = hash * 59 + this.InitialTermPeriodType.GetHashCode();
                if (this.InvoiceOwnerId != null)
                    hash = hash * 59 + this.InvoiceOwnerId.GetHashCode();
                if (this.IsInvoiceSeparate != null)
                    hash = hash * 59 + this.IsInvoiceSeparate.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Notes != null)
                    hash = hash * 59 + this.Notes.GetHashCode();
                if (this.OpportunityCloseDateQT != null)
                    hash = hash * 59 + this.OpportunityCloseDateQT.GetHashCode();
                if (this.OpportunityNameQT != null)
                    hash = hash * 59 + this.OpportunityNameQT.GetHashCode();
                if (this.OriginalCreatedDate != null)
                    hash = hash * 59 + this.OriginalCreatedDate.GetHashCode();
                if (this.OriginalId != null)
                    hash = hash * 59 + this.OriginalId.GetHashCode();
                if (this.PreviousSubscriptionId != null)
                    hash = hash * 59 + this.PreviousSubscriptionId.GetHashCode();
                if (this.QuoteBusinessTypeQT != null)
                    hash = hash * 59 + this.QuoteBusinessTypeQT.GetHashCode();
                if (this.QuoteNumberQT != null)
                    hash = hash * 59 + this.QuoteNumberQT.GetHashCode();
                if (this.QuoteTypeQT != null)
                    hash = hash * 59 + this.QuoteTypeQT.GetHashCode();
                if (this.RenewalSetting != null)
                    hash = hash * 59 + this.RenewalSetting.GetHashCode();
                if (this.RenewalTerm != null)
                    hash = hash * 59 + this.RenewalTerm.GetHashCode();
                if (this.RenewalTermPeriodType != null)
                    hash = hash * 59 + this.RenewalTermPeriodType.GetHashCode();
                if (this.ServiceActivationDate != null)
                    hash = hash * 59 + this.ServiceActivationDate.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.SubscriptionEndDate != null)
                    hash = hash * 59 + this.SubscriptionEndDate.GetHashCode();
                if (this.SubscriptionStartDate != null)
                    hash = hash * 59 + this.SubscriptionStartDate.GetHashCode();
                if (this.TermEndDate != null)
                    hash = hash * 59 + this.TermEndDate.GetHashCode();
                if (this.TermStartDate != null)
                    hash = hash * 59 + this.TermStartDate.GetHashCode();
                if (this.TermType != null)
                    hash = hash * 59 + this.TermType.GetHashCode();
                if (this.UpdatedById != null)
                    hash = hash * 59 + this.UpdatedById.GetHashCode();
                if (this.UpdatedDate != null)
                    hash = hash * 59 + this.UpdatedDate.GetHashCode();
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
