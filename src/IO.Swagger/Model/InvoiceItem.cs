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
    /// InvoiceItem
    /// </summary>
    [DataContract]
    public partial class InvoiceItem :  IEquatable<InvoiceItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItem" /> class.
        /// </summary>
        /// <param name="AccountingCode"> The accounting code for the item&#39;s charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;RatePlanCharge.AccountingCode&#x60; .</param>
        /// <param name="AppliedToInvoiceItemId"> Associates a discount invoice item to a specific invoice item. **Character limit**: 32 **Values**: inherited from the ID of the charge that a discount applies to .</param>
        /// <param name="ChargeAmount"> The amount being charged for the invoice item. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. **Character limit**: **Values**: automatically calculated from multiple fields in multiple objects .</param>
        /// <param name="ChargeDate"> The date when the Invoice Item is created . **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="ChargeDescription"> A description of the invoice item&#39;s charge. **Character limit**: 500 **Values**: inherited from &#x60;RatePlanCharge.Description&#x60; .</param>
        /// <param name="ChargeId"> The ID of the rate plan charge that is associated with this invoice item upon object creation. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60; .</param>
        /// <param name="ChargeName"> The name of the invoice item&#39;s charge. **Character limi**t: 50 **Values: **inherited from &#x60;RatePlanCharge.Name&#x60; .</param>
        /// <param name="ChargeNumber"> The unique identifier of the invoice item&#39;s charge. **Character limit:** 50 **Values:** inherited from &#x60;RatePlanCharge.ChargeNumber&#x60; .</param>
        /// <param name="ChargeType"> Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; .</param>
        /// <param name="CreatedById"> The user ID of the person who created the invoice item. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date the invoice item was created. **Character limit:** 29 **Values**: automatically generated .</param>
        /// <param name="InvoiceId"> The ID of the invoice that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Invoice.Id&#x60; .</param>
        /// <param name="ProcessingType"> Identifies the kind of charge where 0 is a charge, 1 is a discount, 2 is a prepayment, and 3 is a tax. The returned value is text not decimal on data sources. **Character limit**: **Values: **  - 0: charge - 1: discount - 2: prepayment - 3: tax .</param>
        /// <param name="ProductDescription"> A description of the product associated with this invoice item. **Character limit**: 500 **Values**: inherited from &#x60;Product.Description&#x60; .</param>
        /// <param name="ProductId"> The ID of the product associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Product.Id&#x60; .</param>
        /// <param name="ProductName"> The name of the product associated with this invoice item. **Character limit**: 255 **Values: **inherited from &#x60;Product.Name&#x60; .</param>
        /// <param name="ProductRatePlanChargeId"> The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;ProductRatePlanCharge.Id&#x60; You cannot &#x60;query()&#x60; for this field. Only the s&#x60;ubscribe()&#x60; preview and the &#x60;amend()&#x60; preview calls will return the value of this field in the response..</param>
        /// <param name="Quantity"> The number of units for this invoice item. **Values**: inherited from &#x60;RatePlanCharge.Quantity&#x60; .</param>
        /// <param name="RatePlanChargeId"> The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60; .</param>
        /// <param name="RevRecCode"> Associates this invoice item with a specific revenue recognition code. **Character limit**: 32 **Values**: inherited from &#x60;ProductRatePlanCharge.RevRecCode&#x60; .</param>
        /// <param name="RevRecStartDate"> The date when revenue recognition is triggered. **Character limit**: 29 **Values**: generated from &#x60;InvoiceItem.RevRecTriggerCondition&#x60; .</param>
        /// <param name="RevRecTriggerCondition"> Specifies when revenue recognition begins based on a triggering event. **Character limit**: **Values**: inherited from &#x60;[ProductRatePlanCharge](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/ProductRatePlanCharge).RevRecTriggerCondition&#x60; .</param>
        /// <param name="SKU"> The unique SKU for the product associated with this invoice item. **Character limit**: 255 **Values**: inherited from &#x60;Product.SKU&#x60; .</param>
        /// <param name="ServiceEndDate"> The end date of the service period associated with this invoice item. Service ends one second before the date in this value. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="ServiceStartDate"> The start date of the service period associated with this invoice item. If the associated charge is a one-time fee, then this date is the date of that charge. **Character limit:** 29 **Values**: automatically generated .</param>
        /// <param name="SubscriptionId"> The ID of the subscription associated with the invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Subscription.Id&#x60; .</param>
        /// <param name="SubscriptionNumber"> The number of the subscription associated with the invoice item. **Character limit**: **Values**: .</param>
        /// <param name="TaxAmount"> The amount of tax applied to the invoice item&#39;s charge. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object .</param>
        /// <param name="TaxCode"> Specifies the tax code for taxation rules. **Character limit**: 6 **Values**: inherited from &#x60;ProductRatePlanCharge.TaxCode&#x60; .</param>
        /// <param name="TaxExemptAmount"> The amount of the invoice item&#39;s charge that&#39;s tax exempt. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object .</param>
        /// <param name="TaxMode"> The tax mode of the invoice item. **Character limit**: 12 **Values**: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60; .</param>
        /// <param name="UOM"> Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings** **Character limit**: **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60; .</param>
        /// <param name="UnitPrice"> The per-unit price of the invoice item. **Character limit**: **Values**: calculated from multiple fields in ProductRatePlanCharge and ProductRatePlanChargeTier objets .</param>
        /// <param name="UpdatedById"> The ID of the user who last updated the invoice item. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="UpdatedDate"> The date when the invoice item was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        public InvoiceItem(string AccountingCode = null, string AppliedToInvoiceItemId = null, double? ChargeAmount = null, DateTime? ChargeDate = null, string ChargeDescription = null, string ChargeId = null, string ChargeName = null, string ChargeNumber = null, string ChargeType = null, string CreatedById = null, DateTime? CreatedDate = null, string InvoiceId = null, double? ProcessingType = null, string ProductDescription = null, string ProductId = null, string ProductName = null, string ProductRatePlanChargeId = null, double? Quantity = null, string RatePlanChargeId = null, string RevRecCode = null, DateTime? RevRecStartDate = null, string RevRecTriggerCondition = null, string SKU = null, DateTime? ServiceEndDate = null, DateTime? ServiceStartDate = null, string SubscriptionId = null, string SubscriptionNumber = null, double? TaxAmount = null, string TaxCode = null, double? TaxExemptAmount = null, string TaxMode = null, string UOM = null, double? UnitPrice = null, string UpdatedById = null, DateTime? UpdatedDate = null)
        {
            this.AccountingCode = AccountingCode;
            this.AppliedToInvoiceItemId = AppliedToInvoiceItemId;
            this.ChargeAmount = ChargeAmount;
            this.ChargeDate = ChargeDate;
            this.ChargeDescription = ChargeDescription;
            this.ChargeId = ChargeId;
            this.ChargeName = ChargeName;
            this.ChargeNumber = ChargeNumber;
            this.ChargeType = ChargeType;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.InvoiceId = InvoiceId;
            this.ProcessingType = ProcessingType;
            this.ProductDescription = ProductDescription;
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.ProductRatePlanChargeId = ProductRatePlanChargeId;
            this.Quantity = Quantity;
            this.RatePlanChargeId = RatePlanChargeId;
            this.RevRecCode = RevRecCode;
            this.RevRecStartDate = RevRecStartDate;
            this.RevRecTriggerCondition = RevRecTriggerCondition;
            this.SKU = SKU;
            this.ServiceEndDate = ServiceEndDate;
            this.ServiceStartDate = ServiceStartDate;
            this.SubscriptionId = SubscriptionId;
            this.SubscriptionNumber = SubscriptionNumber;
            this.TaxAmount = TaxAmount;
            this.TaxCode = TaxCode;
            this.TaxExemptAmount = TaxExemptAmount;
            this.TaxMode = TaxMode;
            this.UOM = UOM;
            this.UnitPrice = UnitPrice;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
        }
        
        /// <summary>
        ///  The accounting code for the item&#39;s charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;RatePlanCharge.AccountingCode&#x60; 
        /// </summary>
        /// <value> The accounting code for the item&#39;s charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;RatePlanCharge.AccountingCode&#x60; </value>
        [DataMember(Name="AccountingCode", EmitDefaultValue=false)]
        public string AccountingCode { get; set; }
        /// <summary>
        ///  Associates a discount invoice item to a specific invoice item. **Character limit**: 32 **Values**: inherited from the ID of the charge that a discount applies to 
        /// </summary>
        /// <value> Associates a discount invoice item to a specific invoice item. **Character limit**: 32 **Values**: inherited from the ID of the charge that a discount applies to </value>
        [DataMember(Name="AppliedToInvoiceItemId", EmitDefaultValue=false)]
        public string AppliedToInvoiceItemId { get; set; }
        /// <summary>
        ///  The amount being charged for the invoice item. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. **Character limit**: **Values**: automatically calculated from multiple fields in multiple objects 
        /// </summary>
        /// <value> The amount being charged for the invoice item. This amount doesn&#39;t include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. **Character limit**: **Values**: automatically calculated from multiple fields in multiple objects </value>
        [DataMember(Name="ChargeAmount", EmitDefaultValue=false)]
        public double? ChargeAmount { get; set; }
        /// <summary>
        ///  The date when the Invoice Item is created . **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the Invoice Item is created . **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="ChargeDate", EmitDefaultValue=false)]
        public DateTime? ChargeDate { get; set; }
        /// <summary>
        ///  A description of the invoice item&#39;s charge. **Character limit**: 500 **Values**: inherited from &#x60;RatePlanCharge.Description&#x60; 
        /// </summary>
        /// <value> A description of the invoice item&#39;s charge. **Character limit**: 500 **Values**: inherited from &#x60;RatePlanCharge.Description&#x60; </value>
        [DataMember(Name="ChargeDescription", EmitDefaultValue=false)]
        public string ChargeDescription { get; set; }
        /// <summary>
        ///  The ID of the rate plan charge that is associated with this invoice item upon object creation. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60; 
        /// </summary>
        /// <value> The ID of the rate plan charge that is associated with this invoice item upon object creation. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60; </value>
        [DataMember(Name="ChargeId", EmitDefaultValue=false)]
        public string ChargeId { get; set; }
        /// <summary>
        ///  The name of the invoice item&#39;s charge. **Character limi**t: 50 **Values: **inherited from &#x60;RatePlanCharge.Name&#x60; 
        /// </summary>
        /// <value> The name of the invoice item&#39;s charge. **Character limi**t: 50 **Values: **inherited from &#x60;RatePlanCharge.Name&#x60; </value>
        [DataMember(Name="ChargeName", EmitDefaultValue=false)]
        public string ChargeName { get; set; }
        /// <summary>
        ///  The unique identifier of the invoice item&#39;s charge. **Character limit:** 50 **Values:** inherited from &#x60;RatePlanCharge.ChargeNumber&#x60; 
        /// </summary>
        /// <value> The unique identifier of the invoice item&#39;s charge. **Character limit:** 50 **Values:** inherited from &#x60;RatePlanCharge.ChargeNumber&#x60; </value>
        [DataMember(Name="ChargeNumber", EmitDefaultValue=false)]
        public string ChargeNumber { get; set; }
        /// <summary>
        ///  Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; 
        /// </summary>
        /// <value> Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; </value>
        [DataMember(Name="ChargeType", EmitDefaultValue=false)]
        public string ChargeType { get; set; }
        /// <summary>
        ///  The user ID of the person who created the invoice item. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The user ID of the person who created the invoice item. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date the invoice item was created. **Character limit:** 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date the invoice item was created. **Character limit:** 29 **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///  The ID of the invoice that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Invoice.Id&#x60; 
        /// </summary>
        /// <value> The ID of the invoice that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Invoice.Id&#x60; </value>
        [DataMember(Name="InvoiceId", EmitDefaultValue=false)]
        public string InvoiceId { get; set; }
        /// <summary>
        ///  Identifies the kind of charge where 0 is a charge, 1 is a discount, 2 is a prepayment, and 3 is a tax. The returned value is text not decimal on data sources. **Character limit**: **Values: **  - 0: charge - 1: discount - 2: prepayment - 3: tax 
        /// </summary>
        /// <value> Identifies the kind of charge where 0 is a charge, 1 is a discount, 2 is a prepayment, and 3 is a tax. The returned value is text not decimal on data sources. **Character limit**: **Values: **  - 0: charge - 1: discount - 2: prepayment - 3: tax </value>
        [DataMember(Name="ProcessingType", EmitDefaultValue=false)]
        public double? ProcessingType { get; set; }
        /// <summary>
        ///  A description of the product associated with this invoice item. **Character limit**: 500 **Values**: inherited from &#x60;Product.Description&#x60; 
        /// </summary>
        /// <value> A description of the product associated with this invoice item. **Character limit**: 500 **Values**: inherited from &#x60;Product.Description&#x60; </value>
        [DataMember(Name="ProductDescription", EmitDefaultValue=false)]
        public string ProductDescription { get; set; }
        /// <summary>
        ///  The ID of the product associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Product.Id&#x60; 
        /// </summary>
        /// <value> The ID of the product associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Product.Id&#x60; </value>
        [DataMember(Name="ProductId", EmitDefaultValue=false)]
        public string ProductId { get; set; }
        /// <summary>
        ///  The name of the product associated with this invoice item. **Character limit**: 255 **Values: **inherited from &#x60;Product.Name&#x60; 
        /// </summary>
        /// <value> The name of the product associated with this invoice item. **Character limit**: 255 **Values: **inherited from &#x60;Product.Name&#x60; </value>
        [DataMember(Name="ProductName", EmitDefaultValue=false)]
        public string ProductName { get; set; }
        /// <summary>
        ///  The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;ProductRatePlanCharge.Id&#x60; You cannot &#x60;query()&#x60; for this field. Only the s&#x60;ubscribe()&#x60; preview and the &#x60;amend()&#x60; preview calls will return the value of this field in the response.
        /// </summary>
        /// <value> The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;ProductRatePlanCharge.Id&#x60; You cannot &#x60;query()&#x60; for this field. Only the s&#x60;ubscribe()&#x60; preview and the &#x60;amend()&#x60; preview calls will return the value of this field in the response.</value>
        [DataMember(Name="ProductRatePlanChargeId", EmitDefaultValue=false)]
        public string ProductRatePlanChargeId { get; set; }
        /// <summary>
        ///  The number of units for this invoice item. **Values**: inherited from &#x60;RatePlanCharge.Quantity&#x60; 
        /// </summary>
        /// <value> The number of units for this invoice item. **Values**: inherited from &#x60;RatePlanCharge.Quantity&#x60; </value>
        [DataMember(Name="Quantity", EmitDefaultValue=false)]
        public double? Quantity { get; set; }
        /// <summary>
        ///  The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60; 
        /// </summary>
        /// <value> The ID of the rate plan charge that&#39;s associated with this invoice item. **Character limit**: 32 **Values**: inherited from &#x60;RatePlanCharge.Id&#x60; </value>
        [DataMember(Name="RatePlanChargeId", EmitDefaultValue=false)]
        public string RatePlanChargeId { get; set; }
        /// <summary>
        ///  Associates this invoice item with a specific revenue recognition code. **Character limit**: 32 **Values**: inherited from &#x60;ProductRatePlanCharge.RevRecCode&#x60; 
        /// </summary>
        /// <value> Associates this invoice item with a specific revenue recognition code. **Character limit**: 32 **Values**: inherited from &#x60;ProductRatePlanCharge.RevRecCode&#x60; </value>
        [DataMember(Name="RevRecCode", EmitDefaultValue=false)]
        public string RevRecCode { get; set; }
        /// <summary>
        ///  The date when revenue recognition is triggered. **Character limit**: 29 **Values**: generated from &#x60;InvoiceItem.RevRecTriggerCondition&#x60; 
        /// </summary>
        /// <value> The date when revenue recognition is triggered. **Character limit**: 29 **Values**: generated from &#x60;InvoiceItem.RevRecTriggerCondition&#x60; </value>
        [DataMember(Name="RevRecStartDate", EmitDefaultValue=false)]
        public DateTime? RevRecStartDate { get; set; }
        /// <summary>
        ///  Specifies when revenue recognition begins based on a triggering event. **Character limit**: **Values**: inherited from &#x60;[ProductRatePlanCharge](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/ProductRatePlanCharge).RevRecTriggerCondition&#x60; 
        /// </summary>
        /// <value> Specifies when revenue recognition begins based on a triggering event. **Character limit**: **Values**: inherited from &#x60;[ProductRatePlanCharge](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/ProductRatePlanCharge).RevRecTriggerCondition&#x60; </value>
        [DataMember(Name="RevRecTriggerCondition", EmitDefaultValue=false)]
        public string RevRecTriggerCondition { get; set; }
        /// <summary>
        ///  The unique SKU for the product associated with this invoice item. **Character limit**: 255 **Values**: inherited from &#x60;Product.SKU&#x60; 
        /// </summary>
        /// <value> The unique SKU for the product associated with this invoice item. **Character limit**: 255 **Values**: inherited from &#x60;Product.SKU&#x60; </value>
        [DataMember(Name="SKU", EmitDefaultValue=false)]
        public string SKU { get; set; }
        /// <summary>
        ///  The end date of the service period associated with this invoice item. Service ends one second before the date in this value. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The end date of the service period associated with this invoice item. Service ends one second before the date in this value. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="ServiceEndDate", EmitDefaultValue=false)]
        public DateTime? ServiceEndDate { get; set; }
        /// <summary>
        ///  The start date of the service period associated with this invoice item. If the associated charge is a one-time fee, then this date is the date of that charge. **Character limit:** 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The start date of the service period associated with this invoice item. If the associated charge is a one-time fee, then this date is the date of that charge. **Character limit:** 29 **Values**: automatically generated </value>
        [DataMember(Name="ServiceStartDate", EmitDefaultValue=false)]
        public DateTime? ServiceStartDate { get; set; }
        /// <summary>
        ///  The ID of the subscription associated with the invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Subscription.Id&#x60; 
        /// </summary>
        /// <value> The ID of the subscription associated with the invoice item. **Character limit**: 32 **Values**: inherited from &#x60;Subscription.Id&#x60; </value>
        [DataMember(Name="SubscriptionId", EmitDefaultValue=false)]
        public string SubscriptionId { get; set; }
        /// <summary>
        ///  The number of the subscription associated with the invoice item. **Character limit**: **Values**: 
        /// </summary>
        /// <value> The number of the subscription associated with the invoice item. **Character limit**: **Values**: </value>
        [DataMember(Name="SubscriptionNumber", EmitDefaultValue=false)]
        public string SubscriptionNumber { get; set; }
        /// <summary>
        ///  The amount of tax applied to the invoice item&#39;s charge. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object 
        /// </summary>
        /// <value> The amount of tax applied to the invoice item&#39;s charge. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object </value>
        [DataMember(Name="TaxAmount", EmitDefaultValue=false)]
        public double? TaxAmount { get; set; }
        /// <summary>
        ///  Specifies the tax code for taxation rules. **Character limit**: 6 **Values**: inherited from &#x60;ProductRatePlanCharge.TaxCode&#x60; 
        /// </summary>
        /// <value> Specifies the tax code for taxation rules. **Character limit**: 6 **Values**: inherited from &#x60;ProductRatePlanCharge.TaxCode&#x60; </value>
        [DataMember(Name="TaxCode", EmitDefaultValue=false)]
        public string TaxCode { get; set; }
        /// <summary>
        ///  The amount of the invoice item&#39;s charge that&#39;s tax exempt. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object 
        /// </summary>
        /// <value> The amount of the invoice item&#39;s charge that&#39;s tax exempt. **Character limit**: **Values**: calculated from multiple fields in the ProductRatePlanCharge object </value>
        [DataMember(Name="TaxExemptAmount", EmitDefaultValue=false)]
        public double? TaxExemptAmount { get; set; }
        /// <summary>
        ///  The tax mode of the invoice item. **Character limit**: 12 **Values**: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60; 
        /// </summary>
        /// <value> The tax mode of the invoice item. **Character limit**: 12 **Values**: &#x60;TaxExclusive&#x60;, &#x60;TaxInclusive&#x60; </value>
        [DataMember(Name="TaxMode", EmitDefaultValue=false)]
        public string TaxMode { get; set; }
        /// <summary>
        ///  Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings** **Character limit**: **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60; 
        /// </summary>
        /// <value> Specifies the units to measure usage. Units of measure are configured in the web-based UI: **Z-Billing &gt; Settings** **Character limit**: **Values**: inherited from &#x60;ProductRatePlanCharge.UOM&#x60; </value>
        [DataMember(Name="UOM", EmitDefaultValue=false)]
        public string UOM { get; set; }
        /// <summary>
        ///  The per-unit price of the invoice item. **Character limit**: **Values**: calculated from multiple fields in ProductRatePlanCharge and ProductRatePlanChargeTier objets 
        /// </summary>
        /// <value> The per-unit price of the invoice item. **Character limit**: **Values**: calculated from multiple fields in ProductRatePlanCharge and ProductRatePlanChargeTier objets </value>
        [DataMember(Name="UnitPrice", EmitDefaultValue=false)]
        public double? UnitPrice { get; set; }
        /// <summary>
        ///  The ID of the user who last updated the invoice item. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The ID of the user who last updated the invoice item. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the invoice item was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the invoice item was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InvoiceItem {\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  AppliedToInvoiceItemId: ").Append(AppliedToInvoiceItemId).Append("\n");
            sb.Append("  ChargeAmount: ").Append(ChargeAmount).Append("\n");
            sb.Append("  ChargeDate: ").Append(ChargeDate).Append("\n");
            sb.Append("  ChargeDescription: ").Append(ChargeDescription).Append("\n");
            sb.Append("  ChargeId: ").Append(ChargeId).Append("\n");
            sb.Append("  ChargeName: ").Append(ChargeName).Append("\n");
            sb.Append("  ChargeNumber: ").Append(ChargeNumber).Append("\n");
            sb.Append("  ChargeType: ").Append(ChargeType).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  InvoiceId: ").Append(InvoiceId).Append("\n");
            sb.Append("  ProcessingType: ").Append(ProcessingType).Append("\n");
            sb.Append("  ProductDescription: ").Append(ProductDescription).Append("\n");
            sb.Append("  ProductId: ").Append(ProductId).Append("\n");
            sb.Append("  ProductName: ").Append(ProductName).Append("\n");
            sb.Append("  ProductRatePlanChargeId: ").Append(ProductRatePlanChargeId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RatePlanChargeId: ").Append(RatePlanChargeId).Append("\n");
            sb.Append("  RevRecCode: ").Append(RevRecCode).Append("\n");
            sb.Append("  RevRecStartDate: ").Append(RevRecStartDate).Append("\n");
            sb.Append("  RevRecTriggerCondition: ").Append(RevRecTriggerCondition).Append("\n");
            sb.Append("  SKU: ").Append(SKU).Append("\n");
            sb.Append("  ServiceEndDate: ").Append(ServiceEndDate).Append("\n");
            sb.Append("  ServiceStartDate: ").Append(ServiceStartDate).Append("\n");
            sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
            sb.Append("  SubscriptionNumber: ").Append(SubscriptionNumber).Append("\n");
            sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxExemptAmount: ").Append(TaxExemptAmount).Append("\n");
            sb.Append("  TaxMode: ").Append(TaxMode).Append("\n");
            sb.Append("  UOM: ").Append(UOM).Append("\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
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
            return this.Equals(obj as InvoiceItem);
        }

        /// <summary>
        /// Returns true if InvoiceItem instances are equal
        /// </summary>
        /// <param name="other">Instance of InvoiceItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InvoiceItem other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AccountingCode == other.AccountingCode ||
                    this.AccountingCode != null &&
                    this.AccountingCode.Equals(other.AccountingCode)
                ) && 
                (
                    this.AppliedToInvoiceItemId == other.AppliedToInvoiceItemId ||
                    this.AppliedToInvoiceItemId != null &&
                    this.AppliedToInvoiceItemId.Equals(other.AppliedToInvoiceItemId)
                ) && 
                (
                    this.ChargeAmount == other.ChargeAmount ||
                    this.ChargeAmount != null &&
                    this.ChargeAmount.Equals(other.ChargeAmount)
                ) && 
                (
                    this.ChargeDate == other.ChargeDate ||
                    this.ChargeDate != null &&
                    this.ChargeDate.Equals(other.ChargeDate)
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
                    this.ChargeNumber == other.ChargeNumber ||
                    this.ChargeNumber != null &&
                    this.ChargeNumber.Equals(other.ChargeNumber)
                ) && 
                (
                    this.ChargeType == other.ChargeType ||
                    this.ChargeType != null &&
                    this.ChargeType.Equals(other.ChargeType)
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
                    this.InvoiceId == other.InvoiceId ||
                    this.InvoiceId != null &&
                    this.InvoiceId.Equals(other.InvoiceId)
                ) && 
                (
                    this.ProcessingType == other.ProcessingType ||
                    this.ProcessingType != null &&
                    this.ProcessingType.Equals(other.ProcessingType)
                ) && 
                (
                    this.ProductDescription == other.ProductDescription ||
                    this.ProductDescription != null &&
                    this.ProductDescription.Equals(other.ProductDescription)
                ) && 
                (
                    this.ProductId == other.ProductId ||
                    this.ProductId != null &&
                    this.ProductId.Equals(other.ProductId)
                ) && 
                (
                    this.ProductName == other.ProductName ||
                    this.ProductName != null &&
                    this.ProductName.Equals(other.ProductName)
                ) && 
                (
                    this.ProductRatePlanChargeId == other.ProductRatePlanChargeId ||
                    this.ProductRatePlanChargeId != null &&
                    this.ProductRatePlanChargeId.Equals(other.ProductRatePlanChargeId)
                ) && 
                (
                    this.Quantity == other.Quantity ||
                    this.Quantity != null &&
                    this.Quantity.Equals(other.Quantity)
                ) && 
                (
                    this.RatePlanChargeId == other.RatePlanChargeId ||
                    this.RatePlanChargeId != null &&
                    this.RatePlanChargeId.Equals(other.RatePlanChargeId)
                ) && 
                (
                    this.RevRecCode == other.RevRecCode ||
                    this.RevRecCode != null &&
                    this.RevRecCode.Equals(other.RevRecCode)
                ) && 
                (
                    this.RevRecStartDate == other.RevRecStartDate ||
                    this.RevRecStartDate != null &&
                    this.RevRecStartDate.Equals(other.RevRecStartDate)
                ) && 
                (
                    this.RevRecTriggerCondition == other.RevRecTriggerCondition ||
                    this.RevRecTriggerCondition != null &&
                    this.RevRecTriggerCondition.Equals(other.RevRecTriggerCondition)
                ) && 
                (
                    this.SKU == other.SKU ||
                    this.SKU != null &&
                    this.SKU.Equals(other.SKU)
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
                    this.SubscriptionNumber == other.SubscriptionNumber ||
                    this.SubscriptionNumber != null &&
                    this.SubscriptionNumber.Equals(other.SubscriptionNumber)
                ) && 
                (
                    this.TaxAmount == other.TaxAmount ||
                    this.TaxAmount != null &&
                    this.TaxAmount.Equals(other.TaxAmount)
                ) && 
                (
                    this.TaxCode == other.TaxCode ||
                    this.TaxCode != null &&
                    this.TaxCode.Equals(other.TaxCode)
                ) && 
                (
                    this.TaxExemptAmount == other.TaxExemptAmount ||
                    this.TaxExemptAmount != null &&
                    this.TaxExemptAmount.Equals(other.TaxExemptAmount)
                ) && 
                (
                    this.TaxMode == other.TaxMode ||
                    this.TaxMode != null &&
                    this.TaxMode.Equals(other.TaxMode)
                ) && 
                (
                    this.UOM == other.UOM ||
                    this.UOM != null &&
                    this.UOM.Equals(other.UOM)
                ) && 
                (
                    this.UnitPrice == other.UnitPrice ||
                    this.UnitPrice != null &&
                    this.UnitPrice.Equals(other.UnitPrice)
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
                if (this.AccountingCode != null)
                    hash = hash * 59 + this.AccountingCode.GetHashCode();
                if (this.AppliedToInvoiceItemId != null)
                    hash = hash * 59 + this.AppliedToInvoiceItemId.GetHashCode();
                if (this.ChargeAmount != null)
                    hash = hash * 59 + this.ChargeAmount.GetHashCode();
                if (this.ChargeDate != null)
                    hash = hash * 59 + this.ChargeDate.GetHashCode();
                if (this.ChargeDescription != null)
                    hash = hash * 59 + this.ChargeDescription.GetHashCode();
                if (this.ChargeId != null)
                    hash = hash * 59 + this.ChargeId.GetHashCode();
                if (this.ChargeName != null)
                    hash = hash * 59 + this.ChargeName.GetHashCode();
                if (this.ChargeNumber != null)
                    hash = hash * 59 + this.ChargeNumber.GetHashCode();
                if (this.ChargeType != null)
                    hash = hash * 59 + this.ChargeType.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.InvoiceId != null)
                    hash = hash * 59 + this.InvoiceId.GetHashCode();
                if (this.ProcessingType != null)
                    hash = hash * 59 + this.ProcessingType.GetHashCode();
                if (this.ProductDescription != null)
                    hash = hash * 59 + this.ProductDescription.GetHashCode();
                if (this.ProductId != null)
                    hash = hash * 59 + this.ProductId.GetHashCode();
                if (this.ProductName != null)
                    hash = hash * 59 + this.ProductName.GetHashCode();
                if (this.ProductRatePlanChargeId != null)
                    hash = hash * 59 + this.ProductRatePlanChargeId.GetHashCode();
                if (this.Quantity != null)
                    hash = hash * 59 + this.Quantity.GetHashCode();
                if (this.RatePlanChargeId != null)
                    hash = hash * 59 + this.RatePlanChargeId.GetHashCode();
                if (this.RevRecCode != null)
                    hash = hash * 59 + this.RevRecCode.GetHashCode();
                if (this.RevRecStartDate != null)
                    hash = hash * 59 + this.RevRecStartDate.GetHashCode();
                if (this.RevRecTriggerCondition != null)
                    hash = hash * 59 + this.RevRecTriggerCondition.GetHashCode();
                if (this.SKU != null)
                    hash = hash * 59 + this.SKU.GetHashCode();
                if (this.ServiceEndDate != null)
                    hash = hash * 59 + this.ServiceEndDate.GetHashCode();
                if (this.ServiceStartDate != null)
                    hash = hash * 59 + this.ServiceStartDate.GetHashCode();
                if (this.SubscriptionId != null)
                    hash = hash * 59 + this.SubscriptionId.GetHashCode();
                if (this.SubscriptionNumber != null)
                    hash = hash * 59 + this.SubscriptionNumber.GetHashCode();
                if (this.TaxAmount != null)
                    hash = hash * 59 + this.TaxAmount.GetHashCode();
                if (this.TaxCode != null)
                    hash = hash * 59 + this.TaxCode.GetHashCode();
                if (this.TaxExemptAmount != null)
                    hash = hash * 59 + this.TaxExemptAmount.GetHashCode();
                if (this.TaxMode != null)
                    hash = hash * 59 + this.TaxMode.GetHashCode();
                if (this.UOM != null)
                    hash = hash * 59 + this.UOM.GetHashCode();
                if (this.UnitPrice != null)
                    hash = hash * 59 + this.UnitPrice.GetHashCode();
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
