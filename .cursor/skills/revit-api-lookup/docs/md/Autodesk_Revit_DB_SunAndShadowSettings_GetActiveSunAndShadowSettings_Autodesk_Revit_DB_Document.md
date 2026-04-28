---
kind: method
id: M:Autodesk.Revit.DB.SunAndShadowSettings.GetActiveSunAndShadowSettings(Autodesk.Revit.DB.Document)
source: html/172fb455-c62c-7baf-6d11-a458a1c9b725.htm
---
# Autodesk.Revit.DB.SunAndShadowSettings.GetActiveSunAndShadowSettings Method

Returns the current SunAndShadowSettings element assigned to the active view for the
 supplied document.

## Syntax (C#)
```csharp
public static Element GetActiveSunAndShadowSettings(
	Document aDocument
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The active SunAndShadowSettings element for the supplied document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

