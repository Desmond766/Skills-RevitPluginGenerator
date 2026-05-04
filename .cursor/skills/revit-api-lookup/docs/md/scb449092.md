---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.GetDisplacedElementIds(Autodesk.Revit.DB.View)
source: html/e77c4376-b546-9939-53d8-af17afa16bd9.htm
---
# Autodesk.Revit.DB.DisplacementElement.GetDisplacedElementIds Method

Returns the element ids of all displaced elements in the specified view.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetDisplacedElementIds(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.

## Returns
The element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

