---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.IsAdaptivePoint(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/af22c069-a5a5-f786-34b7-3f539e5d6c7a.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.IsAdaptivePoint Method

Verifies if the Reference Point is an Adaptive Point.

## Syntax (C#)
```csharp
public static bool IsAdaptivePoint(
	Document doc,
	ElementId refPointId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id

## Returns
True if the Point is an Adaptive Point (Placement Point or Shape Handle Point).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

