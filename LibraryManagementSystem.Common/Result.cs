﻿namespace LibraryManagementSystem.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }

        public static Result<T> SuccessResult(T data, string message = "")
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static Result<T> ErrorResult(string message)
        {
            return new Result<T>
            {
                Success = false,
                Data = default(T),
                Message = message
            };
        }
    }
}
