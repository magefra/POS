using FluentValidation.Results;

namespace POS.Application.Base
{
    public class BaseResponse<T>
    {
        public bool IsSuccesss { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
