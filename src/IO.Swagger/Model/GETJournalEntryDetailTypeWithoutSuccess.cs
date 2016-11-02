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
    /// GETJournalEntryDetailTypeWithoutSuccess
    /// </summary>
    [DataContract]
    public partial class GETJournalEntryDetailTypeWithoutSuccess :  IEquatable<GETJournalEntryDetailTypeWithoutSuccess>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GETJournalEntryDetailTypeWithoutSuccess" /> class.
        /// </summary>
        /// <param name="AccountingPeriodName">Name of the accounting period that the journal entry belongs to. .</param>
        /// <param name="AggregateCurrency">Returns true if the journal entry is aggregating currencies. That is, if the journal entry was created when the [Aggregate transactions with different currencies during a JournalRun](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) setting was configured to \&quot;Yes\&quot;. Otherwise, returns &#x60;false&#x60;. .</param>
        /// <param name="Currency">Currency used. .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="HomeCurrency">Home currency used. .</param>
        /// <param name="JournalEntryDate">Date of the journal entry. .</param>
        /// <param name="JournalEntryItems">Key name that represents the list of journal entry items. .</param>
        /// <param name="Notes">Additional information about this record. Character limit: 2,000 .</param>
        /// <param name="Number">Journal entry number in the format JE-00000001. .</param>
        /// <param name="Segments">List of segments that apply to the summary journal entry. .</param>
        /// <param name="Status">Status of journal entry. An enum with the values&#x60;Created&#x60; or &#x60;Cancelled&#x60;. .</param>
        /// <param name="TimePeriodEnd">End date of time period included in the journal entry. .</param>
        /// <param name="TimePeriodStart">Start date of time period included in the journal entry. .</param>
        /// <param name="TransactionType">Transaction type of the transactions included in the summary journal entry. .</param>
        /// <param name="TransferDateTime">Date and time that transferredToAccounting was changed to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;. .</param>
        /// <param name="TransferredBy">User ID of the person who changed transferredToAccounting to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;. .</param>
        /// <param name="TransferredToAccounting">Status shows whether the journal entry has been transferred to an accounting system. The possible values are &#x60;No&#x60;, &#x60;Processing&#x60;, &#x60;Yes&#x60;, &#x60;Error&#x60;, &#x60;Ignore&#x60;. .</param>
        public GETJournalEntryDetailTypeWithoutSuccess(string AccountingPeriodName = null, bool? AggregateCurrency = null, string Currency = null, string CustomFieldC = null, string HomeCurrency = null, DateTime? JournalEntryDate = null, List<GETJournalEntryItemType> JournalEntryItems = null, string Notes = null, string Number = null, List<GETJournalEntrySegmentType> Segments = null, string Status = null, DateTime? TimePeriodEnd = null, DateTime? TimePeriodStart = null, string TransactionType = null, DateTime? TransferDateTime = null, string TransferredBy = null, string TransferredToAccounting = null)
        {
            this.AccountingPeriodName = AccountingPeriodName;
            this.AggregateCurrency = AggregateCurrency;
            this.Currency = Currency;
            this.CustomFieldC = CustomFieldC;
            this.HomeCurrency = HomeCurrency;
            this.JournalEntryDate = JournalEntryDate;
            this.JournalEntryItems = JournalEntryItems;
            this.Notes = Notes;
            this.Number = Number;
            this.Segments = Segments;
            this.Status = Status;
            this.TimePeriodEnd = TimePeriodEnd;
            this.TimePeriodStart = TimePeriodStart;
            this.TransactionType = TransactionType;
            this.TransferDateTime = TransferDateTime;
            this.TransferredBy = TransferredBy;
            this.TransferredToAccounting = TransferredToAccounting;
        }
        
        /// <summary>
        /// Name of the accounting period that the journal entry belongs to. 
        /// </summary>
        /// <value>Name of the accounting period that the journal entry belongs to. </value>
        [DataMember(Name="accountingPeriodName", EmitDefaultValue=false)]
        public string AccountingPeriodName { get; set; }
        /// <summary>
        /// Returns true if the journal entry is aggregating currencies. That is, if the journal entry was created when the [Aggregate transactions with different currencies during a JournalRun](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) setting was configured to \&quot;Yes\&quot;. Otherwise, returns &#x60;false&#x60;. 
        /// </summary>
        /// <value>Returns true if the journal entry is aggregating currencies. That is, if the journal entry was created when the [Aggregate transactions with different currencies during a JournalRun](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) setting was configured to \&quot;Yes\&quot;. Otherwise, returns &#x60;false&#x60;. </value>
        [DataMember(Name="aggregateCurrency", EmitDefaultValue=false)]
        public bool? AggregateCurrency { get; set; }
        /// <summary>
        /// Currency used. 
        /// </summary>
        /// <value>Currency used. </value>
        [DataMember(Name="currency", EmitDefaultValue=false)]
        public string Currency { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// Home currency used. 
        /// </summary>
        /// <value>Home currency used. </value>
        [DataMember(Name="homeCurrency", EmitDefaultValue=false)]
        public string HomeCurrency { get; set; }
        /// <summary>
        /// Date of the journal entry. 
        /// </summary>
        /// <value>Date of the journal entry. </value>
        [DataMember(Name="journalEntryDate", EmitDefaultValue=false)]
        public DateTime? JournalEntryDate { get; set; }
        /// <summary>
        /// Key name that represents the list of journal entry items. 
        /// </summary>
        /// <value>Key name that represents the list of journal entry items. </value>
        [DataMember(Name="journalEntryItems", EmitDefaultValue=false)]
        public List<GETJournalEntryItemType> JournalEntryItems { get; set; }
        /// <summary>
        /// Additional information about this record. Character limit: 2,000 
        /// </summary>
        /// <value>Additional information about this record. Character limit: 2,000 </value>
        [DataMember(Name="notes", EmitDefaultValue=false)]
        public string Notes { get; set; }
        /// <summary>
        /// Journal entry number in the format JE-00000001. 
        /// </summary>
        /// <value>Journal entry number in the format JE-00000001. </value>
        [DataMember(Name="number", EmitDefaultValue=false)]
        public string Number { get; set; }
        /// <summary>
        /// List of segments that apply to the summary journal entry. 
        /// </summary>
        /// <value>List of segments that apply to the summary journal entry. </value>
        [DataMember(Name="segments", EmitDefaultValue=false)]
        public List<GETJournalEntrySegmentType> Segments { get; set; }
        /// <summary>
        /// Status of journal entry. An enum with the values&#x60;Created&#x60; or &#x60;Cancelled&#x60;. 
        /// </summary>
        /// <value>Status of journal entry. An enum with the values&#x60;Created&#x60; or &#x60;Cancelled&#x60;. </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// End date of time period included in the journal entry. 
        /// </summary>
        /// <value>End date of time period included in the journal entry. </value>
        [DataMember(Name="timePeriodEnd", EmitDefaultValue=false)]
        public DateTime? TimePeriodEnd { get; set; }
        /// <summary>
        /// Start date of time period included in the journal entry. 
        /// </summary>
        /// <value>Start date of time period included in the journal entry. </value>
        [DataMember(Name="timePeriodStart", EmitDefaultValue=false)]
        public DateTime? TimePeriodStart { get; set; }
        /// <summary>
        /// Transaction type of the transactions included in the summary journal entry. 
        /// </summary>
        /// <value>Transaction type of the transactions included in the summary journal entry. </value>
        [DataMember(Name="transactionType", EmitDefaultValue=false)]
        public string TransactionType { get; set; }
        /// <summary>
        /// Date and time that transferredToAccounting was changed to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;. 
        /// </summary>
        /// <value>Date and time that transferredToAccounting was changed to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;. </value>
        [DataMember(Name="transferDateTime", EmitDefaultValue=false)]
        public DateTime? TransferDateTime { get; set; }
        /// <summary>
        /// User ID of the person who changed transferredToAccounting to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;. 
        /// </summary>
        /// <value>User ID of the person who changed transferredToAccounting to &#x60;Yes&#x60;. This field is returned only when transferredToAccounting is &#x60;Yes&#x60;. Otherwise, this field is &#x60;null&#x60;. </value>
        [DataMember(Name="transferredBy", EmitDefaultValue=false)]
        public string TransferredBy { get; set; }
        /// <summary>
        /// Status shows whether the journal entry has been transferred to an accounting system. The possible values are &#x60;No&#x60;, &#x60;Processing&#x60;, &#x60;Yes&#x60;, &#x60;Error&#x60;, &#x60;Ignore&#x60;. 
        /// </summary>
        /// <value>Status shows whether the journal entry has been transferred to an accounting system. The possible values are &#x60;No&#x60;, &#x60;Processing&#x60;, &#x60;Yes&#x60;, &#x60;Error&#x60;, &#x60;Ignore&#x60;. </value>
        [DataMember(Name="transferredToAccounting", EmitDefaultValue=false)]
        public string TransferredToAccounting { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GETJournalEntryDetailTypeWithoutSuccess {\n");
            sb.Append("  AccountingPeriodName: ").Append(AccountingPeriodName).Append("\n");
            sb.Append("  AggregateCurrency: ").Append(AggregateCurrency).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  HomeCurrency: ").Append(HomeCurrency).Append("\n");
            sb.Append("  JournalEntryDate: ").Append(JournalEntryDate).Append("\n");
            sb.Append("  JournalEntryItems: ").Append(JournalEntryItems).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  Segments: ").Append(Segments).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  TimePeriodEnd: ").Append(TimePeriodEnd).Append("\n");
            sb.Append("  TimePeriodStart: ").Append(TimePeriodStart).Append("\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  TransferDateTime: ").Append(TransferDateTime).Append("\n");
            sb.Append("  TransferredBy: ").Append(TransferredBy).Append("\n");
            sb.Append("  TransferredToAccounting: ").Append(TransferredToAccounting).Append("\n");
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
            return this.Equals(obj as GETJournalEntryDetailTypeWithoutSuccess);
        }

        /// <summary>
        /// Returns true if GETJournalEntryDetailTypeWithoutSuccess instances are equal
        /// </summary>
        /// <param name="other">Instance of GETJournalEntryDetailTypeWithoutSuccess to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETJournalEntryDetailTypeWithoutSuccess other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountingPeriodName == other.AccountingPeriodName ||
                    this.AccountingPeriodName != null &&
                    this.AccountingPeriodName.Equals(other.AccountingPeriodName)
                ) && 
                (
                    this.AggregateCurrency == other.AggregateCurrency ||
                    this.AggregateCurrency != null &&
                    this.AggregateCurrency.Equals(other.AggregateCurrency)
                ) && 
                (
                    this.Currency == other.Currency ||
                    this.Currency != null &&
                    this.Currency.Equals(other.Currency)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.HomeCurrency == other.HomeCurrency ||
                    this.HomeCurrency != null &&
                    this.HomeCurrency.Equals(other.HomeCurrency)
                ) && 
                (
                    this.JournalEntryDate == other.JournalEntryDate ||
                    this.JournalEntryDate != null &&
                    this.JournalEntryDate.Equals(other.JournalEntryDate)
                ) && 
                (
                    this.JournalEntryItems == other.JournalEntryItems ||
                    this.JournalEntryItems != null &&
                    this.JournalEntryItems.SequenceEqual(other.JournalEntryItems)
                ) && 
                (
                    this.Notes == other.Notes ||
                    this.Notes != null &&
                    this.Notes.Equals(other.Notes)
                ) && 
                (
                    this.Number == other.Number ||
                    this.Number != null &&
                    this.Number.Equals(other.Number)
                ) && 
                (
                    this.Segments == other.Segments ||
                    this.Segments != null &&
                    this.Segments.SequenceEqual(other.Segments)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.TimePeriodEnd == other.TimePeriodEnd ||
                    this.TimePeriodEnd != null &&
                    this.TimePeriodEnd.Equals(other.TimePeriodEnd)
                ) && 
                (
                    this.TimePeriodStart == other.TimePeriodStart ||
                    this.TimePeriodStart != null &&
                    this.TimePeriodStart.Equals(other.TimePeriodStart)
                ) && 
                (
                    this.TransactionType == other.TransactionType ||
                    this.TransactionType != null &&
                    this.TransactionType.Equals(other.TransactionType)
                ) && 
                (
                    this.TransferDateTime == other.TransferDateTime ||
                    this.TransferDateTime != null &&
                    this.TransferDateTime.Equals(other.TransferDateTime)
                ) && 
                (
                    this.TransferredBy == other.TransferredBy ||
                    this.TransferredBy != null &&
                    this.TransferredBy.Equals(other.TransferredBy)
                ) && 
                (
                    this.TransferredToAccounting == other.TransferredToAccounting ||
                    this.TransferredToAccounting != null &&
                    this.TransferredToAccounting.Equals(other.TransferredToAccounting)
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
                if (this.AccountingPeriodName != null)
                    hash = hash * 59 + this.AccountingPeriodName.GetHashCode();
                if (this.AggregateCurrency != null)
                    hash = hash * 59 + this.AggregateCurrency.GetHashCode();
                if (this.Currency != null)
                    hash = hash * 59 + this.Currency.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.HomeCurrency != null)
                    hash = hash * 59 + this.HomeCurrency.GetHashCode();
                if (this.JournalEntryDate != null)
                    hash = hash * 59 + this.JournalEntryDate.GetHashCode();
                if (this.JournalEntryItems != null)
                    hash = hash * 59 + this.JournalEntryItems.GetHashCode();
                if (this.Notes != null)
                    hash = hash * 59 + this.Notes.GetHashCode();
                if (this.Number != null)
                    hash = hash * 59 + this.Number.GetHashCode();
                if (this.Segments != null)
                    hash = hash * 59 + this.Segments.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.TimePeriodEnd != null)
                    hash = hash * 59 + this.TimePeriodEnd.GetHashCode();
                if (this.TimePeriodStart != null)
                    hash = hash * 59 + this.TimePeriodStart.GetHashCode();
                if (this.TransactionType != null)
                    hash = hash * 59 + this.TransactionType.GetHashCode();
                if (this.TransferDateTime != null)
                    hash = hash * 59 + this.TransferDateTime.GetHashCode();
                if (this.TransferredBy != null)
                    hash = hash * 59 + this.TransferredBy.GetHashCode();
                if (this.TransferredToAccounting != null)
                    hash = hash * 59 + this.TransferredToAccounting.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
