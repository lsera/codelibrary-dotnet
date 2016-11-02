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
    /// PUTSubscriptionResumeType
    /// </summary>
    [DataContract]
    public partial class PUTSubscriptionResumeType :  IEquatable<PUTSubscriptionResumeType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PUTSubscriptionResumeType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PUTSubscriptionResumeType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PUTSubscriptionResumeType" /> class.
        /// </summary>
        /// <param name="ApplyCreditBalance">Applies a credit balance to an invoice.  If the value is &#x60;true&#x60;, the credit balance is applied to the invoice. If the value is &#x60;false&#x60;, no action is taken.  Prerequisite: &#x60;invoice&#x60; must be &#x60;true&#x60;.   To view the credit balance adjustment, retrieve the details of the invoice using the Get Invoices method. .</param>
        /// <param name="Collect">Collects an automatic payment for a subscription. The collection generated in this operation is only for this subscription, not for the entire customer account.  If the value is &#x60;true&#x60;, the automatic payment is collected. If the value is &#x60;false&#x60;, no action is taken.  The default value is false.  This field is in Zuora REST API version control. Supported minor versions are 196.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information.  Prerequisite: &#x60;invoice&#x60; must be &#x60;true&#x60;. .</param>
        /// <param name="ContractEffectiveDate">The date when the customer notifies you that they want to resume their subscription. .</param>
        /// <param name="ExtendsTerm">Whether to extend the subscription term by the length of time the suspension is in effect.  Values: &#x60;true&#x60;, &#x60;false&#x60;. .</param>
        /// <param name="Invoice">Creates an invoice for a subscription. The invoice generated in this operation is only for this subscription, not for the entire customer account.  If the value is &#x60;true&#x60;, an invoice is created. If the value is &#x60;false&#x60;, no action is taken.  The default value is &#x60;false&#x60;.  This field is in Zuora REST API version control. Supported minor versions are 196.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information. .</param>
        /// <param name="InvoiceCollect">**Note:** This field has been replaced by the &#x60;invoice&#x60; field and the &#x60;collect&#x60; field. &#x60;invoiceCollect&#x60; is available only for backward compatibility.  If &#x60;true&#x60;, an invoice is generated and payment collected automatically during the subscription process. If &#x60;false&#x60; (default), no invoicing or payment takes place.  The invoice generated in this operation is only for this subscription, not for the entire customer account.  This field is in Zuora REST API version control. Supported minor versions are 186.0, 187.0, 188.0, 189.0, and 196.0. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information. .</param>
        /// <param name="InvoiceTargetDate">If an invoice is to be generated, the date through which to calculate the charges, as yyyy-mm-dd. .</param>
        /// <param name="ResumePeriods">The length of the period used to specify when the subscription is resumed. The subscription resumption takes effect after a specified period based on the suspend date or today&#39;s date. You must use this field together with the &#x60;resumePeriodsType&#x60; field to specify the period.  **Note:** This field is only applicable when the &#x60;suspendPolicy&#x60; field is set to &#x60;FixedPeriodsFromToday&#x60; or &#x60;FixedPeriodsFromSuspendDate&#x60;. .</param>
        /// <param name="ResumePeriodsType">The period type used to define when the subscription resumption takes effect. The subscription resumption takes effect after a specified period based on the suspend date or today&#39;s date. You must use this field together with the &#x60;resumePeriods&#x60; field to specify the period.  Values: &#x60;Day&#x60;, &#x60;Week&#x60;, &#x60;Month&#x60;, &#x60;Year&#x60;  **Note:** This field is only applicable when the &#x60;suspendPolicy&#x60; field is set to &#x60;FixedPeriodsFromToday&#x60; or &#x60;FixedPeriodsFromSuspendDate&#x60;. .</param>
        /// <param name="ResumePolicy">Resume methods. Specify a way to resume a subscription. See [Resume Date](https://knowledgecenter.zuora.com/BC_Subscription_Management/Subscriptions/Resume_a_Subscription#Resume_Date) for more information.  Values:  * &#x60;Today&#x60;: The subscription resumption takes effect on today&#39;s date.  * &#x60;FixedPeriodsFromSuspendDate&#x60;: The subscription resumption takes effect after a specified period based on the suspend date. You must specify the &#x60;resumePeriods&#x60; and &#x60;resumePeriodsType&#x60; fields to define the period.  * &#x60;SpecificDate&#x60;: The subscription resumption takes effect on a specific date. You must define the specific date in the &#x60;resumeSpecificDate&#x60; field.  * &#x60;FixedPeriodsFromToday&#x60;: The subscription resumption takes effect after a specified period based on the today&#39;s date. You must specify the &#x60;resumePeriods&#x60; and &#x60;resumePeriodsType&#x60; fields to define the period.  (required).</param>
        /// <param name="ResumeSpecificDate">A specific date when the subscription resumption takes effect, in the format yyyy-mm-dd.  **Note:** This field is only applicable only when the &#x60;resumePolicy&#x60; field is set to &#x60;SpecificDate&#x60;.  The value should not be earlier than the subscription suspension date. .</param>
        public PUTSubscriptionResumeType(bool? ApplyCreditBalance = null, bool? Collect = null, DateTime? ContractEffectiveDate = null, bool? ExtendsTerm = null, bool? Invoice = null, bool? InvoiceCollect = null, DateTime? InvoiceTargetDate = null, string ResumePeriods = null, string ResumePeriodsType = null, string ResumePolicy = null, DateTime? ResumeSpecificDate = null)
        {
            // to ensure "ResumePolicy" is required (not null)
            if (ResumePolicy == null)
            {
                throw new InvalidDataException("ResumePolicy is a required property for PUTSubscriptionResumeType and cannot be null");
            }
            else
            {
                this.ResumePolicy = ResumePolicy;
            }
            this.ApplyCreditBalance = ApplyCreditBalance;
            this.Collect = Collect;
            this.ContractEffectiveDate = ContractEffectiveDate;
            this.ExtendsTerm = ExtendsTerm;
            this.Invoice = Invoice;
            this.InvoiceCollect = InvoiceCollect;
            this.InvoiceTargetDate = InvoiceTargetDate;
            this.ResumePeriods = ResumePeriods;
            this.ResumePeriodsType = ResumePeriodsType;
            this.ResumeSpecificDate = ResumeSpecificDate;
        }
        
        /// <summary>
        /// Applies a credit balance to an invoice.  If the value is &#x60;true&#x60;, the credit balance is applied to the invoice. If the value is &#x60;false&#x60;, no action is taken.  Prerequisite: &#x60;invoice&#x60; must be &#x60;true&#x60;.   To view the credit balance adjustment, retrieve the details of the invoice using the Get Invoices method. 
        /// </summary>
        /// <value>Applies a credit balance to an invoice.  If the value is &#x60;true&#x60;, the credit balance is applied to the invoice. If the value is &#x60;false&#x60;, no action is taken.  Prerequisite: &#x60;invoice&#x60; must be &#x60;true&#x60;.   To view the credit balance adjustment, retrieve the details of the invoice using the Get Invoices method. </value>
        [DataMember(Name="applyCreditBalance", EmitDefaultValue=false)]
        public bool? ApplyCreditBalance { get; set; }
        /// <summary>
        /// Collects an automatic payment for a subscription. The collection generated in this operation is only for this subscription, not for the entire customer account.  If the value is &#x60;true&#x60;, the automatic payment is collected. If the value is &#x60;false&#x60;, no action is taken.  The default value is false.  This field is in Zuora REST API version control. Supported minor versions are 196.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information.  Prerequisite: &#x60;invoice&#x60; must be &#x60;true&#x60;. 
        /// </summary>
        /// <value>Collects an automatic payment for a subscription. The collection generated in this operation is only for this subscription, not for the entire customer account.  If the value is &#x60;true&#x60;, the automatic payment is collected. If the value is &#x60;false&#x60;, no action is taken.  The default value is false.  This field is in Zuora REST API version control. Supported minor versions are 196.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information.  Prerequisite: &#x60;invoice&#x60; must be &#x60;true&#x60;. </value>
        [DataMember(Name="collect", EmitDefaultValue=false)]
        public bool? Collect { get; set; }
        /// <summary>
        /// The date when the customer notifies you that they want to resume their subscription. 
        /// </summary>
        /// <value>The date when the customer notifies you that they want to resume their subscription. </value>
        [DataMember(Name="contractEffectiveDate", EmitDefaultValue=false)]
        public DateTime? ContractEffectiveDate { get; set; }
        /// <summary>
        /// Whether to extend the subscription term by the length of time the suspension is in effect.  Values: &#x60;true&#x60;, &#x60;false&#x60;. 
        /// </summary>
        /// <value>Whether to extend the subscription term by the length of time the suspension is in effect.  Values: &#x60;true&#x60;, &#x60;false&#x60;. </value>
        [DataMember(Name="extendsTerm", EmitDefaultValue=false)]
        public bool? ExtendsTerm { get; set; }
        /// <summary>
        /// Creates an invoice for a subscription. The invoice generated in this operation is only for this subscription, not for the entire customer account.  If the value is &#x60;true&#x60;, an invoice is created. If the value is &#x60;false&#x60;, no action is taken.  The default value is &#x60;false&#x60;.  This field is in Zuora REST API version control. Supported minor versions are 196.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information. 
        /// </summary>
        /// <value>Creates an invoice for a subscription. The invoice generated in this operation is only for this subscription, not for the entire customer account.  If the value is &#x60;true&#x60;, an invoice is created. If the value is &#x60;false&#x60;, no action is taken.  The default value is &#x60;false&#x60;.  This field is in Zuora REST API version control. Supported minor versions are 196.0 or later. To use this field in the method, you must set the &#x60;zuora-version&#x60; parameter to the minor version number in the request header. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information. </value>
        [DataMember(Name="invoice", EmitDefaultValue=false)]
        public bool? Invoice { get; set; }
        /// <summary>
        /// **Note:** This field has been replaced by the &#x60;invoice&#x60; field and the &#x60;collect&#x60; field. &#x60;invoiceCollect&#x60; is available only for backward compatibility.  If &#x60;true&#x60;, an invoice is generated and payment collected automatically during the subscription process. If &#x60;false&#x60; (default), no invoicing or payment takes place.  The invoice generated in this operation is only for this subscription, not for the entire customer account.  This field is in Zuora REST API version control. Supported minor versions are 186.0, 187.0, 188.0, 189.0, and 196.0. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information. 
        /// </summary>
        /// <value>**Note:** This field has been replaced by the &#x60;invoice&#x60; field and the &#x60;collect&#x60; field. &#x60;invoiceCollect&#x60; is available only for backward compatibility.  If &#x60;true&#x60;, an invoice is generated and payment collected automatically during the subscription process. If &#x60;false&#x60; (default), no invoicing or payment takes place.  The invoice generated in this operation is only for this subscription, not for the entire customer account.  This field is in Zuora REST API version control. Supported minor versions are 186.0, 187.0, 188.0, 189.0, and 196.0. See [Zuora REST API Versions](https://knowledgecenter.zuora.com/DC_Developers/REST_API/A_REST_basics#Zuora_REST_API_Versions) for more information. </value>
        [DataMember(Name="invoiceCollect", EmitDefaultValue=false)]
        public bool? InvoiceCollect { get; set; }
        /// <summary>
        /// If an invoice is to be generated, the date through which to calculate the charges, as yyyy-mm-dd. 
        /// </summary>
        /// <value>If an invoice is to be generated, the date through which to calculate the charges, as yyyy-mm-dd. </value>
        [DataMember(Name="invoiceTargetDate", EmitDefaultValue=false)]
        public DateTime? InvoiceTargetDate { get; set; }
        /// <summary>
        /// The length of the period used to specify when the subscription is resumed. The subscription resumption takes effect after a specified period based on the suspend date or today&#39;s date. You must use this field together with the &#x60;resumePeriodsType&#x60; field to specify the period.  **Note:** This field is only applicable when the &#x60;suspendPolicy&#x60; field is set to &#x60;FixedPeriodsFromToday&#x60; or &#x60;FixedPeriodsFromSuspendDate&#x60;. 
        /// </summary>
        /// <value>The length of the period used to specify when the subscription is resumed. The subscription resumption takes effect after a specified period based on the suspend date or today&#39;s date. You must use this field together with the &#x60;resumePeriodsType&#x60; field to specify the period.  **Note:** This field is only applicable when the &#x60;suspendPolicy&#x60; field is set to &#x60;FixedPeriodsFromToday&#x60; or &#x60;FixedPeriodsFromSuspendDate&#x60;. </value>
        [DataMember(Name="resumePeriods", EmitDefaultValue=false)]
        public string ResumePeriods { get; set; }
        /// <summary>
        /// The period type used to define when the subscription resumption takes effect. The subscription resumption takes effect after a specified period based on the suspend date or today&#39;s date. You must use this field together with the &#x60;resumePeriods&#x60; field to specify the period.  Values: &#x60;Day&#x60;, &#x60;Week&#x60;, &#x60;Month&#x60;, &#x60;Year&#x60;  **Note:** This field is only applicable when the &#x60;suspendPolicy&#x60; field is set to &#x60;FixedPeriodsFromToday&#x60; or &#x60;FixedPeriodsFromSuspendDate&#x60;. 
        /// </summary>
        /// <value>The period type used to define when the subscription resumption takes effect. The subscription resumption takes effect after a specified period based on the suspend date or today&#39;s date. You must use this field together with the &#x60;resumePeriods&#x60; field to specify the period.  Values: &#x60;Day&#x60;, &#x60;Week&#x60;, &#x60;Month&#x60;, &#x60;Year&#x60;  **Note:** This field is only applicable when the &#x60;suspendPolicy&#x60; field is set to &#x60;FixedPeriodsFromToday&#x60; or &#x60;FixedPeriodsFromSuspendDate&#x60;. </value>
        [DataMember(Name="resumePeriodsType", EmitDefaultValue=false)]
        public string ResumePeriodsType { get; set; }
        /// <summary>
        /// Resume methods. Specify a way to resume a subscription. See [Resume Date](https://knowledgecenter.zuora.com/BC_Subscription_Management/Subscriptions/Resume_a_Subscription#Resume_Date) for more information.  Values:  * &#x60;Today&#x60;: The subscription resumption takes effect on today&#39;s date.  * &#x60;FixedPeriodsFromSuspendDate&#x60;: The subscription resumption takes effect after a specified period based on the suspend date. You must specify the &#x60;resumePeriods&#x60; and &#x60;resumePeriodsType&#x60; fields to define the period.  * &#x60;SpecificDate&#x60;: The subscription resumption takes effect on a specific date. You must define the specific date in the &#x60;resumeSpecificDate&#x60; field.  * &#x60;FixedPeriodsFromToday&#x60;: The subscription resumption takes effect after a specified period based on the today&#39;s date. You must specify the &#x60;resumePeriods&#x60; and &#x60;resumePeriodsType&#x60; fields to define the period. 
        /// </summary>
        /// <value>Resume methods. Specify a way to resume a subscription. See [Resume Date](https://knowledgecenter.zuora.com/BC_Subscription_Management/Subscriptions/Resume_a_Subscription#Resume_Date) for more information.  Values:  * &#x60;Today&#x60;: The subscription resumption takes effect on today&#39;s date.  * &#x60;FixedPeriodsFromSuspendDate&#x60;: The subscription resumption takes effect after a specified period based on the suspend date. You must specify the &#x60;resumePeriods&#x60; and &#x60;resumePeriodsType&#x60; fields to define the period.  * &#x60;SpecificDate&#x60;: The subscription resumption takes effect on a specific date. You must define the specific date in the &#x60;resumeSpecificDate&#x60; field.  * &#x60;FixedPeriodsFromToday&#x60;: The subscription resumption takes effect after a specified period based on the today&#39;s date. You must specify the &#x60;resumePeriods&#x60; and &#x60;resumePeriodsType&#x60; fields to define the period. </value>
        [DataMember(Name="resumePolicy", EmitDefaultValue=false)]
        public string ResumePolicy { get; set; }
        /// <summary>
        /// A specific date when the subscription resumption takes effect, in the format yyyy-mm-dd.  **Note:** This field is only applicable only when the &#x60;resumePolicy&#x60; field is set to &#x60;SpecificDate&#x60;.  The value should not be earlier than the subscription suspension date. 
        /// </summary>
        /// <value>A specific date when the subscription resumption takes effect, in the format yyyy-mm-dd.  **Note:** This field is only applicable only when the &#x60;resumePolicy&#x60; field is set to &#x60;SpecificDate&#x60;.  The value should not be earlier than the subscription suspension date. </value>
        [DataMember(Name="resumeSpecificDate", EmitDefaultValue=false)]
        public DateTime? ResumeSpecificDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PUTSubscriptionResumeType {\n");
            sb.Append("  ApplyCreditBalance: ").Append(ApplyCreditBalance).Append("\n");
            sb.Append("  Collect: ").Append(Collect).Append("\n");
            sb.Append("  ContractEffectiveDate: ").Append(ContractEffectiveDate).Append("\n");
            sb.Append("  ExtendsTerm: ").Append(ExtendsTerm).Append("\n");
            sb.Append("  Invoice: ").Append(Invoice).Append("\n");
            sb.Append("  InvoiceCollect: ").Append(InvoiceCollect).Append("\n");
            sb.Append("  InvoiceTargetDate: ").Append(InvoiceTargetDate).Append("\n");
            sb.Append("  ResumePeriods: ").Append(ResumePeriods).Append("\n");
            sb.Append("  ResumePeriodsType: ").Append(ResumePeriodsType).Append("\n");
            sb.Append("  ResumePolicy: ").Append(ResumePolicy).Append("\n");
            sb.Append("  ResumeSpecificDate: ").Append(ResumeSpecificDate).Append("\n");
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
            return this.Equals(obj as PUTSubscriptionResumeType);
        }

        /// <summary>
        /// Returns true if PUTSubscriptionResumeType instances are equal
        /// </summary>
        /// <param name="other">Instance of PUTSubscriptionResumeType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PUTSubscriptionResumeType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ApplyCreditBalance == other.ApplyCreditBalance ||
                    this.ApplyCreditBalance != null &&
                    this.ApplyCreditBalance.Equals(other.ApplyCreditBalance)
                ) && 
                (
                    this.Collect == other.Collect ||
                    this.Collect != null &&
                    this.Collect.Equals(other.Collect)
                ) && 
                (
                    this.ContractEffectiveDate == other.ContractEffectiveDate ||
                    this.ContractEffectiveDate != null &&
                    this.ContractEffectiveDate.Equals(other.ContractEffectiveDate)
                ) && 
                (
                    this.ExtendsTerm == other.ExtendsTerm ||
                    this.ExtendsTerm != null &&
                    this.ExtendsTerm.Equals(other.ExtendsTerm)
                ) && 
                (
                    this.Invoice == other.Invoice ||
                    this.Invoice != null &&
                    this.Invoice.Equals(other.Invoice)
                ) && 
                (
                    this.InvoiceCollect == other.InvoiceCollect ||
                    this.InvoiceCollect != null &&
                    this.InvoiceCollect.Equals(other.InvoiceCollect)
                ) && 
                (
                    this.InvoiceTargetDate == other.InvoiceTargetDate ||
                    this.InvoiceTargetDate != null &&
                    this.InvoiceTargetDate.Equals(other.InvoiceTargetDate)
                ) && 
                (
                    this.ResumePeriods == other.ResumePeriods ||
                    this.ResumePeriods != null &&
                    this.ResumePeriods.Equals(other.ResumePeriods)
                ) && 
                (
                    this.ResumePeriodsType == other.ResumePeriodsType ||
                    this.ResumePeriodsType != null &&
                    this.ResumePeriodsType.Equals(other.ResumePeriodsType)
                ) && 
                (
                    this.ResumePolicy == other.ResumePolicy ||
                    this.ResumePolicy != null &&
                    this.ResumePolicy.Equals(other.ResumePolicy)
                ) && 
                (
                    this.ResumeSpecificDate == other.ResumeSpecificDate ||
                    this.ResumeSpecificDate != null &&
                    this.ResumeSpecificDate.Equals(other.ResumeSpecificDate)
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
                if (this.ApplyCreditBalance != null)
                    hash = hash * 59 + this.ApplyCreditBalance.GetHashCode();
                if (this.Collect != null)
                    hash = hash * 59 + this.Collect.GetHashCode();
                if (this.ContractEffectiveDate != null)
                    hash = hash * 59 + this.ContractEffectiveDate.GetHashCode();
                if (this.ExtendsTerm != null)
                    hash = hash * 59 + this.ExtendsTerm.GetHashCode();
                if (this.Invoice != null)
                    hash = hash * 59 + this.Invoice.GetHashCode();
                if (this.InvoiceCollect != null)
                    hash = hash * 59 + this.InvoiceCollect.GetHashCode();
                if (this.InvoiceTargetDate != null)
                    hash = hash * 59 + this.InvoiceTargetDate.GetHashCode();
                if (this.ResumePeriods != null)
                    hash = hash * 59 + this.ResumePeriods.GetHashCode();
                if (this.ResumePeriodsType != null)
                    hash = hash * 59 + this.ResumePeriodsType.GetHashCode();
                if (this.ResumePolicy != null)
                    hash = hash * 59 + this.ResumePolicy.GetHashCode();
                if (this.ResumeSpecificDate != null)
                    hash = hash * 59 + this.ResumeSpecificDate.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
