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
    public interface IRevenueSchedulesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete revenue schedule
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType DELETERS (string rsNumber);

        /// <summary>
        /// Delete revenue schedule
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> DELETERSWithHttpInfo (string rsNumber);
        /// <summary>
        /// Get revenue schedule details
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>GETRSDetailType</returns>
        GETRSDetailType GETRSDetail (string rsNumber);

        /// <summary>
        /// Get revenue schedule details
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>ApiResponse of GETRSDetailType</returns>
        ApiResponse<GETRSDetailType> GETRSDetailWithHttpInfo (string rsNumber);
        /// <summary>
        /// Get revenue schedule by subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>GETRSDetailsByChargeType</returns>
        GETRSDetailsByChargeType GETRSDetailsByCharge (string chargeKey);

        /// <summary>
        /// Get revenue schedule by subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>ApiResponse of GETRSDetailsByChargeType</returns>
        ApiResponse<GETRSDetailsByChargeType> GETRSDetailsByChargeWithHttpInfo (string chargeKey);
        /// <summary>
        /// Get a revenue schedule by invoice item ID
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>GETRSDetailType</returns>
        GETRSDetailType GETRSbyInvoiceItem (string invoiceItemId);

        /// <summary>
        /// Get a revenue schedule by invoice item ID
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>ApiResponse of GETRSDetailType</returns>
        ApiResponse<GETRSDetailType> GETRSbyInvoiceItemWithHttpInfo (string invoiceItemId);
        /// <summary>
        /// Get a revenue schedule by invoice item adjustment
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>GETRSDetailType</returns>
        GETRSDetailType GETRSbyInvoiceItemAdjustment (string invoiceItemAdjId);

        /// <summary>
        /// Get a revenue schedule by invoice item adjustment
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>ApiResponse of GETRSDetailType</returns>
        ApiResponse<GETRSDetailType> GETRSbyInvoiceItemAdjustmentWithHttpInfo (string invoiceItemAdjId);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemAdjustmentDistributeByDateRange (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        ApiResponse<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemAdjustmentDistributeByDateRangeWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemAdjustmentManualDistribution (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        ApiResponse<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemAdjustmentManualDistributionWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemDistributeByDateRange (string invoiceItemId, POSTRevenueScheduleByDateRangeType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        ApiResponse<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemDistributeByDateRangeWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByDateRangeType request);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemManualDistribution (string invoiceItemId, POSTRevenueScheduleByTransactionType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        ApiResponse<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemManualDistributionWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByTransactionType request);
        /// <summary>
        /// Create a revenue schedule on a subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByChargeResponseType</returns>
        POSTRevenueScheduleByChargeResponseType POSTRevenueScheduleByChargeResponse (string chargeKey, POSTRevenueScheduleByChargeType request);

        /// <summary>
        /// Create a revenue schedule on a subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByChargeResponseType</returns>
        ApiResponse<POSTRevenueScheduleByChargeResponseType> POSTRevenueScheduleByChargeResponseWithHttpInfo (string chargeKey, POSTRevenueScheduleByChargeType request);
        /// <summary>
        /// Update revenue schedule basic information
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        CommonResponseType PUTRSBasicInfo (string rsNumber, PUTRSBasicInfoType request);

        /// <summary>
        /// Update revenue schedule basic information
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        ApiResponse<CommonResponseType> PUTRSBasicInfoWithHttpInfo (string rsNumber, PUTRSBasicInfoType request);
        /// <summary>
        /// Distribute revenue across accounting periods
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>PUTRevenueScheduleResponseType</returns>
        PUTRevenueScheduleResponseType PUTRevenueAcrossAP (string rsNumber, PUTAllocateManuallyType request);

        /// <summary>
        /// Distribute revenue across accounting periods
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of PUTRevenueScheduleResponseType</returns>
        ApiResponse<PUTRevenueScheduleResponseType> PUTRevenueAcrossAPWithHttpInfo (string rsNumber, PUTAllocateManuallyType request);
        /// <summary>
        /// Distribute revenue by recognition start and end dates
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>PUTRevenueScheduleResponseType</returns>
        PUTRevenueScheduleResponseType PUTRevenueByRecognitionStartandEndDates (string rsNumber, PUTRSTermType request);

        /// <summary>
        /// Distribute revenue by recognition start and end dates
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of PUTRevenueScheduleResponseType</returns>
        ApiResponse<PUTRevenueScheduleResponseType> PUTRevenueByRecognitionStartandEndDatesWithHttpInfo (string rsNumber, PUTRSTermType request);
        /// <summary>
        /// Distribute revenue on a specific date
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>PUTRevenueScheduleResponseType</returns>
        PUTRevenueScheduleResponseType PUTRevenueSpecificDate (string rsNumber, PUTSpecificDateAllocationType request);

        /// <summary>
        /// Distribute revenue on a specific date
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of PUTRevenueScheduleResponseType</returns>
        ApiResponse<PUTRevenueScheduleResponseType> PUTRevenueSpecificDateWithHttpInfo (string rsNumber, PUTSpecificDateAllocationType request);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Delete revenue schedule
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> DELETERSAsync (string rsNumber);

        /// <summary>
        /// Delete revenue schedule
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETERSAsyncWithHttpInfo (string rsNumber);
        /// <summary>
        /// Get revenue schedule details
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>Task of GETRSDetailType</returns>
        System.Threading.Tasks.Task<GETRSDetailType> GETRSDetailAsync (string rsNumber);

        /// <summary>
        /// Get revenue schedule details
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>Task of ApiResponse (GETRSDetailType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETRSDetailType>> GETRSDetailAsyncWithHttpInfo (string rsNumber);
        /// <summary>
        /// Get revenue schedule by subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>Task of GETRSDetailsByChargeType</returns>
        System.Threading.Tasks.Task<GETRSDetailsByChargeType> GETRSDetailsByChargeAsync (string chargeKey);

        /// <summary>
        /// Get revenue schedule by subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>Task of ApiResponse (GETRSDetailsByChargeType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETRSDetailsByChargeType>> GETRSDetailsByChargeAsyncWithHttpInfo (string chargeKey);
        /// <summary>
        /// Get a revenue schedule by invoice item ID
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>Task of GETRSDetailType</returns>
        System.Threading.Tasks.Task<GETRSDetailType> GETRSbyInvoiceItemAsync (string invoiceItemId);

        /// <summary>
        /// Get a revenue schedule by invoice item ID
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>Task of ApiResponse (GETRSDetailType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETRSDetailType>> GETRSbyInvoiceItemAsyncWithHttpInfo (string invoiceItemId);
        /// <summary>
        /// Get a revenue schedule by invoice item adjustment
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>Task of GETRSDetailType</returns>
        System.Threading.Tasks.Task<GETRSDetailType> GETRSbyInvoiceItemAdjustmentAsync (string invoiceItemAdjId);

        /// <summary>
        /// Get a revenue schedule by invoice item adjustment
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>Task of ApiResponse (GETRSDetailType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETRSDetailType>> GETRSbyInvoiceItemAdjustmentAsyncWithHttpInfo (string invoiceItemAdjId);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemAdjustmentDistributeByDateRangeAsync (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemAdjustmentDistributeByDateRangeAsyncWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemAdjustmentManualDistributionAsync (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemAdjustmentManualDistributionAsyncWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemDistributeByDateRangeAsync (string invoiceItemId, POSTRevenueScheduleByDateRangeType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemDistributeByDateRangeAsyncWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByDateRangeType request);
        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemManualDistributionAsync (string invoiceItemId, POSTRevenueScheduleByTransactionType request);

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution)
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemManualDistributionAsyncWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByTransactionType request);
        /// <summary>
        /// Create a revenue schedule on a subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByChargeResponseType</returns>
        System.Threading.Tasks.Task<POSTRevenueScheduleByChargeResponseType> POSTRevenueScheduleByChargeResponseAsync (string chargeKey, POSTRevenueScheduleByChargeType request);

        /// <summary>
        /// Create a revenue schedule on a subscription charge
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByChargeResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByChargeResponseType>> POSTRevenueScheduleByChargeResponseAsyncWithHttpInfo (string chargeKey, POSTRevenueScheduleByChargeType request);
        /// <summary>
        /// Update revenue schedule basic information
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        System.Threading.Tasks.Task<CommonResponseType> PUTRSBasicInfoAsync (string rsNumber, PUTRSBasicInfoType request);

        /// <summary>
        /// Update revenue schedule basic information
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTRSBasicInfoAsyncWithHttpInfo (string rsNumber, PUTRSBasicInfoType request);
        /// <summary>
        /// Distribute revenue across accounting periods
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of PUTRevenueScheduleResponseType</returns>
        System.Threading.Tasks.Task<PUTRevenueScheduleResponseType> PUTRevenueAcrossAPAsync (string rsNumber, PUTAllocateManuallyType request);

        /// <summary>
        /// Distribute revenue across accounting periods
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (PUTRevenueScheduleResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTRevenueScheduleResponseType>> PUTRevenueAcrossAPAsyncWithHttpInfo (string rsNumber, PUTAllocateManuallyType request);
        /// <summary>
        /// Distribute revenue by recognition start and end dates
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of PUTRevenueScheduleResponseType</returns>
        System.Threading.Tasks.Task<PUTRevenueScheduleResponseType> PUTRevenueByRecognitionStartandEndDatesAsync (string rsNumber, PUTRSTermType request);

        /// <summary>
        /// Distribute revenue by recognition start and end dates
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (PUTRevenueScheduleResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTRevenueScheduleResponseType>> PUTRevenueByRecognitionStartandEndDatesAsyncWithHttpInfo (string rsNumber, PUTRSTermType request);
        /// <summary>
        /// Distribute revenue on a specific date
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of PUTRevenueScheduleResponseType</returns>
        System.Threading.Tasks.Task<PUTRevenueScheduleResponseType> PUTRevenueSpecificDateAsync (string rsNumber, PUTSpecificDateAllocationType request);

        /// <summary>
        /// Distribute revenue on a specific date
        /// </summary>
        /// <remarks>
        /// This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (PUTRevenueScheduleResponseType)</returns>
        System.Threading.Tasks.Task<ApiResponse<PUTRevenueScheduleResponseType>> PUTRevenueSpecificDateAsyncWithHttpInfo (string rsNumber, PUTSpecificDateAllocationType request);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class RevenueSchedulesApi : IRevenueSchedulesApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevenueSchedulesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RevenueSchedulesApi(String basePath)
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
        /// Initializes a new instance of the <see cref="RevenueSchedulesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public RevenueSchedulesApi(Configuration configuration = null)
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
        /// Delete revenue schedule This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType DELETERS (string rsNumber)
        {
             ApiResponse<CommonResponseType> localVarResponse = DELETERSWithHttpInfo(rsNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete revenue schedule This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > DELETERSWithHttpInfo (string rsNumber)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->DELETERS");

            var localVarPath = "/revenue-schedules/{rs-number}";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETERS", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Delete revenue schedule This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> DELETERSAsync (string rsNumber)
        {
             ApiResponse<CommonResponseType> localVarResponse = await DELETERSAsyncWithHttpInfo(rsNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete revenue schedule This REST API reference describes how to delete a revenue schedule by specifying its revenue schedule number ## Prerequisites You must have the Delete Custom Revenue Schedule [Z-Finance permission](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/Administrator_Settings/User_Roles/Z-Finance_Roles#Z-Finance_Permissions). 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber"> Revenue schedule number of the revenue schedule you want to delete, for example, RS-00000256. To be deleted, the revenue schedule: * Must be using a custom unlimited recognition rule. * Cannot have any revenue in a closed accounting period. * Cannot be included in a summary journal entry. * Cannot have a revenue schedule date in a closed accounting period. </param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> DELETERSAsyncWithHttpInfo (string rsNumber)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->DELETERS");

            var localVarPath = "/revenue-schedules/{rs-number}";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("DELETERS", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Get revenue schedule details This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>GETRSDetailType</returns>
        public GETRSDetailType GETRSDetail (string rsNumber)
        {
             ApiResponse<GETRSDetailType> localVarResponse = GETRSDetailWithHttpInfo(rsNumber);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get revenue schedule details This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>ApiResponse of GETRSDetailType</returns>
        public ApiResponse< GETRSDetailType > GETRSDetailWithHttpInfo (string rsNumber)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->GETRSDetail");

            var localVarPath = "/revenue-schedules/{rs-number}";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSDetail", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailType)));
            
        }

        /// <summary>
        /// Get revenue schedule details This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>Task of GETRSDetailType</returns>
        public async System.Threading.Tasks.Task<GETRSDetailType> GETRSDetailAsync (string rsNumber)
        {
             ApiResponse<GETRSDetailType> localVarResponse = await GETRSDetailAsyncWithHttpInfo(rsNumber);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get revenue schedule details This REST API reference describes how to get the details of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <returns>Task of ApiResponse (GETRSDetailType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETRSDetailType>> GETRSDetailAsyncWithHttpInfo (string rsNumber)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->GETRSDetail");

            var localVarPath = "/revenue-schedules/{rs-number}";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSDetail", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailType)));
            
        }

        /// <summary>
        /// Get revenue schedule by subscription charge This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>GETRSDetailsByChargeType</returns>
        public GETRSDetailsByChargeType GETRSDetailsByCharge (string chargeKey)
        {
             ApiResponse<GETRSDetailsByChargeType> localVarResponse = GETRSDetailsByChargeWithHttpInfo(chargeKey);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get revenue schedule by subscription charge This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>ApiResponse of GETRSDetailsByChargeType</returns>
        public ApiResponse< GETRSDetailsByChargeType > GETRSDetailsByChargeWithHttpInfo (string chargeKey)
        {
            // verify the required parameter 'chargeKey' is set
            if (chargeKey == null)
                throw new ApiException(400, "Missing required parameter 'chargeKey' when calling RevenueSchedulesApi->GETRSDetailsByCharge");

            var localVarPath = "/revenue-schedules/subscription-charges/{charge-key}";
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
            if (chargeKey != null) localVarPathParams.Add("charge-key", Configuration.ApiClient.ParameterToString(chargeKey)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSDetailsByCharge", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailsByChargeType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailsByChargeType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailsByChargeType)));
            
        }

        /// <summary>
        /// Get revenue schedule by subscription charge This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>Task of GETRSDetailsByChargeType</returns>
        public async System.Threading.Tasks.Task<GETRSDetailsByChargeType> GETRSDetailsByChargeAsync (string chargeKey)
        {
             ApiResponse<GETRSDetailsByChargeType> localVarResponse = await GETRSDetailsByChargeAsyncWithHttpInfo(chargeKey);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get revenue schedule by subscription charge This REST API reference describes how to get the revenue schedule details by specifying subscription charge ID. Request and response field descriptions and sample code are provided
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <returns>Task of ApiResponse (GETRSDetailsByChargeType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETRSDetailsByChargeType>> GETRSDetailsByChargeAsyncWithHttpInfo (string chargeKey)
        {
            // verify the required parameter 'chargeKey' is set
            if (chargeKey == null)
                throw new ApiException(400, "Missing required parameter 'chargeKey' when calling RevenueSchedulesApi->GETRSDetailsByCharge");

            var localVarPath = "/revenue-schedules/subscription-charges/{charge-key}";
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
            if (chargeKey != null) localVarPathParams.Add("charge-key", Configuration.ApiClient.ParameterToString(chargeKey)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSDetailsByCharge", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailsByChargeType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailsByChargeType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailsByChargeType)));
            
        }

        /// <summary>
        /// Get a revenue schedule by invoice item ID This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>GETRSDetailType</returns>
        public GETRSDetailType GETRSbyInvoiceItem (string invoiceItemId)
        {
             ApiResponse<GETRSDetailType> localVarResponse = GETRSbyInvoiceItemWithHttpInfo(invoiceItemId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get a revenue schedule by invoice item ID This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>ApiResponse of GETRSDetailType</returns>
        public ApiResponse< GETRSDetailType > GETRSbyInvoiceItemWithHttpInfo (string invoiceItemId)
        {
            // verify the required parameter 'invoiceItemId' is set
            if (invoiceItemId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemId' when calling RevenueSchedulesApi->GETRSbyInvoiceItem");

            var localVarPath = "/revenue-schedules/invoice-items/{invoice-item-id}";
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
            if (invoiceItemId != null) localVarPathParams.Add("invoice-item-id", Configuration.ApiClient.ParameterToString(invoiceItemId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSbyInvoiceItem", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailType)));
            
        }

        /// <summary>
        /// Get a revenue schedule by invoice item ID This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>Task of GETRSDetailType</returns>
        public async System.Threading.Tasks.Task<GETRSDetailType> GETRSbyInvoiceItemAsync (string invoiceItemId)
        {
             ApiResponse<GETRSDetailType> localVarResponse = await GETRSbyInvoiceItemAsyncWithHttpInfo(invoiceItemId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get a revenue schedule by invoice item ID This REST API reference describes how to get the details of a revenue schedule by specifying the invoice item ID.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">A valid Invoice Item ID.</param>
        /// <returns>Task of ApiResponse (GETRSDetailType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETRSDetailType>> GETRSbyInvoiceItemAsyncWithHttpInfo (string invoiceItemId)
        {
            // verify the required parameter 'invoiceItemId' is set
            if (invoiceItemId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemId' when calling RevenueSchedulesApi->GETRSbyInvoiceItem");

            var localVarPath = "/revenue-schedules/invoice-items/{invoice-item-id}";
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
            if (invoiceItemId != null) localVarPathParams.Add("invoice-item-id", Configuration.ApiClient.ParameterToString(invoiceItemId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSbyInvoiceItem", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailType)));
            
        }

        /// <summary>
        /// Get a revenue schedule by invoice item adjustment This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>GETRSDetailType</returns>
        public GETRSDetailType GETRSbyInvoiceItemAdjustment (string invoiceItemAdjId)
        {
             ApiResponse<GETRSDetailType> localVarResponse = GETRSbyInvoiceItemAdjustmentWithHttpInfo(invoiceItemAdjId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Get a revenue schedule by invoice item adjustment This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>ApiResponse of GETRSDetailType</returns>
        public ApiResponse< GETRSDetailType > GETRSbyInvoiceItemAdjustmentWithHttpInfo (string invoiceItemAdjId)
        {
            // verify the required parameter 'invoiceItemAdjId' is set
            if (invoiceItemAdjId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemAdjId' when calling RevenueSchedulesApi->GETRSbyInvoiceItemAdjustment");

            var localVarPath = "/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-id}/";
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
            if (invoiceItemAdjId != null) localVarPathParams.Add("invoice-item-adj-id", Configuration.ApiClient.ParameterToString(invoiceItemAdjId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSbyInvoiceItemAdjustment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailType)));
            
        }

        /// <summary>
        /// Get a revenue schedule by invoice item adjustment This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>Task of GETRSDetailType</returns>
        public async System.Threading.Tasks.Task<GETRSDetailType> GETRSbyInvoiceItemAdjustmentAsync (string invoiceItemAdjId)
        {
             ApiResponse<GETRSDetailType> localVarResponse = await GETRSbyInvoiceItemAdjustmentAsyncWithHttpInfo(invoiceItemAdjId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Get a revenue schedule by invoice item adjustment This REST API reference describes how to get the details of a revenue schedule by specifying a valid invoice item adjustment identifier. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjId">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72.</param>
        /// <returns>Task of ApiResponse (GETRSDetailType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GETRSDetailType>> GETRSbyInvoiceItemAdjustmentAsyncWithHttpInfo (string invoiceItemAdjId)
        {
            // verify the required parameter 'invoiceItemAdjId' is set
            if (invoiceItemAdjId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemAdjId' when calling RevenueSchedulesApi->GETRSbyInvoiceItemAdjustment");

            var localVarPath = "/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-id}/";
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
            if (invoiceItemAdjId != null) localVarPathParams.Add("invoice-item-adj-id", Configuration.ApiClient.ParameterToString(invoiceItemAdjId)); // path parameter


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GETRSbyInvoiceItemAdjustment", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GETRSDetailType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (GETRSDetailType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(GETRSDetailType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        public POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemAdjustmentDistributeByDateRange (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = POSTRSforInvoiceItemAdjustmentDistributeByDateRangeWithHttpInfo(invoiceItemAdjKey, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        public ApiResponse< POSTRevenueScheduleByTransactionResponseType > POSTRSforInvoiceItemAdjustmentDistributeByDateRangeWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request)
        {
            // verify the required parameter 'invoiceItemAdjKey' is set
            if (invoiceItemAdjKey == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemAdjKey' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentDistributeByDateRange");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentDistributeByDateRange");

            var localVarPath = "/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key}/distribute-revenue-with-date-range";
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
            if (invoiceItemAdjKey != null) localVarPathParams.Add("invoice-item-adj-key", Configuration.ApiClient.ParameterToString(invoiceItemAdjKey)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemAdjustmentDistributeByDateRange", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        public async System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemAdjustmentDistributeByDateRangeAsync (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = await POSTRSforInvoiceItemAdjustmentDistributeByDateRangeAsyncWithHttpInfo(invoiceItemAdjKey, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemAdjustmentDistributeByDateRangeAsyncWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByDateRangeType request)
        {
            // verify the required parameter 'invoiceItemAdjKey' is set
            if (invoiceItemAdjKey == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemAdjKey' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentDistributeByDateRange");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentDistributeByDateRange");

            var localVarPath = "/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key}/distribute-revenue-with-date-range";
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
            if (invoiceItemAdjKey != null) localVarPathParams.Add("invoice-item-adj-key", Configuration.ApiClient.ParameterToString(invoiceItemAdjKey)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemAdjustmentDistributeByDateRange", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        public POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemAdjustmentManualDistribution (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = POSTRSforInvoiceItemAdjustmentManualDistributionWithHttpInfo(invoiceItemAdjKey, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        public ApiResponse< POSTRevenueScheduleByTransactionResponseType > POSTRSforInvoiceItemAdjustmentManualDistributionWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request)
        {
            // verify the required parameter 'invoiceItemAdjKey' is set
            if (invoiceItemAdjKey == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemAdjKey' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentManualDistribution");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentManualDistribution");

            var localVarPath = "/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key}";
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
            if (invoiceItemAdjKey != null) localVarPathParams.Add("invoice-item-adj-key", Configuration.ApiClient.ParameterToString(invoiceItemAdjKey)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemAdjustmentManualDistribution", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        public async System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemAdjustmentManualDistributionAsync (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = await POSTRSforInvoiceItemAdjustmentManualDistributionAsyncWithHttpInfo(invoiceItemAdjKey, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item Adjustment (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item Adjustment and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemAdjKey">ID or number of the Invoice Item Adjustment, for example, e20b07fd416dcfcf0141c81164fd0a72. If the specified Invoice Item Adjustment is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemAdjustmentManualDistributionAsyncWithHttpInfo (string invoiceItemAdjKey, POSTRevenueScheduleByTransactionType request)
        {
            // verify the required parameter 'invoiceItemAdjKey' is set
            if (invoiceItemAdjKey == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemAdjKey' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentManualDistribution");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemAdjustmentManualDistribution");

            var localVarPath = "/revenue-schedules/invoice-item-adjustments/{invoice-item-adj-key}";
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
            if (invoiceItemAdjKey != null) localVarPathParams.Add("invoice-item-adj-key", Configuration.ApiClient.ParameterToString(invoiceItemAdjKey)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemAdjustmentManualDistribution", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        public POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemDistributeByDateRange (string invoiceItemId, POSTRevenueScheduleByDateRangeType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = POSTRSforInvoiceItemDistributeByDateRangeWithHttpInfo(invoiceItemId, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        public ApiResponse< POSTRevenueScheduleByTransactionResponseType > POSTRSforInvoiceItemDistributeByDateRangeWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByDateRangeType request)
        {
            // verify the required parameter 'invoiceItemId' is set
            if (invoiceItemId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemId' when calling RevenueSchedulesApi->POSTRSforInvoiceItemDistributeByDateRange");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemDistributeByDateRange");

            var localVarPath = "/revenue-schedules/invoice-items/{invoice-item-id}/distribute-revenue-with-date-range";
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
            if (invoiceItemId != null) localVarPathParams.Add("invoice-item-id", Configuration.ApiClient.ParameterToString(invoiceItemId)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemDistributeByDateRange", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        public async System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemDistributeByDateRangeAsync (string invoiceItemId, POSTRevenueScheduleByDateRangeType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = await POSTRSforInvoiceItemDistributeByDateRangeAsyncWithHttpInfo(invoiceItemId, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (distribute by date range) This REST API reference describes how to create a revenue schedule for an Invoice Item and distribute the revenue by specifying the recognition start and end dates.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemDistributeByDateRangeAsyncWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByDateRangeType request)
        {
            // verify the required parameter 'invoiceItemId' is set
            if (invoiceItemId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemId' when calling RevenueSchedulesApi->POSTRSforInvoiceItemDistributeByDateRange");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemDistributeByDateRange");

            var localVarPath = "/revenue-schedules/invoice-items/{invoice-item-id}/distribute-revenue-with-date-range";
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
            if (invoiceItemId != null) localVarPathParams.Add("invoice-item-id", Configuration.ApiClient.ParameterToString(invoiceItemId)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemDistributeByDateRange", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByTransactionResponseType</returns>
        public POSTRevenueScheduleByTransactionResponseType POSTRSforInvoiceItemManualDistribution (string invoiceItemId, POSTRevenueScheduleByTransactionType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = POSTRSforInvoiceItemManualDistributionWithHttpInfo(invoiceItemId, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByTransactionResponseType</returns>
        public ApiResponse< POSTRevenueScheduleByTransactionResponseType > POSTRSforInvoiceItemManualDistributionWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByTransactionType request)
        {
            // verify the required parameter 'invoiceItemId' is set
            if (invoiceItemId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemId' when calling RevenueSchedulesApi->POSTRSforInvoiceItemManualDistribution");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemManualDistribution");

            var localVarPath = "/revenue-schedules/invoice-items/{invoice-item-id}";
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
            if (invoiceItemId != null) localVarPathParams.Add("invoice-item-id", Configuration.ApiClient.ParameterToString(invoiceItemId)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemManualDistribution", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByTransactionResponseType</returns>
        public async System.Threading.Tasks.Task<POSTRevenueScheduleByTransactionResponseType> POSTRSforInvoiceItemManualDistributionAsync (string invoiceItemId, POSTRevenueScheduleByTransactionType request)
        {
             ApiResponse<POSTRevenueScheduleByTransactionResponseType> localVarResponse = await POSTRSforInvoiceItemManualDistributionAsyncWithHttpInfo(invoiceItemId, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a revenue schedule for an Invoice Item (manual distribution) This REST API reference describes how to create a revenue schedule for an Invoice Item and manually distribute the revenue.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="invoiceItemId">ID of the Invoice Item, for example, e20b07fd416dcfcf0141c81164fd0a75. If the specified Invoice Item is already associated with a revenue schedule, the call will fail. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByTransactionResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByTransactionResponseType>> POSTRSforInvoiceItemManualDistributionAsyncWithHttpInfo (string invoiceItemId, POSTRevenueScheduleByTransactionType request)
        {
            // verify the required parameter 'invoiceItemId' is set
            if (invoiceItemId == null)
                throw new ApiException(400, "Missing required parameter 'invoiceItemId' when calling RevenueSchedulesApi->POSTRSforInvoiceItemManualDistribution");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRSforInvoiceItemManualDistribution");

            var localVarPath = "/revenue-schedules/invoice-items/{invoice-item-id}";
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
            if (invoiceItemId != null) localVarPathParams.Add("invoice-item-id", Configuration.ApiClient.ParameterToString(invoiceItemId)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRSforInvoiceItemManualDistribution", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByTransactionResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByTransactionResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByTransactionResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule on a subscription charge This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>POSTRevenueScheduleByChargeResponseType</returns>
        public POSTRevenueScheduleByChargeResponseType POSTRevenueScheduleByChargeResponse (string chargeKey, POSTRevenueScheduleByChargeType request)
        {
             ApiResponse<POSTRevenueScheduleByChargeResponseType> localVarResponse = POSTRevenueScheduleByChargeResponseWithHttpInfo(chargeKey, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create a revenue schedule on a subscription charge This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of POSTRevenueScheduleByChargeResponseType</returns>
        public ApiResponse< POSTRevenueScheduleByChargeResponseType > POSTRevenueScheduleByChargeResponseWithHttpInfo (string chargeKey, POSTRevenueScheduleByChargeType request)
        {
            // verify the required parameter 'chargeKey' is set
            if (chargeKey == null)
                throw new ApiException(400, "Missing required parameter 'chargeKey' when calling RevenueSchedulesApi->POSTRevenueScheduleByChargeResponse");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRevenueScheduleByChargeResponse");

            var localVarPath = "/revenue-schedules/subscription-charges/{charge-key}";
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
            if (chargeKey != null) localVarPathParams.Add("charge-key", Configuration.ApiClient.ParameterToString(chargeKey)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRevenueScheduleByChargeResponse", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByChargeResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByChargeResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByChargeResponseType)));
            
        }

        /// <summary>
        /// Create a revenue schedule on a subscription charge This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>Task of POSTRevenueScheduleByChargeResponseType</returns>
        public async System.Threading.Tasks.Task<POSTRevenueScheduleByChargeResponseType> POSTRevenueScheduleByChargeResponseAsync (string chargeKey, POSTRevenueScheduleByChargeType request)
        {
             ApiResponse<POSTRevenueScheduleByChargeResponseType> localVarResponse = await POSTRevenueScheduleByChargeResponseAsyncWithHttpInfo(chargeKey, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create a revenue schedule on a subscription charge This REST API reference describes how to create a revenue schedule by specifying the subscription charge. This method is for custom unlimited revenue recognition only.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="chargeKey">ID of the subscription rate plan charge; for example, 402892793e173340013e173b81000012.</param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (POSTRevenueScheduleByChargeResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<POSTRevenueScheduleByChargeResponseType>> POSTRevenueScheduleByChargeResponseAsyncWithHttpInfo (string chargeKey, POSTRevenueScheduleByChargeType request)
        {
            // verify the required parameter 'chargeKey' is set
            if (chargeKey == null)
                throw new ApiException(400, "Missing required parameter 'chargeKey' when calling RevenueSchedulesApi->POSTRevenueScheduleByChargeResponse");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->POSTRevenueScheduleByChargeResponse");

            var localVarPath = "/revenue-schedules/subscription-charges/{charge-key}";
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
            if (chargeKey != null) localVarPathParams.Add("charge-key", Configuration.ApiClient.ParameterToString(chargeKey)); // path parameter
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
                Exception exception = ExceptionFactory("POSTRevenueScheduleByChargeResponse", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<POSTRevenueScheduleByChargeResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (POSTRevenueScheduleByChargeResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(POSTRevenueScheduleByChargeResponseType)));
            
        }

        /// <summary>
        /// Update revenue schedule basic information This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>CommonResponseType</returns>
        public CommonResponseType PUTRSBasicInfo (string rsNumber, PUTRSBasicInfoType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = PUTRSBasicInfoWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update revenue schedule basic information This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of CommonResponseType</returns>
        public ApiResponse< CommonResponseType > PUTRSBasicInfoWithHttpInfo (string rsNumber, PUTRSBasicInfoType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRSBasicInfo");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRSBasicInfo");

            var localVarPath = "/revenue-schedules/{rs-number}/basic-information";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRSBasicInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Update revenue schedule basic information This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of CommonResponseType</returns>
        public async System.Threading.Tasks.Task<CommonResponseType> PUTRSBasicInfoAsync (string rsNumber, PUTRSBasicInfoType request)
        {
             ApiResponse<CommonResponseType> localVarResponse = await PUTRSBasicInfoAsyncWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update revenue schedule basic information This REST API reference describes how to get basic information of a revenue schedule by specifying the revenue schedule number. Request and response field descriptions and sample code are provided. 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (CommonResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CommonResponseType>> PUTRSBasicInfoAsyncWithHttpInfo (string rsNumber, PUTRSBasicInfoType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRSBasicInfo");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRSBasicInfo");

            var localVarPath = "/revenue-schedules/{rs-number}/basic-information";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRSBasicInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CommonResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CommonResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(CommonResponseType)));
            
        }

        /// <summary>
        /// Distribute revenue across accounting periods This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>PUTRevenueScheduleResponseType</returns>
        public PUTRevenueScheduleResponseType PUTRevenueAcrossAP (string rsNumber, PUTAllocateManuallyType request)
        {
             ApiResponse<PUTRevenueScheduleResponseType> localVarResponse = PUTRevenueAcrossAPWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Distribute revenue across accounting periods This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of PUTRevenueScheduleResponseType</returns>
        public ApiResponse< PUTRevenueScheduleResponseType > PUTRevenueAcrossAPWithHttpInfo (string rsNumber, PUTAllocateManuallyType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRevenueAcrossAP");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRevenueAcrossAP");

            var localVarPath = "/revenue-schedules/{rs-number}/distribute-revenue-across-accounting-periods";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRevenueAcrossAP", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRevenueScheduleResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRevenueScheduleResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRevenueScheduleResponseType)));
            
        }

        /// <summary>
        /// Distribute revenue across accounting periods This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of PUTRevenueScheduleResponseType</returns>
        public async System.Threading.Tasks.Task<PUTRevenueScheduleResponseType> PUTRevenueAcrossAPAsync (string rsNumber, PUTAllocateManuallyType request)
        {
             ApiResponse<PUTRevenueScheduleResponseType> localVarResponse = await PUTRevenueAcrossAPAsyncWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Distribute revenue across accounting periods This REST API reference describes how to distribute revenue by specifying the revenue schedule number. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (PUTRevenueScheduleResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTRevenueScheduleResponseType>> PUTRevenueAcrossAPAsyncWithHttpInfo (string rsNumber, PUTAllocateManuallyType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRevenueAcrossAP");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRevenueAcrossAP");

            var localVarPath = "/revenue-schedules/{rs-number}/distribute-revenue-across-accounting-periods";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRevenueAcrossAP", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRevenueScheduleResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRevenueScheduleResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRevenueScheduleResponseType)));
            
        }

        /// <summary>
        /// Distribute revenue by recognition start and end dates This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>PUTRevenueScheduleResponseType</returns>
        public PUTRevenueScheduleResponseType PUTRevenueByRecognitionStartandEndDates (string rsNumber, PUTRSTermType request)
        {
             ApiResponse<PUTRevenueScheduleResponseType> localVarResponse = PUTRevenueByRecognitionStartandEndDatesWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Distribute revenue by recognition start and end dates This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of PUTRevenueScheduleResponseType</returns>
        public ApiResponse< PUTRevenueScheduleResponseType > PUTRevenueByRecognitionStartandEndDatesWithHttpInfo (string rsNumber, PUTRSTermType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRevenueByRecognitionStartandEndDates");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRevenueByRecognitionStartandEndDates");

            var localVarPath = "/revenue-schedules/{rs-number}/distribute-revenue-with-date-range";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRevenueByRecognitionStartandEndDates", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRevenueScheduleResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRevenueScheduleResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRevenueScheduleResponseType)));
            
        }

        /// <summary>
        /// Distribute revenue by recognition start and end dates This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of PUTRevenueScheduleResponseType</returns>
        public async System.Threading.Tasks.Task<PUTRevenueScheduleResponseType> PUTRevenueByRecognitionStartandEndDatesAsync (string rsNumber, PUTRSTermType request)
        {
             ApiResponse<PUTRevenueScheduleResponseType> localVarResponse = await PUTRevenueByRecognitionStartandEndDatesAsyncWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Distribute revenue by recognition start and end dates This REST API reference describes how to distribute revenue by specifying the recognition start and end dates. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. Specify the revenue schedule whose revenue you want to distribute.    The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (PUTRevenueScheduleResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTRevenueScheduleResponseType>> PUTRevenueByRecognitionStartandEndDatesAsyncWithHttpInfo (string rsNumber, PUTRSTermType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRevenueByRecognitionStartandEndDates");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRevenueByRecognitionStartandEndDates");

            var localVarPath = "/revenue-schedules/{rs-number}/distribute-revenue-with-date-range";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRevenueByRecognitionStartandEndDates", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRevenueScheduleResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRevenueScheduleResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRevenueScheduleResponseType)));
            
        }

        /// <summary>
        /// Distribute revenue on a specific date This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>PUTRevenueScheduleResponseType</returns>
        public PUTRevenueScheduleResponseType PUTRevenueSpecificDate (string rsNumber, PUTSpecificDateAllocationType request)
        {
             ApiResponse<PUTRevenueScheduleResponseType> localVarResponse = PUTRevenueSpecificDateWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Distribute revenue on a specific date This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>ApiResponse of PUTRevenueScheduleResponseType</returns>
        public ApiResponse< PUTRevenueScheduleResponseType > PUTRevenueSpecificDateWithHttpInfo (string rsNumber, PUTSpecificDateAllocationType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRevenueSpecificDate");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRevenueSpecificDate");

            var localVarPath = "/revenue-schedules/{rs-number}/distribute-revenue-on-specific-date";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRevenueSpecificDate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRevenueScheduleResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRevenueScheduleResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRevenueScheduleResponseType)));
            
        }

        /// <summary>
        /// Distribute revenue on a specific date This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of PUTRevenueScheduleResponseType</returns>
        public async System.Threading.Tasks.Task<PUTRevenueScheduleResponseType> PUTRevenueSpecificDateAsync (string rsNumber, PUTSpecificDateAllocationType request)
        {
             ApiResponse<PUTRevenueScheduleResponseType> localVarResponse = await PUTRevenueSpecificDateAsyncWithHttpInfo(rsNumber, request);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Distribute revenue on a specific date This REST API reference describes how to distribute revenue on a specific recognition date. Request and response field descriptions and sample code are provided.
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="rsNumber">Revenue schedule number. The revenue schedule number is always prefixed with \&quot;RS\&quot;, for example, \&quot;RS-00000001\&quot;. </param>
        /// <param name="request"></param>
        /// <returns>Task of ApiResponse (PUTRevenueScheduleResponseType)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PUTRevenueScheduleResponseType>> PUTRevenueSpecificDateAsyncWithHttpInfo (string rsNumber, PUTSpecificDateAllocationType request)
        {
            // verify the required parameter 'rsNumber' is set
            if (rsNumber == null)
                throw new ApiException(400, "Missing required parameter 'rsNumber' when calling RevenueSchedulesApi->PUTRevenueSpecificDate");
            // verify the required parameter 'request' is set
            if (request == null)
                throw new ApiException(400, "Missing required parameter 'request' when calling RevenueSchedulesApi->PUTRevenueSpecificDate");

            var localVarPath = "/revenue-schedules/{rs-number}/distribute-revenue-on-specific-date";
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
            if (rsNumber != null) localVarPathParams.Add("rs-number", Configuration.ApiClient.ParameterToString(rsNumber)); // path parameter
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
                Exception exception = ExceptionFactory("PUTRevenueSpecificDate", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PUTRevenueScheduleResponseType>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PUTRevenueScheduleResponseType) Configuration.ApiClient.Deserialize(localVarResponse, typeof(PUTRevenueScheduleResponseType)));
            
        }

    }
}
