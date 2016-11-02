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
    /// GETAccountingPeriodType
    /// </summary>
    [DataContract]
    public partial class GETAccountingPeriodType :  IEquatable<GETAccountingPeriodType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GETAccountingPeriodType" /> class.
        /// </summary>
        /// <param name="CreatedBy">ID of the user who created the accounting period. .</param>
        /// <param name="CreatedOn">Date and time when the accounting period was created. .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="EndDate">The end date of the accounting period. .</param>
        /// <param name="FileIds">File IDs of the reports available for the accounting period. You can retrieve the reports by specifying the file ID in a [Get Files](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Get_Files) REST API call. .</param>
        /// <param name="FiscalYear">Fiscal year of the accounting period. .</param>
        /// <param name="FiscalQuarter">dummy.</param>
        /// <param name="Id">ID of the accounting period. .</param>
        /// <param name="Name">Name of the accounting period. .</param>
        /// <param name="Notes">Any optional notes about the accounting period. .</param>
        /// <param name="RunTrialBalanceEnd">Date and time that the trial balance was completed. If the trial balance status is &#x60;Pending&#x60;, &#x60;Processing&#x60;, or &#x60;Error&#x60;, this field is &#x60;null&#x60;. .</param>
        /// <param name="RunTrialBalanceErrorMessage">If trial balance status is Error, an error message is returned in this field. .</param>
        /// <param name="RunTrialBalanceStart">Date and time that the trial balance was run. If the trial balance status is Pending, this field is null. .</param>
        /// <param name="RunTrialBalanceStatus">Status of the trial balance for the accounting period. Possible values:  * &#x60;Pending&#x60; * &#x60;Processing&#x60; * &#x60;Completed&#x60; * &#x60;Error&#x60; .</param>
        /// <param name="StartDate">The start date of the accounting period. .</param>
        /// <param name="Status">Status of the accounting period. Possible values: * &#x60;Open&#x60; * &#x60;PendingClose&#x60; * &#x60;Closed&#x60; .</param>
        /// <param name="Success">Returns &#x60;true&#x60; if the request was processed successfully. .</param>
        /// <param name="UpdatedBy">ID of the user who last updated the accounting period. .</param>
        /// <param name="UpdatedOn">Date and time when the accounting period was last updated. .</param>
        public GETAccountingPeriodType(string CreatedBy = null, DateTime? CreatedOn = null, string CustomFieldC = null, DateTime? EndDate = null, List<GETAccountingPeriodFileIdsType> FileIds = null, string FiscalYear = null, long? FiscalQuarter = null, string Id = null, string Name = null, string Notes = null, DateTime? RunTrialBalanceEnd = null, string RunTrialBalanceErrorMessage = null, DateTime? RunTrialBalanceStart = null, string RunTrialBalanceStatus = null, DateTime? StartDate = null, string Status = null, bool? Success = null, string UpdatedBy = null, DateTime? UpdatedOn = null)
        {
            this.CreatedBy = CreatedBy;
            this.CreatedOn = CreatedOn;
            this.CustomFieldC = CustomFieldC;
            this.EndDate = EndDate;
            this.FileIds = FileIds;
            this.FiscalYear = FiscalYear;
            this.FiscalQuarter = FiscalQuarter;
            this.Id = Id;
            this.Name = Name;
            this.Notes = Notes;
            this.RunTrialBalanceEnd = RunTrialBalanceEnd;
            this.RunTrialBalanceErrorMessage = RunTrialBalanceErrorMessage;
            this.RunTrialBalanceStart = RunTrialBalanceStart;
            this.RunTrialBalanceStatus = RunTrialBalanceStatus;
            this.StartDate = StartDate;
            this.Status = Status;
            this.Success = Success;
            this.UpdatedBy = UpdatedBy;
            this.UpdatedOn = UpdatedOn;
        }
        
        /// <summary>
        /// ID of the user who created the accounting period. 
        /// </summary>
        /// <value>ID of the user who created the accounting period. </value>
        [DataMember(Name="createdBy", EmitDefaultValue=false)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Date and time when the accounting period was created. 
        /// </summary>
        /// <value>Date and time when the accounting period was created. </value>
        [DataMember(Name="createdOn", EmitDefaultValue=false)]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// The end date of the accounting period. 
        /// </summary>
        /// <value>The end date of the accounting period. </value>
        [DataMember(Name="endDate", EmitDefaultValue=false)]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// File IDs of the reports available for the accounting period. You can retrieve the reports by specifying the file ID in a [Get Files](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Get_Files) REST API call. 
        /// </summary>
        /// <value>File IDs of the reports available for the accounting period. You can retrieve the reports by specifying the file ID in a [Get Files](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Get_Files) REST API call. </value>
        [DataMember(Name="fileIds", EmitDefaultValue=false)]
        public List<GETAccountingPeriodFileIdsType> FileIds { get; set; }
        /// <summary>
        /// Fiscal year of the accounting period. 
        /// </summary>
        /// <value>Fiscal year of the accounting period. </value>
        [DataMember(Name="fiscalYear", EmitDefaultValue=false)]
        public string FiscalYear { get; set; }
        /// <summary>
        /// dummy
        /// </summary>
        /// <value>dummy</value>
        [DataMember(Name="fiscal_quarter", EmitDefaultValue=false)]
        public long? FiscalQuarter { get; set; }
        /// <summary>
        /// ID of the accounting period. 
        /// </summary>
        /// <value>ID of the accounting period. </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Name of the accounting period. 
        /// </summary>
        /// <value>Name of the accounting period. </value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        /// Any optional notes about the accounting period. 
        /// </summary>
        /// <value>Any optional notes about the accounting period. </value>
        [DataMember(Name="notes", EmitDefaultValue=false)]
        public string Notes { get; set; }
        /// <summary>
        /// Date and time that the trial balance was completed. If the trial balance status is &#x60;Pending&#x60;, &#x60;Processing&#x60;, or &#x60;Error&#x60;, this field is &#x60;null&#x60;. 
        /// </summary>
        /// <value>Date and time that the trial balance was completed. If the trial balance status is &#x60;Pending&#x60;, &#x60;Processing&#x60;, or &#x60;Error&#x60;, this field is &#x60;null&#x60;. </value>
        [DataMember(Name="runTrialBalanceEnd", EmitDefaultValue=false)]
        public DateTime? RunTrialBalanceEnd { get; set; }
        /// <summary>
        /// If trial balance status is Error, an error message is returned in this field. 
        /// </summary>
        /// <value>If trial balance status is Error, an error message is returned in this field. </value>
        [DataMember(Name="runTrialBalanceErrorMessage", EmitDefaultValue=false)]
        public string RunTrialBalanceErrorMessage { get; set; }
        /// <summary>
        /// Date and time that the trial balance was run. If the trial balance status is Pending, this field is null. 
        /// </summary>
        /// <value>Date and time that the trial balance was run. If the trial balance status is Pending, this field is null. </value>
        [DataMember(Name="runTrialBalanceStart", EmitDefaultValue=false)]
        public DateTime? RunTrialBalanceStart { get; set; }
        /// <summary>
        /// Status of the trial balance for the accounting period. Possible values:  * &#x60;Pending&#x60; * &#x60;Processing&#x60; * &#x60;Completed&#x60; * &#x60;Error&#x60; 
        /// </summary>
        /// <value>Status of the trial balance for the accounting period. Possible values:  * &#x60;Pending&#x60; * &#x60;Processing&#x60; * &#x60;Completed&#x60; * &#x60;Error&#x60; </value>
        [DataMember(Name="runTrialBalanceStatus", EmitDefaultValue=false)]
        public string RunTrialBalanceStatus { get; set; }
        /// <summary>
        /// The start date of the accounting period. 
        /// </summary>
        /// <value>The start date of the accounting period. </value>
        [DataMember(Name="startDate", EmitDefaultValue=false)]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Status of the accounting period. Possible values: * &#x60;Open&#x60; * &#x60;PendingClose&#x60; * &#x60;Closed&#x60; 
        /// </summary>
        /// <value>Status of the accounting period. Possible values: * &#x60;Open&#x60; * &#x60;PendingClose&#x60; * &#x60;Closed&#x60; </value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        /// Returns &#x60;true&#x60; if the request was processed successfully. 
        /// </summary>
        /// <value>Returns &#x60;true&#x60; if the request was processed successfully. </value>
        [DataMember(Name="success", EmitDefaultValue=false)]
        public bool? Success { get; set; }
        /// <summary>
        /// ID of the user who last updated the accounting period. 
        /// </summary>
        /// <value>ID of the user who last updated the accounting period. </value>
        [DataMember(Name="updatedBy", EmitDefaultValue=false)]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Date and time when the accounting period was last updated. 
        /// </summary>
        /// <value>Date and time when the accounting period was last updated. </value>
        [DataMember(Name="updatedOn", EmitDefaultValue=false)]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GETAccountingPeriodType {\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedOn: ").Append(CreatedOn).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  FileIds: ").Append(FileIds).Append("\n");
            sb.Append("  FiscalYear: ").Append(FiscalYear).Append("\n");
            sb.Append("  FiscalQuarter: ").Append(FiscalQuarter).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  RunTrialBalanceEnd: ").Append(RunTrialBalanceEnd).Append("\n");
            sb.Append("  RunTrialBalanceErrorMessage: ").Append(RunTrialBalanceErrorMessage).Append("\n");
            sb.Append("  RunTrialBalanceStart: ").Append(RunTrialBalanceStart).Append("\n");
            sb.Append("  RunTrialBalanceStatus: ").Append(RunTrialBalanceStatus).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Success: ").Append(Success).Append("\n");
            sb.Append("  UpdatedBy: ").Append(UpdatedBy).Append("\n");
            sb.Append("  UpdatedOn: ").Append(UpdatedOn).Append("\n");
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
            return this.Equals(obj as GETAccountingPeriodType);
        }

        /// <summary>
        /// Returns true if GETAccountingPeriodType instances are equal
        /// </summary>
        /// <param name="other">Instance of GETAccountingPeriodType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETAccountingPeriodType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.CreatedBy == other.CreatedBy ||
                    this.CreatedBy != null &&
                    this.CreatedBy.Equals(other.CreatedBy)
                ) && 
                (
                    this.CreatedOn == other.CreatedOn ||
                    this.CreatedOn != null &&
                    this.CreatedOn.Equals(other.CreatedOn)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.EndDate == other.EndDate ||
                    this.EndDate != null &&
                    this.EndDate.Equals(other.EndDate)
                ) && 
                (
                    this.FileIds == other.FileIds ||
                    this.FileIds != null &&
                    this.FileIds.SequenceEqual(other.FileIds)
                ) && 
                (
                    this.FiscalYear == other.FiscalYear ||
                    this.FiscalYear != null &&
                    this.FiscalYear.Equals(other.FiscalYear)
                ) && 
                (
                    this.FiscalQuarter == other.FiscalQuarter ||
                    this.FiscalQuarter != null &&
                    this.FiscalQuarter.Equals(other.FiscalQuarter)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
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
                    this.RunTrialBalanceEnd == other.RunTrialBalanceEnd ||
                    this.RunTrialBalanceEnd != null &&
                    this.RunTrialBalanceEnd.Equals(other.RunTrialBalanceEnd)
                ) && 
                (
                    this.RunTrialBalanceErrorMessage == other.RunTrialBalanceErrorMessage ||
                    this.RunTrialBalanceErrorMessage != null &&
                    this.RunTrialBalanceErrorMessage.Equals(other.RunTrialBalanceErrorMessage)
                ) && 
                (
                    this.RunTrialBalanceStart == other.RunTrialBalanceStart ||
                    this.RunTrialBalanceStart != null &&
                    this.RunTrialBalanceStart.Equals(other.RunTrialBalanceStart)
                ) && 
                (
                    this.RunTrialBalanceStatus == other.RunTrialBalanceStatus ||
                    this.RunTrialBalanceStatus != null &&
                    this.RunTrialBalanceStatus.Equals(other.RunTrialBalanceStatus)
                ) && 
                (
                    this.StartDate == other.StartDate ||
                    this.StartDate != null &&
                    this.StartDate.Equals(other.StartDate)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.Success == other.Success ||
                    this.Success != null &&
                    this.Success.Equals(other.Success)
                ) && 
                (
                    this.UpdatedBy == other.UpdatedBy ||
                    this.UpdatedBy != null &&
                    this.UpdatedBy.Equals(other.UpdatedBy)
                ) && 
                (
                    this.UpdatedOn == other.UpdatedOn ||
                    this.UpdatedOn != null &&
                    this.UpdatedOn.Equals(other.UpdatedOn)
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
                if (this.CreatedBy != null)
                    hash = hash * 59 + this.CreatedBy.GetHashCode();
                if (this.CreatedOn != null)
                    hash = hash * 59 + this.CreatedOn.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.EndDate != null)
                    hash = hash * 59 + this.EndDate.GetHashCode();
                if (this.FileIds != null)
                    hash = hash * 59 + this.FileIds.GetHashCode();
                if (this.FiscalYear != null)
                    hash = hash * 59 + this.FiscalYear.GetHashCode();
                if (this.FiscalQuarter != null)
                    hash = hash * 59 + this.FiscalQuarter.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.Notes != null)
                    hash = hash * 59 + this.Notes.GetHashCode();
                if (this.RunTrialBalanceEnd != null)
                    hash = hash * 59 + this.RunTrialBalanceEnd.GetHashCode();
                if (this.RunTrialBalanceErrorMessage != null)
                    hash = hash * 59 + this.RunTrialBalanceErrorMessage.GetHashCode();
                if (this.RunTrialBalanceStart != null)
                    hash = hash * 59 + this.RunTrialBalanceStart.GetHashCode();
                if (this.RunTrialBalanceStatus != null)
                    hash = hash * 59 + this.RunTrialBalanceStatus.GetHashCode();
                if (this.StartDate != null)
                    hash = hash * 59 + this.StartDate.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.Success != null)
                    hash = hash * 59 + this.Success.GetHashCode();
                if (this.UpdatedBy != null)
                    hash = hash * 59 + this.UpdatedBy.GetHashCode();
                if (this.UpdatedOn != null)
                    hash = hash * 59 + this.UpdatedOn.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
