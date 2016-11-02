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
    /// ProxyCreateContact
    /// </summary>
    [DataContract]
    public partial class ProxyCreateContact :  IEquatable<ProxyCreateContact>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyCreateContact" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ProxyCreateContact() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyCreateContact" /> class.
        /// </summary>
        /// <param name="AccountId"> The Zuora account ID associated with this contact. This field is not required when you use the subscribe() call. This field is required for all other calls. **Character limit: **32 **Values: **[a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id)  (required).</param>
        /// <param name="Address1"> The first line of the contact&#39;s address, which is often a street address or business name. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="Address2"> The second line of the contact&#39;s address. **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="City"> The city of the contact&#39;s address. **Character limit**: 40 **Values: **a string of 40 characters or fewer .</param>
        /// <param name="Country"> The country of the contact&#39;s address. If using [a valid country name or abbreviation](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes) .</param>
        /// <param name="County"> The country. May optionally be used by [Z-Tax](/C_Zuora_User_Guides/A_Billing_and_Payments/I_Taxes/Z-Tax) to calculate county tax. **Character limit**: 32 **Values**: a string of 32 characters or fewer .</param>
        /// <param name="Description"> A description for the contact. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="Fax"> The contact&#39;s fax number. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="FirstName"> The contact&#39;s first name. **Character limit**: 100 **Values**: a string of the contact&#39;s first name  (required).</param>
        /// <param name="HomePhone"> The contact&#39;s home phone number. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="LastName"> The contact&#39;s last name. **Character limit**: 100 **Values**: a string of 100 characters or fewer  (required).</param>
        /// <param name="MobilePhone"> The contact&#39;s mobile phone number. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="NickName"> A nickname for the contact. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="OtherPhone"> An additional phone number for the contact. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="OtherPhoneType">The type of the &#x60;OtherPhone&#x60;. **Character limit**: 20 **Values**: &#x60;Work&#x60;, &#x60;Mobile&#x60;, &#x60;Home&#x60;, &#x60;Other&#x60; .</param>
        /// <param name="PersonalEmail"> The contact&#39;s personal email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer .</param>
        /// <param name="PostalCode"> The zip code for the contact&#39;s address. **Character limit:** 20 **Values: **a string of 20 characters or fewer .</param>
        /// <param name="State"> The state or province of the contact&#39;s address. If using [a valid state name or abbreviation](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) .</param>
        /// <param name="TaxRegion">If using [Z-Tax](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/L_Taxes/A_Z-Tax) tax rules .</param>
        /// <param name="WorkEmail"> The contact&#39;s business email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer .</param>
        /// <param name="WorkPhone"> The contact&#39;s business phone number. **Character limit**: 40 **notes**: - - **Values**: a string of 40 characters or fewer .</param>
        public ProxyCreateContact(string AccountId = null, string Address1 = null, string Address2 = null, string City = null, string Country = null, string County = null, string Description = null, string Fax = null, string FirstName = null, string HomePhone = null, string LastName = null, string MobilePhone = null, string NickName = null, string OtherPhone = null, string OtherPhoneType = null, string PersonalEmail = null, string PostalCode = null, string State = null, string TaxRegion = null, string WorkEmail = null, string WorkPhone = null)
        {
            // to ensure "AccountId" is required (not null)
            if (AccountId == null)
            {
                throw new InvalidDataException("AccountId is a required property for ProxyCreateContact and cannot be null");
            }
            else
            {
                this.AccountId = AccountId;
            }
            // to ensure "FirstName" is required (not null)
            if (FirstName == null)
            {
                throw new InvalidDataException("FirstName is a required property for ProxyCreateContact and cannot be null");
            }
            else
            {
                this.FirstName = FirstName;
            }
            // to ensure "LastName" is required (not null)
            if (LastName == null)
            {
                throw new InvalidDataException("LastName is a required property for ProxyCreateContact and cannot be null");
            }
            else
            {
                this.LastName = LastName;
            }
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.City = City;
            this.Country = Country;
            this.County = County;
            this.Description = Description;
            this.Fax = Fax;
            this.HomePhone = HomePhone;
            this.MobilePhone = MobilePhone;
            this.NickName = NickName;
            this.OtherPhone = OtherPhone;
            this.OtherPhoneType = OtherPhoneType;
            this.PersonalEmail = PersonalEmail;
            this.PostalCode = PostalCode;
            this.State = State;
            this.TaxRegion = TaxRegion;
            this.WorkEmail = WorkEmail;
            this.WorkPhone = WorkPhone;
        }
        
        /// <summary>
        ///  The Zuora account ID associated with this contact. This field is not required when you use the subscribe() call. This field is required for all other calls. **Character limit: **32 **Values: **[a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) 
        /// </summary>
        /// <value> The Zuora account ID associated with this contact. This field is not required when you use the subscribe() call. This field is required for all other calls. **Character limit: **32 **Values: **[a valid account ID](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/E1_SOAP_API_Object_Reference/Account#Id) </value>
        [DataMember(Name="AccountId", EmitDefaultValue=false)]
        public string AccountId { get; set; }
        /// <summary>
        ///  The first line of the contact&#39;s address, which is often a street address or business name. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The first line of the contact&#39;s address, which is often a street address or business name. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="Address1", EmitDefaultValue=false)]
        public string Address1 { get; set; }
        /// <summary>
        ///  The second line of the contact&#39;s address. **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The second line of the contact&#39;s address. **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name="Address2", EmitDefaultValue=false)]
        public string Address2 { get; set; }
        /// <summary>
        ///  The city of the contact&#39;s address. **Character limit**: 40 **Values: **a string of 40 characters or fewer 
        /// </summary>
        /// <value> The city of the contact&#39;s address. **Character limit**: 40 **Values: **a string of 40 characters or fewer </value>
        [DataMember(Name="City", EmitDefaultValue=false)]
        public string City { get; set; }
        /// <summary>
        ///  The country of the contact&#39;s address. If using [a valid country name or abbreviation](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes) 
        /// </summary>
        /// <value> The country of the contact&#39;s address. If using [a valid country name or abbreviation](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes) </value>
        [DataMember(Name="Country", EmitDefaultValue=false)]
        public string Country { get; set; }
        /// <summary>
        ///  The country. May optionally be used by [Z-Tax](/C_Zuora_User_Guides/A_Billing_and_Payments/I_Taxes/Z-Tax) to calculate county tax. **Character limit**: 32 **Values**: a string of 32 characters or fewer 
        /// </summary>
        /// <value> The country. May optionally be used by [Z-Tax](/C_Zuora_User_Guides/A_Billing_and_Payments/I_Taxes/Z-Tax) to calculate county tax. **Character limit**: 32 **Values**: a string of 32 characters or fewer </value>
        [DataMember(Name="County", EmitDefaultValue=false)]
        public string County { get; set; }
        /// <summary>
        ///  A description for the contact. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value> A description for the contact. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="Description", EmitDefaultValue=false)]
        public string Description { get; set; }
        /// <summary>
        ///  The contact&#39;s fax number. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s fax number. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="Fax", EmitDefaultValue=false)]
        public string Fax { get; set; }
        /// <summary>
        ///  The contact&#39;s first name. **Character limit**: 100 **Values**: a string of the contact&#39;s first name 
        /// </summary>
        /// <value> The contact&#39;s first name. **Character limit**: 100 **Values**: a string of the contact&#39;s first name </value>
        [DataMember(Name="FirstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }
        /// <summary>
        ///  The contact&#39;s home phone number. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s home phone number. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="HomePhone", EmitDefaultValue=false)]
        public string HomePhone { get; set; }
        /// <summary>
        ///  The contact&#39;s last name. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s last name. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="LastName", EmitDefaultValue=false)]
        public string LastName { get; set; }
        /// <summary>
        ///  The contact&#39;s mobile phone number. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s mobile phone number. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="MobilePhone", EmitDefaultValue=false)]
        public string MobilePhone { get; set; }
        /// <summary>
        ///  A nickname for the contact. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value> A nickname for the contact. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name="NickName", EmitDefaultValue=false)]
        public string NickName { get; set; }
        /// <summary>
        ///  An additional phone number for the contact. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> An additional phone number for the contact. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="OtherPhone", EmitDefaultValue=false)]
        public string OtherPhone { get; set; }
        /// <summary>
        /// The type of the &#x60;OtherPhone&#x60;. **Character limit**: 20 **Values**: &#x60;Work&#x60;, &#x60;Mobile&#x60;, &#x60;Home&#x60;, &#x60;Other&#x60; 
        /// </summary>
        /// <value>The type of the &#x60;OtherPhone&#x60;. **Character limit**: 20 **Values**: &#x60;Work&#x60;, &#x60;Mobile&#x60;, &#x60;Home&#x60;, &#x60;Other&#x60; </value>
        [DataMember(Name="OtherPhoneType", EmitDefaultValue=false)]
        public string OtherPhoneType { get; set; }
        /// <summary>
        ///  The contact&#39;s personal email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s personal email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer </value>
        [DataMember(Name="PersonalEmail", EmitDefaultValue=false)]
        public string PersonalEmail { get; set; }
        /// <summary>
        ///  The zip code for the contact&#39;s address. **Character limit:** 20 **Values: **a string of 20 characters or fewer 
        /// </summary>
        /// <value> The zip code for the contact&#39;s address. **Character limit:** 20 **Values: **a string of 20 characters or fewer </value>
        [DataMember(Name="PostalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }
        /// <summary>
        ///  The state or province of the contact&#39;s address. If using [a valid state name or abbreviation](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) 
        /// </summary>
        /// <value> The state or province of the contact&#39;s address. If using [a valid state name or abbreviation](https://knowledgecenter.zuora.com/DC_Developers/SOAP_API/J_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes) </value>
        [DataMember(Name="State", EmitDefaultValue=false)]
        public string State { get; set; }
        /// <summary>
        /// If using [Z-Tax](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/L_Taxes/A_Z-Tax) tax rules 
        /// </summary>
        /// <value>If using [Z-Tax](https://knowledgecenter.zuora.com/CB_Billing/J_Billing_Operations/L_Taxes/A_Z-Tax) tax rules </value>
        [DataMember(Name="TaxRegion", EmitDefaultValue=false)]
        public string TaxRegion { get; set; }
        /// <summary>
        ///  The contact&#39;s business email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s business email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer </value>
        [DataMember(Name="WorkEmail", EmitDefaultValue=false)]
        public string WorkEmail { get; set; }
        /// <summary>
        ///  The contact&#39;s business phone number. **Character limit**: 40 **notes**: - - **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The contact&#39;s business phone number. **Character limit**: 40 **notes**: - - **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name="WorkPhone", EmitDefaultValue=false)]
        public string WorkPhone { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProxyCreateContact {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  Address1: ").Append(Address1).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  County: ").Append(County).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Fax: ").Append(Fax).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  HomePhone: ").Append(HomePhone).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  MobilePhone: ").Append(MobilePhone).Append("\n");
            sb.Append("  NickName: ").Append(NickName).Append("\n");
            sb.Append("  OtherPhone: ").Append(OtherPhone).Append("\n");
            sb.Append("  OtherPhoneType: ").Append(OtherPhoneType).Append("\n");
            sb.Append("  PersonalEmail: ").Append(PersonalEmail).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  TaxRegion: ").Append(TaxRegion).Append("\n");
            sb.Append("  WorkEmail: ").Append(WorkEmail).Append("\n");
            sb.Append("  WorkPhone: ").Append(WorkPhone).Append("\n");
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
            return this.Equals(obj as ProxyCreateContact);
        }

        /// <summary>
        /// Returns true if ProxyCreateContact instances are equal
        /// </summary>
        /// <param name="other">Instance of ProxyCreateContact to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyCreateContact other)
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
                    this.Address1 == other.Address1 ||
                    this.Address1 != null &&
                    this.Address1.Equals(other.Address1)
                ) && 
                (
                    this.Address2 == other.Address2 ||
                    this.Address2 != null &&
                    this.Address2.Equals(other.Address2)
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
                    this.County == other.County ||
                    this.County != null &&
                    this.County.Equals(other.County)
                ) && 
                (
                    this.Description == other.Description ||
                    this.Description != null &&
                    this.Description.Equals(other.Description)
                ) && 
                (
                    this.Fax == other.Fax ||
                    this.Fax != null &&
                    this.Fax.Equals(other.Fax)
                ) && 
                (
                    this.FirstName == other.FirstName ||
                    this.FirstName != null &&
                    this.FirstName.Equals(other.FirstName)
                ) && 
                (
                    this.HomePhone == other.HomePhone ||
                    this.HomePhone != null &&
                    this.HomePhone.Equals(other.HomePhone)
                ) && 
                (
                    this.LastName == other.LastName ||
                    this.LastName != null &&
                    this.LastName.Equals(other.LastName)
                ) && 
                (
                    this.MobilePhone == other.MobilePhone ||
                    this.MobilePhone != null &&
                    this.MobilePhone.Equals(other.MobilePhone)
                ) && 
                (
                    this.NickName == other.NickName ||
                    this.NickName != null &&
                    this.NickName.Equals(other.NickName)
                ) && 
                (
                    this.OtherPhone == other.OtherPhone ||
                    this.OtherPhone != null &&
                    this.OtherPhone.Equals(other.OtherPhone)
                ) && 
                (
                    this.OtherPhoneType == other.OtherPhoneType ||
                    this.OtherPhoneType != null &&
                    this.OtherPhoneType.Equals(other.OtherPhoneType)
                ) && 
                (
                    this.PersonalEmail == other.PersonalEmail ||
                    this.PersonalEmail != null &&
                    this.PersonalEmail.Equals(other.PersonalEmail)
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
                    this.TaxRegion == other.TaxRegion ||
                    this.TaxRegion != null &&
                    this.TaxRegion.Equals(other.TaxRegion)
                ) && 
                (
                    this.WorkEmail == other.WorkEmail ||
                    this.WorkEmail != null &&
                    this.WorkEmail.Equals(other.WorkEmail)
                ) && 
                (
                    this.WorkPhone == other.WorkPhone ||
                    this.WorkPhone != null &&
                    this.WorkPhone.Equals(other.WorkPhone)
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
                if (this.Address1 != null)
                    hash = hash * 59 + this.Address1.GetHashCode();
                if (this.Address2 != null)
                    hash = hash * 59 + this.Address2.GetHashCode();
                if (this.City != null)
                    hash = hash * 59 + this.City.GetHashCode();
                if (this.Country != null)
                    hash = hash * 59 + this.Country.GetHashCode();
                if (this.County != null)
                    hash = hash * 59 + this.County.GetHashCode();
                if (this.Description != null)
                    hash = hash * 59 + this.Description.GetHashCode();
                if (this.Fax != null)
                    hash = hash * 59 + this.Fax.GetHashCode();
                if (this.FirstName != null)
                    hash = hash * 59 + this.FirstName.GetHashCode();
                if (this.HomePhone != null)
                    hash = hash * 59 + this.HomePhone.GetHashCode();
                if (this.LastName != null)
                    hash = hash * 59 + this.LastName.GetHashCode();
                if (this.MobilePhone != null)
                    hash = hash * 59 + this.MobilePhone.GetHashCode();
                if (this.NickName != null)
                    hash = hash * 59 + this.NickName.GetHashCode();
                if (this.OtherPhone != null)
                    hash = hash * 59 + this.OtherPhone.GetHashCode();
                if (this.OtherPhoneType != null)
                    hash = hash * 59 + this.OtherPhoneType.GetHashCode();
                if (this.PersonalEmail != null)
                    hash = hash * 59 + this.PersonalEmail.GetHashCode();
                if (this.PostalCode != null)
                    hash = hash * 59 + this.PostalCode.GetHashCode();
                if (this.State != null)
                    hash = hash * 59 + this.State.GetHashCode();
                if (this.TaxRegion != null)
                    hash = hash * 59 + this.TaxRegion.GetHashCode();
                if (this.WorkEmail != null)
                    hash = hash * 59 + this.WorkEmail.GetHashCode();
                if (this.WorkPhone != null)
                    hash = hash * 59 + this.WorkPhone.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
