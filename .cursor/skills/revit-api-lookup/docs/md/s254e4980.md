---
kind: method
id: M:Autodesk.Revit.DB.Reference.CreateLinkReference(Autodesk.Revit.DB.RevitLinkInstance)
source: html/919d7d3f-f8c2-eb12-4069-0022c20fa13a.htm
---
# Autodesk.Revit.DB.Reference.CreateLinkReference Method

Creates a Reference from a Reference in an RVT Link.

## Syntax (C#)
```csharp
public Reference CreateLinkReference(
	RevitLinkInstance revitLinkInstance
)
```

## Parameters
- **revitLinkInstance** (`Autodesk.Revit.DB.RevitLinkInstance`) - Id of the RevitLinkInstance that contains the reference.

## Remarks
The reference that is returned can be used to create a family instance on a face in an RVT link.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when revitLinkInstance is Nothing nullptr a null reference ( Nothing in Visual Basic) .

