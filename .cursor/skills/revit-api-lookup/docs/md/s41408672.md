---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetValidFamiliesForNoteBlock(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/80c6d4cf-d375-5b55-e04a-1a6bd8e43cf5.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetValidFamiliesForNoteBlock Method

**中文**: 明细表

Gets a list of families that can be used for a note block.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetValidFamiliesForNoteBlock(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The IDs of all valid families.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

