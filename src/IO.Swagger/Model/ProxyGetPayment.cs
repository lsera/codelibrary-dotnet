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
    /// ProxyGetPayment
    /// </summary>
    [DataContract]
    public partial class ProxyGetPayment :  IEquatable<ProxyGetPayment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetPayment" /> class.
        /// </summary>
        /// <param name="AccountId"> The unique account ID for the customer that the payment is for. **Character limit**: 32 **Values**: a valid [account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) .</param>
        /// <param name="AccountingCode"> The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) .</param>
        /// <param name="Amount"> The amount of the payment. **Character limit**: 16 **Values**: a valid currency value .</param>
        /// <param name="AppliedCreditBalanceAmount"> The amount of the payment to apply to a credit balance. This field is required in a create() call when the &#x60;AppliedInvoiceAmount&#x60; field value is null. **Character limit**: 16 **Values**: a valid currency value .</param>
        /// <param name="AuthTransactionId"> The authorization transaction ID from the payment gateway. Use this field for electronic payments, such as credit cards. **Character limit**: 50 **Values**: a string of 50 characters or fewer .</param>
        /// <param name="BankIdentificationNumber"> The first six digits of the credit card or debit card used for the payment, when applicable. Use this field to [reconcile payments between the gateway and merchant banks](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/d_Reconciling_Payments_with_Merchant_Accounts). **Character limit**: 6 **Values**: automatically generated .</param>
        /// <param name="CancelledOn"> The date when the payment was canceled. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Comment"> Additional information related to the payment. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="CreatedById"> The user ID of the person who created the &#x60;Payment&#x60; object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date when the Payment object was created in the Zuora system. **Character limit**: 29 **Values** automatically generated .</param>
        /// <param name="EffectiveDate"> The date when the payment takes effect. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) .</param>
        /// <param name="Gateway"> Name of the [gateway](/C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways) instance that processes the payment. When creating a Payment, this must be a valid gateway instance name and this gateway must support the specific payment method. If not specified, the default gateway on the Account will be used. .</param>
        /// <param name="GatewayOrderId"> A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created. If not specified, the PaymentNumber will be passed in instead. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="GatewayResponse"> The message returned from the payment gateway for the payment. This message is gateway-dependent. **Character limit**: 500 **Values**: automatically generated .</param>
        /// <param name="GatewayResponseCode"> The code returned from the payment gateway for the payment. This code is gateway-dependent. **Character limit**: 20 **Values**: automatically generated .</param>
        /// <param name="GatewayState"> The status of the payment in the gateway; use for reconciliation. **Character limit**: 19 **Values**: automatically generated .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="MarkedForSubmissionOn"> The date when a payment was marked and waiting for batch submission to the payment process. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="PaymentMethodId"> The ID of the payment method used for the payment. Required for Create. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="PaymentMethodSnapshotId"> The unique ID of the payment method snapshot which is a copy of the particular Payment Method used in a transaction. **Character limit**: 32 **V****alues**: a valid [payment method snapshot ID](http://knowledgecenter.zuora.com/D_SOAP_API/E_SOAP_API_Objects/PaymentMethod_Snapshot) .</param>
        /// <param name="PaymentNumber"> The unique identification number of a payment. For example: P-00000028. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="ReferenceId"> The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Z-Payments. **Character limit**: 60 **Values**: a string of 60 characters or fewer .</param>
        /// <param name="RefundAmount"> The amount of the payment that is refunded. This field is null if no refund is made against the payment. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="SecondPaymentReferenceId"> The transaction ID returned by the payment gateway if there is an additional transaction for the payment. Use this field to reconcile payments between your gateway and Z-Payments. **Character limit**: 60 **Values**: a string of 60 characters or fewer .</param>
        /// <param name="SettledOn"> The date when the payment was settled in the payment processor. This field is used by the Spectrum gateway only and not applicable to other gateways. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="SoftDescriptor"> [A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/Verifi_Global_Payment_Gateway#Soft_Descriptors_(Optional)). **Character limit**: 35 **Values**: &#x60;[SDMerchantName]*[SDProductionInfo]&#x60; .</param>
        /// <param name="SoftDescriptorPhone"> [A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/Verifi_Global_Payment_Gateway#Soft_Descriptors_(Optional)). **Character limit**: 20 **Values**: &#x60;[SDPhone]&#x60; .</param>
        /// <param name="Source"> Indicates how the payment was created, whether through API, manually, import, or payment run. **Character limit**: **Values**: Payment Run, Import, Manually, and API .</param>
        /// <param name="SourceName"> Name of the source. **Character limit**: **Values**: Payment Run number or a file name. .</param>
        /// <param name="Status"> The status of the payment in Zuora. The value depends on the type of payment. **Character limit**: 11 **Values**: one of the following:  -  Electronic payments: &#x60;Processed&#x60;, &#x60;Error&#x60;, &#x60;Voided&#x60;  -  External payments: &#x60;Processed&#x60;, &#x60;Canceled&#x60;  See [Troubleshooting Payment Runs](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/CA_Payment_Runs/Troubleshooting_Payment_Runs) for more information. * Update of status can change value from &#x60;Processed&#x60; to &#x60;Canceled&#x60; when the payment type is external. .</param>
        /// <param name="SubmittedOn"> The date when the payment was submitted. **Character limit****:** 29 **Values**: automatically generated .</param>
        /// <param name="TransferredToAccounting"> Indicates if the payment was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. **Character limit**: 11 **Values**: &#x60;Processing&#x60;, &#x60;Yes&#x60;, &#x60;Error&#x60;, &#x60;Ignore&#x60; .</param>
        /// <param name="Type"> Indicates if the payment is external or electronic. **Character limit**: 10 **Values**: &#x60;External&#x60;, &#x60;Electronic&#x60; .</param>
        /// <param name="UpdatedById"> The ID of the user who last updated the payment. **Character limit**: **Values**: automatically generated .</param>
        /// <param name="UpdatedDate"> The date when the payment was last updated. **Character limit**: **Values** **Values**: automatically generated .</param>
        public ProxyGetPayment(string AccountId = null, string AccountingCode = null, double? Amount = null, double? AppliedCreditBalanceAmount = null, string AuthTransactionId = null, string BankIdentificationNumber = null, DateTime? CancelledOn = null, string Comment = null, string CreatedById = null, DateTime? CreatedDate = null, DateTime? EffectiveDate = null, string Gateway = null, string GatewayOrderId = null, string GatewayResponse = null, string GatewayResponseCode = null, string GatewayState = null, string Id = null, DateTime? MarkedForSubmissionOn = null, string PaymentMethodId = null, string PaymentMethodSnapshotId = null, string PaymentNumber = null, string ReferenceId = null, double? RefundAmount = null, string SecondPaymentReferenceId = null, DateTime? SettledOn = null, string SoftDescriptor = null, string SoftDescriptorPhone = null, string Source = null, string SourceName = null, string Status = null, DateTime? SubmittedOn = null, string TransferredToAccounting = null, string Type = null, string UpdatedById = null, DateTime? UpdatedDate = null)
        {
            this.AccountId = AccountId;
            this.AccountingCode = AccountingCode;
            this.Amount = Amount;
            this.AppliedCreditBalanceAmount = AppliedCreditBalanceAmount;
            this.AuthTransactionId = AuthTransactionId;
            this.BankIdentificationNumber = BankIdentificationNumber;
            this.CancelledOn = CancelledOn;
            this.Comment = Comment;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.EffectiveDate = EffectiveDate;
            this.Gateway = Gateway;
            this.GatewayOrderId = GatewayOrderId;
            this.GatewayResponse = GatewayResponse;
            this.GatewayResponseCode = GatewayResponseCode;
            this.GatewayState = GatewayState;
            this.Id = Id;
            this.MarkedForSubmissionOn = MarkedForSubmissionOn;
            this.PaymentMethodId = PaymentMethodId;
            this.PaymentMethodSnapshotId = PaymentMethodSnapshotId;
            this.PaymentNumber = PaymentNumber;
            this.ReferenceId = ReferenceId;
            this.RefundAmount = RefundAmount;
            this.SecondPaymentReferenceId = SecondPaymentReferenceId;
            this.SettledOn = SettledOn;
            this.SoftDescriptor = SoftDescriptor;
            this.SoftDescriptorPhone = SoftDescriptorPhone;
            this.Source = Source;
            this.SourceName = SourceName;
            this.Status = Status;
            this.SubmittedOn = SubmittedOn;
            this.TransferredToAccounting = TransferredToAccounting;
            this.Type = Type;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
        }
        
        /// <summary>
        ///  The unique account ID for the customer that the payment is for. **Character limit**: 32 **Values**: a valid [account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) 
        /// </summary>
        /// <value> The unique account ID for the customer that the payment is for. **Character limit**: 32 **Values**: a valid [account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) </value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        ///  The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) 
        /// </summary>
        /// <value> The [Chart of Accounts](/CB_Billing/W_Billing_and_Payments_Settings/V_Configure_Accounting_Codes/D_Set_Up_Chart_of_Accounts) </value>
        [DataMember(Name="AccountingCode", EmitDefaultValue=false)]
        public string AccountingCode { get; set; }
        /// <summary>
        ///  The amount of the payment. **Character limit**: 16 **Values**: a valid currency value 
        /// </summary>
        /// <value> The amount of the payment. **Character limit**: 16 **Values**: a valid currency value </value>
        [DataMember(Name="Amount", EmitDefaultValue=false)]
        public double? Amount { get; set; }
        /// <summary>
        ///  The amount of the payment to apply to a credit balance. This field is required in a create() call when the &#x60;AppliedInvoiceAmount&#x60; field value is null. **Character limit**: 16 **Values**: a valid currency value 
        /// </summary>
        /// <value> The amount of the payment to apply to a credit balance. This field is required in a create() call when the &#x60;AppliedInvoiceAmount&#x60; field value is null. **Character limit**: 16 **Values**: a valid currency value </value>
        [DataMember(Name="AppliedCreditBalanceAmount", EmitDefaultValue=false)]
        public double? AppliedCreditBalanceAmount { get; set; }
        /// <summary>
        ///  The authorization transaction ID from the payment gateway. Use this field for electronic payments, such as credit cards. **Character limit**: 50 **Values**: a string of 50 characters or fewer 
        /// </summary>
        /// <value> The authorization transaction ID from the payment gateway. Use this field for electronic payments, such as credit cards. **Character limit**: 50 **Values**: a string of 50 characters or fewer </value>
        [DataMember(Name="AuthTransactionId", EmitDefaultValue=false)]
        public string AuthTransactionId { get; set; }
        /// <summary>
        ///  The first six digits of the credit card or debit card used for the payment, when applicable. Use this field to [reconcile payments between the gateway and merchant banks](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/d_Reconciling_Payments_with_Merchant_Accounts). **Character limit**: 6 **Values**: automatically generated 
        /// </summary>
        /// <value> The first six digits of the credit card or debit card used for the payment, when applicable. Use this field to [reconcile payments between the gateway and merchant banks](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/d_Reconciling_Payments_with_Merchant_Accounts). **Character limit**: 6 **Values**: automatically generated </value>
        [DataMember(Name="BankIdentificationNumber", EmitDefaultValue=false)]
        public string BankIdentificationNumber { get; set; }
        /// <summary>
        ///  The date when the payment was canceled. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the payment was canceled. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CancelledOn", EmitDefaultValue=false)]
        public DateTime? CancelledOn { get; set; }
        /// <summary>
        ///  Additional information related to the payment. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> Additional information related to the payment. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="Comment", EmitDefaultValue=false)]
        public string Comment { get; set; }
        /// <summary>
        ///  The user ID of the person who created the &#x60;Payment&#x60; object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The user ID of the person who created the &#x60;Payment&#x60; object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date when the Payment object was created in the Zuora system. **Character limit**: 29 **Values** automatically generated 
        /// </summary>
        /// <value> The date when the Payment object was created in the Zuora system. **Character limit**: 29 **Values** automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///  The date when the payment takes effect. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) 
        /// </summary>
        /// <value> The date when the payment takes effect. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) </value>
        [DataMember(Name="EffectiveDate", EmitDefaultValue=false)]
        public DateTime? EffectiveDate { get; set; }
        /// <summary>
        ///  Name of the [gateway](/C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways) instance that processes the payment. When creating a Payment, this must be a valid gateway instance name and this gateway must support the specific payment method. If not specified, the default gateway on the Account will be used. 
        /// </summary>
        /// <value> Name of the [gateway](/C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways) instance that processes the payment. When creating a Payment, this must be a valid gateway instance name and this gateway must support the specific payment method. If not specified, the default gateway on the Account will be used. </value>
        [DataMember(Name="Gateway", EmitDefaultValue=false)]
        public string Gateway { get; set; }
        /// <summary>
        ///  A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created. If not specified, the PaymentNumber will be passed in instead. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> A merchant-specified natural key value that can be passed to the electronic payment gateway when a payment is created. If not specified, the PaymentNumber will be passed in instead. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name="GatewayOrderId", EmitDefaultValue=false)]
        public string GatewayOrderId { get; set; }
        /// <summary>
        ///  The message returned from the payment gateway for the payment. This message is gateway-dependent. **Character limit**: 500 **Values**: automatically generated 
        /// </summary>
        /// <value> The message returned from the payment gateway for the payment. This message is gateway-dependent. **Character limit**: 500 **Values**: automatically generated </value>
        [DataMember(Name="GatewayResponse", EmitDefaultValue=false)]
        public string GatewayResponse { get; set; }
        /// <summary>
        ///  The code returned from the payment gateway for the payment. This code is gateway-dependent. **Character limit**: 20 **Values**: automatically generated 
        /// </summary>
        /// <value> The code returned from the payment gateway for the payment. This code is gateway-dependent. **Character limit**: 20 **Values**: automatically generated </value>
        [DataMember(Name="GatewayResponseCode", EmitDefaultValue=false)]
        public string GatewayResponseCode { get; set; }
        /// <summary>
        ///  The status of the payment in the gateway; use for reconciliation. **Character limit**: 19 **Values**: automatically generated 
        /// </summary>
        /// <value> The status of the payment in the gateway; use for reconciliation. **Character limit**: 19 **Values**: automatically generated </value>
        [DataMember(Name="GatewayState", EmitDefaultValue=false)]
        public string GatewayState { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        ///  The date when a payment was marked and waiting for batch submission to the payment process. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when a payment was marked and waiting for batch submission to the payment process. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="MarkedForSubmissionOn", EmitDefaultValue=false)]
        public DateTime? MarkedForSubmissionOn { get; set; }
        /// <summary>
        ///  The ID of the payment method used for the payment. Required for Create. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The ID of the payment method used for the payment. Required for Create. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="PaymentMethodId", EmitDefaultValue=false)]
        public string PaymentMethodId { get; set; }
        /// <summary>
        ///  The unique ID of the payment method snapshot which is a copy of the particular Payment Method used in a transaction. **Character limit**: 32 **V****alues**: a valid [payment method snapshot ID](http://knowledgecenter.zuora.com/D_SOAP_API/E_SOAP_API_Objects/PaymentMethod_Snapshot) 
        /// </summary>
        /// <value> The unique ID of the payment method snapshot which is a copy of the particular Payment Method used in a transaction. **Character limit**: 32 **V****alues**: a valid [payment method snapshot ID](http://knowledgecenter.zuora.com/D_SOAP_API/E_SOAP_API_Objects/PaymentMethod_Snapshot) </value>
        [DataMember(Name="PaymentMethodSnapshotId", EmitDefaultValue=false)]
        public string PaymentMethodSnapshotId { get; set; }
        /// <summary>
        ///  The unique identification number of a payment. For example: P-00000028. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The unique identification number of a payment. For example: P-00000028. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="PaymentNumber", EmitDefaultValue=false)]
        public string PaymentNumber { get; set; }
        /// <summary>
        ///  The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Z-Payments. **Character limit**: 60 **Values**: a string of 60 characters or fewer 
        /// </summary>
        /// <value> The transaction ID returned by the payment gateway. Use this field to reconcile payments between your gateway and Z-Payments. **Character limit**: 60 **Values**: a string of 60 characters or fewer </value>
        [DataMember(Name="ReferenceId", EmitDefaultValue=false)]
        public string ReferenceId { get; set; }
        /// <summary>
        ///  The amount of the payment that is refunded. This field is null if no refund is made against the payment. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value> The amount of the payment that is refunded. This field is null if no refund is made against the payment. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="RefundAmount", EmitDefaultValue=false)]
        public double? RefundAmount { get; set; }
        /// <summary>
        ///  The transaction ID returned by the payment gateway if there is an additional transaction for the payment. Use this field to reconcile payments between your gateway and Z-Payments. **Character limit**: 60 **Values**: a string of 60 characters or fewer 
        /// </summary>
        /// <value> The transaction ID returned by the payment gateway if there is an additional transaction for the payment. Use this field to reconcile payments between your gateway and Z-Payments. **Character limit**: 60 **Values**: a string of 60 characters or fewer </value>
        [DataMember(Name="SecondPaymentReferenceId", EmitDefaultValue=false)]
        public string SecondPaymentReferenceId { get; set; }
        /// <summary>
        ///  The date when the payment was settled in the payment processor. This field is used by the Spectrum gateway only and not applicable to other gateways. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the payment was settled in the payment processor. This field is used by the Spectrum gateway only and not applicable to other gateways. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="SettledOn", EmitDefaultValue=false)]
        public DateTime? SettledOn { get; set; }
        /// <summary>
        ///  [A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/Verifi_Global_Payment_Gateway#Soft_Descriptors_(Optional)). **Character limit**: 35 **Values**: &#x60;[SDMerchantName]*[SDProductionInfo]&#x60; 
        /// </summary>
        /// <value> [A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/Verifi_Global_Payment_Gateway#Soft_Descriptors_(Optional)). **Character limit**: 35 **Values**: &#x60;[SDMerchantName]*[SDProductionInfo]&#x60; </value>
        [DataMember(Name="SoftDescriptor", EmitDefaultValue=false)]
        public string SoftDescriptor { get; set; }
        /// <summary>
        ///  [A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/Verifi_Global_Payment_Gateway#Soft_Descriptors_(Optional)). **Character limit**: 20 **Values**: &#x60;[SDPhone]&#x60; 
        /// </summary>
        /// <value> [A payment gateway-specific field that maps to Zuora for the gateways, Orbital, Vantiv and Verifi](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways/Verifi_Global_Payment_Gateway#Soft_Descriptors_(Optional)). **Character limit**: 20 **Values**: &#x60;[SDPhone]&#x60; </value>
        [DataMember(Name="SoftDescriptorPhone", EmitDefaultValue=false)]
        public string SoftDescriptorPhone { get; set; }
        /// <summary>
        ///  Indicates how the payment was created, whether through API, manually, import, or payment run. **Character limit**: **Values**: Payment Run, Import, Manually, and API 
        /// </summary>
        /// <value> Indicates how the payment was created, whether through API, manually, import, or payment run. **Character limit**: **Values**: Payment Run, Import, Manually, and API </value>
        [DataMember(Name="Source", EmitDefaultValue=false)]
        public string Source { get; set; }
        /// <summary>
        ///  Name of the source. **Character limit**: **Values**: Payment Run number or a file name. 
        /// </summary>
        /// <value> Name of the source. **Character limit**: **Values**: Payment Run number or a file name. </value>
        [DataMember(Name="SourceName", EmitDefaultValue=false)]
        public string SourceName { get; set; }
        /// <summary>
        ///  The status of the payment in Zuora. The value depends on the type of payment. **Character limit**: 11 **Values**: one of the following:  -  Electronic payments: &#x60;Processed&#x60;, &#x60;Error&#x60;, &#x60;Voided&#x60;  -  External payments: &#x60;Processed&#x60;, &#x60;Canceled&#x60;  See [Troubleshooting Payment Runs](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/CA_Payment_Runs/Troubleshooting_Payment_Runs) for more information. * Update of status can change value from &#x60;Processed&#x60; to &#x60;Canceled&#x60; when the payment type is external. 
        /// </summary>
        /// <value> The status of the payment in Zuora. The value depends on the type of payment. **Character limit**: 11 **Values**: one of the following:  -  Electronic payments: &#x60;Processed&#x60;, &#x60;Error&#x60;, &#x60;Voided&#x60;  -  External payments: &#x60;Processed&#x60;, &#x60;Canceled&#x60;  See [Troubleshooting Payment Runs](https://knowledgecenter.zuora.com/CB_Billing/K_Payment_Operations/CA_Payment_Runs/Troubleshooting_Payment_Runs) for more information. * Update of status can change value from &#x60;Processed&#x60; to &#x60;Canceled&#x60; when the payment type is external. </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        ///  The date when the payment was submitted. **Character limit****:** 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the payment was submitted. **Character limit****:** 29 **Values**: automatically generated </value>
        [DataMember(Name="SubmittedOn", EmitDefaultValue=false)]
        public DateTime? SubmittedOn { get; set; }
        /// <summary>
        ///  Indicates if the payment was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. **Character limit**: 11 **Values**: &#x60;Processing&#x60;, &#x60;Yes&#x60;, &#x60;Error&#x60;, &#x60;Ignore&#x60; 
        /// </summary>
        /// <value> Indicates if the payment was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. **Character limit**: 11 **Values**: &#x60;Processing&#x60;, &#x60;Yes&#x60;, &#x60;Error&#x60;, &#x60;Ignore&#x60; </value>
        [DataMember(Name="TransferredToAccounting", EmitDefaultValue=false)]
        public string TransferredToAccounting { get; set; }
        /// <summary>
        ///  Indicates if the payment is external or electronic. **Character limit**: 10 **Values**: &#x60;External&#x60;, &#x60;Electronic&#x60; 
        /// </summary>
        /// <value> Indicates if the payment is external or electronic. **Character limit**: 10 **Values**: &#x60;External&#x60;, &#x60;Electronic&#x60; </value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        ///  The ID of the user who last updated the payment. **Character limit**: **Values**: automatically generated 
        /// </summary>
        /// <value> The ID of the user who last updated the payment. **Character limit**: **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the payment was last updated. **Character limit**: **Values** **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the payment was last updated. **Character limit**: **Values** **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetPayment {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  AppliedCreditBalanceAmount: ").Append(AppliedCreditBalanceAmount).Append("\n");
            sb.Append("  AuthTransactionId: ").Append(AuthTransactionId).Append("\n");
            sb.Append("  BankIdentificationNumber: ").Append(BankIdentificationNumber).Append("\n");
            sb.Append("  CancelledOn: ").Append(CancelledOn).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  EffectiveDate: ").Append(EffectiveDate).Append("\n");
            sb.Append("  Gateway: ").Append(Gateway).Append("\n");
            sb.Append("  GatewayOrderId: ").Append(GatewayOrderId).Append("\n");
            sb.Append("  GatewayResponse: ").Append(GatewayResponse).Append("\n");
            sb.Append("  GatewayResponseCode: ").Append(GatewayResponseCode).Append("\n");
            sb.Append("  GatewayState: ").Append(GatewayState).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MarkedForSubmissionOn: ").Append(MarkedForSubmissionOn).Append("\n");
            sb.Append("  PaymentMethodId: ").Append(PaymentMethodId).Append("\n");
            sb.Append("  PaymentMethodSnapshotId: ").Append(PaymentMethodSnapshotId).Append("\n");
            sb.Append("  PaymentNumber: ").Append(PaymentNumber).Append("\n");
            sb.Append("  ReferenceId: ").Append(ReferenceId).Append("\n");
            sb.Append("  RefundAmount: ").Append(RefundAmount).Append("\n");
            sb.Append("  SecondPaymentReferenceId: ").Append(SecondPaymentReferenceId).Append("\n");
            sb.Append("  SettledOn: ").Append(SettledOn).Append("\n");
            sb.Append("  SoftDescriptor: ").Append(SoftDescriptor).Append("\n");
            sb.Append("  SoftDescriptorPhone: ").Append(SoftDescriptorPhone).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  SourceName: ").Append(SourceName).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubmittedOn: ").Append(SubmittedOn).Append("\n");
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
            return this.Equals(obj as ProxyGetPayment);
        }

        /// <summary>
        /// Returns true if ProxyGetPayment instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetPayment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetPayment other)
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
                    this.Amount == other.Amount ||
                    this.Amount != null &&
                    this.Amount.Equals(other.Amount)
                ) && 
                (
                    this.AppliedCreditBalanceAmount == other.AppliedCreditBalanceAmount ||
                    this.AppliedCreditBalanceAmount != null &&
                    this.AppliedCreditBalanceAmount.Equals(other.AppliedCreditBalanceAmount)
                ) && 
                (
                    this.AuthTransactionId == other.AuthTransactionId ||
                    this.AuthTransactionId != null &&
                    this.AuthTransactionId.Equals(other.AuthTransactionId)
                ) && 
                (
                    this.BankIdentificationNumber == other.BankIdentificationNumber ||
                    this.BankIdentificationNumber != null &&
                    this.BankIdentificationNumber.Equals(other.BankIdentificationNumber)
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
                    this.EffectiveDate == other.EffectiveDate ||
                    this.EffectiveDate != null &&
                    this.EffectiveDate.Equals(other.EffectiveDate)
                ) && 
                (
                    this.Gateway == other.Gateway ||
                    this.Gateway != null &&
                    this.Gateway.Equals(other.Gateway)
                ) && 
                (
                    this.GatewayOrderId == other.GatewayOrderId ||
                    this.GatewayOrderId != null &&
                    this.GatewayOrderId.Equals(other.GatewayOrderId)
                ) && 
                (
                    this.GatewayResponse == other.GatewayResponse ||
                    this.GatewayResponse != null &&
                    this.GatewayResponse.Equals(other.GatewayResponse)
                ) && 
                (
                    this.GatewayResponseCode == other.GatewayResponseCode ||
                    this.GatewayResponseCode != null &&
                    this.GatewayResponseCode.Equals(other.GatewayResponseCode)
                ) && 
                (
                    this.GatewayState == other.GatewayState ||
                    this.GatewayState != null &&
                    this.GatewayState.Equals(other.GatewayState)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.MarkedForSubmissionOn == other.MarkedForSubmissionOn ||
                    this.MarkedForSubmissionOn != null &&
                    this.MarkedForSubmissionOn.Equals(other.MarkedForSubmissionOn)
                ) && 
                (
                    this.PaymentMethodId == other.PaymentMethodId ||
                    this.PaymentMethodId != null &&
                    this.PaymentMethodId.Equals(other.PaymentMethodId)
                ) && 
                (
                    this.PaymentMethodSnapshotId == other.PaymentMethodSnapshotId ||
                    this.PaymentMethodSnapshotId != null &&
                    this.PaymentMethodSnapshotId.Equals(other.PaymentMethodSnapshotId)
                ) && 
                (
                    this.PaymentNumber == other.PaymentNumber ||
                    this.PaymentNumber != null &&
                    this.PaymentNumber.Equals(other.PaymentNumber)
                ) && 
                (
                    this.ReferenceId == other.ReferenceId ||
                    this.ReferenceId != null &&
                    this.ReferenceId.Equals(other.ReferenceId)
                ) && 
                (
                    this.RefundAmount == other.RefundAmount ||
                    this.RefundAmount != null &&
                    this.RefundAmount.Equals(other.RefundAmount)
                ) && 
                (
                    this.SecondPaymentReferenceId == other.SecondPaymentReferenceId ||
                    this.SecondPaymentReferenceId != null &&
                    this.SecondPaymentReferenceId.Equals(other.SecondPaymentReferenceId)
                ) && 
                (
                    this.SettledOn == other.SettledOn ||
                    this.SettledOn != null &&
                    this.SettledOn.Equals(other.SettledOn)
                ) && 
                (
                    this.SoftDescriptor == other.SoftDescriptor ||
                    this.SoftDescriptor != null &&
                    this.SoftDescriptor.Equals(other.SoftDescriptor)
                ) && 
                (
                    this.SoftDescriptorPhone == other.SoftDescriptorPhone ||
                    this.SoftDescriptorPhone != null &&
                    this.SoftDescriptorPhone.Equals(other.SoftDescriptorPhone)
                ) && 
                (
                    this.Source == other.Source ||
                    this.Source != null &&
                    this.Source.Equals(other.Source)
                ) && 
                (
                    this.SourceName == other.SourceName ||
                    this.SourceName != null &&
                    this.SourceName.Equals(other.SourceName)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.SubmittedOn == other.SubmittedOn ||
                    this.SubmittedOn != null &&
                    this.SubmittedOn.Equals(other.SubmittedOn)
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
                if (this.Amount != null)
                    hash = hash * 59 + this.Amount.GetHashCode();
                if (this.AppliedCreditBalanceAmount != null)
                    hash = hash * 59 + this.AppliedCreditBalanceAmount.GetHashCode();
                if (this.AuthTransactionId != null)
                    hash = hash * 59 + this.AuthTransactionId.GetHashCode();
                if (this.BankIdentificationNumber != null)
                    hash = hash * 59 + this.BankIdentificationNumber.GetHashCode();
                if (this.CancelledOn != null)
                    hash = hash * 59 + this.CancelledOn.GetHashCode();
                if (this.Comment != null)
                    hash = hash * 59 + this.Comment.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.EffectiveDate != null)
                    hash = hash * 59 + this.EffectiveDate.GetHashCode();
                if (this.Gateway != null)
                    hash = hash * 59 + this.Gateway.GetHashCode();
                if (this.GatewayOrderId != null)
                    hash = hash * 59 + this.GatewayOrderId.GetHashCode();
                if (this.GatewayResponse != null)
                    hash = hash * 59 + this.GatewayResponse.GetHashCode();
                if (this.GatewayResponseCode != null)
                    hash = hash * 59 + this.GatewayResponseCode.GetHashCode();
                if (this.GatewayState != null)
                    hash = hash * 59 + this.GatewayState.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.MarkedForSubmissionOn != null)
                    hash = hash * 59 + this.MarkedForSubmissionOn.GetHashCode();
                if (this.PaymentMethodId != null)
                    hash = hash * 59 + this.PaymentMethodId.GetHashCode();
                if (this.PaymentMethodSnapshotId != null)
                    hash = hash * 59 + this.PaymentMethodSnapshotId.GetHashCode();
                if (this.PaymentNumber != null)
                    hash = hash * 59 + this.PaymentNumber.GetHashCode();
                if (this.ReferenceId != null)
                    hash = hash * 59 + this.ReferenceId.GetHashCode();
                if (this.RefundAmount != null)
                    hash = hash * 59 + this.RefundAmount.GetHashCode();
                if (this.SecondPaymentReferenceId != null)
                    hash = hash * 59 + this.SecondPaymentReferenceId.GetHashCode();
                if (this.SettledOn != null)
                    hash = hash * 59 + this.SettledOn.GetHashCode();
                if (this.SoftDescriptor != null)
                    hash = hash * 59 + this.SoftDescriptor.GetHashCode();
                if (this.SoftDescriptorPhone != null)
                    hash = hash * 59 + this.SoftDescriptorPhone.GetHashCode();
                if (this.Source != null)
                    hash = hash * 59 + this.Source.GetHashCode();
                if (this.SourceName != null)
                    hash = hash * 59 + this.SourceName.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.SubmittedOn != null)
                    hash = hash * 59 + this.SubmittedOn.GetHashCode();
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
