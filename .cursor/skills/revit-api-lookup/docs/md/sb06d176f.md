---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.AreElementsValidForCreateParts(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/5cbd9192-b16a-d34e-9cba-75d8a34e3424.htm
---
# Autodesk.Revit.DB.PartUtils.AreElementsValidForCreateParts Method

Identifies if the given elements can be used to create parts.

## Syntax (C#)
```csharp
public static bool AreElementsValidForCreateParts(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be tested for validity for creating parts.

## Returns
True if all member ids are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

