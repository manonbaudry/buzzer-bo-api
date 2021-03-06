﻿using buzzerApi.Models;
using buzzerApi.Dto;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buzzerApi.Exceptions;
using buzzerApi.Enum;

namespace buzzerApi.Dto
{
    public class QuestionImageDtoBO
    {
        public Guid Id { get; set; }
        public string Interogation { get; set; }
        public ReponseDtoBO Reponse { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<MediaQuestionDto> MediaQuestions { get; set; } = new List<MediaQuestionDto>();
    }

    public static class QuestionImageDtoBOExtensions
    {
        public static QuestionImageDtoBO ToDto(this Models.Question entity)
        {
            return new QuestionImageDtoBO
            {
                Id = entity.Id,
                Interogation = entity.Interogation,
                Reponse = entity.Propositions == null ? null : (PropositionDtoBOExtensions.ToDto(entity.Propositions.First(x => x.IsCorrect))).ToReponse(),
                MediaQuestions = entity.MediaQuestions.Select(x => x.ToDto()).ToList(),
                QuestionType = entity.QuestionType
            };
        }
        public static Question ToEntity(this QuestionImageDtoBO dto)
        {
            if (dto.Reponse == null)
            {
                throw new NoResponseException("La question ne contient pas de réponse");
            }
            ICollection<Propositions> propositions = new List<Propositions>();
            propositions.Add(dto.Reponse.ToProposition());
            return new Question
            {
                Id = dto.Id,
                Interogation = dto.Interogation,
                Propositions = propositions,
                QuestionTypeId = dto.QuestionType == null ? null : dto.QuestionType.Id,
                MediaQuestions = dto.MediaQuestions.Select(x => x.ToEntity()).ToList()
            };
        }
    }
}
