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
    /// ProxyGetPaymentMethodSnapshot
    /// </summary>
    [DataContract]
    public partial class ProxyGetPaymentMethodSnapshot :  IEquatable<ProxyGetPaymentMethodSnapshot>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetPaymentMethodSnapshot" /> class.
        /// </summary>
        /// <param name="AccountId">.</param>
        /// <param name="AchAbaCode">.</param>
        /// <param name="AchAccountName">.</param>
        /// <param name="AchAccountNumberMask">.</param>
        /// <param name="AchAccountType">.</param>
        /// <param name="AchBankName">.</param>
        /// <param name="BankBranchCode">.</param>
        /// <param name="BankCheckDigit">.</param>
        /// <param name="BankCity">.</param>
        /// <param name="BankCode">.</param>
        /// <param name="BankIdentificationNumber">.</param>
        /// <param name="BankName">.</param>
        /// <param name="BankPostalCode">.</param>
        /// <param name="BankStreetName">.</param>
        /// <param name="BankStreetNumber">.</param>
        /// <param name="BankTransferAccountName">.</param>
        /// <param name="BankTransferAccountNumberMask">.</param>
        /// <param name="BankTransferAccountType">.</param>
        /// <param name="BankTransferType">.</param>
        /// <param name="BusinessIdentificationCode">.</param>
        /// <param name="City">.</param>
        /// <param name="Country">.</param>
        /// <param name="CreditCardAddress1">.</param>
        /// <param name="CreditCardAddress2">.</param>
        /// <param name="CreditCardCity">.</param>
        /// <param name="CreditCardCountry">.</param>
        /// <param name="CreditCardExpirationMonth">.</param>
        /// <param name="CreditCardExpirationYear">.</param>
        /// <param name="CreditCardHolderName">.</param>
        /// <param name="CreditCardMaskNumber">.</param>
        /// <param name="CreditCardPostalCode">.</param>
        /// <param name="CreditCardState">.</param>
        /// <param name="CreditCardType">.</param>
        /// <param name="DeviceSessionId">.</param>
        /// <param name="Email">.</param>
        /// <param name="ExistingMandate">.</param>
        /// <param name="FirstName">.</param>
        /// <param name="IBAN">.</param>
        /// <param name="IPAddress">.</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="LastFailedSaleTransactionDate">.</param>
        /// <param name="LastName">.</param>
        /// <param name="LastTransactionDateTime">.</param>
        /// <param name="LastTransactionStatus">.</param>
        /// <param name="MandateCreationDate">.</param>
        /// <param name="MandateID">.</param>
        /// <param name="MandateReceived">.</param>
        /// <param name="MandateUpdateDate">.</param>
        /// <param name="MaxConsecutivePaymentFailures">.</param>
        /// <param name="Name">.</param>
        /// <param name="NumConsecutiveFailures">.</param>
        /// <param name="PaymentMethodId">.</param>
        /// <param name="PaymentMethodStatus">.</param>
        /// <param name="PaymentRetryWindow">.</param>
        /// <param name="PaypalBaid">.</param>
        /// <param name="PaypalEmail">.</param>
        /// <param name="PaypalPreapprovalKey">.</param>
        /// <param name="PaypalType">.</param>
        /// <param name="Phone">.</param>
        /// <param name="PostalCode">.</param>
        /// <param name="SecondTokenId">.</param>
        /// <param name="State">.</param>
        /// <param name="StreetName">.</param>
        /// <param name="StreetNumber">.</param>
        /// <param name="TokenId">.</param>
        /// <param name="TotalNumberOfErrorPayments">.</param>
        /// <param name="TotalNumberOfProcessedPayments">.</param>
        /// <param name="Type">.</param>
        /// <param name="UseDefaultRetryRule">.</param>
        public ProxyGetPaymentMethodSnapshot(string AccountId = null, string AchAbaCode = null, string AchAccountName = null, string AchAccountNumberMask = null, string AchAccountType = null, string AchBankName = null, string BankBranchCode = null, string BankCheckDigit = null, string BankCity = null, string BankCode = null, string BankIdentificationNumber = null, string BankName = null, string BankPostalCode = null, string BankStreetName = null, string BankStreetNumber = null, string BankTransferAccountName = null, string BankTransferAccountNumberMask = null, string BankTransferAccountType = null, string BankTransferType = null, string BusinessIdentificationCode = null, string City = null, string Country = null, string CreditCardAddress1 = null, string CreditCardAddress2 = null, string CreditCardCity = null, string CreditCardCountry = null, int? CreditCardExpirationMonth = null, int? CreditCardExpirationYear = null, string CreditCardHolderName = null, string CreditCardMaskNumber = null, string CreditCardPostalCode = null, string CreditCardState = null, string CreditCardType = null, string DeviceSessionId = null, string Email = null, string ExistingMandate = null, string FirstName = null, string IBAN = null, string IPAddress = null, string Id = null, DateTime? LastFailedSaleTransactionDate = null, string LastName = null, DateTime? LastTransactionDateTime = null, string LastTransactionStatus = null, DateTime? MandateCreationDate = null, string MandateID = null, string MandateReceived = null, DateTime? MandateUpdateDate = null, int? MaxConsecutivePaymentFailures = null, string Name = null, int? NumConsecutiveFailures = null, string PaymentMethodId = null, string PaymentMethodStatus = null, int? PaymentRetryWindow = null, string PaypalBaid = null, string PaypalEmail = null, string PaypalPreapprovalKey = null, string PaypalType = null, string Phone = null, string PostalCode = null, string SecondTokenId = null, string State = null, string StreetName = null, string StreetNumber = null, string TokenId = null, int? TotalNumberOfErrorPayments = null, int? TotalNumberOfProcessedPayments = null, string Type = null, bool? UseDefaultRetryRule = null)
        {
            this.AccountId = AccountId;
            this.AchAbaCode = AchAbaCode;
            this.AchAccountName = AchAccountName;
            this.AchAccountNumberMask = AchAccountNumberMask;
            this.AchAccountType = AchAccountType;
            this.AchBankName = AchBankName;
            this.BankBranchCode = BankBranchCode;
            this.BankCheckDigit = BankCheckDigit;
            this.BankCity = BankCity;
            this.BankCode = BankCode;
            this.BankIdentificationNumber = BankIdentificationNumber;
            this.BankName = BankName;
            this.BankPostalCode = BankPostalCode;
            this.BankStreetName = BankStreetName;
            this.BankStreetNumber = BankStreetNumber;
            this.BankTransferAccountName = BankTransferAccountName;
            this.BankTransferAccountNumberMask = BankTransferAccountNumberMask;
            this.BankTransferAccountType = BankTransferAccountType;
            this.BankTransferType = BankTransferType;
            this.BusinessIdentificationCode = BusinessIdentificationCode;
            this.City = City;
            this.Country = Country;
            this.CreditCardAddress1 = CreditCardAddress1;
            this.CreditCardAddress2 = CreditCardAddress2;
            this.CreditCardCity = CreditCardCity;
            this.CreditCardCountry = CreditCardCountry;
            this.CreditCardExpirationMonth = CreditCardExpirationMonth;
            this.CreditCardExpirationYear = CreditCardExpirationYear;
            this.CreditCardHolderName = CreditCardHolderName;
            this.CreditCardMaskNumber = CreditCardMaskNumber;
            this.CreditCardPostalCode = CreditCardPostalCode;
            this.CreditCardState = CreditCardState;
            this.CreditCardType = CreditCardType;
            this.DeviceSessionId = DeviceSessionId;
            this.Email = Email;
            this.ExistingMandate = ExistingMandate;
            this.FirstName = FirstName;
            this.IBAN = IBAN;
            this.IPAddress = IPAddress;
            this.Id = Id;
            this.LastFailedSaleTransactionDate = LastFailedSaleTransactionDate;
            this.LastName = LastName;
            this.LastTransactionDateTime = LastTransactionDateTime;
            this.LastTransactionStatus = LastTransactionStatus;
            this.MandateCreationDate = MandateCreationDate;
            this.MandateID = MandateID;
            this.MandateReceived = MandateReceived;
            this.MandateUpdateDate = MandateUpdateDate;
            this.MaxConsecutivePaymentFailures = MaxConsecutivePaymentFailures;
            this.Name = Name;
            this.NumConsecutiveFailures = NumConsecutiveFailures;
            this.PaymentMethodId = PaymentMethodId;
            this.PaymentMethodStatus = PaymentMethodStatus;
            this.PaymentRetryWindow = PaymentRetryWindow;
            this.PaypalBaid = PaypalBaid;
            this.PaypalEmail = PaypalEmail;
            this.PaypalPreapprovalKey = PaypalPreapprovalKey;
            this.PaypalType = PaypalType;
            this.Phone = Phone;
            this.PostalCode = PostalCode;
            this.SecondTokenId = SecondTokenId;
            this.State = State;
            this.StreetName = StreetName;
            this.StreetNumber = StreetNumber;
            this.TokenId = TokenId;
            this.TotalNumberOfErrorPayments = TotalNumberOfErrorPayments;
            this.TotalNumberOfProcessedPayments = TotalNumberOfProcessedPayments;
            this.Type = Type;
            this.UseDefaultRetryRule = UseDefaultRetryRule;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AchAbaCode", EmitDefaultValue=false)]
        public string AchAbaCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AchAccountName", EmitDefaultValue=false)]
        public string AchAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AchAccountNumberMask", EmitDefaultValue=false)]
        public string AchAccountNumberMask { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AchAccountType", EmitDefaultValue=false)]
        public string AchAccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="AchBankName", EmitDefaultValue=false)]
        public string AchBankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankBranchCode", EmitDefaultValue=false)]
        public string BankBranchCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankCheckDigit", EmitDefaultValue=false)]
        public string BankCheckDigit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankCity", EmitDefaultValue=false)]
        public string BankCity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankCode", EmitDefaultValue=false)]
        public string BankCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankIdentificationNumber", EmitDefaultValue=false)]
        public string BankIdentificationNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankName", EmitDefaultValue=false)]
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankPostalCode", EmitDefaultValue=false)]
        public string BankPostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankStreetName", EmitDefaultValue=false)]
        public string BankStreetName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankStreetNumber", EmitDefaultValue=false)]
        public string BankStreetNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankTransferAccountName", EmitDefaultValue=false)]
        public string BankTransferAccountName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankTransferAccountNumberMask", EmitDefaultValue=false)]
        public string BankTransferAccountNumberMask { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankTransferAccountType", EmitDefaultValue=false)]
        public string BankTransferAccountType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BankTransferType", EmitDefaultValue=false)]
        public string BankTransferType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="BusinessIdentificationCode", EmitDefaultValue=false)]
        public string BusinessIdentificationCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="City", EmitDefaultValue=false)]
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="Country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardAddress1", EmitDefaultValue=false)]
        public string CreditCardAddress1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardAddress2", EmitDefaultValue=false)]
        public string CreditCardAddress2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardCity", EmitDefaultValue=false)]
        public string CreditCardCity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardCountry", EmitDefaultValue=false)]
        public string CreditCardCountry { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardExpirationMonth", EmitDefaultValue=false)]
        public int? CreditCardExpirationMonth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardExpirationYear", EmitDefaultValue=false)]
        public int? CreditCardExpirationYear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardHolderName", EmitDefaultValue=false)]
        public string CreditCardHolderName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardMaskNumber", EmitDefaultValue=false)]
        public string CreditCardMaskNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardPostalCode", EmitDefaultValue=false)]
        public string CreditCardPostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardState", EmitDefaultValue=false)]
        public string CreditCardState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="CreditCardType", EmitDefaultValue=false)]
        public string CreditCardType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="DeviceSessionId", EmitDefaultValue=false)]
        public string DeviceSessionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="Email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="ExistingMandate", EmitDefaultValue=false)]
        public string ExistingMandate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="FirstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="IBAN", EmitDefaultValue=false)]
        public string IBAN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="IPAddress", EmitDefaultValue=false)]
        public string IPAddress { get; set; }
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
        [DataMember(Name="LastFailedSaleTransactionDate", EmitDefaultValue=false)]
        public DateTime? LastFailedSaleTransactionDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="LastName", EmitDefaultValue=false)]
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="LastTransactionDateTime", EmitDefaultValue=false)]
        public DateTime? LastTransactionDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="LastTransactionStatus", EmitDefaultValue=false)]
        public string LastTransactionStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="MandateCreationDate", EmitDefaultValue=false)]
        public DateTime? MandateCreationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="MandateID", EmitDefaultValue=false)]
        public string MandateID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="MandateReceived", EmitDefaultValue=false)]
        public string MandateReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="MandateUpdateDate", EmitDefaultValue=false)]
        public DateTime? MandateUpdateDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="MaxConsecutivePaymentFailures", EmitDefaultValue=false)]
        public int? MaxConsecutivePaymentFailures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="NumConsecutiveFailures", EmitDefaultValue=false)]
        public int? NumConsecutiveFailures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaymentMethodId", EmitDefaultValue=false)]
        public string PaymentMethodId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaymentMethodStatus", EmitDefaultValue=false)]
        public string PaymentMethodStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaymentRetryWindow", EmitDefaultValue=false)]
        public int? PaymentRetryWindow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaypalBaid", EmitDefaultValue=false)]
        public string PaypalBaid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaypalEmail", EmitDefaultValue=false)]
        public string PaypalEmail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaypalPreapprovalKey", EmitDefaultValue=false)]
        public string PaypalPreapprovalKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PaypalType", EmitDefaultValue=false)]
        public string PaypalType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="Phone", EmitDefaultValue=false)]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="PostalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="SecondTokenId", EmitDefaultValue=false)]
        public string SecondTokenId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="State", EmitDefaultValue=false)]
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="StreetName", EmitDefaultValue=false)]
        public string StreetName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="StreetNumber", EmitDefaultValue=false)]
        public string StreetNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="TokenId", EmitDefaultValue=false)]
        public string TokenId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="TotalNumberOfErrorPayments", EmitDefaultValue=false)]
        public int? TotalNumberOfErrorPayments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="TotalNumberOfProcessedPayments", EmitDefaultValue=false)]
        public int? TotalNumberOfProcessedPayments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [DataMember(Name="UseDefaultRetryRule", EmitDefaultValue=false)]
        public bool? UseDefaultRetryRule { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetPaymentMethodSnapshot {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AchAbaCode: ").Append(AchAbaCode).Append("\n");
            sb.Append("  AchAccountName: ").Append(AchAccountName).Append("\n");
            sb.Append("  AchAccountNumberMask: ").Append(AchAccountNumberMask).Append("\n");
            sb.Append("  AchAccountType: ").Append(AchAccountType).Append("\n");
            sb.Append("  AchBankName: ").Append(AchBankName).Append("\n");
            sb.Append("  BankBranchCode: ").Append(BankBranchCode).Append("\n");
            sb.Append("  BankCheckDigit: ").Append(BankCheckDigit).Append("\n");
            sb.Append("  BankCity: ").Append(BankCity).Append("\n");
            sb.Append("  BankCode: ").Append(BankCode).Append("\n");
            sb.Append("  BankIdentificationNumber: ").Append(BankIdentificationNumber).Append("\n");
            sb.Append("  BankName: ").Append(BankName).Append("\n");
            sb.Append("  BankPostalCode: ").Append(BankPostalCode).Append("\n");
            sb.Append("  BankStreetName: ").Append(BankStreetName).Append("\n");
            sb.Append("  BankStreetNumber: ").Append(BankStreetNumber).Append("\n");
            sb.Append("  BankTransferAccountName: ").Append(BankTransferAccountName).Append("\n");
            sb.Append("  BankTransferAccountNumberMask: ").Append(BankTransferAccountNumberMask).Append("\n");
            sb.Append("  BankTransferAccountType: ").Append(BankTransferAccountType).Append("\n");
            sb.Append("  BankTransferType: ").Append(BankTransferType).Append("\n");
            sb.Append("  BusinessIdentificationCode: ").Append(BusinessIdentificationCode).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  CreditCardAddress1: ").Append(CreditCardAddress1).Append("\n");
            sb.Append("  CreditCardAddress2: ").Append(CreditCardAddress2).Append("\n");
            sb.Append("  CreditCardCity: ").Append(CreditCardCity).Append("\n");
            sb.Append("  CreditCardCountry: ").Append(CreditCardCountry).Append("\n");
            sb.Append("  CreditCardExpirationMonth: ").Append(CreditCardExpirationMonth).Append("\n");
            sb.Append("  CreditCardExpirationYear: ").Append(CreditCardExpirationYear).Append("\n");
            sb.Append("  CreditCardHolderName: ").Append(CreditCardHolderName).Append("\n");
            sb.Append("  CreditCardMaskNumber: ").Append(CreditCardMaskNumber).Append("\n");
            sb.Append("  CreditCardPostalCode: ").Append(CreditCardPostalCode).Append("\n");
            sb.Append("  CreditCardState: ").Append(CreditCardState).Append("\n");
            sb.Append("  CreditCardType: ").Append(CreditCardType).Append("\n");
            sb.Append("  DeviceSessionId: ").Append(DeviceSessionId).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ExistingMandate: ").Append(ExistingMandate).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  IBAN: ").Append(IBAN).Append("\n");
            sb.Append("  IPAddress: ").Append(IPAddress).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastFailedSaleTransactionDate: ").Append(LastFailedSaleTransactionDate).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LastTransactionDateTime: ").Append(LastTransactionDateTime).Append("\n");
            sb.Append("  LastTransactionStatus: ").Append(LastTransactionStatus).Append("\n");
            sb.Append("  MandateCreationDate: ").Append(MandateCreationDate).Append("\n");
            sb.Append("  MandateID: ").Append(MandateID).Append("\n");
            sb.Append("  MandateReceived: ").Append(MandateReceived).Append("\n");
            sb.Append("  MandateUpdateDate: ").Append(MandateUpdateDate).Append("\n");
            sb.Append("  MaxConsecutivePaymentFailures: ").Append(MaxConsecutivePaymentFailures).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NumConsecutiveFailures: ").Append(NumConsecutiveFailures).Append("\n");
            sb.Append("  PaymentMethodId: ").Append(PaymentMethodId).Append("\n");
            sb.Append("  PaymentMethodStatus: ").Append(PaymentMethodStatus).Append("\n");
            sb.Append("  PaymentRetryWindow: ").Append(PaymentRetryWindow).Append("\n");
            sb.Append("  PaypalBaid: ").Append(PaypalBaid).Append("\n");
            sb.Append("  PaypalEmail: ").Append(PaypalEmail).Append("\n");
            sb.Append("  PaypalPreapprovalKey: ").Append(PaypalPreapprovalKey).Append("\n");
            sb.Append("  PaypalType: ").Append(PaypalType).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  SecondTokenId: ").Append(SecondTokenId).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  StreetName: ").Append(StreetName).Append("\n");
            sb.Append("  StreetNumber: ").Append(StreetNumber).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  TotalNumberOfErrorPayments: ").Append(TotalNumberOfErrorPayments).Append("\n");
            sb.Append("  TotalNumberOfProcessedPayments: ").Append(TotalNumberOfProcessedPayments).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UseDefaultRetryRule: ").Append(UseDefaultRetryRule).Append("\n");
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
            return this.Equals(obj as ProxyGetPaymentMethodSnapshot);
        }

        /// <summary>
        /// Returns true if ProxyGetPaymentMethodSnapshot instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetPaymentMethodSnapshot to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetPaymentMethodSnapshot other)
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
                    this.AchAbaCode == other.AchAbaCode ||
                    this.AchAbaCode != null &&
                    this.AchAbaCode.Equals(other.AchAbaCode)
                ) && 
                (
                    this.AchAccountName == other.AchAccountName ||
                    this.AchAccountName != null &&
                    this.AchAccountName.Equals(other.AchAccountName)
                ) && 
                (
                    this.AchAccountNumberMask == other.AchAccountNumberMask ||
                    this.AchAccountNumberMask != null &&
                    this.AchAccountNumberMask.Equals(other.AchAccountNumberMask)
                ) && 
                (
                    this.AchAccountType == other.AchAccountType ||
                    this.AchAccountType != null &&
                    this.AchAccountType.Equals(other.AchAccountType)
                ) && 
                (
                    this.AchBankName == other.AchBankName ||
                    this.AchBankName != null &&
                    this.AchBankName.Equals(other.AchBankName)
                ) && 
                (
                    this.BankBranchCode == other.BankBranchCode ||
                    this.BankBranchCode != null &&
                    this.BankBranchCode.Equals(other.BankBranchCode)
                ) && 
                (
                    this.BankCheckDigit == other.BankCheckDigit ||
                    this.BankCheckDigit != null &&
                    this.BankCheckDigit.Equals(other.BankCheckDigit)
                ) && 
                (
                    this.BankCity == other.BankCity ||
                    this.BankCity != null &&
                    this.BankCity.Equals(other.BankCity)
                ) && 
                (
                    this.BankCode == other.BankCode ||
                    this.BankCode != null &&
                    this.BankCode.Equals(other.BankCode)
                ) && 
                (
                    this.BankIdentificationNumber == other.BankIdentificationNumber ||
                    this.BankIdentificationNumber != null &&
                    this.BankIdentificationNumber.Equals(other.BankIdentificationNumber)
                ) && 
                (
                    this.BankName == other.BankName ||
                    this.BankName != null &&
                    this.BankName.Equals(other.BankName)
                ) && 
                (
                    this.BankPostalCode == other.BankPostalCode ||
                    this.BankPostalCode != null &&
                    this.BankPostalCode.Equals(other.BankPostalCode)
                ) && 
                (
                    this.BankStreetName == other.BankStreetName ||
                    this.BankStreetName != null &&
                    this.BankStreetName.Equals(other.BankStreetName)
                ) && 
                (
                    this.BankStreetNumber == other.BankStreetNumber ||
                    this.BankStreetNumber != null &&
                    this.BankStreetNumber.Equals(other.BankStreetNumber)
                ) && 
                (
                    this.BankTransferAccountName == other.BankTransferAccountName ||
                    this.BankTransferAccountName != null &&
                    this.BankTransferAccountName.Equals(other.BankTransferAccountName)
                ) && 
                (
                    this.BankTransferAccountNumberMask == other.BankTransferAccountNumberMask ||
                    this.BankTransferAccountNumberMask != null &&
                    this.BankTransferAccountNumberMask.Equals(other.BankTransferAccountNumberMask)
                ) && 
                (
                    this.BankTransferAccountType == other.BankTransferAccountType ||
                    this.BankTransferAccountType != null &&
                    this.BankTransferAccountType.Equals(other.BankTransferAccountType)
                ) && 
                (
                    this.BankTransferType == other.BankTransferType ||
                    this.BankTransferType != null &&
                    this.BankTransferType.Equals(other.BankTransferType)
                ) && 
                (
                    this.BusinessIdentificationCode == other.BusinessIdentificationCode ||
                    this.BusinessIdentificationCode != null &&
                    this.BusinessIdentificationCode.Equals(other.BusinessIdentificationCode)
                ) && 
                (
                    this.City == other.City ||
                    this.City != null &&
                    this.City.Equals(other.City)
                ) && 
                (
                    this.Country == other.Country ||
                    this.Country != null &&
                    this.Country.Equals(other.Country)
                ) && 
                (
                    this.CreditCardAddress1 == other.CreditCardAddress1 ||
                    this.CreditCardAddress1 != null &&
                    this.CreditCardAddress1.Equals(other.CreditCardAddress1)
                ) && 
                (
                    this.CreditCardAddress2 == other.CreditCardAddress2 ||
                    this.CreditCardAddress2 != null &&
                    this.CreditCardAddress2.Equals(other.CreditCardAddress2)
                ) && 
                (
                    this.CreditCardCity == other.CreditCardCity ||
                    this.CreditCardCity != null &&
                    this.CreditCardCity.Equals(other.CreditCardCity)
                ) && 
                (
                    this.CreditCardCountry == other.CreditCardCountry ||
                    this.CreditCardCountry != null &&
                    this.CreditCardCountry.Equals(other.CreditCardCountry)
                ) && 
                (
                    this.CreditCardExpirationMonth == other.CreditCardExpirationMonth ||
                    this.CreditCardExpirationMonth != null &&
                    this.CreditCardExpirationMonth.Equals(other.CreditCardExpirationMonth)
                ) && 
                (
                    this.CreditCardExpirationYear == other.CreditCardExpirationYear ||
                    this.CreditCardExpirationYear != null &&
                    this.CreditCardExpirationYear.Equals(other.CreditCardExpirationYear)
                ) && 
                (
                    this.CreditCardHolderName == other.CreditCardHolderName ||
                    this.CreditCardHolderName != null &&
                    this.CreditCardHolderName.Equals(other.CreditCardHolderName)
                ) && 
                (
                    this.CreditCardMaskNumber == other.CreditCardMaskNumber ||
                    this.CreditCardMaskNumber != null &&
                    this.CreditCardMaskNumber.Equals(other.CreditCardMaskNumber)
                ) && 
                (
                    this.CreditCardPostalCode == other.CreditCardPostalCode ||
                    this.CreditCardPostalCode != null &&
                    this.CreditCardPostalCode.Equals(other.CreditCardPostalCode)
                ) && 
                (
                    this.CreditCardState == other.CreditCardState ||
                    this.CreditCardState != null &&
                    this.CreditCardState.Equals(other.CreditCardState)
                ) && 
                (
                    this.CreditCardType == other.CreditCardType ||
                    this.CreditCardType != null &&
                    this.CreditCardType.Equals(other.CreditCardType)
                ) && 
                (
                    this.DeviceSessionId == other.DeviceSessionId ||
                    this.DeviceSessionId != null &&
                    this.DeviceSessionId.Equals(other.DeviceSessionId)
                ) && 
                (
                    this.Email == other.Email ||
                    this.Email != null &&
                    this.Email.Equals(other.Email)
                ) && 
                (
                    this.ExistingMandate == other.ExistingMandate ||
                    this.ExistingMandate != null &&
                    this.ExistingMandate.Equals(other.ExistingMandate)
                ) && 
                (
                    this.FirstName == other.FirstName ||
                    this.FirstName != null &&
                    this.FirstName.Equals(other.FirstName)
                ) && 
                (
                    this.IBAN == other.IBAN ||
                    this.IBAN != null &&
                    this.IBAN.Equals(other.IBAN)
                ) && 
                (
                    this.IPAddress == other.IPAddress ||
                    this.IPAddress != null &&
                    this.IPAddress.Equals(other.IPAddress)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.LastFailedSaleTransactionDate == other.LastFailedSaleTransactionDate ||
                    this.LastFailedSaleTransactionDate != null &&
                    this.LastFailedSaleTransactionDate.Equals(other.LastFailedSaleTransactionDate)
                ) && 
                (
                    this.LastName == other.LastName ||
                    this.LastName != null &&
                    this.LastName.Equals(other.LastName)
                ) && 
                (
                    this.LastTransactionDateTime == other.LastTransactionDateTime ||
                    this.LastTransactionDateTime != null &&
                    this.LastTransactionDateTime.Equals(other.LastTransactionDateTime)
                ) && 
                (
                    this.LastTransactionStatus == other.LastTransactionStatus ||
                    this.LastTransactionStatus != null &&
                    this.LastTransactionStatus.Equals(other.LastTransactionStatus)
                ) && 
                (
                    this.MandateCreationDate == other.MandateCreationDate ||
                    this.MandateCreationDate != null &&
                    this.MandateCreationDate.Equals(other.MandateCreationDate)
                ) && 
                (
                    this.MandateID == other.MandateID ||
                    this.MandateID != null &&
                    this.MandateID.Equals(other.MandateID)
                ) && 
                (
                    this.MandateReceived == other.MandateReceived ||
                    this.MandateReceived != null &&
                    this.MandateReceived.Equals(other.MandateReceived)
                ) && 
                (
                    this.MandateUpdateDate == other.MandateUpdateDate ||
                    this.MandateUpdateDate != null &&
                    this.MandateUpdateDate.Equals(other.MandateUpdateDate)
                ) && 
                (
                    this.MaxConsecutivePaymentFailures == other.MaxConsecutivePaymentFailures ||
                    this.MaxConsecutivePaymentFailures != null &&
                    this.MaxConsecutivePaymentFailures.Equals(other.MaxConsecutivePaymentFailures)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.NumConsecutiveFailures == other.NumConsecutiveFailures ||
                    this.NumConsecutiveFailures != null &&
                    this.NumConsecutiveFailures.Equals(other.NumConsecutiveFailures)
                ) && 
                (
                    this.PaymentMethodId == other.PaymentMethodId ||
                    this.PaymentMethodId != null &&
                    this.PaymentMethodId.Equals(other.PaymentMethodId)
                ) && 
                (
                    this.PaymentMethodStatus == other.PaymentMethodStatus ||
                    this.PaymentMethodStatus != null &&
                    this.PaymentMethodStatus.Equals(other.PaymentMethodStatus)
                ) && 
                (
                    this.PaymentRetryWindow == other.PaymentRetryWindow ||
                    this.PaymentRetryWindow != null &&
                    this.PaymentRetryWindow.Equals(other.PaymentRetryWindow)
                ) && 
                (
                    this.PaypalBaid == other.PaypalBaid ||
                    this.PaypalBaid != null &&
                    this.PaypalBaid.Equals(other.PaypalBaid)
                ) && 
                (
                    this.PaypalEmail == other.PaypalEmail ||
                    this.PaypalEmail != null &&
                    this.PaypalEmail.Equals(other.PaypalEmail)
                ) && 
                (
                    this.PaypalPreapprovalKey == other.PaypalPreapprovalKey ||
                    this.PaypalPreapprovalKey != null &&
                    this.PaypalPreapprovalKey.Equals(other.PaypalPreapprovalKey)
                ) && 
                (
                    this.PaypalType == other.PaypalType ||
                    this.PaypalType != null &&
                    this.PaypalType.Equals(other.PaypalType)
                ) && 
                (
                    this.Phone == other.Phone ||
                    this.Phone != null &&
                    this.Phone.Equals(other.Phone)
                ) && 
                (
                    this.PostalCode == other.PostalCode ||
                    this.PostalCode != null &&
                    this.PostalCode.Equals(other.PostalCode)
                ) && 
                (
                    this.SecondTokenId == other.SecondTokenId ||
                    this.SecondTokenId != null &&
                    this.SecondTokenId.Equals(other.SecondTokenId)
                ) && 
                (
                    this.State == other.State ||
                    this.State != null &&
                    this.State.Equals(other.State)
                ) && 
                (
                    this.StreetName == other.StreetName ||
                    this.StreetName != null &&
                    this.StreetName.Equals(other.StreetName)
                ) && 
                (
                    this.StreetNumber == other.StreetNumber ||
                    this.StreetNumber != null &&
                    this.StreetNumber.Equals(other.StreetNumber)
                ) && 
                (
                    this.TokenId == other.TokenId ||
                    this.TokenId != null &&
                    this.TokenId.Equals(other.TokenId)
                ) && 
                (
                    this.TotalNumberOfErrorPayments == other.TotalNumberOfErrorPayments ||
                    this.TotalNumberOfErrorPayments != null &&
                    this.TotalNumberOfErrorPayments.Equals(other.TotalNumberOfErrorPayments)
                ) && 
                (
                    this.TotalNumberOfProcessedPayments == other.TotalNumberOfProcessedPayments ||
                    this.TotalNumberOfProcessedPayments != null &&
                    this.TotalNumberOfProcessedPayments.Equals(other.TotalNumberOfProcessedPayments)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.UseDefaultRetryRule == other.UseDefaultRetryRule ||
                    this.UseDefaultRetryRule != null &&
                    this.UseDefaultRetryRule.Equals(other.UseDefaultRetryRule)
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
                if (this.AchAbaCode != null)
                    hash = hash * 59 + this.AchAbaCode.GetHashCode();
                if (this.AchAccountName != null)
                    hash = hash * 59 + this.AchAccountName.GetHashCode();
                if (this.AchAccountNumberMask != null)
                    hash = hash * 59 + this.AchAccountNumberMask.GetHashCode();
                if (this.AchAccountType != null)
                    hash = hash * 59 + this.AchAccountType.GetHashCode();
                if (this.AchBankName != null)
                    hash = hash * 59 + this.AchBankName.GetHashCode();
                if (this.BankBranchCode != null)
                    hash = hash * 59 + this.BankBranchCode.GetHashCode();
                if (this.BankCheckDigit != null)
                    hash = hash * 59 + this.BankCheckDigit.GetHashCode();
                if (this.BankCity != null)
                    hash = hash * 59 + this.BankCity.GetHashCode();
                if (this.BankCode != null)
                    hash = hash * 59 + this.BankCode.GetHashCode();
                if (this.BankIdentificationNumber != null)
                    hash = hash * 59 + this.BankIdentificationNumber.GetHashCode();
                if (this.BankName != null)
                    hash = hash * 59 + this.BankName.GetHashCode();
                if (this.BankPostalCode != null)
                    hash = hash * 59 + this.BankPostalCode.GetHashCode();
                if (this.BankStreetName != null)
                    hash = hash * 59 + this.BankStreetName.GetHashCode();
                if (this.BankStreetNumber != null)
                    hash = hash * 59 + this.BankStreetNumber.GetHashCode();
                if (this.BankTransferAccountName != null)
                    hash = hash * 59 + this.BankTransferAccountName.GetHashCode();
                if (this.BankTransferAccountNumberMask != null)
                    hash = hash * 59 + this.BankTransferAccountNumberMask.GetHashCode();
                if (this.BankTransferAccountType != null)
                    hash = hash * 59 + this.BankTransferAccountType.GetHashCode();
                if (this.BankTransferType != null)
                    hash = hash * 59 + this.BankTransferType.GetHashCode();
                if (this.BusinessIdentificationCode != null)
                    hash = hash * 59 + this.BusinessIdentificationCode.GetHashCode();
                if (this.City != null)
                    hash = hash * 59 + this.City.GetHashCode();
                if (this.Country != null)
                    hash = hash * 59 + this.Country.GetHashCode();
                if (this.CreditCardAddress1 != null)
                    hash = hash * 59 + this.CreditCardAddress1.GetHashCode();
                if (this.CreditCardAddress2 != null)
                    hash = hash * 59 + this.CreditCardAddress2.GetHashCode();
                if (this.CreditCardCity != null)
                    hash = hash * 59 + this.CreditCardCity.GetHashCode();
                if (this.CreditCardCountry != null)
                    hash = hash * 59 + this.CreditCardCountry.GetHashCode();
                if (this.CreditCardExpirationMonth != null)
                    hash = hash * 59 + this.CreditCardExpirationMonth.GetHashCode();
                if (this.CreditCardExpirationYear != null)
                    hash = hash * 59 + this.CreditCardExpirationYear.GetHashCode();
                if (this.CreditCardHolderName != null)
                    hash = hash * 59 + this.CreditCardHolderName.GetHashCode();
                if (this.CreditCardMaskNumber != null)
                    hash = hash * 59 + this.CreditCardMaskNumber.GetHashCode();
                if (this.CreditCardPostalCode != null)
                    hash = hash * 59 + this.CreditCardPostalCode.GetHashCode();
                if (this.CreditCardState != null)
                    hash = hash * 59 + this.CreditCardState.GetHashCode();
                if (this.CreditCardType != null)
                    hash = hash * 59 + this.CreditCardType.GetHashCode();
                if (this.DeviceSessionId != null)
                    hash = hash * 59 + this.DeviceSessionId.GetHashCode();
                if (this.Email != null)
                    hash = hash * 59 + this.Email.GetHashCode();
                if (this.ExistingMandate != null)
                    hash = hash * 59 + this.ExistingMandate.GetHashCode();
                if (this.FirstName != null)
                    hash = hash * 59 + this.FirstName.GetHashCode();
                if (this.IBAN != null)
                    hash = hash * 59 + this.IBAN.GetHashCode();
                if (this.IPAddress != null)
                    hash = hash * 59 + this.IPAddress.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.LastFailedSaleTransactionDate != null)
                    hash = hash * 59 + this.LastFailedSaleTransactionDate.GetHashCode();
                if (this.LastName != null)
                    hash = hash * 59 + this.LastName.GetHashCode();
                if (this.LastTransactionDateTime != null)
                    hash = hash * 59 + this.LastTransactionDateTime.GetHashCode();
                if (this.LastTransactionStatus != null)
                    hash = hash * 59 + this.LastTransactionStatus.GetHashCode();
                if (this.MandateCreationDate != null)
                    hash = hash * 59 + this.MandateCreationDate.GetHashCode();
                if (this.MandateID != null)
                    hash = hash * 59 + this.MandateID.GetHashCode();
                if (this.MandateReceived != null)
                    hash = hash * 59 + this.MandateReceived.GetHashCode();
                if (this.MandateUpdateDate != null)
                    hash = hash * 59 + this.MandateUpdateDate.GetHashCode();
                if (this.MaxConsecutivePaymentFailures != null)
                    hash = hash * 59 + this.MaxConsecutivePaymentFailures.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.NumConsecutiveFailures != null)
                    hash = hash * 59 + this.NumConsecutiveFailures.GetHashCode();
                if (this.PaymentMethodId != null)
                    hash = hash * 59 + this.PaymentMethodId.GetHashCode();
                if (this.PaymentMethodStatus != null)
                    hash = hash * 59 + this.PaymentMethodStatus.GetHashCode();
                if (this.PaymentRetryWindow != null)
                    hash = hash * 59 + this.PaymentRetryWindow.GetHashCode();
                if (this.PaypalBaid != null)
                    hash = hash * 59 + this.PaypalBaid.GetHashCode();
                if (this.PaypalEmail != null)
                    hash = hash * 59 + this.PaypalEmail.GetHashCode();
                if (this.PaypalPreapprovalKey != null)
                    hash = hash * 59 + this.PaypalPreapprovalKey.GetHashCode();
                if (this.PaypalType != null)
                    hash = hash * 59 + this.PaypalType.GetHashCode();
                if (this.Phone != null)
                    hash = hash * 59 + this.Phone.GetHashCode();
                if (this.PostalCode != null)
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                if (this.SecondTokenId != null)
                    hash = hash * 59 + this.SecondTokenId.GetHashCode();
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                if (this.StreetName != null)
                    hash = hash * 59 + this.StreetName.GetHashCode();
                if (this.StreetNumber != null)
                    hash = hash * 59 + this.StreetNumber.GetHashCode();
                if (this.TokenId != null)
                    hash = hash * 59 + this.TokenId.GetHashCode();
                if (this.TotalNumberOfErrorPayments != null)
                    hash = hash * 59 + this.TotalNumberOfErrorPayments.GetHashCode();
                if (this.TotalNumberOfProcessedPayments != null)
                    hash = hash * 59 + this.TotalNumberOfProcessedPayments.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.UseDefaultRetryRule != null)
                    hash = hash * 59 + this.UseDefaultRetryRule.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
