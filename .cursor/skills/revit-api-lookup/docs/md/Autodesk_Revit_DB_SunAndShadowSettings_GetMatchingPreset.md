---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetMatchingPreset
source: html/fb84ce23-7f06-bac4-aec4-d63890b10597.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetMatchingPreset Method

Finds the name of the 'per-document' SunAndShadowSettings that matches the properties
 of this per-view element.

## Syntax (C#)
```csharp
public string GetMatchingPreset()
```

## Returns
Name of the per-document SunAndShadowSettings that matches the view specific element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The SunAndShadowSettings is not view-specific.

