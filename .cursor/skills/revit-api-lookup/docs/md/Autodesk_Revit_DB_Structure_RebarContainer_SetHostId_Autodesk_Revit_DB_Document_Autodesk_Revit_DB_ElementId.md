---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.SetHostId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/affeac8e-7d19-ee94-4a29-3011ab93e8a0.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.SetHostId Method

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
- **Autodesk.Revit.Exceptions.ArgumentException** - hostId is not a legal Rebar Container host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

