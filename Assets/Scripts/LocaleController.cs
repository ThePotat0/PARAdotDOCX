using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleController : MonoBehaviour
{
    private TMP_Text _label;

    void Start()
    {
        _label = GetComponentInChildren<TMP_Text>();
        var saved = PlayerPrefs.GetString("Locale", "");
        if (!string.IsNullOrEmpty(saved))
            StartCoroutine(SetLocale(saved));
        else
            StartCoroutine(UpdateLabel());
    }

    public void OnClick()
    {
        var locales = LocalizationSettings.AvailableLocales.Locales;
        var current = LocalizationSettings.SelectedLocale;
        var index = locales.IndexOf(current);
        var next = locales[(index + 1) % locales.Count];
        PlayerPrefs.SetString("Locale", next.Identifier.Code);
        StartCoroutine(SetLocale(next.Identifier.Code));
    }

    private IEnumerator SetLocale(string code)
    {
        yield return LocalizationSettings.InitializationOperation;

        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.Identifier.Code == code)
            {
                LocalizationSettings.SelectedLocale = locale;
                break;
            }
        }

        if (_label != null)
            _label.text = LocalizationSettings.SelectedLocale.Identifier.Code.ToUpper();
    }

    private IEnumerator UpdateLabel()
    {
        yield return LocalizationSettings.InitializationOperation;
        if (_label != null)
            _label.text = LocalizationSettings.SelectedLocale.Identifier.Code.ToUpper();
    }
}
