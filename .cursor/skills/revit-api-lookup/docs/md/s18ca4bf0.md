---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.ArePartsValidForDivide(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/cc2eb56c-703f-6bec-14ad-67237389d479.htm
---
# Autodesk.Revit.DB.PartUtils.ArePartsValidForDivide Method

Identifies if provided members are valid for dividing parts.

## Syntax (C#)
```csharp
public static bool ArePartsValidForDivide(
	Document document,
	ICollection<ElementId> elementIdsToDivide
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIdsToDivide** (`System.Collections.Generic.ICollection < ElementId >`) - Element ids to be tested for validity for dividing parts.

## Returns
True if all member ids are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

