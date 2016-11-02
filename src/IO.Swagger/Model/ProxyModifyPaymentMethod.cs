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
    /// ProxyModifyPaymentMethod
    /// </summary>
    [DataContract]
    public partial class ProxyModifyPaymentMethod :  IEquatable<ProxyModifyPaymentMethod>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyModifyPaymentMethod" /> class.
        /// </summary>
        /// <param name="AccountId"> The ID of the customer account associated with this payment method. This field is not required for the &#x60;[account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) .</param>
        /// <param name="AchAbaCode"> The nine-digit routing number or ABA number used by banks. Use this field for ACH payment methods. **Character limit**: 9 **Values**: a string of 9 characters or fewer .</param>
        /// <param name="AchAccountName"> The name of the account holder, which can be either a person or a company. Use this field for ACH payment methods. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="AchAccountType"> The type of bank account associated with the ACH payment. Use this field for ACH payment methods. **Character limit**: 16 **Values**:  - &#x60;BusinessChecking&#x60; - &#x60;Checking&#x60; - &#x60;Saving&#x60; .</param>
        /// <param name="AchAddress1"> Line 1 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways. **Character limit:** **Values:** an address .</param>
        /// <param name="AchAddress2"> Line 2 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways. **Character limit:** **Values:** an address .</param>
        /// <param name="AchBankName"> The name of the bank where the ACH payment account is held. Use this field for ACH payment methods. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="BankBranchCode"> The branch code of the bank used for direct debit. Use this field for direct debit payment methods. **Character limit**: 10 **Values**:  string of 10 characters or fewer .</param>
        /// <param name="BankCheckDigit">The check digit in the international bank account number, which confirms the validity of the account. Use this field for direct debit payment methods. **Character limit**: 4 **Values**:  string of 4 characters or fewer .</param>
        /// <param name="BankCity"> The city of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:70 **Values**:  string of 70 characters or fewer .</param>
        /// <param name="BankCode"> The sort code or number that identifies the bank. This is also known as the sort code. This field is required for direct debit payment methods. **Character limit**: 18 **Values**:  string of 18 characters or fewer .</param>
        /// <param name="BankName"> The name of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:80 **Values**:  string of 80 characters or fewer .</param>
        /// <param name="BankPostalCode"> The zip code or postal code of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:20 **Values**:  string of 20 characters or fewer .</param>
        /// <param name="BankStreetName"> The name of the street of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:60 **Values**:  string of 60 characters or fewer .</param>
        /// <param name="BankStreetNumber"> The number of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:10 **Values**:  string of 10 characters or fewer .</param>
        /// <param name="BankTransferAccountName"> The name on the direct debit bank account. Use this field for direct debit payment methods. **Character limit**: 60 **Values**:  string of 60 characters or fewer .</param>
        /// <param name="BusinessIdentificationCode"> The business identification code for Swiss direct payment methods that use the Global Collect payment gateway. Use this field only for direct debit payments in Switzerland with Global Collect. **Character limit**: 11 **Values**: string of 11 characters or fewer .</param>
        /// <param name="City"> The city of the customer&#39;s address. Use this field for direct debit payment methods. **Character limit**:80 **Values**:  string of 80 characters or fewer .</param>
        /// <param name="Country"> The two-letter country code of the customer&#39;s address. Use this field for direct debit payment methods. **Character limit**: 2 **Values**: [a valid country code](/BC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) .</param>
        /// <param name="CreditCardAddress1"> The first line of the card holder&#39;s address, which is often a street address or business name. Use this field for credit card and direct debit payment methods. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="CreditCardAddress2"> The second line of the card holder&#39;s address. Use this field for credit card and direct debit payment methods. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="CreditCardCity"> The city of the card holder&#39;s address. Use this field for credit card and direct debit payment methods **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="CreditCardCountry"> The country of the card holder&#39;s address. See [a supported country name](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) .</param>
        /// <param name="CreditCardExpirationMonth"> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods. **Character limit**: 2 **Values**: a two-digit number, 01 - 12 .</param>
        /// <param name="CreditCardExpirationYear"> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods. **Character limit**: 4 **Values**: a four-digit number .</param>
        /// <param name="CreditCardHolderName"> The full name of the card holder. Use this field for credit card and direct debit payment methods. **Character limit**: 50 **Values**: a string of 50 characters or fewer .</param>
        /// <param name="CreditCardPostalCode"> The billing address&#39;s zip code. This field is required only when you define a debit card or credit card payment. **Character limit**: 20 **Values**: a string of 20 characters or fewer .</param>
        /// <param name="CreditCardState"> The billing address&#39;s state. Use this field is if the &#x60;CreditCardCountry&#x60; value is either Canada or the US. State names must be spelled in full. For more information see the list of [a valid state name](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) .</param>
        /// <param name="CreditCardType"> The type of credit card or debit card. This field is required only when you define a debit card or credit card payment. **Character limit**: 32 **Values**: &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;MasterCard&#x60;, &#x60;Visa&#x60; .</param>
        /// <param name="DeviceSessionId"> The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently only Verifi supports this field. **Character limit**: 255 **Values**: .</param>
        /// <param name="Email"> An email address for the payment method in addition to the bill to contact email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer .</param>
        /// <param name="ExistingMandate"> Indicates if the customer has an existing mandate or a new mandate. A mandate is a signed authorization for UK and NL customers. When you are migrating mandates from another system, be sure to set this field correctly. If you indicate that a new mandate is an existing mandate or vice-versa, then transactions fail. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No&#x60; .</param>
        /// <param name="FirstName"> The customer&#39;s first name. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer .</param>
        /// <param name="IBAN"> The International Bank Account Number. This field is used only for the direct debit payment method. **Character limit**: 42 **Values**: a string of 42 characters or fewer .</param>
        /// <param name="IPAddress"> The IP address of the user when the payment method was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently PayPal, CyberSource, Authorize.Net, and Verifi support this field. **Character limit**: 15 **Values**: a string of 15 characters or fewer .</param>
        /// <param name="LastName"> The customer&#39;s last name. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="LastTransactionDateTime"> The date of the most recent transaction. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) .</param>
        /// <param name="LastTransactionStatus"> The status of the most recent transaction. **Character limit**: 39 **Values**: automatically generated .</param>
        /// <param name="MandateCreationDate"> The date when the mandate was created. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) .</param>
        /// <param name="MandateID"> The ID of the mandate. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 36 **Values**: a string of 36 characters or fewer .</param>
        /// <param name="MandateReceived"> Indicates if  the mandate was received. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No &#x60;(case-sensitive) .</param>
        /// <param name="MandateUpdateDate"> The date when the mandate was last updated. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) .</param>
        /// <param name="MaxConsecutivePaymentFailures"> Specifies the number of allowable consecutive failures Zuora attempts with the payment method before stopping. **Values**: a valid number .</param>
        /// <param name="NumConsecutiveFailures"> The number of consecutive failed payment for this payment method. It is reset to 0 upon successful payment. You can use the API to update the field value to 0. **Character limit**: **Values**: a positive whole number .</param>
        /// <param name="PaymentMethodStatus"> Specifies the status of the payment method. It is set to Active on creation. **Character limit**: 6 **Values**: &#x60;Active&#x60; or &#x60;Closed&#x60; *Update() functionality added in WSDL 47. PaymentMethodStatus should not be used in the &#x60;create()&#x60; call. You can only set this field to **Closed** via the &#x60;update()&#x60; call. .</param>
        /// <param name="PaymentRetryWindow"> The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours. This field is required if the &#x60;UseDefaultRetryRule&#x60; field value is set to &#x60;false&#x60;. **Character limit**: 4 **Values**: a whole number between 1 and 1000, exclusive .</param>
        /// <param name="Phone"> The phone number that the account holder registered with the bank. This field is used for credit card validation when passing to a gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="PostalCode"> The zip code of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 20 **Values**: a string of 20 characters or fewer .</param>
        /// <param name="State"> The state of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="StreetName"> The street name of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="StreetNumber"> The street number of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer .</param>
        /// <param name="UseDefaultRetryRule"> Determines whether to use the default retry rules configured in the [Z-Payments settings](https://knowledgecenter.zuora.com/CB_Billing/L_Payment_Methods/H_Configure_Payment_Method_Retry_Rules). Set this to &#x60;true&#x60; to use the default retry rules. Set this to &#x60;false&#x60; to set the specific rules for this payment method. If you set this value to &#x60;false&#x60;, then the fields, &#x60;PaymentRetryWindow&#x60; and &#x60;MaxConsecutivePaymentFailures&#x60;, are required. **Character limit**: 5 **Values**: &#x60;t&#x60;&#x60;rue&#x60;, &#x60;false&#x60; .</param>
        public ProxyModifyPaymentMethod(string AccountId = null, string AchAbaCode = null, string AchAccountName = null, string AchAccountType = null, string AchAddress1 = null, string AchAddress2 = null, string AchBankName = null, string BankBranchCode = null, string BankCheckDigit = null, string BankCity = null, string BankCode = null, string BankName = null, string BankPostalCode = null, string BankStreetName = null, string BankStreetNumber = null, string BankTransferAccountName = null, string BusinessIdentificationCode = null, string City = null, string Country = null, string CreditCardAddress1 = null, string CreditCardAddress2 = null, string CreditCardCity = null, string CreditCardCountry = null, int? CreditCardExpirationMonth = null, int? CreditCardExpirationYear = null, string CreditCardHolderName = null, string CreditCardPostalCode = null, string CreditCardState = null, string CreditCardType = null, string DeviceSessionId = null, string Email = null, string ExistingMandate = null, string FirstName = null, string IBAN = null, string IPAddress = null, string LastName = null, DateTime? LastTransactionDateTime = null, string LastTransactionStatus = null, DateTime? MandateCreationDate = null, string MandateID = null, string MandateReceived = null, DateTime? MandateUpdateDate = null, int? MaxConsecutivePaymentFailures = null, int? NumConsecutiveFailures = null, string PaymentMethodStatus = null, int? PaymentRetryWindow = null, string Phone = null, string PostalCode = null, string State = null, string StreetName = null, string StreetNumber = null, bool? UseDefaultRetryRule = null)
        {
            this.AccountId = AccountId;
            this.AchAbaCode = AchAbaCode;
            this.AchAccountName = AchAccountName;
            this.AchAccountType = AchAccountType;
            this.AchAddress1 = AchAddress1;
            this.AchAddress2 = AchAddress2;
            this.AchBankName = AchBankName;
            this.BankBranchCode = BankBranchCode;
            this.BankCheckDigit = BankCheckDigit;
            this.BankCity = BankCity;
            this.BankCode = BankCode;
            this.BankName = BankName;
            this.BankPostalCode = BankPostalCode;
            this.BankStreetName = BankStreetName;
            this.BankStreetNumber = BankStreetNumber;
            this.BankTransferAccountName = BankTransferAccountName;
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
            this.CreditCardPostalCode = CreditCardPostalCode;
            this.CreditCardState = CreditCardState;
            this.CreditCardType = CreditCardType;
            this.DeviceSessionId = DeviceSessionId;
            this.Email = Email;
            this.ExistingMandate = ExistingMandate;
            this.FirstName = FirstName;
            this.IBAN = IBAN;
            this.IPAddress = IPAddress;
            this.LastName = LastName;
            this.LastTransactionDateTime = LastTransactionDateTime;
            this.LastTransactionStatus = LastTransactionStatus;
            this.MandateCreationDate = MandateCreationDate;
            this.MandateID = MandateID;
            this.MandateReceived = MandateReceived;
            this.MandateUpdateDate = MandateUpdateDate;
            this.MaxConsecutivePaymentFailures = MaxConsecutivePaymentFailures;
            this.NumConsecutiveFailures = NumConsecutiveFailures;
            this.PaymentMethodStatus = PaymentMethodStatus;
            this.PaymentRetryWindow = PaymentRetryWindow;
            this.Phone = Phone;
            this.PostalCode = PostalCode;
            this.State = State;
            this.StreetName = StreetName;
            this.StreetNumber = StreetNumber;
            this.UseDefaultRetryRule = UseDefaultRetryRule;
        }
        
        /// <summary>
        ///  The ID of the customer account associated with this payment method. This field is not required for the &#x60;[account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) 
        /// </summary>
        /// <value> The ID of the customer account associated with this payment method. This field is not required for the &#x60;[account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account) </value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        ///  The nine-digit routing number or ABA number used by banks. Use this field for ACH payment methods. **Character limit**: 9 **Values**: a string of 9 characters or fewer 
        /// </summary>
        /// <value> The nine-digit routing number or ABA number used by banks. Use this field for ACH payment methods. **Character limit**: 9 **Values**: a string of 9 characters or fewer </value>
        [DataMember(Name="AchAbaCode", EmitDefaultValue=false)]
        public string AchAbaCode { get; set; }
        /// <summary>
        ///  The name of the account holder, which can be either a person or a company. Use this field for ACH payment methods. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The name of the account holder, which can be either a person or a company. Use this field for ACH payment methods. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name="AchAccountName", EmitDefaultValue=false)]
        public string AchAccountName { get; set; }
        /// <summary>
        ///  The type of bank account associated with the ACH payment. Use this field for ACH payment methods. **Character limit**: 16 **Values**:  - &#x60;BusinessChecking&#x60; - &#x60;Checking&#x60; - &#x60;Saving&#x60; 
        /// </summary>
        /// <value> The type of bank account associated with the ACH payment. Use this field for ACH payment methods. **Character limit**: 16 **Values**:  - &#x60;BusinessChecking&#x60; - &#x60;Checking&#x60; - &#x60;Saving&#x60; </value>
        [DataMember(Name="AchAccountType", EmitDefaultValue=false)]
        public string AchAccountType { get; set; }
        /// <summary>
        ///  Line 1 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways. **Character limit:** **Values:** an address 
        /// </summary>
        /// <value> Line 1 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways. **Character limit:** **Values:** an address </value>
        [DataMember(Name="AchAddress1", EmitDefaultValue=false)]
        public string AchAddress1 { get; set; }
        /// <summary>
        ///  Line 2 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways. **Character limit:** **Values:** an address 
        /// </summary>
        /// <value> Line 2 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways. **Character limit:** **Values:** an address </value>
        [DataMember(Name="AchAddress2", EmitDefaultValue=false)]
        public string AchAddress2 { get; set; }
        /// <summary>
        ///  The name of the bank where the ACH payment account is held. Use this field for ACH payment methods. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The name of the bank where the ACH payment account is held. Use this field for ACH payment methods. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name="AchBankName", EmitDefaultValue=false)]
        public string AchBankName { get; set; }
        /// <summary>
        ///  The branch code of the bank used for direct debit. Use this field for direct debit payment methods. **Character limit**: 10 **Values**:  string of 10 characters or fewer 
        /// </summary>
        /// <value> The branch code of the bank used for direct debit. Use this field for direct debit payment methods. **Character limit**: 10 **Values**:  string of 10 characters or fewer </value>
        [DataMember(Name="BankBranchCode", EmitDefaultValue=false)]
        public string BankBranchCode { get; set; }
        /// <summary>
        /// The check digit in the international bank account number, which confirms the validity of the account. Use this field for direct debit payment methods. **Character limit**: 4 **Values**:  string of 4 characters or fewer 
        /// </summary>
        /// <value>The check digit in the international bank account number, which confirms the validity of the account. Use this field for direct debit payment methods. **Character limit**: 4 **Values**:  string of 4 characters or fewer </value>
        [DataMember(Name="BankCheckDigit", EmitDefaultValue=false)]
        public string BankCheckDigit { get; set; }
        /// <summary>
        ///  The city of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:70 **Values**:  string of 70 characters or fewer 
        /// </summary>
        /// <value> The city of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:70 **Values**:  string of 70 characters or fewer </value>
        [DataMember(Name="BankCity", EmitDefaultValue=false)]
        public string BankCity { get; set; }
        /// <summary>
        ///  The sort code or number that identifies the bank. This is also known as the sort code. This field is required for direct debit payment methods. **Character limit**: 18 **Values**:  string of 18 characters or fewer 
        /// </summary>
        /// <value> The sort code or number that identifies the bank. This is also known as the sort code. This field is required for direct debit payment methods. **Character limit**: 18 **Values**:  string of 18 characters or fewer </value>
        [DataMember(Name="BankCode", EmitDefaultValue=false)]
        public string BankCode { get; set; }
        /// <summary>
        ///  The name of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:80 **Values**:  string of 80 characters or fewer 
        /// </summary>
        /// <value> The name of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:80 **Values**:  string of 80 characters or fewer </value>
        [DataMember(Name="BankName", EmitDefaultValue=false)]
        public string BankName { get; set; }
        /// <summary>
        ///  The zip code or postal code of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:20 **Values**:  string of 20 characters or fewer 
        /// </summary>
        /// <value> The zip code or postal code of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:20 **Values**:  string of 20 characters or fewer </value>
        [DataMember(Name="BankPostalCode", EmitDefaultValue=false)]
        public string BankPostalCode { get; set; }
        /// <summary>
        ///  The name of the street of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:60 **Values**:  string of 60 characters or fewer 
        /// </summary>
        /// <value> The name of the street of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:60 **Values**:  string of 60 characters or fewer </value>
        [DataMember(Name="BankStreetName", EmitDefaultValue=false)]
        public string BankStreetName { get; set; }
        /// <summary>
        ///  The number of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:10 **Values**:  string of 10 characters or fewer 
        /// </summary>
        /// <value> The number of the direct debit bank. Use this field for direct debit payment methods. **Character limit**:10 **Values**:  string of 10 characters or fewer </value>
        [DataMember(Name="BankStreetNumber", EmitDefaultValue=false)]
        public string BankStreetNumber { get; set; }
        /// <summary>
        ///  The name on the direct debit bank account. Use this field for direct debit payment methods. **Character limit**: 60 **Values**:  string of 60 characters or fewer 
        /// </summary>
        /// <value> The name on the direct debit bank account. Use this field for direct debit payment methods. **Character limit**: 60 **Values**:  string of 60 characters or fewer </value>
        [DataMember(Name="BankTransferAccountName", EmitDefaultValue=false)]
        public string BankTransferAccountName { get; set; }
        /// <summary>
        ///  The business identification code for Swiss direct payment methods that use the Global Collect payment gateway. Use this field only for direct debit payments in Switzerland with Global Collect. **Character limit**: 11 **Values**: string of 11 characters or fewer 
        /// </summary>
        /// <value> The business identification code for Swiss direct payment methods that use the Global Collect payment gateway. Use this field only for direct debit payments in Switzerland with Global Collect. **Character limit**: 11 **Values**: string of 11 characters or fewer </value>
        [DataMember(Name="BusinessIdentificationCode", EmitDefaultValue=false)]
        public string BusinessIdentificationCode { get; set; }
        /// <summary>
        ///  The city of the customer&#39;s address. Use this field for direct debit payment methods. **Character limit**:80 **Values**:  string of 80 characters or fewer 
        /// </summary>
        /// <value> The city of the customer&#39;s address. Use this field for direct debit payment methods. **Character limit**:80 **Values**:  string of 80 characters or fewer </value>
        [DataMember(Name="City", EmitDefaultValue=false)]
        public string City { get; set; }
        /// <summary>
        ///  The two-letter country code of the customer&#39;s address. Use this field for direct debit payment methods. **Character limit**: 2 **Values**: [a valid country code](/BC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) 
        /// </summary>
        /// <value> The two-letter country code of the customer&#39;s address. Use this field for direct debit payment methods. **Character limit**: 2 **Values**: [a valid country code](/BC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) </value>
        [DataMember(Name="Country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        ///  The first line of the card holder&#39;s address, which is often a street address or business name. Use this field for credit card and direct debit payment methods. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The first line of the card holder&#39;s address, which is often a street address or business name. Use this field for credit card and direct debit payment methods. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="CreditCardAddress1", EmitDefaultValue=false)]
        public string CreditCardAddress1 { get; set; }
        /// <summary>
        ///  The second line of the card holder&#39;s address. Use this field for credit card and direct debit payment methods. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The second line of the card holder&#39;s address. Use this field for credit card and direct debit payment methods. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="CreditCardAddress2", EmitDefaultValue=false)]
        public string CreditCardAddress2 { get; set; }
        /// <summary>
        ///  The city of the card holder&#39;s address. Use this field for credit card and direct debit payment methods **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The city of the card holder&#39;s address. Use this field for credit card and direct debit payment methods **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="CreditCardCity", EmitDefaultValue=false)]
        public string CreditCardCity { get; set; }
        /// <summary>
        ///  The country of the card holder&#39;s address. See [a supported country name](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) 
        /// </summary>
        /// <value> The country of the card holder&#39;s address. See [a supported country name](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) </value>
        [DataMember(Name="CreditCardCountry", EmitDefaultValue=false)]
        public string CreditCardCountry { get; set; }
        /// <summary>
        ///  The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods. **Character limit**: 2 **Values**: a two-digit number, 01 - 12 
        /// </summary>
        /// <value> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods. **Character limit**: 2 **Values**: a two-digit number, 01 - 12 </value>
        [DataMember(Name="CreditCardExpirationMonth", EmitDefaultValue=false)]
        public int? CreditCardExpirationMonth { get; set; }
        /// <summary>
        ///  The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods. **Character limit**: 4 **Values**: a four-digit number 
        /// </summary>
        /// <value> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods. **Character limit**: 4 **Values**: a four-digit number </value>
        [DataMember(Name="CreditCardExpirationYear", EmitDefaultValue=false)]
        public int? CreditCardExpirationYear { get; set; }
        /// <summary>
        ///  The full name of the card holder. Use this field for credit card and direct debit payment methods. **Character limit**: 50 **Values**: a string of 50 characters or fewer 
        /// </summary>
        /// <value> The full name of the card holder. Use this field for credit card and direct debit payment methods. **Character limit**: 50 **Values**: a string of 50 characters or fewer </value>
        [DataMember(Name="CreditCardHolderName", EmitDefaultValue=false)]
        public string CreditCardHolderName { get; set; }
        /// <summary>
        ///  The billing address&#39;s zip code. This field is required only when you define a debit card or credit card payment. **Character limit**: 20 **Values**: a string of 20 characters or fewer 
        /// </summary>
        /// <value> The billing address&#39;s zip code. This field is required only when you define a debit card or credit card payment. **Character limit**: 20 **Values**: a string of 20 characters or fewer </value>
        [DataMember(Name="CreditCardPostalCode", EmitDefaultValue=false)]
        public string CreditCardPostalCode { get; set; }
        /// <summary>
        ///  The billing address&#39;s state. Use this field is if the &#x60;CreditCardCountry&#x60; value is either Canada or the US. State names must be spelled in full. For more information see the list of [a valid state name](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) 
        /// </summary>
        /// <value> The billing address&#39;s state. Use this field is if the &#x60;CreditCardCountry&#x60; value is either Canada or the US. State names must be spelled in full. For more information see the list of [a valid state name](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) </value>
        [DataMember(Name="CreditCardState", EmitDefaultValue=false)]
        public string CreditCardState { get; set; }
        /// <summary>
        ///  The type of credit card or debit card. This field is required only when you define a debit card or credit card payment. **Character limit**: 32 **Values**: &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;MasterCard&#x60;, &#x60;Visa&#x60; 
        /// </summary>
        /// <value> The type of credit card or debit card. This field is required only when you define a debit card or credit card payment. **Character limit**: 32 **Values**: &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;MasterCard&#x60;, &#x60;Visa&#x60; </value>
        [DataMember(Name="CreditCardType", EmitDefaultValue=false)]
        public string CreditCardType { get; set; }
        /// <summary>
        ///  The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently only Verifi supports this field. **Character limit**: 255 **Values**: 
        /// </summary>
        /// <value> The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently only Verifi supports this field. **Character limit**: 255 **Values**: </value>
        [DataMember(Name="DeviceSessionId", EmitDefaultValue=false)]
        public string DeviceSessionId { get; set; }
        /// <summary>
        ///  An email address for the payment method in addition to the bill to contact email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer 
        /// </summary>
        /// <value> An email address for the payment method in addition to the bill to contact email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer </value>
        [DataMember(Name="Email", EmitDefaultValue=false)]
        public string Email { get; set; }
        /// <summary>
        ///  Indicates if the customer has an existing mandate or a new mandate. A mandate is a signed authorization for UK and NL customers. When you are migrating mandates from another system, be sure to set this field correctly. If you indicate that a new mandate is an existing mandate or vice-versa, then transactions fail. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No&#x60; 
        /// </summary>
        /// <value> Indicates if the customer has an existing mandate or a new mandate. A mandate is a signed authorization for UK and NL customers. When you are migrating mandates from another system, be sure to set this field correctly. If you indicate that a new mandate is an existing mandate or vice-versa, then transactions fail. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No&#x60; </value>
        [DataMember(Name="ExistingMandate", EmitDefaultValue=false)]
        public string ExistingMandate { get; set; }
        /// <summary>
        ///  The customer&#39;s first name. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer 
        /// </summary>
        /// <value> The customer&#39;s first name. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer </value>
        [DataMember(Name="FirstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }
        /// <summary>
        ///  The International Bank Account Number. This field is used only for the direct debit payment method. **Character limit**: 42 **Values**: a string of 42 characters or fewer 
        /// </summary>
        /// <value> The International Bank Account Number. This field is used only for the direct debit payment method. **Character limit**: 42 **Values**: a string of 42 characters or fewer </value>
        [DataMember(Name="IBAN", EmitDefaultValue=false)]
        public string IBAN { get; set; }
        /// <summary>
        ///  The IP address of the user when the payment method was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently PayPal, CyberSource, Authorize.Net, and Verifi support this field. **Character limit**: 15 **Values**: a string of 15 characters or fewer 
        /// </summary>
        /// <value> The IP address of the user when the payment method was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently PayPal, CyberSource, Authorize.Net, and Verifi support this field. **Character limit**: 15 **Values**: a string of 15 characters or fewer </value>
        [DataMember(Name="IPAddress", EmitDefaultValue=false)]
        public string IPAddress { get; set; }
        /// <summary>
        ///  The customer&#39;s last name. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The customer&#39;s last name. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name="LastName", EmitDefaultValue=false)]
        public string LastName { get; set; }
        /// <summary>
        ///  The date of the most recent transaction. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) 
        /// </summary>
        /// <value> The date of the most recent transaction. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) </value>
        [DataMember(Name="LastTransactionDateTime", EmitDefaultValue=false)]
        public DateTime? LastTransactionDateTime { get; set; }
        /// <summary>
        ///  The status of the most recent transaction. **Character limit**: 39 **Values**: automatically generated 
        /// </summary>
        /// <value> The status of the most recent transaction. **Character limit**: 39 **Values**: automatically generated </value>
        [DataMember(Name="LastTransactionStatus", EmitDefaultValue=false)]
        public string LastTransactionStatus { get; set; }
        /// <summary>
        ///  The date when the mandate was created. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) 
        /// </summary>
        /// <value> The date when the mandate was created. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) </value>
        [DataMember(Name="MandateCreationDate", EmitDefaultValue=false)]
        public DateTime? MandateCreationDate { get; set; }
        /// <summary>
        ///  The ID of the mandate. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 36 **Values**: a string of 36 characters or fewer 
        /// </summary>
        /// <value> The ID of the mandate. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 36 **Values**: a string of 36 characters or fewer </value>
        [DataMember(Name="MandateID", EmitDefaultValue=false)]
        public string MandateID { get; set; }
        /// <summary>
        ///  Indicates if  the mandate was received. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No &#x60;(case-sensitive) 
        /// </summary>
        /// <value> Indicates if  the mandate was received. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No &#x60;(case-sensitive) </value>
        [DataMember(Name="MandateReceived", EmitDefaultValue=false)]
        public string MandateReceived { get; set; }
        /// <summary>
        ///  The date when the mandate was last updated. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) 
        /// </summary>
        /// <value> The date when the mandate was last updated. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 **Values**: [a valid date and time value](/CB_Billing/WA_Dates_in_Zuora/A_Date_Format_and_Datetimes_in_Zuora) </value>
        [DataMember(Name="MandateUpdateDate", EmitDefaultValue=false)]
        public DateTime? MandateUpdateDate { get; set; }
        /// <summary>
        ///  Specifies the number of allowable consecutive failures Zuora attempts with the payment method before stopping. **Values**: a valid number 
        /// </summary>
        /// <value> Specifies the number of allowable consecutive failures Zuora attempts with the payment method before stopping. **Values**: a valid number </value>
        [DataMember(Name="MaxConsecutivePaymentFailures", EmitDefaultValue=false)]
        public int? MaxConsecutivePaymentFailures { get; set; }
        /// <summary>
        ///  The number of consecutive failed payment for this payment method. It is reset to 0 upon successful payment. You can use the API to update the field value to 0. **Character limit**: **Values**: a positive whole number 
        /// </summary>
        /// <value> The number of consecutive failed payment for this payment method. It is reset to 0 upon successful payment. You can use the API to update the field value to 0. **Character limit**: **Values**: a positive whole number </value>
        [DataMember(Name="NumConsecutiveFailures", EmitDefaultValue=false)]
        public int? NumConsecutiveFailures { get; set; }
        /// <summary>
        ///  Specifies the status of the payment method. It is set to Active on creation. **Character limit**: 6 **Values**: &#x60;Active&#x60; or &#x60;Closed&#x60; *Update() functionality added in WSDL 47. PaymentMethodStatus should not be used in the &#x60;create()&#x60; call. You can only set this field to **Closed** via the &#x60;update()&#x60; call. 
        /// </summary>
        /// <value> Specifies the status of the payment method. It is set to Active on creation. **Character limit**: 6 **Values**: &#x60;Active&#x60; or &#x60;Closed&#x60; *Update() functionality added in WSDL 47. PaymentMethodStatus should not be used in the &#x60;create()&#x60; call. You can only set this field to **Closed** via the &#x60;update()&#x60; call. </value>
        [DataMember(Name="PaymentMethodStatus", EmitDefaultValue=false)]
        public string PaymentMethodStatus { get; set; }
        /// <summary>
        ///  The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours. This field is required if the &#x60;UseDefaultRetryRule&#x60; field value is set to &#x60;false&#x60;. **Character limit**: 4 **Values**: a whole number between 1 and 1000, exclusive 
        /// </summary>
        /// <value> The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours. This field is required if the &#x60;UseDefaultRetryRule&#x60; field value is set to &#x60;false&#x60;. **Character limit**: 4 **Values**: a whole number between 1 and 1000, exclusive </value>
        [DataMember(Name="PaymentRetryWindow", EmitDefaultValue=false)]
        public int? PaymentRetryWindow { get; set; }
        /// <summary>
        ///  The phone number that the account holder registered with the bank. This field is used for credit card validation when passing to a gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The phone number that the account holder registered with the bank. This field is used for credit card validation when passing to a gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="Phone", EmitDefaultValue=false)]
        public string Phone { get; set; }
        /// <summary>
        ///  The zip code of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 20 **Values**: a string of 20 characters or fewer 
        /// </summary>
        /// <value> The zip code of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 20 **Values**: a string of 20 characters or fewer </value>
        [DataMember(Name="PostalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }
        /// <summary>
        ///  The state of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The state of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name="State", EmitDefaultValue=false)]
        public string State { get; set; }
        /// <summary>
        ///  The street name of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value> The street name of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="StreetName", EmitDefaultValue=false)]
        public string StreetName { get; set; }
        /// <summary>
        ///  The street number of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer 
        /// </summary>
        /// <value> The street number of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer </value>
        [DataMember(Name="StreetNumber", EmitDefaultValue=false)]
        public string StreetNumber { get; set; }
        /// <summary>
        ///  Determines whether to use the default retry rules configured in the [Z-Payments settings](https://knowledgecenter.zuora.com/CB_Billing/L_Payment_Methods/H_Configure_Payment_Method_Retry_Rules). Set this to &#x60;true&#x60; to use the default retry rules. Set this to &#x60;false&#x60; to set the specific rules for this payment method. If you set this value to &#x60;false&#x60;, then the fields, &#x60;PaymentRetryWindow&#x60; and &#x60;MaxConsecutivePaymentFailures&#x60;, are required. **Character limit**: 5 **Values**: &#x60;t&#x60;&#x60;rue&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value> Determines whether to use the default retry rules configured in the [Z-Payments settings](https://knowledgecenter.zuora.com/CB_Billing/L_Payment_Methods/H_Configure_Payment_Method_Retry_Rules). Set this to &#x60;true&#x60; to use the default retry rules. Set this to &#x60;false&#x60; to set the specific rules for this payment method. If you set this value to &#x60;false&#x60;, then the fields, &#x60;PaymentRetryWindow&#x60; and &#x60;MaxConsecutivePaymentFailures&#x60;, are required. **Character limit**: 5 **Values**: &#x60;t&#x60;&#x60;rue&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name="UseDefaultRetryRule", EmitDefaultValue=false)]
        public bool? UseDefaultRetryRule { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyModifyPaymentMethod {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AchAbaCode: ").Append(AchAbaCode).Append("\n");
            sb.Append("  AchAccountName: ").Append(AchAccountName).Append("\n");
            sb.Append("  AchAccountType: ").Append(AchAccountType).Append("\n");
            sb.Append("  AchAddress1: ").Append(AchAddress1).Append("\n");
            sb.Append("  AchAddress2: ").Append(AchAddress2).Append("\n");
            sb.Append("  AchBankName: ").Append(AchBankName).Append("\n");
            sb.Append("  BankBranchCode: ").Append(BankBranchCode).Append("\n");
            sb.Append("  BankCheckDigit: ").Append(BankCheckDigit).Append("\n");
            sb.Append("  BankCity: ").Append(BankCity).Append("\n");
            sb.Append("  BankCode: ").Append(BankCode).Append("\n");
            sb.Append("  BankName: ").Append(BankName).Append("\n");
            sb.Append("  BankPostalCode: ").Append(BankPostalCode).Append("\n");
            sb.Append("  BankStreetName: ").Append(BankStreetName).Append("\n");
            sb.Append("  BankStreetNumber: ").Append(BankStreetNumber).Append("\n");
            sb.Append("  BankTransferAccountName: ").Append(BankTransferAccountName).Append("\n");
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
            sb.Append("  CreditCardPostalCode: ").Append(CreditCardPostalCode).Append("\n");
            sb.Append("  CreditCardState: ").Append(CreditCardState).Append("\n");
            sb.Append("  CreditCardType: ").Append(CreditCardType).Append("\n");
            sb.Append("  DeviceSessionId: ").Append(DeviceSessionId).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ExistingMandate: ").Append(ExistingMandate).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  IBAN: ").Append(IBAN).Append("\n");
            sb.Append("  IPAddress: ").Append(IPAddress).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LastTransactionDateTime: ").Append(LastTransactionDateTime).Append("\n");
            sb.Append("  LastTransactionStatus: ").Append(LastTransactionStatus).Append("\n");
            sb.Append("  MandateCreationDate: ").Append(MandateCreationDate).Append("\n");
            sb.Append("  MandateID: ").Append(MandateID).Append("\n");
            sb.Append("  MandateReceived: ").Append(MandateReceived).Append("\n");
            sb.Append("  MandateUpdateDate: ").Append(MandateUpdateDate).Append("\n");
            sb.Append("  MaxConsecutivePaymentFailures: ").Append(MaxConsecutivePaymentFailures).Append("\n");
            sb.Append("  NumConsecutiveFailures: ").Append(NumConsecutiveFailures).Append("\n");
            sb.Append("  PaymentMethodStatus: ").Append(PaymentMethodStatus).Append("\n");
            sb.Append("  PaymentRetryWindow: ").Append(PaymentRetryWindow).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  StreetName: ").Append(StreetName).Append("\n");
            sb.Append("  StreetNumber: ").Append(StreetNumber).Append("\n");
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
            return this.Equals(obj as ProxyModifyPaymentMethod);
        }

        /// <summary>
        /// Returns true if ProxyModifyPaymentMethod instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyModifyPaymentMethod to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyModifyPaymentMethod other)
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
                    this.AchAccountType == other.AchAccountType ||
                    this.AchAccountType != null &&
                    this.AchAccountType.Equals(other.AchAccountType)
                ) && 
                (
                    this.AchAddress1 == other.AchAddress1 ||
                    this.AchAddress1 != null &&
                    this.AchAddress1.Equals(other.AchAddress1)
                ) && 
                (
                    this.AchAddress2 == other.AchAddress2 ||
                    this.AchAddress2 != null &&
                    this.AchAddress2.Equals(other.AchAddress2)
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
                    this.NumConsecutiveFailures == other.NumConsecutiveFailures ||
                    this.NumConsecutiveFailures != null &&
                    this.NumConsecutiveFailures.Equals(other.NumConsecutiveFailures)
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
                if (this.AchAccountType != null)
                    hash = hash * 59 + this.AchAccountType.GetHashCode();
                if (this.AchAddress1 != null)
                    hash = hash * 59 + this.AchAddress1.GetHashCode();
                if (this.AchAddress2 != null)
                    hash = hash * 59 + this.AchAddress2.GetHashCode();
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
                if (this.NumConsecutiveFailures != null)
                    hash = hash * 59 + this.NumConsecutiveFailures.GetHashCode();
                if (this.PaymentMethodStatus != null)
                    hash = hash * 59 + this.PaymentMethodStatus.GetHashCode();
                if (this.PaymentRetryWindow != null)
                    hash = hash * 59 + this.PaymentRetryWindow.GetHashCode();
                if (this.Phone != null)
                    hash = hash * 59 + this.Phone.GetHashCode();
                if (this.PostalCode != null)
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                if (this.StreetName != null)
                    hash = hash * 59 + this.StreetName.GetHashCode();
                if (this.StreetNumber != null)
                    hash = hash * 59 + this.StreetNumber.GetHashCode();
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
