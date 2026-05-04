---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.IsValidFamilyForNoteBlock(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/7d33490a-45e0-18e5-3b1b-1912c4515367.htm
---
# Autodesk.Revit.DB.ViewSchedule.IsValidFamilyForNoteBlock Method

**中文**: 明细表

Checks whether a family can be used for a note block.

## Syntax (C#)
```csharp
public static bool IsValidFamilyForNoteBlock(
	Document document,
	ElementId familyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **familyId** (`Autodesk.Revit.DB.ElementId`) - The family ID to check.

## Returns
True if the family can be used for a note block,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

