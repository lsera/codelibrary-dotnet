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
    /// ProxyGetCreditBalanceAdjustment
    /// </summary>
    [DataContract]
    public partial class ProxyGetCreditBalanceAdjustment :  IEquatable<ProxyGetCreditBalanceAdjustment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetCreditBalanceAdjustment" /> class.
        /// </summary>
        /// <param name="AccountId"> The account ID of the credit balance&#39;s account. Zuora generates this value from the source transaction. **Character limit**: 32 **V****alues**: automatically generated from:  - CreditBalanceAdjustment.SourceTransactionId or - CreditBalanceAdjustment.SourceTransactionNumber .</param>
        /// <param name="AccountingCode"> The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) .</param>
        /// <param name="AdjustmentDate"> The date when the credit balance adjustment is applied. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Amount"> The amount of the adjustment. **Character limit**: 16 **Values**: a valid currency amount .</param>
        /// <param name="CancelledOn"> The date when the credit balance adjustment was canceled. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Comment"> Use this field to record comments about the credit balance adjustment. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="CreatedById"> The user ID of the person who created the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date when the credit balance adjustmentwas generated. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="IntegrationIdNS">.</param>
        /// <param name="IntegrationStatusNS">.</param>
        /// <param name="Number"> A unique identifier for the credit balance adjustment. Zuora generates this number in the format, &lt;em&gt;CBA-xxxxxxxx&lt;/em&gt;, such as CBA-00375919. **Character limit**: 255 **Values**: automatically generated .</param>
        /// <param name="ReasonCode"> A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **V****alues**: a valid [reason code](/CB_Billing/K_Payment_Operations/Reason_Codes_for_Payment_Operations) .</param>
        /// <param name="ReferenceId"> The ID of the payment that the credit balance adjustment is for. **Character limit**: 32 **Values**: a string of 60 characters or fewer .</param>
        /// <param name="SourceTransactionId"> The ID of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 32 **Values**: one of the following:  - InvoiceId - PaymentId - RefundId .</param>
        /// <param name="SourceTransactionNumber"> The number of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 50 **Values**: one of the following:  - InvoiceNumber - PaymentNumber - RefundNumber .</param>
        /// <param name="SourceTransactionType"> The source of the credit balance adjustment. **Character limit**: **Values**: automatically generated; one of the following:  - Invoice - Payment - Refund .</param>
        /// <param name="Status"> The status of the credit balance adjustment. **Character limit**: 9 **Values**: automatically generated; one of the following:  - Processed - Canceled .</param>
        /// <param name="SyncDateNS">.</param>
        /// <param name="TransferredToAccounting"> Indicates the status of the credit balance adjustment&#39;s transfer to an external accounting system, such as NetSuite. **Character limit**: **Values**: one of the following:  - Processing - Yes - Error - Ignore .</param>
        /// <param name="Type">Create Query Filter.</param>
        /// <param name="UpdatedById"> The ID of the user who last updated the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="UpdatedDate"> The date when the credit balance adjustment was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        public ProxyGetCreditBalanceAdjustment(string AccountId = null, string AccountingCode = null, DateTime? AdjustmentDate = null, double? Amount = null, DateTime? CancelledOn = null, string Comment = null, string CreatedById = null, DateTime? CreatedDate = null, string Id = null, string IntegrationIdNS = null, string IntegrationStatusNS = null, string Number = null, string ReasonCode = null, string ReferenceId = null, string SourceTransactionId = null, string SourceTransactionNumber = null, string SourceTransactionType = null, string Status = null, string SyncDateNS = null, string TransferredToAccounting = null, string Type = null, string UpdatedById = null, DateTime? UpdatedDate = null)
        {
            this.AccountId = AccountId;
            this.AccountingCode = AccountingCode;
            this.AdjustmentDate = AdjustmentDate;
            this.Amount = Amount;
            this.CancelledOn = CancelledOn;
            this.Comment = Comment;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.Id = Id;
            this.IntegrationIdNS = IntegrationIdNS;
            this.IntegrationStatusNS = IntegrationStatusNS;
            this.Number = Number;
            this.ReasonCode = ReasonCode;
            this.ReferenceId = ReferenceId;
            this.SourceTransactionId = SourceTransactionId;
            this.SourceTransactionNumber = SourceTransactionNumber;
            this.SourceTransactionType = SourceTransactionType;
            this.Status = Status;
            this.SyncDateNS = SyncDateNS;
            this.TransferredToAccounting = TransferredToAccounting;
            this.Type = Type;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
        }
        
        /// <summary>
        ///  The account ID of the credit balance&#39;s account. Zuora generates this value from the source transaction. **Character limit**: 32 **V****alues**: automatically generated from:  - CreditBalanceAdjustment.SourceTransactionId or - CreditBalanceAdjustment.SourceTransactionNumber 
        /// </summary>
        /// <value> The account ID of the credit balance&#39;s account. Zuora generates this value from the source transaction. **Character limit**: 32 **V****alues**: automatically generated from:  - CreditBalanceAdjustment.SourceTransactionId or - CreditBalanceAdjustment.SourceTransactionNumber </value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        ///  The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) 
        /// </summary>
        /// <value> The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) </value>
        [DataMember(Name="AccountingCode", EmitDefaultValue=false)]
        public string AccountingCode { get; set; }
        /// <summary>
        ///  The date when the credit balance adjustment is applied. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the credit balance adjustment is applied. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="AdjustmentDate", EmitDefaultValue=false)]
        public DateTime? AdjustmentDate { get; set; }
        /// <summary>
        ///  The amount of the adjustment. **Character limit**: 16 **Values**: a valid currency amount 
        /// </summary>
        /// <value> The amount of the adjustment. **Character limit**: 16 **Values**: a valid currency amount </value>
        [DataMember(Name="Amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }
        /// <summary>
        ///  The date when the credit balance adjustment was canceled. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the credit balance adjustment was canceled. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CancelledOn", EmitDefaultValue=false)]
        public DateTime? CancelledOn { get; set; }
        /// <summary>
        ///  Use this field to record comments about the credit balance adjustment. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> Use this field to record comments about the credit balance adjustment. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="Comment", EmitDefaultValue=false)]
        public string Comment { get; set; }
        /// <summary>
        ///  The user ID of the person who created the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The user ID of the person who created the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date when the credit balance adjustmentwas generated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the credit balance adjustmentwas generated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="IntegrationId__NS", EmitDefaultValue=false)]
        public string IntegrationIdNS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="IntegrationStatus__NS", EmitDefaultValue=false)]
        public string IntegrationStatusNS { get; set; }
        /// <summary>
        ///  A unique identifier for the credit balance adjustment. Zuora generates this number in the format, &lt;em&gt;CBA-xxxxxxxx&lt;/em&gt;, such as CBA-00375919. **Character limit**: 255 **Values**: automatically generated 
        /// </summary>
        /// <value> A unique identifier for the credit balance adjustment. Zuora generates this number in the format, &lt;em&gt;CBA-xxxxxxxx&lt;/em&gt;, such as CBA-00375919. **Character limit**: 255 **Values**: automatically generated </value>
        [DataMember(Name="Number", EmitDefaultValue=false)]
        public string Number { get; set; }
        /// <summary>
        ///  A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **V****alues**: a valid [reason code](/CB_Billing/K_Payment_Operations/Reason_Codes_for_Payment_Operations) 
        /// </summary>
        /// <value> A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **V****alues**: a valid [reason code](/CB_Billing/K_Payment_Operations/Reason_Codes_for_Payment_Operations) </value>
        [DataMember(Name="ReasonCode", EmitDefaultValue=false)]
        public string ReasonCode { get; set; }
        /// <summary>
        ///  The ID of the payment that the credit balance adjustment is for. **Character limit**: 32 **Values**: a string of 60 characters or fewer 
        /// </summary>
        /// <value> The ID of the payment that the credit balance adjustment is for. **Character limit**: 32 **Values**: a string of 60 characters or fewer </value>
        [DataMember(Name="ReferenceId", EmitDefaultValue=false)]
        public string ReferenceId { get; set; }
        /// <summary>
        ///  The ID of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 32 **Values**: one of the following:  - InvoiceId - PaymentId - RefundId 
        /// </summary>
        /// <value> The ID of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 32 **Values**: one of the following:  - InvoiceId - PaymentId - RefundId </value>
        [DataMember(Name="SourceTransactionId", EmitDefaultValue=false)]
        public string SourceTransactionId { get; set; }
        /// <summary>
        ///  The number of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 50 **Values**: one of the following:  - InvoiceNumber - PaymentNumber - RefundNumber 
        /// </summary>
        /// <value> The number of the object that the credit balance adjustment is applied to. You must specify a value for either the &#x60;SourceTransactionId&#x60; field or the &#x60;SourceTransactionNumber&#x60; field. **Character limit**: 50 **Values**: one of the following:  - InvoiceNumber - PaymentNumber - RefundNumber </value>
        [DataMember(Name="SourceTransactionNumber", EmitDefaultValue=false)]
        public string SourceTransactionNumber { get; set; }
        /// <summary>
        ///  The source of the credit balance adjustment. **Character limit**: **Values**: automatically generated; one of the following:  - Invoice - Payment - Refund 
        /// </summary>
        /// <value> The source of the credit balance adjustment. **Character limit**: **Values**: automatically generated; one of the following:  - Invoice - Payment - Refund </value>
        [DataMember(Name="SourceTransactionType", EmitDefaultValue=false)]
        public string SourceTransactionType { get; set; }
        /// <summary>
        ///  The status of the credit balance adjustment. **Character limit**: 9 **Values**: automatically generated; one of the following:  - Processed - Canceled 
        /// </summary>
        /// <value> The status of the credit balance adjustment. **Character limit**: 9 **Values**: automatically generated; one of the following:  - Processed - Canceled </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="SyncDate__NS", EmitDefaultValue=false)]
        public string SyncDateNS { get; set; }
        /// <summary>
        ///  Indicates the status of the credit balance adjustment&#39;s transfer to an external accounting system, such as NetSuite. **Character limit**: **Values**: one of the following:  - Processing - Yes - Error - Ignore 
        /// </summary>
        /// <value> Indicates the status of the credit balance adjustment&#39;s transfer to an external accounting system, such as NetSuite. **Character limit**: **Values**: one of the following:  - Processing - Yes - Error - Ignore </value>
        [DataMember(Name="TransferredToAccounting", EmitDefaultValue=false)]
        public string TransferredToAccounting { get; set; }
        /// <summary>
        /// Create Query Filter
        /// </summary>
        /// <value>Create Query Filter</value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        ///  The ID of the user who last updated the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The ID of the user who last updated the credit balance adjustment. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the credit balance adjustment was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the credit balance adjustment was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetCreditBalanceAdjustment {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  AdjustmentDate: ").Append(AdjustmentDate).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  CancelledOn: ").Append(CancelledOn).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IntegrationIdNS: ").Append(IntegrationIdNS).Append("\n");
            sb.Append("  IntegrationStatusNS: ").Append(IntegrationStatusNS).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  ReasonCode: ").Append(ReasonCode).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  SourceTransactionId: ").Append(SourceTransactionId).Append("\n");
            sb.Append("  SourceTransactionNumber: ").Append(SourceTransactionNumber).Append("\n");
            sb.Append("  SourceTransactionType: ").Append(SourceTransactionType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SyncDateNS: ").Append(SyncDateNS).Append("\n");
            sb.Append("  TransferredToAccounting: ").Append(TransferredToAccounting).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
            return this.Equals(obj as ProxyGetCreditBalanceAdjustment);
        }

        /// <summary>
        /// Returns true if ProxyGetCreditBalanceAdjustment instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetCreditBalanceAdjustment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetCreditBalanceAdjustment other)
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
                    this.AccountingCode == other.AccountingCode ||
                    this.AccountingCode != null &&
                    this.AccountingCode.Equals(other.AccountingCode)
                ) && 
                (
                    this.AdjustmentDate == other.AdjustmentDate ||
                    this.AdjustmentDate != null &&
                    this.AdjustmentDate.Equals(other.AdjustmentDate)
                ) && 
                (
                    this.Amount == other.Amount ||
                    this.Amount != null &&
                    this.Amount.Equals(other.Amount)
                ) && 
                (
                    this.CancelledOn == other.CancelledOn ||
                    this.CancelledOn != null &&
                    this.CancelledOn.Equals(other.CancelledOn)
                ) && 
                (
                    this.Comment == other.Comment ||
                    this.Comment != null &&
                    this.Comment.Equals(other.Comment)
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
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.IntegrationIdNS == other.IntegrationIdNS ||
                    this.IntegrationIdNS != null &&
                    this.IntegrationIdNS.Equals(other.IntegrationIdNS)
                ) && 
                (
                    this.IntegrationStatusNS == other.IntegrationStatusNS ||
                    this.IntegrationStatusNS != null &&
                    this.IntegrationStatusNS.Equals(other.IntegrationStatusNS)
                ) && 
                (
                    this.Number == other.Number ||
                    this.Number != null &&
                    this.Number.Equals(other.Number)
                ) && 
                (
                    this.ReasonCode == other.ReasonCode ||
                    this.ReasonCode != null &&
                    this.ReasonCode.Equals(other.ReasonCode)
                ) && 
                (
                    this.ReferenceId == other.ReferenceId ||
                    this.ReferenceId != null &&
                    this.ReferenceId.Equals(other.ReferenceId)
                ) && 
                (
                    this.SourceTransactionId == other.SourceTransactionId ||
                    this.SourceTransactionId != null &&
                    this.SourceTransactionId.Equals(other.SourceTransactionId)
                ) && 
                (
                    this.SourceTransactionNumber == other.SourceTransactionNumber ||
                    this.SourceTransactionNumber != null &&
                    this.SourceTransactionNumber.Equals(other.SourceTransactionNumber)
                ) && 
                (
                    this.SourceTransactionType == other.SourceTransactionType ||
                    this.SourceTransactionType != null &&
                    this.SourceTransactionType.Equals(other.SourceTransactionType)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.SyncDateNS == other.SyncDateNS ||
                    this.SyncDateNS != null &&
                    this.SyncDateNS.Equals(other.SyncDateNS)
                ) && 
                (
                    this.TransferredToAccounting == other.TransferredToAccounting ||
                    this.TransferredToAccounting != null &&
                    this.TransferredToAccounting.Equals(other.TransferredToAccounting)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
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
                if (this.AccountingCode != null)
                    hash = hash * 59 + this.AccountingCode.GetHashCode();
                if (this.AdjustmentDate != null)
                    hash = hash * 59 + this.AdjustmentDate.GetHashCode();
                if (this.Amount != null)
                    hash = hash * 59 + this.Amount.GetHashCode();
                if (this.CancelledOn != null)
                    hash = hash * 59 + this.CancelledOn.GetHashCode();
                if (this.Comment != null)
                    hash = hash * 59 + this.Comment.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.IntegrationIdNS != null)
                    hash = hash * 59 + this.IntegrationIdNS.GetHashCode();
                if (this.IntegrationStatusNS != null)
                    hash = hash * 59 + this.IntegrationStatusNS.GetHashCode();
                if (this.Number != null)
                    hash = hash * 59 + this.Number.GetHashCode();
                if (this.ReasonCode != null)
                    hash = hash * 59 + this.ReasonCode.GetHashCode();
                if (this.ReferenceId != null)
                    hash = hash * 59 + this.ReferenceId.GetHashCode();
                if (this.SourceTransactionId != null)
                    hash = hash * 59 + this.SourceTransactionId.GetHashCode();
                if (this.SourceTransactionNumber != null)
                    hash = hash * 59 + this.SourceTransactionNumber.GetHashCode();
                if (this.SourceTransactionType != null)
                    hash = hash * 59 + this.SourceTransactionType.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.SyncDateNS != null)
                    hash = hash * 59 + this.SyncDateNS.GetHashCode();
                if (this.TransferredToAccounting != null)
                    hash = hash * 59 + this.TransferredToAccounting.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
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
