using System.Collections.Generic;
using UnityEngine;

public sealed class CheckMachine : MonoBehaviour
{
    [SerializeField] private SpriteRenderer newCheckIndicator;

    public Check[] Current => _currentChecks.ToArray();
    
    private readonly List<Check> _currentChecks = new List<Check>();
    
    public void PushCheck(Check data)
    {
        newCheckIndicator.gameObject.SetActive(true);
        _currentChecks.Add(data);
    }
    
    public void ReceiveCheck(Check check)
    {
        check.OnReceive();
        _currentChecks.Remove(check);
        
        if(_currentChecks.Count == 0)
            newCheckIndicator.gameObject.SetActive(false);
    }
}