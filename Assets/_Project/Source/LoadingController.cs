using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using USE.ScreenService;

namespace Source
{
    public class LoadingController : BaseScreen
    {
        [SerializeField] private Button _cancelButton;
        private CancellationTokenSource _cancellationTokenSource = new();

        private async void Start()
        {
            Initialize();
            _cancelButton.onClick.AddListener(CancelLoadingOperationClickHandler);
            CancellationToken cancellationToken = _cancellationTokenSource.Token;

            try
            {
                bool result = await SimulateAsyncOperationAsync(cancellationToken);

                Debug.Log($"Operação concluída com sucesso? {!result}");
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Operação cancelada por exceção.");
            }
            finally
            {
                ScreenService.UnLoadSceneAsync(_thisScreenRef);
            }
        }

        private async UniTask<bool> SimulateAsyncOperationAsync(CancellationToken cancellationToken)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            return cancellationToken.IsCancellationRequested;
        }

        private void CancelLoadingOperationClickHandler()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
