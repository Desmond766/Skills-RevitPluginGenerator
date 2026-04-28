---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.IsAdaptiveShapeHandlePoint(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/1d59c38b-f483-6be1-bcec-4fb7d9596cf9.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.IsAdaptiveShapeHandlePoint Method

Verifies if the Reference Point is an Adaptive Shape Handle Point.

## Syntax (C#)
```csharp
public static bool IsAdaptiveShapeHandlePoint(
	Document doc,
	ElementId refPointId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **refPointId** (`Autodesk.Revit.DB.ElementId`) - The ReferencePoint id

## Returns
True if the Point is an Adaptive Shape Handle Point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

