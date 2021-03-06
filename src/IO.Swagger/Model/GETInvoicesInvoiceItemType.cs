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
    /// GETInvoicesInvoiceItemType
    /// </summary>
    [DataContract]
    public partial class GETInvoicesInvoiceItemType :  IEquatable<GETInvoicesInvoiceItemType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GETInvoicesInvoiceItemType" /> class.
        /// </summary>
        /// <param name="ChargeAmount">The amount of the charge. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. .</param>
        /// <param name="ChargeDescription">Description of the charge. .</param>
        /// <param name="ChargeId">ID of the charge. .</param>
        /// <param name="ChargeName">Name of the charge. .</param>
        /// <param name="CustomFieldC">Any custom fields defined for this object. .</param>
        /// <param name="Id">Item ID. .</param>
        /// <param name="ProductName">Name of the product associated with this item. .</param>
        /// <param name="Quantity">Quantity of this item, in the configured unit of measure for the charge. .</param>
        /// <param name="ServiceEndDate">End date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_. .</param>
        /// <param name="ServiceStartDate">Start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge. .</param>
        /// <param name="SubscriptionId">ID of the subscription for this item. .</param>
        /// <param name="SubscriptionName">Name of the subscription for this item. .</param>
        /// <param name="Success">Returns &#x60;true&#x60; if the request was processed successfully. .</param>
        /// <param name="TaxAmount">Tax applied to the charge. .</param>
        /// <param name="UnitOfMeasure">Unit used to measure consumption, as configured in the web-based UI at **Z-Billing &gt; Settings**. .</param>
        public GETInvoicesInvoiceItemType(string ChargeAmount = null, string ChargeDescription = null, string ChargeId = null, string ChargeName = null, string CustomFieldC = null, string Id = null, string ProductName = null, string Quantity = null, DateTime? ServiceEndDate = null, DateTime? ServiceStartDate = null, string SubscriptionId = null, string SubscriptionName = null, bool? Success = null, string TaxAmount = null, string UnitOfMeasure = null)
        {
            this.ChargeAmount = ChargeAmount;
            this.ChargeDescription = ChargeDescription;
            this.ChargeId = ChargeId;
            this.ChargeName = ChargeName;
            this.CustomFieldC = CustomFieldC;
            this.Id = Id;
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.ServiceEndDate = ServiceEndDate;
            this.ServiceStartDate = ServiceStartDate;
            this.SubscriptionId = SubscriptionId;
            this.SubscriptionName = SubscriptionName;
            this.Success = Success;
            this.TaxAmount = TaxAmount;
            this.UnitOfMeasure = UnitOfMeasure;
        }
        
        /// <summary>
        /// The amount of the charge. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. 
        /// </summary>
        /// <value>The amount of the charge. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. </value>
        [DataMember(Name="chargeAmount", EmitDefaultValue=false)]
        public string ChargeAmount { get; set; }
        /// <summary>
        /// Description of the charge. 
        /// </summary>
        /// <value>Description of the charge. </value>
        [DataMember(Name="chargeDescription", EmitDefaultValue=false)]
        public string ChargeDescription { get; set; }
        /// <summary>
        /// ID of the charge. 
        /// </summary>
        /// <value>ID of the charge. </value>
        [DataMember(Name="chargeId", EmitDefaultValue=false)]
        public string ChargeId { get; set; }
        /// <summary>
        /// Name of the charge. 
        /// </summary>
        /// <value>Name of the charge. </value>
        [DataMember(Name="chargeName", EmitDefaultValue=false)]
        public string ChargeName { get; set; }
        /// <summary>
        /// Any custom fields defined for this object. 
        /// </summary>
        /// <value>Any custom fields defined for this object. </value>
        [DataMember(Name="customField__c", EmitDefaultValue=false)]
        public string CustomFieldC { get; set; }
        /// <summary>
        /// Item ID. 
        /// </summary>
        /// <value>Item ID. </value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// Name of the product associated with this item. 
        /// </summary>
        /// <value>Name of the product associated with this item. </value>
        [DataMember(Name="productName", EmitDefaultValue=false)]
        public string ProductName { get; set; }
        /// <summary>
        /// Quantity of this item, in the configured unit of measure for the charge. 
        /// </summary>
        /// <value>Quantity of this item, in the configured unit of measure for the charge. </value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public string Quantity { get; set; }
        /// <summary>
        /// End date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_. 
        /// </summary>
        /// <value>End date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_. </value>
        [DataMember(Name="serviceEndDate", EmitDefaultValue=false)]
        public DateTime? ServiceEndDate { get; set; }
        /// <summary>
        /// Start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge. 
        /// </summary>
        /// <value>Start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge. </value>
        [DataMember(Name="serviceStartDate", EmitDefaultValue=false)]
        public DateTime? ServiceStartDate { get; set; }
        /// <summary>
        /// ID of the subscription for this item. 
        /// </summary>
        /// <value>ID of the subscription for this item. </value>
        [DataMember(Name="subscriptionId", EmitDefaultValue=false)]
        public string SubscriptionId { get; set; }
        /// <summary>
        /// Name of the subscription for this item. 
        /// </summary>
        /// <value>Name of the subscription for this item. </value>
        [DataMember(Name="subscriptionName", EmitDefaultValue=false)]
        public string SubscriptionName { get; set; }
        /// <summary>
        /// Returns &#x60;true&#x60; if the request was processed successfully. 
        /// </summary>
        /// <value>Returns &#x60;true&#x60; if the request was processed successfully. </value>
        [DataMember(Name="success", EmitDefaultValue=false)]
        public bool? Success { get; set; }
        /// <summary>
        /// Tax applied to the charge. 
        /// </summary>
        /// <value>Tax applied to the charge. </value>
        [DataMember(Name="taxAmount", EmitDefaultValue=false)]
        public string TaxAmount { get; set; }
        /// <summary>
        /// Unit used to measure consumption, as configured in the web-based UI at **Z-Billing &gt; Settings**. 
        /// </summary>
        /// <value>Unit used to measure consumption, as configured in the web-based UI at **Z-Billing &gt; Settings**. </value>
        [DataMember(Name="unitOfMeasure", EmitDefaultValue=false)]
        public string UnitOfMeasure { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GETInvoicesInvoiceItemType {\n");
            sb.Append("  ChargeAmount: ").Append(ChargeAmount).Append("\n");
            sb.Append("  ChargeDescription: ").Append(ChargeDescription).Append("\n");
            sb.Append("  ChargeId: ").Append(ChargeId).Append("\n");
            sb.Append("  ChargeName: ").Append(ChargeName).Append("\n");
            sb.Append("  CustomFieldC: ").Append(CustomFieldC).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProductName: ").Append(ProductName).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  ServiceEndDate: ").Append(ServiceEndDate).Append("\n");
            sb.Append("  ServiceStartDate: ").Append(ServiceStartDate).Append("\n");
            sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
            sb.Append("  SubscriptionName: ").Append(SubscriptionName).Append("\n");
            sb.Append("  Success: ").Append(Success).Append("\n");
            sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
            sb.Append("  UnitOfMeasure: ").Append(UnitOfMeasure).Append("\n");
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
            return this.Equals(obj as GETInvoicesInvoiceItemType);
        }

        /// <summary>
        /// Returns true if GETInvoicesInvoiceItemType instances are equal
        /// </summary>
        /// <param name="other">Instance of GETInvoicesInvoiceItemType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETInvoicesInvoiceItemType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.ChargeAmount == other.ChargeAmount ||
                    this.ChargeAmount != null &&
                    this.ChargeAmount.Equals(other.ChargeAmount)
                ) && 
                (
                    this.ChargeDescription == other.ChargeDescription ||
                    this.ChargeDescription != null &&
                    this.ChargeDescription.Equals(other.ChargeDescription)
                ) && 
                (
                    this.ChargeId == other.ChargeId ||
                    this.ChargeId != null &&
                    this.ChargeId.Equals(other.ChargeId)
                ) && 
                (
                    this.ChargeName == other.ChargeName ||
                    this.ChargeName != null &&
                    this.ChargeName.Equals(other.ChargeName)
                ) && 
                (
                    this.CustomFieldC == other.CustomFieldC ||
                    this.CustomFieldC != null &&
                    this.CustomFieldC.Equals(other.CustomFieldC)
                ) && 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.ProductName == other.ProductName ||
                    this.ProductName != null &&
                    this.ProductName.Equals(other.ProductName)
                ) && 
                (
                    this.Quantity == other.Quantity ||
                    this.Quantity != null &&
                    this.Quantity.Equals(other.Quantity)
                ) && 
                (
                    this.ServiceEndDate == other.ServiceEndDate ||
                    this.ServiceEndDate != null &&
                    this.ServiceEndDate.Equals(other.ServiceEndDate)
                ) && 
                (
                    this.ServiceStartDate == other.ServiceStartDate ||
                    this.ServiceStartDate != null &&
                    this.ServiceStartDate.Equals(other.ServiceStartDate)
                ) && 
                (
                    this.SubscriptionId == other.SubscriptionId ||
                    this.SubscriptionId != null &&
                    this.SubscriptionId.Equals(other.SubscriptionId)
                ) && 
                (
                    this.SubscriptionName == other.SubscriptionName ||
                    this.SubscriptionName != null &&
                    this.SubscriptionName.Equals(other.SubscriptionName)
                ) && 
                (
                    this.Success == other.Success ||
                    this.Success != null &&
                    this.Success.Equals(other.Success)
                ) && 
                (
                    this.TaxAmount == other.TaxAmount ||
                    this.TaxAmount != null &&
                    this.TaxAmount.Equals(other.TaxAmount)
                ) && 
                (
                    this.UnitOfMeasure == other.UnitOfMeasure ||
                    this.UnitOfMeasure != null &&
                    this.UnitOfMeasure.Equals(other.UnitOfMeasure)
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
                if (this.ChargeAmount != null)
                    hash = hash * 59 + this.ChargeAmount.GetHashCode();
                if (this.ChargeDescription != null)
                    hash = hash * 59 + this.ChargeDescription.GetHashCode();
                if (this.ChargeId != null)
                    hash = hash * 59 + this.ChargeId.GetHashCode();
                if (this.ChargeName != null)
                    hash = hash * 59 + this.ChargeName.GetHashCode();
                if (this.CustomFieldC != null)
                    hash = hash * 59 + this.CustomFieldC.GetHashCode();
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.ProductName != null)
                    hash = hash * 59 + this.ProductName.GetHashCode();
                if (this.Quantity != null)
                    hash = hash * 59 + this.Quantity.GetHashCode();
                if (this.ServiceEndDate != null)
                    hash = hash * 59 + this.ServiceEndDate.GetHashCode();
                if (this.ServiceStartDate != null)
                    hash = hash * 59 + this.ServiceStartDate.GetHashCode();
                if (this.SubscriptionId != null)
                    hash = hash * 59 + this.SubscriptionId.GetHashCode();
                if (this.SubscriptionName != null)
                    hash = hash * 59 + this.SubscriptionName.GetHashCode();
                if (this.Success != null)
                    hash = hash * 59 + this.Success.GetHashCode();
                if (this.TaxAmount != null)
                    hash = hash * 59 + this.TaxAmount.GetHashCode();
                if (this.UnitOfMeasure != null)
                    hash = hash * 59 + this.UnitOfMeasure.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
