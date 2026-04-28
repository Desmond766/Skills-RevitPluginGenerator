---
kind: method
id: M:Autodesk.Revit.DB.FilledRegion.IsValidLineStyleIdForFilledRegion(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/81b206f9-39bb-ecaf-36e3-3a4c31718972.htm
---
# Autodesk.Revit.DB.FilledRegion.IsValidLineStyleIdForFilledRegion Method

Indicates whether the given Id is a valid line style Id.

## Syntax (C#)
```csharp
public static bool IsValidLineStyleIdForFilledRegion(
	Document document,
	ElementId lineStyleId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **lineStyleId** (`Autodesk.Revit.DB.ElementId`) - The line style Id.

## Returns
True if it is a valid line style Id, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

