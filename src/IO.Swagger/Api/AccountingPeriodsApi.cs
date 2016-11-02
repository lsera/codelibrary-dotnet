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
    public interface IAccountingPeriodsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete accounting period
        /// </summary>
        /// <remarks>
        ///  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType DELETEAccountingPeriod (string apId);

        /// <summary>
        /// Delete accounting period
        /// </summary>
        /// <remarks>
        ///  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> DELETEAccountingPeriodWithHttpInfo (string apId);
        /// <summary>
        /// Get accounting period
        /// </summary>
        /// <remarks>
        /// Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>GETAccountingPeriodType</returns>
        GETAccountingPeriodType GETAccountingPeriod (string apId);

        /// <summary>
        /// Get accounting period
        /// </summary>
        /// <remarks>
        /// Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>ApiResponse of GETAccountingPeriodType</returns>
        ApiResponse<GETAccountingPeriodType> GETAccountingPeriodWithHttpInfo (string apId);
        /// <summary>
        /// Get all accounting periods
        /// </summary>
        /// <remarks>
        /// Retrieves all accounting periods on your tenant.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>GETAccountingPeriodsType</returns>
        GETAccountingPeriodsType GETAccountingPeriods ();

        /// <summary>
        /// Get all accounting periods
        /// </summary>
        /// <remarks>
        /// Retrieves all accounting periods on your tenant.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of GETAccountingPeriodsType</returns>
        ApiResponse<GETAccountingPeriodsType> GETAccountingPeriodsWithHttpInfo ();
        /// <summary>
        /// Create accounting period
        /// </summary>
        /// <remarks>
        /// Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTAccountingPeriodResponseType</returns>
        POSTAccountingPeriodResponseType POSTAccountingPeriod (POSTAccountingPeriodType request);

        /// <summary>
        /// Create accounting period
        /// </summary>
        /// <remarks>
        /// Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTAccountingPeriodResponseType</returns>
        ApiResponse<POSTAccountingPeriodResponseType> POSTAccountingPeriodWithHttpInfo (POSTAccountingPeriodType request);
        /// <summary>
        /// Close accounting period
        /// </summary>
        /// <remarks>
        /// Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTCloseAccountingPeriod (string apId);

        /// <summary>
        /// Close accounting period
        /// </summary>
        /// <remarks>
        /// Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTCloseAccountingPeriodWithHttpInfo (string apId);
        /// <summary>
        /// Set accounting period to pending close
        /// </summary>
        /// <remarks>
        /// Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTPendingCloseAccountingPeriod (string apId);

        /// <summary>
        /// Set accounting period to pending close
        /// </summary>
        /// <remarks>
        /// Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTPendingCloseAccountingPeriodWithHttpInfo (string apId);
        /// <summary>
        /// Re-open accounting period
        /// </summary>
        /// <remarks>
        /// Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTReopenAccountingPeriod (string apId);

        /// <summary>
        /// Re-open accounting period
        /// </summary>
        /// <remarks>
        /// Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTReopenAccountingPeriodWithHttpInfo (string apId);
        /// <summary>
        /// Run trial balance
        /// </summary>
        /// <remarks>
        /// Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTRunTrialBalance (string apId);

        /// <summary>
        /// Run trial balance
        /// </summary>
        /// <remarks>
        /// Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTRunTrialBalanceWithHttpInfo (string apId);
        /// <summary>
        /// Update accounting period
        /// </summary>
        /// <remarks>
        ///  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTUpdateAccountingPeriod (string apId, PUTAccountingPeriodType request);

        /// <summary>
        /// Update accounting period
        /// </summary>
        /// <remarks>
        ///  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTUpdateAccountingPeriodWithHttpInfo (string apId, PUTAccountingPeriodType request);
        /// <summary>
        /// CRUD: Delete AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ProxyDeleteResponse</returns>
        ProxyDeleteResponse ProxyDELETEAccountingPeriod (string id);

        /// <summary>
        /// CRUD: Delete AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ApiResponse of ProxyDeleteResponse</returns>
        ApiResponse<ProxyDeleteResponse> ProxyDELETEAccountingPeriodWithHttpInfo (string id);
        /// <summary>
        /// CRUD: Retrieve AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ProxyGetAccountingPeriod</returns>
        ProxyGetAccountingPeriod ProxyGETAccountingPeriod (string id, string fields = null);

        /// <summary>
        /// CRUD: Retrieve AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ApiResponse of ProxyGetAccountingPeriod</returns>
        ApiResponse<ProxyGetAccountingPeriod> ProxyGETAccountingPeriodWithHttpInfo (string id, string fields = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Delete accounting period
        /// </summary>
        /// <remarks>
        ///  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> DELETEAccountingPeriodAsync (string apId);

        /// <summary>
        /// Delete accounting period
        /// </summary>
        /// <remarks>
        ///  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETEAccountingPeriodAsyncWithHttpInfo (string apId);
        /// <summary>
        /// Get accounting period
        /// </summary>
        /// <remarks>
        /// Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>Task of GETAccountingPeriodType</returns>
        System.Threading.Tasks.Task<GETAccountingPeriodType> GETAccountingPeriodAsync (string apId);

        /// <summary>
        /// Get accounting period
        /// </summary>
        /// <remarks>
        /// Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>Task of ApiResponse (GETAccountingPeriodType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETAccountingPeriodType>> GETAccountingPeriodAsyncWithHttpInfo (string apId);
        /// <summary>
        /// Get all accounting periods
        /// </summary>
        /// <remarks>
        /// Retrieves all accounting periods on your tenant.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of GETAccountingPeriodsType</returns>
        System.Threading.Tasks.Task<GETAccountingPeriodsType> GETAccountingPeriodsAsync ();

        /// <summary>
        /// Get all accounting periods
        /// </summary>
        /// <remarks>
        /// Retrieves all accounting periods on your tenant.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (GETAccountingPeriodsType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETAccountingPeriodsType>> GETAccountingPeriodsAsyncWithHttpInfo ();
        /// <summary>
        /// Create accounting period
        /// </summary>
        /// <remarks>
        /// Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTAccountingPeriodResponseType</returns>
        System.Threading.Tasks.Task<POSTAccountingPeriodResponseType> POSTAccountingPeriodAsync (POSTAccountingPeriodType request);

        /// <summary>
        /// Create accounting period
        /// </summary>
        /// <remarks>
        /// Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTAccountingPeriodResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTAccountingPeriodResponseType>> POSTAccountingPeriodAsyncWithHttpInfo (POSTAccountingPeriodType request);
        /// <summary>
        /// Close accounting period
        /// </summary>
        /// <remarks>
        /// Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTCloseAccountingPeriodAsync (string apId);

        /// <summary>
        /// Close accounting period
        /// </summary>
        /// <remarks>
        /// Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTCloseAccountingPeriodAsyncWithHttpInfo (string apId);
        /// <summary>
        /// Set accounting period to pending close
        /// </summary>
        /// <remarks>
        /// Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTPendingCloseAccountingPeriodAsync (string apId);

        /// <summary>
        /// Set accounting period to pending close
        /// </summary>
        /// <remarks>
        /// Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTPendingCloseAccountingPeriodAsyncWithHttpInfo (string apId);
        /// <summary>
        /// Re-open accounting period
        /// </summary>
        /// <remarks>
        /// Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTReopenAccountingPeriodAsync (string apId);

        /// <summary>
        /// Re-open accounting period
        /// </summary>
        /// <remarks>
        /// Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTReopenAccountingPeriodAsyncWithHttpInfo (string apId);
        /// <summary>
        /// Run trial balance
        /// </summary>
        /// <remarks>
        /// Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTRunTrialBalanceAsync (string apId);

        /// <summary>
        /// Run trial balance
        /// </summary>
        /// <remarks>
        /// Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTRunTrialBalanceAsyncWithHttpInfo (string apId);
        /// <summary>
        /// Update accounting period
        /// </summary>
        /// <remarks>
        ///  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTUpdateAccountingPeriodAsync (string apId, PUTAccountingPeriodType request);

        /// <summary>
        /// Update accounting period
        /// </summary>
        /// <remarks>
        ///  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTUpdateAccountingPeriodAsyncWithHttpInfo (string apId, PUTAccountingPeriodType request);
        /// <summary>
        /// CRUD: Delete AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ProxyDeleteResponse</returns>
        System.Threading.Tasks.Task<ProxyDeleteResponse> ProxyDELETEAccountingPeriodAsync (string id);

        /// <summary>
        /// CRUD: Delete AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ApiResponse (ProxyDeleteResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyDeleteResponse>> ProxyDELETEAccountingPeriodAsyncWithHttpInfo (string id);
        /// <summary>
        /// CRUD: Retrieve AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ProxyGetAccountingPeriod</returns>
        System.Threading.Tasks.Task<ProxyGetAccountingPeriod> ProxyGETAccountingPeriodAsync (string id, string fields = null);

        /// <summary>
        /// CRUD: Retrieve AccountingPeriod
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ApiResponse (ProxyGetAccountingPeriod)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyGetAccountingPeriod>> ProxyGETAccountingPeriodAsyncWithHttpInfo (string id, string fields = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AccountingPeriodsApi : IAccountingPeriodsApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingPeriodsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccountingPeriodsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="AccountingPeriodsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AccountingPeriodsApi(Configuration configuration = null)
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
        /// Delete accounting period  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType DELETEAccountingPeriod (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = DELETEAccountingPeriodWithHttpInfo(apId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete accounting period  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > DELETEAccountingPeriodWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->DELETEAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETEAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Delete accounting period  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> DELETEAccountingPeriodAsync (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await DELETEAccountingPeriodAsyncWithHttpInfo(apId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete accounting period  Deletes an accounting period.  Prerequisites - -- -- -- -- -- --   * You must have Zuora Finance enabled on your tenant.   * You must have the Delete Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).   Limitations - -- -- -- -- --  The accounting period to be deleted:  * Must be the most recent accounting period  * Must be an open accounting period  * Must have no revenue distributed into it  * Must not have any active journal entries  * Must not be the open-ended accounting period  * Must not be in the process of running a trial balance 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to delete.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETEAccountingPeriodAsyncWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->DELETEAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETEAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Get accounting period Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>GETAccountingPeriodType</returns>
        public GETAccountingPeriodType GETAccountingPeriod (string apId)
        {
             ApiResponse<GETAccountingPeriodType> localVarResponse = GETAccountingPeriodWithHttpInfo(apId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get accounting period Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>ApiResponse of GETAccountingPeriodType</returns>
        public ApiResponse< GETAccountingPeriodType > GETAccountingPeriodWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->GETAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingPeriodType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingPeriodType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingPeriodType)));
            
        }

        /// <summary>
        /// Get accounting period Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>Task of GETAccountingPeriodType</returns>
        public async System.Threading.Tasks.Task<GETAccountingPeriodType> GETAccountingPeriodAsync (string apId)
        {
             ApiResponse<GETAccountingPeriodType> localVarResponse = await GETAccountingPeriodAsyncWithHttpInfo(apId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get accounting period Retrieves an accounting period. Prerequisites - -- -- -- -- -- --  You must have Zuora Finance enabled on your tenant. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to get.</param>
        /// <returns>Task of ApiResponse (GETAccountingPeriodType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETAccountingPeriodType>> GETAccountingPeriodAsyncWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->GETAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingPeriodType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingPeriodType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingPeriodType)));
            
        }

        /// <summary>
        /// Get all accounting periods Retrieves all accounting periods on your tenant.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>GETAccountingPeriodsType</returns>
        public GETAccountingPeriodsType GETAccountingPeriods ()
        {
             ApiResponse<GETAccountingPeriodsType> localVarResponse = GETAccountingPeriodsWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get all accounting periods Retrieves all accounting periods on your tenant.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of GETAccountingPeriodsType</returns>
        public ApiResponse< GETAccountingPeriodsType > GETAccountingPeriodsWithHttpInfo ()
        {

            var localVarPath = "/accounting-periods";
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


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETAccountingPeriods", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingPeriodsType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingPeriodsType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingPeriodsType)));
            
        }

        /// <summary>
        /// Get all accounting periods Retrieves all accounting periods on your tenant.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of GETAccountingPeriodsType</returns>
        public async System.Threading.Tasks.Task<GETAccountingPeriodsType> GETAccountingPeriodsAsync ()
        {
             ApiResponse<GETAccountingPeriodsType> localVarResponse = await GETAccountingPeriodsAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get all accounting periods Retrieves all accounting periods on your tenant.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (GETAccountingPeriodsType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETAccountingPeriodsType>> GETAccountingPeriodsAsyncWithHttpInfo ()
        {

            var localVarPath = "/accounting-periods";
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


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETAccountingPeriods", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingPeriodsType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingPeriodsType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingPeriodsType)));
            
        }

        /// <summary>
        /// Create accounting period Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTAccountingPeriodResponseType</returns>
        public POSTAccountingPeriodResponseType POSTAccountingPeriod (POSTAccountingPeriodType request)
        {
             ApiResponse<POSTAccountingPeriodResponseType> localVarResponse = POSTAccountingPeriodWithHttpInfo(request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create accounting period Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTAccountingPeriodResponseType</returns>
        public ApiResponse< POSTAccountingPeriodResponseType > POSTAccountingPeriodWithHttpInfo (POSTAccountingPeriodType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingPeriodsApi->POSTAccountingPeriod");

            var localVarPath = "/accounting-periods";
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
                Exception exception = ExceptionFactory("POSTAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTAccountingPeriodResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTAccountingPeriodResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTAccountingPeriodResponseType)));
            
        }

        /// <summary>
        /// Create accounting period Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTAccountingPeriodResponseType</returns>
        public async System.Threading.Tasks.Task<POSTAccountingPeriodResponseType> POSTAccountingPeriodAsync (POSTAccountingPeriodType request)
        {
             ApiResponse<POSTAccountingPeriodResponseType> localVarResponse = await POSTAccountingPeriodAsyncWithHttpInfo(request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create accounting period Creates an accounting period. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/Z-Finance_Roles).  Limitations - -- -- -- -- -- * When creating the first accounting period on your tenant, the start date must be equal to or earlier than the date of the earliest transaction on the tenant. * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1. * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTAccountingPeriodResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTAccountingPeriodResponseType>> POSTAccountingPeriodAsyncWithHttpInfo (POSTAccountingPeriodType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingPeriodsApi->POSTAccountingPeriod");

            var localVarPath = "/accounting-periods";
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
                Exception exception = ExceptionFactory("POSTAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTAccountingPeriodResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTAccountingPeriodResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTAccountingPeriodResponseType)));
            
        }

        /// <summary>
        /// Close accounting period Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTCloseAccountingPeriod (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTCloseAccountingPeriodWithHttpInfo(apId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Close accounting period Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTCloseAccountingPeriodWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTCloseAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}/close";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTCloseAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Close accounting period Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTCloseAccountingPeriodAsync (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTCloseAccountingPeriodAsyncWithHttpInfo(apId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Close accounting period Close an [accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods) by accounting period ID.  Prerequisites - -- -- -- -- -- -- You must have Zuora Finance enabled on your tenant. You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). Limitations - -- -- -- -- -- * The accounting period cannot already be closed. * The accounting period cannot be in the process of running a trial balance. * All earlier accounting periods must be closed. * There must be no required action items for the accounting period. See [Reconcile Transactions Before Closing an Accounting Period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/G_Reconcile_transactions_before_closing_an_accounting_period) for more information.  Notes - -- -- When you close an accounting period in Zuora, a trial balance is automatically run for that period. A successful response means only that the accounting period is now closed, but does not mean that the trial balance has successfully completed.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to close.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTCloseAccountingPeriodAsyncWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTCloseAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}/close";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTCloseAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Set accounting period to pending close Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTPendingCloseAccountingPeriod (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTPendingCloseAccountingPeriodWithHttpInfo(apId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Set accounting period to pending close Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTPendingCloseAccountingPeriodWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTPendingCloseAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}/pending-close";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTPendingCloseAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Set accounting period to pending close Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTPendingCloseAccountingPeriodAsync (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTPendingCloseAccountingPeriodAsyncWithHttpInfo(apId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Set accounting period to pending close Sets an accounting period to pending close.   Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).              Limitations   - -- -- -- -- --    * The accounting period cannot be closed or pending close.    * The accounting period cannot be in the process of running a trial balance.    * All earlier accounting periods must be closed.     Notes - -- -- When you set an accounting period to pending close in Zuora, a trial balance is automatically run for that period. A response of &#x60;{ \&quot;success\&quot;: true }&#x60;  means only that the accounting period status is now pending close, but does not mean that the trial balance has successfully completed. You can use the Get Accounting Period REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to set to pending close.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTPendingCloseAccountingPeriodAsyncWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTPendingCloseAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}/pending-close";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTPendingCloseAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Re-open accounting period Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTReopenAccountingPeriod (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTReopenAccountingPeriodWithHttpInfo(apId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Re-open accounting period Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTReopenAccountingPeriodWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTReopenAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}/reopen";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTReopenAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Re-open accounting period Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTReopenAccountingPeriodAsync (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTReopenAccountingPeriodAsyncWithHttpInfo(apId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Re-open accounting period Re-opens an accounting period. See [Re-Open Accounting Periods](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for more information. Prerequisites - -- -- -- -- -- -- * You must have Zuora Finance enabled on your tenant. * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- -- * The accounting period must be closed or pending close. * You can only re-open an accounting period that is immediately previous to an open period. See [re-open an accounting period](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/H_Reopen_accounting_periods) for an example.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period that you want to re-open.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTReopenAccountingPeriodAsyncWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTReopenAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}/reopen";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTReopenAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Run trial balance Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTRunTrialBalance (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTRunTrialBalanceWithHttpInfo(apId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Run trial balance Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTRunTrialBalanceWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTRunTrialBalance");

            var localVarPath = "/accounting-periods/{ap-id}/run-trial-balance";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTRunTrialBalance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Run trial balance Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTRunTrialBalanceAsync (string apId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTRunTrialBalanceAsyncWithHttpInfo(apId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Run trial balance Runs the trial balance for an accounting period. See [Run a Trial Balance](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/E_Accounting_Periods/D_Run_a_trial_balance) for more information.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Manage Close Process and Run Trial Balance user permissions. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).             Limitations  - -- -- -- -- --    * The accounting period must be open.    * The accounting period cannot already be in the process of running a trial balance.   Notes - -- -- The trial balance is run asynchronously. A response of &#x60;{ \&quot;success\&quot;: true }&#x60; means only that the trial balance has started processing, but does not mean that the trial balance has successfully completed. You can use the [Get Accounting Period](https://knowledgecenter.zuora.com/DC_Developers/REST_API/B_REST_API_reference/Accounting_Periods/Get_Accounting_Period) REST API call to view details about the outcome of the trial balance. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period for which you want to run a trial balance.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTRunTrialBalanceAsyncWithHttpInfo (string apId)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTRunTrialBalance");

            var localVarPath = "/accounting-periods/{ap-id}/run-trial-balance";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTRunTrialBalance", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Update accounting period  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTUpdateAccountingPeriod (string apId, PUTAccountingPeriodType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTUpdateAccountingPeriodWithHttpInfo(apId, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update accounting period  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTUpdateAccountingPeriodWithHttpInfo (string apId, PUTAccountingPeriodType request)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTUpdateAccountingPeriod");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingPeriodsApi->PUTUpdateAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter
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
                Exception exception = ExceptionFactory("PUTUpdateAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Update accounting period  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTUpdateAccountingPeriodAsync (string apId, PUTAccountingPeriodType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTUpdateAccountingPeriodAsyncWithHttpInfo(apId, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update accounting period  Updates an accounting period.  Prerequisites - -- -- -- -- -- --  * You must have Zuora Finance enabled on your tenant.  * You must have the Create Accounting Period user permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles).  Limitations - -- -- -- -- --  * You can update the start date of only the earliest accounting period on your tenant. You cannot update the start date of later periods.  * If you update the earliest accounting period, the start date must be equal to or earlier than the date of the earliest transaction on the tenant.  * Start and end dates of accounting periods must be contiguous. For example, if one accounting period ends on January 31, the next period must start on February 1.  * If you have the Revenue Recognition Package and have enabled the \&quot;Monthly recognition over time\&quot; revenue recognition model, the accounting period start date and end date must be on the first day and last day of the month, respectively. Note that the start and end dates do not necessarily have to be in the same month.  * You cannot update the start date or end date of an accounting period if:   * Any revenue has been distributed into the period.   * The period has any active journal entries. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="apId">ID of the accounting period you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTUpdateAccountingPeriodAsyncWithHttpInfo (string apId, PUTAccountingPeriodType request)
        {
            // verify the required parameter 'apId' is set
            if (apId == null)
                throw new ApiException(400, "Missing required parameter 'apId' when calling AccountingPeriodsApi->PUTUpdateAccountingPeriod");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingPeriodsApi->PUTUpdateAccountingPeriod");

            var localVarPath = "/accounting-periods/{ap-id}";
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
            if (apId != null) localVarPathParams.Add("ap-id", Configuration.ApiClient.ParameterToString(apId)); // path parameter
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
                Exception exception = ExceptionFactory("PUTUpdateAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// CRUD: Delete AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ProxyDeleteResponse</returns>
        public ProxyDeleteResponse ProxyDELETEAccountingPeriod (string id)
        {
             ApiResponse<ProxyDeleteResponse> localVarResponse = ProxyDELETEAccountingPeriodWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Delete AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ApiResponse of ProxyDeleteResponse</returns>
        public ApiResponse< ProxyDeleteResponse > ProxyDELETEAccountingPeriodWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingPeriodsApi->ProxyDELETEAccountingPeriod");

            var localVarPath = "/object/accounting-period/{id}";
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
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyDELETEAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyDeleteResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyDeleteResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyDeleteResponse)));
            
        }

        /// <summary>
        /// CRUD: Delete AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ProxyDeleteResponse</returns>
        public async System.Threading.Tasks.Task<ProxyDeleteResponse> ProxyDELETEAccountingPeriodAsync (string id)
        {
             ApiResponse<ProxyDeleteResponse> localVarResponse = await ProxyDELETEAccountingPeriodAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Delete AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ApiResponse (ProxyDeleteResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyDeleteResponse>> ProxyDELETEAccountingPeriodAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingPeriodsApi->ProxyDELETEAccountingPeriod");

            var localVarPath = "/object/accounting-period/{id}";
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
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyDELETEAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyDeleteResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyDeleteResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyDeleteResponse)));
            
        }

        /// <summary>
        /// CRUD: Retrieve AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ProxyGetAccountingPeriod</returns>
        public ProxyGetAccountingPeriod ProxyGETAccountingPeriod (string id, string fields = null)
        {
             ApiResponse<ProxyGetAccountingPeriod> localVarResponse = ProxyGETAccountingPeriodWithHttpInfo(id, fields);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Retrieve AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ApiResponse of ProxyGetAccountingPeriod</returns>
        public ApiResponse< ProxyGetAccountingPeriod > ProxyGETAccountingPeriodWithHttpInfo (string id, string fields = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingPeriodsApi->ProxyGETAccountingPeriod");

            var localVarPath = "/object/accounting-period/{id}";
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
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (fields != null) localVarQueryParams.Add("fields", Configuration.ApiClient.ParameterToString(fields)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyGETAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyGetAccountingPeriod>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyGetAccountingPeriod) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyGetAccountingPeriod)));
            
        }

        /// <summary>
        /// CRUD: Retrieve AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ProxyGetAccountingPeriod</returns>
        public async System.Threading.Tasks.Task<ProxyGetAccountingPeriod> ProxyGETAccountingPeriodAsync (string id, string fields = null)
        {
             ApiResponse<ProxyGetAccountingPeriod> localVarResponse = await ProxyGETAccountingPeriodAsyncWithHttpInfo(id, fields);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Retrieve AccountingPeriod 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ApiResponse (ProxyGetAccountingPeriod)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyGetAccountingPeriod>> ProxyGETAccountingPeriodAsyncWithHttpInfo (string id, string fields = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingPeriodsApi->ProxyGETAccountingPeriod");

            var localVarPath = "/object/accounting-period/{id}";
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
            if (id != null) localVarPathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            if (fields != null) localVarQueryParams.Add("fields", Configuration.ApiClient.ParameterToString(fields)); // query parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyGETAccountingPeriod", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyGetAccountingPeriod>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyGetAccountingPeriod) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyGetAccountingPeriod)));
            
        }

    }
}
