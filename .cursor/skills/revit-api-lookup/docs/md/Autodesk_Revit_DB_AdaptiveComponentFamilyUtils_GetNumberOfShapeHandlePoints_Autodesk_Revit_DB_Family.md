---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetNumberOfShapeHandlePoints(Autodesk.Revit.DB.Family)
source: html/78241d66-f092-f820-9be5-e9d0d36b6af9.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetNumberOfShapeHandlePoints Method

Gets number of Shape Handle Point Elements in Adaptive Component Family.

## Syntax (C#)
```csharp
public static int GetNumberOfShapeHandlePoints(
	Family family
)
```

## Parameters
- **family** (`Autodesk.Revit.DB.Family`) - The Family

## Returns
Number of Adaptive Shape Handle Point Element References in the Adaptive Component Family.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Family family is not an Adaptive Component Family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

