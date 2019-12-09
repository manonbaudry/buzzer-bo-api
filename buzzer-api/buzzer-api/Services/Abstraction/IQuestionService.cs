﻿using buzzerApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace buzzerApi.Services.Abstraction
{
    public interface IQuestionService
    {
        Task CreateQuestionTexte(Question question);

        IEnumerable<Question> GetListAllQuestionTexte();

        Task<bool> DeleteQuestion(Guid id);
        Question GetListOneQuestionTexte(Guid id);
        Question GetListRandomQuestionTexte();
    }
}
