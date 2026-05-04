---
kind: method
id: M:Autodesk.Revit.DB.ConfigurationReloadInfo.GetConnectivityValidation
source: html/d4e50d7c-3e1d-37cf-bbcb-ee98d987d182.htm
---
# Autodesk.Revit.DB.ConfigurationReloadInfo.GetConnectivityValidation Method

Returns information about the post-reload connectivity validation.

## Syntax (C#)
```csharp
public ConnectionValidationInfo GetConnectivityValidation()
```

## Returns
Information about the post-reload connectivity validation.

## Exceptions
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

