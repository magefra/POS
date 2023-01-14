using AutoMapper;
using POS.Application.Base;
using POS.Application.Dtos.Category.Request;
using POS.Application.Dtos.Category.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validator;
        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filter)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDto>>();
            var categories = await _unitOfWork.Category.ListCategories(filter);

            if (categories is not null)
            {
                response.IsSuccesss = true;
                response.Data = _mapper.Map<BaseEntityResponse<CategoryResponseDto>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDto>>();
            var categories = await _unitOfWork.Category.GetAllAsync();

            if (categories is not null)
            {
                response.IsSuccesss = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDto>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validator.ValidateAsync(requestDto);
            if (!validationResult.IsValid)
            {
                response.Message = ReplyMessage.MESSAAGE_VALIDATE;
                response.IsSuccesss = false;
                response.Errors = validationResult.Errors;
                return response;
            }

            var category = _mapper.Map<Category>(requestDto);
            response.Data = await _unitOfWork.Category.RegisterAsync(category);

            if (response.Data)
            {
                response.IsSuccesss = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAAGE_FAILDER;
            }

            return response;
        }

        public async Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId)
        {
            var response = new BaseResponse<CategoryResponseDto>();
            var category = await _unitOfWork.Category.GetByIdAsync(categoryId);

            if (category is not null)
            {
                response.IsSuccesss = true;
                response.Data = _mapper.Map<CategoryResponseDto>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await CategoryById(categoryId);

            if (categoryEdit.Data is null)
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            var category = _mapper.Map<Category>(requestDto);
            category.Id = categoryId;

            response.Data = await _unitOfWork.Category.EditAsync(category);

            if (response.Data)
            {
                response.IsSuccesss = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAAGE_FAILDER;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            var response = new BaseResponse<bool>();
            var category = await CategoryById(categoryId);
            if (category.Data is null)
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Category.RemoveAsync(categoryId);

            if (response.Data)
            {
                response.IsSuccesss = true;
                response.Message += ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccesss = false;
                response.Message = ReplyMessage.MESSAAGE_FAILDER;
            }

            return response;
        }
    }
}
