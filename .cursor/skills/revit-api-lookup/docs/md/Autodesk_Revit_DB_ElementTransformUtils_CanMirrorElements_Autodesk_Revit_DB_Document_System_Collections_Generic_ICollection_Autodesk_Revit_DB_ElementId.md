---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.CanMirrorElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/34aa420d-d9dc-806d-2019-00252b638666.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.CanMirrorElements Method

Determines whether elements can be mirrored.

## Syntax (C#)
```csharp
public static bool CanMirrorElements(
	Document ADoc,
	ICollection<ElementId> elemIds
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document where the elements reside.
- **elemIds** (`System.Collections.Generic.ICollection < ElementId >`) - The elements identified by id.

## Returns
True if the elements can be mirrored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

