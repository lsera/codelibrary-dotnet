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


using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using IO.Swagger.Api;
using IO.Swagger.Model;
using IO.Swagger.Client;
using System.Reflection;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing PaymentMethod
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the model.
    /// </remarks>
    [TestFixture]
    public class PaymentMethodTests
    {
        // TODO uncomment below to declare an instance variable for PaymentMethod
        //private PaymentMethod instance;

        /// <summary>
        /// Setup before each test
        /// </summary>
        [SetUp]
        public void Init()
        {
            // TODO uncomment below to create an instance of PaymentMethod
            //instance = new PaymentMethod();
        }

        /// <summary>
        /// Clean up after each test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of PaymentMethod
        /// </summary>
        [Test]
        public void PaymentMethodInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOfType" PaymentMethod
            //Assert.IsInstanceOfType<PaymentMethod> (instance, "variable 'instance' is a PaymentMethod");
        }

        /// <summary>
        /// Test the property 'AccountId'
        /// </summary>
        [Test]
        public void AccountIdTest()
        {
            // TODO unit test for the property 'AccountId'
        }
        /// <summary>
        /// Test the property 'AchAbaCode'
        /// </summary>
        [Test]
        public void AchAbaCodeTest()
        {
            // TODO unit test for the property 'AchAbaCode'
        }
        /// <summary>
        /// Test the property 'AchAccountName'
        /// </summary>
        [Test]
        public void AchAccountNameTest()
        {
            // TODO unit test for the property 'AchAccountName'
        }
        /// <summary>
        /// Test the property 'AchAccountNumber'
        /// </summary>
        [Test]
        public void AchAccountNumberTest()
        {
            // TODO unit test for the property 'AchAccountNumber'
        }
        /// <summary>
        /// Test the property 'AchAccountNumberMask'
        /// </summary>
        [Test]
        public void AchAccountNumberMaskTest()
        {
            // TODO unit test for the property 'AchAccountNumberMask'
        }
        /// <summary>
        /// Test the property 'AchAccountType'
        /// </summary>
        [Test]
        public void AchAccountTypeTest()
        {
            // TODO unit test for the property 'AchAccountType'
        }
        /// <summary>
        /// Test the property 'AchAddress1'
        /// </summary>
        [Test]
        public void AchAddress1Test()
        {
            // TODO unit test for the property 'AchAddress1'
        }
        /// <summary>
        /// Test the property 'AchAddress2'
        /// </summary>
        [Test]
        public void AchAddress2Test()
        {
            // TODO unit test for the property 'AchAddress2'
        }
        /// <summary>
        /// Test the property 'AchBankName'
        /// </summary>
        [Test]
        public void AchBankNameTest()
        {
            // TODO unit test for the property 'AchBankName'
        }
        /// <summary>
        /// Test the property 'Active'
        /// </summary>
        [Test]
        public void ActiveTest()
        {
            // TODO unit test for the property 'Active'
        }
        /// <summary>
        /// Test the property 'BankBranchCode'
        /// </summary>
        [Test]
        public void BankBranchCodeTest()
        {
            // TODO unit test for the property 'BankBranchCode'
        }
        /// <summary>
        /// Test the property 'BankCheckDigit'
        /// </summary>
        [Test]
        public void BankCheckDigitTest()
        {
            // TODO unit test for the property 'BankCheckDigit'
        }
        /// <summary>
        /// Test the property 'BankCity'
        /// </summary>
        [Test]
        public void BankCityTest()
        {
            // TODO unit test for the property 'BankCity'
        }
        /// <summary>
        /// Test the property 'BankCode'
        /// </summary>
        [Test]
        public void BankCodeTest()
        {
            // TODO unit test for the property 'BankCode'
        }
        /// <summary>
        /// Test the property 'BankIdentificationNumber'
        /// </summary>
        [Test]
        public void BankIdentificationNumberTest()
        {
            // TODO unit test for the property 'BankIdentificationNumber'
        }
        /// <summary>
        /// Test the property 'BankName'
        /// </summary>
        [Test]
        public void BankNameTest()
        {
            // TODO unit test for the property 'BankName'
        }
        /// <summary>
        /// Test the property 'BankPostalCode'
        /// </summary>
        [Test]
        public void BankPostalCodeTest()
        {
            // TODO unit test for the property 'BankPostalCode'
        }
        /// <summary>
        /// Test the property 'BankStreetName'
        /// </summary>
        [Test]
        public void BankStreetNameTest()
        {
            // TODO unit test for the property 'BankStreetName'
        }
        /// <summary>
        /// Test the property 'BankStreetNumber'
        /// </summary>
        [Test]
        public void BankStreetNumberTest()
        {
            // TODO unit test for the property 'BankStreetNumber'
        }
        /// <summary>
        /// Test the property 'BankTransferAccountName'
        /// </summary>
        [Test]
        public void BankTransferAccountNameTest()
        {
            // TODO unit test for the property 'BankTransferAccountName'
        }
        /// <summary>
        /// Test the property 'BankTransferAccountNumber'
        /// </summary>
        [Test]
        public void BankTransferAccountNumberTest()
        {
            // TODO unit test for the property 'BankTransferAccountNumber'
        }
        /// <summary>
        /// Test the property 'BankTransferAccountNumberMask'
        /// </summary>
        [Test]
        public void BankTransferAccountNumberMaskTest()
        {
            // TODO unit test for the property 'BankTransferAccountNumberMask'
        }
        /// <summary>
        /// Test the property 'BankTransferAccountType'
        /// </summary>
        [Test]
        public void BankTransferAccountTypeTest()
        {
            // TODO unit test for the property 'BankTransferAccountType'
        }
        /// <summary>
        /// Test the property 'BankTransferType'
        /// </summary>
        [Test]
        public void BankTransferTypeTest()
        {
            // TODO unit test for the property 'BankTransferType'
        }
        /// <summary>
        /// Test the property 'BusinessIdentificationCode'
        /// </summary>
        [Test]
        public void BusinessIdentificationCodeTest()
        {
            // TODO unit test for the property 'BusinessIdentificationCode'
        }
        /// <summary>
        /// Test the property 'City'
        /// </summary>
        [Test]
        public void CityTest()
        {
            // TODO unit test for the property 'City'
        }
        /// <summary>
        /// Test the property 'Country'
        /// </summary>
        [Test]
        public void CountryTest()
        {
            // TODO unit test for the property 'Country'
        }
        /// <summary>
        /// Test the property 'CreatedById'
        /// </summary>
        [Test]
        public void CreatedByIdTest()
        {
            // TODO unit test for the property 'CreatedById'
        }
        /// <summary>
        /// Test the property 'CreatedDate'
        /// </summary>
        [Test]
        public void CreatedDateTest()
        {
            // TODO unit test for the property 'CreatedDate'
        }
        /// <summary>
        /// Test the property 'CreditCardAddress1'
        /// </summary>
        [Test]
        public void CreditCardAddress1Test()
        {
            // TODO unit test for the property 'CreditCardAddress1'
        }
        /// <summary>
        /// Test the property 'CreditCardAddress2'
        /// </summary>
        [Test]
        public void CreditCardAddress2Test()
        {
            // TODO unit test for the property 'CreditCardAddress2'
        }
        /// <summary>
        /// Test the property 'CreditCardCity'
        /// </summary>
        [Test]
        public void CreditCardCityTest()
        {
            // TODO unit test for the property 'CreditCardCity'
        }
        /// <summary>
        /// Test the property 'CreditCardCountry'
        /// </summary>
        [Test]
        public void CreditCardCountryTest()
        {
            // TODO unit test for the property 'CreditCardCountry'
        }
        /// <summary>
        /// Test the property 'CreditCardExpirationMonth'
        /// </summary>
        [Test]
        public void CreditCardExpirationMonthTest()
        {
            // TODO unit test for the property 'CreditCardExpirationMonth'
        }
        /// <summary>
        /// Test the property 'CreditCardExpirationYear'
        /// </summary>
        [Test]
        public void CreditCardExpirationYearTest()
        {
            // TODO unit test for the property 'CreditCardExpirationYear'
        }
        /// <summary>
        /// Test the property 'CreditCardHolderName'
        /// </summary>
        [Test]
        public void CreditCardHolderNameTest()
        {
            // TODO unit test for the property 'CreditCardHolderName'
        }
        /// <summary>
        /// Test the property 'CreditCardMaskNumber'
        /// </summary>
        [Test]
        public void CreditCardMaskNumberTest()
        {
            // TODO unit test for the property 'CreditCardMaskNumber'
        }
        /// <summary>
        /// Test the property 'CreditCardNumber'
        /// </summary>
        [Test]
        public void CreditCardNumberTest()
        {
            // TODO unit test for the property 'CreditCardNumber'
        }
        /// <summary>
        /// Test the property 'CreditCardPostalCode'
        /// </summary>
        [Test]
        public void CreditCardPostalCodeTest()
        {
            // TODO unit test for the property 'CreditCardPostalCode'
        }
        /// <summary>
        /// Test the property 'CreditCardSecurityCode'
        /// </summary>
        [Test]
        public void CreditCardSecurityCodeTest()
        {
            // TODO unit test for the property 'CreditCardSecurityCode'
        }
        /// <summary>
        /// Test the property 'CreditCardState'
        /// </summary>
        [Test]
        public void CreditCardStateTest()
        {
            // TODO unit test for the property 'CreditCardState'
        }
        /// <summary>
        /// Test the property 'CreditCardType'
        /// </summary>
        [Test]
        public void CreditCardTypeTest()
        {
            // TODO unit test for the property 'CreditCardType'
        }
        /// <summary>
        /// Test the property 'DeviceSessionId'
        /// </summary>
        [Test]
        public void DeviceSessionIdTest()
        {
            // TODO unit test for the property 'DeviceSessionId'
        }
        /// <summary>
        /// Test the property 'Email'
        /// </summary>
        [Test]
        public void EmailTest()
        {
            // TODO unit test for the property 'Email'
        }
        /// <summary>
        /// Test the property 'ExistingMandate'
        /// </summary>
        [Test]
        public void ExistingMandateTest()
        {
            // TODO unit test for the property 'ExistingMandate'
        }
        /// <summary>
        /// Test the property 'FirstName'
        /// </summary>
        [Test]
        public void FirstNameTest()
        {
            // TODO unit test for the property 'FirstName'
        }
        /// <summary>
        /// Test the property 'GatewayOptionData'
        /// </summary>
        [Test]
        public void GatewayOptionDataTest()
        {
            // TODO unit test for the property 'GatewayOptionData'
        }
        /// <summary>
        /// Test the property 'IBAN'
        /// </summary>
        [Test]
        public void IBANTest()
        {
            // TODO unit test for the property 'IBAN'
        }
        /// <summary>
        /// Test the property 'IPAddress'
        /// </summary>
        [Test]
        public void IPAddressTest()
        {
            // TODO unit test for the property 'IPAddress'
        }
        /// <summary>
        /// Test the property 'Id'
        /// </summary>
        [Test]
        public void IdTest()
        {
            // TODO unit test for the property 'Id'
        }
        /// <summary>
        /// Test the property 'LastFailedSaleTransactionDate'
        /// </summary>
        [Test]
        public void LastFailedSaleTransactionDateTest()
        {
            // TODO unit test for the property 'LastFailedSaleTransactionDate'
        }
        /// <summary>
        /// Test the property 'LastName'
        /// </summary>
        [Test]
        public void LastNameTest()
        {
            // TODO unit test for the property 'LastName'
        }
        /// <summary>
        /// Test the property 'LastTransactionDateTime'
        /// </summary>
        [Test]
        public void LastTransactionDateTimeTest()
        {
            // TODO unit test for the property 'LastTransactionDateTime'
        }
        /// <summary>
        /// Test the property 'LastTransactionStatus'
        /// </summary>
        [Test]
        public void LastTransactionStatusTest()
        {
            // TODO unit test for the property 'LastTransactionStatus'
        }
        /// <summary>
        /// Test the property 'MandateCreationDate'
        /// </summary>
        [Test]
        public void MandateCreationDateTest()
        {
            // TODO unit test for the property 'MandateCreationDate'
        }
        /// <summary>
        /// Test the property 'MandateID'
        /// </summary>
        [Test]
        public void MandateIDTest()
        {
            // TODO unit test for the property 'MandateID'
        }
        /// <summary>
        /// Test the property 'MandateReceived'
        /// </summary>
        [Test]
        public void MandateReceivedTest()
        {
            // TODO unit test for the property 'MandateReceived'
        }
        /// <summary>
        /// Test the property 'MandateUpdateDate'
        /// </summary>
        [Test]
        public void MandateUpdateDateTest()
        {
            // TODO unit test for the property 'MandateUpdateDate'
        }
        /// <summary>
        /// Test the property 'MaxConsecutivePaymentFailures'
        /// </summary>
        [Test]
        public void MaxConsecutivePaymentFailuresTest()
        {
            // TODO unit test for the property 'MaxConsecutivePaymentFailures'
        }
        /// <summary>
        /// Test the property 'Name'
        /// </summary>
        [Test]
        public void NameTest()
        {
            // TODO unit test for the property 'Name'
        }
        /// <summary>
        /// Test the property 'NumConsecutiveFailures'
        /// </summary>
        [Test]
        public void NumConsecutiveFailuresTest()
        {
            // TODO unit test for the property 'NumConsecutiveFailures'
        }
        /// <summary>
        /// Test the property 'PaymentMethodStatus'
        /// </summary>
        [Test]
        public void PaymentMethodStatusTest()
        {
            // TODO unit test for the property 'PaymentMethodStatus'
        }
        /// <summary>
        /// Test the property 'PaymentRetryWindow'
        /// </summary>
        [Test]
        public void PaymentRetryWindowTest()
        {
            // TODO unit test for the property 'PaymentRetryWindow'
        }
        /// <summary>
        /// Test the property 'PaypalBaid'
        /// </summary>
        [Test]
        public void PaypalBaidTest()
        {
            // TODO unit test for the property 'PaypalBaid'
        }
        /// <summary>
        /// Test the property 'PaypalEmail'
        /// </summary>
        [Test]
        public void PaypalEmailTest()
        {
            // TODO unit test for the property 'PaypalEmail'
        }
        /// <summary>
        /// Test the property 'PaypalPreapprovalKey'
        /// </summary>
        [Test]
        public void PaypalPreapprovalKeyTest()
        {
            // TODO unit test for the property 'PaypalPreapprovalKey'
        }
        /// <summary>
        /// Test the property 'PaypalType'
        /// </summary>
        [Test]
        public void PaypalTypeTest()
        {
            // TODO unit test for the property 'PaypalType'
        }
        /// <summary>
        /// Test the property 'Phone'
        /// </summary>
        [Test]
        public void PhoneTest()
        {
            // TODO unit test for the property 'Phone'
        }
        /// <summary>
        /// Test the property 'PostalCode'
        /// </summary>
        [Test]
        public void PostalCodeTest()
        {
            // TODO unit test for the property 'PostalCode'
        }
        /// <summary>
        /// Test the property 'SecondTokenId'
        /// </summary>
        [Test]
        public void SecondTokenIdTest()
        {
            // TODO unit test for the property 'SecondTokenId'
        }
        /// <summary>
        /// Test the property 'SkipValidation'
        /// </summary>
        [Test]
        public void SkipValidationTest()
        {
            // TODO unit test for the property 'SkipValidation'
        }
        /// <summary>
        /// Test the property 'State'
        /// </summary>
        [Test]
        public void StateTest()
        {
            // TODO unit test for the property 'State'
        }
        /// <summary>
        /// Test the property 'StreetName'
        /// </summary>
        [Test]
        public void StreetNameTest()
        {
            // TODO unit test for the property 'StreetName'
        }
        /// <summary>
        /// Test the property 'StreetNumber'
        /// </summary>
        [Test]
        public void StreetNumberTest()
        {
            // TODO unit test for the property 'StreetNumber'
        }
        /// <summary>
        /// Test the property 'TokenId'
        /// </summary>
        [Test]
        public void TokenIdTest()
        {
            // TODO unit test for the property 'TokenId'
        }
        /// <summary>
        /// Test the property 'TotalNumberOfErrorPayments'
        /// </summary>
        [Test]
        public void TotalNumberOfErrorPaymentsTest()
        {
            // TODO unit test for the property 'TotalNumberOfErrorPayments'
        }
        /// <summary>
        /// Test the property 'TotalNumberOfProcessedPayments'
        /// </summary>
        [Test]
        public void TotalNumberOfProcessedPaymentsTest()
        {
            // TODO unit test for the property 'TotalNumberOfProcessedPayments'
        }
        /// <summary>
        /// Test the property 'Type'
        /// </summary>
        [Test]
        public void TypeTest()
        {
            // TODO unit test for the property 'Type'
        }
        /// <summary>
        /// Test the property 'UpdatedById'
        /// </summary>
        [Test]
        public void UpdatedByIdTest()
        {
            // TODO unit test for the property 'UpdatedById'
        }
        /// <summary>
        /// Test the property 'UpdatedDate'
        /// </summary>
        [Test]
        public void UpdatedDateTest()
        {
            // TODO unit test for the property 'UpdatedDate'
        }
        /// <summary>
        /// Test the property 'UseDefaultRetryRule'
        /// </summary>
        [Test]
        public void UseDefaultRetryRuleTest()
        {
            // TODO unit test for the property 'UseDefaultRetryRule'
        }

    }

}
