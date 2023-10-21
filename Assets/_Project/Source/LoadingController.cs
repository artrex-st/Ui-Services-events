using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using USE.ScreenService;

namespace Source
{
    public class LoadingController : BaseScreen
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private async void Start()
        {
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            try
            {
                bool result = await SimulateAsyncOperationAsync(cancellationToken);

                Debug.Log($"Operação concluída com sucesso? {!result}");
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Operação cancelada por exceção.");
            }
        }

        private async UniTask<bool> SimulateAsyncOperationAsync(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            return cancellationToken.IsCancellationRequested;
        }

        public void CancelOperation()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
