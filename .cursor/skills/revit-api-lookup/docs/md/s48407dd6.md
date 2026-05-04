---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetNumberOfAdaptivePoints(Autodesk.Revit.DB.Family)
source: html/86837f8c-894a-a858-3984-af7cc142a1e1.htm
---
# Autodesk.Revit.DB.AdaptiveComponentFamilyUtils.GetNumberOfAdaptivePoints Method

Gets number of Adaptive Point Elements in Adaptive Component Family.

## Syntax (C#)
```csharp
public static int GetNumberOfAdaptivePoints(
	Family family
)
```

## Parameters
- **family** (`Autodesk.Revit.DB.Family`) - The Family

## Returns
Number of Adaptive Point Element References in Adaptive Component Family.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Family family is not an Adaptive Component Family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

