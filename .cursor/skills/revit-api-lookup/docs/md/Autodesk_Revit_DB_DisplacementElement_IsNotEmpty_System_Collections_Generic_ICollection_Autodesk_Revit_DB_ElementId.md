---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.IsNotEmpty(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/e8e91140-0a9e-fac8-ab7a-3de5fd57bf0a.htm
---
# Autodesk.Revit.DB.DisplacementElement.IsNotEmpty Method

Validates that the input set of element ids is valid for a DisplacementElement.

## Syntax (C#)
```csharp
public static bool IsNotEmpty(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - A set of element ids.

## Returns
True if the set of element ids is not empty.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

