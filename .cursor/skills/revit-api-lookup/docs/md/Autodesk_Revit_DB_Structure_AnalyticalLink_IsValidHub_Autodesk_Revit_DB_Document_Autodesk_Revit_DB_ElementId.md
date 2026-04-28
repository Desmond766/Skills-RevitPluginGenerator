---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalLink.IsValidHub(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/5de89b9e-1ca2-dfc9-10f1-f10bc7f5dd8b.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalLink.IsValidHub Method

Checks whether input hub is valid for an AnalyticalLink.

## Syntax (C#)
```csharp
public static bool IsValidHub(
	Document doc,
	ElementId hubId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Hubs's document.
- **hubId** (`Autodesk.Revit.DB.ElementId`) - Hub to test for validity.

## Returns
True is returned when provided hubId points hub that is valid for AnalyticalLink, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

