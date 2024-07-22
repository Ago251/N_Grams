using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProbabilityActionHandler : MonoBehaviour
{
    [SerializeField]
    private int n_grams;
    private PlayerBase player;

    [SerializeField]
    private List<SignType> _actions = new List<SignType>();

    private Dictionary<string, int> _patterns = new Dictionary<string, int>();

    private void Awake()
    {
        player = GetComponent<PlayerBase>();
        player.OnSignPlayed += OnSignPlayed;
    }

    private void OnDestroy()
    {
        player.OnSignPlayed -= OnSignPlayed;
    }

    private void OnSignPlayed(SignType signType)
    {
        _actions.Add(signType);

        if (_actions.Count >= n_grams)
        {
            string pattern = CreatePattern();

            if (!_patterns.ContainsKey(pattern))
                _patterns.Add(pattern, 0);

            _patterns[pattern]++;
        }
    }

    public SignType GetActionWithHighProbility()
    {
        if (_actions.Count < n_grams)
            return (SignType)UnityEngine.Random.Range(0, 2);

        var prefix = CreatePrefix();
        var patternKeys = _patterns.Keys.Where(key => key.StartsWith(prefix));
        
        
        if (patternKeys.Count() == 0)
            return (SignType)UnityEngine.Random.Range(0, 2);

        var pattern = string.Empty;
        var currentProbability = 0;

        
        foreach (var key in patternKeys)
        {
            if (_patterns[key] > currentProbability)
            {
                pattern = key;
                currentProbability = _patterns[key];

            }
            Debug.Log($"Action: {key}, Description: {_patterns[key]}");
        }

        return SignTypeUtility.ConvertStringToType(pattern[pattern.Length - 1]);
    }

    private string CreatePattern()
    {
        string pattern = string.Empty;
        for (int i = _actions.Count - n_grams; i < _actions.Count; i++)
        {
            pattern += _actions[i].GetShortString();
        }

        return pattern;
    }

    private string CreatePrefix()
    {
        string pattern = string.Empty;
        for (int i = _actions.Count - (n_grams - 1); i < _actions.Count; i++)
        {
            pattern += _actions[i].GetShortString();
        }

        return pattern;
    }
}
