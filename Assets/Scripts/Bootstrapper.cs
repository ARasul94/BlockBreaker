using Services.SaveService;
using Services.SaveService.Implementations;
using Services.SaveService.Interface;
using Services.ServiceLocator;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Bootstrapper: MonoBehaviour
{
    private void Awake()
    {
        var playerPrefsSaveService = new PlayerPrefsSaveService();
        var saveService = new SaveService(playerPrefsSaveService);
        
        ServiceLocator.instance
            //регистрируем сервисы
            .Register<ISaveService>(saveService);
    }
}