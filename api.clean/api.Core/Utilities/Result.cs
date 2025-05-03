using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Utilities
{
    public class Result<T>
    {
        public T Value { get; }
        public bool IsSuccess { get; }
        public string[] Errors { get; }

        private Result(T value, bool isSuccess, string[] errors)
        {
            Value = value;
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result<T> Success(T value) => new(value, true, Array.Empty<string>());
        public static Result<T> Failure(params string[] errors) => new(default, false, errors);

        public TResult Match<TResult>(
            Func<T, TResult> success,
            Func<string[], TResult> failure) =>
            IsSuccess ? success(Value) : failure(Errors);
    }
}
