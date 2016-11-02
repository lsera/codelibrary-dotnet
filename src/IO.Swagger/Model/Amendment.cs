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
    /// Amendment
    /// </summary>
    [DataContract]
    public partial class Amendment :  IEquatable<Amendment>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Amendment" /> class.
        /// </summary>
        /// <param name="AutoRenew"> Determines whether the subscription is automatically renewed, or whether it expires at the end of the term and needs to be manually renewed. **Required:** For amendment of type TermsAndConditions when changing the automatic renewal status of a subscription. **Values**: true, false .</param>
        /// <param name="Code"> A unique alphanumeric string that identifies the amendment. **Character limit**: 50 **Values**: one of the following:  - &#x60;null&#x60; generates a value automatically - A string .</param>
        /// <param name="ContractEffectiveDate"> The date when the amendment&#39;s changes become effective for billing purposes. **Version notes**: - - .</param>
        /// <param name="CreatedById"> The user ID of the person who created the amendment. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="CreatedDate"> The date when the amendment was created. **Values**: automatically generated .</param>
        /// <param name="CurrentTerm"> The length of the period for the current subscription term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60; and TermType is set to &#x60;TERMED&#x60;. This field is not required if TermType is set to &#x60;EVERGREEN&#x60;. **Character limit**: **Values**: a valid number **Note**: The InitialTerm field is deprecated from WSDL 73.0, use the CurrentTerm field instead. .</param>
        /// <param name="CurrentTermPeriodType"> The period type for the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the CurrentTerm field to specify the current subscription term. .</param>
        /// <param name="CustomerAcceptanceDate"> The date when the customer accepts the amendment&#39;s changes to the subscription. Use this field if [Zuora is configured to require customer acceptance in Z-Billing](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/Define_Default_Subscription_Settings). **Required**: Only if the value of the Status field is set to PendingAcceptance. **Version notes**: - - .</param>
        /// <param name="Description"> A description of the amendment. **Character limit**: 500 **Values**: maximum 500 characters .</param>
        /// <param name="DestinationAccountId"> The ID of the account that the subscription is being transferred to. **Character limit**: 32 **Values**: [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) .</param>
        /// <param name="DestinationInvoiceOwnerId"> The ID of the invoice that the subscription is being transferred to. **Character limit**: 32 **Values**: [a valid invoice ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Invoice#Id) .</param>
        /// <param name="EffectiveDate"> The date when the amendment&#39;s changes take effective. This field validates that the amendment&#39;s changes are within valid ranges of products and product rate plans. **Required**: For the cancellation amendments. Optional for other types of amendments. **Version notes**: - - .</param>
        /// <param name="Name"> The name of the amendment. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="RatePlanData"> A container for one [RatePlanData](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/F_SOAP_API_Complex_Types/RatePlanData) .</param>
        /// <param name="RenewalSetting"> Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: RENEW_WITH_SPECIFIC_TERM (default), RENEW_TO_EVERGREEN .</param>
        /// <param name="RenewalTerm"> The term of renewal for the amended subscription. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60;. **Character limit**: **Values:** a valid number .</param>
        /// <param name="RenewalTermPeriodType"> The period type for the subscription renewal term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60;. This field is used with the RenewalTerm field to specify the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; .</param>
        /// <param name="ServiceActivationDate"> The date when service is activated. Use this field if [Zuora is configured to require service activation in Z-Billing](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/Define_Default_Subscription_Settings). **Required**: Only if the value of the Status field is set to PendingActivation. **Version notes**: - - .</param>
        /// <param name="SpecificUpdateDate"> The date when the UpdateProduct amendment takes effect. This field is only applicable if there is already a future-dated UpdateProduct amendment on the subscription. See [Create an UpdateProduct Amendment Before a Future-dated Update](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Amendment/Update_a_Product_(Amendment)#Create_an_UpdateProduct_Amendment_Before_a_Future-dated_Update_(API_version_71.0.2B)) for more information. **Required**: Only for the UpdateProduct amendments if there is already a future-dated UpdateProduct amendment on the subscription. **Version notes**: WSDL 71.0+ .</param>
        /// <param name="Status"> The status of the amendment. Type: string (enum) **Character limit**: 17 **Values**: one of the following:  - Draft (default, if left null) - Pending Activation - Pending Acceptance - Completed .</param>
        /// <param name="SubscriptionId"> The ID of the subscription that the amendment changes. **Character limit**: 32 **Values**: [a valid subscription ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Subscription#Id) .</param>
        /// <param name="TermStartDate"> The date when the new terms and conditions take effect. **Required**: Only if the value of the Type field is set to TermsAndConditions. **Version notes**: - - .</param>
        /// <param name="TermType"> Indicates if the subscription isTERMED or EVERGREEN.  - A TERMED subscription has an expiration date, and must be manually renewed. - An EVERGREEN subscription doesn&#39;t have an expiration date, and must be manually ended.  **Required**: Only when as part of an amendment of type TermsAndConditions &amp;#65279;to change the term type of a subscription. Type: string **Character limit**: 9 **Values**: TERMED, EVERGREEN .</param>
        /// <param name="Type"> The type of amendment. **Character limit**: 18 **Values**: one of the following:  - Cancellation - NewProduct - OwnerTransfer - RemoveProduct - Renewal - UpdateProduct - TermsAndConditions - SuspendSubscription (This value is in **Limited Availability**.) - ResumeSubscription (This value is in **Limited Availability**.) .</param>
        /// <param name="UpdatedById"> The ID of the user who last updated the amendment. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="UpdatedDate"> The date when the amendment was last updated. **Values**: automatically generated .</param>
        public Amendment(bool? AutoRenew = null, string Code = null, DateTime? ContractEffectiveDate = null, string CreatedById = null, DateTime? CreatedDate = null, long? CurrentTerm = null, string CurrentTermPeriodType = null, DateTime? CustomerAcceptanceDate = null, string Description = null, string DestinationAccountId = null, string DestinationInvoiceOwnerId = null, DateTime? EffectiveDate = null, string Name = null, RatePlanData RatePlanData = null, string RenewalSetting = null, long? RenewalTerm = null, string RenewalTermPeriodType = null, DateTime? ServiceActivationDate = null, DateTime? SpecificUpdateDate = null, string Status = null, string SubscriptionId = null, DateTime? TermStartDate = null, string TermType = null, string Type = null, string UpdatedById = null, DateTime? UpdatedDate = null)
        {
            this.AutoRenew = AutoRenew;
            this.Code = Code;
            this.ContractEffectiveDate = ContractEffectiveDate;
            this.CreatedById = CreatedById;
            this.CreatedDate = CreatedDate;
            this.CurrentTerm = CurrentTerm;
            this.CurrentTermPeriodType = CurrentTermPeriodType;
            this.CustomerAcceptanceDate = CustomerAcceptanceDate;
            this.Description = Description;
            this.DestinationAccountId = DestinationAccountId;
            this.DestinationInvoiceOwnerId = DestinationInvoiceOwnerId;
            this.EffectiveDate = EffectiveDate;
            this.Name = Name;
            this.RatePlanData = RatePlanData;
            this.RenewalSetting = RenewalSetting;
            this.RenewalTerm = RenewalTerm;
            this.RenewalTermPeriodType = RenewalTermPeriodType;
            this.ServiceActivationDate = ServiceActivationDate;
            this.SpecificUpdateDate = SpecificUpdateDate;
            this.Status = Status;
            this.SubscriptionId = SubscriptionId;
            this.TermStartDate = TermStartDate;
            this.TermType = TermType;
            this.Type = Type;
            this.UpdatedById = UpdatedById;
            this.UpdatedDate = UpdatedDate;
        }
        
        /// <summary>
        ///  Determines whether the subscription is automatically renewed, or whether it expires at the end of the term and needs to be manually renewed. **Required:** For amendment of type TermsAndConditions when changing the automatic renewal status of a subscription. **Values**: true, false 
        /// </summary>
        /// <value> Determines whether the subscription is automatically renewed, or whether it expires at the end of the term and needs to be manually renewed. **Required:** For amendment of type TermsAndConditions when changing the automatic renewal status of a subscription. **Values**: true, false </value>
        [DataMember(Name="AutoRenew", EmitDefaultValue=false)]
        public bool? AutoRenew { get; set; }
        /// <summary>
        ///  A unique alphanumeric string that identifies the amendment. **Character limit**: 50 **Values**: one of the following:  - &#x60;null&#x60; generates a value automatically - A string 
        /// </summary>
        /// <value> A unique alphanumeric string that identifies the amendment. **Character limit**: 50 **Values**: one of the following:  - &#x60;null&#x60; generates a value automatically - A string </value>
        [DataMember(Name="Code", EmitDefaultValue=false)]
        public string Code { get; set; }
        /// <summary>
        ///  The date when the amendment&#39;s changes become effective for billing purposes. **Version notes**: - - 
        /// </summary>
        /// <value> The date when the amendment&#39;s changes become effective for billing purposes. **Version notes**: - - </value>
        [DataMember(Name="ContractEffectiveDate", EmitDefaultValue=false)]
        public DateTime? ContractEffectiveDate { get; set; }
        /// <summary>
        ///  The user ID of the person who created the amendment. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The user ID of the person who created the amendment. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="CreatedById", EmitDefaultValue=false)]
        public string CreatedById { get; set; }
        /// <summary>
        ///  The date when the amendment was created. **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the amendment was created. **Values**: automatically generated </value>
        [DataMember(Name="CreatedDate", EmitDefaultValue=false)]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        ///  The length of the period for the current subscription term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60; and TermType is set to &#x60;TERMED&#x60;. This field is not required if TermType is set to &#x60;EVERGREEN&#x60;. **Character limit**: **Values**: a valid number **Note**: The InitialTerm field is deprecated from WSDL 73.0, use the CurrentTerm field instead. 
        /// </summary>
        /// <value> The length of the period for the current subscription term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60; and TermType is set to &#x60;TERMED&#x60;. This field is not required if TermType is set to &#x60;EVERGREEN&#x60;. **Character limit**: **Values**: a valid number **Note**: The InitialTerm field is deprecated from WSDL 73.0, use the CurrentTerm field instead. </value>
        [DataMember(Name="CurrentTerm", EmitDefaultValue=false)]
        public long? CurrentTerm { get; set; }
        /// <summary>
        ///  The period type for the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the CurrentTerm field to specify the current subscription term. 
        /// </summary>
        /// <value> The period type for the current subscription term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; **Note**:  - This field can be updated when Status is &#x60;Draft&#x60;. - This field is used with the CurrentTerm field to specify the current subscription term. </value>
        [DataMember(Name="CurrentTermPeriodType", EmitDefaultValue=false)]
        public string CurrentTermPeriodType { get; set; }
        /// <summary>
        ///  The date when the customer accepts the amendment&#39;s changes to the subscription. Use this field if [Zuora is configured to require customer acceptance in Z-Billing](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/Define_Default_Subscription_Settings). **Required**: Only if the value of the Status field is set to PendingAcceptance. **Version notes**: - - 
        /// </summary>
        /// <value> The date when the customer accepts the amendment&#39;s changes to the subscription. Use this field if [Zuora is configured to require customer acceptance in Z-Billing](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/Define_Default_Subscription_Settings). **Required**: Only if the value of the Status field is set to PendingAcceptance. **Version notes**: - - </value>
        [DataMember(Name="CustomerAcceptanceDate", EmitDefaultValue=false)]
        public DateTime? CustomerAcceptanceDate { get; set; }
        /// <summary>
        ///  A description of the amendment. **Character limit**: 500 **Values**: maximum 500 characters 
        /// </summary>
        /// <value> A description of the amendment. **Character limit**: 500 **Values**: maximum 500 characters </value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        ///  The ID of the account that the subscription is being transferred to. **Character limit**: 32 **Values**: [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) 
        /// </summary>
        /// <value> The ID of the account that the subscription is being transferred to. **Character limit**: 32 **Values**: [a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) </value>
        [DataMember(Name="DestinationAccountId", EmitDefaultValue=false)]
        public string DestinationAccountId { get; set; }
        /// <summary>
        ///  The ID of the invoice that the subscription is being transferred to. **Character limit**: 32 **Values**: [a valid invoice ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Invoice#Id) 
        /// </summary>
        /// <value> The ID of the invoice that the subscription is being transferred to. **Character limit**: 32 **Values**: [a valid invoice ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Invoice#Id) </value>
        [DataMember(Name="DestinationInvoiceOwnerId", EmitDefaultValue=false)]
        public string DestinationInvoiceOwnerId { get; set; }
        /// <summary>
        ///  The date when the amendment&#39;s changes take effective. This field validates that the amendment&#39;s changes are within valid ranges of products and product rate plans. **Required**: For the cancellation amendments. Optional for other types of amendments. **Version notes**: - - 
        /// </summary>
        /// <value> The date when the amendment&#39;s changes take effective. This field validates that the amendment&#39;s changes are within valid ranges of products and product rate plans. **Required**: For the cancellation amendments. Optional for other types of amendments. **Version notes**: - - </value>
        [DataMember(Name="EffectiveDate", EmitDefaultValue=false)]
        public DateTime? EffectiveDate { get; set; }
        /// <summary>
        ///  The name of the amendment. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value> The name of the amendment. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }
        /// <summary>
        ///  A container for one [RatePlanData](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/F_SOAP_API_Complex_Types/RatePlanData) 
        /// </summary>
        /// <value> A container for one [RatePlanData](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/F_SOAP_API_Complex_Types/RatePlanData) </value>
        [DataMember(Name="RatePlanData", EmitDefaultValue=false)]
        public RatePlanData RatePlanData { get; set; }
        /// <summary>
        ///  Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: RENEW_WITH_SPECIFIC_TERM (default), RENEW_TO_EVERGREEN 
        /// </summary>
        /// <value> Specifies whether a termed subscription will remain termed or change to evergreen when it is renewed. **Required**: If TermType is Termed **Values**: RENEW_WITH_SPECIFIC_TERM (default), RENEW_TO_EVERGREEN </value>
        [DataMember(Name="RenewalSetting", EmitDefaultValue=false)]
        public string RenewalSetting { get; set; }
        /// <summary>
        ///  The term of renewal for the amended subscription. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60;. **Character limit**: **Values:** a valid number 
        /// </summary>
        /// <value> The term of renewal for the amended subscription. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60;. **Character limit**: **Values:** a valid number </value>
        [DataMember(Name="RenewalTerm", EmitDefaultValue=false)]
        public long? RenewalTerm { get; set; }
        /// <summary>
        ///  The period type for the subscription renewal term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60;. This field is used with the RenewalTerm field to specify the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; 
        /// </summary>
        /// <value> The period type for the subscription renewal term. This field can be updated when Status is &#x60;Draft&#x60;. **Required**: Only if the value of the Type field is set to &#x60;TermsAndConditions&#x60;. This field is used with the RenewalTerm field to specify the subscription renewal term. **Values**:  - &#x60;Month&#x60; (default) - &#x60;Year&#x60; - &#x60;Day&#x60; - &#x60;Week&#x60; </value>
        [DataMember(Name="RenewalTermPeriodType", EmitDefaultValue=false)]
        public string RenewalTermPeriodType { get; set; }
        /// <summary>
        ///  The date when service is activated. Use this field if [Zuora is configured to require service activation in Z-Billing](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/Define_Default_Subscription_Settings). **Required**: Only if the value of the Status field is set to PendingActivation. **Version notes**: - - 
        /// </summary>
        /// <value> The date when service is activated. Use this field if [Zuora is configured to require service activation in Z-Billing](https://knowledgecenter.zuora.com/CB_Billing/W_Billing_and_Payments_Settings/Define_Default_Subscription_Settings). **Required**: Only if the value of the Status field is set to PendingActivation. **Version notes**: - - </value>
        [DataMember(Name="ServiceActivationDate", EmitDefaultValue=false)]
        public DateTime? ServiceActivationDate { get; set; }
        /// <summary>
        ///  The date when the UpdateProduct amendment takes effect. This field is only applicable if there is already a future-dated UpdateProduct amendment on the subscription. See [Create an UpdateProduct Amendment Before a Future-dated Update](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Amendment/Update_a_Product_(Amendment)#Create_an_UpdateProduct_Amendment_Before_a_Future-dated_Update_(API_version_71.0.2B)) for more information. **Required**: Only for the UpdateProduct amendments if there is already a future-dated UpdateProduct amendment on the subscription. **Version notes**: WSDL 71.0+ 
        /// </summary>
        /// <value> The date when the UpdateProduct amendment takes effect. This field is only applicable if there is already a future-dated UpdateProduct amendment on the subscription. See [Create an UpdateProduct Amendment Before a Future-dated Update](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Amendment/Update_a_Product_(Amendment)#Create_an_UpdateProduct_Amendment_Before_a_Future-dated_Update_(API_version_71.0.2B)) for more information. **Required**: Only for the UpdateProduct amendments if there is already a future-dated UpdateProduct amendment on the subscription. **Version notes**: WSDL 71.0+ </value>
        [DataMember(Name="SpecificUpdateDate", EmitDefaultValue=false)]
        public DateTime? SpecificUpdateDate { get; set; }
        /// <summary>
        ///  The status of the amendment. Type: string (enum) **Character limit**: 17 **Values**: one of the following:  - Draft (default, if left null) - Pending Activation - Pending Acceptance - Completed 
        /// </summary>
        /// <value> The status of the amendment. Type: string (enum) **Character limit**: 17 **Values**: one of the following:  - Draft (default, if left null) - Pending Activation - Pending Acceptance - Completed </value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public string Status { get; set; }
        /// <summary>
        ///  The ID of the subscription that the amendment changes. **Character limit**: 32 **Values**: [a valid subscription ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Subscription#Id) 
        /// </summary>
        /// <value> The ID of the subscription that the amendment changes. **Character limit**: 32 **Values**: [a valid subscription ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Subscription#Id) </value>
        [DataMember(Name="SubscriptionId", EmitDefaultValue=false)]
        public string SubscriptionId { get; set; }
        /// <summary>
        ///  The date when the new terms and conditions take effect. **Required**: Only if the value of the Type field is set to TermsAndConditions. **Version notes**: - - 
        /// </summary>
        /// <value> The date when the new terms and conditions take effect. **Required**: Only if the value of the Type field is set to TermsAndConditions. **Version notes**: - - </value>
        [DataMember(Name="TermStartDate", EmitDefaultValue=false)]
        public DateTime? TermStartDate { get; set; }
        /// <summary>
        ///  Indicates if the subscription isTERMED or EVERGREEN.  - A TERMED subscription has an expiration date, and must be manually renewed. - An EVERGREEN subscription doesn&#39;t have an expiration date, and must be manually ended.  **Required**: Only when as part of an amendment of type TermsAndConditions &amp;#65279;to change the term type of a subscription. Type: string **Character limit**: 9 **Values**: TERMED, EVERGREEN 
        /// </summary>
        /// <value> Indicates if the subscription isTERMED or EVERGREEN.  - A TERMED subscription has an expiration date, and must be manually renewed. - An EVERGREEN subscription doesn&#39;t have an expiration date, and must be manually ended.  **Required**: Only when as part of an amendment of type TermsAndConditions &amp;#65279;to change the term type of a subscription. Type: string **Character limit**: 9 **Values**: TERMED, EVERGREEN </value>
        [DataMember(Name="TermType", EmitDefaultValue=false)]
        public string TermType { get; set; }
        /// <summary>
        ///  The type of amendment. **Character limit**: 18 **Values**: one of the following:  - Cancellation - NewProduct - OwnerTransfer - RemoveProduct - Renewal - UpdateProduct - TermsAndConditions - SuspendSubscription (This value is in **Limited Availability**.) - ResumeSubscription (This value is in **Limited Availability**.) 
        /// </summary>
        /// <value> The type of amendment. **Character limit**: 18 **Values**: one of the following:  - Cancellation - NewProduct - OwnerTransfer - RemoveProduct - Renewal - UpdateProduct - TermsAndConditions - SuspendSubscription (This value is in **Limited Availability**.) - ResumeSubscription (This value is in **Limited Availability**.) </value>
        [DataMember(Name="Type", EmitDefaultValue=false)]
        public string Type { get; set; }
        /// <summary>
        ///  The ID of the user who last updated the amendment. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value> The ID of the user who last updated the amendment. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name="UpdatedById", EmitDefaultValue=false)]
        public string UpdatedById { get; set; }
        /// <summary>
        ///  The date when the amendment was last updated. **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the amendment was last updated. **Values**: automatically generated </value>
        [DataMember(Name="UpdatedDate", EmitDefaultValue=false)]
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Amendment {\n");
            sb.Append("  AutoRenew: ").Append(AutoRenew).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  ContractEffectiveDate: ").Append(ContractEffectiveDate).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CurrentTerm: ").Append(CurrentTerm).Append("\n");
            sb.Append("  CurrentTermPeriodType: ").Append(CurrentTermPeriodType).Append("\n");
            sb.Append("  CustomerAcceptanceDate: ").Append(CustomerAcceptanceDate).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DestinationAccountId: ").Append(DestinationAccountId).Append("\n");
            sb.Append("  DestinationInvoiceOwnerId: ").Append(DestinationInvoiceOwnerId).Append("\n");
            sb.Append("  EffectiveDate: ").Append(EffectiveDate).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RatePlanData: ").Append(RatePlanData).Append("\n");
            sb.Append("  RenewalSetting: ").Append(RenewalSetting).Append("\n");
            sb.Append("  RenewalTerm: ").Append(RenewalTerm).Append("\n");
            sb.Append("  RenewalTermPeriodType: ").Append(RenewalTermPeriodType).Append("\n");
            sb.Append("  ServiceActivationDate: ").Append(ServiceActivationDate).Append("\n");
            sb.Append("  SpecificUpdateDate: ").Append(SpecificUpdateDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
            sb.Append("  TermStartDate: ").Append(TermStartDate).Append("\n");
            sb.Append("  TermType: ").Append(TermType).Append("\n");
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
            return this.Equals(obj as Amendment);
        }

        /// <summary>
        /// Returns true if Amendment instances are equal
        /// </summary>
        /// <param name="other">Instance of Amendment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Amendment other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.AutoRenew == other.AutoRenew ||
                    this.AutoRenew != null &&
                    this.AutoRenew.Equals(other.AutoRenew)
                ) && 
                (
                    this.Code == other.Code ||
                    this.Code != null &&
                    this.Code.Equals(other.Code)
                ) && 
                (
                    this.ContractEffectiveDate == other.ContractEffectiveDate ||
                    this.ContractEffectiveDate != null &&
                    this.ContractEffectiveDate.Equals(other.ContractEffectiveDate)
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
                    this.CurrentTerm == other.CurrentTerm ||
                    this.CurrentTerm != null &&
                    this.CurrentTerm.Equals(other.CurrentTerm)
                ) && 
                (
                    this.CurrentTermPeriodType == other.CurrentTermPeriodType ||
                    this.CurrentTermPeriodType != null &&
                    this.CurrentTermPeriodType.Equals(other.CurrentTermPeriodType)
                ) && 
                (
                    this.CustomerAcceptanceDate == other.CustomerAcceptanceDate ||
                    this.CustomerAcceptanceDate != null &&
                    this.CustomerAcceptanceDate.Equals(other.CustomerAcceptanceDate)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.DestinationAccountId == other.DestinationAccountId ||
                    this.DestinationAccountId != null &&
                    this.DestinationAccountId.Equals(other.DestinationAccountId)
                ) && 
                (
                    this.DestinationInvoiceOwnerId == other.DestinationInvoiceOwnerId ||
                    this.DestinationInvoiceOwnerId != null &&
                    this.DestinationInvoiceOwnerId.Equals(other.DestinationInvoiceOwnerId)
                ) && 
                (
                    this.EffectiveDate == other.EffectiveDate ||
                    this.EffectiveDate != null &&
                    this.EffectiveDate.Equals(other.EffectiveDate)
                ) && 
                (
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.RatePlanData == other.RatePlanData ||
                    this.RatePlanData != null &&
                    this.RatePlanData.Equals(other.RatePlanData)
                ) && 
                (
                    this.RenewalSetting == other.RenewalSetting ||
                    this.RenewalSetting != null &&
                    this.RenewalSetting.Equals(other.RenewalSetting)
                ) && 
                (
                    this.RenewalTerm == other.RenewalTerm ||
                    this.RenewalTerm != null &&
                    this.RenewalTerm.Equals(other.RenewalTerm)
                ) && 
                (
                    this.RenewalTermPeriodType == other.RenewalTermPeriodType ||
                    this.RenewalTermPeriodType != null &&
                    this.RenewalTermPeriodType.Equals(other.RenewalTermPeriodType)
                ) && 
                (
                    this.ServiceActivationDate == other.ServiceActivationDate ||
                    this.ServiceActivationDate != null &&
                    this.ServiceActivationDate.Equals(other.ServiceActivationDate)
                ) && 
                (
                    this.SpecificUpdateDate == other.SpecificUpdateDate ||
                    this.SpecificUpdateDate != null &&
                    this.SpecificUpdateDate.Equals(other.SpecificUpdateDate)
                ) && 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.SubscriptionId == other.SubscriptionId ||
                    this.SubscriptionId != null &&
                    this.SubscriptionId.Equals(other.SubscriptionId)
                ) && 
                (
                    this.TermStartDate == other.TermStartDate ||
                    this.TermStartDate != null &&
                    this.TermStartDate.Equals(other.TermStartDate)
                ) && 
                (
                    this.TermType == other.TermType ||
                    this.TermType != null &&
                    this.TermType.Equals(other.TermType)
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
                if (this.AutoRenew != null)
                    hash = hash * 59 + this.AutoRenew.GetHashCode();
                if (this.Code != null)
                    hash = hash * 59 + this.Code.GetHashCode();
                if (this.ContractEffectiveDate != null)
                    hash = hash * 59 + this.ContractEffectiveDate.GetHashCode();
                if (this.CreatedById != null)
                    hash = hash * 59 + this.CreatedById.GetHashCode();
                if (this.CreatedDate != null)
                    hash = hash * 59 + this.CreatedDate.GetHashCode();
                if (this.CurrentTerm != null)
                    hash = hash * 59 + this.CurrentTerm.GetHashCode();
                if (this.CurrentTermPeriodType != null)
                    hash = hash * 59 + this.CurrentTermPeriodType.GetHashCode();
                if (this.CustomerAcceptanceDate != null)
                    hash = hash * 59 + this.CustomerAcceptanceDate.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.DestinationAccountId != null)
                    hash = hash * 59 + this.DestinationAccountId.GetHashCode();
                if (this.DestinationInvoiceOwnerId != null)
                    hash = hash * 59 + this.DestinationInvoiceOwnerId.GetHashCode();
                if (this.EffectiveDate != null)
                    hash = hash * 59 + this.EffectiveDate.GetHashCode();
                if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                if (this.RatePlanData != null)
                    hash = hash * 59 + this.RatePlanData.GetHashCode();
                if (this.RenewalSetting != null)
                    hash = hash * 59 + this.RenewalSetting.GetHashCode();
                if (this.RenewalTerm != null)
                    hash = hash * 59 + this.RenewalTerm.GetHashCode();
                if (this.RenewalTermPeriodType != null)
                    hash = hash * 59 + this.RenewalTermPeriodType.GetHashCode();
                if (this.ServiceActivationDate != null)
                    hash = hash * 59 + this.ServiceActivationDate.GetHashCode();
                if (this.SpecificUpdateDate != null)
                    hash = hash * 59 + this.SpecificUpdateDate.GetHashCode();
                if (this.Status != null)
                    hash = hash * 59 + this.Status.GetHashCode();
                if (this.SubscriptionId != null)
                    hash = hash * 59 + this.SubscriptionId.GetHashCode();
                if (this.TermStartDate != null)
                    hash = hash * 59 + this.TermStartDate.GetHashCode();
                if (this.TermType != null)
                    hash = hash * 59 + this.TermType.GetHashCode();
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
