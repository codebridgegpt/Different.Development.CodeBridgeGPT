﻿using CodeBridgePlatform.AI.Core.Interfaces;
using System.Text.RegularExpressions;

namespace CodeBridgePlatform.AI.Core.Validation
{
    public class TaskExecutionPromptModelReferenceValidator(IModelInspectorService inspectorService) : IPromptValidator
    {
        private readonly IModelInspectorService _inspectorService = inspectorService;

        public List<string> ValidateStringPrompt(string prompt)
        {
            List<string> errors = [];
            var regex = new Regex(@"\b(?<model>[A-Z][A-Za-z0-9]+Model)\b");
            var matches = regex.Matches(prompt);
            foreach ( Match match in matches )
            {
                var model = match.Groups["model"].Value;
                if ( !_inspectorService.ClassExists(model) )
                {
                    errors.Add($"Referenced model '{ model }' does not exist in the project.");
                }
            }
            return errors;
        }
    }
}
