using System;
using System.Collections;
using api;
using UnityEngine;

namespace remote
{
    // https://www.youtube.com/watch?v=YMj2qPq9CP8&t=71s
    public class CommandExecutor : MonoBehaviour
    {
        private const int MaxSeconds = 60;
        private IProgressBar _progressBar;

        CommandExecutor(IProgressBar progressBar)
        {
            _progressBar = progressBar;
        }
        
        public void execute<T> (Command<T> command)
        {
            _progressBar.reset();
            _progressBar.setMaximum(MaxSeconds);
            StartCoroutine(ProcessAsynchronously(command));
        }

        IEnumerator ProcessAsynchronously<T>(Command<T> command)
        {
            AsyncOperation operation = command.process();

            while (!operation.isDone)
            {
                _progressBar.incrementSelection();
                yield return null;
            }
        }
    }
}
