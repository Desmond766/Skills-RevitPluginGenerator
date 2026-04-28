---
kind: method
id: M:Autodesk.Revit.DB.FilledRegion.IsValidFilledRegionTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/5abb7cd1-e4c1-7565-e591-a9d79ccb46c0.htm
---
# Autodesk.Revit.DB.FilledRegion.IsValidFilledRegionTypeId Method

Indicates whether the given Id is a valid filled region type Id.

## Syntax (C#)
```csharp
public static bool IsValidFilledRegionTypeId(
	Document document,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The filled region type Id.

## Returns
True if it is a valid filled region type Id, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

