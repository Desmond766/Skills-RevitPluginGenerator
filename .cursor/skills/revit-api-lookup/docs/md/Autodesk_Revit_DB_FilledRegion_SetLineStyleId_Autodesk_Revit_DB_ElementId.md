---
kind: method
id: M:Autodesk.Revit.DB.FilledRegion.SetLineStyleId(Autodesk.Revit.DB.ElementId)
source: html/799a16c2-dba1-f9bf-1d5c-4215d238bee1.htm
---
# Autodesk.Revit.DB.FilledRegion.SetLineStyleId Method

Sets the line style Id for all boundaries.

## Syntax (C#)
```csharp
public void SetLineStyleId(
	ElementId lineStyleId
)
```

## Parameters
- **lineStyleId** (`Autodesk.Revit.DB.ElementId`) - The line style Id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - lineStyleId is not a valid line style Id for a filled region.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

