﻿using FluentValidation;
using Microsoft.Extensions.Options;
using ReactChan.Domain.Entities.Board;
using ReactChan.Models.Thread;
using System.Linq;
using System.Threading.Tasks;

namespace ReactChan.Validators.Thread
{
    public class CreateThreadDtoValidator : AbstractValidator<CreateThreadDto>
    {
        private readonly IBoardService _boardService;
        private readonly AppSettings _appSettings;

        public CreateThreadDtoValidator(
            IBoardService boardService,
            IOptions<AppSettings> options)
        {
            _boardService = boardService;
            _appSettings = options.Value;

            RuleFor(x => x).CustomAsync(async (dto, ctx, _) => await ValidateDto(dto, ctx));
        }

        private async Task ValidateDto(CreateThreadDto dto, ValidationContext<CreateThreadDto> context)
        {
            if (dto == null)
            {
                context.AddFailure(nameof(CreateThreadDto), "Null DTO");
            }
            else
            {
                if (dto.Post == null)
                {
                    context.AddFailure(nameof(CreateThreadDto.Post), "Null Post");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(dto.Post.Text))
                    {
                        context.AddFailure(nameof(CreateThreadDto.Post.Text), "Invalid Post text");
                    }
                    else
                    {
                        var board = await _boardService.GetByIdAsync(dto.BoardId);
                        if (board == null)
                        {
                            context.AddFailure(nameof(CreateThreadDto.BoardId), "Invalid Board identifier");
                        }
                        else if (board.Threads.Count() + 1 > board.MaxThreads)
                        {
                            context.AddFailure(nameof(CreateThreadDto), "Max number of threads reached");
                        }
                    }
                }
            }
        }
    }
}