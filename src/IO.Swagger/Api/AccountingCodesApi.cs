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
    public interface IAccountingCodesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType DELETEAccountingCode (string acId);

        /// <summary>
        /// Delete accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> DELETEAccountingCodeWithHttpInfo (string acId);
        /// <summary>
        /// Query an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to query an accounting code through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>GETAccountingCodeItemType</returns>
        GETAccountingCodeItemType GETAccountingCodeItem (string acId);

        /// <summary>
        /// Query an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to query an accounting code through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>ApiResponse of GETAccountingCodeItemType</returns>
        ApiResponse<GETAccountingCodeItemType> GETAccountingCodeItemWithHttpInfo (string acId);
        /// <summary>
        /// Get all accounting codes
        /// </summary>
        /// <remarks>
        /// This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>GETAccountingCodesType</returns>
        GETAccountingCodesType GETAccountingCodes ();

        /// <summary>
        /// Get all accounting codes
        /// </summary>
        /// <remarks>
        /// This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of GETAccountingCodesType</returns>
        ApiResponse<GETAccountingCodesType> GETAccountingCodesWithHttpInfo ();
        /// <summary>
        /// Create accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTAccountingCodeResponseType</returns>
        POSTAccountingCodeResponseType POSTAccountingCode (POSTAccountingCodeType request);

        /// <summary>
        /// Create accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTAccountingCodeResponseType</returns>
        ApiResponse<POSTAccountingCodeResponseType> POSTAccountingCodeWithHttpInfo (POSTAccountingCodeType request);
        /// <summary>
        /// Update an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTAccountingCode (string acId, PUTAccountingCodeType request);

        /// <summary>
        /// Update an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTAccountingCodeWithHttpInfo (string acId, PUTAccountingCodeType request);
        /// <summary>
        /// Activate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTActivateAccountingCode (string acId);

        /// <summary>
        /// Activate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTActivateAccountingCodeWithHttpInfo (string acId);
        /// <summary>
        /// Deactivate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTDeactivateAccountingCode (string acId);

        /// <summary>
        /// Deactivate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTDeactivateAccountingCodeWithHttpInfo (string acId);
        /// <summary>
        /// CRUD: Delete AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ProxyDeleteResponse</returns>
        ProxyDeleteResponse ProxyDELETEAccountingCode (string id);

        /// <summary>
        /// CRUD: Delete AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ApiResponse of ProxyDeleteResponse</returns>
        ApiResponse<ProxyDeleteResponse> ProxyDELETEAccountingCodeWithHttpInfo (string id);
        /// <summary>
        /// CRUD: Retrieve AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ProxyGetAccountingCode</returns>
        ProxyGetAccountingCode ProxyGETAccountingCode (string id, string fields = null);

        /// <summary>
        /// CRUD: Retrieve AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ApiResponse of ProxyGetAccountingCode</returns>
        ApiResponse<ProxyGetAccountingCode> ProxyGETAccountingCodeWithHttpInfo (string id, string fields = null);
        /// <summary>
        /// CRUD: Create AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        ProxyCreateOrModifyResponse ProxyPOSTAccountingCode (ProxyCreateAccountingCode createRequest);

        /// <summary>
        /// CRUD: Create AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        ApiResponse<ProxyCreateOrModifyResponse> ProxyPOSTAccountingCodeWithHttpInfo (ProxyCreateAccountingCode createRequest);
        /// <summary>
        /// CRUD: Update AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        ProxyCreateOrModifyResponse ProxyPUTAccountingCode (string id, ProxyModifyAccountingCode modifyRequest);

        /// <summary>
        /// CRUD: Update AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        ApiResponse<ProxyCreateOrModifyResponse> ProxyPUTAccountingCodeWithHttpInfo (string id, ProxyModifyAccountingCode modifyRequest);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Delete accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> DELETEAccountingCodeAsync (string acId);

        /// <summary>
        /// Delete accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETEAccountingCodeAsyncWithHttpInfo (string acId);
        /// <summary>
        /// Query an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to query an accounting code through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>Task of GETAccountingCodeItemType</returns>
        System.Threading.Tasks.Task<GETAccountingCodeItemType> GETAccountingCodeItemAsync (string acId);

        /// <summary>
        /// Query an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to query an accounting code through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>Task of ApiResponse (GETAccountingCodeItemType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETAccountingCodeItemType>> GETAccountingCodeItemAsyncWithHttpInfo (string acId);
        /// <summary>
        /// Get all accounting codes
        /// </summary>
        /// <remarks>
        /// This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of GETAccountingCodesType</returns>
        System.Threading.Tasks.Task<GETAccountingCodesType> GETAccountingCodesAsync ();

        /// <summary>
        /// Get all accounting codes
        /// </summary>
        /// <remarks>
        /// This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (GETAccountingCodesType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETAccountingCodesType>> GETAccountingCodesAsyncWithHttpInfo ();
        /// <summary>
        /// Create accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTAccountingCodeResponseType</returns>
        System.Threading.Tasks.Task<POSTAccountingCodeResponseType> POSTAccountingCodeAsync (POSTAccountingCodeType request);

        /// <summary>
        /// Create accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTAccountingCodeResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTAccountingCodeResponseType>> POSTAccountingCodeAsyncWithHttpInfo (POSTAccountingCodeType request);
        /// <summary>
        /// Update an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTAccountingCodeAsync (string acId, PUTAccountingCodeType request);

        /// <summary>
        /// Update an accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTAccountingCodeAsyncWithHttpInfo (string acId, PUTAccountingCodeType request);
        /// <summary>
        /// Activate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTActivateAccountingCodeAsync (string acId);

        /// <summary>
        /// Activate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTActivateAccountingCodeAsyncWithHttpInfo (string acId);
        /// <summary>
        /// Deactivate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTDeactivateAccountingCodeAsync (string acId);

        /// <summary>
        /// Deactivate accounting code
        /// </summary>
        /// <remarks>
        /// This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTDeactivateAccountingCodeAsyncWithHttpInfo (string acId);
        /// <summary>
        /// CRUD: Delete AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ProxyDeleteResponse</returns>
        System.Threading.Tasks.Task<ProxyDeleteResponse> ProxyDELETEAccountingCodeAsync (string id);

        /// <summary>
        /// CRUD: Delete AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ApiResponse (ProxyDeleteResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyDeleteResponse>> ProxyDELETEAccountingCodeAsyncWithHttpInfo (string id);
        /// <summary>
        /// CRUD: Retrieve AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ProxyGetAccountingCode</returns>
        System.Threading.Tasks.Task<ProxyGetAccountingCode> ProxyGETAccountingCodeAsync (string id, string fields = null);

        /// <summary>
        /// CRUD: Retrieve AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ApiResponse (ProxyGetAccountingCode)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyGetAccountingCode>> ProxyGETAccountingCodeAsyncWithHttpInfo (string id, string fields = null);
        /// <summary>
        /// CRUD: Create AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPOSTAccountingCodeAsync (ProxyCreateAccountingCode createRequest);

        /// <summary>
        /// CRUD: Create AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPOSTAccountingCodeAsyncWithHttpInfo (ProxyCreateAccountingCode createRequest);
        /// <summary>
        /// CRUD: Update AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPUTAccountingCodeAsync (string id, ProxyModifyAccountingCode modifyRequest);

        /// <summary>
        /// CRUD: Update AccountingCode
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPUTAccountingCodeAsyncWithHttpInfo (string id, ProxyModifyAccountingCode modifyRequest);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AccountingCodesApi : IAccountingCodesApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingCodesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AccountingCodesApi(String basePath)
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
        /// Initializes a new instance of the <see cref="AccountingCodesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AccountingCodesApi(Configuration configuration = null)
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
        /// Delete accounting code This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType DELETEAccountingCode (string acId)
        {
             ApiResponse<CommonResponseType> localVarResponse = DELETEAccountingCodeWithHttpInfo(acId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete accounting code This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > DELETEAccountingCodeWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->DELETEAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETEAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Delete accounting code This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> DELETEAccountingCodeAsync (string acId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await DELETEAccountingCodeAsyncWithHttpInfo(acId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete accounting code This reference describes how to [delete an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Delete_an_Accounting_Code) through the REST API. ## Prerequisites If you have Z-Finance enabled on your tenant, then you must have the Z-Finance Delete Unused Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only delete accounting codes that have never been associated with any transactions. An accounting code must be deactivated before you can delete it. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to delete.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETEAccountingCodeAsyncWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->DELETEAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETEAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Query an accounting code This reference describes how to query an accounting code through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>GETAccountingCodeItemType</returns>
        public GETAccountingCodeItemType GETAccountingCodeItem (string acId)
        {
             ApiResponse<GETAccountingCodeItemType> localVarResponse = GETAccountingCodeItemWithHttpInfo(acId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Query an accounting code This reference describes how to query an accounting code through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>ApiResponse of GETAccountingCodeItemType</returns>
        public ApiResponse< GETAccountingCodeItemType > GETAccountingCodeItemWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->GETAccountingCodeItem");

            var localVarPath = "/accounting-codes/{ac-id}";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETAccountingCodeItem", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingCodeItemType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingCodeItemType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingCodeItemType)));
            
        }

        /// <summary>
        /// Query an accounting code This reference describes how to query an accounting code through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>Task of GETAccountingCodeItemType</returns>
        public async System.Threading.Tasks.Task<GETAccountingCodeItemType> GETAccountingCodeItemAsync (string acId)
        {
             ApiResponse<GETAccountingCodeItemType> localVarResponse = await GETAccountingCodeItemAsyncWithHttpInfo(acId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Query an accounting code This reference describes how to query an accounting code through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to query.</param>
        /// <returns>Task of ApiResponse (GETAccountingCodeItemType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETAccountingCodeItemType>> GETAccountingCodeItemAsyncWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->GETAccountingCodeItem");

            var localVarPath = "/accounting-codes/{ac-id}";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETAccountingCodeItem", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingCodeItemType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingCodeItemType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingCodeItemType)));
            
        }

        /// <summary>
        /// Get all accounting codes This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>GETAccountingCodesType</returns>
        public GETAccountingCodesType GETAccountingCodes ()
        {
             ApiResponse<GETAccountingCodesType> localVarResponse = GETAccountingCodesWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get all accounting codes This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of GETAccountingCodesType</returns>
        public ApiResponse< GETAccountingCodesType > GETAccountingCodesWithHttpInfo ()
        {

            var localVarPath = "/accounting-codes";
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
                Exception exception = ExceptionFactory("GETAccountingCodes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingCodesType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingCodesType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingCodesType)));
            
        }

        /// <summary>
        /// Get all accounting codes This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of GETAccountingCodesType</returns>
        public async System.Threading.Tasks.Task<GETAccountingCodesType> GETAccountingCodesAsync ()
        {
             ApiResponse<GETAccountingCodesType> localVarResponse = await GETAccountingCodesAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get all accounting codes This reference describes how to query all accounting codes in your chart of accounts through the REST API.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (GETAccountingCodesType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETAccountingCodesType>> GETAccountingCodesAsyncWithHttpInfo ()
        {

            var localVarPath = "/accounting-codes";
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
                Exception exception = ExceptionFactory("GETAccountingCodes", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETAccountingCodesType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETAccountingCodesType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETAccountingCodesType)));
            
        }

        /// <summary>
        /// Create accounting code This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>POSTAccountingCodeResponseType</returns>
        public POSTAccountingCodeResponseType POSTAccountingCode (POSTAccountingCodeType request)
        {
             ApiResponse<POSTAccountingCodeResponseType> localVarResponse = POSTAccountingCodeWithHttpInfo(request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create accounting code This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTAccountingCodeResponseType</returns>
        public ApiResponse< POSTAccountingCodeResponseType > POSTAccountingCodeWithHttpInfo (POSTAccountingCodeType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingCodesApi->POSTAccountingCode");

            var localVarPath = "/accounting-codes";
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
                Exception exception = ExceptionFactory("POSTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTAccountingCodeResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTAccountingCodeResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTAccountingCodeResponseType)));
            
        }

        /// <summary>
        /// Create accounting code This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of POSTAccountingCodeResponseType</returns>
        public async System.Threading.Tasks.Task<POSTAccountingCodeResponseType> POSTAccountingCodeAsync (POSTAccountingCodeType request)
        {
             ApiResponse<POSTAccountingCodeResponseType> localVarResponse = await POSTAccountingCodeAsyncWithHttpInfo(request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create accounting code This reference describes how to create a new accounting code through the REST API.  The accounting code will be active as soon as it has been created.  ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Create Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTAccountingCodeResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTAccountingCodeResponseType>> POSTAccountingCodeAsyncWithHttpInfo (POSTAccountingCodeType request)
        {
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingCodesApi->POSTAccountingCode");

            var localVarPath = "/accounting-codes";
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
                Exception exception = ExceptionFactory("POSTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTAccountingCodeResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTAccountingCodeResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTAccountingCodeResponseType)));
            
        }

        /// <summary>
        /// Update an accounting code This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTAccountingCode (string acId, PUTAccountingCodeType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTAccountingCodeWithHttpInfo(acId, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update an accounting code This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTAccountingCodeWithHttpInfo (string acId, PUTAccountingCodeType request)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->PUTAccountingCode");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingCodesApi->PUTAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter
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
                Exception exception = ExceptionFactory("PUTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Update an accounting code This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTAccountingCodeAsync (string acId, PUTAccountingCodeType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTAccountingCodeAsyncWithHttpInfo(acId, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update an accounting code This reference describes how to update an existing accounting code through the REST API. ## Prerequisites   If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only update accounting codes that are not already associated with any transactions. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to update.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTAccountingCodeAsyncWithHttpInfo (string acId, PUTAccountingCodeType request)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->PUTAccountingCode");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling AccountingCodesApi->PUTAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter
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
                Exception exception = ExceptionFactory("PUTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Activate accounting code This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTActivateAccountingCode (string acId)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTActivateAccountingCodeWithHttpInfo(acId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Activate accounting code This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTActivateAccountingCodeWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->PUTActivateAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}/activate";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTActivateAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Activate accounting code This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTActivateAccountingCodeAsync (string acId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTActivateAccountingCodeAsyncWithHttpInfo(acId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Activate accounting code This reference describes how to [activate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  Prerequisites - -- -- -- -- -- -- If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to activate.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTActivateAccountingCodeAsyncWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->PUTActivateAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}/activate";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTActivateAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Deactivate accounting code This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTDeactivateAccountingCode (string acId)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTDeactivateAccountingCodeWithHttpInfo(acId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Deactivate accounting code This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTDeactivateAccountingCodeWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->PUTDeactivateAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}/deactivate";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTDeactivateAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Deactivate accounting code This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTDeactivateAccountingCodeAsync (string acId)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTDeactivateAccountingCodeAsyncWithHttpInfo(acId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Deactivate accounting code This reference describes how to [deactivate an accounting code](https://knowledgecenter.zuora.com/CC_Finance/A_Z-Finance/G_Chart_of_Accounts/A_Set_Up_Chart_of_Accounts#Activate_or_Deactivate_an_Accounting_Code) through the REST API.  ## Prerequisites If you have Z-Finance enabled on your tenant, you must have the Z-Finance Manage Accounting Code permission. See [Z-Finance Roles](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/User_Roles/f_Finance_Roles). ## Limitations You can only deactivate accounting codes that are not associated with any transactions.  You cannot disable accounting codes of type AccountsReceivable. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="acId">ID of the accounting code you want to deactivate.</param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTDeactivateAccountingCodeAsyncWithHttpInfo (string acId)
        {
            // verify the required parameter 'acId' is set
            if (acId == null)
                throw new ApiException(400, "Missing required parameter 'acId' when calling AccountingCodesApi->PUTDeactivateAccountingCode");

            var localVarPath = "/accounting-codes/{ac-id}/deactivate";
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
            if (acId != null) localVarPathParams.Add("ac-id", Configuration.ApiClient.ParameterToString(acId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("PUTDeactivateAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// CRUD: Delete AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ProxyDeleteResponse</returns>
        public ProxyDeleteResponse ProxyDELETEAccountingCode (string id)
        {
             ApiResponse<ProxyDeleteResponse> localVarResponse = ProxyDELETEAccountingCodeWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Delete AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>ApiResponse of ProxyDeleteResponse</returns>
        public ApiResponse< ProxyDeleteResponse > ProxyDELETEAccountingCodeWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingCodesApi->ProxyDELETEAccountingCode");

            var localVarPath = "/object/accounting-code/{id}";
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
                Exception exception = ExceptionFactory("ProxyDELETEAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyDeleteResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyDeleteResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyDeleteResponse)));
            
        }

        /// <summary>
        /// CRUD: Delete AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ProxyDeleteResponse</returns>
        public async System.Threading.Tasks.Task<ProxyDeleteResponse> ProxyDELETEAccountingCodeAsync (string id)
        {
             ApiResponse<ProxyDeleteResponse> localVarResponse = await ProxyDELETEAccountingCodeAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Delete AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <returns>Task of ApiResponse (ProxyDeleteResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyDeleteResponse>> ProxyDELETEAccountingCodeAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingCodesApi->ProxyDELETEAccountingCode");

            var localVarPath = "/object/accounting-code/{id}";
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
                Exception exception = ExceptionFactory("ProxyDELETEAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyDeleteResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyDeleteResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyDeleteResponse)));
            
        }

        /// <summary>
        /// CRUD: Retrieve AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ProxyGetAccountingCode</returns>
        public ProxyGetAccountingCode ProxyGETAccountingCode (string id, string fields = null)
        {
             ApiResponse<ProxyGetAccountingCode> localVarResponse = ProxyGETAccountingCodeWithHttpInfo(id, fields);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Retrieve AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>ApiResponse of ProxyGetAccountingCode</returns>
        public ApiResponse< ProxyGetAccountingCode > ProxyGETAccountingCodeWithHttpInfo (string id, string fields = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingCodesApi->ProxyGETAccountingCode");

            var localVarPath = "/object/accounting-code/{id}";
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
                Exception exception = ExceptionFactory("ProxyGETAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyGetAccountingCode>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyGetAccountingCode) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyGetAccountingCode)));
            
        }

        /// <summary>
        /// CRUD: Retrieve AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ProxyGetAccountingCode</returns>
        public async System.Threading.Tasks.Task<ProxyGetAccountingCode> ProxyGETAccountingCodeAsync (string id, string fields = null)
        {
             ApiResponse<ProxyGetAccountingCode> localVarResponse = await ProxyGETAccountingCodeAsyncWithHttpInfo(id, fields);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Retrieve AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="fields">Object fields to return (optional)</param>
        /// <returns>Task of ApiResponse (ProxyGetAccountingCode)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyGetAccountingCode>> ProxyGETAccountingCodeAsyncWithHttpInfo (string id, string fields = null)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingCodesApi->ProxyGETAccountingCode");

            var localVarPath = "/object/accounting-code/{id}";
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
                Exception exception = ExceptionFactory("ProxyGETAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyGetAccountingCode>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyGetAccountingCode) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyGetAccountingCode)));
            
        }

        /// <summary>
        /// CRUD: Create AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        public ProxyCreateOrModifyResponse ProxyPOSTAccountingCode (ProxyCreateAccountingCode createRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = ProxyPOSTAccountingCodeWithHttpInfo(createRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Create AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        public ApiResponse< ProxyCreateOrModifyResponse > ProxyPOSTAccountingCodeWithHttpInfo (ProxyCreateAccountingCode createRequest)
        {
            // verify the required parameter 'createRequest' is set
            if (createRequest == null)
                throw new ApiException(400, "Missing required parameter 'createRequest' when calling AccountingCodesApi->ProxyPOSTAccountingCode");

            var localVarPath = "/object/accounting-code";
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
            if (createRequest != null && createRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(createRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPOSTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

        /// <summary>
        /// CRUD: Create AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        public async System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPOSTAccountingCodeAsync (ProxyCreateAccountingCode createRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = await ProxyPOSTAccountingCodeAsyncWithHttpInfo(createRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Create AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPOSTAccountingCodeAsyncWithHttpInfo (ProxyCreateAccountingCode createRequest)
        {
            // verify the required parameter 'createRequest' is set
            if (createRequest == null)
                throw new ApiException(400, "Missing required parameter 'createRequest' when calling AccountingCodesApi->ProxyPOSTAccountingCode");

            var localVarPath = "/object/accounting-code";
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
            if (createRequest != null && createRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(createRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = createRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPOSTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

        /// <summary>
        /// CRUD: Update AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ProxyCreateOrModifyResponse</returns>
        public ProxyCreateOrModifyResponse ProxyPUTAccountingCode (string id, ProxyModifyAccountingCode modifyRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = ProxyPUTAccountingCodeWithHttpInfo(id, modifyRequest);
             return localVarResponse.Data;
        }

        /// <summary>
        /// CRUD: Update AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>ApiResponse of ProxyCreateOrModifyResponse</returns>
        public ApiResponse< ProxyCreateOrModifyResponse > ProxyPUTAccountingCodeWithHttpInfo (string id, ProxyModifyAccountingCode modifyRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingCodesApi->ProxyPUTAccountingCode");
            // verify the required parameter 'modifyRequest' is set
            if (modifyRequest == null)
                throw new ApiException(400, "Missing required parameter 'modifyRequest' when calling AccountingCodesApi->ProxyPUTAccountingCode");

            var localVarPath = "/object/accounting-code/{id}";
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
            if (modifyRequest != null && modifyRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(modifyRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = modifyRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPUTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

        /// <summary>
        /// CRUD: Update AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ProxyCreateOrModifyResponse</returns>
        public async System.Threading.Tasks.Task<ProxyCreateOrModifyResponse> ProxyPUTAccountingCodeAsync (string id, ProxyModifyAccountingCode modifyRequest)
        {
             ApiResponse<ProxyCreateOrModifyResponse> localVarResponse = await ProxyPUTAccountingCodeAsyncWithHttpInfo(id, modifyRequest);
             return localVarResponse.Data;

        }

        /// <summary>
        /// CRUD: Update AccountingCode 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Object id</param>
        /// <param name="modifyRequest"></param>
        /// <returns>Task of ApiResponse (ProxyCreateOrModifyResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<ProxyCreateOrModifyResponse>> ProxyPUTAccountingCodeAsyncWithHttpInfo (string id, ProxyModifyAccountingCode modifyRequest)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AccountingCodesApi->ProxyPUTAccountingCode");
            // verify the required parameter 'modifyRequest' is set
            if (modifyRequest == null)
                throw new ApiException(400, "Missing required parameter 'modifyRequest' when calling AccountingCodesApi->ProxyPUTAccountingCode");

            var localVarPath = "/object/accounting-code/{id}";
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
            if (modifyRequest != null && modifyRequest.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(modifyRequest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = modifyRequest; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("ProxyPUTAccountingCode", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<ProxyCreateOrModifyResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (ProxyCreateOrModifyResponse) Configuration.ApiClient.Deserialize(localVarResponse, typeof(ProxyCreateOrModifyResponse)));
            
        }

    }
}
