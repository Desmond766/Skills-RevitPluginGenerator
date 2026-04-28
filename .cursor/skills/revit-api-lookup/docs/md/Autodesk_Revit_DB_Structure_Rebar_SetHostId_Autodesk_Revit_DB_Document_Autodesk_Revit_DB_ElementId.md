---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetHostId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 钢筋、配筋
source: html/79da5994-50ed-171f-adf2-9a6550c898db.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetHostId Method

**中文**: 钢筋、配筋

The element that contains the rebar.

## Syntax (C#)
```csharp
public void SetHostId(
	Document doc,
	ElementId hostId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document containing both this element and the host element.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The element that the rebar object belongs to, such as a structural
 wall, floor, foundation, beam, brace or column. The rebar does not need
 to be strictly inside the host, but it must be assigned to one host
 element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - hostId is not a legal Rebar host (see the RebarHostData class).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

