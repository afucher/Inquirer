﻿using InquirerCore.Console;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;

namespace InquirerCore.Prompts
{
    public class ListInput : BasePrompt
    {
        private string answer;
        private int selectedOption = 0;
        private string[] options;
        public ListInput(string name, string message, string[] options, IScreenManager consoleRender = null) : base(name, message, consoleRender)
        {
            this.options = options;
        }

        public override string Answer()
        {
            return answer;
        }

        public override void Ask()
        {
            var pos = Render();
            var input = consoleRender.GetInputObservable();
            input.Intercept(true);
            input.KeyPress()
                .TakeUntil(input.GetEnterObservable())
                .Where(x => x.Key == ConsoleKey.UpArrow || x.Key == ConsoleKey.DownArrow)
                .Subscribe(x =>
                {
                    if(x.Key == ConsoleKey.UpArrow)
                    {
                        if (selectedOption > 0) selectedOption--;
                    }
                    else
                    {
                        if (selectedOption < options.Length - 1) selectedOption++;
                    };
                    consoleRender.Clean(0, pos[0]);
                    pos = Render();
                });
            answer = (selectedOption+1).ToString();
        }

        public override string[] GetQuestion()
        {
            var question = new string[options.Length+1];
            question[0] = message;
            options.CopyTo(question, 1);

            question[selectedOption + 1] = "> " + question[selectedOption + 1];

            return question;
        }

        public override int[] Render()
        {
            ConsoleMessage[] messages = ProcessInputMessages(GetQuestion());
            return consoleRender.Render(messages, new ConsoleMessage[] { });
        }

        public ConsoleMessage[] ProcessInputMessages(string[] questions)
        {
            var messages = new ConsoleMessage[questions.Length];

            for (int i = 0; i < questions.Length; i++)
            {
                messages[i] = new ConsoleMessage(questions[i]);
                if ((selectedOption + 1) == i)
                    messages[i].SetConsoleColor(ConsoleColor.Cyan);
                else
                    messages[i].SetConsoleColor(ConsoleColor.Gray);
            }

            return messages;
        }
    }
}
