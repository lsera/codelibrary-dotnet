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
    /// POSTQuoteDocType
    /// </summary>
    [DataContract]
    public partial class POSTQuoteDocType :  IEquatable<POSTQuoteDocType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="POSTQuoteDocType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected POSTQuoteDocType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="POSTQuoteDocType" /> class.
        /// </summary>
        /// <param name="Apiuser">If not using Salesforce locale, this API Zuora user will be used to retrieve the locale from Zuora. .</param>
        /// <param name="DocumentType">Type of the document to generate: &#x60;PDF&#x60; or &#x60;DOC&#x60;.  (required).</param>
        /// <param name="Locale">Salesforce locale value to use. .</param>
        /// <param name="Password">dummy.</param>
        /// <param name="QuoteId">｜ Id of the quote。 (required).</param>
        /// <param name="Sandbox">dummy.</param>
        /// <param name="ServerUrl">SOAP URL used to login to Salesforce to get data. You can get the value with the following code in a Visualforce page: &#x60;{!$Api.Partner_Server_URL_100}&#x60;  (required).</param>
        /// <param name="SessionId">Salesforce session id used to log in to Salesforce to get data. You can get the value with the following code in a Visualforce page: *{!$Api.Session_ID}*  (required).</param>
        /// <param name="TemplateId">Id of the quote template in Zuora.  (required).</param>
        /// <param name="Token">dummy.</param>
        /// <param name="UseSFDCLocale">If using Salesforce org locale, set this to a value that is not null. .</param>
        /// <param name="Username">dummy.</param>
        /// <param name="ZquotesMajorVersion">The major version number of Zuora Quotes you are generating the quote document in. You can use a quote template with hierarchy sizes bigger than 3 if this is set to 7 or higher. .</param>
        /// <param name="ZquotesMinorVersion">The minor version number of Zuora Quotes you are generating the quote document in. .</param>
        public POSTQuoteDocType(string Apiuser = null, string DocumentType = null, string Locale = null, string Password = null, string QuoteId = null, string Sandbox = null, string ServerUrl = null, string SessionId = null, string TemplateId = null, string Token = null, string UseSFDCLocale = null, string Username = null, string ZquotesMajorVersion = null, string ZquotesMinorVersion = null)
        {
            // to ensure "DocumentType" is required (not null)
            if (DocumentType == null)
            {
                throw new InvalidDataException("DocumentType is a required property for POSTQuoteDocType and cannot be null");
            }
            else
            {
                this.DocumentType = DocumentType;
            }
            // to ensure "QuoteId" is required (not null)
            if (QuoteId == null)
            {
                throw new InvalidDataException("QuoteId is a required property for POSTQuoteDocType and cannot be null");
            }
            else
            {
                this.QuoteId = QuoteId;
            }
            // to ensure "ServerUrl" is required (not null)
            if (ServerUrl == null)
            {
                throw new InvalidDataException("ServerUrl is a required property for POSTQuoteDocType and cannot be null");
            }
            else
            {
                this.ServerUrl = ServerUrl;
            }
            // to ensure "SessionId" is required (not null)
            if (SessionId == null)
            {
                throw new InvalidDataException("SessionId is a required property for POSTQuoteDocType and cannot be null");
            }
            else
            {
                this.SessionId = SessionId;
            }
            // to ensure "TemplateId" is required (not null)
            if (TemplateId == null)
            {
                throw new InvalidDataException("TemplateId is a required property for POSTQuoteDocType and cannot be null");
            }
            else
            {
                this.TemplateId = TemplateId;
            }
            this.Apiuser = Apiuser;
            this.Locale = Locale;
            this.Password = Password;
            this.Sandbox = Sandbox;
            this.Token = Token;
            this.UseSFDCLocale = UseSFDCLocale;
            this.Username = Username;
            this.ZquotesMajorVersion = ZquotesMajorVersion;
            this.ZquotesMinorVersion = ZquotesMinorVersion;
        }
        
        /// <summary>
        /// If not using Salesforce locale, this API Zuora user will be used to retrieve the locale from Zuora. 
        /// </summary>
        /// <value>If not using Salesforce locale, this API Zuora user will be used to retrieve the locale from Zuora. </value>
        [DataMember(Name="apiuser", EmitDefaultValue=false)]
        public string Apiuser { get; set; }
        /// <summary>
        /// Type of the document to generate: &#x60;PDF&#x60; or &#x60;DOC&#x60;. 
        /// </summary>
        /// <value>Type of the document to generate: &#x60;PDF&#x60; or &#x60;DOC&#x60;. </value>
        [DataMember(Name="documentType", EmitDefaultValue=false)]
        public string DocumentType { get; set; }
        /// <summary>
        /// Salesforce locale value to use. 
        /// </summary>
        /// <value>Salesforce locale value to use. </value>
        [DataMember(Name="locale", EmitDefaultValue=false)]
        public string Locale { get; set; }
        /// <summary>
        /// dummy
        /// </summary>
        /// <value>dummy</value>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }
        /// <summary>
        /// ｜ Id of the quote。
        /// </summary>
        /// <value>｜ Id of the quote。</value>
        [DataMember(Name="quoteId", EmitDefaultValue=false)]
        public string QuoteId { get; set; }
        /// <summary>
        /// dummy
        /// </summary>
        /// <value>dummy</value>
        [DataMember(Name="sandbox", EmitDefaultValue=false)]
        public string Sandbox { get; set; }
        /// <summary>
        /// SOAP URL used to login to Salesforce to get data. You can get the value with the following code in a Visualforce page: &#x60;{!$Api.Partner_Server_URL_100}&#x60; 
        /// </summary>
        /// <value>SOAP URL used to login to Salesforce to get data. You can get the value with the following code in a Visualforce page: &#x60;{!$Api.Partner_Server_URL_100}&#x60; </value>
        [DataMember(Name="serverUrl", EmitDefaultValue=false)]
        public string ServerUrl { get; set; }
        /// <summary>
        /// Salesforce session id used to log in to Salesforce to get data. You can get the value with the following code in a Visualforce page: *{!$Api.Session_ID}* 
        /// </summary>
        /// <value>Salesforce session id used to log in to Salesforce to get data. You can get the value with the following code in a Visualforce page: *{!$Api.Session_ID}* </value>
        [DataMember(Name="sessionId", EmitDefaultValue=false)]
        public string SessionId { get; set; }
        /// <summary>
        /// Id of the quote template in Zuora. 
        /// </summary>
        /// <value>Id of the quote template in Zuora. </value>
        [DataMember(Name="templateId", EmitDefaultValue=false)]
        public string TemplateId { get; set; }
        /// <summary>
        /// dummy
        /// </summary>
        /// <value>dummy</value>
        [DataMember(Name="token", EmitDefaultValue=false)]
        public string Token { get; set; }
        /// <summary>
        /// If using Salesforce org locale, set this to a value that is not null. 
        /// </summary>
        /// <value>If using Salesforce org locale, set this to a value that is not null. </value>
        [DataMember(Name="useSFDCLocale", EmitDefaultValue=false)]
        public string UseSFDCLocale { get; set; }
        /// <summary>
        /// dummy
        /// </summary>
        /// <value>dummy</value>
        [DataMember(Name="username", EmitDefaultValue=false)]
        public string Username { get; set; }
        /// <summary>
        /// The major version number of Zuora Quotes you are generating the quote document in. You can use a quote template with hierarchy sizes bigger than 3 if this is set to 7 or higher. 
        /// </summary>
        /// <value>The major version number of Zuora Quotes you are generating the quote document in. You can use a quote template with hierarchy sizes bigger than 3 if this is set to 7 or higher. </value>
        [DataMember(Name="zquotesMajorVersion", EmitDefaultValue=false)]
        public string ZquotesMajorVersion { get; set; }
        /// <summary>
        /// The minor version number of Zuora Quotes you are generating the quote document in. 
        /// </summary>
        /// <value>The minor version number of Zuora Quotes you are generating the quote document in. </value>
        [DataMember(Name="zquotesMinorVersion", EmitDefaultValue=false)]
        public string ZquotesMinorVersion { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class POSTQuoteDocType {\n");
            sb.Append("  Apiuser: ").Append(Apiuser).Append("\n");
            sb.Append("  DocumentType: ").Append(DocumentType).Append("\n");
            sb.Append("  Locale: ").Append(Locale).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  QuoteId: ").Append(QuoteId).Append("\n");
            sb.Append("  Sandbox: ").Append(Sandbox).Append("\n");
            sb.Append("  ServerUrl: ").Append(ServerUrl).Append("\n");
            sb.Append("  SessionId: ").Append(SessionId).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  Token: ").Append(Token).Append("\n");
            sb.Append("  UseSFDCLocale: ").Append(UseSFDCLocale).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  ZquotesMajorVersion: ").Append(ZquotesMajorVersion).Append("\n");
            sb.Append("  ZquotesMinorVersion: ").Append(ZquotesMinorVersion).Append("\n");
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
            return this.Equals(obj as POSTQuoteDocType);
        }

        /// <summary>
        /// Returns true if POSTQuoteDocType instances are equal
        /// </summary>
        /// <param name="other">Instance of POSTQuoteDocType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(POSTQuoteDocType other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Apiuser == other.Apiuser ||
                    this.Apiuser != null &&
                    this.Apiuser.Equals(other.Apiuser)
                ) && 
                (
                    this.DocumentType == other.DocumentType ||
                    this.DocumentType != null &&
                    this.DocumentType.Equals(other.DocumentType)
                ) && 
                (
                    this.Locale == other.Locale ||
                    this.Locale != null &&
                    this.Locale.Equals(other.Locale)
                ) && 
                (
                    this.Password == other.Password ||
                    this.Password != null &&
                    this.Password.Equals(other.Password)
                ) && 
                (
                    this.QuoteId == other.QuoteId ||
                    this.QuoteId != null &&
                    this.QuoteId.Equals(other.QuoteId)
                ) && 
                (
                    this.Sandbox == other.Sandbox ||
                    this.Sandbox != null &&
                    this.Sandbox.Equals(other.Sandbox)
                ) && 
                (
                    this.ServerUrl == other.ServerUrl ||
                    this.ServerUrl != null &&
                    this.ServerUrl.Equals(other.ServerUrl)
                ) && 
                (
                    this.SessionId == other.SessionId ||
                    this.SessionId != null &&
                    this.SessionId.Equals(other.SessionId)
                ) && 
                (
                    this.TemplateId == other.TemplateId ||
                    this.TemplateId != null &&
                    this.TemplateId.Equals(other.TemplateId)
                ) && 
                (
                    this.Token == other.Token ||
                    this.Token != null &&
                    this.Token.Equals(other.Token)
                ) && 
                (
                    this.UseSFDCLocale == other.UseSFDCLocale ||
                    this.UseSFDCLocale != null &&
                    this.UseSFDCLocale.Equals(other.UseSFDCLocale)
                ) && 
                (
                    this.Username == other.Username ||
                    this.Username != null &&
                    this.Username.Equals(other.Username)
                ) && 
                (
                    this.ZquotesMajorVersion == other.ZquotesMajorVersion ||
                    this.ZquotesMajorVersion != null &&
                    this.ZquotesMajorVersion.Equals(other.ZquotesMajorVersion)
                ) && 
                (
                    this.ZquotesMinorVersion == other.ZquotesMinorVersion ||
                    this.ZquotesMinorVersion != null &&
                    this.ZquotesMinorVersion.Equals(other.ZquotesMinorVersion)
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
                if (this.Apiuser != null)
                    hash = hash * 59 + this.Apiuser.GetHashCode();
                if (this.DocumentType != null)
                    hash = hash * 59 + this.DocumentType.GetHashCode();
                if (this.Locale != null)
                    hash = hash * 59 + this.Locale.GetHashCode();
                if (this.Password != null)
                    hash = hash * 59 + this.Password.GetHashCode();
                if (this.QuoteId != null)
                    hash = hash * 59 + this.QuoteId.GetHashCode();
                if (this.Sandbox != null)
                    hash = hash * 59 + this.Sandbox.GetHashCode();
                if (this.ServerUrl != null)
                    hash = hash * 59 + this.ServerUrl.GetHashCode();
                if (this.SessionId != null)
                    hash = hash * 59 + this.SessionId.GetHashCode();
                if (this.TemplateId != null)
                    hash = hash * 59 + this.TemplateId.GetHashCode();
                if (this.Token != null)
                    hash = hash * 59 + this.Token.GetHashCode();
                if (this.UseSFDCLocale != null)
                    hash = hash * 59 + this.UseSFDCLocale.GetHashCode();
                if (this.Username != null)
                    hash = hash * 59 + this.Username.GetHashCode();
                if (this.ZquotesMajorVersion != null)
                    hash = hash * 59 + this.ZquotesMajorVersion.GetHashCode();
                if (this.ZquotesMinorVersion != null)
                    hash = hash * 59 + this.ZquotesMinorVersion.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
