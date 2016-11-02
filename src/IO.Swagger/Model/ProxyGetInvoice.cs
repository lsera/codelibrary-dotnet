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
    /// ProxyGetInvoice
    /// </summary>
    [DataContract]
    public partial class ProxyGetInvoice :  IEquatable<ProxyGetInvoice>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetInvoice" /> class.
        /// </summary>
        /// <param name="AccountId">.</param>
        /// <param name="AdjustmentAmount"> The amount of the invoice adjustments associated with the invoice. **Character limi**t: 16 **Values**: a valid currency amount .</param>
        /// <param name="Amount"> The sum of all charges and taxes associated with the invoice. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="AmountWithoutTax"> The sum of all charges associated with the invoice. Taxes are excluded from this value. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="Balance"> The remaining balance of the invoice after all payments, adjustments, and refunds are applied. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="Body"> Required .</param>
        /// <param name="Comments"> Additional information related to the invoice that a Zuora user added to the invoice. **Character limit**: 255 **Values:** a string of 255 characters or fewer .</param>
        /// <param name="CreatedById"> The user ID of the person who created the invoice. If a bill run generated the invoice, then the value is the user ID of person who created the bill run. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date when the invoice was generated. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="CreditBalanceAdjustmentAmount"> The currency amount of the adjustment applied to the customer&#39;s credit balance. **Character limit**: 16 **Values**: a valid currency amount This field is only available if the [Zuora Global Support](http://support.zuora.com/) to enable this feature.   .</param>
        /// <param name="DueDate"> The date by which the payment for this invoice is due. **Character limit**: 29 **Version notes**: - - .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="IncludesOneTime"> Specifies whether the invoice includes one-time charges. You can use this field only with the &#x60;generate()&#x60; call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True&#x60; (default), &#x60;False&#x60; .</param>
        /// <param name="IncludesRecurring"> Specifies whether the invoice includes recurring charges. You can use this field only with the &#x60;generate() &#x60;call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True&#x60; (default), &#x60;False&#x60; .</param>
        /// <param name="IncludesUsage"> Specifies whether the invoice includes usage charges. You can use this field only with the &#x60;generate() &#x60;call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True &#x60;(default), &#x60;False&#x60; .</param>
        /// <param name="InvoiceDate"> Specifies the date on which to generate the invoice. **Character limit**: 29 **Version notes**: - - .</param>
        /// <param name="InvoiceNumber"> The unique identification number for the invoice. This number is returned as a string. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="LastEmailSentDate"> The date when the invoice was last emailed. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="PaymentAmount"> The amount of payments applied to the invoice. **Character limit**: 16 **Value**s: automatically generated .</param>
        /// <param name="PostedBy"> The user ID of the person who moved the invoice to Posted status. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="PostedDate"> The date when the invoice was posted. **Character limit:** 29 **Values**: automatically generated .</param>
        /// <param name="RefundAmount"> Specifies the amount of a refund that was applied against an earlier payment on the invoice. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="Status"> The status of the invoice in the system. This status is not the status of the payment of the invoice, just the status of the invoice itself. **Character limit**: 8 **Values**: one of the following:  -  Draft (default, automatically set upon invoice creation)  -  Posted  -  Canceled  .</param>
        /// <param name="TargetDate"> This date is used to determine which charges are to be billed. All charges that are to be billed on this date or prior will be included in this bill run. **Character limit**: 29 **Version notes**: - - .</param>
        /// <param name="TaxAmount"> The total amount of the taxes applied to the invoice. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="TaxExemptAmount"> The total amount of the invoice that is exempt from taxation. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="TransferredToAccounting"> Specifies whether or not the invoice was transferred to an external accounting system, such as NetSuite. **Character limit**: 10 **Values**: Processing, Yes, Error, Ignore .</param>
        /// <param name="UpdatedById">.</param>
        /// <param name="UpdatedDate"> The date when the invoice was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        public ProxyGetInvoice(string AccountId = null, double? AdjustmentAmount = null, double? Amount = null, double? AmountWithoutTax = null, double? Balance = null, string Body = null, string Comments = null, string CreatedById = null, DateTime? CreatedDate = null, double? CreditBalanceAdjustmentAmount = null, DateTime? DueDate = null, string Id = null, bool? IncludesOneTime = null, bool? IncludesRecurring = null, bool? IncludesUsage = null, DateTime? InvoiceDate = null, string InvoiceNumber = null, DateTime? LastEmailSentDate = null, double? PaymentAmount = null, string PostedBy = null, DateTime? PostedDate = null, double? RefundAmount = null, string Status = null, DateTime? TargetDate = null, double? TaxAmount = null, double? TaxExemptAmount = null, string TransferredToAccounting = null, string UpdatedById = null, DateTime? UpdatedDate = null)
        {
            this.AccountId = AccountId;
            this.AdjustmentAmount = AdjustmentAmount;
            this.Amount = Amount;
            this.AmountWithoutTax = AmountWithoutTax;
            this.Balance = Balance;
            this.Body = Body;
            this.Comments = Comments;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.CreditBalanceAdjustmentAmount = CreditBalanceAdjustmentAmount;
            this.DueDate = DueDate;
            this.Id = Id;
            this.IncludesOneTime = IncludesOneTime;
            this.IncludesRecurring = IncludesRecurring;
            this.IncludesUsage = IncludesUsage;
            this.InvoiceDate = InvoiceDate;
            this.InvoiceNumber = InvoiceNumber;
            this.LastEmailSentDate = LastEmailSentDate;
            this.PaymentAmount = PaymentAmount;
            this.PostedBy = PostedBy;
            this.PostedDate = PostedDate;
            this.RefundAmount = RefundAmount;
            this.Status = Status;
            this.TargetDate = TargetDate;
            this.TaxAmount = TaxAmount;
            this.TaxExemptAmount = TaxExemptAmount;
            this.TransferredToAccounting = TransferredToAccounting;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        ///  The amount of the invoice adjustments associated with the invoice. **Character limi**t: 16 **Values**: a valid currency amount 
        /// </summary>
        /// <value> The amount of the invoice adjustments associated with the invoice. **Character limi**t: 16 **Values**: a valid currency amount </value>
        [DataMember(Name="AdjustmentAmount", EmitDefaultValue=false)]
        public double? AdjustmentAmount { get; set; }
        /// <summary>
        ///  The sum of all charges and taxes associated with the invoice. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The sum of all charges and taxes associated with the invoice. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="Amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }
        /// <summary>
        ///  The sum of all charges associated with the invoice. Taxes are excluded from this value. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The sum of all charges associated with the invoice. Taxes are excluded from this value. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="AmountWithoutTax", EmitDefaultValue=false)]
        public double? AmountWithoutTax { get; set; }
        /// <summary>
        ///  The remaining balance of the invoice after all payments, adjustments, and refunds are applied. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The remaining balance of the invoice after all payments, adjustments, and refunds are applied. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="Balance", EmitDefaultValue=false)]
        public double? Balance { get; set; }
        /// <summary>
        ///  Required 
        /// </summary>
        /// <value> Required </value>
        [DataMember(Name="Body", EmitDefaultValue=false)]
        public string Body { get; set; }
        /// <summary>
        ///  Additional information related to the invoice that a Zuora user added to the invoice. **Character limit**: 255 **Values:** a string of 255 characters or fewer 
        /// </summary>
        /// <value> Additional information related to the invoice that a Zuora user added to the invoice. **Character limit**: 255 **Values:** a string of 255 characters or fewer </value>
        [DataMember(Name="Comments", EmitDefaultValue=false)]
        public string Comments { get; set; }
        /// <summary>
        ///  The user ID of the person who created the invoice. If a bill run generated the invoice, then the value is the user ID of person who created the bill run. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The user ID of the person who created the invoice. If a bill run generated the invoice, then the value is the user ID of person who created the bill run. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date when the invoice was generated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the invoice was generated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///  The currency amount of the adjustment applied to the customer&#39;s credit balance. **Character limit**: 16 **Values**: a valid currency amount This field is only available if the [Zuora Global Support](http://support.zuora.com/) to enable this feature.   
        /// </summary>
        /// <value> The currency amount of the adjustment applied to the customer&#39;s credit balance. **Character limit**: 16 **Values**: a valid currency amount This field is only available if the [Zuora Global Support](http://support.zuora.com/) to enable this feature.   </value>
        [DataMember(Name="CreditBalanceAdjustmentAmount", EmitDefaultValue=false)]
        public double? CreditBalanceAdjustmentAmount { get; set; }
        /// <summary>
        ///  The date by which the payment for this invoice is due. **Character limit**: 29 **Version notes**: - - 
        /// </summary>
        /// <value> The date by which the payment for this invoice is due. **Character limit**: 29 **Version notes**: - - </value>
        [DataMember(Name="DueDate", EmitDefaultValue=false)]
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        ///  Specifies whether the invoice includes one-time charges. You can use this field only with the &#x60;generate()&#x60; call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True&#x60; (default), &#x60;False&#x60; 
        /// </summary>
        /// <value> Specifies whether the invoice includes one-time charges. You can use this field only with the &#x60;generate()&#x60; call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True&#x60; (default), &#x60;False&#x60; </value>
        [DataMember(Name="IncludesOneTime", EmitDefaultValue=false)]
        public bool? IncludesOneTime { get; set; }
        /// <summary>
        ///  Specifies whether the invoice includes recurring charges. You can use this field only with the &#x60;generate() &#x60;call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True&#x60; (default), &#x60;False&#x60; 
        /// </summary>
        /// <value> Specifies whether the invoice includes recurring charges. You can use this field only with the &#x60;generate() &#x60;call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True&#x60; (default), &#x60;False&#x60; </value>
        [DataMember(Name="IncludesRecurring", EmitDefaultValue=false)]
        public bool? IncludesRecurring { get; set; }
        /// <summary>
        ///  Specifies whether the invoice includes usage charges. You can use this field only with the &#x60;generate() &#x60;call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True &#x60;(default), &#x60;False&#x60; 
        /// </summary>
        /// <value> Specifies whether the invoice includes usage charges. You can use this field only with the &#x60;generate() &#x60;call for the Invoice object. **Character limit**: 5 **Values**: automatically generated from one of the following: &#x60;True &#x60;(default), &#x60;False&#x60; </value>
        [DataMember(Name="IncludesUsage", EmitDefaultValue=false)]
        public bool? IncludesUsage { get; set; }
        /// <summary>
        ///  Specifies the date on which to generate the invoice. **Character limit**: 29 **Version notes**: - - 
        /// </summary>
        /// <value> Specifies the date on which to generate the invoice. **Character limit**: 29 **Version notes**: - - </value>
        [DataMember(Name="InvoiceDate", EmitDefaultValue=false)]
        public DateTime? InvoiceDate { get; set; }
        /// <summary>
        ///  The unique identification number for the invoice. This number is returned as a string. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The unique identification number for the invoice. This number is returned as a string. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="InvoiceNumber", EmitDefaultValue=false)]
        public string InvoiceNumber { get; set; }
        /// <summary>
        ///  The date when the invoice was last emailed. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the invoice was last emailed. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="LastEmailSentDate", EmitDefaultValue=false)]
        public DateTime? LastEmailSentDate { get; set; }
        /// <summary>
        ///  The amount of payments applied to the invoice. **Character limit**: 16 **Value**s: automatically generated 
        /// </summary>
        /// <value> The amount of payments applied to the invoice. **Character limit**: 16 **Value**s: automatically generated </value>
        [DataMember(Name="PaymentAmount", EmitDefaultValue=false)]
        public double? PaymentAmount { get; set; }
        /// <summary>
        ///  The user ID of the person who moved the invoice to Posted status. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The user ID of the person who moved the invoice to Posted status. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="PostedBy", EmitDefaultValue=false)]
        public string PostedBy { get; set; }
        /// <summary>
        ///  The date when the invoice was posted. **Character limit:** 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the invoice was posted. **Character limit:** 29 **Values**: automatically generated </value>
        [DataMember(Name="PostedDate", EmitDefaultValue=false)]
        public DateTime? PostedDate { get; set; }
        /// <summary>
        ///  Specifies the amount of a refund that was applied against an earlier payment on the invoice. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> Specifies the amount of a refund that was applied against an earlier payment on the invoice. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="RefundAmount", EmitDefaultValue=false)]
        public double? RefundAmount { get; set; }
        /// <summary>
        ///  The status of the invoice in the system. This status is not the status of the payment of the invoice, just the status of the invoice itself. **Character limit**: 8 **Values**: one of the following:  -  Draft (default, automatically set upon invoice creation)  -  Posted  -  Canceled  
        /// </summary>
        /// <value> The status of the invoice in the system. This status is not the status of the payment of the invoice, just the status of the invoice itself. **Character limit**: 8 **Values**: one of the following:  -  Draft (default, automatically set upon invoice creation)  -  Posted  -  Canceled  </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        ///  This date is used to determine which charges are to be billed. All charges that are to be billed on this date or prior will be included in this bill run. **Character limit**: 29 **Version notes**: - - 
        /// </summary>
        /// <value> This date is used to determine which charges are to be billed. All charges that are to be billed on this date or prior will be included in this bill run. **Character limit**: 29 **Version notes**: - - </value>
        [DataMember(Name="TargetDate", EmitDefaultValue=false)]
        public DateTime? TargetDate { get; set; }
        /// <summary>
        ///  The total amount of the taxes applied to the invoice. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The total amount of the taxes applied to the invoice. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="TaxAmount", EmitDefaultValue=false)]
        public double? TaxAmount { get; set; }
        /// <summary>
        ///  The total amount of the invoice that is exempt from taxation. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The total amount of the invoice that is exempt from taxation. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="TaxExemptAmount", EmitDefaultValue=false)]
        public double? TaxExemptAmount { get; set; }
        /// <summary>
        ///  Specifies whether or not the invoice was transferred to an external accounting system, such as NetSuite. **Character limit**: 10 **Values**: Processing, Yes, Error, Ignore 
        /// </summary>
        /// <value> Specifies whether or not the invoice was transferred to an external accounting system, such as NetSuite. **Character limit**: 10 **Values**: Processing, Yes, Error, Ignore </value>
        [DataMember(Name="TransferredToAccounting", EmitDefaultValue=false)]
        public string TransferredToAccounting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the invoice was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the invoice was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetInvoice {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AdjustmentAmount: ").Append(AdjustmentAmount).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  AmountWithoutTax: ").Append(AmountWithoutTax).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  Comments: ").Append(Comments).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CreditBalanceAdjustmentAmount: ").Append(CreditBalanceAdjustmentAmount).Append("\n");
            sb.Append("  DueDate: ").Append(DueDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludesOneTime: ").Append(IncludesOneTime).Append("\n");
            sb.Append("  IncludesRecurring: ").Append(IncludesRecurring).Append("\n");
            sb.Append("  IncludesUsage: ").Append(IncludesUsage).Append("\n");
            sb.Append("  InvoiceDate: ").Append(InvoiceDate).Append("\n");
            sb.Append("  InvoiceNumber: ").Append(InvoiceNumber).Append("\n");
            sb.Append("  LastEmailSentDate: ").Append(LastEmailSentDate).Append("\n");
            sb.Append("  PaymentAmount: ").Append(PaymentAmount).Append("\n");
            sb.Append("  PostedBy: ").Append(PostedBy).Append("\n");
            sb.Append("  PostedDate: ").Append(PostedDate).Append("\n");
            sb.Append("  RefundAmount: ").Append(RefundAmount).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TargetDate: ").Append(TargetDate).Append("\n");
            sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
            sb.Append("  TaxExemptAmount: ").Append(TaxExemptAmount).Append("\n");
            sb.Append("  TransferredToAccounting: ").Append(TransferredToAccounting).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
            return this.Equals(obj as ProxyGetInvoice);
        }

        /// <summary>
        /// Returns true if ProxyGetInvoice instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetInvoice to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetInvoice other)
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
                    this.AdjustmentAmount == other.AdjustmentAmount ||
                    this.AdjustmentAmount != null &&
                    this.AdjustmentAmount.Equals(other.AdjustmentAmount)
                ) && 
                (
                    this.Amount == other.Amount ||
                    this.Amount != null &&
                    this.Amount.Equals(other.Amount)
                ) && 
                (
                    this.AmountWithoutTax == other.AmountWithoutTax ||
                    this.AmountWithoutTax != null &&
                    this.AmountWithoutTax.Equals(other.AmountWithoutTax)
                ) && 
                (
                    this.Balance == other.Balance ||
                    this.Balance != null &&
                    this.Balance.Equals(other.Balance)
                ) && 
                (
                    this.Body == other.Body ||
                    this.Body != null &&
                    this.Body.Equals(other.Body)
                ) && 
                (
                    this.Comments == other.Comments ||
                    this.Comments != null &&
                    this.Comments.Equals(other.Comments)
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
                    this.CreditBalanceAdjustmentAmount == other.CreditBalanceAdjustmentAmount ||
                    this.CreditBalanceAdjustmentAmount != null &&
                    this.CreditBalanceAdjustmentAmount.Equals(other.CreditBalanceAdjustmentAmount)
                ) && 
                (
                    this.DueDate == other.DueDate ||
                    this.DueDate != null &&
                    this.DueDate.Equals(other.DueDate)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.IncludesOneTime == other.IncludesOneTime ||
                    this.IncludesOneTime != null &&
                    this.IncludesOneTime.Equals(other.IncludesOneTime)
                ) && 
                (
                    this.IncludesRecurring == other.IncludesRecurring ||
                    this.IncludesRecurring != null &&
                    this.IncludesRecurring.Equals(other.IncludesRecurring)
                ) && 
                (
                    this.IncludesUsage == other.IncludesUsage ||
                    this.IncludesUsage != null &&
                    this.IncludesUsage.Equals(other.IncludesUsage)
                ) && 
                (
                    this.InvoiceDate == other.InvoiceDate ||
                    this.InvoiceDate != null &&
                    this.InvoiceDate.Equals(other.InvoiceDate)
                ) && 
                (
                    this.InvoiceNumber == other.InvoiceNumber ||
                    this.InvoiceNumber != null &&
                    this.InvoiceNumber.Equals(other.InvoiceNumber)
                ) && 
                (
                    this.LastEmailSentDate == other.LastEmailSentDate ||
                    this.LastEmailSentDate != null &&
                    this.LastEmailSentDate.Equals(other.LastEmailSentDate)
                ) && 
                (
                    this.PaymentAmount == other.PaymentAmount ||
                    this.PaymentAmount != null &&
                    this.PaymentAmount.Equals(other.PaymentAmount)
                ) && 
                (
                    this.PostedBy == other.PostedBy ||
                    this.PostedBy != null &&
                    this.PostedBy.Equals(other.PostedBy)
                ) && 
                (
                    this.PostedDate == other.PostedDate ||
                    this.PostedDate != null &&
                    this.PostedDate.Equals(other.PostedDate)
                ) && 
                (
                    this.RefundAmount == other.RefundAmount ||
                    this.RefundAmount != null &&
                    this.RefundAmount.Equals(other.RefundAmount)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.TargetDate == other.TargetDate ||
                    this.TargetDate != null &&
                    this.TargetDate.Equals(other.TargetDate)
                ) && 
                (
                    this.TaxAmount == other.TaxAmount ||
                    this.TaxAmount != null &&
                    this.TaxAmount.Equals(other.TaxAmount)
                ) && 
                (
                    this.TaxExemptAmount == other.TaxExemptAmount ||
                    this.TaxExemptAmount != null &&
                    this.TaxExemptAmount.Equals(other.TaxExemptAmount)
                ) && 
                (
                    this.TransferredToAccounting == other.TransferredToAccounting ||
                    this.TransferredToAccounting != null &&
                    this.TransferredToAccounting.Equals(other.TransferredToAccounting)
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
                if (this.AdjustmentAmount != null)
                    hash = hash * 59 + this.AdjustmentAmount.GetHashCode();
                if (this.Amount != null)
                    hash = hash * 59 + this.Amount.GetHashCode();
                if (this.AmountWithoutTax != null)
                    hash = hash * 59 + this.AmountWithoutTax.GetHashCode();
                if (this.Balance != null)
                    hash = hash * 59 + this.Balance.GetHashCode();
                if (this.Body != null)
                    hash = hash * 59 + this.Body.GetHashCode();
                if (this.Comments != null)
                    hash = hash * 59 + this.Comments.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.CreditBalanceAdjustmentAmount != null)
                    hash = hash * 59 + this.CreditBalanceAdjustmentAmount.GetHashCode();
                if (this.DueDate != null)
                    hash = hash * 59 + this.DueDate.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.IncludesOneTime != null)
                    hash = hash * 59 + this.IncludesOneTime.GetHashCode();
                if (this.IncludesRecurring != null)
                    hash = hash * 59 + this.IncludesRecurring.GetHashCode();
                if (this.IncludesUsage != null)
                    hash = hash * 59 + this.IncludesUsage.GetHashCode();
                if (this.InvoiceDate != null)
                    hash = hash * 59 + this.InvoiceDate.GetHashCode();
                if (this.InvoiceNumber != null)
                    hash = hash * 59 + this.InvoiceNumber.GetHashCode();
                if (this.LastEmailSentDate != null)
                    hash = hash * 59 + this.LastEmailSentDate.GetHashCode();
                if (this.PaymentAmount != null)
                    hash = hash * 59 + this.PaymentAmount.GetHashCode();
                if (this.PostedBy != null)
                    hash = hash * 59 + this.PostedBy.GetHashCode();
                if (this.PostedDate != null)
                    hash = hash * 59 + this.PostedDate.GetHashCode();
                if (this.RefundAmount != null)
                    hash = hash * 59 + this.RefundAmount.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.TargetDate != null)
                    hash = hash * 59 + this.TargetDate.GetHashCode();
                if (this.TaxAmount != null)
                    hash = hash * 59 + this.TaxAmount.GetHashCode();
                if (this.TaxExemptAmount != null)
                    hash = hash * 59 + this.TaxExemptAmount.GetHashCode();
                if (this.TransferredToAccounting != null)
                    hash = hash * 59 + this.TransferredToAccounting.GetHashCode();
                if (this.UpdatedById != null)
                    hash = hash * 59 + this.UpdatedById.GetHashCode();
                if (this.UpdatedDate != null)
                    hash = hash * 59 + this.UpdatedDate.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
