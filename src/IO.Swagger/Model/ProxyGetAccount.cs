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
    /// ProxyGetAccount
    /// </summary>
    [DataContract]
    public partial class ProxyGetAccount :  IEquatable<ProxyGetAccount>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetAccount" /> class.
        /// </summary>
        /// <param name="AccountNumber">Unique account number assigned to the account. **Character limit**: 50 **Values**: one of the following:  - null to auto-generate - a string of 50 characters or fewer that doesn&#39;t begin with the default account number prefix .</param>
        /// <param name="AdditionalEmailAddresses">List of additional email addresses to receive emailed invoices. **Character limit**: 120 **Values**: comma-separated list of email addresses .</param>
        /// <param name="AllowInvoiceEdit"> Indicates if associated invoices can be edited. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) .</param>
        /// <param name="AutoPay"> Indicates if future payments are automatically collected when they&#39;re due during a Payment Run. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default) .</param>
        /// <param name="Balance">Current outstanding balance for the account. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="Batch"> Organizes your customer accounts into groups to optimize your billing and payment operations. Required if use the [subscribe()](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E_SOAP_API_Calls/subscribe_call) call, optional for other supported calls. **Character limit**: 20 **Values**:any system-defined batch (&#x60;Batch1&#x60; - &#x60;Batch50 &#x60;or by name). .</param>
        /// <param name="BcdSettingOption">Billing cycle day setting option. **Character limit**: 9 **Values**: &#x60;AutoSet&#x60;, &#x60;ManualSet&#x60; .</param>
        /// <param name="BillCycleDay">Billing cycle day (BCD) on which bill runs generate invoices for the account. **Character limit**: 2 **Values**: any activated system-defined bill cycle day (&#x60;1&#x60; - &#x60;31&#x60;) .</param>
        /// <param name="BillToId">ID of the person to bill for the account. **Character limit**: 32 **Values**: a valid contact ID for the account .</param>
        /// <param name="CommunicationProfileId">Associates the account with a specified communication profile. **Character limit**: 32 **Values**: a valid communication profile ID .</param>
        /// <param name="CreatedById">ID of the Zuora user who created the Account object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate">Date when the Account object was created. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="CreditBalance">Total credit balance for the account. **Character limit**: 16 **Values**: automatically generated .</param>
        /// <param name="CrmId">CRM account ID for the account. A CRM is a customer relationship management system, such as Salesforce.com. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="Currency"> Currency that the customer is billed in. See [a currency value defined in the Zuora Ui admin settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Customize_Currencies) .</param>
        /// <param name="CustomerServiceRepName">Name of the account&#39;s customer service representative, if applicable. **Character limit**: 50 **Values**: a string of 50 characters or fewer .</param>
        /// <param name="DefaultPaymentMethodId">ID of the default payment method for the account. This field is required if the AutoPay field is set to &#x60;true&#x60;. **Character limit**: 32 **Values**: [a valid ID for an existing payment method](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/PaymentMethod) .</param>
        /// <param name="Id">Object identifier..</param>
        /// <param name="InvoiceDeliveryPrefsEmail">Indicates if the customer wants to receive invoices through email.  **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) .</param>
        /// <param name="InvoiceDeliveryPrefsPrint">Indicates if the customer wants to receive printed invoices, such as through postal mail. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) .</param>
        /// <param name="InvoiceTemplateId">The ID of the invoice template. Each customer account can use a specific invoice template for invoice generation. **Character limit**: 32 **Values**: a[ valid template ID configured in Z-Billing Settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Manage_Invoice_Rules_and_Templates) To find the ID of your current invoice template: In Zuora, navigate to **Settings &gt; Z-Billing &gt; Manage Invoice Rules and Templates** and click **Show Id **next to the template you want to use.   .</param>
        /// <param name="LastInvoiceDate"> The date when the previous invoice was generated for the account. The field value is null if no invoice has ever been generated for the account. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="Name">Name of the account as displayed in the Zuora UI. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="Notes"> Comments about the account. **Character limit**: 65,535 **Values**: a string of 65,535 characters .</param>
        /// <param name="ParentId">Identifier of the parent customer account for this Account object. Use this field if you have customer hierarchy enabled. **Character limit**: 32 **Values**: [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) .</param>
        /// <param name="PaymentGateway">Gateway used for processing electronic payments and refunds. **Character limit**: 40 **Values**: one of the following:  - a valid configured gateway name - Null to inherit the default value set in Z-Payment Settings .</param>
        /// <param name="PaymentTerm">Indicates when the customer pays for subscriptions. **Character limit**: 100 **Values**: [a valid, active payment term defined in the web-based UI administrative settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Payment_Terms) .</param>
        /// <param name="PurchaseOrderNumber">The number of the purchase order associated with this account. Purchase order information generally comes from customers. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="SalesRepName">The name of the sales representative associated with this account, if applicable. **Character limit**: 50 **Values**: a string of 50 characters or fewer .</param>
        /// <param name="SoldToId">ID of the person who bought the subscription associated with the account. **Character limit**: 32 **Values**: [a valid contact ID for the account](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Contact) .</param>
        /// <param name="Status">Status of the account in the system. **Character limit**: 8 **Values**: one of the following:  - leave null if you&#39;re using &#x60;subscribe()&#x60; - if you&#39;re using &#x60;create()&#x60;: - &#x60;Draft&#x60; - &#x60;Active&#x60; - &#x60;Canceled&#x60; .</param>
        /// <param name="TaxCompanyCode"> Unique code that identifies a company account in Avalara. Use this field to calculate taxes based on origin and sold-to addresses in Avalara. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Character limit**: 50 **Values**: a valid company code .</param>
        /// <param name="TaxExemptCertificateID">ID of your customer&#39;s tax exemption certificate. **Character limit**: 32 **Values**: a string of 32 characters or fewer .</param>
        /// <param name="TaxExemptCertificateType">Type of the tax exemption certificate that your customer holds.  **Character limit**: 32 **Values**: a string of 32 characters or fewer .</param>
        /// <param name="TaxExemptDescription">Description of the tax exemption certificate that your customer holds. **Character limit**: 500 **Values**: a string of 500 characters or fewer .</param>
        /// <param name="TaxExemptEffectiveDate">Date when the the customer&#39;s tax exemption starts. **Character limit**: 29 **Version notes**: requires Z-Tax .</param>
        /// <param name="TaxExemptExpirationDate">Date when the customer&#39;s tax exemption certificate expires  **Character limit**: 29 **Version notes**: requires Z-Tax .</param>
        /// <param name="TaxExemptIssuingJurisdiction">Indicates the jurisdiction in which the customer&#39;s tax exemption certificate was issued. **Character limit**: 32 **Values**: a string of 32 characters or fewer .</param>
        /// <param name="TaxExemptStatus"> Status of the account&#39;s tax exemption. Required if you use Z-Tax. This field is unavailable if you don&#39;t use Z-Tax. **Character limit**: 19 **Values**: one of the following:  - &#x60;Yes&#x60; - &#x60;No&#x60; - &#x60;PendingVerification&#x60; .</param>
        /// <param name="TotalInvoiceBalance">Total balance of the account&#39;s invoices. **Character limit**: 16 **Values**: a valid currency value .</param>
        /// <param name="UpdatedById">ID of the user who last updated the account. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="UpdatedDate">Date when the account was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="VATId"> EU Value Added Tax ID. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Character limit**: 25 **Values**: a valid Value Added Tax ID .</param>
        public ProxyGetAccount(string AccountNumber = null, string AdditionalEmailAddresses = null, bool? AllowInvoiceEdit = null, bool? AutoPay = null, double? Balance = null, string Batch = null, string BcdSettingOption = null, int? BillCycleDay = null, string BillToId = null, string CommunicationProfileId = null, string CreatedById = null, DateTime? CreatedDate = null, double? CreditBalance = null, string CrmId = null, string Currency = null, string CustomerServiceRepName = null, string DefaultPaymentMethodId = null, string Id = null, bool? InvoiceDeliveryPrefsEmail = null, bool? InvoiceDeliveryPrefsPrint = null, string InvoiceTemplateId = null, DateTime? LastInvoiceDate = null, string Name = null, string Notes = null, string ParentId = null, string PaymentGateway = null, string PaymentTerm = null, string PurchaseOrderNumber = null, string SalesRepName = null, string SoldToId = null, string Status = null, string TaxCompanyCode = null, string TaxExemptCertificateID = null, string TaxExemptCertificateType = null, string TaxExemptDescription = null, DateTime? TaxExemptEffectiveDate = null, DateTime? TaxExemptExpirationDate = null, string TaxExemptIssuingJurisdiction = null, string TaxExemptStatus = null, double? TotalInvoiceBalance = null, string UpdatedById = null, DateTime? UpdatedDate = null, string VATId = null)
        {
            this.AccountNumber = AccountNumber;
            this.AdditionalEmailAddresses = AdditionalEmailAddresses;
            this.AllowInvoiceEdit = AllowInvoiceEdit;
            this.AutoPay = AutoPay;
            this.Balance = Balance;
            this.Batch = Batch;
            this.BcdSettingOption = BcdSettingOption;
            this.BillCycleDay = BillCycleDay;
            this.BillToId = BillToId;
            this.CommunicationProfileId = CommunicationProfileId;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.CreditBalance = CreditBalance;
            this.CrmId = CrmId;
            this.Currency = Currency;
            this.CustomerServiceRepName = CustomerServiceRepName;
            this.DefaultPaymentMethodId = DefaultPaymentMethodId;
            this.Id = Id;
            this.InvoiceDeliveryPrefsEmail = InvoiceDeliveryPrefsEmail;
            this.InvoiceDeliveryPrefsPrint = InvoiceDeliveryPrefsPrint;
            this.InvoiceTemplateId = InvoiceTemplateId;
            this.LastInvoiceDate = LastInvoiceDate;
            this.Name = Name;
            this.Notes = Notes;
            this.ParentId = ParentId;
            this.PaymentGateway = PaymentGateway;
            this.PaymentTerm = PaymentTerm;
            this.PurchaseOrderNumber = PurchaseOrderNumber;
            this.SalesRepName = SalesRepName;
            this.SoldToId = SoldToId;
            this.Status = Status;
            this.TaxCompanyCode = TaxCompanyCode;
            this.TaxExemptCertificateID = TaxExemptCertificateID;
            this.TaxExemptCertificateType = TaxExemptCertificateType;
            this.TaxExemptDescription = TaxExemptDescription;
            this.TaxExemptEffectiveDate = TaxExemptEffectiveDate;
            this.TaxExemptExpirationDate = TaxExemptExpirationDate;
            this.TaxExemptIssuingJurisdiction = TaxExemptIssuingJurisdiction;
            this.TaxExemptStatus = TaxExemptStatus;
            this.TotalInvoiceBalance = TotalInvoiceBalance;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
            this.VATId = VATId;
        }
        
        /// <summary>
        /// Unique account number assigned to the account. **Character limit**: 50 **Values**: one of the following:  - null to auto-generate - a string of 50 characters or fewer that doesn&#39;t begin with the default account number prefix 
        /// </summary>
        /// <value>Unique account number assigned to the account. **Character limit**: 50 **Values**: one of the following:  - null to auto-generate - a string of 50 characters or fewer that doesn&#39;t begin with the default account number prefix </value>
        [DataMember(Name="AccountNumber", EmitDefaultValue=false)]
        public string AccountNumber { get; set; }
        /// <summary>
        /// List of additional email addresses to receive emailed invoices. **Character limit**: 120 **Values**: comma-separated list of email addresses 
        /// </summary>
        /// <value>List of additional email addresses to receive emailed invoices. **Character limit**: 120 **Values**: comma-separated list of email addresses </value>
        [DataMember(Name="AdditionalEmailAddresses", EmitDefaultValue=false)]
        public string AdditionalEmailAddresses { get; set; }
        /// <summary>
        ///  Indicates if associated invoices can be edited. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) 
        /// </summary>
        /// <value> Indicates if associated invoices can be edited. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) </value>
        [DataMember(Name="AllowInvoiceEdit", EmitDefaultValue=false)]
        public bool? AllowInvoiceEdit { get; set; }
        /// <summary>
        ///  Indicates if future payments are automatically collected when they&#39;re due during a Payment Run. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default) 
        /// </summary>
        /// <value> Indicates if future payments are automatically collected when they&#39;re due during a Payment Run. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default) </value>
        [DataMember(Name="AutoPay", EmitDefaultValue=false)]
        public bool? AutoPay { get; set; }
        /// <summary>
        /// Current outstanding balance for the account. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value>Current outstanding balance for the account. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="Balance", EmitDefaultValue=false)]
        public double? Balance { get; set; }
        /// <summary>
        ///  Organizes your customer accounts into groups to optimize your billing and payment operations. Required if use the [subscribe()](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E_SOAP_API_Calls/subscribe_call) call, optional for other supported calls. **Character limit**: 20 **Values**:any system-defined batch (&#x60;Batch1&#x60; - &#x60;Batch50 &#x60;or by name). 
        /// </summary>
        /// <value> Organizes your customer accounts into groups to optimize your billing and payment operations. Required if use the [subscribe()](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E_SOAP_API_Calls/subscribe_call) call, optional for other supported calls. **Character limit**: 20 **Values**:any system-defined batch (&#x60;Batch1&#x60; - &#x60;Batch50 &#x60;or by name). </value>
        [DataMember(Name="Batch", EmitDefaultValue=false)]
        public string Batch { get; set; }
        /// <summary>
        /// Billing cycle day setting option. **Character limit**: 9 **Values**: &#x60;AutoSet&#x60;, &#x60;ManualSet&#x60; 
        /// </summary>
        /// <value>Billing cycle day setting option. **Character limit**: 9 **Values**: &#x60;AutoSet&#x60;, &#x60;ManualSet&#x60; </value>
        [DataMember(Name="BcdSettingOption", EmitDefaultValue=false)]
        public string BcdSettingOption { get; set; }
        /// <summary>
        /// Billing cycle day (BCD) on which bill runs generate invoices for the account. **Character limit**: 2 **Values**: any activated system-defined bill cycle day (&#x60;1&#x60; - &#x60;31&#x60;) 
        /// </summary>
        /// <value>Billing cycle day (BCD) on which bill runs generate invoices for the account. **Character limit**: 2 **Values**: any activated system-defined bill cycle day (&#x60;1&#x60; - &#x60;31&#x60;) </value>
        [DataMember(Name="BillCycleDay", EmitDefaultValue=false)]
        public int? BillCycleDay { get; set; }
        /// <summary>
        /// ID of the person to bill for the account. **Character limit**: 32 **Values**: a valid contact ID for the account 
        /// </summary>
        /// <value>ID of the person to bill for the account. **Character limit**: 32 **Values**: a valid contact ID for the account </value>
        [DataMember(Name="BillToId", EmitDefaultValue=false)]
        public string BillToId { get; set; }
        /// <summary>
        /// Associates the account with a specified communication profile. **Character limit**: 32 **Values**: a valid communication profile ID 
        /// </summary>
        /// <value>Associates the account with a specified communication profile. **Character limit**: 32 **Values**: a valid communication profile ID </value>
        [DataMember(Name="CommunicationProfileId", EmitDefaultValue=false)]
        public string CommunicationProfileId { get; set; }
        /// <summary>
        /// ID of the Zuora user who created the Account object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>ID of the Zuora user who created the Account object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        /// Date when the Account object was created. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value>Date when the Account object was created. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Total credit balance for the account. **Character limit**: 16 **Values**: automatically generated 
        /// </summary>
        /// <value>Total credit balance for the account. **Character limit**: 16 **Values**: automatically generated </value>
        [DataMember(Name="CreditBalance", EmitDefaultValue=false)]
        public double? CreditBalance { get; set; }
        /// <summary>
        /// CRM account ID for the account. A CRM is a customer relationship management system, such as Salesforce.com. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value>CRM account ID for the account. A CRM is a customer relationship management system, such as Salesforce.com. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="CrmId", EmitDefaultValue=false)]
        public string CrmId { get; set; }
        /// <summary>
        ///  Currency that the customer is billed in. See [a currency value defined in the Zuora Ui admin settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Customize_Currencies) 
        /// </summary>
        /// <value> Currency that the customer is billed in. See [a currency value defined in the Zuora Ui admin settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Customize_Currencies) </value>
        [DataMember(Name="Currency", EmitDefaultValue=false)]
        public string Currency { get; set; }
        /// <summary>
        /// Name of the account&#39;s customer service representative, if applicable. **Character limit**: 50 **Values**: a string of 50 characters or fewer 
        /// </summary>
        /// <value>Name of the account&#39;s customer service representative, if applicable. **Character limit**: 50 **Values**: a string of 50 characters or fewer </value>
        [DataMember(Name="CustomerServiceRepName", EmitDefaultValue=false)]
        public string CustomerServiceRepName { get; set; }
        /// <summary>
        /// ID of the default payment method for the account. This field is required if the AutoPay field is set to &#x60;true&#x60;. **Character limit**: 32 **Values**: [a valid ID for an existing payment method](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/PaymentMethod) 
        /// </summary>
        /// <value>ID of the default payment method for the account. This field is required if the AutoPay field is set to &#x60;true&#x60;. **Character limit**: 32 **Values**: [a valid ID for an existing payment method](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/PaymentMethod) </value>
        [DataMember(Name="DefaultPaymentMethodId", EmitDefaultValue=false)]
        public string DefaultPaymentMethodId { get; set; }
        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name="Id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Indicates if the customer wants to receive invoices through email.  **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) 
        /// </summary>
        /// <value>Indicates if the customer wants to receive invoices through email.  **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) </value>
        [DataMember(Name="InvoiceDeliveryPrefsEmail", EmitDefaultValue=false)]
        public bool? InvoiceDeliveryPrefsEmail { get; set; }
        /// <summary>
        /// Indicates if the customer wants to receive printed invoices, such as through postal mail. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) 
        /// </summary>
        /// <value>Indicates if the customer wants to receive printed invoices, such as through postal mail. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; (default if left null) </value>
        [DataMember(Name="InvoiceDeliveryPrefsPrint", EmitDefaultValue=false)]
        public bool? InvoiceDeliveryPrefsPrint { get; set; }
        /// <summary>
        /// The ID of the invoice template. Each customer account can use a specific invoice template for invoice generation. **Character limit**: 32 **Values**: a[ valid template ID configured in Z-Billing Settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Manage_Invoice_Rules_and_Templates) To find the ID of your current invoice template: In Zuora, navigate to **Settings &gt; Z-Billing &gt; Manage Invoice Rules and Templates** and click **Show Id **next to the template you want to use.   
        /// </summary>
        /// <value>The ID of the invoice template. Each customer account can use a specific invoice template for invoice generation. **Character limit**: 32 **Values**: a[ valid template ID configured in Z-Billing Settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Manage_Invoice_Rules_and_Templates) To find the ID of your current invoice template: In Zuora, navigate to **Settings &gt; Z-Billing &gt; Manage Invoice Rules and Templates** and click **Show Id **next to the template you want to use.   </value>
        [DataMember(Name="InvoiceTemplateId", EmitDefaultValue=false)]
        public string InvoiceTemplateId { get; set; }
        /// <summary>
        ///  The date when the previous invoice was generated for the account. The field value is null if no invoice has ever been generated for the account. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the previous invoice was generated for the account. The field value is null if no invoice has ever been generated for the account. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="LastInvoiceDate", EmitDefaultValue=false)]
        public DateTime? LastInvoiceDate { get; set; }
        /// <summary>
        /// Name of the account as displayed in the Zuora UI. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value>Name of the account as displayed in the Zuora UI. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        ///  Comments about the account. **Character limit**: 65,535 **Values**: a string of 65,535 characters 
        /// </summary>
        /// <value> Comments about the account. **Character limit**: 65,535 **Values**: a string of 65,535 characters </value>
        [DataMember(Name="Notes", EmitDefaultValue=false)]
        public string Notes { get; set; }
        /// <summary>
        /// Identifier of the parent customer account for this Account object. Use this field if you have customer hierarchy enabled. **Character limit**: 32 **Values**: [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) 
        /// </summary>
        /// <value>Identifier of the parent customer account for this Account object. Use this field if you have customer hierarchy enabled. **Character limit**: 32 **Values**: [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) </value>
        [DataMember(Name="ParentId", EmitDefaultValue=false)]
        public string ParentId { get; set; }
        /// <summary>
        /// Gateway used for processing electronic payments and refunds. **Character limit**: 40 **Values**: one of the following:  - a valid configured gateway name - Null to inherit the default value set in Z-Payment Settings 
        /// </summary>
        /// <value>Gateway used for processing electronic payments and refunds. **Character limit**: 40 **Values**: one of the following:  - a valid configured gateway name - Null to inherit the default value set in Z-Payment Settings </value>
        [DataMember(Name="PaymentGateway", EmitDefaultValue=false)]
        public string PaymentGateway { get; set; }
        /// <summary>
        /// Indicates when the customer pays for subscriptions. **Character limit**: 100 **Values**: [a valid, active payment term defined in the web-based UI administrative settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Payment_Terms) 
        /// </summary>
        /// <value>Indicates when the customer pays for subscriptions. **Character limit**: 100 **Values**: [a valid, active payment term defined in the web-based UI administrative settings](https://knowledgecenter.zuora.com/CB_Billing/Billing_Settings/Define_Payment_Terms) </value>
        [DataMember(Name="PaymentTerm", EmitDefaultValue=false)]
        public string PaymentTerm { get; set; }
        /// <summary>
        /// The number of the purchase order associated with this account. Purchase order information generally comes from customers. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value>The number of the purchase order associated with this account. Purchase order information generally comes from customers. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="PurchaseOrderNumber", EmitDefaultValue=false)]
        public string PurchaseOrderNumber { get; set; }
        /// <summary>
        /// The name of the sales representative associated with this account, if applicable. **Character limit**: 50 **Values**: a string of 50 characters or fewer 
        /// </summary>
        /// <value>The name of the sales representative associated with this account, if applicable. **Character limit**: 50 **Values**: a string of 50 characters or fewer </value>
        [DataMember(Name="SalesRepName", EmitDefaultValue=false)]
        public string SalesRepName { get; set; }
        /// <summary>
        /// ID of the person who bought the subscription associated with the account. **Character limit**: 32 **Values**: [a valid contact ID for the account](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Contact) 
        /// </summary>
        /// <value>ID of the person who bought the subscription associated with the account. **Character limit**: 32 **Values**: [a valid contact ID for the account](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Contact) </value>
        [DataMember(Name="SoldToId", EmitDefaultValue=false)]
        public string SoldToId { get; set; }
        /// <summary>
        /// Status of the account in the system. **Character limit**: 8 **Values**: one of the following:  - leave null if you&#39;re using &#x60;subscribe()&#x60; - if you&#39;re using &#x60;create()&#x60;: - &#x60;Draft&#x60; - &#x60;Active&#x60; - &#x60;Canceled&#x60; 
        /// </summary>
        /// <value>Status of the account in the system. **Character limit**: 8 **Values**: one of the following:  - leave null if you&#39;re using &#x60;subscribe()&#x60; - if you&#39;re using &#x60;create()&#x60;: - &#x60;Draft&#x60; - &#x60;Active&#x60; - &#x60;Canceled&#x60; </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        ///  Unique code that identifies a company account in Avalara. Use this field to calculate taxes based on origin and sold-to addresses in Avalara. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Character limit**: 50 **Values**: a valid company code 
        /// </summary>
        /// <value> Unique code that identifies a company account in Avalara. Use this field to calculate taxes based on origin and sold-to addresses in Avalara. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Character limit**: 50 **Values**: a valid company code </value>
        [DataMember(Name="TaxCompanyCode", EmitDefaultValue=false)]
        public string TaxCompanyCode { get; set; }
        /// <summary>
        /// ID of your customer&#39;s tax exemption certificate. **Character limit**: 32 **Values**: a string of 32 characters or fewer 
        /// </summary>
        /// <value>ID of your customer&#39;s tax exemption certificate. **Character limit**: 32 **Values**: a string of 32 characters or fewer </value>
        [DataMember(Name="TaxExemptCertificateID", EmitDefaultValue=false)]
        public string TaxExemptCertificateID { get; set; }
        /// <summary>
        /// Type of the tax exemption certificate that your customer holds.  **Character limit**: 32 **Values**: a string of 32 characters or fewer 
        /// </summary>
        /// <value>Type of the tax exemption certificate that your customer holds.  **Character limit**: 32 **Values**: a string of 32 characters or fewer </value>
        [DataMember(Name="TaxExemptCertificateType", EmitDefaultValue=false)]
        public string TaxExemptCertificateType { get; set; }
        /// <summary>
        /// Description of the tax exemption certificate that your customer holds. **Character limit**: 500 **Values**: a string of 500 characters or fewer 
        /// </summary>
        /// <value>Description of the tax exemption certificate that your customer holds. **Character limit**: 500 **Values**: a string of 500 characters or fewer </value>
        [DataMember(Name="TaxExemptDescription", EmitDefaultValue=false)]
        public string TaxExemptDescription { get; set; }
        /// <summary>
        /// Date when the the customer&#39;s tax exemption starts. **Character limit**: 29 **Version notes**: requires Z-Tax 
        /// </summary>
        /// <value>Date when the the customer&#39;s tax exemption starts. **Character limit**: 29 **Version notes**: requires Z-Tax </value>
        [DataMember(Name="TaxExemptEffectiveDate", EmitDefaultValue=false)]
        public DateTime? TaxExemptEffectiveDate { get; set; }
        /// <summary>
        /// Date when the customer&#39;s tax exemption certificate expires  **Character limit**: 29 **Version notes**: requires Z-Tax 
        /// </summary>
        /// <value>Date when the customer&#39;s tax exemption certificate expires  **Character limit**: 29 **Version notes**: requires Z-Tax </value>
        [DataMember(Name="TaxExemptExpirationDate", EmitDefaultValue=false)]
        public DateTime? TaxExemptExpirationDate { get; set; }
        /// <summary>
        /// Indicates the jurisdiction in which the customer&#39;s tax exemption certificate was issued. **Character limit**: 32 **Values**: a string of 32 characters or fewer 
        /// </summary>
        /// <value>Indicates the jurisdiction in which the customer&#39;s tax exemption certificate was issued. **Character limit**: 32 **Values**: a string of 32 characters or fewer </value>
        [DataMember(Name="TaxExemptIssuingJurisdiction", EmitDefaultValue=false)]
        public string TaxExemptIssuingJurisdiction { get; set; }
        /// <summary>
        ///  Status of the account&#39;s tax exemption. Required if you use Z-Tax. This field is unavailable if you don&#39;t use Z-Tax. **Character limit**: 19 **Values**: one of the following:  - &#x60;Yes&#x60; - &#x60;No&#x60; - &#x60;PendingVerification&#x60; 
        /// </summary>
        /// <value> Status of the account&#39;s tax exemption. Required if you use Z-Tax. This field is unavailable if you don&#39;t use Z-Tax. **Character limit**: 19 **Values**: one of the following:  - &#x60;Yes&#x60; - &#x60;No&#x60; - &#x60;PendingVerification&#x60; </value>
        [DataMember(Name="TaxExemptStatus", EmitDefaultValue=false)]
        public string TaxExemptStatus { get; set; }
        /// <summary>
        /// Total balance of the account&#39;s invoices. **Character limit**: 16 **Values**: a valid currency value 
        /// </summary>
        /// <value>Total balance of the account&#39;s invoices. **Character limit**: 16 **Values**: a valid currency value </value>
        [DataMember(Name="TotalInvoiceBalance", EmitDefaultValue=false)]
        public double? TotalInvoiceBalance { get; set; }
        /// <summary>
        /// ID of the user who last updated the account. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>ID of the user who last updated the account. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        /// Date when the account was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value>Date when the account was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        ///  EU Value Added Tax ID. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Character limit**: 25 **Values**: a valid Value Added Tax ID 
        /// </summary>
        /// <value> EU Value Added Tax ID. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Character limit**: 25 **Values**: a valid Value Added Tax ID </value>
        [DataMember(Name="VATId", EmitDefaultValue=false)]
        public string VATId { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyGetAccount {\n");
            sb.Append("  AccountNumber: ").Append(AccountNumber).Append("\n");
            sb.Append("  AdditionalEmailAddresses: ").Append(AdditionalEmailAddresses).Append("\n");
            sb.Append("  AllowInvoiceEdit: ").Append(AllowInvoiceEdit).Append("\n");
            sb.Append("  AutoPay: ").Append(AutoPay).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  Batch: ").Append(Batch).Append("\n");
            sb.Append("  BcdSettingOption: ").Append(BcdSettingOption).Append("\n");
            sb.Append("  BillCycleDay: ").Append(BillCycleDay).Append("\n");
            sb.Append("  BillToId: ").Append(BillToId).Append("\n");
            sb.Append("  CommunicationProfileId: ").Append(CommunicationProfileId).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CreditBalance: ").Append(CreditBalance).Append("\n");
            sb.Append("  CrmId: ").Append(CrmId).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  CustomerServiceRepName: ").Append(CustomerServiceRepName).Append("\n");
            sb.Append("  DefaultPaymentMethodId: ").Append(DefaultPaymentMethodId).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  InvoiceDeliveryPrefsEmail: ").Append(InvoiceDeliveryPrefsEmail).Append("\n");
            sb.Append("  InvoiceDeliveryPrefsPrint: ").Append(InvoiceDeliveryPrefsPrint).Append("\n");
            sb.Append("  InvoiceTemplateId: ").Append(InvoiceTemplateId).Append("\n");
            sb.Append("  LastInvoiceDate: ").Append(LastInvoiceDate).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  PaymentGateway: ").Append(PaymentGateway).Append("\n");
            sb.Append("  PaymentTerm: ").Append(PaymentTerm).Append("\n");
            sb.Append("  PurchaseOrderNumber: ").Append(PurchaseOrderNumber).Append("\n");
            sb.Append("  SalesRepName: ").Append(SalesRepName).Append("\n");
            sb.Append("  SoldToId: ").Append(SoldToId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TaxCompanyCode: ").Append(TaxCompanyCode).Append("\n");
            sb.Append("  TaxExemptCertificateID: ").Append(TaxExemptCertificateID).Append("\n");
            sb.Append("  TaxExemptCertificateType: ").Append(TaxExemptCertificateType).Append("\n");
            sb.Append("  TaxExemptDescription: ").Append(TaxExemptDescription).Append("\n");
            sb.Append("  TaxExemptEffectiveDate: ").Append(TaxExemptEffectiveDate).Append("\n");
            sb.Append("  TaxExemptExpirationDate: ").Append(TaxExemptExpirationDate).Append("\n");
            sb.Append("  TaxExemptIssuingJurisdiction: ").Append(TaxExemptIssuingJurisdiction).Append("\n");
            sb.Append("  TaxExemptStatus: ").Append(TaxExemptStatus).Append("\n");
            sb.Append("  TotalInvoiceBalance: ").Append(TotalInvoiceBalance).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  VATId: ").Append(VATId).Append("\n");
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
            return this.Equals(obj as ProxyGetAccount);
        }

        /// <summary>
        /// Returns true if ProxyGetAccount instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyGetAccount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetAccount other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountNumber == other.AccountNumber ||
                    this.AccountNumber != null &&
                    this.AccountNumber.Equals(other.AccountNumber)
                ) && 
                (
                    this.AdditionalEmailAddresses == other.AdditionalEmailAddresses ||
                    this.AdditionalEmailAddresses != null &&
                    this.AdditionalEmailAddresses.Equals(other.AdditionalEmailAddresses)
                ) && 
                (
                    this.AllowInvoiceEdit == other.AllowInvoiceEdit ||
                    this.AllowInvoiceEdit != null &&
                    this.AllowInvoiceEdit.Equals(other.AllowInvoiceEdit)
                ) && 
                (
                    this.AutoPay == other.AutoPay ||
                    this.AutoPay != null &&
                    this.AutoPay.Equals(other.AutoPay)
                ) && 
                (
                    this.Balance == other.Balance ||
                    this.Balance != null &&
                    this.Balance.Equals(other.Balance)
                ) && 
                (
                    this.Batch == other.Batch ||
                    this.Batch != null &&
                    this.Batch.Equals(other.Batch)
                ) && 
                (
                    this.BcdSettingOption == other.BcdSettingOption ||
                    this.BcdSettingOption != null &&
                    this.BcdSettingOption.Equals(other.BcdSettingOption)
                ) && 
                (
                    this.BillCycleDay == other.BillCycleDay ||
                    this.BillCycleDay != null &&
                    this.BillCycleDay.Equals(other.BillCycleDay)
                ) && 
                (
                    this.BillToId == other.BillToId ||
                    this.BillToId != null &&
                    this.BillToId.Equals(other.BillToId)
                ) && 
                (
                    this.CommunicationProfileId == other.CommunicationProfileId ||
                    this.CommunicationProfileId != null &&
                    this.CommunicationProfileId.Equals(other.CommunicationProfileId)
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
                    this.CreditBalance == other.CreditBalance ||
                    this.CreditBalance != null &&
                    this.CreditBalance.Equals(other.CreditBalance)
                ) && 
                (
                    this.CrmId == other.CrmId ||
                    this.CrmId != null &&
                    this.CrmId.Equals(other.CrmId)
                ) && 
                (
                    this.Currency == other.Currency ||
                    this.Currency != null &&
                    this.Currency.Equals(other.Currency)
                ) && 
                (
                    this.CustomerServiceRepName == other.CustomerServiceRepName ||
                    this.CustomerServiceRepName != null &&
                    this.CustomerServiceRepName.Equals(other.CustomerServiceRepName)
                ) && 
                (
                    this.DefaultPaymentMethodId == other.DefaultPaymentMethodId ||
                    this.DefaultPaymentMethodId != null &&
                    this.DefaultPaymentMethodId.Equals(other.DefaultPaymentMethodId)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.InvoiceDeliveryPrefsEmail == other.InvoiceDeliveryPrefsEmail ||
                    this.InvoiceDeliveryPrefsEmail != null &&
                    this.InvoiceDeliveryPrefsEmail.Equals(other.InvoiceDeliveryPrefsEmail)
                ) && 
                (
                    this.InvoiceDeliveryPrefsPrint == other.InvoiceDeliveryPrefsPrint ||
                    this.InvoiceDeliveryPrefsPrint != null &&
                    this.InvoiceDeliveryPrefsPrint.Equals(other.InvoiceDeliveryPrefsPrint)
                ) && 
                (
                    this.InvoiceTemplateId == other.InvoiceTemplateId ||
                    this.InvoiceTemplateId != null &&
                    this.InvoiceTemplateId.Equals(other.InvoiceTemplateId)
                ) && 
                (
                    this.LastInvoiceDate == other.LastInvoiceDate ||
                    this.LastInvoiceDate != null &&
                    this.LastInvoiceDate.Equals(other.LastInvoiceDate)
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
                    this.ParentId == other.ParentId ||
                    this.ParentId != null &&
                    this.ParentId.Equals(other.ParentId)
                ) && 
                (
                    this.PaymentGateway == other.PaymentGateway ||
                    this.PaymentGateway != null &&
                    this.PaymentGateway.Equals(other.PaymentGateway)
                ) && 
                (
                    this.PaymentTerm == other.PaymentTerm ||
                    this.PaymentTerm != null &&
                    this.PaymentTerm.Equals(other.PaymentTerm)
                ) && 
                (
                    this.PurchaseOrderNumber == other.PurchaseOrderNumber ||
                    this.PurchaseOrderNumber != null &&
                    this.PurchaseOrderNumber.Equals(other.PurchaseOrderNumber)
                ) && 
                (
                    this.SalesRepName == other.SalesRepName ||
                    this.SalesRepName != null &&
                    this.SalesRepName.Equals(other.SalesRepName)
                ) && 
                (
                    this.SoldToId == other.SoldToId ||
                    this.SoldToId != null &&
                    this.SoldToId.Equals(other.SoldToId)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.TaxCompanyCode == other.TaxCompanyCode ||
                    this.TaxCompanyCode != null &&
                    this.TaxCompanyCode.Equals(other.TaxCompanyCode)
                ) && 
                (
                    this.TaxExemptCertificateID == other.TaxExemptCertificateID ||
                    this.TaxExemptCertificateID != null &&
                    this.TaxExemptCertificateID.Equals(other.TaxExemptCertificateID)
                ) && 
                (
                    this.TaxExemptCertificateType == other.TaxExemptCertificateType ||
                    this.TaxExemptCertificateType != null &&
                    this.TaxExemptCertificateType.Equals(other.TaxExemptCertificateType)
                ) && 
                (
                    this.TaxExemptDescription == other.TaxExemptDescription ||
                    this.TaxExemptDescription != null &&
                    this.TaxExemptDescription.Equals(other.TaxExemptDescription)
                ) && 
                (
                    this.TaxExemptEffectiveDate == other.TaxExemptEffectiveDate ||
                    this.TaxExemptEffectiveDate != null &&
                    this.TaxExemptEffectiveDate.Equals(other.TaxExemptEffectiveDate)
                ) && 
                (
                    this.TaxExemptExpirationDate == other.TaxExemptExpirationDate ||
                    this.TaxExemptExpirationDate != null &&
                    this.TaxExemptExpirationDate.Equals(other.TaxExemptExpirationDate)
                ) && 
                (
                    this.TaxExemptIssuingJurisdiction == other.TaxExemptIssuingJurisdiction ||
                    this.TaxExemptIssuingJurisdiction != null &&
                    this.TaxExemptIssuingJurisdiction.Equals(other.TaxExemptIssuingJurisdiction)
                ) && 
                (
                    this.TaxExemptStatus == other.TaxExemptStatus ||
                    this.TaxExemptStatus != null &&
                    this.TaxExemptStatus.Equals(other.TaxExemptStatus)
                ) && 
                (
                    this.TotalInvoiceBalance == other.TotalInvoiceBalance ||
                    this.TotalInvoiceBalance != null &&
                    this.TotalInvoiceBalance.Equals(other.TotalInvoiceBalance)
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
                    this.VATId == other.VATId ||
                    this.VATId != null &&
                    this.VATId.Equals(other.VATId)
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
                if (this.AccountNumber != null)
                    hash = hash * 59 + this.AccountNumber.GetHashCode();
                if (this.AdditionalEmailAddresses != null)
                    hash = hash * 59 + this.AdditionalEmailAddresses.GetHashCode();
                if (this.AllowInvoiceEdit != null)
                    hash = hash * 59 + this.AllowInvoiceEdit.GetHashCode();
                if (this.AutoPay != null)
                    hash = hash * 59 + this.AutoPay.GetHashCode();
                if (this.Balance != null)
                    hash = hash * 59 + this.Balance.GetHashCode();
                if (this.Batch != null)
                    hash = hash * 59 + this.Batch.GetHashCode();
                if (this.BcdSettingOption != null)
                    hash = hash * 59 + this.BcdSettingOption.GetHashCode();
                if (this.BillCycleDay != null)
                    hash = hash * 59 + this.BillCycleDay.GetHashCode();
                if (this.BillToId != null)
                    hash = hash * 59 + this.BillToId.GetHashCode();
                if (this.CommunicationProfileId != null)
                    hash = hash * 59 + this.CommunicationProfileId.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.CreditBalance != null)
                    hash = hash * 59 + this.CreditBalance.GetHashCode();
                if (this.CrmId != null)
                    hash = hash * 59 + this.CrmId.GetHashCode();
                if (this.Currency != null)
                    hash = hash * 59 + this.Currency.GetHashCode();
                if (this.CustomerServiceRepName != null)
                    hash = hash * 59 + this.CustomerServiceRepName.GetHashCode();
                if (this.DefaultPaymentMethodId != null)
                    hash = hash * 59 + this.DefaultPaymentMethodId.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.InvoiceDeliveryPrefsEmail != null)
                    hash = hash * 59 + this.InvoiceDeliveryPrefsEmail.GetHashCode();
                if (this.InvoiceDeliveryPrefsPrint != null)
                    hash = hash * 59 + this.InvoiceDeliveryPrefsPrint.GetHashCode();
                if (this.InvoiceTemplateId != null)
                    hash = hash * 59 + this.InvoiceTemplateId.GetHashCode();
                if (this.LastInvoiceDate != null)
                    hash = hash * 59 + this.LastInvoiceDate.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Notes != null)
                    hash = hash * 59 + this.Notes.GetHashCode();
                if (this.ParentId != null)
                    hash = hash * 59 + this.ParentId.GetHashCode();
                if (this.PaymentGateway != null)
                    hash = hash * 59 + this.PaymentGateway.GetHashCode();
                if (this.PaymentTerm != null)
                    hash = hash * 59 + this.PaymentTerm.GetHashCode();
                if (this.PurchaseOrderNumber != null)
                    hash = hash * 59 + this.PurchaseOrderNumber.GetHashCode();
                if (this.SalesRepName != null)
                    hash = hash * 59 + this.SalesRepName.GetHashCode();
                if (this.SoldToId != null)
                    hash = hash * 59 + this.SoldToId.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.TaxCompanyCode != null)
                    hash = hash * 59 + this.TaxCompanyCode.GetHashCode();
                if (this.TaxExemptCertificateID != null)
                    hash = hash * 59 + this.TaxExemptCertificateID.GetHashCode();
                if (this.TaxExemptCertificateType != null)
                    hash = hash * 59 + this.TaxExemptCertificateType.GetHashCode();
                if (this.TaxExemptDescription != null)
                    hash = hash * 59 + this.TaxExemptDescription.GetHashCode();
                if (this.TaxExemptEffectiveDate != null)
                    hash = hash * 59 + this.TaxExemptEffectiveDate.GetHashCode();
                if (this.TaxExemptExpirationDate != null)
                    hash = hash * 59 + this.TaxExemptExpirationDate.GetHashCode();
                if (this.TaxExemptIssuingJurisdiction != null)
                    hash = hash * 59 + this.TaxExemptIssuingJurisdiction.GetHashCode();
                if (this.TaxExemptStatus != null)
                    hash = hash * 59 + this.TaxExemptStatus.GetHashCode();
                if (this.TotalInvoiceBalance != null)
                    hash = hash * 59 + this.TotalInvoiceBalance.GetHashCode();
                if (this.UpdatedById != null)
                    hash = hash * 59 + this.UpdatedById.GetHashCode();
                if (this.UpdatedDate != null)
                    hash = hash * 59 + this.UpdatedDate.GetHashCode();
                if (this.VATId != null)
                    hash = hash * 59 + this.VATId.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
