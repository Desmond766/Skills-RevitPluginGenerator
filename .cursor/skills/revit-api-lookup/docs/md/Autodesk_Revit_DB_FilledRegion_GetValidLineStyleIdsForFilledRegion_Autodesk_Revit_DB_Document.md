---
kind: method
id: M:Autodesk.Revit.DB.FilledRegion.GetValidLineStyleIdsForFilledRegion(Autodesk.Revit.DB.Document)
source: html/d85532a7-8165-1701-90ac-cf665b47b58a.htm
---
# Autodesk.Revit.DB.FilledRegion.GetValidLineStyleIdsForFilledRegion Method

Gets the line style Ids which are permitted to be assigned to a filled region.

## Syntax (C#)
```csharp
public static IList<ElementId> GetValidLineStyleIdsForFilledRegion(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.

## Returns
The valid line style Ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

