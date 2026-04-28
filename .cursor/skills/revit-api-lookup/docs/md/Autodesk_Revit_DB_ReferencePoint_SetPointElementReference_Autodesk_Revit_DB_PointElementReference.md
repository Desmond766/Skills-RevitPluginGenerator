---
kind: method
id: M:Autodesk.Revit.DB.ReferencePoint.SetPointElementReference(Autodesk.Revit.DB.PointElementReference)
source: html/2fe8dd3a-06f6-42f0-52c6-49e83c2c28f2.htm
---
# Autodesk.Revit.DB.ReferencePoint.SetPointElementReference Method

Change the rule for computing the 
location of the ReferencePoint relative to other elements in
the document.

## Syntax (C#)
```csharp
public void SetPointElementReference(
	PointElementReference pointElementReference
)
```

## Parameters
- **pointElementReference** (`Autodesk.Revit.DB.PointElementReference`) - An object specifying
a rule for the location and orientation of a ReferencePoint.
(Note: The ReferencePoint object does not store the
pointElementReference object after this call.)

## Remarks
pointElementReference may be Nothing nullptr a null reference ( Nothing in Visual Basic) , in which case the ReferencePoint
does not follow any other element. When Reference is changed
from Nothing nullptr a null reference ( Nothing in Visual Basic) to a non-null value, the point moves and rotates
to the prescribed location and orientation. Where the 
coordinate system has some freedom, it will remain as close
to the old orientation as possible. When
the reference is set to Nothing nullptr a null reference ( Nothing in Visual Basic) , the point does not move or
rotate.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when Reference is set to a non-null object, and the
ReferencePoint is unable to move to the new reference.

