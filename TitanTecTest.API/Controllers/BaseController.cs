using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TitanTecTest.BL.Exceptions;
using TitanTecTest.BL.Results;
using TitanTecTest.BL.Services.ServicesPool;

namespace TitanTecTest.API.Controllers
{
    public class BaseController: ControllerBase
    {

        public IHttpContextAccessor HttpContextAccessor { get; }

        /// <summary>
        /// All Logc services
        /// </summary>
        public IServicePool AllServices { get; }


        public BaseController(IServicePool ServicesPool, IHttpContextAccessor httpContextAccessor)
        {
            this.AllServices = ServicesPool;
            HttpContextAccessor = httpContextAccessor;
        }




        /// <summary>
        /// Basic Error Handler For APi Request Faild
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        protected ApiResult BasicErrorHandler(ICoreException error)
        {
            return new ApiResult()
            {
                IsOk = false,
                Message = new ApiMessage(error.Message)
            };
        }


        protected ApiResult BasicErrorHandler(string error)
        {
            return new ApiResult()
            {
                IsOk = false,
                Message = new ApiMessage(error)
            };
        }

        

        /// <summary>
        /// To be used when returning a list of items (objects) to client
        /// So we don't need to map just call this handler and pass the list of items and it will automatically convert it to ListResult
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [NonAction]
        protected ApiResult<ListResult<T>> ListingSuccessHandler<T>(List<T> list, string message = null) where T : Result
        {
            return new ApiResult<ListResult<T>>()
            {
                Message = new ApiMessage(message ?? "TaskCompletedSuccessfully", MessageType.Success),
                Result = new ListResult<T>
                {
                    Items = list
                }
            };
        }

        /// <summary>
        /// Resturn Api liting result directly from a kernel result.
        /// The mapping will be don here
        /// </summary>
        /// <typeparam name="K">The Kerenel result type of the object</typeparam>
        /// <typeparam name="T">The Result Type of the api request</typeparam>
        /// <param name="list">The list return after doing operation in kernel</param>
        /// <param name="message">The message to be customized as needed</param>
        /// <returns></returns>
        [NonAction]
        protected ApiResult<ListResult<T>> ListingSuccessHandler<K, T>(List<K> list, string message = null) where T : Result where K : class
        {
            return new ApiResult<ListResult<T>>()
            {
                Message = new ApiMessage(message ??"TaskCompletedSuccessfully", MessageType.Success),
                Result = new ListResult<T>
                {
                    Items = AllServices.MappingService.Map<List<T>>(list)
                }
            };
        }

        /// <summary>
        /// Basic Success Handler For APi Request Faild
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ApiResult BasicSuccessHandler<T>(T result, string message = null) where T : Result
        {
            return new ApiResult<T>()
            {
                Message = new ApiMessage(message ?? "TaskCompletedSuccessfully", MessageType.Success),
                Result = result
            };
        }

        /// <summary>
        /// Basic Success Handler For APi Request Faild
        /// </summary>
        /// <returns></returns>
        protected ApiResult BasicSuccessHandler(string message = null)
        {
            return new ApiResult()
            {
                IsOk = true,
                Message = new ApiMessage(message ?? "TaskCompletedSuccessfully", MessageType.Success)
            };
        }

    }
}
