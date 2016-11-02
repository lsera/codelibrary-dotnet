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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISummaryJournalEntriesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete summary journal entry
        /// </summary>
        /// <remarks>
        /// This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType DELETESummaryJournalEntry (string jeNumber);

        /// <summary>
        /// Delete summary journal entry
        /// </summary>
        /// <remarks>
        /// This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> DELETESummaryJournalEntryWithHttpInfo (string jeNumber);
        /// <summary>
        /// Get all summary journal entries in a journal run
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>GETJournalEntriesInJournalRunType</returns>
        GETJournalEntriesInJournalRunType GETJournalEntriesInJournalRun (string jrNumber);

        /// <summary>
        /// Get all summary journal entries in a journal run
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>ApiResponse of GETJournalEntriesInJournalRunType</returns>
        ApiResponse<GETJournalEntriesInJournalRunType> GETJournalEntriesInJournalRunWithHttpInfo (string jrNumber);
        /// <summary>
        /// Get summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>GETJournalEntryDetailType</returns>
        GETJournalEntryDetailType GETJournalEntryDetail (string jeNumber);

        /// <summary>
        /// Get summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>ApiResponse of GETJournalEntryDetailType</returns>
        ApiResponse<GETJournalEntryDetailType> GETJournalEntryDetailWithHttpInfo (string jeNumber);
        /// <summary>
        /// Create summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTJournalEntryResponseType</returns>
        POSTJournalEntryResponseType POSTJournalEntry (POSTJournalEntryType request);

        /// <summary>
        /// Create summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTJournalEntryResponseType</returns>
        ApiResponse<POSTJournalEntryResponseType> POSTJournalEntryWithHttpInfo (POSTJournalEntryType request);
        /// <summary>
        /// Update basic information of a summary journal entry
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTBasicSummaryJournalEntry (string jeNumber, PUTBasicSummaryJournalEntryType request);

        /// <summary>
        /// Update basic information of a summary journal entry
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTBasicSummaryJournalEntryWithHttpInfo (string jeNumber, PUTBasicSummaryJournalEntryType request);
        /// <summary>
        /// Cancel summary journal entry
        /// </summary>
        /// <remarks>
        ///  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTSummaryJournalEntry (string jeNumber);

        /// <summary>
        /// Cancel summary journal entry
        /// </summary>
        /// <remarks>
        ///  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTSummaryJournalEntryWithHttpInfo (string jeNumber);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Delete summary journal entry
        /// </summary>
        /// <remarks>
        /// This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> DELETESummaryJournalEntryAsync (string jeNumber);

        /// <summary>
        /// Delete summary journal entry
        /// </summary>
        /// <remarks>
        /// This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETESummaryJournalEntryAsyncWithHttpInfo (string jeNumber);
        /// <summary>
        /// Get all summary journal entries in a journal run
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>Task of GETJournalEntriesInJournalRunType</returns>
        System.Threading.Tasks.Task<GETJournalEntriesInJournalRunType> GETJournalEntriesInJournalRunAsync (string jrNumber);

        /// <summary>
        /// Get all summary journal entries in a journal run
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>Task of ApiResponse (GETJournalEntriesInJournalRunType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETJournalEntriesInJournalRunType>> GETJournalEntriesInJournalRunAsyncWithHttpInfo (string jrNumber);
        /// <summary>
        /// Get summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>Task of GETJournalEntryDetailType</returns>
        System.Threading.Tasks.Task<GETJournalEntryDetailType> GETJournalEntryDetailAsync (string jeNumber);

        /// <summary>
        /// Get summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>Task of ApiResponse (GETJournalEntryDetailType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETJournalEntryDetailType>> GETJournalEntryDetailAsyncWithHttpInfo (string jeNumber);
        /// <summary>
        /// Create summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTJournalEntryResponseType</returns>
        System.Threading.Tasks.Task<POSTJournalEntryResponseType> POSTJournalEntryAsync (POSTJournalEntryType request);

        /// <summary>
        /// Create summary journal entry
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTJournalEntryResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTJournalEntryResponseType>> POSTJournalEntryAsyncWithHttpInfo (POSTJournalEntryType request);
        /// <summary>
        /// Update basic information of a summary journal entry
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTBasicSummaryJournalEntryAsync (string jeNumber, PUTBasicSummaryJournalEntryType request);

        /// <summary>
        /// Update basic information of a summary journal entry
        /// </summary>
        /// <remarks>
        ///  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTBasicSummaryJournalEntryAsyncWithHttpInfo (string jeNumber, PUTBasicSummaryJournalEntryType request);
        /// <summary>
        /// Cancel summary journal entry
        /// </summary>
        /// <remarks>
        ///  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTSummaryJournalEntryAsync (string jeNumber);

        /// <summary>
        /// Cancel summary journal entry
        /// </summary>
        /// <remarks>
        ///  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTSummaryJournalEntryAsyncWithHttpInfo (string jeNumber);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class SummaryJournalEntriesApi : ISummaryJournalEntriesApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryJournalEntriesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public SummaryJournalEntriesApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryJournalEntriesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public SummaryJournalEntriesApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Delete summary journal entry This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType DELETESummaryJournalEntry (string jeNumber)
        {
             ApiResponse<CommonResponseType> localVarResponse = DELETESummaryJournalEntryWithHttpInfo(jeNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete summary journal entry This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > DELETESummaryJournalEntryWithHttpInfo (string jeNumber)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->DELETESummaryJournalEntry");

            var localVarPath = "/journal-entries/{je-number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETESummaryJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Delete summary journal entry This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> DELETESummaryJournalEntryAsync (string jeNumber)
        {
             ApiResponse<CommonResponseType> localVarResponse = await DELETESummaryJournalEntryAsyncWithHttpInfo(jeNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete summary journal entry This reference describes how to delete a summary journal entry using the REST API.  You must have the \&quot;Delete Cancelled Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to delete summary journal entries.  A summary journal entry must be canceled before it can be deleted. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETESummaryJournalEntryAsyncWithHttpInfo (string jeNumber)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->DELETESummaryJournalEntry");

            var localVarPath = "/journal-entries/{je-number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETESummaryJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Get all summary journal entries in a journal run  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>GETJournalEntriesInJournalRunType</returns>
        public GETJournalEntriesInJournalRunType GETJournalEntriesInJournalRun (string jrNumber)
        {
             ApiResponse<GETJournalEntriesInJournalRunType> localVarResponse = GETJournalEntriesInJournalRunWithHttpInfo(jrNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get all summary journal entries in a journal run  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>ApiResponse of GETJournalEntriesInJournalRunType</returns>
        public ApiResponse< GETJournalEntriesInJournalRunType > GETJournalEntriesInJournalRunWithHttpInfo (string jrNumber)
        {
            // verify the required parameter 'jrNumber' is set
            if (jrNumber == null)
                throw new ApiException(400, "Missing required parameter 'jrNumber' when calling SummaryJournalEntriesApi->GETJournalEntriesInJournalRun");

            var localVarPath = "/journal-entries/journal-runs/{jr-number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jrNumber != null) localVarPathParams.Add("jr-number", Configuration.ApiClient.ParameterToString(jrNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETJournalEntriesInJournalRun", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETJournalEntriesInJournalRunType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETJournalEntriesInJournalRunType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETJournalEntriesInJournalRunType)));
            
        }

        /// <summary>
        /// Get all summary journal entries in a journal run  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>Task of GETJournalEntriesInJournalRunType</returns>
        public async System.Threading.Tasks.Task<GETJournalEntriesInJournalRunType> GETJournalEntriesInJournalRunAsync (string jrNumber)
        {
             ApiResponse<GETJournalEntriesInJournalRunType> localVarResponse = await GETJournalEntriesInJournalRunAsyncWithHttpInfo(jrNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get all summary journal entries in a journal run  This REST API reference describes how to retrieve information about all summary journal entries in a journal run. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jrNumber">Journal run number.</param>
        /// <returns>Task of ApiResponse (GETJournalEntriesInJournalRunType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETJournalEntriesInJournalRunType>> GETJournalEntriesInJournalRunAsyncWithHttpInfo (string jrNumber)
        {
            // verify the required parameter 'jrNumber' is set
            if (jrNumber == null)
                throw new ApiException(400, "Missing required parameter 'jrNumber' when calling SummaryJournalEntriesApi->GETJournalEntriesInJournalRun");

            var localVarPath = "/journal-entries/journal-runs/{jr-number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jrNumber != null) localVarPathParams.Add("jr-number", Configuration.ApiClient.ParameterToString(jrNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETJournalEntriesInJournalRun", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETJournalEntriesInJournalRunType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETJournalEntriesInJournalRunType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETJournalEntriesInJournalRunType)));
            
        }

        /// <summary>
        /// Get summary journal entry This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>GETJournalEntryDetailType</returns>
        public GETJournalEntryDetailType GETJournalEntryDetail (string jeNumber)
        {
             ApiResponse<GETJournalEntryDetailType> localVarResponse = GETJournalEntryDetailWithHttpInfo(jeNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get summary journal entry This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>ApiResponse of GETJournalEntryDetailType</returns>
        public ApiResponse< GETJournalEntryDetailType > GETJournalEntryDetailWithHttpInfo (string jeNumber)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->GETJournalEntryDetail");

            var localVarPath = "/journal-entries/{je-number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETJournalEntryDetail", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETJournalEntryDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETJournalEntryDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETJournalEntryDetailType)));
            
        }

        /// <summary>
        /// Get summary journal entry This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>Task of GETJournalEntryDetailType</returns>
        public async System.Threading.Tasks.Task<GETJournalEntryDetailType> GETJournalEntryDetailAsync (string jeNumber)
        {
             ApiResponse<GETJournalEntryDetailType> localVarResponse = await GETJournalEntryDetailAsyncWithHttpInfo(jeNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get summary journal entry This REST API reference describes how to get information about a summary journal entry by its journal entry number. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber"></param>
        /// <returns>Task of ApiResponse (GETJournalEntryDetailType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETJournalEntryDetailType>> GETJournalEntryDetailAsyncWithHttpInfo (string jeNumber)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->GETJournalEntryDetail");

            var localVarPath = "/journal-entries/{je-number}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETJournalEntryDetail", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETJournalEntryDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETJournalEntryDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETJournalEntryDetailType)));
            
        }

        /// <summary>
        /// Create summary journal entry This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTJournalEntryResponseType</returns>
        public POSTJournalEntryResponseType POSTJournalEntry (POSTJournalEntryType request)
        {
             ApiResponse<POSTJournalEntryResponseType> localVarResponse = POSTJournalEntryWithHttpInfo(request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create summary journal entry This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTJournalEntryResponseType</returns>
        public ApiResponse< POSTJournalEntryResponseType > POSTJournalEntryWithHttpInfo (POSTJournalEntryType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SummaryJournalEntriesApi->POSTJournalEntry");

            var localVarPath = "/journal-entries";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTJournalEntryResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTJournalEntryResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTJournalEntryResponseType)));
            
        }

        /// <summary>
        /// Create summary journal entry This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTJournalEntryResponseType</returns>
        public async System.Threading.Tasks.Task<POSTJournalEntryResponseType> POSTJournalEntryAsync (POSTJournalEntryType request)
        {
             ApiResponse<POSTJournalEntryResponseType> localVarResponse = await POSTJournalEntryAsyncWithHttpInfo(request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create summary journal entry This REST API reference describes how to manually create a summary journal entry. Request and response field descriptions and sample code are provided. ## Requirements 1.The sum of debits must equal the sum of credits in the summary journal entry.  2.The following applies only if you use foreign currency conversion:   * If you have configured [Aggregate transactions with different currencies during a Journal Run](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/C_Configure_accounting_rules#Aggregate_transactions_with_different_currencies_during_a_Journal_Run) to \&quot;Yes\&quot;, the value of the **currency** field must be the same as your tenant&#39;s home currency. That is, you must create journal entries using your home currency.   * All journal entries in an accounting period must either all be aggregated or all be unaggregated. You cannot have a mix of aggregated and unaggregated journal entries in the same accounting period.  See [Foreign Currency Conversion for Summary Journal Entries](https://knowledgecenter.zuora.com/CC_Finance/Foreign_Currency_Conversion/Foreign_Currency_Conversion_for_Summary_Journal_Entries) for more information about currency aggregation. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTJournalEntryResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTJournalEntryResponseType>> POSTJournalEntryAsyncWithHttpInfo (POSTJournalEntryType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SummaryJournalEntriesApi->POSTJournalEntry");

            var localVarPath = "/journal-entries";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("POSTJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTJournalEntryResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTJournalEntryResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTJournalEntryResponseType)));
            
        }

        /// <summary>
        /// Update basic information of a summary journal entry  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTBasicSummaryJournalEntry (string jeNumber, PUTBasicSummaryJournalEntryType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTBasicSummaryJournalEntryWithHttpInfo(jeNumber, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update basic information of a summary journal entry  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTBasicSummaryJournalEntryWithHttpInfo (string jeNumber, PUTBasicSummaryJournalEntryType request)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->PUTBasicSummaryJournalEntry");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SummaryJournalEntriesApi->PUTBasicSummaryJournalEntry");

            var localVarPath = "/journal-entries/{je-number}/basic-information";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTBasicSummaryJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Update basic information of a summary journal entry  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTBasicSummaryJournalEntryAsync (string jeNumber, PUTBasicSummaryJournalEntryType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTBasicSummaryJournalEntryAsyncWithHttpInfo(jeNumber, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update basic information of a summary journal entry  This REST API reference describes how to update the basic information of a summary journal entry. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTBasicSummaryJournalEntryAsyncWithHttpInfo (string jeNumber, PUTBasicSummaryJournalEntryType request)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->PUTBasicSummaryJournalEntry");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling SummaryJournalEntriesApi->PUTBasicSummaryJournalEntry");

            var localVarPath = "/journal-entries/{je-number}/basic-information";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter
            if (request != null && request.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(request); // http body (model) parameter
            }
            else
            {
                localVarPostBody = request; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTBasicSummaryJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Cancel summary journal entry  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTSummaryJournalEntry (string jeNumber)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTSummaryJournalEntryWithHttpInfo(jeNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Cancel summary journal entry  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTSummaryJournalEntryWithHttpInfo (string jeNumber)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->PUTSummaryJournalEntry");

            var localVarPath = "/journal-entries/{je-number}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSummaryJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Cancel summary journal entry  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTSummaryJournalEntryAsync (string jeNumber)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTSummaryJournalEntryAsyncWithHttpInfo(jeNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Cancel summary journal entry  This reference describes how to cancel a summary journal entry using the REST API.  You must have the \&quot;Cancel Journal Entry\&quot; [Z-Finance user permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles) enabled to cancel summary journal entries.  A summary journal entry cannot be canceled if its Transferred to Accounting status is \&quot;Yes\&quot; or \&quot;Processing\&quot;. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="jeNumber">Journal entry number in the format JE-00000001.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTSummaryJournalEntryAsyncWithHttpInfo (string jeNumber)
        {
            // verify the required parameter 'jeNumber' is set
            if (jeNumber == null)
                throw new ApiException(400, "Missing required parameter 'jeNumber' when calling SummaryJournalEntriesApi->PUTSummaryJournalEntry");

            var localVarPath = "/journal-entries/{je-number}/cancel";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (jeNumber != null) localVarPathParams.Add("je-number", Configuration.ApiClient.ParameterToString(jeNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTSummaryJournalEntry", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

    }
}
