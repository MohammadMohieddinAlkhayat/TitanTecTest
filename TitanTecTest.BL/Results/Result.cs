using System.Collections.Generic;

namespace TitanTecTest.BL.Results
{
    public class Result
    {

    }
    public enum MessageType
    {
        Success = 1,
        Error = 2,
        Warning = 3,
        Info = 4
    }
    public class ApiMessage
    {
        public string Type { get; set; }
        public string Content { get; set; }

        public ApiMessage(string content, MessageType type = MessageType.Error)
        {
            Type = type.ToString();
            Content = content;
        }
    }

    public class StateApiModel : Result
    {
        public string Status { get; set; }
        public string Messages { get; set; }

        public StateApiModel()
        {

        }
        public StateApiModel(string Status, string Message)
        {
            this.Status = Status;
            this.Messages = Message;
        }
    }
    public class ListResult<T> : Result
    {
        public ListResult()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }
    }
    public class DictionaryResult<T, T1> : Result
    {
        public DictionaryResult()
        {
            Items = new Dictionary<T, T1>();
        }

        public Dictionary<T, T1> Items { get; set; }
    }

    public class ApiResult<T> : ApiResult where T : Result
    {
        public T Result { set; get; }

        public ApiResult(bool isOK = true, string message = null) : base(isOK, message)
        {

        }
    }

    public class ApiResult : Result
    {
        /// <summary>
        /// Default constructor will make a successfull result
        /// </summary>
        public ApiResult()
        {

        }

        /// <summary>
        /// default constructor 
        /// </summary>
        /// <param name="isOK"></param>
        /// <param name="message"></param>
        public ApiResult(bool isOK = true, string message = null)
        {
            IsOk = isOK;
            var type = IsOk ? MessageType.Success : MessageType.Error;
            var actualMessage = IsOk ? message ?? "TaskCompletedSuccessfully" : message ?? "UnExpectedError";
            Message = new ApiMessage(actualMessage, type);
        }

        /// <summary>
        /// Detrmine if the action is done or not
        /// </summary>
        public bool IsOk { get; set; } = true;

        /// <summary>
        /// The api response message
        /// will be according to is ok status => if IsOk=true then it will contains a success message otherwise it's an error message
        /// </summary>
        public ApiMessage Message { get; set; }
    }


}
